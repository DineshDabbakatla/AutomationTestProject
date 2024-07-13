using FrameworkLayer.WebDriverUtils;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FrameworkLayer.WebAppUtil
{
    public class WebDriverUtils
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(WebDriverUtils));
        private IWebDriver _driver;
        private readonly DriverFactory _driverFactory;

        public WebDriverUtils(DriverFactory driverFactory)
        {
            _driverFactory = driverFactory;
        }

        public IWebDriver GetDriver(string browser)
        {
            if (_driver == null)
            {
                _driver = _driverFactory.CreateInstance(browser);
            }
            return _driver;
        }

        public void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
                Log.Info("Driver quit");
            }
        }

        public Actions GetActionObj()
        {
            return new Actions(_driver);
        }

        public string TakeScreenShot(string scenarioTitle)
        {
            CreateDirectory();
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string fileName = $"{scenarioTitle}_{timestamp}.png";
            string path = Path.Combine(GetScreenshotsDirectory(), fileName);
            ITakesScreenshot screenshotDriver = _driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(path);
            Log.Info($"Screenshot saved to {path}");
            return path;
        }

        private string GetScreenshotsDirectory()
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "SS");
        }

        private void CreateDirectory()
        {
            var directory = GetScreenshotsDirectory();
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
                Log.Info($"Created directory: {directory}");
            }
        }

        public IWebElement GetElement(By locator)
        {
            return _driver.FindElement(locator);
        }

        public void ClearAndSendKeys(By locator, string value)
        {
            var element = GetElement(locator);
            element.Clear();
            element.SendKeys(value);
            Log.Info($"Cleared and entered text in element: {locator}");
        }

        public void NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
            Log.Info($"Navigated to URL: {url}");
        }

        public List<IWebElement> GetElements(By locator)
        {
            return _driver.FindElements(locator).ToList();
        }
    }
}
