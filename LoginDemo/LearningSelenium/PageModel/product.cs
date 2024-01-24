using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSelenium.PageModel
{
    public class Product
    {
        WebDriver driver;
        private By item1 = By.LinkText("Sauce Labs Bike Light");
        private By addItem1 = By.XPath("//button[@id='add-to-cart-sauce-labs-bike-light' or @id='remove-sauce-labs-bike-light']");
        public By backMenu = By.XPath("//button[contains(@id,'back-to-products')]");
        private By item2 = By.PartialLinkText("Backpack");
        private By addItem2 = By.XPath("//button[@id='add-to-cart-sauce-labs-backpack' or @id='remove-sauce-labs-backpack']");
        private By itemCount = By.XPath("//a[contains(@class,'shopping_cart_link')]/span[contains(@class,'shopping_cart_badge')]");
        public Product(WebDriver driver)
        {
            this.driver = driver;
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
