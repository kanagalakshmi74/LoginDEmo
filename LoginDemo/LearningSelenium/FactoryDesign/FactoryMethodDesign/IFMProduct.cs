using OpenQA.Selenium;

namespace LearningSelenium.FactoryDesign.FactoryMethodDesign
{
    public interface IFMProduct
    {

        void PerformClick();
    }

    //concrete class
    public class FMDLogin : IFMProduct
    {
        private readonly WebDriver driver;
        private readonly ReadConfig config;
        private By swagUserName = By.XPath("//input[contains(@id,'user-name')]");
        private By swagPassword = By.XPath("//input[contains(@id,'password')]");
        private By swagLogButton = By.XPath("//input[contains(@id,'login-button')]");

        public FMDLogin(WebDriver driver, ReadConfig config)
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

        public void PerformClick()
        {
            EnterSwagUserName(config.userName);
            EnterSwagPassword(config.password);
            driver.FindElement(swagLogButton).Click();
        }
    }

    public class FMDItems : IFMProduct
    {
        private readonly WebDriver driver;
        private readonly ReadConfig config;
        private By item = By.LinkText("Sauce Labs Bike Light");
        private By addItem = By.XPath("//button[@id='add-to-cart-sauce-labs-bike-light' or @id='remove-sauce-labs-bike-light']");
        public By backMenu = By.XPath("//button[contains(@id,'back-to-products')]");
        private By itemCount = By.XPath("//a[contains(@class,'shopping_cart_link')]/span[contains(@class,'shopping_cart_badge')]");

        public FMDItems(WebDriver driver, ReadConfig config)
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
    public class FMDPurchase : IFMProduct
    {
        private readonly WebDriver driver;
        private readonly ReadConfig config;
        public By cart = By.XPath("//a[contains(@class,'shopping_cart_link')]");
        public By checkout = By.XPath("//button[contains(@id,'checkout')]");
        private By fName = By.XPath("//input[contains(@id,'first-name')]");
        private By lName = By.XPath("//input[contains(@id,'last-name')]");
        private By postal = By.XPath("//input[contains(@id,'postal-code')]");
        public By _continue = By.XPath("//input[contains(@id,'continue') and contains(@type,'submit')]");
        private By _price = By.XPath("//div[contains(@class,'summary_total_label')]");
        private By finish = By.XPath("//button[contains(@id,'finish')]");

        public FMDPurchase(WebDriver driver, ReadConfig config)
        {
            this.driver = driver;
            this.config = config;
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

        public void PerformClick()
        {

            driver.FindElement(cart).Click();
            driver.FindElement(checkout).Click();
            EnterFirstName(config.firstName);
            EnterLastName(config.lastName);
            EnterPostal(config.postal);
            driver.FindElement(_continue).Click();
            var errorElement = driver.FindElement(_price);
            decimal price = decimal.Parse(errorElement.Text.Substring(errorElement.Text.LastIndexOf('$') + 1));
            Assert.Greater(price, 0.00, "Shopping card is empty");
            driver.FindElement(finish).Click();
        }
    }
}