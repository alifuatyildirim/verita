﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Verita.Contract.Models;
using Verita.Domain.Entities;

namespace Verita.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserAudit> UserAuditEvents { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<ProductCard> ProductCards { get; set; }
        public DbSet<ProductOrderItem> ProductOrderItems { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Page> Pages{ get; set; }
        public DbSet<PageImage> PageImages{ get; set; }
        public DbSet<BasindaBiz> BasindaBiz { get; set; }
        public DbSet<HomePageSlider> HomePageSlider { get; set; }
        public DbSet<HomePageContent> HomePageContent { get; set; }
        public DbSet<NedenVerita> NedenVerita { get; set; }
        public DbSet<Referanslar> Referanslar { get; set; }
        public DbSet<BunlariBiliyorMusunuz> BunlariBiliyorMusunuz { get; set; }
        public DbSet<Hakkimizda> Hakkimizda { get; set; }
        public DbSet<HakkimizdaTimeLine> HakkimizdaTimeLine { get; set; }
        public DbSet<MeyveliRehber> MeyveliRehber { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
