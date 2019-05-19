using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TesteAutomatizado
{
    [TestFixture]
    class LanceSystemTest
    {
        private FirefoxDriver driver;
        private LeiloesPage leiloes;

        [SetUp]
        public void inicializa()
        {
            driver = new FirefoxDriver();
            leiloes = new LeiloesPage(driver);

            driver.Navigate().GoToUrl(new URLDaAplicacao().GetUrlBase() + "/apenas-teste/limpa");

            new CriadorDeCenarios(driver)
                 .umUsuario("Paulo Henrique", "paulo@henrique.com")
                 .umUsuario("José Alberto", "jose@alberto.com")
                 .umLeilao("Paulo Henrique", "Geladeira", 100, false);
        }

        [Test]
        public void DeveDarLance()
        {
           DetalhesDoLeilaoPage lances = leiloes.detalhes(1);

            lances.lance("Paulo Henrique", 150);

            Assert.IsTrue(lances.existeLance("Paulo Henrique", 150));
        }

        [TearDown]
        public void finaliza()
        {
            driver.Close();
        }
    }
}
