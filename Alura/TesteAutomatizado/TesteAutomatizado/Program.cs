using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace TesteAutomatizado
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            //IWebDriver driverC = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com.br/");

            IWebElement campotexto = driver.FindElement(By.Name("q"));
            campotexto.SendKeys("Caelum");

            campotexto.Submit();

            driver.Close();
        }
    }
}
