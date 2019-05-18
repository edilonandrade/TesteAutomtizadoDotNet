using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace TesteAutomatizado
{
    public class LeiloesSystemTest
    {
        private LeiloesPage leiloes;
        private FirefoxDriver driver;

        [SetUp]
        public void inicializa()
        {
            driver = new FirefoxDriver();
            leiloes = new LeiloesPage(driver);

            UsuarioPage usuarios = new UsuarioPage(driver);
            usuarios.visita();

           
        }

        [Test]
        public void deveCadastrarUmLeilao()
        {
            leiloes.visita();
            NovoLeilaoPage novoLeilao = leiloes.novo();
            novoLeilao.preenche("Geladeira", 123, "Paulo Henrique", true);
        }
    }
}
