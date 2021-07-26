using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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

            IWebElement lnkLogin = webDriver.FindElement(By.Id("loginLink"));
            lnkLogin.Click();

            var txtUserName = webDriver.FindElement(By.Name("UserName"));

            Assert.That(txtUserName.Displayed, Is.True);

            txtUserName.SendKeys("admin");
        }
    }
}