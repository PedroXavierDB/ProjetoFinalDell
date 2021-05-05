using UnitTestProject.Fixtures;
using UnitTestProject.PageObjects;
using OpenQA.Selenium;
using NUnit;
using UnitTestProject1.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;

namespace UnitTestProject.Testes
{
    [TestFixture]
    public class Login
    {
        private IWebDriver _driver;

        public static ExtentTest _test;
        public static ExtentReports _extent;

        [SetUp]
        public void Initialize()
        {
            _driver = new ChromeDriver();
        }

        [OneTimeSetUp]
        public void ExtentStart()
        {

            _extent = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(@"C:\Users\pedro.xavier\source\repos\MODULO2-ExercicioDemoStore\UnitTestProject\Data\" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            _extent.AttachReporter(htmlreporter);

        }

        [Test]
        public void TestSuccessfulLogin()
        {
            //Arrange
            _test = null;
            _test = _extent.CreateTest("T001").Info("Login Successful Test");

            LoginPO login = new LoginPO(_driver);
            login.GoTo();

            //Act
            login.WriteLoginData("tomsmith", "SuperSecretPassword!");
            login.ClickLoginBtn();

            //Assert
            //System.Threading.Thread.Sleep(10000);
            StringAssert.Contains("Secure Area", _driver.PageSource);
            _test.Log(Status.Pass, "Test Pass");
        }

        [Test]
        public void TestFailLogin()
        {
            //Arrange
            _test = null;
            _test = _extent.CreateTest("T002").Info("Login Fail Test");

            LoginPO login = new LoginPO(_driver);
            login.GoTo();

            //Act
            login.ClickLoginBtn();

            //Assert
            StringAssert.Contains("Your username is invalid!", login.GetErrorMessage());
            _test.Log(Status.Pass, "Test Pass");
        }

        [TearDown]
        public void closeBrowser()
        {
            _driver.Close();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            _extent.Flush();
        }
    }
}
