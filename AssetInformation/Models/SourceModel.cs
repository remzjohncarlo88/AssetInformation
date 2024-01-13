using System.ComponentModel.DataAnnotations;

namespace AssetInformation.Models
{
    /// <summary>
    /// Source Model
    /// </summary>
    public class SourceModel
    {
        /// <summary>
        /// Source Id
        /// </summary>
        [Key]
        public int SourceId { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [MaxLength(500)]
        public string Name { get; set; } = string.Empty;
    }
}
