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
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = Driver.SwitchTo().Alert();
            return alert;
        }

        public string CheckCart()
        {
            return string.Empty; //TODO
        }

        public string PlaceOrder()
        {
            return string.Empty; //TODO
        }
    }
}
