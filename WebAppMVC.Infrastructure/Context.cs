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

        public DbSet<Item> Items { get; set; }

        public DbSet<ItemIngredient> ItemIngredients { get; set; }

        public DbSet<Ingredient>  Ingredients { get; set; }

        public DbSet<ItemDescription> ItemDescriptions { get; set; }

        public DbSet<ItemTag> ItemTags { get; set; }

        public DbSet<ItemCategory> ItemCategories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Domain.Model.Type> Types { get; set; }

        public Context(DbContextOptions options) : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>()
                .HasOne(a => a.CustomerContactInformaction).WithOne(b => b.Customer)
                .HasForeignKey<CustomerContactInformaction>(e => e.CustomerRef);

            builder.Entity<Customer>()
                .HasMany<Address>(it => it.AddressDetails)
                .WithOne(b => b.Customer)
                .HasForeignKey(e => e.CustomerId);

            builder.Entity<ItemTag>()
                .HasKey(it => new { it.ItemId, it.TagId });

            builder.Entity<ItemTag>()
                .HasOne<Item>(it => it.Item)
                .WithMany(i => i.ItemTags)
                .HasForeignKey(it => it.ItemId);

            builder.Entity<ItemTag>()
                .HasOne<Tag> (it => it.Tag)
                .WithMany(t=>t.ItemTags)
                .HasForeignKey(it => it.TagId);

            builder.Entity<Item>()
                .HasOne(a => a.ItemDescription)
                .WithOne(b => b.Item)
                .HasForeignKey<ItemDescription>(it => it.ItemRef);
            
            builder.Entity<Item>()
                .HasOne<Domain.Model.Type>(it => it.Type)
                .WithMany(it => it.Items)
                .HasForeignKey(it => it.TypeId);

            builder.Entity<ItemCategory>()
                .HasMany<Item>(it => it.Items)
                .WithOne(b => b.ItemCategory)
                .HasForeignKey(e => e.ItemCategoryId);

            builder.Entity<ItemIngredient>()
                .HasKey(it => new { it.ItemIngredientsId, it.ItemRef });

            builder.Entity<ItemIngredient>()
                .HasOne<Item>(it => it.Item)
                .WithMany(i => i.ItemIngredients)
                .HasForeignKey(it => it.ItemRef);

            builder.Entity<ItemIngredient>()
                .HasOne<Ingredient>(it => it.Ingredients)
                .WithMany(t => t.ItemIngredients)
                .HasForeignKey(i => i.ItemIngredientsId);
        }
    }
}
