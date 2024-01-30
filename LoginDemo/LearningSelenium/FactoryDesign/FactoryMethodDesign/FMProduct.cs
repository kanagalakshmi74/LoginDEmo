using OpenQA.Selenium;

namespace LearningSelenium.FactoryDesign.FactoryMethodDesign
{
    //an abstract class and declares the factory method, which returns an object of type Product
    abstract class FMProduct
    {
        public FMProduct()
        {
        }

        public abstract IFMProduct FactoryMethod(WebDriver driver, ReadConfig config, ReadTestDataConfig testConfig);

    }

    //implement the Abstract Creator class and override the factory method to return an instance of a Concrete Product
    class FMLogin : FMProduct
    {

        public FMLogin() {}

        public override IFMProduct FactoryMethod(WebDriver driver, ReadConfig config, ReadTestDataConfig testConfig)
        {
            return new FMDLogin(driver, config,testConfig);
        }
    }

    class FMItems : FMProduct
    {

        public FMItems(){}

        public override IFMProduct FactoryMethod(WebDriver driver, ReadConfig config, ReadTestDataConfig testConfig)
        {
            return new FMDItems(driver, config,testConfig);
        }
    }

    class FMPurchase : FMProduct
    {
        public FMPurchase(){}

        public override IFMProduct FactoryMethod(WebDriver driver, ReadConfig config, ReadTestDataConfig testConfig)
        {
            return new FMDPurchase(driver, config, testConfig);
        }
    }
}
