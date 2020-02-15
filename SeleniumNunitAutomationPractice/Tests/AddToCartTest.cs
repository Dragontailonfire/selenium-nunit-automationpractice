using AutomationPracticeComponents.Pages;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using ProjectComponents.components;

namespace SeleniumNunitAutomationPractice.Tests
{
    public class AddToCartTest
    {
        IWebDriver _webDriver;
        HomePage _homePage;
        SearchCategoryResultPage _searchCategoryResultPage;
        ProductPage _productPage;
        AddedToCartModalPage _addedToCartModalPage;
        ShoppingCartSummaryPage _shoppingCartSummaryPage;

        public AddToCartTest()
        {
            _webDriver = WebDriverManager.Driver;
            _homePage = new HomePage(_webDriver);
            _searchCategoryResultPage = new SearchCategoryResultPage(_webDriver);
            _productPage = new ProductPage(_webDriver);
            _addedToCartModalPage = new AddedToCartModalPage(_webDriver);
            _shoppingCartSummaryPage = new ShoppingCartSummaryPage(_webDriver);
        }
        

        [Test]
        public void AddTshirtToCartAndVerifyCheckoutPage()
        {
            var config = new ConfigurationBuilder().AddJsonFile("config.json").Build();
            _homePage.NavigateToPage(config["test_url"]);

            _homePage.ClickMenuItem("Women");
            _searchCategoryResultPage.VerifyPageIsDisplayed("WOMEN");
            _searchCategoryResultPage.OpenProduct("Faded Short Sleeve T-shirts");
            _productPage.VerifyPageIsDisplayed("Faded Short Sleeve T-shirts");
            _productPage.GiveProductQuantity("2");
            _productPage.SelectProductSize("M");
            _productPage.ClickAddToCart();
            _addedToCartModalPage.VerifyPageIsDisplayed();
            _addedToCartModalPage.ClickProceedToCheckout();
            _shoppingCartSummaryPage.VerifyPageIsDisplayed();
            _shoppingCartSummaryPage.VerifyProductDetails("Faded Short Sleeve T-shirts", "M", "2");
        }

        [OneTimeTearDown]
        public void Stop()
        {
            WebDriverManager.DisposeDriver();
        }
    }
}
