using LearningSelenium.PageModel;
using OpenQA.Selenium;

namespace LearningSelenium.FactoryDesign.SimpleFactory
{
    public class FactoryClass
    {
        private WebDriver driver;

        public FactoryClass(WebDriver driver)
        {
            this.driver = driver;
        }

        public Login CreateLoginFactory()
        {
            return new Login(driver);
        }

        public Product CreateProductFactory()
        {
            return new Product(driver);
        }

        public Purchase CreatePurchaseFactory()
        {
            return new Purchase(driver);
        }

    }
}
