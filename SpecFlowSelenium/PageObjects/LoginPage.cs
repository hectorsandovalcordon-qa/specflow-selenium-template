using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;

namespace SpecFlowProject.PageObjects
{
    public class LoginPage : BasePage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        #region WebElements

        private IWebElement UsernameField => _driver.FindElement(By.Id("userName"));

        private IWebElement FirstnameField => _driver.FindElement(By.Id("firstname"));

        private IWebElement LastnameField => _driver.FindElement(By.Id("lastname"));

        private IWebElement RegisterButton => _driver.FindElement(By.Id("register"));

        private IWebElement PasswordField => _driver.FindElement(By.Id("password"));

        private IWebElement ErrorMessage => _driver.FindElement(By.Id("name"));

        private IWebElement LoginButton => _driver.FindElement(By.Id("login"));

        private IWebElement NewUserButton => _driver.FindElement(By.Id("newUser"));

        private IWebElement BackToLoginButton => _driver.FindElement(By.Id("gotologin"));

        #endregion

        public void NewUser(string firstname, string lastname, string username, string password)
        {
            WaitElement(FirstnameField).SendKeys(firstname);
            WaitElement(LastnameField).SendKeys(lastname);
            WaitElement(UsernameField).SendKeys(username);
            WaitElement(PasswordField).SendKeys(password);

            IWebElement recaptchaFrame = _driver.FindElement(By.XPath("//iframe[@title='reCAPTCHA']"));
            _driver.SwitchTo().Frame(recaptchaFrame);
            IWebElement recaptchaCheckbox = _driver.FindElement(By.Id("recaptcha-anchor"));
            recaptchaCheckbox.Click();
            _driver.SwitchTo().DefaultContent();

            RegisterButton.Click();
        }

        public void FillNewUserData(string firstname, string lastname, string username, string password)
        {
            WaitElement(FirstnameField).SendKeys(firstname);
            WaitElement(LastnameField).SendKeys(lastname);
            WaitElement(UsernameField).SendKeys(username);
            WaitElement(PasswordField).SendKeys(password);
        }

        public void EnterUsername(string username)
        {
            WaitElement(UsernameField).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            WaitElement(PasswordField).SendKeys(password);
        }

        public void VerifyMessage(string message)
        {
            ClassicAssert.IsTrue(ErrorMessage.Text.Equals(message));
        }


        public void VerifyRequiredField(IWebElement field)
        {
            ClassicAssert.IsTrue(field.GetAttribute("class").Contains("is-invalid"));
        }

        public void VerifyRequiredFields(params IWebElement[] fields)
        {
            foreach (var field in fields)
            {
                VerifyRequiredField(field);
            }
        }

        public void VerifyRequiredFields()
        {
            VerifyRequiredFields(WaitElement(UsernameField), WaitElement(PasswordField));
        }

        public void VerifyUserNameRequiredField()
        {
            VerifyRequiredFields(WaitElement(UsernameField));
        }

        public void VerifyPasswordRequiredField()
        {
            VerifyRequiredFields(WaitElement(PasswordField));
        }


        public void ClickLoginButton()
        {
            WaitElement(LoginButton).Click();
        }

        public void ClickRecaptchaCheckBox()
        {

            IWebElement recaptchaFrame = _driver.FindElement(By.XPath("//iframe[@title='reCAPTCHA']"));
            _driver.SwitchTo().Frame(recaptchaFrame);
            IWebElement recaptchaCheckbox = _driver.FindElement(By.Id("recaptcha-anchor"));
            recaptchaCheckbox.Click();
            _driver.SwitchTo().DefaultContent();

        }

        public void ClickRegisterButton()
        {
            WaitElement(RegisterButton).Click();
        }

        public void ClickNewUserButton()
        {
            WaitElement(NewUserButton).Click();
        }

        public void ClickBackToLoginButton()
        {
            WaitElement(BackToLoginButton).Click();
        }

        public bool IsWelcomeMessageDisplayed()
        {
            return _driver.FindElement(By.Id("welcomeMessage")).Displayed;
        }

        public bool IsDashboardUrl()
        {
            return _driver.Url.Contains("dashboard");
        }
    }
}
