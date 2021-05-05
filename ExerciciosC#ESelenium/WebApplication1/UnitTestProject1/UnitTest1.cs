using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        public static ExtentTest _test;
        public static ExtentReports _extent;

        [OneTimeSetUp]
        public void ExtentStart()
        {

            _extent = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(@"C:\Users\pedro.xavier\source\repos\WebApplication1\UnitTestProject1\Data\" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            _extent.AttachReporter(htmlreporter);

        }

        [Test]
        public void TestMethod1()
        {
            //Arrange
            ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();

            _test = null;
            _test = _extent.CreateTest("TestMethod1").Info("Test for check the contact list");

            //Act
            var contacts = client.GetContacts();

            //Assert
            var expected = 5;
            var actual = contacts.Length;

            NUnit.Framework.Assert.AreEqual(expected, actual, "Not all contacts expected were returned.");
            string baseName = "contact ";
            for (int id = 0; id<5; id++)
            {
                NUnit.Framework.Assert.AreEqual(baseName+(id+1), contacts[id].Name, "Name does not match for ID " + (id + 1));
            }
            _test.Log(Status.Pass, "Test Pass");
        }

        [Test]
        public void TestMethod2()
        {
            //Arrange
            ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();

            _test = null;
            _test = _extent.CreateTest("TestMethod2").Info("Test for check a contact that Id is equals to 1");

            //Act
            var contact = client.GetContact(1);

            //Assert
            string nameExpected = "contact 1";
            string nameActual = contact.Name;

            string emailExpected = "contact1@test.com";
            string emailActual = contact.Email;

            int ageExpected = 25;
            int ageActual = contact.Age;

            float salaryExpected = 2200.55f;
            float salaryActual = contact.Salary;

            NUnit.Framework.Assert.AreEqual(nameExpected, nameActual, "Name does not match for ID 1");
            NUnit.Framework.Assert.AreEqual(emailExpected, emailActual, "Email does not match for ID 1");
            NUnit.Framework.Assert.AreEqual(ageExpected, ageActual, "Age does not match for ID 1");
            NUnit.Framework.Assert.AreEqual(salaryExpected, salaryActual, "Salary does not match for ID 1");
            _test.Log(Status.Pass, "Test Pass");
        }

        [Test]
        public void TestMethod3()
        {
            var response = GetAsync(new Uri("http://api.icndb.com/jokes/random/3"));
            var jsonResponse = GetString(response.Result);
            var json = jsonResponse.Result;

            _test = null;
            _test = _extent.CreateTest("TestMethod3").Info("Test a REST service");

            if (!string.IsNullOrEmpty(json))
            {
                var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                NUnit.Framework.Assert.IsNotNull(jsonResult);
                _test.Log(Status.Pass, "Test Pass");
            }
            else
            {
                throw new Exception("It was not possible to get JSON content from the client");
            }
        }

        [Test]
        public void TestMethod4()
        {
            //Arrange
            ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();

            _test = null;
            _test = _extent.CreateTest("TestMethod4").Info("Test for check a invalid contact that Id is equals to 0");

            //Act
            var contact = client.GetContact(0);

            //Assert
            try
            {
                var aux = contact.Name;
            }catch(NullReferenceException)
            {
                _test.Log(Status.Pass, "Test Pass");
            }
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            _extent.Flush();
        }

        private async Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(uri);

            return response;
        }

        private async Task<string> GetString(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return null;
        }
    }
}
