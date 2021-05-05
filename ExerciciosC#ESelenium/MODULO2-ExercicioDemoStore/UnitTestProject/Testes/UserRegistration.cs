using UnitTestProject.Data;
using UnitTestProject.Fixtures;
using UnitTestProject.PageObjects;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace UnitTestProject.Testes
{
    [Collection("GoogleChrome")]
    public class UserRegistration
    {
        private IWebDriver _driver;

        public UserRegistration(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void ShouldRegisterNewUser()
        {
            //Arrange
            string jsonFromFile;
            string aux = @"C:\Users\pedro.xavier\source\repos\MODULO2-ExercicioDemoStore\UnitTestProject\Data\file.json";
            using (StreamReader reader = new StreamReader(aux))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            var userList = JsonConvert.DeserializeObject<List<User>>(jsonFromFile);

            HomePagePO homePage = new HomePagePO(_driver);
            UserRegistrationPO userRegistrationPO = new UserRegistrationPO(_driver);
            homePage.GoTo();
            userRegistrationPO.GoToRegistrationPage();
            userRegistrationPO.ClosePopUp();

            foreach (User p in userList)
            {
                //Act
                userRegistrationPO.CompleteRegistrationForm(p.FirstName, p.LastName,
                    p.PhoneNumber, p.Email, p.Password, p.Birthdate);
                //System.Threading.Thread.Sleep(1000);
                userRegistrationPO.Register();

                //Assert
            }
        }
    }
}
