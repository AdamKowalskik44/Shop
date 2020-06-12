using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Data.CustomFieldTypes;
using Shop.Data.ProductTypes;

namespace Shop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CustomField>()
        //        .HasRequired(c => c.Category)
        //        .WithMany()
        //        .WillCascadeOnDelete(false);
        //}

        public DbSet<Category> Categories { get; set; }
        public DbSet<CustomField> CustomFields { get; set; }
        public DbSet<DropDownItem> DropDownItems { get; set; }
        public DbSet<ProductFieldValue> ProductFieldValues  { get; set; }
        public DbSet<ProductFieldValueBool> ProductFieldValuesBool { get; set; }
        public DbSet<ProductFieldValueInt> ProductFieldValuesInt { get; set; }
        public DbSet<ProductFieldValueString> ProductFieldValuesString { get; set; }
        public DbSet<ProductFieldValueFloat> ProductFieldValuesFloat { get; set; }
        public DbSet<ProductFieldValueDDI> ProductFieldValuesDDI { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<CartEntry> CartEntries { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
