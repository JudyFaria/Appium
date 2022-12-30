using OpenQA.Selenium.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;
using OpenQA.Selenium;

namespace MSTestOverview
{
    [TestClass]
    public class AlarmsAndClockSmokeTests { 

        static WindowsDriver<WindowsElement> sessionAlarms;

        [ClassInitialize]
        public static void PrepareForTestingAlarms(TestContext testContext)
        {
            Debug.WriteLine("Hello Class Initialize");

            AppiumOptions capCalc = new AppiumOptions();

            capCalc.AddAdditionalCapability("app", "Microsoft.WindowsAlarms_8wekyb3d8bbwe!App");

            sessionAlarms = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), capCalc);

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


        

    }
}