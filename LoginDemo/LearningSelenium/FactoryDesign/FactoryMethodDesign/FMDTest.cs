using LearningSelenium.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LearningSelenium.FactoryDesign.FactoryMethodDesign
{
    public class FMDTest
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
            IFMProduct obj = new FMLogin().FactoryMethod(driver, config);

            //login
            obj.PerformClick();
            utilityObj.SetImplicitWait(20);

            //products
            obj = new FMItems().FactoryMethod(driver, config);
            obj.PerformClick();
            utilityObj.SetImplicitWait(20);

            //purchase
            obj = new FMPurchase().FactoryMethod(driver, config);
            obj.PerformClick();
        }

    }
}
