﻿using AssetInformation.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace AssetInformation.Respositories
{
    /// <summary>
    /// Store Respoitory Interface
    /// </summary>
    public interface IStoreRepository
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
        /// <param name="asset">asset object</param>
        void CreateAsset(AssetModel asset);
        /// <summary>
        /// UpdateAsset
        /// </summary>
        /// <param name="asset">asset object</param>
        void UpdateAsset(AssetModel asset);
        /// <summary>
        /// GetPriceAssets
        /// </summary>
        /// <param name="assetPrices">assetPrice object</param>
        /// <returns>List of prices by asset per date.</returns>
        Task<IEnumerable<AssetSourcePriceModel>> GetPriceAssets(List<AssetSourcePriceModel> assetPrices);
        /// <summary>
        /// AddPrice
        /// </summary>
        /// <param name="assetPrice">AssetPrice object</param>
        void AddPrice(AssetSourcePriceModel assetPrice);
        /// <summary>
        /// UpdatePrice
        /// </summary>
        /// <param name="assetPrice">AssetPrice object</param>
        void UpdatePrice(AssetSourcePriceModel assetPrice);

    }
}
