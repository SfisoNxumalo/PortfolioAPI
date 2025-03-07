using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<MessageEntity> Message { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<GuestEntity> Guest { get; set; } 

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //}

    }

    
}
