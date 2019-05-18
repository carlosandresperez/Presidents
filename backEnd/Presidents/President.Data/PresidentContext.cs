using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using President.Domain;

namespace President.Data
{
    public class PresidentContext : DbContext
    {
        public PresidentContext(DbContextOptions<PresidentContext> options) : base(options)
        {
        }

        public DbSet<PresidentInfo> PresidentInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
