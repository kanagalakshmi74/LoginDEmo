using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningSelenium.PageModel;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace LearningSelenium
{
    internal class Shopping
    {
        WebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

        }

        [Test]
        public void TestLoginFail()
        {
            Login lg = new Login(driver);
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            lg.enterUserName("admin");
            lg.enterPassword("admin1234");
            lg.LoginClick();

            WebDriverWait wait= new WebDriverWait(driver,TimeSpan.FromSeconds(20));
            wait.Until(d => lg.getErrorMessage());
            Assert.AreEqual("Invalid credentials", lg.getErrorMessage(),"username or password is incorrect");

        }

        [Test]
        public void TestLoginSuccess()
        {
            Login lg = new Login(driver);
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            lg.enterUserName("Admin");
            lg.enterPassword("admin123");
            lg.LoginClick();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(d => lg.getSuccessMessage());
            Assert.AreEqual("Dashboard", lg.getSuccessMessage(), "Dashboard not loading...");

        }

        [Test]
        public void TestLogFail()
        {
            Login lg = new Login(driver);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            lg.enterSwagUserName("user");
            lg.enterSwagPassword("secert_sauce");
            lg.SwagLoginClick();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(d => lg.getSwagErrorMessage());
            Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", lg.getSwagErrorMessage(), "username or password is incorrect");

        }
        
        [Test]
        public void TestLogSuccess()
        {
            Login lg = new Login(driver);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            lg.enterSwagUserName("standard_user");
            lg.enterSwagPassword("secret_sauce");
            lg.SwagLoginClick();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(d => lg.getSwagSuccessMessage());
            Assert.AreEqual("Products", lg.getSwagSuccessMessage(), "loged user name is mismatch");

        }
        [Test]
        public void TestPurchase()
        {
            Login lg = new Login(driver);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            lg.enterSwagUserName("visual_user");
            lg.enterSwagPassword("secret_sauce");
            lg.SwagLoginClick(); 
            Product p = new Product(driver);
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(20);
            p.getItem1();
            p.LinkItem1();            
            driver.FindElement(p.BackMenu).Click();
            p.getItem2();
            p.LinkItem2();            
            driver.FindElement(p.BackMenu).Click();
            Assert.Greater(p.getItemCount(), 0, "Shopping card is empty");
        }
        [Test]
        public void TestShopping()
        {
            Login lg = new Login(driver);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            lg.enterSwagUserName("visual_user");
            lg.enterSwagPassword("secret_sauce");
            lg.SwagLoginClick(); 
            Product p = new Product(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            p.getItem1();
            p.LinkItem1();
            driver.FindElement(p.BackMenu).Click();
            p.getItem2();
            p.LinkItem2();
            driver.FindElement(p.BackMenu).Click();
            Purchase s=new Purchase(driver);
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(20);
            driver.FindElement(s.Cart).Click();
            driver.FindElement(s.Checkout).Click();
            s.enterFirstName("Mark");
            s.enterLastName("David");
            s.enterPostal("707872");
            driver.FindElement(s.Continue).Click();
            Assert.Greater(s.getPrice(), 0.00, "Shopping card is empty");
        }
        [TearDown]
        public void TearDown()
        {
           driver.Close();
        }
    }
    }
