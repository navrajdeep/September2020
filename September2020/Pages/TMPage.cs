using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace September2020.Pages
{
    class TMPage
    {
        public void CreateTM(IWebDriver driver)
        {
            // click create new button
            driver.FindElement(By.XPath("//*[@id='container']/p/a")).Click();
            Thread.Sleep(1000);

            // select time from the dropdown list
            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]")).Click();

            // input code
            driver.FindElement(By.Id("Code")).SendKeys("Sep2020");

            // input description 
            driver.FindElement(By.Id("Description")).SendKeys("September2020");

            // input price
            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Click();
            driver.FindElement(By.Id("Price")).SendKeys("123");

            // click save
            driver.FindElement(By.Id("SaveButton")).Click();
            Thread.Sleep(500);

            // validate if the time record got created successfully
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]")).Click();

            IWebElement expectedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (expectedCode.Text == "Sep2020")
            {
                Console.WriteLine("Time record created successfully, Test 1 passed");
            }
            else
            {
                Console.WriteLine("Unable to find the record created, Test Failed");
            }
        }

        public void EditTM(IWebDriver driver)
        {
            // To-do - code to edit TM test 
            // added a new comment line to test git
        }

        public void DeleteTM(IWebDriver driver)
        {
            // To-do - code to delte TM test 
        }
    }
}
