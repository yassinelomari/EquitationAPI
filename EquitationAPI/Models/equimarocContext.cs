using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EquitationAPI.Models
{
    public partial class equimarocContext : DbContext
    {

        public equimarocContext(DbContextOptions<equimarocContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Seance> Seances { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(c => c.ClientId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Seance>()
                .Property(s => s.SeanceId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>()
                .Property(u => u.UserId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Task>()
                .Property(t => t.TaskId)
                .ValueGeneratedOnAdd();
        }

    }

}
