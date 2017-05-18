﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SouthAlive.Models;
using SouthAlive.Models.PantryModels;

namespace SouthAlive.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
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

        public DbSet<SouthAlive.Models.PantryModels.Cart> Cart { get; set; }

        public DbSet<SouthAlive.Models.PantryModels.CartProduct> CartProduct { get; set; }

        public DbSet<SouthAlive.Models.PantryModels.Product> Product { get; set; }

        public DbSet<SouthAlive.Models.PantryModels.Recipe> Recipe { get; set; }

        public DbSet<SouthAlive.Models.PantryModels.RecipeProduct> RecipeProduct { get; set; }

        public DbSet<SouthAlive.Models.PantryModels.ProductCategory> ProductCategory { get; set; }



    }
}
