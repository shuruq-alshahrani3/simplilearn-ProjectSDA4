using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace ClassLibrary1
{
    [TestClass]
        public class Class1
        {
            private readonly IWebDriver _drive;
            public Class1()
            {
                _drive = new ChromeDriver();
            }
            [TestMethod]
            public void AddItem()
            {
                _drive.Manage().Window.Maximize();
                _drive.Navigate().GoToUrl("https://localhost:44381/");

            }
        }

    
}
