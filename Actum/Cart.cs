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
        


        string cartButton = "/html/body/nav/div/div/ul/li[4]/a";
        string addToCartButton = "//*[@id=\"tbodyid\"]/div[2]/div/a";
        string clearCartButton = "/html/body/div[6]/div/div[1]/div/table/tbody/tr/td[4]/a";
        string orderButton = "/html/body/div[6]/div/div[2]/button";
        string purchaseButton = "/html/body/div[3]/div/div/div[3]/button[2]";


        public Cart(IWebDriver driver)
        {
            Driver = driver;
        }





        public IAlert AddToCart()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(addToCartButton)));
            Driver.FindElement(By.XPath(addToCartButton)).Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            IAlert alert = Driver.SwitchTo().Alert();
            return alert;
        }



        public bool ClearCart()
        {
            AddItem();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            this.Driver.FindElement(By.XPath(cartButton)).Click();
            wait.Until(ExpectedConditions.ElementExists(By.XPath(clearCartButton)));
            Driver.FindElement(By.XPath(clearCartButton)).Click();
            bool exists = Driver.FindElements(By.ClassName("success")).Count > 0;
            return exists;
        }

        public string PlaceOrder() //Predelat vcetne clear cart
        {

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(addToCartButton)));
            Driver.FindElement(By.XPath(addToCartButton)).Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            Driver.SwitchTo().Alert().Accept();
            this.Driver.FindElement(By.XPath(cartButton)).Click();
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("success")));
            Driver.FindElement(By.XPath(orderButton)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[3]/div/div/div[2]/form")));
            Driver.FindElement(By.Id("name")).SendKeys("TestName");
            Driver.FindElement(By.Id("country")).SendKeys("TestCountry");
            Driver.FindElement(By.Id("card")).SendKeys("45645645645");
            Driver.FindElement(By.Id("month")).SendKeys("January");
            Driver.FindElement(By.Id("year")).SendKeys("2022");
            Driver.FindElement(By.XPath(purchaseButton)).Click();
            var popUp = Driver.SwitchTo().ActiveElement().FindElement(By.XPath("/html/body/div[10]/h2")).Text;
            return popUp; 
        }

        public void AddItem()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(addToCartButton)));
            Driver.FindElement(By.XPath(addToCartButton)).Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
            //Driver.SwitchTo().Alert().Accept();
        }
    }
}
