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
        public IEnumerable<AssetModel> GetAssets()
        {
            return _storeRepository.GetAssets();
        }
        /// <summary>
        /// GetAssetByName
        /// </summary>
        /// <param name="name">asset name</param>
        /// <returns>Asset details.</returns>
        public AssetModel GetAssetByName(string name)
        {
            return _storeRepository.GetAssetByName(name);
        }
        /// <summary>
        /// CreateAsset
        /// </summary>
        /// <param name="assetName">asset's name</param>
        /// <param name="symbol">asset's symbol</param>
        /// <param name="ISIN">isin</param>
        public void CreateAsset(string assetName, string symbol, string ISIN)
        {
            AssetModel asset = new AssetModel();
            asset.Name = assetName;
            asset.Symbol = symbol;
            asset.ISIN = ISIN;
            _storeRepository.CreateAsset(asset);
        }
        /// <summary>
        /// UpdateAsset
        /// </summary>
        /// <param name="assetName">asset's name</param>
        /// <param name="symbol">asset's symbol</param>
        /// <param name="ISIN">isin</param>
        public void UpdateAsset(string assetName, string symbol, string ISIN)
        {
            var asset = Task.Run<AssetModel>(async() => _storeRepository.GetAssetByName(assetName)).Result;
            asset.Name = assetName;
            asset.Symbol = symbol;
            asset.ISIN = ISIN;
            _storeRepository.UpdateAsset(asset);
        }
        /// <summary>
        /// AddPrice
        /// </summary>
        /// <param name="assetName">asset's name</param>
        /// <param name="sourceName">source's name</param>
        /// <param name="price">price</param>
        /// <param name="createdDate">created date</param>
        public void CreatePrice(string assetName, string sourceName, decimal price, DateTime createdDate)
        {
            var asset = _storeRepository.GetAssetByName(assetName);
            var source =  _storeRepository.GetSourceByName(sourceName);
            var assetSourcePriceModel = _storeRepository.GetPriceByAssetSource(asset.AssetId, source.SourceId, createdDate);

            assetSourcePriceModel.AssetId = asset.AssetId;
            assetSourcePriceModel.SourceId = source.SourceId;
            assetSourcePriceModel.Price = price;
            assetSourcePriceModel.CreateDate = createdDate;
            _storeRepository.CreatePrice(assetSourcePriceModel);
        }
        /// <summary>
        /// UpdatePrice
        /// </summary>
        /// <param name="assetName">asset's name</param>
        /// <param name="sourceName">source's name</param>
        /// <param name="price">price</param>
        public void UpdatePrice(string assetName, string sourceName, decimal price)
        {
            var asset =  _storeRepository.GetAssetByName(assetName);
            var source = _storeRepository.GetSourceByName(sourceName);
            var assetSourcePriceModel = _storeRepository.GetPriceByAssetSource(asset.AssetId, source.SourceId, DateTime.MinValue);

            assetSourcePriceModel.AssetId = asset.AssetId;
            assetSourcePriceModel.Price = price;
            assetSourcePriceModel.SourceId = source.SourceId;
            assetSourcePriceModel.CreateDate = DateTime.Now;
            _storeRepository.UpdatePrice(assetSourcePriceModel);
        }
    }
}
