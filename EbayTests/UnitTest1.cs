using System;
using WindowsFormsApp1;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject1
{
    [TestFixture]
    public class UITests
    {
        private IWebDriver driver;

        [SetUp] // jaizpilda,pirms katra testa
        public void Setup()
        {
            var options = new ChromeOptions();
            driver = new ChromeDriver(@"C:\Users\marek\source\repos\lasdan220\Eksamens_2024_Punculis_PB_It_Ne_2\packages\Selenium.WebDriver.ChromeDriver.125.0.6422.14100\driver\win32", options); // inicialize chrome draiveri
            driver.Navigate().GoToUrl("https://www.ebay.com"); // atver ebay majaslapu
        }

        [Test] // NUnit testa metode
        public void Test1_field()
        {
            var searchField = driver.FindElement(By.Id("gh-ac")); // mekle elementu pec id
            if (searchField != null)
            {
                Console.WriteLine("Elements ar ID 'gh-ac' ir atrasts."); // ja ir atrasts pazino konsole
            }
        }

        [Test]
        public void Test2_search()
        {
            var searchButton = driver.FindElement(By.Id("gh-btn")); // mekle elementu pec id
            if (searchButton != null)
            {
                Console.WriteLine("Elements ar ID 'gh-btn' ir atrasts."); // ja ir atrasts pazino konsole
            }
        }

        [TearDown] // jaizpilda pec katra testa
        public void Teardown()
        {
            driver.Quit(); // aizver chrome
        }
    }
}
