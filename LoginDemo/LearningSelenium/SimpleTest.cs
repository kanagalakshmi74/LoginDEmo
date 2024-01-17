using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSelenium
{
    internal class SimpleTest
    {
        IWebDriver driver;

        [SetUp] //it will execute before each and every test attributes / methods runs 
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test] // it is testcase, while it called it automatically call Setup and Teardown method/ attribute
        public void TestMethod()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            string dItem = "Sauce Labs Bike Light";
            string item = driver.FindElement(By.XPath("//*[@id='inventory_container']/div/div[2]/div[2]")).Text;
           // Console.WriteLine(item);

            string itemTitle = driver.FindElement(By.XPath("//*[@id='item_0_title_link']/div")).Text;
           // Console.WriteLine(itemTitle);

            Assert.AreEqual(dItem, itemTitle);
            driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//*[@id='shopping_cart_container']/a")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.Name("checkout")).Click();
            driver.FindElement(By.Id("first-name")).SendKeys("Mark");
            driver.FindElement(By.Id("last-name")).SendKeys("Jack");
            driver.FindElement(By.Id("postal-code")).SendKeys("962870");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("continue")).Click();
            Thread.Sleep(2000);


            string amount = driver.FindElement(By.XPath("//*[@id='checkout_summary_container']/div/div[2]/div[8]")).Text ;
            var price = amount.Substring(amount.LastIndexOf('$') + 1);
            Assert.LessOrEqual( double.Parse( price),11.00);
            driver.FindElement(By.XPath("//*[@id='finish']")).Click();

            Thread.Sleep(2000);
            driver.FindElement(By.Id("back-to-products")).Click();


        }
        [TearDown] // it will execute after each and every test method runs
        public void TearDown()
        {
            driver.Close();
        }
    }
}
