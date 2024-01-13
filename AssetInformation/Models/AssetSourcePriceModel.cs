using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetInformation.Models
{
    /// <summary>
    /// Asset Source Price Model
    /// </summary>
    public class AssetSourcePriceModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Asset Id
        /// </summary>
        [Required]
        public int AssetId { get; set; }
        /// <summary>
        /// Source Id
        /// </summary>
        [Required]
        public int SourceId { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        /// <summary>
        /// Create Date
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "{dd MMM yyyy hh:mm:ss}")]
        public DateTime CreateDate { get; set; }
    }
}
