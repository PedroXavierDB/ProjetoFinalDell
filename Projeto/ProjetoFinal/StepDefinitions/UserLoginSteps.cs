using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoFinal.DataStructures;
using ProjetoFinal.PageObjects;
using ProjetoFinal.TestContext;
using TechTalk.SpecFlow;
using ProjetoFinal.Config;

namespace ProjetoFinal.StepDefinitions
{
    [Binding]
    public class UserLoginSteps
    {
        private Context _context;
        private User _user;
        private HomePO _homePage;
        private LoginPO _loginPage;
        
        public UserLoginSteps(Context context)
        {
            _context = context;
            _user = new User();
            _homePage = new HomePO(_context.Driver);
            _loginPage = new LoginPO(_context.Driver);
        }
        
        [Given(@"That I am on the Sign In page")]
        public void GivenThatIAmOnTheSignInPage()
        {
            _homePage.ToGoToHomePageByUrl();
            _homePage.ToGoToLoginPage();
        }

        [When(@"I try to do my login writing only my email")]
        public void WhenITryToDoMyLoginWritingOnlyMyEmail()
        {
            _loginPage.ToFillLoginEmailAndPasswordFields(_user.Email, "");
            _loginPage.ToClickLoginBtn();
        }

        [When(@"I try to do my login writing an invalid email")]
        public void WhenITryToDoMyLoginWritingAnInvalidEmail()
        {
            _loginPage.ToFillLoginEmailAndPasswordFields("Email.com", "");
            _loginPage.ToClickLoginBtn();
        }

        [When(@"I try to do my login writing a valid email and an invalid password")]
        public void WhenITryToDoMyLoginWritingAValidEmailAndAnInvalidPassword()
        {
            _loginPage.ToFillLoginEmailAndPasswordFields("teste@hotmail.com", "123");
            _loginPage.ToClickLoginBtn();
        }

        [When(@"I try to do my login writing incorrectly my email or password")]
        public void WhenITryToDoMyLoginWritingIncorrectlyMyEmailOrPassword()
        {
            _loginPage.ToFillLoginEmailAndPasswordFields(_user.Email, _user.Password + "000");
            _loginPage.ToClickLoginBtn();
        }

        [When(@"I try to do my login writing my registered email and password")]
        public void WhenITryToDoMyLoginWritingMyRegisteredEmailAndPassword()
        {
            _loginPage.ToFillLoginEmailAndPasswordFields(ReadConfigs.ReadSetting("Email"),
                ReadConfigs.ReadSetting("Password"));
            _loginPage.ToClickLoginBtn();
        }

        [When(@"I try to do my login without writing my email and password")]
        public void WhenITryToDoMyLoginWithoutWritingMyEmailAndPassword()
        {
            _loginPage.ToClickLoginBtn();
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
