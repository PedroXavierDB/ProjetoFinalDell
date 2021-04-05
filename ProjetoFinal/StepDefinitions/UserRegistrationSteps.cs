using ProjetoFinal.PageObjects;
using ProjetoFinal.TestContext;
using TechTalk.SpecFlow;

namespace ProjetoFinal.StepDefinitions
{
    [Binding]
    public class UserRegistrationSteps
    {
        private Context _context;

        public UserRegistrationSteps(Context context)
        {
            _context = context;
        }

        [Given(@"That I'm a new client without registration")]
        public void GivenThatIMANewClientWithoutRegistration()
        {
            HomePO homePage = new HomePO(_context.Driver);
            homePage.GoTo();
        }
        
        [When(@"I click on the Sign In button")]
        public void WhenIClickOnTheSignInButton()
        {
            HomePO homePage = new HomePO(_context.Driver);
            homePage.GoToLoginPage();
        }

        [When(@"I insert the email value")]
        public void WhenIInsertTheEmailValue()
        {
            LoginPO loginPage = new LoginPO(_context.Driver);
            loginPage.ToFillSignInEmailField("pewx@hotmail.com");
        }

        [When(@"I click on the Create an Account button")]
        public void WhenIClickOnTheCreateAnAccountButton()
        {
            LoginPO loginPage = new LoginPO(_context.Driver);
            loginPage.ToClickSignInBtn();
        }
        
        [When(@"I insert all mandatory values")]
        public void WhenIInsertAllMandatoryValues()
        {
            RegistrationPO registrationPage = new RegistrationPO(_context.Driver);
            registrationPage.ToFillPersonalPart("Pedro", "Xavier", "12345");
            registrationPage.ToFillAddressPart("Pedro", "Xavier", "Rua Coronel 27", "Porto Alegre",
                "Texas", "United States", "90620", "51995968401");
            registrationPage.ToClickRegisterBtn();
            System.Threading.Thread.Sleep(8000);
        }
        
        [When(@"I access the Sign In page")]
        public void WhenIAccessTheSignInPage()
        {
        }
        
        [When(@"I don't write in at least one of the mandatory fields")]
        public void WhenIDonTWriteInAtLeastOneOfTheMandatoryFields()
        {
        }
        
        [Then(@"I'll be redirected to the Login page")]
        public void ThenILlBeRedirectedToTheLoginPage()
        {
        }
        
        [Then(@"I'll be redirected to the Registration page")]
        public void ThenILlBeRedirectedToTheRegistrationPage()
        {
        }
        
        [Then(@"I'll be able to complete my registration at the online store")]
        public void ThenILlBeAbleToCompleteMyRegistrationAtTheOnlineStore()
        {
        }
        
        [Then(@"A message should be displayed informing that all mandatory fields must be completed")]
        public void ThenAMessageShouldBeDisplayedInformingThatAllMandatoryFieldsMustBeCompleted()
        {
        }
    }
}
