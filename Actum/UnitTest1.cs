using AngleSharp.Dom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;


namespace Actum
{
    [TestClass]
    [TestCategory("HomePage")]
    public class UnitTest1
    {
        private IWebDriver Driver;


        //
        string login = Utility.login;
        string password = Utility.password;

        // Xpath pro vybrany item k nakupu
        string cartItem = "/html/body/div[5]/div/div[2]/div/div[1]/div/div/h4";



        [TestInitialize]
        public void Setup()
        {
            Driver = new ChromeDriver();
        }

   



        [TestMethod]
        //Homepage opens test
        public void Test1()
        {
            var test = new Homepage(Driver).Open();

        }
        
        [TestMethod]
        //SignUp OK test
        public void Test2()
        {
            var signUpP = new Homepage(Driver).Open().SignUp().SignUpSuccesfull(login,password);
            Assert.AreEqual(signUpP.Text.ToString(), "Sign up successful."); 


        }
        
        [TestMethod]
        //User Exists test
        public void Test3()
        {
            var signUpN = new Homepage(Driver).Open().SignUp().SignUpExists(login, password); //pustit po positive / doplnit login co existuje napr. z DB apod.
            Assert.AreEqual(signUpN.Text, "This user already exist."); 
            
        }

        [TestMethod]
       //Login test
        public void Test4()
        {
            var loginP = new Homepage(Driver).Open().Login().LoginSuccesful(login, password); //doplnit existujici user select napr.
            Assert.AreEqual(loginP, "Welcome" +" "+ login);

        }

        [TestMethod]
        //Login logout test
        public void Test5()
        {
            var logout = new Homepage(Driver).Open().Login().Logout(login,password); 
            Assert.IsTrue(logout);
        }

        [TestMethod]
        //Add to cart
        public void Test6()
        {
            var addToCart = new Homepage(Driver).Open().SelectItem(cartItem).AddToCart(); 
            Assert.AreEqual(addToCart.Text, "Product added");
        }

        [TestMethod]
        //Clear Cart
        public void Test7()
        {
            var clearCart = new Homepage(Driver).Open().SelectItem(cartItem).ClearCart(); 
            Assert.IsTrue(clearCart);
        }

        [TestMethod]
        //Place Order
        public void Test8()
        {
            var order = new Homepage(Driver).Open().SelectItem(cartItem).PlaceOrder();
            Assert.AreEqual(order, "Thank you for your purchase!");
        }




        [TestCleanup]
        public void CloseBrowser()
        {
            Driver.Quit();
        }
        

       












    }
}