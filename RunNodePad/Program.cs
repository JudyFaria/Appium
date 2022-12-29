using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunNodePad
{
    class Program
    {
        static void Main(string[] args)
        {
            // Automation Solution - setup in Visual Studio
            // Será o "Olá Mundo!" da automação de teste

            WindowsDriver<WindowsElement> notePadSession; // objeto de driver Windows com tipo genérico Elemento Windows
            AppiumOptions capacidadesDesejadas = new AppiumOptions(); // objeto do tipo AppiumOptions

            // chamando método, acrescentar capacidade adicional, e especifica o caminho da aplicação herdada
            capacidadesDesejadas
               .AddAdditionalCapability("app", @"C:\Windows\System32\notepad.exe"); // (parâmetros - nome-valor) 1º parameter: "app", 2º parameter: caminho da aplicação

            //notePadSession - objeto condutor
            notePadSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), capacidadesDesejadas);
            //atribuindo valor - 1º parameter: objeto do URI - porta do WinAppDriver / 2º parameter: objeto AppiumOptions

            // > Ao fazer isso, estamos informando o driver sobre o caminho da aplicação, queremos que ela seja lançada


            // Se o pedido for lançado com sucesso:
            if (notePadSession == null)
            {
             Console.WriteLine("App não iniciou. (App not started.)");
             return;
            }


////------------------------------------------------ Primeira Solução -----------------------------------------------------------



            // Um objeto WindowsDriver pode ser usado para recuperar várias propriedades da aplicação em teste
            /*Ex.:
            * Recuperando título do pedido.*/

            Console.WriteLine($"Application title: {notePadSession.Title}");

            notePadSession.Manage().Window.Maximize();

            //Recuperando uma captura de tela do aplicativo em teste 
            var screenShot = notePadSession.GetScreenshot(); // captura de tela recuperada usando o método GetScreenShot()
            screenShot.SaveAsFile($".\\CapturaDeTela{DateTime.Now.ToString("ddMMyyyyhhmmss")}.png", // salva no disco chamando o método SaveAsFile()
                OpenQA.Selenium.ScreenshotImageFormat.Png);
            // > SaveAsFile() - 1º parameter: caminho onde o arquivo será salvo / 2º parameter: formato da imagem 

            //notePadSession.Quit(); 



////------------------------------------------------ Segunda Solução -----------------------------------------------------------


            //Sem iniciar o WAD
        
        //    var appiumLocalServer = AppiumServiceBuilder().UsingPort(4723).Build();
         //   appiumLocalServer.Start();
//
         //   AppiumOptions ao = new AppiumOptions();
       //     ao.AddAdditionalCapability("app", @"C:\Windows\System32\calc.exe");

        //    WindowsDriver<WindowsElement> session = new WindowsDriver<WindowsElement>(appiumLocalServer, ao);

        //    session.Quit();
            
        }
    }
}
