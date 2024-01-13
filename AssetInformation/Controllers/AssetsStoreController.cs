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
        /// GetAssets
        /// </summary>
        /// <returns>list of assets</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AssetModel>))]
        [HttpGet("GetAssets")]
        public async Task<IActionResult> GetAssets()
        {
            var owners = await _storeService.GetAssets();
            return Ok(owners);
        }

        /// <summary>
        /// GetAssetByName
        /// </summary>
        /// <param name="name">asset name</param>
        /// <returns>Asset details.</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AssetModel>))]
        [HttpGet("GetAssetByName")]
        public async Task<IActionResult> GetAssetByName(string name)
        {
            var owners = await _storeService.GetAssetByName(name);
            return Ok(owners);
        }
    }
}
