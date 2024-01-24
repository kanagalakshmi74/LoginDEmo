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
            Login login= new Login(driver);
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            login.EnterUserName("admin");
            login.EnterPassword("admin1234");
            login.LoginClick();

            WebDriverWait wait= new WebDriverWait(driver,TimeSpan.FromSeconds(20));
            wait.Until(d => login.GetErrorMessage());
            Assert.AreEqual("Invalid credentials", login.GetErrorMessage(),"username or password is incorrect");

        }

        [Test]
        public void TestLoginSuccess()
        {
            Login login = new Login(driver);
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            login.EnterUserName("Admin");
            login.EnterPassword("admin123");
            login.LoginClick();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(d => login.GetSuccessMessage());
            Assert.AreEqual("Dashboard", login.GetSuccessMessage(), "Dashboard not loading...");

        }

        [Test]
        public void TestLogFail()
        {
            Login login = new Login(driver);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            login.EnterSwagUserName("user");
            login.EnterSwagPassword("secert_sauce");
            login.SwagLoginClick();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(d => login.GetSwagErrorMessage());
            Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", login.GetSwagErrorMessage(), "username or password is incorrect");

        }
        
        [Test]
        public void TestLogSuccess()
        {
            Login login = new Login(driver);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            login.EnterSwagUserName("standard_user");
            login.EnterSwagPassword("secret_sauce");
            login.SwagLoginClick();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(d => login.GetSwagSuccessMessage());
            Assert.AreEqual("Products", login.GetSwagSuccessMessage(), "loged user name is mismatch");

        }
        [Test]
        public void TestPurchase()
        {
            Login login = new Login(driver);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            login.EnterSwagUserName("visual_user");
            login.EnterSwagPassword("secret_sauce");
            login.SwagLoginClick(); 
            Product product = new Product(driver);
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(20);
            product.GetItem1();
            product.LinkItem1();            
            driver.FindElement(product.backMenu).Click();
            product.GetItem2();
            product.LinkItem2();            
            driver.FindElement(product.backMenu).Click();
            Assert.Greater(product.GetItemCount(), 0, "Shopping card is empty");
        }
        [Test]
        public void TestShopping()
        {
            Login login = new Login(driver);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            login.EnterSwagUserName("visual_user");
            login.EnterSwagPassword("secret_sauce");
            login.SwagLoginClick(); 
            Product product = new Product(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            product.GetItem1();
            product.LinkItem1();
            driver.FindElement(product.backMenu).Click();
            product.GetItem2();
            product.LinkItem2();
            driver.FindElement(product.backMenu).Click();
            Purchase purchase=new Purchase(driver);
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(20);
            driver.FindElement(purchase.cart).Click();
            driver.FindElement(purchase.checkout).Click();
            purchase.EnterFirstName("Mark");
            purchase.EnterLastName("David");
            purchase.EnterPostal("707872");
            driver.FindElement(purchase._continue).Click();
            Assert.Greater(purchase.GetPrice(), 0.00, "Shopping card is empty");
        }
        [TearDown]
        public void TearDown()
        {
           driver.Close();
        }
    }
    }
