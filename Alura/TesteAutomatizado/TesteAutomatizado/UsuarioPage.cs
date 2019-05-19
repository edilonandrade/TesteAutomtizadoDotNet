using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TesteAutomatizado
{
    public class UsuarioPage
    {
        private IWebDriver driver;

        public UsuarioPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void visita()
        {
            driver.Navigate().GoToUrl(new URLDaAplicacao().GetUrlBase() + "/usuarios");
        }

        public void limpa()
        {
            driver.Navigate().GoToUrl(new URLDaAplicacao().GetUrlBase() + "/apenas-teste/limpa");
        }

        public NovoUsuarioPage novo()
        {
            driver.FindElement(By.LinkText("Novo Usuário")).Click();
            return new NovoUsuarioPage(driver);
        }

        public EidtarUsuarioPage editar()
        {
            driver.FindElement(By.LinkText("editar")).Click();
            return new EidtarUsuarioPage(driver);
        }

        public void Excluir(int posicao)
        {
           
            driver.FindElements(By.TagName("button"))[posicao - 1].Click();

            //pega o alert que está aberto
           
            System.Threading.Thread.Sleep(1000);
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

        public void ExcluirUsuarios()
        {
            while (driver.PageSource.Contains("excluir"))
            {
                Excluir(1);
                System.Threading.Thread.Sleep(2000);
            }
        }

        public bool existeNaListagem(string nome, string email)
        {
            return driver.PageSource.Contains(nome) &&
                driver.PageSource.Contains(email);
        }

        public bool existeAMensagem(string mensagem)
        {
            return driver.PageSource.Contains(mensagem);
        }

        public bool naoExisteMensagem(string nome, string email)
        {
            return !driver.PageSource.Contains(nome) &&
               !driver.PageSource.Contains(email);
        }


    }
}
