using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetInformation.Models
{
    /// <summary>
    /// Asset Model
    /// </summary>
    [Table("Asset")]
    public class AssetModel
    {
        /// <summary>
        /// Asset Id
        /// </summary>
        [Key]
        [Column("AssetId")]
        public int AssetId { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [MaxLength(500)]
        [Column("Name")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Symbol
        /// </summary>
        [Required]
        [MaxLength(100)]
        [Column("Symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// ISIN
        /// </summary>
        [Required]
        [MaxLength(500)]
        [Column("ISIN")]
        public string ISIN { get; set; } = string.Empty;
    }
}
