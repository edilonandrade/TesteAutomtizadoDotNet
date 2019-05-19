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

            usuarios.novo().cadastra("Paulo Henrique", "paulo@caelum.com.br");

            System.Threading.Thread.Sleep(5000);
        }

        [Test]
        public void deveCadastrarUmLeilao()
        {
            leiloes.visita();
            NovoLeilaoPage novoLeilao = leiloes.novo();
            novoLeilao.preenche("Geladeira", 123, "Paulo Henrique", true);

            System.Threading.Thread.Sleep(3000);

            Assert.IsTrue(leiloes.existe("Geladeira", 123, "Paulo Henrique", true));
        }

        [Test]
        public void leilaoDeveExibirMensagemValidacaoSeNaoInformarNomeEValor()
        {
            leiloes.visita();
            NovoLeilaoPage novoLeilao = leiloes.novo();
            novoLeilao.preenche(string.Empty, 0, "Paulo Henrique", true);
            System.Threading.Thread.Sleep(1500);
            Assert.IsTrue(leiloes.existeMensagem("Nome obrigatorio!") &&
                leiloes.existeMensagem("Valor inicial deve ser maior que zero!"));
        }

        
    }
}
