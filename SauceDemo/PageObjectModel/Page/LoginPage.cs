using System;
using OpenQA.Selenium;
using FrameworkLayer.WebAppUtil;

namespace PageObjectModel.Page
{
    public class LoginPage
    {
        private By _username = By.XPath(".//input[@id='user-name']");
        private By _password = By.XPath(".//input[@id='password']");
        private By _loginBtn = By.XPath(".//*[@id='login-button']");

        private By _errorInvalidUser = By.XPath("//h3[@data-test='error']");

        private WebDriverUtils _driver;

        public LoginPage(WebDriverUtils driver)
        {
            _driver = driver;
        }

        public void Login(string username, string password)
        {
            _driver.ClearAndSendKeys(_username, username);
            _driver.ClearAndSendKeys(_password, password);

        }

        public void ClickLogInBtn()
        {
            _driver.GetElement(_loginBtn).Click();
        }

        public string ErrorMessage()
        {
            return _driver.GetElement(_errorInvalidUser).Text;
        }

       

    }
}
