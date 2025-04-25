using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowProject.Drivers
{
    public class BrowserDriver
    {
        public IWebDriver CreateDriver()
        {
            return new ChromeDriver();
        }
    }
}
