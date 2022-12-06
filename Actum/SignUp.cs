using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V106.Page;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.Services.Impl;
using static System.Net.Mime.MediaTypeNames;

namespace Actum
{
    public class SignUp
    {

        private readonly IWebDriver Driver;
        public SignUp(IWebDriver driver)
        {
            Driver = driver;
        }



        public IAlert SignUpSuccesfull(string login, string password)
        {
            Driver.FindElement(By.Id("sign-username")).SendKeys(login);
            Driver.FindElement(By.Id("sign-password")).SendKeys(password);
            Driver.FindElement(By.XPath("//*[@id=\"signInModal\"]/div/div/div[3]/button[2]")).Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = Driver.SwitchTo().Alert();
            return alert;
        }
        
        public IAlert SignUpExists(string login, string password)
        {
            var alert = SignUpSuccesfull(login, password);
            return alert;
        }

       
    }
}
