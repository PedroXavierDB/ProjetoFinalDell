using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoFinal.DataStructures;
using ProjetoFinal.PageObjects;
using ProjetoFinal.TestContext;
using System;
using TechTalk.SpecFlow;

namespace ProjetoFinal.StepDefinitions
{
    [Binding]
    public class UserRegistrationSteps
    {
        private Context _context;
        private  User _user;
        private HomePO _homePage;
        private LoginPO _loginPage;
        private RegistrationPO _registrationPage;

        public UserRegistrationSteps(Context context)
        {
            _context = context;
            _user = new User();
            _homePage = new HomePO(_context.Driver);
            _loginPage = new LoginPO(_context.Driver);
            _registrationPage = new RegistrationPO(_context.Driver);
        }

        [Given(@"That I am a new client without registration")]
        public void GivenThatIAmANewClientWithoutRegistration()
        {
            _homePage.ToGoToHomePageByUrl();
        }
        
        [When(@"I click on the Sign In button")]
        public void WhenIClickOnTheSignInButton()
        {
            _homePage.ToGoToLoginPage();
        }

        [When(@"I insert the email value")]
        public void WhenIInsertTheEmailValue()
        {
            _loginPage.ToFillSignInEmailField(_user.Email);
        }

        [When(@"I click on the Create an Account button of the Login page")]
        public void WhenIClickOnTheCreateAnAccountButtonOfTheLoginPage()
        {
            _loginPage.ToClickSignInBtn();
        }
        
        [When(@"I insert all mandatory values")]
        public void WhenIInsertAllMandatoryValues()
        {
            _registrationPage.ToFillPersonalPart(_user.FirstName, _user.LastName, _user.Password);
            _registrationPage.ToFillAddressPart(_user.Address, _user.City, _user.State,
                _user.Country, _user.Zip, _user.MobilePhone);
        }
        
        [When(@"I access the Registration page using an unregistered email")]
        public void WhenIAccessTheRegistrationPageUsingAnUnregisteredEmail()
        {
            WhenIClickOnTheSignInButton();
            WhenIInsertTheEmailValue();
            WhenIClickOnTheCreateAnAccountButtonOfTheLoginPage();     
        }
        
        [When(@"I do not write in at least one of the mandatory fields")]
        public void WhenIDoNotWriteInAtLeastOneOfTheMandatoryFields()
        {
            _registrationPage.ToFillPersonalPart(_user.FirstName, _user.LastName, _user.Password);
        }

        [When(@"I click on Create an Account on the Registration page")]
        public void WhenIClickOnCreateAnAccountOnTheRegistrationPage()
        {
            _registrationPage.ToClickRegisterBtn();
        }

        [Then(@"I will be redirected to the Login page")]
        public void ThenIWillBeRedirectedToTheLoginPage()
        {
            StringAssert.Contains(_context.Driver.Url.ToLower(), "controller=authentication".ToLower());
            StringAssert.Contains(_context.Driver.PageSource.ToLower(), "Authentication".ToLower());
        }
        
        [Then(@"I will be redirected to the Registration page")]
        public void ThenIWillBeRedirectedToTheRegistrationPage()
        {
            _registrationPage.ToWaitPageLoads();

            StringAssert.Contains(_context.Driver.PageSource.ToLower(), "First name".ToLower());
            StringAssert.Contains(_context.Driver.PageSource.ToLower(), "Country".ToLower());
            StringAssert.Contains(_context.Driver.PageSource.ToLower(), "State".ToLower());

        }
        
        [Then(@"I will be able to complete my registration at the online store")]
        public void ThenIWillBeAbleToCompleteMyRegistrationAtTheOnlineStore()
        {
            StringAssert.Contains(_context.Driver.Url.ToLower(), "controller=my-account".ToLower());
            StringAssert.Contains(_context.Driver.PageSource.ToLower(), "My account".ToLower());
            StringAssert.Contains(_context.Driver.PageSource.ToLower(), "My personal information".ToLower());
        }
        
        [Then(@"A message should be displayed informing that all mandatory fields must be completed")]
        public void ThenAMessageShouldBeDisplayedInformingThatAllMandatoryFieldsMustBeCompleted()
        {
            StringAssert.Contains(_context.Driver.PageSource.ToLower(), "There are 5 errors".ToLower());
            StringAssert.Contains(_context.Driver.PageSource.ToLower(), "You must register at least one phone number.".ToLower());
            StringAssert.Contains(_context.Driver.PageSource.ToLower(), "This country requires you to choose a State.".ToLower());
        }
    }
}
