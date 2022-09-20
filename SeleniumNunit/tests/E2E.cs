using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumNunitFramework.pages;
using SeleniumNunitFramework.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumNunitFramework.tests
{
    public class e2e : Base //inherting from Base Class

    {

        [Test]
        //parameterized test using NUnit TestCaseSource tag
        [TestCaseSource(nameof(UserNames))]
        public void ParameterizedJSONLogin(string username, string password)
        {
            //Login
            LoginPage loginPage = new LoginPage(getDriver());
            loginPage.getUsername().SendKeys(username);
            loginPage.getPassword().SendKeys(password);
            loginPage.getLoginButton().Click();

            //explicit wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("title")));

            driver.FindElement(By.PartialLinkText("Bike Light")).Click();
            driver.FindElement(By.CssSelector("#add-to-cart-sauce-labs-bike-light")).Click();
            driver.FindElement(By.CssSelector("#shopping_cart_container")).Click();

            String cartProduct = driver.FindElement(By.CssSelector(".inventory_item_name")).Text;

            Assert.That(cartProduct, Is.EqualTo("Sauce Labs Bike Light"));

        }

        //Test Data Source from JSON File
        public static IEnumerable<TestCaseData> UserNames()
        {
            yield return new TestCaseData(getJsonParser().ExtractData("username1"), getJsonParser().ExtractData("password1"));
            yield return new TestCaseData(getJsonParser().ExtractData("username2"), getJsonParser().ExtractData("password2"));

        }
    }
}

