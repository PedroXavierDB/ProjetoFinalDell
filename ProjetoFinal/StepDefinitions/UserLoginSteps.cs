using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoFinal.DataStructures;
using ProjetoFinal.PageObjects;
using ProjetoFinal.TestContext;
using TechTalk.SpecFlow;

namespace ProjetoFinal.StepDefinitions
{
    [Binding]
    public class UserLoginSteps
    {
        private Context _context;
        private User _user;
        private HomePO _homePage;
        private LoginPO _loginPage;
        private MyAccountPO _myAccountPage;
        private RegistrationPO _registrationPage;
        
        public UserLoginSteps(Context context)
        {
            _context = context;
            _user = new User();
            _homePage = new HomePO(_context.Driver);
            _loginPage = new LoginPO(_context.Driver);
            _myAccountPage = new MyAccountPO(_context.Driver);
            _registrationPage = new RegistrationPO(_context.Driver);
        }

        [Given(@"That I am a user with a registered account")]
        public void GivenThatIAmAUserWithARegisteredAccount()
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
        
        [Given(@"That I am on the Sign In page")]
        public void GivenThatIAmOnTheSignInPage()
        {
            _homePage.ToGoToHomePageByUrl();
            _homePage.ToGoToLoginPage();
        }
        
        [When(@"I write correctly my email and password")]
        public void WhenIWriteCorrectlyMyEmailAndPassword()
        {
            _loginPage.ToFillLoginEmailAndPasswordFields(_user.Email, _user.Password);
        }

        [When(@"I try to do my login without writing my email and password")]
        public void WhenITryToDoMyLoginWithoutWritingMyEmailAndPassword()
        {
            _loginPage.ToClickLoginBtn();
        }

        [When(@"I try to do my login")]
        public void WhenITryToDoMyLogin()
        {
            _loginPage.ToClickLoginBtn();
        }
        
        [When(@"I write only my email")]
        public void WhenIWriteOnlyMyEmail()
        {
            _loginPage.ToFillLoginEmailAndPasswordFields(_user.Email, "");
        }
        
        [When(@"I write an invalid email")]
        public void WhenIWriteAnInvalidEmail()
        {
            _loginPage.ToFillLoginEmailAndPasswordFields("Email.com", "");
        }
        
        [When(@"I write a valid email and an invalid password")]
        public void WhenIWriteAValidEmailAndAnInvalidPassword()
        {
            _loginPage.ToFillLoginEmailAndPasswordFields("teste@hotmail.com", "123");
        }
        
        [When(@"I write incorrectly my email or password")]
        public void WhenIWriteIncorrectlyMyEmailOrPassword()
        {
            _loginPage.ToFillLoginEmailAndPasswordFields(_user.Email, _user.Password+"000");
        }
        
        [Then(@"I will login in my account")]
        public void ThenIWillLoginInMyAccount()
        {
            StringAssert.Contains(_context.Driver.Url.ToLower(), "controller=my-account".ToLower());
            StringAssert.Contains(_context.Driver.PageSource.ToLower(), "My account".ToLower());
            StringAssert.Contains(_context.Driver.PageSource.ToLower(), "My personal information".ToLower());
        }
        
        [Then(@"The message ""(.*)"" should be displayed on the Sign In page")]
        public void ThenTheMessageShouldBeDisplayedOnTheSignInPage(string p0)
        {
            StringAssert.Contains(_context.Driver.PageSource.ToLower(), p0.ToLower());
        }
    }
}
