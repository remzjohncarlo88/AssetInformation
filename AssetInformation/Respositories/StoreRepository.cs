using AssetInformation.Data;
using AssetInformation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

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
            await _dbContext.Assets.Where(x => x.Name.Equals(name)).FirstAsync();
        /// <summary>
        /// CreateAsset
        /// </summary>
        /// <param name="asset">asset object</param>
        public void CreateAsset(AssetModel asset)
        {
            _dbContext.Assets.Add(asset);
            _dbContext.SaveChanges();
        }
        /// <summary>
        /// UpdateAsset
        /// </summary>
        /// <param name="asset">asset object</param>
        public void UpdateAsset(AssetModel asset)
        {
            _dbContext.Assets.Update(asset);
            _dbContext.SaveChanges();
        }
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
                var returnedAsset = assetSource.SourceId == 0 ? (await _dbContext.AssetSourcePrices.Where(x =>
                x.AssetId.Equals(assetSource.AssetId)
                && x.CreateDate.ToString("yyyy/MM/dd") == assetSource.CreateDate.ToString("yyyy/MM/dd")).FirstAsync()) :
                (await _dbContext.AssetSourcePrices.Where(x =>
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
        public void CreatePrice(AssetSourcePriceModel assetPrice)
        {
            _dbContext.AssetSourcePrices.Add(assetPrice);
            _dbContext.SaveChanges();
        }
        /// <summary>
        /// UpdatePrice
        /// </summary>
        /// <param name="assetPrice">AssetPrice object</param>
        public void UpdatePrice(AssetSourcePriceModel assetPrice)
        {
            _dbContext.AssetSourcePrices.Update(assetPrice);
            _dbContext.SaveChanges();
        }
        /// <summary>
        /// GetAssetByName
        /// </summary>
        /// <param name="name">source name</param>
        /// <returns>Resource details.</returns>
        public async Task<SourceModel> GetSourceByName(string name) =>
            await _dbContext.Sources.Where(x => x.Name.Equals(name)).FirstAsync();
        /// <summary>
        /// GetPriceByAssetSource
        /// </summary>
        /// <param name="assetId">asset id</param>
        /// <param name="sourceId">source id</param>
        /// <param name="createdDate">create date</param>
        /// <returns>AssetSourcePrice details.</returns>
        public async Task<AssetSourcePriceModel> GetPriceByAssetSource(int assetId, int sourceId, DateTime createdDate)
        {
            var data = createdDate != DateTime.MinValue ? 
                    await _dbContext.AssetSourcePrices.Where(x => x.AssetId.Equals(assetId) && x.SourceId.Equals(sourceId)).FirstAsync() :
                    await _dbContext.AssetSourcePrices.Where(x => x.AssetId.Equals(assetId) && x.SourceId.Equals(sourceId)
                        && x.CreateDate.ToString("yyyy/MM/dd") == createdDate.ToString("yyyy/MM/dd")).FirstAsync();

            return data;
        }            
    }
}
