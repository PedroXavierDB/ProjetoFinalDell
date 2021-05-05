using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using UnitTestProject.PageObjects;

namespace UnitTestProject.Testes
{
    [TestClass]
    public class test
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [DataSource(@"Provider=MSOLEDBSQL;Data Source=(localdb)\MSSQLLocalDB;
Initial Catalog=Testes;
Integrated Security=SSPI;",
            "TabelaDados")]
        [TestMethod]
        public void TestMethod1()
        {
            //Console.WriteLine(testContextInstance.DataRow["FirstName"].ToString());
            IWebDriver _driver = new ChromeDriver();

            HomePagePO homePage = new HomePagePO(_driver);
            UserRegistrationPO userRegistrationPO = new UserRegistrationPO(_driver);
            homePage.GoTo();
            userRegistrationPO.GoToRegistrationPage();
            userRegistrationPO.ClosePopUp();

            //Act
            userRegistrationPO.CompleteRegistrationForm(
                testContextInstance.DataRow["FirstName"].ToString(),
                testContextInstance.DataRow["LastName"].ToString(),
                testContextInstance.DataRow["PhoneNumber"].ToString(),
                testContextInstance.DataRow["Email"].ToString(),
                testContextInstance.DataRow["Password"].ToString(),
                testContextInstance.DataRow["Birthdate"].ToString()
                );
            //System.Threading.Thread.Sleep(1000);
            userRegistrationPO.Register();
            //Assert
        }
    }
}
