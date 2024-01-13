﻿namespace AssetInformation.Models
{
    /// <summary>
    /// Asset Model
    /// </summary>
    public class AssetModel
    {
        /// <summary>
        /// Asset Id
        /// </summary>
        public int AssetId { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ISIN
        /// </summary>
        public string ISIN { get; set; } = string.Empty;
    }
}