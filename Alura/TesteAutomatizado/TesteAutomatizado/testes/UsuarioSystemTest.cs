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

        [SetUp]
        public void AntesDosTestes()
        {
            firefox = new FirefoxDriver();
            firefox.Navigate().GoToUrl("http://localhost:8080/usuarios");

            IWebElement linkNovoUsuario = firefox.FindElement(By.LinkText("Novo Usuário"));
            linkNovoUsuario.Click();

        }

        [Test]
        public void DeveCadastrarUsuario() {
            //Navegar para a url desejada
            //firefox.Navigate().GoToUrl("http://localhost:8080/usuarios/new");

            //procurar o elemento desejado, nesse caso o nome e o e-mail e o botão salva
            IWebElement campoNome = firefox.FindElement(By.Name("usuario.nome"));
            IWebElement campoEmail = firefox.FindElement(By.Name("usuario.email"));

            //Preencher os campos desejados
            campoNome.SendKeys("Renan");
            campoEmail.SendKeys("renan.saggio@caelum.com.br");

            ///Salvar as informações
            ///
            IWebElement btnSalvar = firefox.FindElement(By.Id("btnSalvar"));
            btnSalvar.Click();

            //Enviar o formulário
            //campoNome.Submit();

            //Declarar váriaveis boolenas para verificar se foi cadastrada
            bool achouNome = firefox.PageSource.Contains("Renan");
            bool achcouEmail = firefox.PageSource.Contains("renan.saggio@caelum.com.br");
            
            //Incluir TextFixture e Test como parametros

            //Fazer os asserts com o NUnit
            Assert.IsTrue(achouNome);
            Assert.IsTrue(achcouEmail);
        }

        [Test]
        public void DeveCadastrarUsuarioAdriano()
        {
           //Navegar para a url desejada
           // firefox.Navigate().GoToUrl("http://localhost:8080/usuarios/new");

            //procurar o elemento desejado, nesse caso o nome e o e-mail e o botão salva
            IWebElement campoNome = firefox.FindElement(By.Name("usuario.nome"));
            IWebElement campoEmail = firefox.FindElement(By.Name("usuario.email"));

            string strNome = "Adriano Xavier";
            string strEmail = "axavier@empresa.com.br";

            //Preencher os campos desejados
            campoNome.SendKeys(strNome);
            campoEmail.SendKeys(strEmail);

            ///Salvar as informações
            ///
            IWebElement btnSalvar = firefox.FindElement(By.Id("btnSalvar"));
            btnSalvar.Click();

            //Enviar o formulário
            //campoNome.Submit();

            //Declarar váriaveis boolenas para verificar se foi cadastrada
            bool achouNome = firefox.PageSource.Contains(strNome);
            bool achcouEmail = firefox.PageSource.Contains(strEmail);

            //Incluir TextFixture e Test como parametros

            //Fazer os asserts com o NUnit
            Assert.IsTrue(achouNome);
            Assert.IsTrue(achcouEmail);
        }

        [Test]
        public void DeveExibirMensagemQuandoUsuarioNaoInformado()
        {
            //Navegar para a url desejada
            firefox.Navigate().GoToUrl("http://localhost:8080/usuarios/new");
            
            ///Salvar as informações
            IWebElement btnSalvar = firefox.FindElement(By.Id("btnSalvar"));
            btnSalvar.Click();

            //Declarar váriaveis boolenas para verificar se foi cadastrada
            bool mensagemNome = firefox.PageSource.Contains("Nome obrigatorio!");
            
            //Incluir TextFixture e Test como parametros

            //Fazer os asserts com o NUnit
            Assert.IsTrue(mensagemNome);
            //Assert.IsTrue(achcouEmail);
        }

        [Test]
        public void DeveExibirMensagemQuandoUsuarioEEmailNaoInformado()
        {
           //Navegar para a url desejada
            //firefox.Navigate().GoToUrl("http://localhost:8080/usuarios/new");

            ///Salvar as informações
            IWebElement btnSalvar = firefox.FindElement(By.Id("btnSalvar"));
            btnSalvar.Click();

            //Declarar váriaveis boolenas para verificar se foi cadastrada
            bool mensagemNome = firefox.PageSource.Contains("Nome obrigatorio!");
            bool mensagemEmail = firefox.PageSource.Contains("E-mail obrigatorio!");

            //Incluir TextFixture e Test como parametros

            //Fazer os asserts com o NUnit
            Assert.IsTrue(mensagemNome);
            Assert.IsTrue(mensagemEmail);
        }

        [TearDown]
        public void FinalDosTestes()
        {
            //Fechar o drive
            firefox.Close();
        }
    }
}
