using System.ComponentModel.DataAnnotations;

namespace AssetInformation.Models
{
    /// <summary>
    /// Asset Model
    /// </summary>
    public class AssetModel
    {
        /// <summary>
        /// Asset Id
        /// </summary>
        [Key]
        public int AssetId { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [MaxLength(500)]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Symbol
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ISIN
        /// </summary>
        [Required]
        [MaxLength(500)]
        public string ISIN { get; set; } = string.Empty;
    }
}
