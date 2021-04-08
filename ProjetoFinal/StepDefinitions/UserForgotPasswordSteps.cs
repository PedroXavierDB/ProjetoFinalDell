using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoFinal.DataStructures;
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
        private User _user;
        private HomePO _homePage;
        private LoginPO _loginPage;
        private MyAccountPO _myAccountPage;
        private RegistrationPO _registrationPage;
        private ForgotPasswordPO _forgotPasswordPage;

        public UserForgotPasswordSteps(Context context)
        {
            _context = context;
            _user = new User();
            _homePage = new HomePO(_context.Driver);
            _loginPage = new LoginPO(_context.Driver);
            _myAccountPage = new MyAccountPO(_context.Driver);
            _registrationPage = new RegistrationPO(_context.Driver);
            _forgotPasswordPage = new ForgotPasswordPO(_context.Driver);
        }

        [Given(@"That I am a user with a registered account two")]
        public void GivenThatIAmAUserWithARegisteredAccountTwo()
        {
            _homePage.ToGoToHomePageByUrl();
            _homePage.ToGoToLoginPage();
            _loginPage.ToFillSignInEmailField(_user.Email);
            _loginPage.ToClickSignInBtn();
            _registrationPage.ToFillPersonalPart(_user.FirstName, _user.LastName, _user.Password);
            _registrationPage.ToFillAddressPart(_user.Address, _user.City, _user.State,
                _user.Country, _user.Zip, _user.MobilePhone);
            _registrationPage.ToClickRegisterBtn();
            _myAccountPage.SignOut();
        }

        [Given(@"That I am on the Forgot Password page")]
        public void GivenThatIAmOnTheForgotPasswordPage()
        {
            _homePage.ToGoToHomePageByUrl();
            _homePage.ToGoToLoginPage();
            _loginPage.ToClickForgotPasswordBtn();
        }
        
        [When(@"I click on the Forgot Your Password button")]
        public void WhenIClickOnTheForgotYourPasswordButton()
        {
            _loginPage.ToClickForgotPasswordBtn();
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
        }
        
        [When(@"I write my already registered email on the Forgot Password page")]
        public void WhenIWriteMyAlreadyRegisteredEmailOnTheForgotPasswordPage()
        {
            _forgotPasswordPage.WriteOnEmailBox(_user.Email);
        }
        
        [When(@"I click on the Retrieve Password button")]
        public void WhenIClickOnTheRetrievePasswordButton()
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
