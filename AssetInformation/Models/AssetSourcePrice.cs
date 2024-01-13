namespace AssetInformation.Models
{
    /// <summary>
    /// Asset Source Price Model
    /// </summary>
    public class AssetSourcePrice
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Asset Id
        /// </summary>
        public int AssetId { get; set; }
        /// <summary>
        /// Source Id
        /// </summary>
        public int SourceId { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Create Date
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
