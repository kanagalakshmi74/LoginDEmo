using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using LearningSelenium.Utilities;

namespace LearningSelenium.FactoryDesign.SimpleFactory
{
    public class FactoryDesignTest
    {
        WebDriver driver;
        Utility utilityObj;
        static string filePath = @"..\..\..\DataConfig.json"; 
        ReadConfig config = ReadConfig.GetReadConfig(filePath);
        static string testDataFilePath = @"..\..\..\TestDataConfig.json";
        ReadTestDataConfig testConfig = ReadTestDataConfig.GetTestDataConfig(testDataFilePath);

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            utilityObj = Utility.GetInstance(driver);
            utilityObj.SetImplicitWait(config.waitTime);
        }

        [Test]
        public void TestMethod()
        {
            driver.Navigate().GoToUrl(config.baseUrl);
            var factoryClass = new FactoryClass(driver);
            var login = factoryClass.CreateLoginFactory();

            //login
            utilityObj.SetImplicitWait(config.waitTime);
            login.EnterSwagUserName(config.userName);
            login.EnterSwagPassword(config.password);
            login.SwagLoginClick();
            utilityObj.SetExplicitWait(login.GetSwagSuccessMessage(), config.waitTime);

            //products
            var productObj = factoryClass.CreateProductFactory();
            productObj.GetItem1();
            productObj.LinkItem1();
            driver.FindElement(productObj.backMenu).Click();
            productObj.GetItem2();
            productObj.LinkItem2();
            driver.FindElement(productObj.backMenu).Click();
            utilityObj.SetExplicitWait(productObj.GetItemCount().ToString(), config.waitTime);

            //purchase
            var purchaseObj = factoryClass.CreatePurchaseFactory();
            driver.FindElement(purchaseObj.cart).Click();
            driver.FindElement(purchaseObj.checkout).Click();
            purchaseObj.EnterFirstName(testConfig.firstName);
            purchaseObj.EnterLastName(testConfig.lastName);
            purchaseObj.EnterPostal(testConfig.postal);
            driver.FindElement(purchaseObj._continue).Click();
            utilityObj.SetExplicitWait(purchaseObj.GetPrice().ToString(), config.waitTime);
            Assert.Greater(purchaseObj.GetPrice(), 0.00, "Shopping card is empty");

        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

    }
}