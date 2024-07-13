using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using FrameworkLayer.WebAppUtil;
using PageObjectModel.Page;
using FrameworkLayer;
using System.Reflection;

namespace SauceDemoTest.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly WebDriverUtils _driverUtils;
        private readonly LoginPage _loginPage;
        private readonly ProductPage _product;

        public LoginStepDefinitions(WebDriverUtils driverUtils)
        {
            _driverUtils = driverUtils;
            _loginPage = new LoginPage(_driverUtils);
            _product = new ProductPage(_driverUtils);
        }

        [Given(@"I am on the Sauce demo login page")]
        public void GivenIAmOnTheSauceDemoLoginPage()
        {
            _driverUtils.NavigateToUrl(ConfigReader.GetConfig(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+@"\appSettings.json").Url);
        }

        [When(@"I enter '([^']*)' and '([^']*)' in the login page")]
        public void WhenIEnterAndInTheLoginPage(string username, string password)
        {
            _loginPage.Login(username, password);
        }

        [When(@"I click on login")]
        public void WhenIClickOnLogin()
        {
            _loginPage.ClickLogInBtn();
        }

        [Then(@"Product label should be displayed")]
        public void ThenProductLabelShouldBeDisplayed()
        {
            Assert.That(_product.IsProductLabelDisplayed(), Is.True);
        }

        [Then(@"It should show message Epic sadface: Username and password do not match any user in this service")]
        public void ThenItShouldShowMessageEpicSadfaceUsernameAndPasswordDoNotMatchAnyUserInThisService()
        {
            string actualError = "Epic sadface: Username and password do not match any user in this servic";
            Assert.That(_loginPage.ErrorMessage(), Is.EqualTo(actualError));
        }

        [Then(@"It should show message Epic sadface: Sorry, this user has been locked out")]
        public void ThenItShouldShowMessageEpicSadfaceSorryThisUserHasBeenLockedOut()
        {
            string actualError = "Epic sadface: Sorry, this user has been locked out.";
            Assert.That(_loginPage.ErrorMessage(), Is.EqualTo(actualError));
        }

        [Then(@"It should show message Epic sadface: Username is required")]
        public void ThenItShouldShowMessageEpicSadfaceUsernameIsRequired()
        {
            string actualError = "Epic sadface: Username is required";
            Assert.That(_loginPage.ErrorMessage(), Is.EqualTo(actualError));
        }

        [Then(@"It should show message Epic sadface: Password is required")]
        public void ThenItShouldShowMessageEpicSadfacePasswordIsRequired()
        {
            string actualError = "Epic sadface: Password is required";
            Assert.That(_loginPage.ErrorMessage(), Is.EqualTo(actualError));
        }
    }
}
