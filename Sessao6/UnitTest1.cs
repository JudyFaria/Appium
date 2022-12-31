using OpenQA.Selenium.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace MSTestOverview               /* DATA DRIVEN TESTING IN MsTest */
                                     /* TESTE ORIENTADO A DADOS NO MsTest */
{
    [TestClass]
    public class AlarmsAndClockSmokeTests  
    {
        static WindowsDriver<WindowsElement> sessionAlarms;
        private static TestContext objTestContext;

        [ClassInitialize]
        public static void PrepareForTestingAlarms(TestContext testContext) /**/
        {
            Debug.WriteLine("Hello Class Initialize");

            AppiumOptions capCalc = new AppiumOptions();

            capCalc.AddAdditionalCapability("app", "Microsoft.WindowsAlarms_8wekyb3d8bbwe!App");

            sessionAlarms = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), capCalc);


            /* Para acessar os dados que estão disponíveis com um teste de acionamento de dados no MsTest, 
               precisamos usar um obejto de TestContext class */      
           

            objTestContext = testContext; /* -> Armazenando o valor, testContext, a um membro de nível de classe ( variável ??? )
                                                para que possamos utilizá-lo em nossos métodos de teste.

                                                Então, o Visual Studio gera um campo no membro de nível de class.


            // -> A classe TestContext pertence à estrutura de teste da unidade Visual Studio, também conhecida como MsTest
            
            ** Um objeto já instanciado da classe TestContext é fornecido pela estrutura como um parâmetro para o método ClassInitialize */

        }

        [ClassCleanup]
        public static void CleanupAfterAllAlarmsTests()
        {
            Debug.WriteLine("Hello Class CleanUp");

            if (sessionAlarms != null)
            {
                sessionAlarms.Quit();
            }
        }

        [TestInitialize]
        public void BeforeATest()
        {
            Debug.WriteLine("Before a test, calling Test Initialize");
        }


        [TestCleanup]
        public void AfterATest()
        {
            Debug.WriteLine("After a test, calling Test CleanUp");
        }


        [TestMethod]
        public void JustAnotherTest()
        {
            Debug.WriteLine("Hello another test");
        }


        [TestMethod]
        public void TestAlarmsAdnClockIsLaunchingSuccessfully()
        {
            Debug.WriteLine("Hello Test Alarms Is Launching Successfully!");

            Assert.AreEqual("Relógio", sessionAlarms.Title, false,
                $"Título actual não é o esperado: {sessionAlarms.Title}");

        }




                     /*  ADDING SUPPORT FOR DATA DRIVEN TESTING TO A TEST FOR SEQUENTIAL DATA VARIETY
             *  ADICIONANDO SUPORTE PARA TESTE ORIENTADOS A DADOS A UM TESTE PARA VARIEDADE DE DADOS SEQUENCIAIS 



        // Após o TestMethod, dicionamos  o atributo "DataSource", os parâmetros para o mesmo são fornecidos entre parênteses '()'.
         
         -> 1º PARAMETER : "System.Data.OleDb" - é o nome do fornecedor dos dados.



         -> 2º PARAMETER : Fio de conexão - o copiamos do connectionstring.com, pesquisando: ace oledb 12 
                            Copiamos o fio do tipo de arquivo que usaremos, no caso, Xlsx files (Excel)
        

            - O valor do atributo Propriedades Estendidas (Extended Properties) vem com um corpo duplo.
            Precisamos escapar deles, e para isso, acrescentaremos uma citação dupla por trás das citações duplas existentes 
            no valor do atributo
                
                 -> antes: ... Extended Properties="Excel 12.0 Xml;HDR=NO";
                 -> depois: ... Extended Properties=""Excel 12.0 Xml;HDR=NO"";
         

            - No 'Data Source=', Fonte de Dados, colocaremos o caminho para o arquivo que contém os dados que serão utilizados
                
                 -> Data Source = C:\Appium\sessao6CursoAppium.xlsx;


            - "HDR=Yes;" indicates that the first row contains columnnames, not data. "HDR=No;" indicates the opposite.
            - "HDR=Sim;" indica que a primeira linha contém nomes de coluna, não dados. "HDR=Não;" indica o contrário.



        -> 3º PARAMETER : nome da folha do arquivo, no caso do excel, do qual queremos ler os dados

            - Colocaremos o nome da folha que queremos usar e o símbolo de cifrão ($) depois dela.
                
                 -> ..., "Clocks$" ,

                    * O sinal de cifrão é muito importante !!!
         


        -> 4º PARAMETER : DataAccessMethod.Sequential - este é o tipo de acesso aos dados

            - E isso significa que o teste de nossos dados deve ser feito através do fornecimento dos valores fornecidos na folha Excel
              de cima para baixo. 

            - E dopis haverá um suporte de fechamento. Para ter certeza que definimos tudo corretamente.

         */

        [TestMethod, DataSource("System.Data.OleDb", @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = C:\Appium\sessao6CursoAppium.xlsx;Extended Properties=""Excel 12.0 Xml;HDR=YES"";", "Clocks$" , DataAccessMethod.Sequential)]
        public void AddLocalRelogio()
        {
            //sessionAlarms.FindElementByName("Fechar Entrar").Click();

            sessionAlarms.FindElementByAccessibilityId("ClockButton").Click();

            //sessionAlarms.FindElementByClassName("Ativar/desativar a navegação").Click();
            //sessionAlarms.FindElementByAccessibilityId("ClockButton").Click();

            sessionAlarms.FindElementByName("Adicionar nova cidade").Click();

            // System.Threading.Thread.Sleep(1000); // tática de atraso


            WebDriverWait waitForMe = new WebDriverWait(sessionAlarms, TimeSpan.FromSeconds(10));

            var local = sessionAlarms.FindElementByName("Inserir um local");

            waitForMe.Until(pred => local.Displayed);
            // pred = parâmetro IWebDriver
            // => expressão lambda
            // local = WindowsElement 
            // .Displayed - oque está sendo avaliado 


            /* DataRow 
               -> propriedade da objTestContext, usada para acessar os dados de linha
             
                - após inseri-la, precisamos acrescentar a referência de montagem.
                - E precisamos convertê-la em uma string.  */


            /* Aqui vamos para tipo de valor recuperado da panilha Excel em vez do código rígido "Amsterdã, Países Baixos" */
            string locInput = Convert.ToString(objTestContext.DataRow["Lacalização Input"]);

            Debug.WriteLine($"Input do Excel: {locInput}");

            local.SendKeys(locInput); //"Amsterdã, Países Baixos" );

            local.SendKeys(Keys.Enter);
            sessionAlarms.FindElementByName("Adicionar").Click();


            var clockItems = sessionAlarms.FindElementsByClassName("ListViewItem");

            bool wasClockTileFound = false;
            WindowsElement tileFound = null;

            string valorEsperado = Convert.ToString(objTestContext.DataRow["Localização Esperada"]);

            Debug.WriteLine($"Valor esperado: {valorEsperado}");

            foreach (WindowsElement clockTile in clockItems)
            {  
                if (clockTile.Text.StartsWith( valorEsperado)) //"Amsterdã, Países Baixos"))
                {
                    Debug.WriteLine("Clock Found.");
                    wasClockTileFound = true;
                    tileFound = clockTile;
                    break;
                }
            }

            Assert.IsTrue(wasClockTileFound, "No clock tile found."); // Afirmação para verificar os resultados

            /* Clique direito = Clique de contexto */

            //waitForMe.Until(pred => tileFound.Displayed);

            Actions actionForRightClick = new Actions(sessionAlarms); 

            actionForRightClick.MoveToElement(tileFound); 
            actionForRightClick.Click();
            actionForRightClick.ContextClick();
            waitForMe.Until(pred => tileFound.Displayed);
            actionForRightClick.Perform(); // colocará todas as ações em movimento


            // Using app Root Desktop session for selecting a context menu item in Appium

            AppiumOptions capDesktop = new AppiumOptions();
            capDesktop.AddAdditionalCapability("app", "Root");

            WindowsDriver<WindowsElement> sessionDesktop =
                new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), capDesktop);

            var contextItemDelete = sessionDesktop.FindElementByAccessibilityId("ContextMenuDelete");

            WebDriverWait DesktopWaitForMe = new WebDriverWait(sessionDesktop, TimeSpan.FromSeconds(10));
            waitForMe.Until(pred => contextItemDelete.Displayed);

            contextItemDelete.Click();

        }
    }
}