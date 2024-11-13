using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Utilities; // Make sure this is the correct namespace for WebDriverExtensions

namespace POM
{
    public class LoginPage
    {
        private IWebDriver _driver;
        private By _usernameField = By.Id("user-name");
        private By _passwordField = By.Id("password");
        private By _loginButton = By.Id("login-button");
        private By _errorMessage = By.CssSelector(".error-message-container");
        private By _productsPageTitle = By.ClassName("title");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateToLoginPage()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com");
        }

        public void EnterCredentials(string username, string password)
        {
            _driver.FindElementSafe(_usernameField)?.SendKeys(username);
            _driver.FindElementSafe(_passwordField)?.SendKeys(password);
            _driver.FindElementSafe(_loginButton)?.Click();
        }

        public bool IsProductsPageVisible()
        {
            IWebElement productsPageTitleElement = _driver.FindElementSafe(_productsPageTitle);
            return productsPageTitleElement != null && productsPageTitleElement.Displayed;
        }

        public bool IsErrorMessageVisible()
        {
            IWebElement errorMessageElement = _driver.FindElementSafe(_errorMessage);
            return errorMessageElement != null && errorMessageElement.Displayed;
        }
    }
}
