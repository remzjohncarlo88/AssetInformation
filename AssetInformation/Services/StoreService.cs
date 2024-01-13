using AssetInformation.Models;
using AssetInformation.Respositories;
using System.Threading;

namespace AssetInformation.Services
{
    /// <summary>
    /// Store Service class
    /// </summary>
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        /// <summary>
        /// StoreService constructor
        /// </summary>
        /// <param name="storeRepository">store asset information Repository object</param>
        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        /// <summary>
        /// GetAssets
        /// </summary>
        /// <returns>List of Assets</returns>
        public async Task<IEnumerable<AssetModel>> GetAssets()
        {
            return await _storeRepository.GetAssets();
        }
        /// <summary>
        /// GetAssetByName
        /// </summary>
        /// <param name="name">asset name</param>
        /// <returns>Asset details.</returns>
        public async Task<AssetModel> GetAssetByName(string name)
        {
            return await _storeRepository.GetAssetByName(name);
        }
    }
}
