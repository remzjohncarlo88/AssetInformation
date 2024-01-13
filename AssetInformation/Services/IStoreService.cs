using AssetInformation.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetInformation.Services
{
    /// <summary>
    /// Store Service Interface class
    /// </summary>
    public interface IStoreService
    {
        /// <summary>
        /// GetAssets
        /// </summary>
        /// <returns>List of Assets</returns>
        Task<IEnumerable<AssetModel>> GetAssets();
        /// <summary>
        /// GetAssetByName
        /// </summary>
        /// <param name="name">asset name</param>
        /// <returns>Asset details.</returns>
        Task<AssetModel> GetAssetByName(string name);
        /// <summary>
        /// CreateAsset
        /// </summary>
        /// <param name="assetName">asset's name</param>
        /// <param name="symbol">asset's symbol</param>
        /// <param name="ISIN">isin</param>
        void CreateAsset(string assetName, string symbol, string ISIN);
        /// <summary>
        /// UpdateAsset
        /// </summary>
        /// <param name="assetName">asset's name</param>
        /// <param name="symbol">asset's symbol</param>
        /// <param name="ISIN">isin</param>
        void UpdateAsset(string assetName, string symbol, string ISIN);
        /// <summary>
        /// AddPrice
        /// </summary>
        /// <param name="assetName">asset's name</param>
        /// <param name="sourceName">source's name</param>
        /// <param name="price">price</param>
        /// <param name="createdDate">created date</param>
        void CreatePrice(string assetName, string sourceName, decimal price, DateTime createdDate);
        /// <summary>
        /// UpdatePrice
        /// </summary>
        /// <param name="assetName">asset's name</param>
        /// <param name="sourceName">source's name</param>
        /// <param name="price">price</param>
        void UpdatePrice(string assetName, string sourceName, decimal price);
    }
}
