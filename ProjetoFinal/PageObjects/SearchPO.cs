using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.PageObjects
{
    public class SearchPO : TemplatePO
    {
        private By _byNumberOfResults => By.ClassName("heading-counter");

        public SearchPO(IWebDriver driver) : base(driver)
        {
        }

        public int NumberOfSearchResults()
        {
            IWebElement numberOfResults = _driver.FindElement(_byNumberOfResults);
            String number = numberOfResults.Text;
            return int.Parse(number.Substring(0,1));
        }
    }
}
