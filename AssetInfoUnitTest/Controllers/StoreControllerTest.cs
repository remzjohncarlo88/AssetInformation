using AssetInformation.Controllers;
using AssetInformation.Models;
using AssetInformation.Services;
using AssetInfoUnitTest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
        public void GetAssets_WhenCalled_ReturnsRightItem()
        {
            // Act
            var items = _controller.GetAssets() as OkObjectResult;
            // Assert
            var itemsEq = Assert.IsType<List<AssetModel>>(items.Value);
            Assert.Single(itemsEq);
        }

        [Fact]
        public void GetAssetByName_WhenCalled_ReturnsRightItem()
        {
            // Act
            var items = _controller.GetAssetByName("Microsoft Corporation") as OkObjectResult;
            // Assert
            var itemsEq = Assert.IsType<AssetModel>(items.Value);
            Assert.Equal("MSFT", (items.Value as AssetModel).Symbol);
        }

        [Fact]
        public void CreateAsset_WhenCalled_ReturnsRightItem()
        {
            string assetName = "GOOGLE", symbol = "GGL", ISIN = "US18";
            // Act
            _controller.CreateAsset(assetName, symbol, assetName);
            var items = _controller.GetAssetByName(assetName) as OkObjectResult;
            // Assert
            var itemsEq = Assert.IsType<AssetModel>(items.Value);
            Assert.Equal("GGL", (items.Value as AssetModel).Symbol);
        }


        [Fact]
        public void CreatePrice_WhenCalled_ReturnsRightItem()
        {
            string assetName = "Microsoft Corporation", sourceName = "Reuters Market Data";
            int price = 8;
            DateTime createdDate = Convert.ToDateTime("01/01/2024");
            // Act
            _controller.CreatePrice(assetName, sourceName, price, createdDate);
            var items = _controller.GetAssetByName(assetName) as OkObjectResult;
            // Assert
            var itemsEq = Assert.IsType<AssetModel>(items.Value);
            Assert.Equal("MSFT", (items.Value as AssetModel).Symbol);
        }

        [Fact]
        public void UpdateAsset_WhenCalled_ReturnsRightItem()
        {
            string assetName = "Microsoft Corporation", symbol = "MSFT", ISIN = "US59491810458";
            // Act
            _controller.UpdateAsset(assetName, symbol, ISIN);
            var items = _controller.GetAssetByName(assetName) as OkObjectResult;
            // Assert
            var itemsEq = Assert.IsType<AssetModel>(items.Value);
            Assert.Equal("US59491810458", (items.Value as AssetModel).ISIN);
        }

        [Fact]
        public void UpdatePrice_WhenCalled_ReturnsRightItem()
        {
            //UpdatePrice(string assetName, string sourceName, decimal price)
            string assetName = "Microsoft Corporation", sourceName = "Reuters Market Data";
            int price = 9;
            // Act
            _controller.UpdatePrice(assetName, sourceName, price);
            var items = _controller.GetAssetByName(assetName) as OkObjectResult;
            // Assert
            var itemsEq = Assert.IsType<AssetModel>(items.Value);
            Assert.Equal("MSFT", (items.Value as AssetModel).Symbol);
        }
    }
}
