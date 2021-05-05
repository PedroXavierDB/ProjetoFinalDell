using OpenQA.Selenium;

namespace MODULO2_ExercicioDemoStore.PageObjects
{
    public class SearchResultPO : TemplatePO
    {

        public SearchResultPO(IWebDriver driver) : base(driver)
        {

        }

        public void AddToCartAnItemByName(string name)
        {
            IWebElement itemForm = _driver.FindElement(By.Name(name));
            itemForm.Click();
        }

    }
}
