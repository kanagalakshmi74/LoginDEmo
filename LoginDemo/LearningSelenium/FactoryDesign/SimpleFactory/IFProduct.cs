using OpenQA.Selenium;

namespace LearningSelenium.FactoryDesign.SimpleFactory
{
    //interface or abstract class defining the methods that concrete products must implement
    public interface IFProduct
    {
        void PerformClick();
    }

    //below are the classes that implements the Product interface
    //login
    public class LoginPage : IFProduct
    {
        private readonly WebDriver driver;
        private readonly ReadConfig config;
        private By swagUserName = By.XPath("//input[contains(@id,'user-name')]");
        private By swagPassword = By.XPath("//input[contains(@id,'password')]");
        private By swagLogButton = By.XPath("//input[contains(@id,'login-button')]");

        public LoginPage(WebDriver driver, ReadConfig config)
        {
            this.driver = driver;
            this.config = config;
        }

        public void EnterSwagUserName(string userName)
        {
            driver.FindElement(swagUserName).SendKeys(userName);
        }

        public void EnterSwagPassword(string password)
        {
            driver.FindElement(swagPassword).SendKeys(password);
        }

        public void GetUserFeilds()
        {
            EnterSwagUserName(config.userName);
            EnterSwagPassword(config.password);
        }

        public void PerformClick()
        {
            GetUserFeilds();
            driver.FindElement(swagLogButton).Click();
        }

    }

    //product
    public class ProductPage : IFProduct
    {
        private readonly WebDriver driver;
        private readonly ReadConfig config;
        private By item = By.LinkText("Sauce Labs Bike Light");
        private By addItem = By.XPath("//button[@id='add-to-cart-sauce-labs-bike-light' or @id='remove-sauce-labs-bike-light']");
        public By backMenu = By.XPath("//button[contains(@id,'back-to-products')]");
        
        public ProductPage(WebDriver driver, ReadConfig config)
        {
            this.driver = driver;
            this.config = config;
        }

        public void GetItem()
        {
            driver.FindElement(item).Click();
        }

        public void LinkItem()
        {
            driver.FindElement(addItem).Click();
        }

        public void PerformClick()
        {
            GetItem();
            LinkItem();
            driver.FindElement(backMenu).Click();
        }
    }

    //purchase
    public class PurchasePage : IFProduct
    {
        private readonly WebDriver driver;
        private readonly ReadConfig config;
        private readonly ReadTestDataConfig testConfig;
        public By cart = By.XPath("//a[contains(@class,'shopping_cart_link')]");
        public By checkout = By.XPath("//button[contains(@id,'checkout')]");
        private By fName = By.XPath("//input[contains(@id,'first-name')]");
        private By lName = By.XPath("//input[contains(@id,'last-name')]");
        private By postal = By.XPath("//input[contains(@id,'postal-code')]");
        public By _continue = By.XPath("//input[contains(@id,'continue') and contains(@type,'submit')]");
        private By _price = By.XPath("//div[contains(@class,'summary_total_label')]");
        private By finish = By.XPath("//button[contains(@id,'finish')]");

        public PurchasePage(WebDriver driver, ReadConfig config, ReadTestDataConfig testConfig)
        {
            this.driver = driver;
            this.config = config;
            this.testConfig = testConfig;
        }

        public void EnterFirstName(string firstName)
        {
            driver.FindElement(fName).SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            driver.FindElement(lName).SendKeys(lastName);
        }

        public void EnterPostal(string postalCode)
        {
            driver.FindElement(postal).SendKeys(postalCode);
        }

        public void GetDataFields()
        {
            driver.FindElement(cart).Click();
            driver.FindElement(checkout).Click();
            EnterFirstName(testConfig.firstName);
            EnterLastName(testConfig.lastName);
            EnterPostal(testConfig.postal);
            driver.FindElement(_continue).Click();
        }
        
        public void PerformClick()
        {
            GetDataFields();
            driver.FindElement(finish).Click();
        }
    }
}
