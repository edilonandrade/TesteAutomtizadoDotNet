using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace TesteAutomatizado
{
    public class DetalhesDoLeilaoPage
    {
        private IWebDriver driver;

        public DetalhesDoLeilaoPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void lance(string usuario, double lance)
        {
            IWebElement txtlance = driver.FindElement(By.Name("lance.valor"));
            SelectElement cbUsuario = new SelectElement(driver.FindElement(By.Name("lance.usuario.id")));

            txtlance.SendKeys(Convert.ToString(lance));
            cbUsuario.SelectByText(usuario);

            driver.FindElement(By.Id("btnDarLance")).Click();

        }

        public bool existeLance(string usuario, double valor)
        {
            bool existe = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElement(By.Id("lancesDados")).Text.Contains(usuario));
            if (existe)
            {
                return driver.PageSource.Contains(usuario) &&
                    driver.PageSource.Contains(Convert.ToString(valor));
            }

            return false;
        }

        
    }
}
