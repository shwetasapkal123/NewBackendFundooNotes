using Microsoft.EntityFrameworkCore;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Layer.Context
{
    public class FundooContext: DbContext
    {
        public FundooContext(DbContextOptions options)
           : base(options)
        {
        }
        public DbSet<Entity.User> Users { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Collaborator> Collaborators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Entity.User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        }
    }
}
