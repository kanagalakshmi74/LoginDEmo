using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace LoginSF.StepDefinitions
{
    [Binding]
    public class SignInSteps
    {
        private IWebDriver driver;
        private readonly string baseurl = "https://localhost:44318/Registration.html";

        [Given(@"Chrome browser is opened")]
        public void GivenChromeBrowserIsOpened()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [When(@"I open Login Page")]
        public void WhenIOpenLoginPage()
        {
            driver.Navigate().GoToUrl(baseurl);
        }

        [When(@"I enter the username '([^']*)', password '([^']*)' and confirm_password '([^']*)'")]
        public void WhenIEnterTheUsernamePasswordAndConfirm_Password(string username, string password, string cpassword)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            IWebElement user = driver.FindElement(By.Id("username"));
            user.SendKeys(username);
            IWebElement pwd = driver.FindElement(By.Id("password"));
            pwd.SendKeys(password);
            IWebElement cpwd = driver.FindElement(By.Id("cpassword"));
            cpwd.SendKeys(cpassword);
        }

        [When(@"password '([^']*)' and confirm_password '([^']*)' are not same")]
        public void WhenPasswordAndConfirm_PasswordAreNotSame(string password, string cpassword)
        {
            Assert.IsNotNull(password);
            Assert.IsNotNull(cpassword);
            ScenarioContext.Current["incorrect_pwd"] = password;
            ScenarioContext.Current["incorrect_cpwd"] = cpassword;
            driver.FindElement(By.Id("btn-sub")).Click();
        }

        [Then(@"user receives Error message")]
        public void ThenUserReceivesErrorMessage()
        {
            string password = ScenarioContext.Current["incorrect_pwd"].ToString();
            string cpassword = ScenarioContext.Current["incorrect_cpwd"].ToString();
            Assert.AreNotEqual(password, cpassword);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Navigate().GoToUrl("https://localhost:44318/Error.html");
        }

        [When(@"password '([^']*)' and confirm_password '([^']*)' are same")]
        public void WhenPasswordAndConfirm_PasswordAreSame(string password, string cpassword)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Navigate().Back();
            ScenarioContext.Current["correct_pwd"] = password;
            ScenarioContext.Current["correct_cpwd"] = cpassword;
            driver.FindElement(By.Id("btn-sub")).Click();
        }

        [Then(@"user receives Success message")]
        public void ThenUserReceivesSuccessMessage()
        {
            string password = ScenarioContext.Current["correct_pwd"].ToString();
            string cpassword = ScenarioContext.Current["correct_cpwd"].ToString();
            Assert.AreEqual(password, cpassword);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Navigate().GoToUrl("https://localhost:44318/Success.html");
        }

    }
}
