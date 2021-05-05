using OpenQA.Selenium;

namespace UnitTestProject.PageObjects
{
    public class HomePagePO : TemplatePO
    {

        public HomePagePO(IWebDriver driver) : base(driver)
        {

        }

        public void GoTo()
        {
            _driver.Navigate().GoToUrl("https://demo.cs-cart.com/");
        }

    }
}
