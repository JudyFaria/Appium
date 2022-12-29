using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcRunnerAppiumV4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WindowsDriver<WindowsElement> sessionCalc;

            AppiumOptions appOptions = new AppiumOptions();

            appOptions.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App"); // 2ºparameter: User Mode ID

            sessionCalc = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"),appOptions);

            //sessionCalc.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            
            // HOW TO CLICK A BUTTOM WITH APPIUM

            // Esse código 'Encontra Elemento Pelo Nome', que encontramos pelo Recorder_WAD_UI
            // E então, clica no eslemento encontrado
            
            var btnDois = sessionCalc.FindElementByName("Dois");

            btnDois.Click();
            sessionCalc.FindElementByName("Mais").Click();
            btnDois.Click();
            sessionCalc.FindElementByName("Igual a").Click();



            // READNG TEXT FROM UI ELEMENT USING 'AutomationID' IN APPIUM

            var txtResultado = sessionCalc.FindElementByAccessibilityId("CalculatorResults"); /* Esse parâmetro é encontrado pelo Recorde_UI com 
                                                                                                o nome de 'AutomaionId' da caixa de texto*/

            Console.WriteLine($"Valor mostrado pela calculadora: {txtResultado.Text}"); // Text -> Propriedade usada para ler o valor em texto do elemento Windown 

            // Verificando se o resultado mostrado na tela é igual ao esperado
            if (txtResultado.Text.EndsWith("4")) 
            {
                Console.WriteLine("Resultado Correto!");
            }
            else 
            { 
                Console.WriteLine("Resultado Incorreto!");
            }



            // TYPING TEXT WITH SendKeys

            // SendKeys() -> envia algumas teclas para um determinado controle (elemento UI)

            // namespace of Keys class, used for defining specialkey -> OpenQA.Selenium
            txtResultado.SendKeys(Keys.Escape); // -> Dizendo para o Appium que queremos pressionar o Escape Key

            //Chamamos o método SendKeys() e passamos um valor de string
            txtResultado.SendKeys("2");
            txtResultado.SendKeys("+");
            txtResultado.SendKeys("2");
            txtResultado.SendKeys("=");



            // USING ImplicitWait TO SLOW SCRIPTS DOWN
            // Deixar a aplicação um pouco mais lenta
            
            //sessionCalc.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            /* Manage() -> Podemos definir o Timer chamando o método de gerenciamento (Maneger()) no objeto WindowsDriver 
             * Timeouts() -> método
             * ImplicitWait -> proprirdade
             * TimeSpan -> é uma classe
             * FromSeconds() -> método estático
             * 
             */


            // To launch a Unified Windows Platform (UWP) application, wich of the following is used.
            // Aula 16 - Finding App User Mode ID to Launch UWP App with Appium WinAppDriver, Project Setup

            /************************** ESTUDAR **********************************/

            /* How to see list of apps for finding their User Mode ID?
             * > Press Windows + R, type: shell:appsfolder and hit enter.
             * 
             * - cria um shortcut na área de trabalho */
        }

    }
}
