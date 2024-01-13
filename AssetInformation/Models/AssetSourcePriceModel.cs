using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetInformation.Models
{
    /// <summary>
    /// Asset Source Price Model
    /// </summary>
    [Table("AssetSourcePrice")]
    public class AssetSourcePriceModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        /// <summary>
        /// Asset Id
        /// </summary>
        [Required]
        [Column("AssetId")]
        public int AssetId { get; set; }
        /// <summary>
        /// Source Id
        /// </summary>
        [Required]
        [Column("SourceId")]
        public int SourceId { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        [Required]
        [Column("Price", TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        /// <summary>
        /// Create Date
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "{dd MMM yyyy hh:mm:ss}")]
        [Column("CreateDate")]
        public DateTime CreateDate { get; set; }
    }
}
