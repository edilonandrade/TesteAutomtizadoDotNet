using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TesteAutomatizado
{
    public class CriadorDeCenarios
    {
        private IWebDriver driver;
        
        public CriadorDeCenarios(IWebDriver driver)
        {
            this.driver = driver;
        }

        public CriadorDeCenarios umUsuario(string nome, string email)
        {
            UsuarioPage usuario = new UsuarioPage(driver);

            usuario.visita();
            usuario.novo().cadastra(nome, email);
            System.Threading.Thread.Sleep(2000);
            return this;
        }

        public CriadorDeCenarios umLeilao(string usuario, string produto,
                                  double valor, bool usado)
        {
            LeiloesPage leiloes = new LeiloesPage(driver);
            leiloes.visita();
            leiloes.novo().preenche(produto, valor, usuario, usado);
            System.Threading.Thread.Sleep(2000);
            return this;
        }
    }
}
