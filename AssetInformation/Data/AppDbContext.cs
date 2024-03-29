﻿using AssetInformation.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetInformation.Data
{
    /// <summary>
    /// Application DbContext
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// AppDbContext constructor
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// Asset Set
        /// </summary>
        public DbSet<AssetModel> Assets { get; set; }
        /// <summary>
        /// Asset Sources Prices
        /// </summary>
        public DbSet<AssetSourcePriceModel> AssetSourcePrices { get; set; }

        /// <summary>
        /// Sources
        /// </summary>
        public DbSet<SourceModel> Sources { get; set; }
    }
}
