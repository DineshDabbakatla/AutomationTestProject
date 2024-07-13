using System;
using System.Linq;
using FrameworkLayer.WebAppUtil;
using OpenQA.Selenium;

namespace PageObjectModel.Page
{
    public class ProductPage
    {
        private By _productLabel = By.XPath(".//span[@class='title']");
        private By _backToProducts = By.XPath(".//button[@id='back-to-products']");
        private By _addToCartBtn = By.XPath("//button[@class='btn btn_primary btn_small btn_inventory ']");
        private By _cartIcon = By.Id("shopping_cart_container");
        private WebDriverUtils _driver;

        public ProductPage(WebDriverUtils driver)
        {
            _driver = driver;
        }

        public bool IsProductLabelDisplayed()
        {
            return _driver.GetElement(_productLabel).Displayed;
        }

        public bool IsProductDetailsDisplayed()
        {
            return _driver.GetElement(_backToProducts).Displayed;
        }

        public void ViewProductDetails(string productName)
        {
            IWebElement e = _driver.GetElement(By.XPath($"//div[text()='{productName}']"));
            e.Click();
        }

        public void ClickProducts(int numberOfProducts)
        {
            var elements = _driver.GetElements(_addToCartBtn).ToList();
            for (int i = 0; i < numberOfProducts; i++)
            {
                elements[i].Click();
            }
        }
        public void ClickCartIcon()
        {
            _driver.GetElement(_cartIcon).Click();
        }

    }
}
