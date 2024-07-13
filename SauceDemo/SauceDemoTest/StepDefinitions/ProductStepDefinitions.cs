using FrameworkLayer.WebAppUtil;
using FrameworkLayer;
using OpenQA.Selenium;
using PageObjectModel.Page;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Reflection;

namespace SauceDemoTest.StepDefinitions
{
    
    [Binding]
    public class ProductStepDefinitions
    {
        private readonly WebDriverUtils _driverUtils;
        private readonly LoginPage _loginPage;
        private readonly ProductPage _product;

        public ProductStepDefinitions(WebDriverUtils driverUtils)
        {
            _driverUtils = driverUtils;
            _loginPage = new LoginPage(_driverUtils);
            _product = new ProductPage(_driverUtils);
        }

        [Given(@"I am on product page")]
        public void GivenIAmOnProductPage()
        {
        }

        [When(@"I click on a ""([^""]*)"" displayed on home page")]
        public void WhenIClickOnADisplayedOnHomePage(string productName)
        {
            _product.ViewProductDetails(productName);
        }

        [Then(@"Details of the product displayed")]
        public void ThenDetailsOfTheProductDisplayed()
        {
            Assert.That(_product.IsProductDetailsDisplayed(), Is.True);
        }
    }
}
