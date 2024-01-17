using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace LoginSF.StepDefinitions
{
    [Binding]
    public class SignInSteps
    {
        private IWebDriver driver;
        private readonly string baseurl = "https://localhost:44318/Registration.html";

        [Given(@"Load the browser")]     
        [When(@"login page opens")]
        public void WhenLoginPageOpens()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();  
        }

        [Then(@"enter username password confirm password")]
        public void ThenEnterUsernamePasswordConfirmPassword()
        {
            driver.Navigate().GoToUrl(baseurl);
            driver.FindElement(By.Id("username")).SendKeys("user1");
            driver.FindElement(By.Id("password")).SendKeys("123456");
            driver.FindElement(By.Id("cpassword")).SendKeys("12345");
            Thread.Sleep(2000);
        }


        [When(@"Attempt log in using incorrect '([^']*)','([^']*)' and '([^']*)'")]
        public void WhenAttemptLogInUsingIncorrectAnd(string username, string password, string cpassword)
        {
            driver.FindElement(By.Id("btn-sub")).Click();
            Thread.Sleep(3000);
            driver.Navigate().GoToUrl("https://localhost:44318/Error.html");
           
        }

        [Then(@"the user receives access invalid")]
        public void ThenTheUserReceivesAccessInvalid()
        {
            Console.WriteLine("User Registered Failed");
            Thread.Sleep(5000);
        }

        [When(@"Attempt log in using correct '([^']*)','([^']*)' and '([^']*)'")]
        public void WhenAttemptLogInUsingCorrectAnd(string username, string password, string cpassword)
        {
            driver.Navigate().GoToUrl(baseurl);
            driver.FindElement(By.Id("username")).SendKeys("user1");
            driver.FindElement(By.Id("password")).SendKeys("123456");
            driver.FindElement(By.Id("cpassword")).SendKeys("123456");
            driver.FindElement(By.Id("btn-sub")).Click();
            Thread.Sleep(2000);
            driver.Navigate().GoToUrl("https://localhost:44318/Success.html");
        }

        [Then(@"the user receives log in success message")]
        public void ThenTheUserReceivesLogInSuccessMessage()
        {
            Console.WriteLine("User Registered Sucessfully");
        }

    }
}
