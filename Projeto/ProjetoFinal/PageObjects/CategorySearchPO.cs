using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.PageObjects
{
    public class CategorySearchPO : TemplatePO
    {
        private By _byDressesCategory => By.Id("layered_category_8");
        private By _bySizeM => By.Id("layered_id_attribute_group_2");
        private By _byColorWhite => By.Id("layered_id_attribute_group_8");
        private By _byCompositionPolyester => By.Id("layered_id_feature_1");
        private By _byStyleCasual => By.Id("layered_id_feature_11");
        private By _byPropertieColorful => By.Id("uniform-layered_id_feature_18");
        private By _byAvailabilityInStock => By.Id("layered_quantity_1");
        private By _byManufacturerFashion => By.Id("layered_manufacturer_1");
        private By _byConditionNew => By.Id("layered_condition_new");

        public CategorySearchPO(IWebDriver driver) : base(driver)
        {
        }

        public void ToClickDressesCategory()
        {
            IWebElement elemente = _driver.FindElement(_byDressesCategory);
            elemente.Click();
        }

        public void ToClickSizeM()
        {
            IWebElement elemente = _driver.FindElement(_bySizeM);
            elemente.Click();
        }

        public void ToClickColorWhite()
        {
            IWebElement elemente = _driver.FindElement(_byColorWhite);
            elemente.Click();
        }

        public void ToClickCompositionPolyester()
        {
            IWebElement elemente = _driver.FindElement(_byCompositionPolyester);
            elemente.Click();
        }

        public void ToClickStyleCasual()
        {
            IWebElement elemente = _driver.FindElement(_byStyleCasual);
            elemente.Click();
        }

        public void ToClickPropertieColorful()
        {
            IWebElement elemente = _driver.FindElement(_byPropertieColorful);
            elemente.Click();
        }

        public void ToClickAvailabilityInStock()
        {
            IWebElement elemente = _driver.FindElement(_byAvailabilityInStock);
            elemente.Click();
        }

        public void ToClickManufacturerFashion()
        {
            IWebElement elemente = _driver.FindElement(_byManufacturerFashion);
            elemente.Click();
        }

        public void ToClickConditionNew()
        {
            IWebElement elemente = _driver.FindElement(_byConditionNew);
            elemente.Click();
        }
    }
}
