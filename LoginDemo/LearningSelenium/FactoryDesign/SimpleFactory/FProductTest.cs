using LearningSelenium.Utilities;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace LearningSelenium.FactoryDesign.SimpleFactory
{
    public class FProductTest
    {
        WebDriver driver;
        Utility utilityObj;
        static string dataFilePath = @"..\..\..\DataConfig.json";
        static string testDataFilePath = @"..\..\..\TestDataConfig.json";
        ReadConfig config = ReadConfig.GetReadConfig(dataFilePath);
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
            utilityObj.SetImplicitWait(config.waitTime);
            var factoryClass = new FProduct(driver, config,testConfig);
            var login = factoryClass.CreateInstance("login");

            //login
            login.PerformClick();
            utilityObj.SetImplicitWait(config.waitTime);

            //products
            var productObj = factoryClass.CreateInstance("product");
            productObj.PerformClick();
            utilityObj.SetImplicitWait(config.waitTime);

            //purchase
            var purchaseObj = factoryClass.CreateInstance("purchase");
            purchaseObj.PerformClick();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

    }
}
