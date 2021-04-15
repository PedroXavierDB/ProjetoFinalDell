﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoFinal.Config;
using ProjetoFinal.PageObjects;
using ProjetoFinal.TestContext;
using System;
using TechTalk.SpecFlow;

namespace ProjetoFinal.StepDefinitions
{
    [Binding]
    public class UserForgotPasswordSteps
    {
        private Context _context;
        private HomePO _homePage;
        private LoginPO _loginPage;
        private ForgotPasswordPO _forgotPasswordPage;

        public UserForgotPasswordSteps(Context context)
        {
            _context = context;
            _homePage = new HomePO(_context.Driver);
            _loginPage = new LoginPO(_context.Driver);
            _forgotPasswordPage = new ForgotPasswordPO(_context.Driver);
        }

        [Given(@"That I am on the Forgot Password page")]
        public void GivenThatIAmOnTheForgotPasswordPage()
        {
            _homePage.ToGoToHomePageByUrl();
            _homePage.ToGoToLoginPage();
            _loginPage.ToClickForgotPasswordBtn();
        }
        
        [When(@"I click on Forgot Your Password")]
        public void WhenIClickOnForgotYourPassword()
        {
            _loginPage.ToClickForgotPasswordBtn();
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
        }
        
        [When(@"I write my already registered email on the Forgot Password page")]
        public void WhenIWriteMyAlreadyRegisteredEmailOnTheForgotPasswordPage()
        {
            _forgotPasswordPage.WriteOnEmailBox(ReadConfigs.ReadSetting("Email"));
        }
        
        [When(@"I click on Retrieve Password")]
        public void WhenIClickOnRetrievePassword()
        {
            _forgotPasswordPage.ToClickRetrievePasswordBtn();
        }
        
        [When(@"I write an invalid email on the Forgot Password page")]
        public void WhenIWriteAnInvalidEmailOnTheForgotPasswordPage()
        {
            _forgotPasswordPage.WriteOnEmailBox("Email.com");
        }
        
        [When(@"I write an unregistered email on the Forgot Password page")]
        public void WhenIWriteAnUnregisteredEmailOnTheForgotPasswordPage()
        {
            _forgotPasswordPage.WriteOnEmailBox($"{Guid.NewGuid()}@hotmail.com");
        }
        
        [Then(@"I will be redirected to the Forgot Password page")]
        public void ThenIWillBeRedirectedToTheForgotPasswordPage()
        {
            StringAssert.Contains(_context.Driver.Url.ToLower(), "controller=password".ToLower());
            StringAssert.Contains(_context.Driver.PageSource.ToLower(), "Forgot your password".ToLower());
        }
        
        [Then(@"The message ""(.*)"" should be displayed on the Forgot Password page")]
        public void ThenTheMessageShouldBeDisplayedOnTheForgotPasswordPage(string p0)
        {
            StringAssert.Contains(_context.Driver.PageSource.ToLower(), p0.ToLower());
        }
    }
}
