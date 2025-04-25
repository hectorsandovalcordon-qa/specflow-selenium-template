using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowProject.PageObjects
{
    public class BasePage
    {
        protected readonly IWebDriver _driver;

        private const string _baseUrl = "https://demoqa.com/";

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }
        public void Open(string parameter)
        {
            _driver.Navigate().GoToUrlAsync(_baseUrl + parameter);
        }

        public IWebElement WaitElement(IWebElement element)
        {
            WebDriverWait wait = new(_driver, TimeSpan.FromSeconds(10));
            return wait.Until(x => element);
        }
    }
}
