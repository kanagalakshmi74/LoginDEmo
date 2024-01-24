using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Xml.Linq;
namespace LearningSelenium
{
    internal class locators
    {
        IWebDriver driver;
        
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void testLocator()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            //using Absolute XPath
            driver.FindElement(By.XPath("html/body/div/div/div[2]/div[1]/div/div/form/div[1]/input")).SendKeys("standard_user");

            //using Relative Xpath
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            //Basic XPath, select the element based on the attributes from the given node( node used here is input )
            driver.FindElement(By.XPath("//input[@id='login-button']")).Click();

            //XPath using contains 
            driver.FindElement(By.XPath("//*[contains(@id,'item_0_title_link')]")).Click();

            //XPath using OR & AND
            driver.FindElement(By.XPath("//button[@id='add-to-cart-sauce-labs-bike-light' or @id='remove-sauce-labs-bike-light']")).Click();


            driver.FindElement(By.XPath("//button[@id='back-to-products']")).Click();

            //using Text
            driver.FindElement(By.XPath("//*[@id='header_container']/div[2]/span[text()='Products']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            driver.FindElement(By.XPath("//button[contains(@id,'react-burger-menu-btn')]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            driver.FindElement(By.XPath("//a[contains(@id,'logout_sidebar_link')]")).Click();


        }

        [Test]
        public void testTraditionalLocator()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            //using ClassName
            driver.FindElement(By.ClassName("form_input")).SendKeys("visual_user");

            //using CssSelector,the script executes faster than the XPath locator.
            driver.FindElement(By.CssSelector("input#password")).SendKeys("secret_sauce");


            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            //using Name
            driver.FindElement(By.Name("login-button")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            //using LinkText
            var item = driver.FindElement(By.LinkText("Sauce Labs Bike Light")).Text;
            Assert.AreEqual("Sauce Labs Bike Light", item);

            driver.FindElement(By.LinkText("Sauce Labs Bike Light")).Click();

            //using XPath
            driver.FindElement(By.XPath("//button[@id='add-to-cart-sauce-labs-bike-light' or @id='remove-sauce-labs-bike-light']")).Click();

            driver.FindElement(By.XPath("//button[contains(@id,'back-to-products')]")).Click();
            
            //using PartialLinkText
            driver.FindElement(By.PartialLinkText("Backpack")).Click();

            driver.FindElement(By.XPath("//button[@id='add-to-cart-sauce-labs-backpack' or @id='remove-sauce-labs-backpack']"));

            driver.FindElement(By.XPath("//button[@id='back-to-products']")).Click();

            //using Text
            var t= driver.FindElement(By.XPath("//*[@id='header_container']/div[2]/span[text()='Products']")).Text;
            Assert.AreEqual("Products", t);

            driver.FindElement(By.XPath("//button[contains(@id,'react-burger-menu-btn')]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            driver.FindElement(By.XPath("//a[contains(@id,'logout_sidebar_link')]")).Click();


        }

        [Test]
        public void testFindElements()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            driver.FindElement(By.XPath("//input[contains(@id,'user-name')]")).SendKeys("standard_user");

            driver.FindElement(By.XPath("//input[contains(@id,'password')]")).SendKeys("secret_sauce");


            // Get element with tag name 'div'
            IWebElement element = driver.FindElement(By.XPath("//div[contains(@id,'login_button_container')]"));
            
            // Get all the elements available with tag name 'p'
            IList<IWebElement> elements = element.FindElements(By.TagName("input"));
            foreach (IWebElement e in elements)
            {
                Console.WriteLine(e.GetAttribute("name") +" : " + e.GetAttribute("value"));
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}