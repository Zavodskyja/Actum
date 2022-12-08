using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actum
{
    internal class Categories
    {
        private readonly IWebDriver Driver;
        public Categories(IWebDriver driver)
        {
            Driver = driver;
        }

        public IAlert Default()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = Driver.SwitchTo().Alert();
            return alert;
        }

        public string SelectedCategory()
        {
            return string.Empty; //TODO
        }


    }
}
