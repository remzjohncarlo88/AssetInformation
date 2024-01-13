using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetInformation.Models
{
    /// <summary>
    /// Source Model
    /// </summary>
    [Table("Source")]
    public class SourceModel
    {
        /// <summary>
        /// Source Id
        /// </summary>
        [Key]
        [Column("SourceId")]
        public int SourceId { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [MaxLength(500)]
        [Column("Name")]
        public string Name { get; set; } = string.Empty;
    }
}
