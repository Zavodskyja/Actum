using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V106.Page;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
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

        // Page elements
        [FindsBy(How = How.Id, Using = "sign-username")]
        private IWebElement signBox;

        [FindsBy(How = How.Id, Using = "sign-password")]
        private IWebElement passwordBox;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"signInModal\"]/div/div/div[3]/button[2]")]
        private IWebElement signButton;


        //webdriver
        public SignUp(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);

        }




        //methods


        public IAlert SignUpSuccesfull(string login, string password)
        {
            signBox.SendKeys(login);
            passwordBox.SendKeys(password);
            signButton.Click();
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
