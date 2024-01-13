using AssetInformation.Models;

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
    }
}
