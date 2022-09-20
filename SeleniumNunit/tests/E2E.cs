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
        public void AddingProductInCart(string username, string password)
        {
            //Login
            LoginPage loginPage = new LoginPage(getDriver());
            loginPage.getUsername().SendKeys(username);
            loginPage.getPassword().SendKeys(password);
            loginPage.getLoginButton().Click();

            //explicit wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("title")));

            //add to cart
            driver.FindElement(By.PartialLinkText("Bike Light")).Click();
            driver.FindElement(By.CssSelector("#add-to-cart-sauce-labs-bike-light")).Click();
            driver.FindElement(By.CssSelector("#shopping_cart_container")).Click();
            //assert product is added
            String cartProduct = driver.FindElement(By.CssSelector(".inventory_item_name")).Text;
            Assert.That(cartProduct, Is.EqualTo("Sauce Labs Bike Light"));

            //click checkout
            driver.FindElement(By.CssSelector("#checkout")).Click();

            //fill form
            driver.FindElement(By.CssSelector("#first-name")).SendKeys("John");
            driver.FindElement(By.CssSelector("#last-name")).SendKeys("Smith");
            driver.FindElement(By.CssSelector("#postal-code")).SendKeys("555");

            //click Continue
            driver.FindElement(By.CssSelector("#continue")).Click();

            //assert Checkout:Overview
            String shippingInfo = driver.FindElement(By.CssSelector("div[class='summary_info'] div:nth-child(4)")).Text;
            Assert.That(shippingInfo, Is.EqualTo("FREE PONY EXPRESS DELIVERY!"));

            //click Finish
            driver.FindElement(By.CssSelector("#finish")).Click();

            //assert final URL is correct
            String completeUrl = driver.Url;
            Assert.That(completeUrl, Is.EqualTo("https://www.saucedemo.com/checkout-complete.html"));

        }

        //Test Data Source from JSON File
        public static IEnumerable<TestCaseData> UserNames()
        {
            yield return new TestCaseData(getJsonParser().ExtractData("username1"), getJsonParser().ExtractData("password1"));
            yield return new TestCaseData(getJsonParser().ExtractData("username2"), getJsonParser().ExtractData("password2"));

        }
    }
}

