using AssetInformation.Controllers;
using AssetInformation.Models;
using AssetInformation.Services;
using AssetInfoUnitTest.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetInfoUnitTest.Controllers
{
    public class StoreControllerTest
    {
        private readonly AssetsStoreController _controller;
        private readonly IStoreService _service;

        /// <summary>
        /// Store Contoller Test 
        /// </summary>
        public StoreControllerTest()
        {
            _service = new StoreServiceTest();
            _controller = new AssetsStoreController(_service);
        }

        [Fact]
        public async void GetAssets_WhenCalled_ReturnsRightItem()
        {
            // Act
            var items = await _controller.GetAssets() as OkObjectResult;
            // Assert
            var itemsEq = Assert.IsType<List<AssetModel>>(items.Value);
            Assert.Single(itemsEq);
        }

        [Fact]
        public async void GetAssetByName_WhenCalled_ReturnsRightItem()
        {
            // Act
            var items = await _controller.GetAssetByName("Microsoft Corporation") as OkObjectResult;
            // Assert
            var itemsEq = Assert.IsType<List<AssetModel>>(items.Value);
            Assert.Single(itemsEq);
        }
    }
}
