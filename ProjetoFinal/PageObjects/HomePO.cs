using OpenQA.Selenium;

namespace ProjetoFinal.PageObjects
{
    public class HomePO : TemplatePO
    {
        public HomePO(IWebDriver driver) : base(driver)
        {

        }

        public void GoTo()
        {
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }
    }
}
