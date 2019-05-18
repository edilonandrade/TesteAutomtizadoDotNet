using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using System.Diagnostics;

namespace TesteAutomatizado.testes
{
    [TestFixture]
    class UsuarioSystemTest
    {
        private IWebDriver firefox;
        private UsuarioPage usuario;

        [SetUp]
        public void AntesDosTestes()
        {
            firefox = new FirefoxDriver();
            usuario = new UsuarioPage(firefox);

        }

        [Test]
        public void DeveCadastrarUsuario()
        {
            usuario.limpa();
            System.Threading.Thread.Sleep(3000);
            usuario.visita();
            usuario.novo().cadastra("Renan", "renan.saggio@gmail.com");
            System.Threading.Thread.Sleep(2000);
            bool existeNaPagina = usuario.existeNaListagem("Renan", "renan.saggio@gmail.com");
            Assert.IsTrue(existeNaPagina);

            usuario.Excluir(1);

            System.Threading.Thread.Sleep(2000);

            bool naoExisteMensagem = usuario.naoExisteMensagem("Renan", "renan.saggio@gmail.com");

            Assert.IsTrue(naoExisteMensagem);
        }

        [Test]
        public void DeveCadastrarUsuarioAdriano()
        {
            string strNome = "Adriano Xavier";
            string strEmail = "axavier@empresa.com.br";

            usuario.visita();
            usuario.novo().cadastra(strNome, strEmail);

            System.Threading.Thread.Sleep(2000);


            bool existeNaPagina = usuario.existeNaListagem(strNome, strEmail);
            Assert.IsTrue(existeNaPagina);
        }

        [Test]
        public void DeveExibirMensagemQuandoUsuarioNaoInformado()
        {
            usuario.visita();
            usuario.novo().cadastra(string.Empty, "vazio@provedor.com");

            System.Threading.Thread.Sleep(2000);

            bool mensagemNome = usuario.existeAMensagem("Nome obrigatorio!");

            Assert.IsTrue(mensagemNome);



        }

        [Test]
        public void DeveExibirMensagemQuandoUsuarioEEmailNaoInformado()
        {
            usuario.visita();
            usuario.novo().cadastra(string.Empty, string.Empty);

            System.Threading.Thread.Sleep(2000);

            bool mensagemNome = usuario.existeAMensagem("Nome obrigatorio!");
            bool mensagemEmail = usuario.existeAMensagem("E-mail obrigatorio!");

            Assert.IsTrue(mensagemNome);
            Assert.IsTrue(mensagemEmail);
        }

        [TearDown]
        public void FinalDosTestes()
        {
            //Fechar o drive
            firefox.Close();
        }

        [Test]
        public void DeveEditarUmUsuario()
        {
            usuario.visita();
            
            System.Threading.Thread.Sleep(1000);

            usuario.editar().edita("Rafael", "rafael@gmail.com");

            System.Threading.Thread.Sleep(2000);

            bool existeNaPagina = usuario.existeNaListagem("Rafael", "rafael@gmail.com");

            Assert.IsTrue(existeNaPagina);

        }
    }

}