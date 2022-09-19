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
    public class LoginUsingJson : Base //inherting from Base Class

    {

        [Test]
        //parameterized test using NUnit TestCaseSource tag
        [TestCaseSource(nameof(UserNames))]
        public void ParameterizedJSONLogin(string username, string password)
        {

            LoginPage loginPage = new LoginPage(getDriver());
            loginPage.getUsername().SendKeys(username);
            loginPage.getPassword().SendKeys(password);
            loginPage.getLoginButton().Click();

            string currentUrl = driver.Url;

            Assert.That(currentUrl.Equals("https://www.saucedemo.com/inventory.html"));
        }



        //Test Data Source from Hard Coded
        public static IEnumerable<TestCaseData> UserNames()
        {
            yield return new TestCaseData(getJsonParser().ExtractData("username1"), getJsonParser().ExtractData("password1"));
            yield return new TestCaseData(getJsonParser().ExtractData("username2"), getJsonParser().ExtractData("password2"));

        }
    }
}