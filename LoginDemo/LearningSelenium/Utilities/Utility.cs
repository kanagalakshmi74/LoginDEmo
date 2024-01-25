using LearningSelenium.Singletons;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LearningSelenium.Utilities
{
    public class Utility
    {
        public static Utility utilityObj;
        public WebDriver driver;

        private Utility()
        {

        }

        public static Utility GetInstance(WebDriver driver)
        {
            if (utilityObj == null)
            {
                utilityObj = new Utility();
            }
            utilityObj.driver = driver;
            return utilityObj;
        }

        public void SetImplicitWait(int seconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }
        public void SetExplicitWait(string condition, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(webdriver =>condition);
        }

    }
}
