using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoFinal.DataStructures;
using ProjetoFinal.PageObjects;
using ProjetoFinal.TestContext;
using TechTalk.SpecFlow;

namespace ProjetoFinal.StepDefinitions
{
    [Binding]
    public class UserRegistrationSteps
    {
        private Context _context;
        private User _user;
        private HomePO _homePage;
        private LoginPO _loginPage;
        private RegistrationPO _registrationPage;

        public UserRegistrationSteps(Context context, User user)
        {
            _context = context;
            _user = new User();
            _homePage = new HomePO(_context.Driver);
            _loginPage = new LoginPO(_context.Driver);
            _registrationPage = new RegistrationPO(_context.Driver);
        }

        [Given(@"That I'm a new client without registration")]
        public void GivenThatIMANewClientWithoutRegistration()
        {
            _homePage.GoTo();
        }
        
        [When(@"I click on the Sign In button")]
        public void WhenIClickOnTheSignInButton()
        {
            _homePage.GoToLoginPage();
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
        
        [When(@"I access the Sign In page")]
        public void WhenIAccessTheSignInPage()
        {
            WhenIClickOnTheSignInButton();
            WhenIInsertTheEmailValue();
            WhenIClickOnTheCreateAnAccountButtonOfTheLoginPage();
            
        }
        
        [When(@"I don't write in at least one of the mandatory fields")]
        public void WhenIDonTWriteInAtLeastOneOfTheMandatoryFields()
        {
            _registrationPage.ToFillPersonalPart(_user.FirstName, _user.LastName, _user.Password);
        }

        [When(@"I click on the Create an Account button of the Registration page")]
        public void WhenIClickOnTheCreateAnAccountButtonOfTheRegistrationPage()
        {
            _registrationPage.ToClickRegisterBtn();
        }

        [Then(@"I'll be redirected to the Login page")]
        public void ThenILlBeRedirectedToTheLoginPage()
        {
            StringAssert.Contains(_context.Driver.Url, "controller=authentication");
            StringAssert.Contains(_context.Driver.PageSource, "Authentication");
        }
        
        [Then(@"I'll be redirected to the Registration page")]
        public void ThenILlBeRedirectedToTheRegistrationPage()
        {
            _registrationPage.ToWaitPageLoads();

            StringAssert.Contains(_context.Driver.PageSource, "First name");
            StringAssert.Contains(_context.Driver.PageSource, "Country");
            StringAssert.Contains(_context.Driver.PageSource, "State");

        }
        
        [Then(@"I'll be able to complete my registration at the online store")]
        public void ThenILlBeAbleToCompleteMyRegistrationAtTheOnlineStore()
        {
            StringAssert.Contains(_context.Driver.Url, "controller=my-account");
            StringAssert.Contains(_context.Driver.PageSource, "My account");
            StringAssert.Contains(_context.Driver.PageSource, "My personal information");
        }
        
        [Then(@"A message should be displayed informing that all mandatory fields must be completed")]
        public void ThenAMessageShouldBeDisplayedInformingThatAllMandatoryFieldsMustBeCompleted()
        {
            StringAssert.Contains(_context.Driver.PageSource, "There are 5 errors");
            StringAssert.Contains(_context.Driver.PageSource, "You must register at least one phone number.");
            StringAssert.Contains(_context.Driver.PageSource, "This country requires you to choose a State.");
        }
    }
}
