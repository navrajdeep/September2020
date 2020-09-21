using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using September2020.Pages;
using System;
using System.Threading;

namespace September2020
{
    [TestFixture]
    class Program
    {
        // init driver
        IWebDriver driver;

        [SetUp]
        public void LoginToTurnUp()
        {
            // define webdriver
            driver = new ChromeDriver();

            // Object init and define for login page
            LoginPage loginObj = new LoginPage();
            loginObj.LoginSteps(driver);
        }

        [Test]
        public void CreateNewTMTest()
        {
            // Object init and define for home page
            HomePage homeObj = new HomePage();
            homeObj.NavigateToTM(driver);

            // Test 1 - Check if the user is able to create time successfully

            // Object init and define for TM page
            TMPage tmObj = new TMPage();
            tmObj.CreateTM(driver);
        }

        [Test]
        public void EditTMTest()
        {
            // Object init and define for home page
            HomePage homeObj = new HomePage();
            homeObj.NavigateToTM(driver);

            // Test 2 - Check if the user is able to edit time successfully

            // Object init and define for TM page
            TMPage tmObj = new TMPage();
            tmObj.EditTM(driver);
        }

        [Test]
        public void DeleteTMTest()
        {
            // Object init and define for home page
            HomePage homeObj = new HomePage();
            homeObj.NavigateToTM(driver);

            // Test 3 - Check if the user is able to delete time successfully

            // Object init and define for TM page
            TMPage tmObj = new TMPage();
            tmObj.DeleteTM(driver);
        }

        [TearDown]
        public void TestClosure()
        {
            // close instances of open chrome driver 
            driver.Quit();
        }

    }


}
