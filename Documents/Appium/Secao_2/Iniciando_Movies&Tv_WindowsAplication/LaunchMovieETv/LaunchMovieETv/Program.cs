using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchMovieETv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WindowsDriver<WindowsElement> sessionMovieETv;
            AppiumOptions ao = new AppiumOptions();
            ao.AddAdditionalCapability("app", "Microsoft.ZuneVideo_8wekyb3d8bbwe!Microsoft.ZuneVideo");

            sessionMovieETv = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"),ao);

            Console.WriteLine("Iniciando Movie & TV!");

        }
    }
}
