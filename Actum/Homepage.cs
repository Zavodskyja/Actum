using AngleSharp.Html.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actum
{
    public class Homepage
    {
        private IWebDriver Driver;
        
        string testUrl = "https://www.demoblaze.com";

        public Homepage(IWebDriver driver) 
        {
            Driver = driver;
            

        }

        

        public Homepage Open()
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(testUrl);
            String url = Driver.Url;
            StringAssert.Equals(url, testUrl);
            return this;
        }

        public SignUp SignUp()
        {
            this.Driver.FindElement(By.Id("signin2")).Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return new SignUp(Driver);
        }

        public Login Login()
        {
            this.Driver.FindElement(By.Id("login2")).Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return new Login(Driver);
        }

        public Cart SelectItem(string item)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(item)));
            this.Driver.FindElement(By.XPath(item)).Click();
            return new Cart(Driver);
        }




    }
}
