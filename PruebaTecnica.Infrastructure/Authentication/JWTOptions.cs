namespace PruebaTecnica.Infrastructure.Authentication
{
    public class JWTOptions
    {
        public string? Issuer { get; init; }
        public string? Audience { get; init; }
        public string? SecretKey { get; init; }
    }
}
