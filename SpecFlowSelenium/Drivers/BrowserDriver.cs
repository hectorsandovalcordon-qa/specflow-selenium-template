using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowProject.Drivers
{
    public class BrowserDriver
    {
        public IWebDriver CreateDriver()
        {
            // Generar un directorio único temporal para cada sesión
            var userDataDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            // Configuración de opciones de Chrome
            var options = new ChromeOptions();
            options.AddArguments($"--user-data-dir={userDataDir}");  // Especifica un directorio único para cada sesión
            options.AddArguments("--headless"); // Si quieres que se ejecute en modo headless (sin interfaz gráfica)

            // Crear el ChromeDriver con las opciones configuradas
            var driver = new ChromeDriver(options);

            return driver;
        }
    }
}
