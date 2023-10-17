using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebAppMVC.Domain.Model;

namespace WebAppMVC.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerContactInformaction> CustomerContactInformactions { get; set; }

        public DbSet<Alcohol> Alcohols { get; set; }

        public DbSet<AlcoholIngredient> AlcoholIngredients { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<AlcoholDescription> AlcoholDescriptions { get; set; }

        public DbSet<AlcoholTag> AlcoholTag { get; set; }

        public DbSet<AlcoholCategory> AlcoholCategorys { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Domain.Model.Type> Types { get; set; }

        public Context(DbContextOptions options) : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>()
                .HasMany <CustomerContactInformaction>(it => it.CustomerContactInformaction)
                .WithOne(b => b.Customer)
                .HasForeignKey(e => e.CustomerRef);

            builder.Entity<Customer>()
                .HasMany<Address>(it => it.AddressDetails)
                .WithOne(b => b.Customer)
                .HasForeignKey(e => e.CustomerId);

            builder.Entity<AlcoholTag>()
                .HasKey(it => new { it.AlcoholId, it.TagId });

            builder.Entity<AlcoholTag>()
                .HasOne<Alcohol>(it => it.Alcohol)
                .WithMany(i => i.AlcoholTags)
                .HasForeignKey(it => it.AlcoholId);

            builder.Entity<AlcoholTag>()
                .HasOne<Tag> (it => it.Tag)
                .WithMany(t=>t.AlcoholTags)
                .HasForeignKey(it => it.TagId);

            builder.Entity<Alcohol>()
                .HasOne(a => a.AlcoholDescription)
                .WithOne(b => b.Alcohol)
                .HasForeignKey<AlcoholDescription>(it => it.AlcoholRef);
            
            builder.Entity<Alcohol>()
                .HasOne<Domain.Model.Type>(it => it.Type)
                .WithMany(it => it.Alcohols)
                .HasForeignKey(e => e.TypeId);

            builder.Entity<AlcoholCategory>()
                .HasMany<Alcohol>(it => it.Alcohols)
                .WithOne(b => b.AlcoholCategory)
                .HasForeignKey(e => e.AlcoholCategoryId);

            builder.Entity<AlcoholIngredient>()
                .HasKey(it => new { it.Id, it.AlcoholRef });

            builder.Entity<AlcoholIngredient>()
                .HasOne<Alcohol>(it => it.Alcohol)
                .WithMany(i => i.AlcoholIngredients)
                .HasForeignKey(it => it.AlcoholRef);

            builder.Entity<AlcoholIngredient>()
                .HasOne<Ingredient>(it => it.Ingredients)
                .WithMany(t => t.AlcoholIngredients)
                .HasForeignKey(i => i.IngredientId);
        }
    }
}