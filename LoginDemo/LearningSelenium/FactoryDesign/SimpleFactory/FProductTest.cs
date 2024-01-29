using LearningSelenium.Utilities;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace LearningSelenium.FactoryDesign.SimpleFactory
{
    public class FProductTest
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
            utilityObj.SetImplicitWait(20);
            var factoryClass = new FProduct(driver, config);
            var login = factoryClass.CreateInstance("login");

            //login
            login.PerformClick();
            utilityObj.SetImplicitWait(20);

            //products
            var productObj = factoryClass.CreateInstance("product");
            productObj.PerformClick();
            utilityObj.SetImplicitWait(20);

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
