using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PruebaTecnica.Application.Authentication;
using PruebaTecnica.Domain.Models;
using PruebaTecnica.Infrastructure.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PruebaTecnica.Infrastructure.Authentication
{
    public class JWTProvider : IJWTProvider
    {
        private readonly JWTOptions Options;
        private readonly ISQLConnectionFactory SQLConnectionFactory;
        public JWTProvider(IOptions<JWTOptions> Options, ISQLConnectionFactory SQLConnectionFactory)
        {
            this.Options = Options.Value;
            this.SQLConnectionFactory = SQLConnectionFactory;
        }
        public async Task<string> Generate(UserModel User)
        {
            const string SQL = """
            SELECT p.nombre
            FROM user AS usr
                LEFT JOIN user_roles usrl
                ON usr.id = usrl.user_id
                LEFT JOIN roles AS rl
                ON rl.id = usrl.role_id
                LEFT JOIN roles_permissions AS rp
                ON rl.id = rp.role_id
                LEFT JOIN permissions AS p
                ON p.id = rp.permission_id
            WHERE usr.id=@UserId
            """;
            using var Connection = SQLConnectionFactory.CreateConnection();
            var Permissions = await Connection.QueryAsync<string>(SQL, User.Id);
            var PermissionsCollection = Permissions.ToHashSet();
            var Claims = new List<Claim>{
                new(JwtRegisteredClaimNames.Sub, User.Id!.ToString()),
                new(JwtRegisteredClaimNames.Email, User.UserEmail!),
            };
            foreach (var Permission in PermissionsCollection)
            {
                Claims.Add(new(CustomClaims.Permission, "Permission"));
            }
            var SigningCredential = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Options.SecretKey!)), SecurityAlgorithms.HmacSha256);
            var Token = new JwtSecurityToken(Options.Issuer, Options.Audience, Claims, null, DateTime.UtcNow.AddDays(1), SigningCredential);
            var TokenValue = new JwtSecurityTokenHandler().WriteToken(Token);
            return TokenValue;
        }
    }
}
