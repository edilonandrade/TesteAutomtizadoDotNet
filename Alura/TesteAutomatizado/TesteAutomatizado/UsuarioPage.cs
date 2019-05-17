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
            driver.Navigate().GoToUrl("http://localhost:8080/usuarios");
        }

        public NovoUsuarioPage novo()
        {
            driver.FindElement(By.LinkText("Novo Usuário")).Click();
            return new NovoUsuarioPage(driver);
        }

        public void Excluir()
        {
            int posicao = 1; //queremos o 1º botão
            driver.FindElements(By.TagName("button"))[posicao - 1].Click();

            //pega o alert que está aberto
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
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
