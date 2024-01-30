using LearningSelenium.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LearningSelenium.FactoryDesign.FactoryMethodDesign
{
    public class FMDTest
    {
        WebDriver driver;
        Utility utilityObj;
        //absolute path
        //ReadConfig config = ReadConfig.GetReadConfig("C:/Kanaga/repo/Login/LoginDemo/LoginDemo/LearningSelenium/FactoryDesign/DataConfig.json");
        //relative path
        static string filePath = @"..\..\..\DataConfig.json";
        ReadConfig config =ReadConfig.GetReadConfig(filePath);
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
            utilityObj.SetImplicitWait(config.waitTime);
            IFMProduct obj = new FMLogin().FactoryMethod(driver, config,testConfig);

            //login
            obj.PerformClick();
            utilityObj.SetImplicitWait(config.waitTime);

            //products
            obj = new FMItems().FactoryMethod(driver, config, testConfig);
            obj.PerformClick();
            utilityObj.SetImplicitWait(config.waitTime);

            //purchase
            obj = new FMPurchase().FactoryMethod(driver, config, testConfig);
            obj.PerformClick();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }

    }
}
