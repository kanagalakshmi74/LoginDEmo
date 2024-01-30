using OpenQA.Selenium;

namespace LearningSelenium.FactoryDesign.SimpleFactory
{
    public class FProduct
    {
        private WebDriver driver;
        private ReadConfig config;
        private ReadTestDataConfig testConfig;

        public FProduct(WebDriver driver, ReadConfig config, ReadTestDataConfig testConfig)
        {
            this.driver = driver;
            this.config = config;
            this.testConfig = testConfig;
        }


        //provides the factory method to return an instance of a specific Concrete Product
        public IFProduct CreateInstance(string pageType)
        {
            switch (pageType.ToLower())
            {
                case "login":
                    return new LoginPage(driver, config);
                case "product":
                    return new ProductPage(driver, config);
                case "purchase":
                    return new PurchasePage(driver, config, testConfig);
                default:
                    throw new ArgumentException("Invalid type");
            }
        }
    }
}
