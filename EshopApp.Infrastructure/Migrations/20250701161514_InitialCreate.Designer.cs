
using System;
using EshopApp.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable
namespace EshopApp.Infrastructure.Migrations;


    /// <summary>
    /// Designer class for the InitialCreate migration, responsible for building the target model for EF Core migrations.
    /// </summary>
    [DbContext(typeof(AppDbContext))]
    [Migration("20250701161514_InitialCreate")]
    partial class InitialCreate
    {
        /// <summary>
        /// Builds the target model for the migration, defining entities, relationships, and schema configuration.
        /// </summary>
        /// <param name="modelBuilder">The builder used to construct the model.</param>
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            // ...existing code...
#pragma warning restore 612, 618
        }
    }
