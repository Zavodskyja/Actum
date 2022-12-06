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
    public class Login
    {

        private readonly IWebDriver Driver;
        public Login(IWebDriver driver)
        {
            Driver = driver;
        }


        public string LoginSuccesful(string login, string password)
        {
            Driver.FindElement(By.Id("loginusername")).SendKeys(login);
            Driver.FindElement(By.Id("loginpassword")).SendKeys(password);
            Driver.FindElement(By.XPath("//*[@id=\"logInModal\"]/div/div/div[3]/button[2]")).Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("nameofuser")));
            string loginUser = Driver.FindElement(By.Id("nameofuser")).Text;
            return loginUser;
        }

        public bool Logout(string login, string password)
        {
            LoginSuccesful(login, password);
            Driver.FindElement(By.Id("logout2")).Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login2")));
            bool logoutOK = true;
            return logoutOK;
        }
    }
}
