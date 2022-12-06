using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actum
{
    public class Cart
    {

        private readonly IWebDriver Driver;
        public Cart(IWebDriver driver)
        {
            Driver = driver;
        }

        public IAlert AddToCart()
        {
            string addToCartButton = "//*[@id=\"tbodyid\"]/div[2]/div/a";
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(addToCartButton)));
            Driver.FindElement(By.XPath(addToCartButton)).Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = Driver.SwitchTo().Alert();
            return alert;
        }

        public bool ClearCart()
        {
            AddToCart();
            string clearCartButton = "/html/body/div[6]/div/div[1]/div/table/tbody/tr/td[4]/a";
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(clearCartButton)));
            Driver.FindElement(By.XPath(clearCartButton)).Click();
            bool exists = Driver.FindElements(By.ClassName("success")).Count == 0;
            return exists;


        }

        public string PlaceOrder()
        {
            return string.Empty; //TODO
        }
    }
}
