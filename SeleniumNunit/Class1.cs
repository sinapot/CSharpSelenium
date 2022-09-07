using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumNunit
{
    public class SeleniumFirst
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            //Webdriver Manager manages the version compatibility of chrome 

            //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            //driver = new ChromeDriver();

            //new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            //driver = new FirefoxDriver();

            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
        }

        [Test]
        public void Test1()
        {
            driver.Url = "https://www.saucedemo.com/";
            driver.Manage().Window.Maximize();

            String url = driver.Url;
            String pageTitle = driver.Title;
            TestContext.Progress.WriteLine(pageTitle);
            TestContext.Progress.WriteLine(url);

        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Dispose();
        }

    }
}
