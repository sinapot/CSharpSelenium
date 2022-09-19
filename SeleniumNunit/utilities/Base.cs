using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace SeleniumNunitFramework.utilities
{
    public class Base
    {

        public ExtentReports extent;
        public IWebDriver driver;
        ExtentTest test;

        //initialize report file
        [OneTimeSetUp]
        public void Setup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Localhost");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("QA Engineer", "Edison Maningat");
           
        }


        //setup runs before each step
        [SetUp]
        public void StartBrowser()
        {

            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            //Webdriver Manager manages the version compatibility of chrome 

            //Configuration
            String browserName = ConfigurationManager.AppSettings["browser"];

            InitBrowser("Chrome");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.saucedemo.com/";
        }

        public IWebDriver getDriver()
        {
            return driver;
        }

        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {

                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;


                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;


                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;

            }
        }

        public static JsonReader getJsonParser()
        {
            return new JsonReader();
        }


        [TearDown]
        public void CloseBrowser()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            //log of the error
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;


            //screenshot Filename
            DateTime time = DateTime.Now;
            String fileName = "Screenshot" + time.ToString("h_mm_ss") + ".png";


            if(status == TestStatus.Failed)
            {
                //review if this does not work because Rahul's driver is driver.Vaue
                test.Fail("Test Failed!!", CaptureScreenshot(driver, fileName));

                //log when failed
                test.Log(Status.Fail,"test failed with logtrace"+stackTrace);
            }
            else if (status == TestStatus.Passed)
            {
                
            }

            extent.Flush();

            driver.Dispose();
        }

        public MediaEntityModelProvider CaptureScreenshot(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();

        }
    }
}
