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
        public DbSet<ClientAdress> ClientAdresses { get; set; }
        public DbSet<ClientData> ClientDatas { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<WorkDone> WorkDones { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkersAdress> WorkersAdresses { get; set; }
        public DbSet<WorkersData> WorkersDatas { get; set; }

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
                .HasMany(i => i.ClientAdresses).WithOne(j => j.Client)
                .HasForeignKey(k => k.ClientId);
            builder.Entity<Client>()
                .HasMany(p => p.ClientDatas).WithOne(r => r.Client)
                .HasForeignKey(d => d.ClientId);
            builder.Entity<Worker>()
                .HasMany(p => p.WorkerAdress).WithOne(r => r.Worker)
                .HasForeignKey(s => s.WorkerId);
            builder.Entity<Worker>()
               .HasMany(p => p.WorkerData).WithOne(r => r.Worker)
               .HasForeignKey(s => s.WorkerId);
            builder.Entity<Worker>()
                .HasMany(p => p.WorkDone).WithOne(r => r.Worker)
                .HasForeignKey(s => s.WorkerId);
            builder.Entity<Client>()
                .HasMany(i => i.Baskets).WithOne(b => b.Client)
                .HasForeignKey(k => k.ClientId);
            /*builder.Entity<Basket>()
                .HasMany(i => i.Items).WithOne(b => b.Baskets)
                .HasForeignKey(k => k.BasketId);*/
        }
    }
}
