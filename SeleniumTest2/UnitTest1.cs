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
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            //driver.Navigate().GoToUrl("http://localhost:3000/");

            driver.Manage().Window.Maximize();

            IWebElement lnkLogin = driver.FindElement(By.Id("loginLink"));
            lnkLogin.Click();

            var txtUserName = driver.FindElement(By.Id("UserName"));
            var txtPassword = driver.FindElement(By.Name("Password"));
            var loginButton = driver.FindElement(By.ClassName("btn-default"));
            var newUserLink = driver.FindElement(By.LinkText("Register as a new user"));
            var hostingLink = driver.FindElement(By.PartialLinkText("hosting by"));
            var rememberBox = driver.FindElement(By.XPath("//input[@name='RememberMe']"));

            Assert.That(txtUserName.Displayed, Is.True);
            Assert.That(txtPassword.Displayed, Is.True);
            Assert.That(loginButton.Displayed, Is.True);
            Assert.That(newUserLink.Displayed, Is.True);
            Assert.That(hostingLink.Displayed, Is.True);
            Assert.That(rememberBox.Displayed, Is.True);

            txtUserName.SendKeys("admin");
            txtPassword.SendKeys("password");
            rememberBox.Click();
            Thread.Sleep(1000);
            rememberBox.Click();
            Thread.Sleep(3000);
            loginButton.Click();
        }
    }
}