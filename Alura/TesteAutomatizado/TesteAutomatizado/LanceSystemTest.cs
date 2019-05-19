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

            UsuarioPage usuario = new UsuarioPage(driver);
            usuario.limpa();
            usuario.visita();

            usuario.novo().cadastra("Renan Saggio", "renan@caelum.com.br");
            System.Threading.Thread.Sleep(2000);
            usuario.novo().cadastra("Paulo Henrique", "paulo@caelum.com.br");
            System.Threading.Thread.Sleep(2000);
            leiloes.visita();
            leiloes.novo().preenche("Geladeira", 250, "Renan Saggio", true);
            System.Threading.Thread.Sleep(2000);
        }

        [Test]
        public void DeveDarLance()
        {
            leiloes.visita();

            DetalhesDoLeilaoPage lances = leiloes.detalhes(1);

            lances.lance("Paulo Henrique", 150);

            Assert.IsTrue(lances.existeLance("Paulo Henrique", 150));
        }
    }
}
