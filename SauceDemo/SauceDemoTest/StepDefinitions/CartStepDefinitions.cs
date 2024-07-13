using FrameworkLayer.WebAppUtil;
using FrameworkLayer;
using OpenQA.Selenium;
using PageObjectModel.Page;
using System;
using TechTalk.SpecFlow;
using System.Reflection;
using NUnit.Framework;

namespace SauceDemoTest.StepDefinitions
{
    [Binding]
    public class CartStepDefinitions
    {
        private readonly WebDriverUtils _driverUtils;
        private readonly LoginPage _loginPage;
        private readonly ProductPage _product;
        private readonly CartPage _cartPage;



        public CartStepDefinitions(WebDriverUtils driverUtils)
        {
            _driverUtils = driverUtils;
            _loginPage = new LoginPage(_driverUtils);
            _product = new ProductPage(_driverUtils);
            _cartPage = new CartPage(_driverUtils);
        }
       

       

        [Given(@"I am on Peoduct page")]
        public void GivenIAmOnPeoductPage()
        {
            Assert.That(_product.IsProductLabelDisplayed(), Is.True);
        }

        [When(@"click on the add to cart button of ""([^""]*)"" products")]
        public void WhenClickOnTheAddToCartButtonOfProducts(int numberOfProducts)
        {
            _product.ClickProducts(numberOfProducts);
        }

        [When(@"I click on cart icon")]
        public void WhenIClickOnCartIcon()
        {
            _product.ClickCartIcon();
        }

        [Then(@"I should see the ""([^""]*)"" products that are added")]
        public void ThenIShouldSeeTheProductsThatAreAdded(int numberOfElements)
        {
            Assert.True(numberOfElements == _cartPage.ElementsPresent());
        }

    }
}
