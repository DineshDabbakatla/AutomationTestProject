using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkLayer.WebDriverUtils
{
    public class DriverFactory
    {
        IWebDriver _driver;
        public IWebDriver CreateInstance(string browser)
        {
           
                switch (browser)
                {
                    case "chrome":
                        _driver = new ChromeDriver();
                        break;
                    case "edge":
                        _driver = new EdgeDriver();
                        break;
                    default:
                        return null;
                }
            return _driver;
            
        }
    }
}
