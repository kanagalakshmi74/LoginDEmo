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
        public By cart = By.XPath("//a[contains(@class,'shopping_cart_link')]");
        public By checkout = By.XPath("//button[contains(@id,'checkout')]");
        private By fName = By.XPath("//input[contains(@id,'first-name')]");
        private By lName = By.XPath("//input[contains(@id,'last-name')]");
        private By postal = By.XPath("//input[contains(@id,'postal-code')]");
        public By _continue = By.XPath("//input[contains(@id,'continue') and contains(@type,'submit')]");
        private By _price = By.XPath("//div[contains(@class,'summary_info_label') and contains(@class,'summary_total_label')]");
        
        public Purchase(WebDriver driver)
        {
            this.driver = driver;
        }
        
        public void EnterFirstName(string firstName)
        {
            driver.FindElement(fName).SendKeys(firstName);
        }
        
        public void EnterLastName(string lastName)
        {
            driver.FindElement(lName).SendKeys(lastName);
        }
        
        public void EnterPostal(string postalCode)
        {
            driver.FindElement(postal).SendKeys(postalCode);
        }
        
        public void ContinueButton()
        {
            driver.FindElement(_continue).Click();
        }
        
        public decimal GetPrice()
        {
            var errorElement = driver.FindElement(_price);
            decimal price = decimal.Parse(errorElement.Text.Substring(errorElement.Text.LastIndexOf('$') + 1));
            return price;
        }

    }
}

