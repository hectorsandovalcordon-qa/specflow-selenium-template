using BoDi;
using OpenQA.Selenium;
using SpecFlowProject.Drivers;

namespace SpecFlowProject.Support
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;
        private BrowserDriver _browserDriver;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void Initialize()
        {
            _browserDriver = new BrowserDriver();
            _driver = _browserDriver.CreateDriver();
            _driver.Manage().Window.Maximize();
            _objectContainer.RegisterInstanceAs(_driver);
        }

        [AfterScenario]
        public void CleanUp()
        {
            _driver.Dispose();
        }
    }
}
