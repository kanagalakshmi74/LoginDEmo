using OpenQA.Selenium;

namespace LearningSelenium.Singletons
{
    //Simple Singleton pattern with private constructor
    //Private constructor ensures that object is not instantiated other than with in the class itself

    public class Singleton
    {
        public static Singleton singletonObj;
        public WebDriver driver;
        private By _userName = By.XPath("//input[contains(@name,'username')]");
        private By _password = By.XPath("//input[contains(@name,'password')]");
        private By logButton = By.XPath("//button[contains(@type,'submit')]");
        private By logError = By.XPath("//p[contains(@class,'oxd-alert-content-text')]");
        private By logSuccess = By.XPath("//span[contains(@class,'oxd-topbar-header-breadcrumb')]");
        private By swagUserName = By.XPath("//input[contains(@id,'user-name')]");
        private By swagPassword = By.XPath("//input[contains(@id,'password')]");
        private By swagLogButton = By.XPath("//input[contains(@id,'login-button')]");
        private By swagLogError = By.XPath("//div[contains(@class,'error')]");
        private By swagLogSuccess = By.XPath("//div[contains(@class,'header_secondary_container')]/span[contains(@class,'title')]");

        private Singleton()
        {
            
        }        

        public static Singleton GetInstance(WebDriver driver)
        {
            if (singletonObj == null)
            {
                singletonObj = new Singleton();
            }
            singletonObj.driver = driver;
            return singletonObj;
        }

        public void EnterUserName(string userName)
        {
            driver.FindElement(_userName).SendKeys(userName);
        }

        public void EnterPassword(string password)
        {
            driver.FindElement(_password).SendKeys(password);
        }

        public void LoginClick()
        {
            driver.FindElement(logButton).Click();
        }

        public void EnterSwagUserName(string userName)
        {
            driver.FindElement(swagUserName).SendKeys(userName);
        }

        public void EnterSwagPassword(string password)
        {
            driver.FindElement(swagPassword).SendKeys(password);
        }

        public void SwagLoginClick()
        {
            driver.FindElement(swagLogButton).Click();
        }

        public string GetErrorMessage()
        {
            var errorElement = driver.FindElement(logError);
            string strErrorMsg = errorElement.Text.Length > 0 ? errorElement.Text : null;
            return strErrorMsg;
        }

        public string GetSuccessMessage()
        {
            var sucessElement = driver.FindElement(logSuccess);
            string strSuccessMsg = sucessElement.Text.Length > 0 ? sucessElement.Text : null;
            return strSuccessMsg;
        }

        public string GetSwagErrorMessage()
        {
            var errorElement = driver.FindElement(swagLogError);
            string strErrorMsg = errorElement.Text.Length > 0 ? errorElement.Text : null;
            return strErrorMsg;
        }

        public string GetSwagSuccessMessage()
        {
            var sucessElement = driver.FindElement(swagLogSuccess);
            string strSuccessMsg = sucessElement.Text.Length > 0 ? sucessElement.Text : null;
            return strSuccessMsg;
        }

    }
}
