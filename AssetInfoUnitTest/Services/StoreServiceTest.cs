using AssetInformation.Models;
using AssetInformation.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInfoUnitTest.Services
{
    public class StoreServiceTest : IStoreService
    {
        private readonly List<AssetModel> _assets;
        private readonly List<SourceModel> _sources;
        private readonly List<AssetSourcePriceModel> _prices;

        /// <summary>
        /// StoreServiceTest constructor
        /// </summary>
        public StoreServiceTest()
        {
            _assets = new List<AssetModel>()
            {
                new AssetModel() { AssetId = 1, Name = "Microsoft Corporation", Symbol = "MSFT", ISIN = "US5949181045" }
            };

            _sources = new List<SourceModel>()
            {
                new SourceModel() { SourceId = 1, Name = "Reuters Market Data" }
            };

            _prices = new List<AssetSourcePriceModel>()
            {
                new AssetSourcePriceModel() { Id = 1, AssetId = 1, SourceId = 1, Price = 8,  CreateDate = Convert.ToDateTime("01/01/2024") }
            };
        }

        /// <summary>
        /// GetAssets
        /// </summary>
        /// <returns>List of Assets</returns>
        public IEnumerable<AssetModel> GetAssets()
        {
            return _assets;
        }

        /// <summary>
        /// GetAssetByName
        /// </summary>
        /// <param name="name">asset name</param>
        /// <returns>Asset details.</returns>
        public AssetModel GetAssetByName(string name)
        {
            return _assets.Where(a => a.Name.ToLower().Equals(name.ToLower())).FirstOrDefault();
        }

        /// <summary>
        /// CreateAsset
        /// </summary>
        /// <param name="assetName">asset's name</param>
        /// <param name="symbol">asset's symbol</param>
        /// <param name="ISIN">isin</param>
        public void CreateAsset(string assetName, string symbol, string ISIN)
        {
            _assets.Add(new AssetModel() { AssetId = 2, Name = assetName, Symbol = symbol, ISIN = ISIN });
        }

        /// <summary>
        /// UpdateAsset
        /// </summary>
        /// <param name="assetName">asset's name</param>
        /// <param name="symbol">asset's symbol</param>
        /// <param name="ISIN">isin</param>
        public void UpdateAsset(string assetName, string symbol, string ISIN)
        {
            var obj = _assets.FindIndex(x => x.Name == assetName);
            _assets[obj].Name = assetName;
            _assets[obj].Symbol = symbol;
            _assets[obj].ISIN = ISIN;
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
            var asset = _assets.First(x => x.Name == assetName);
            var source = _sources.First(x => x.Name == sourceName);
            var prices = _prices.FindIndex(x => x.AssetId == asset.AssetId
                    && x.SourceId == source.SourceId && x.CreateDate == createdDate);

            _prices.Add(new AssetSourcePriceModel() { Id = 2, AssetId = asset.AssetId, SourceId = source.SourceId, Price = 8, CreateDate = createdDate });
        }

        /// <summary>
        /// UpdatePrice
        /// </summary>
        /// <param name="assetName">asset's name</param>
        /// <param name="sourceName">source's name</param>
        /// <param name="price">price</param>
        public void UpdatePrice(string assetName, string sourceName, decimal price)
        {
            var asset = _assets.First(x => x.Name == assetName);
            var source = _sources.First(x => x.Name == sourceName);
            var prices = _prices.FindIndex(x => x.AssetId == asset.AssetId);

            _prices[prices].Price = price;
            _prices[prices].CreateDate = DateTime.Now;
        }
    }
}
