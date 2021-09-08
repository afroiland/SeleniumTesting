using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace SeleniumTest2
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            //IWebDriver webDriver = new ChromeDriver();
            //webDriver.Navigate().GoToUrl("http://eaapp.somee.com/");
        }

        [Test]
        public void Test1()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("http://eaapp.somee.com/");

            webDriver.Manage().Window.Maximize();

            IWebElement lnkLogin = webDriver.FindElement(By.Id("loginLink"));
            lnkLogin.Click();

            var txtUserName = webDriver.FindElement(By.Name("UserName"));
            var txtPassword = webDriver.FindElement(By.Name("Password"));
            var loginButton = webDriver.FindElement(By.ClassName("btn-default"));

            Assert.That(txtUserName.Displayed, Is.True);
            Assert.That(txtPassword.Displayed, Is.True);
            Assert.That(loginButton.Displayed, Is.True);

            txtUserName.SendKeys("admin");
            txtPassword.SendKeys("password");
            //webDriver.FindElement(By.Id("RememberMe")).Click();
            //Thread.Sleep(5000);
            loginButton.Click();
        }
    }
}