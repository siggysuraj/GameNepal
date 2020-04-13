using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;
using OpenQA.Selenium.Support.UI;

namespace GameNepal.AutomatedUITests
{
    public class AutomatedUITests:IDisposable
    {
        private readonly IWebDriver _driver;


        public AutomatedUITests()
        {
            _driver = new ChromeDriver(Environment.CurrentDirectory);
        }

        

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void Signup_test()
        {
            _driver.Navigate().GoToUrl("http://localhost:49550/Home/Register");
            Assert.Equal("Register", _driver.Title);
            Assert.Contains("Game Nepal - your gaming companion", _driver.PageSource);

        }
        [Fact]
        public void Register_test()
        {

            _driver.Navigate().GoToUrl("http://localhost:49550/Home/Register");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            /*   wait.Until<IWebElement>((d) =>
               {
                   IWebElement element = d.FindElement(By.Id("FirstName"));
                   if (element.Selected)

                   {
                   element.SendKeys("suraj");
                   }

                   return null;
               }); */

            //   var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));


            IWebElement query = _driver.FindElement(By.Id("FirstName"));
            query  .SendKeys("TestFirst");

            // var element = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("FirstName"))
            //  .SendKeys("TestFirst");
            query = _driver.FindElement(By.Id("LastName"));
             query  .SendKeys("TestName1111");

            _driver.FindElement(By.Id("Email"))
               .SendKeys("test113@abc.com");
            _driver.FindElement(By.Id("Phone"))
               .SendKeys("0912345125");
            _driver.FindElement(By.XPath("//*[@type='radio'][1]")).Click();
            _driver.FindElement(By.Id("City"))
               .SendKeys("TestCity");
            _driver.FindElement(By.XPath("//*[@id='AgeGroup']/option[2]")).Click();

            _driver.FindElement(By.Id("pwdReEntered"))
               .SendKeys("Test1234@");
            _driver.FindElement(By.Id("pwdReEntered"))
               .SendKeys("Test1234@");
            _driver.FindElement(By.Id("btnSend"))
                .Click();
            var wait1 = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            Assert.Equal("Home", _driver.Title);
        }
    }
}
