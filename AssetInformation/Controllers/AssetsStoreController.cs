using AssetInformation.Models;
using AssetInformation.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace AssetInformation.Controllers
{
    /// <summary>
    /// AssetsStoreController
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AssetsStoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        /// <summary>
        /// AssetsStoreController constructor
        /// </summary>
        /// <param name="storeService">storeService object</param>
        public AssetsStoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        /// <summary>
        /// Get All Assets
        /// </summary>
        /// <returns>list of assets</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AssetModel>))]
        [HttpGet("GetAssets")]
        public IActionResult GetAssets()
        {
            var owners = _storeService.GetAssets();
            return Ok(owners);
        }

        /// <summary>
        /// Get Asset By Name
        /// </summary>
        /// <param name="name">asset name</param>
        /// <returns>Asset details.</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AssetModel>))]
        [HttpGet("GetAssetByName")]
        public IActionResult GetAssetByName(string name)
        {
            var owners = _storeService.GetAssetByName(name);
            return Ok(owners);
        }

        /// <summary>
        /// Create Asset
        /// </summary>
        /// <param name="assetName">asset's name</param>
        /// <param name="symbol">asset's symbol</param>
        /// <param name="ISIN">isin</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("CreateAsset")]
        public void CreateAsset(string assetName, string symbol, string ISIN)
        {
            _storeService.CreateAsset(assetName, symbol, ISIN);
        }

        /// <summary>
        /// Update Asset
        /// </summary>
        /// <param name="assetName">asset's name</param>
        /// <param name="symbol">asset's symbol</param>
        /// <param name="ISIN">isin</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("UpdateAsset")]
        public void UpdateAsset(string assetName, string symbol, string ISIN)
        {
            _storeService.UpdateAsset(assetName, symbol, ISIN);
        }

        /// <summary>
        /// Add Price
        /// </summary>
        /// <param name="assetName">asset's name</param>
        /// <param name="sourceName">source's name</param>
        /// <param name="price">price</param>
        /// <param name="createdDate">created date</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("CreatePrice")]
        public void CreatePrice(string assetName, string sourceName, decimal price, DateTime createdDate)
        {
            _storeService.CreatePrice(assetName, sourceName, price, createdDate);
        }

        /// <summary>
        /// Update Price
        /// </summary>
        /// <param name="assetName">asset's name</param>
        /// <param name="sourceName">source's name</param>
        /// <param name="price">price</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("UpdatePrice")]
        public void UpdatePrice(string assetName, string sourceName, decimal price)
        {
            _storeService.UpdatePrice(assetName, sourceName, price);
        }
    }
}
