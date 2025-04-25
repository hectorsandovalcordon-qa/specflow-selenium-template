using OpenQA.Selenium;
using SpecFlowProject.PageObjects;

namespace SpecFlowProject.StepDefinitions
{

    [Binding]
    public class LoginSteps
    {
        private readonly LoginPage loginPage;

        public LoginSteps(IWebDriver driver)
        {
            loginPage = new LoginPage(driver);
        }

        [Given(@"""(.*)"" page is open")]
        public void GivenPageIsOpen(string urlParameter)
        {
            loginPage.Open(urlParameter);
        }

        [Given(@"UserName ""(.*)"" is entered")]
        public void GivenUserNameIsEntered(string userName)
        {
            loginPage.EnterUsername(userName);
        }

        [Given(@"Password ""(.*)"" is entered")]
        public void GivenPasswordIsEntered(string password)
        {
            loginPage.EnterPassword(password);
        }

        [Given(@"User clicks on New User button")]
        public void GivenUserClicksOnNewUserButton()
        {
            loginPage.ClickNewUserButton();
        }

        [When(@"User fills ""(.*)"", ""(.*)"", ""(.*)"" and ""(.*)""")]
        public void WhenUserFillsAnd(string firstName, string lastName, string userName, string password)
        {
            loginPage.FillNewUserData(firstName, lastName, userName, password);
        }

        [When(@"User clicks recaptcha checkbox")]
        public void WhenUserClicksRecaptchaCheckbox()
        {
            loginPage.ClickRecaptchaCheckBox();
        }

        [When(@"User clicks on Register button")]
        public void WhenUserClicksOnRegisterButton()
        {
            loginPage.ClickRegisterButton();
        }

        [When(@"User clicks on Login button")]
        public void WhenUserClicksOnLoginButton()
        {
            loginPage.ClickLoginButton();
        }

        [Then(@"User should be redirected to the login page")]
        public void ThenUserShouldBeRedirectedToTheLoginPage()
        {
            //Assert.AreEqual("https://your-login-page-url.com/login", loginPage.Url);
        }

        [Then(@"UserName ""(.*)"" is entered")]
        public void ThenUserNameIsEntered(string userName)
        {
            loginPage.EnterUsername(userName);
        }

        [Then(@"Password ""(.*)"" is entered")]
        public void ThenPasswordIsEntered(string password)
        {
            loginPage.EnterUsername(password);
        }

        [Then(@"User clicks on Login button")]
        public void ThenUserClicksOnLoginButton()
        {
            loginPage.ClickLoginButton();
        }

        [Then(@"User verifies required fields")]
        public void ThenUserVerifiesRequiredFields()
        {
            loginPage.VerifyRequiredFields();
        }

        [Then(@"User verifies username required field")]
        public void ThenUserVerifiesUserNameRequiredField()
        {
            loginPage.VerifyUserNameRequiredField();
        }

        [Then(@"User verifies password required field")]
        public void ThenUserVerifiesPasswordRequiredField()
        {
            loginPage.VerifyPasswordRequiredField();
        }

        [Then(@"User shows ""([^""]*)"" message")]
        public void ThenUserShowsMessage(string message)
        {
            loginPage.VerifyMessage(message);
        }
    }
}
