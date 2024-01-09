﻿using IWantApp.Domain.Products;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace IWantApp.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Product>().Property(p => p.Description).IsRequired(false);
        builder.Entity<Product>().Property(p => p.Name).HasMaxLength(255).IsRequired();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        
        modelBuilder.Entity<Product>().Property(p => p.Code).HasColumnType("decimal(18,2)").IsRequired();
        modelBuilder.Entity<Category>().ToTable("Categories");
    }
}
