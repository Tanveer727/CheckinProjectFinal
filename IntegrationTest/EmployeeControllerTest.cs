using Asp.netCoreMvcCrud.Controllers;
using Asp.netCoreMvcCrud.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace IntegrationTest
{
    [TestFixture]
    public class EmployeeControllerTest
    { 


        IWebDriver driver;
        string WebHostURL = Constants.Baseurl;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }
        [Test, Order(1)]
        public void CheckLoginPage()
        {
            try
            {

                driver.Navigate().GoToUrl(WebHostURL);
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(2);

                string currenturl = driver.Url.ToString().ToLower();

               

                 


                if (currenturl ==Constants.Emppage.ToLower())
                {
                    Assert.AreEqual(true, true);
                }

                else
                {
                    Assert.Fail("Employee Page Not found");
                }

            }
            catch (Exception ex)
            {

                Assert.Fail(ex.Message + ex.StackTrace);

            }

        }

       

        [OneTimeTearDown]
        public void DisposeClassObjects()
        {

            driver.Quit();
        }
    }

}

