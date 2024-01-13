using AssetInformation.Data;
using AssetInformation.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetInformation.Respositories
{
    /// <summary>
    /// Store Repository class
    /// </summary>
    public class StoreRepository : IStoreRepository
    {
        private readonly AppDbContext _dbContext;

        /// <summary>
        /// StoreRepository constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public StoreRepository(AppDbContext dbContext) => _dbContext = dbContext;

        /// <summary>
        /// GetAssets
        /// </summary>
        /// <returns>List of Assets</returns>
        public async Task<IEnumerable<AssetModel>> GetAssets() => await _dbContext.Assets.ToListAsync();
        /// <summary>
        /// GetAssetByName
        /// </summary>
        /// <param name="name">asset name</param>
        /// <returns>Asset details.</returns>
        public async Task<AssetModel> GetAssetByName(string name) => 
            await _dbContext.Assets.Include(x => x.Name.Equals(name)).FirstAsync();
        /// <summary>
        /// CreateAsset
        /// </summary>
        /// <param name="asset">asset object</param>
        public void CreateAsset(AssetModel asset) => _dbContext.Assets.Add(asset);
        /// <summary>
        /// UpdateAsset
        /// </summary>
        /// <param name="asset">asset object</param>
        public void UpdateAsset(AssetModel asset) => _dbContext.Assets.Update(asset);
        /// <summary>
        /// GetPriceAssets
        /// </summary>
        /// <param name="assetPrices">assetPrice object</param>
        /// <returns>List of prices by asset per date.</returns>
        public async Task<IEnumerable<AssetSourcePriceModel>> GetPriceAssets(List<AssetSourcePriceModel> assetPrices)
        {
            List<AssetSourcePriceModel> assetSourcePrices = new List<AssetSourcePriceModel>();

            foreach(var assetSource in assetPrices)
            {
                var returnedAsset = assetSource.SourceId == 0 ? (await _dbContext.AssetSourcePrices.Include(x =>
                x.AssetId.Equals(assetSource.AssetId)
                && x.CreateDate.ToString("yyyy/MM/dd") == assetSource.CreateDate.ToString("yyyy/MM/dd")).FirstAsync()) :
                (await _dbContext.AssetSourcePrices.Include(x =>
                x.AssetId.Equals(assetSource.AssetId)
                && x.CreateDate.ToString("yyyy/MM/dd") == assetSource.CreateDate.ToString("yyyy/MM/dd")
                && x.SourceId.Equals(assetSource.SourceId)).FirstAsync());

                assetSourcePrices.Add(returnedAsset);
            }

            return assetSourcePrices;
        }            
        /// <summary>
        /// AddPrice
        /// </summary>
        /// <param name="assetPrice">AssetPrice object</param>
        public void AddPrice(AssetSourcePriceModel assetPrice) => _dbContext.AssetSourcePrices.Add(assetPrice);
        /// <summary>
        /// UpdatePrice
        /// </summary>
        /// <param name="assetPrice">AssetPrice object</param>
        public void UpdatePrice(AssetSourcePriceModel assetPrice) => _dbContext.AssetSourcePrices.Update(assetPrice);
    }
}
