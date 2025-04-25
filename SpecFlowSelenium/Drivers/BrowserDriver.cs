using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowProject.Drivers
{
    public class BrowserDriver
    {
        public IWebDriver CreateDriver()
        {
            // Configuración de opciones de Chrome
            var options = new ChromeOptions();
            options.AddArguments("--headless"); // Si quieres que se ejecute en modo headless (sin interfaz gráfica)

            // Crear el ChromeDriver con las opciones configuradas
            var driver = new ChromeDriver(options);

            return driver;
        }
    }
}
