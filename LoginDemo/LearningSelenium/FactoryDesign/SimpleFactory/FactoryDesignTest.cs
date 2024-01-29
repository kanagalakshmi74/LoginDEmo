using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using LearningSelenium.Utilities;

namespace LearningSelenium.FactoryDesign.SimpleFactory
{
    public class FactoryDesignTest
    {
        WebDriver driver;
        Utility utilityObj;
        ReadConfig config = ReadConfig.GetReadConfig("C:/Kanaga/repo/Login/LoginDemo/LoginDemo/LearningSelenium/FactoryDesign/DataConfig.json");

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            utilityObj = Utility.GetInstance(driver);
            utilityObj.SetImplicitWait(20);
        }

        [Test]
        public void TestMethod()
        {
            driver.Navigate().GoToUrl(config.baseUrl);
            var factoryClass = new FactoryClass(driver);
            var login = factoryClass.CreateLoginFactory();

            //login
            utilityObj.SetImplicitWait(20);
            login.EnterSwagUserName(config.userName);
            login.EnterSwagPassword(config.password);
            login.SwagLoginClick();
            utilityObj.SetExplicitWait(login.GetSwagSuccessMessage(), 20);

            //products
            var productObj = factoryClass.CreateProductFactory();
            productObj.GetItem1();
            productObj.LinkItem1();
            driver.FindElement(productObj.backMenu).Click();
            productObj.GetItem2();
            productObj.LinkItem2();
            driver.FindElement(productObj.backMenu).Click();
            utilityObj.SetExplicitWait(productObj.GetItemCount().ToString(), 20);

            //purchase
            var purchaseObj = factoryClass.CreatePurchaseFactory();
            driver.FindElement(purchaseObj.cart).Click();
            driver.FindElement(purchaseObj.checkout).Click();
            purchaseObj.EnterFirstName(config.firstName);
            purchaseObj.EnterLastName(config.lastName);
            purchaseObj.EnterPostal(config.postal);
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