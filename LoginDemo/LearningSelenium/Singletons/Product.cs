using OpenQA.Selenium;

namespace LearningSelenium.Singletons
{
    //Singleton pattern with sealed class for avoiding inheritance private constructor
    //lock is a way to make sure that only one instance of Singleton class is created

    public class Product
    {
        public static Product productObj=null;
        private static readonly object productlock = new object();
        WebDriver driver;
        public By item1 = By.LinkText("Sauce Labs Bike Light");
        private By addItem1 = By.XPath("//button[@id='add-to-cart-sauce-labs-bike-light' or @id='remove-sauce-labs-bike-light']");
        public By backMenu = By.XPath("//button[contains(@id,'back-to-products')]");
        private By item2 = By.PartialLinkText("Backpack");
        private By addItem2 = By.XPath("//button[@id='add-to-cart-sauce-labs-backpack' or @id='remove-sauce-labs-backpack']");
        private By itemCount = By.XPath("//a[contains(@class,'shopping_cart_link')]/span[contains(@class,'shopping_cart_badge')]");

        private Product()
        {

        }

        public static Product GetInstance(WebDriver driver)
        {
            if (productObj == null) //double-checking the instance  
            {
                lock (productlock) //lock used to control thread
                {
                    if (productObj == null)
                    {
                        productObj = new Product();
                    }
                }
            }
            productObj.driver = driver;
            return productObj;
        }

        public void GetItem1()
        {
            driver.FindElement(item1).Click();
        }

        public void GetItem2()
        {
            driver.FindElement(item2).Click();
        }

        public void LinkItem1()
        {
            driver.FindElement(addItem1).Click();
        }

        public void LinkItem2()
        {
            driver.FindElement(addItem2).Click();
        }

        public int GetItemCount()
        {
            var errorElement = driver.FindElement(itemCount);
            int cnt = int.Parse(errorElement.Text);
            return cnt;
        }
    }
}
