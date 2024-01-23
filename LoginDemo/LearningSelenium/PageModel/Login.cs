using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LearningSelenium.PageModel
{
    public class Login
    {
        WebDriver driver;
        protected By UserName = By.XPath("//input[contains(@name,'username')]");
        protected By Password = By.XPath("//input[contains(@name,'password')]");
        protected By LogButton = By.XPath("//button[contains(@type,'submit') ]");
        public By LogError = By.XPath("//p[contains(@class,'oxd-text') and contains(@class,'oxd-text--p') and contains(@class,'oxd-alert-content-text') ]");
        public By LogSuccess = By.XPath("//h6[contains(@class,'oxd-text')and contains(@class,'oxd-text--h6') and contains(@class,'oxd-topbar-header-breadcrumb-module')]");

        protected By SUserName = By.XPath("//input[contains(@id,'user-name')]");
        protected By SPassword = By.XPath("//input[contains(@id,'password')]");
        protected By SLogButton = By.XPath("//input[contains(@id,'login-button') ]");
        public By SLogError = By.XPath("//div[contains(@class,'error-message-container') and contains(@class,'error')]/h3");
        public By SLogSuccess = By.XPath("//div[contains(@class,'header_secondary_container')]/span[contains(@class,'title')]");


        public Login(WebDriver driver)
        {
            this.driver = driver;
        }
        public void enterUserName(string userName)
        {
            driver.FindElement(UserName).SendKeys(userName);
        }
        public void enterPassword(string password)
        {
            driver.FindElement(Password).SendKeys(password);
        }
        public void LoginClick()
        {
            driver.FindElement(LogButton).Click();
        }
        public void enterSwagUserName(string userName)
        {
            driver.FindElement(SUserName).SendKeys(userName);
        }
        public void enterSwagPassword(string password)
        {
            driver.FindElement(SPassword).SendKeys(password);
        }
        public void SwagLoginClick()
        {
            driver.FindElement(SLogButton).Click();
        }
        public string getErrorMessage()
        {
            string strErrorMsg = null;
            var errorElement = driver.FindElement(LogError);
            strErrorMsg = (errorElement.Text.Length>0) ? errorElement.Text : null;
            return strErrorMsg;
        }
        public string getSuccessMessage()
        {
            string strSuccessMsg = null;
            var sucessElement = driver.FindElement(LogSuccess);
            strSuccessMsg = (sucessElement.Text.Length > 0) ? sucessElement.Text : null;
            return strSuccessMsg;
        }
        public string getSwagErrorMessage()
        {
            string strErrorMsg = null;
            var errorElement = driver.FindElement(SLogError);
            strErrorMsg = (errorElement.Text.Length > 0) ? errorElement.Text : null;
            return strErrorMsg;
        }
        public string getSwagSuccessMessage()
        {
            string strSuccessMsg = null;
            var sucessElement = driver.FindElement(SLogSuccess);
            strSuccessMsg = (sucessElement.Text.Length > 0) ? sucessElement.Text : null;
            return strSuccessMsg;
        }
    }
}
