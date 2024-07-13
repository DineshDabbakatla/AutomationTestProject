using FrameworkLayer.WebAppUtil;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.Page
{
    public class CartPage
    {

        private WebDriverUtils _driver;
        private By elements = By.XPath("//button[@class='btn btn_secondary btn_small cart_button']");
        public CartPage(WebDriverUtils driver)
        {
            _driver = driver;
        }

        public int ElementsPresent()
        {
            return _driver.GetElements(elements).Count();
        }

       

    }
}
