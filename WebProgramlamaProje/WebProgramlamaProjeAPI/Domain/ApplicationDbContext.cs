using System;
using Microsoft.EntityFrameworkCore;

namespace WebProgramlamaProjeAPI.Domain
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
		{

		}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
			foreach (var entityType in builder.Model.GetEntityTypes())
			{
				//entityType.SetTableName(entityType.DisplayName());
				entityType.GetForeignKeys().Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade).ToList().ForEach(fk=>fk.DeleteBehavior = DeleteBehavior.NoAction);
			}
        }

        public DbSet<Flight> Flight { get; set; }
		public DbSet<Ticket> Ticket { get; set; }
		public DbSet<TicketType> TicketType { get; set; }

		
	}
}

