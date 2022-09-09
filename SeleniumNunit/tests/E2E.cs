using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
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
    public class Login : Base //inherting from Base Class

    {

        [Test]
        //parameterized test attribute
        [TestCase("standard_user", "secret_sauce")]
        [TestCase("performance_glitch_user", "secret_sauce")]
        public void ParameterizedLogin1(string username, string password)
        {
  
            LoginPage loginPage = new LoginPage(getDriver());
            loginPage.getUsername().SendKeys(username);
            loginPage.getPassword().SendKeys(password);
            loginPage.getLoginButton().Click();

            string currentUrl = driver.Url;

            Assert.That(currentUrl.Equals("https://www.saucedemo.com/inventory.html"));
        }

        [Test]
        //parameterized test attribute
        [TestCaseSource(nameof(UserNames))]
        public void ParameterizedLogin2(string username, string password)
        {

            LoginPage loginPage = new LoginPage(getDriver());
            loginPage.getUsername().SendKeys(username);
            loginPage.getPassword().SendKeys(password);
            loginPage.getLoginButton().Click();

            string currentUrl = driver.Url;

            Assert.That(currentUrl.Equals("https://www.saucedemo.com/inventory.html"));
        }

        public static IEnumerable<TestCaseData> UserNames()
        {
            yield return new TestCaseData("standard_user", "secret_sauce");
            yield return new TestCaseData("performance_glitch_user", "secret_sauce");

        }
    }
}
