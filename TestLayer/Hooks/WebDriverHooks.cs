using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SauceDemoAutomation.TestLayer.Hooks
{
    [Binding]
    public class WebDriverHooks
    {
        private readonly IObjectContainer _objectContainer;

        public WebDriverHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            var driver = new ChromeDriver();
            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void QuitWebDriver()
        {
            var driver = _objectContainer.Resolve<IWebDriver>();
            driver.Quit();
        }
    }
}