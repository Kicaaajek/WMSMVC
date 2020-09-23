using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using WMSMVC.Domain.Model;
using WMSMVC.Web.Models;

namespace WMSMVC.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<ClientData> ClientDatas { get; set; }
        public DbSet<Basket> Baskets { get; set; }

        public Context(DbContextOptions options ) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>()
                .HasMany(a => a.Items).WithOne(b => b.Category)
                .HasForeignKey(c => c.CategoryId);
            builder.Entity<Client>()
                .HasMany(i => i.Adresses).WithOne(j => j.Client)
                .HasForeignKey(k => k.ClientId);
            builder.Entity<Client>()
                .HasOne(p => p.ClientData).WithOne(r => r.Client)
                .HasForeignKey<ClientData>(d => d.ClientId);
                

        }
    }
}
