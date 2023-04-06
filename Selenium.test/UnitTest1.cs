using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class UntitledTestCase
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            driver = new ChromeDriver();
            baseURL = "https://www.google.com/";
        }

        [ClassCleanup]
        public static void CleanupClass()
        {
            try
            {
                //driver.Quit();// quit does not close the window
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        [TestInitialize]
        public void InitializeTest()
        {
            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void TheUntitledTestCaseTest()
        {
            driver.Navigate().GoToUrl("https://localhost:7073/");
            driver.FindElement(By.LinkText("Site teste")).Click();
            driver.FindElement(By.LinkText("Página Principal")).Click();
            driver.FindElement(By.LinkText("Página Secundária")).Click();
            driver.FindElement(By.Id("nome")).Click();
            driver.FindElement(By.Id("nome")).Clear();
            driver.FindElement(By.Id("nome")).SendKeys("João");
            driver.FindElement(By.Id("Sobrenome")).Clear();
            driver.FindElement(By.Id("Sobrenome")).SendKeys("Silva");
            driver.FindElement(By.Id("sexo")).Click();
            new SelectElement(driver.FindElement(By.Id("sexo"))).SelectByText("M");
            driver.FindElement(By.Id("sexo")).Click();
            new SelectElement(driver.FindElement(By.Id("sexo"))).SelectByText("F");
            driver.FindElement(By.Id("sexo")).Click();
            new SelectElement(driver.FindElement(By.Id("sexo"))).SelectByText("M");
            driver.FindElement(By.Id("Telefone")).Click();
            driver.FindElement(By.Id("Telefone")).Clear();
            driver.FindElement(By.Id("Telefone")).SendKeys("00000000");
            driver.FindElement(By.Id("CPF")).Click();
            driver.FindElement(By.Id("CPF")).Clear();
            driver.FindElement(By.Id("CPF")).SendKeys("00000000000");
            driver.FindElement(By.Id("CEP")).Click();
            driver.FindElement(By.Id("CEP")).Clear();
            driver.FindElement(By.Id("CEP")).SendKeys("00000000");
            driver.FindElement(By.Id("Endereco")).Click();
            driver.FindElement(By.Id("Endereco")).Clear();
            driver.FindElement(By.Id("Endereco")).SendKeys("Rua teste");
            driver.FindElement(By.Id("Cidade")).Clear();
            driver.FindElement(By.Id("Cidade")).SendKeys("Teste");
            driver.FindElement(By.Id("Cargo")).Clear();
            driver.FindElement(By.Id("Cargo")).SendKeys("Teste");
            driver.FindElement(By.Id("nomeMae")).Clear();
            driver.FindElement(By.Id("nomeMae")).SendKeys("Maria");
            driver.FindElement(By.Id("btnEnviar")).Click();
            driver.FindElement(By.LinkText("Página Principal")).Click();

            Assert.IsNotNull(driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[1]/a")));
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}