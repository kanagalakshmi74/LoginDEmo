using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSelenium.PageModel
{
    public  class Product
    {
        WebDriver driver;
        protected By Item1 = By.LinkText("Sauce Labs Bike Light");
        protected By AddItem1 = By.XPath("//button[@id='add-to-cart-sauce-labs-bike-light' or @id='remove-sauce-labs-bike-light']");
        public By BackMenu = By.XPath("//button[contains(@id,'back-to-products')]");
        protected By Item2 = By.PartialLinkText("Backpack");
        protected By AddItem2 = By.XPath("//button[@id='add-to-cart-sauce-labs-backpack' or @id='remove-sauce-labs-backpack']");
        protected By ItemCount = By.XPath("//a[contains(@class,'shopping_cart_link')]/span[contains(@class,'shopping_cart_badge')]");
        public Product(WebDriver driver)
        {
            this.driver = driver;
        }
        public void getItem1()
        {
            driver.FindElement(Item1).Click();
        }
        public void getItem2()
        {
            driver.FindElement(Item2).Click();
        }
        public void LinkItem1()
        {
            driver.FindElement(AddItem1).Click();
        }
        public void LinkItem2()
        {
            driver.FindElement(AddItem2).Click();
        }
        public int getItemCount()
        {
            int cnt = 0;
            var errorElement = driver.FindElement(ItemCount);
            cnt= int.Parse(errorElement.Text);
            return cnt;
        }
    }
}
