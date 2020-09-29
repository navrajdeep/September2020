using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using September2020.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace September2020.Pages
{
    class CompanyPage
    {
        public void CreateCompany(IWebDriver driver)
        {
            // To-do - create company test
            // Click on Create New
            driver.FindElement(By.XPath("//*[@id='container']/p/a")).Click();

            //Wait for element to appear
            Wait.WaitForElementVisiblity(driver, "id", "Name", 5);

            //Enter Name
            driver.FindElement(By.Id("Name")).SendKeys("BB Airlines");

            //Click on Edit Contact
            driver.FindElement(By.Id("EditContactButton")).Click();

            //Wait for element to appear
            Wait.WaitForElementVisiblity(driver, "XPath", "//iframe[@class='k-content-frame']", 5);

            //switch to iframe
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@class='k-content-frame']")));

            //Enter name
            driver.FindElement(By.Id("FirstName")).SendKeys("Barak");

            //Enter Last Name
            driver.FindElement(By.Id("LastName")).SendKeys("Obama");

            //Enter PreferedName
            driver.FindElement(By.Id("PreferedName")).SendKeys("President");

            //Enter Phone Number
            driver.FindElement(By.Id("Phone")).SendKeys("0987654321");

            //Enter Mobile
            driver.FindElement(By.Id("Mobile")).SendKeys("0123456789");

            //Enter email
            driver.FindElement(By.Id("email")).SendKeys("bb@president.com");

            //Click on Save Contact
            driver.FindElement(By.Id("submitButton")).Click();

            //Wait for element to appear
            Wait.WaitForElementVisiblity(driver, "id", "SaveButton", 5);

            // Switch Back to parent Window
            driver.SwitchTo().DefaultContent();
            //Click on Save Company Button
            driver.FindElement(By.Id("SaveButton")).Click();

            //Wait for element to appear
            Wait.WaitForElementVisiblity(driver, "XPath", "//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]", 5);

            IWebElement expectedCompany = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            
            Assert.That(expectedCompany.Text, Is.EqualTo("BB Airlines"));

        }

        public void EditCompany(IWebDriver driver)
        {
            //Wait
            //Wait for element to appear
            Wait.WaitForElementVisiblity(driver, "XPath", "//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[1]", 5);

            // To-do - edit company test
            driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[1]")).Click();

            IWebElement expectedCom = driver.FindElement(By.XPath("//*[@id='container']/h2"));
            Assert.That(expectedCom.Text, Is.EqualTo("Company"));

            //Click on Back to List
            driver.FindElement(By.XPath("//*[@id='container']/div/a")).Click();
        }

        public void DeleteCompany(IWebDriver driver)
        {
            //Wait for element to appear
            Wait.WaitForElementVisiblity(driver, "XPath", "//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[2]", 5);

            // To-do - delete company test
            driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[2]")).Click();

            //Accept Alert
            driver.SwitchTo().Alert().Accept();

            driver.Navigate().Refresh();

            Wait.WaitForElementVisiblity(driver, "XPath", "//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]", 5);


            IWebElement expectedCompName = driver.FindElement(By.XPath("//*[@id='companiesGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            

            Assert.That(expectedCompName.Text, Is.Not.EqualTo("BB Airlines"));
        }
    }
}
