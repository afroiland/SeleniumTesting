using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using System;
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

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();

            IWebElement lnkLogin = driver.FindElement(By.Id("loginLink"));
            lnkLogin.Click();

            var txtUserName = driver.FindElement(By.Id("UserName"));
            var txtPassword = driver.FindElement(By.Name("Password"));
            var loginButton = driver.FindElement(By.ClassName("btn-default"));
            var newUserLink = driver.FindElement(By.LinkText("Register as a new user"));
            var hostingLink = driver.FindElement(By.PartialLinkText("hosting by"));
            var rememberBox = driver.FindElement(By.XPath("//input[@name='RememberMe']"));
            var chkboxByCSS = driver.FindElement(By.CssSelector("#RememberMe"));
            var loginByCSS1 = driver.FindElement(By.CssSelector(".btn.btn-default"));
            var loginByCSS2 = driver.FindElement(By.CssSelector("input[class*='efault']"));

            Assert.That(txtUserName.Displayed, Is.True);
            Assert.That(txtPassword.Displayed, Is.True);
            Assert.That(loginButton.Displayed, Is.True);
            Assert.That(newUserLink.Displayed, Is.True);
            Assert.That(hostingLink.Displayed, Is.True);
            Assert.That(rememberBox.Displayed, Is.True);
            Assert.That(chkboxByCSS.Displayed, Is.True);
            Assert.That(loginByCSS1.Displayed, Is.True);
            Assert.That(loginByCSS2.Displayed, Is.True);

            txtUserName.SendKeys("admin");
            //txtPassword.SendKeys("password");
            TimeSpan tspan = new TimeSpan(0, 0, 10);
            SendKeysWithWait((ChromeDriver)driver, "Password", tspan, "password");
            Thread.Sleep(1000);
            rememberBox.Click();
            Thread.Sleep(1000);
            rememberBox.Click();
            Thread.Sleep(1000);
            loginByCSS1.Click();
            Thread.Sleep(1000);
            driver.Close();
        }

        [Test]
        public void Test2()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://testpages.herokuapp.com/styled/alerts/alert-test.html");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Id("alertexamples")).Click();
            String alertMessage = driver.SwitchTo().Alert().Text;
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();

            driver.FindElement(By.Id("confirmexample")).Click();
            String confirmMessage = driver.SwitchTo().Alert().Text;
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();

            driver.FindElement(By.Id("promptexample")).Click();
            String promptMessage = driver.SwitchTo().Alert().Text;
            Thread.Sleep(1000);
            var promptBox = driver.SwitchTo().Alert();
            promptBox.SendKeys("sendKeys test");
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
            driver.Close();

            Assert.AreEqual(alertMessage, "I am an alert box!");
            Assert.AreEqual(confirmMessage, "I am a confirm alert");
            Assert.AreEqual(promptMessage, "I prompt you");
        }

        [Test]
        public void Test3()
        {
            IWebDriver driver = new ChromeDriver();
            EventFiringWebDriver eventFiringWebDriver = new EventFiringWebDriver(driver);

            eventFiringWebDriver.Navigate().GoToUrl("https://testpages.herokuapp.com/styled/alerts/alert-test.html");
            eventFiringWebDriver.Manage().Window.Maximize();

            eventFiringWebDriver.ElementClicking += EventFiringWebDriver_ElementClicking;
            eventFiringWebDriver.ElementClicked += EventFiringWebDriver_ElementClicked;

            eventFiringWebDriver.FindElement(By.Id("alertexamples")).Click();
            eventFiringWebDriver.SwitchTo().Alert().Accept();
            eventFiringWebDriver.Close();
        }

        private void EventFiringWebDriver_ElementClicking(object sender, WebElementEventArgs e)
        {
            Console.WriteLine("Element clicking");
            Console.WriteLine($"e.Element.Location: {e.Element.Location}");
        }

        private void EventFiringWebDriver_ElementClicked(object sender, WebElementEventArgs e)
        {
            Console.WriteLine("Element clicked");
        }

        public static void SendKeysWithWait(ChromeDriver driver, string id, TimeSpan timeout, string value)
        {
            new WebDriverWait(driver, timeout).Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(By.Id(id));
                    return elementToBeDisplayed.Displayed;
                    //or we can use SeleniumExtras.WaitHelpers
                    //return SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(elementToBeDisplayed);
                }
                catch (Exception)
                {
                    return false;
                }
            });
            driver.FindElement(By.Id(id)).SendKeys(value);
        }
    }
}
