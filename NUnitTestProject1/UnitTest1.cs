using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using Assert = NUnit.Framework.Assert;

namespace NUnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
            private readonly IWebDriver _driver;
            public UnitTest1()
            {
                _driver = new ChromeDriver();
            }
            [SetUp]
            public void Setup()
            {
            }

            [Test]
            public void Test1()
            {
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl("https://localhost:44381/");
                //  Assert.Equals("Index", _driver.Title);
                //_driver.FindElement(By.XPath(@"/html/body/div[1]/div[2]/div[2]/div[2]/form/div[1]/div[1]/div[1]/div[1]/div/input")).SendKeys("test");
                // HttpClient http=
                Assert.Pass();

            }
        
    }
}
