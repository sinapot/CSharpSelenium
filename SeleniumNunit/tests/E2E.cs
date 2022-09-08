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
    public class E2E : Base //inherting from Base Class

    {

        [Test]
        public void Login()
        {
            //driver.Url = "https://www.saucedemo.com/";
            //driver.Manage().Window.Maximize();

            //driver.FindElement(By.Id("user-name")).SendKeys("standard_user");

            LoginPage loginPage = new LoginPage(getDriver());
            loginPage.getUsername().SendKeys("standard_user");

            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();

            string currentUrl = driver.Url;

            Assert.That(currentUrl.Equals("https://www.saucedemo.com/inventory.html"));
        }


    }
}
