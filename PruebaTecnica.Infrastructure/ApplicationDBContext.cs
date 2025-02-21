using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace PruebaTecnica.Infrastructure
{
    public class ApplicationDBContext : DbContext
    {
        private readonly IPublisher Publisher;
        public ApplicationDBContext(DbContextOptions Options, IPublisher Publisher) : base(Options)
        {
            this.Publisher = Publisher;
        }
        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            ModelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
            base.OnModelCreating(ModelBuilder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken CancellationToken = default)
        {
            try
            {
                var Result = await base.SaveChangesAsync(CancellationToken);
                return Result;
            }
            catch (DbUpdateConcurrencyException Ex)
            {
                throw new Exception("Ocurrió un error durante la ejecucución del procedimiento: " + Ex.Message);
            }
        }
    }
}
