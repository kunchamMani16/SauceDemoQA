using NUnit.Framework;
using OpenQA.Selenium;
using POM;
using TechTalk.SpecFlow;
using BoDi;

namespace TestLayer.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly LoginPage _loginPage;
        private readonly IWebDriver _driver;

        public LoginStepDefinitions(IWebDriver driver)
        {
            _driver = driver;
            _loginPage = new LoginPage(driver);
        }

        [Given("I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _loginPage.NavigateToLoginPage();
        }

        [When("I enter valid credentials")]
        public void WhenIEnterValidCredentials()
        {
            _loginPage.EnterCredentials("standard_user", "secret_sauce");
        }

        [When("I enter invalid credentials")]
        public void WhenIEnterInvalidCredentials()
        {
            _loginPage.EnterCredentials("invalid_user", "invalid_sauce");
        }

      
        [Then("I should be redirected to the products page")]
        public void ThenIShouldBeRedirectedToTheProductsPage()
        {

            Assert.That(_loginPage.IsProductsPageVisible(), Is.True);
        }

        [Then("I should see an error message")]
        public void ThenIShouldSeeAnErrorMessage()
        {

            Assert.That(_loginPage.IsErrorMessageVisible(), Is.True);
        }
    
}
}