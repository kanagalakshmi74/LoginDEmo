using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSelenium.PageModel
{
    public class Purchase
    {
        WebDriver driver;
        public By Cart = By.XPath("//a[contains(@class,'shopping_cart_link')]");
        public By Checkout = By.XPath("//button[contains(@id,'checkout')]");
        protected By FName = By.XPath("//input[contains(@id,'first-name')]");
        protected By LName = By.XPath("//input[contains(@id,'last-name')]");
        protected By Postal = By.XPath("//input[contains(@id,'postal-code')]");
        public By Continue = By.XPath("//input[contains(@id,'continue') and contains(@type,'submit')]");
        protected By Price = By.XPath("//div[contains(@class,'summary_info_label') and contains(@class,'summary_total_label')]");
        public Purchase(WebDriver driver)
        {
            this.driver = driver;
        }
        public void enterFirstName(string firstName)
        {
            driver.FindElement(FName).SendKeys(firstName);
        }
        public void enterLastName(string lastName)
        {
            driver.FindElement(LName).SendKeys(lastName);
        }
        public void enterPostal(string postalCode)
        {
            driver.FindElement(Postal).SendKeys(postalCode);
        }
        public void ContinueButton()
        {
            driver.FindElement(Continue).Click();
        }
        public decimal getPrice()
        {
            decimal price =0;
            var errorElement = driver.FindElement(Price);
            price = decimal.Parse(errorElement.Text.Substring(errorElement.Text.LastIndexOf('$') + 1));
            return price;
        }

    }
}
