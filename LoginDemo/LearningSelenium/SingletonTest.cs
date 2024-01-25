using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using LearningSelenium.Singletons;
using LearningSelenium.Utilities;
using OpenQA.Selenium.Support.UI;

namespace LearningSelenium
{
    public class SingletonTest
    {
        WebDriver driver;
        Utility utilityObj;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            //driver.Manage().Window.Maximize();
            utilityObj = Utility.GetInstance(driver);
            utilityObj.SetImplicitWait(20);

        }

        [Test]
        public void TestLoginFail()
        {
            Singleton singletonObj = Singleton.GetInstance(driver);
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            utilityObj.SetImplicitWait(20);
            singletonObj.EnterUserName("admin");
            singletonObj.EnterPassword("admin1234");
            singletonObj.LoginClick();
            utilityObj.SetExplicitWait(singletonObj.GetErrorMessage(),20);
            Assert.That(singletonObj.GetErrorMessage(),Is.EqualTo("Invalid credentials") , "username or password is incorrect");
        }

        [Test]
        public void TestLoginSuccess()
        {
            Singleton singletonObj = Singleton.GetInstance(driver);
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            utilityObj.SetImplicitWait(20);
            singletonObj.EnterUserName("Admin");
            singletonObj.EnterPassword("admin123");
            singletonObj.LoginClick();
            utilityObj.SetExplicitWait(singletonObj.GetSuccessMessage(), 20);
            Assert.That(singletonObj.GetSuccessMessage(), Is.EqualTo("Dashboard"), "Dashboard not loading...");

        }

        [Test]
        public void TestLogin()
        {
            Singleton singletonObj = Singleton.GetInstance(driver);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/"); 
            utilityObj.SetImplicitWait(20);
            singletonObj.EnterSwagUserName("standard_user");
            singletonObj.EnterSwagPassword("secret_sauce");
            singletonObj.SwagLoginClick();
            utilityObj.SetExplicitWait(singletonObj.GetSwagSuccessMessage(), 20);
            Assert.AreEqual("Products", singletonObj.GetSwagSuccessMessage(), "loged user name is mismatch");
        }

        [Test]
        public void TestProduct()
        {
            TestLogin();
            Product productObj = Product.GetInstance(driver);
            productObj.GetItem1();
            productObj.LinkItem1();
            driver.FindElement(productObj.backMenu).Click();
            productObj.GetItem2();
            productObj.LinkItem2();
            driver.FindElement(productObj.backMenu).Click();
            utilityObj.SetExplicitWait(productObj.GetItemCount().ToString(), 20);
            Assert.Greater(productObj.GetItemCount(), 0, "Shopping card is empty");
        }

        [Test]
        public void TestShopping()
        {
            TestProduct();
            Purchase purchaseObj = Purchase.GetInstance(driver);
            driver.FindElement(purchaseObj.cart).Click();
            driver.FindElement(purchaseObj.checkout).Click();
            purchaseObj.EnterFirstName("Mark");
            purchaseObj.EnterLastName("David");
            purchaseObj.EnterPostal("707872");
            driver.FindElement(purchaseObj._continue).Click();
            utilityObj.SetExplicitWait(purchaseObj.GetPrice().ToString(), 20);
            Assert.Greater(purchaseObj.GetPrice(), 0.00, "Shopping card is empty");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

    }
}
