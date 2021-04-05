using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
