using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace ProjetoFinal.TestContext
{
    public class Context : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public Context()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("--no-sandbox");
            //chromeOptions.AddArguments("--headless");
            //chromeOptions.AddArguments("disable-gpu");
            chromeOptions.AddArguments("--disable-notifications");
            chromeOptions.AddExcludedArgument("disable-popup-blocking");
            Driver = new ChromeDriver(chromeOptions);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
