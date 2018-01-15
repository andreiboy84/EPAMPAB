using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoeuroTest
{
    public class Page : IDisposable
    {
        private const string BaseUrl = "https://ru.goeuro.com/";

        private const string DriverPath = @"C:\Users\Andre\Desktop\GoeuroTest\GoeuroTest\Resource";
        private const string ChromeDriver = "chromedriver";
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn_home']")]
        private IWebElement buttonInputFrom; //кнопка поиска

        [FindsBy(How = How.XPath, Using = "//button[@class='trenButtonDetalles99586']")]
        private IWebElement trenButtonDetalles; //кнопка заказа

        [FindsBy(How = How.XPath, Using = "//input[@id='IdOrigen']")]
        private IWebElement IdOrigen; // от куда 

        [FindsBy(How = How.XPath, Using = "//input[@id='IdDestino']")]
        private IWebElement IdDestino; // куда 

        [FindsBy(How = How.XPath, Using = "//input[@id='__fechaIdaVisual']")]
        private IWebElement fechaIdaVisual; // изменение даты отпровления 

        [FindsBy(How = How.XPath, Using = "//label[@for='_idaManana']")]
        private IWebElement idaManana; // утром с6-12

        [FindsBy(How = How.XPath, Using = "//label[@for='_idaMediodia']")]
        private IWebElement idaMediodia; // днем с 12-19

        [FindsBy(How = How.XPath, Using = "//label[@for='_idaNoche']")]
        private IWebElement idaNoche; // вечером с 19-24

        [FindsBy(How = How.XPath, Using = "//input[@id='__fechaVueltaVisual']")]
        private IWebElement fechaVueltaVisual; // изменение даты обратно 

        [FindsBy(How = How.XPath, Using = "//label[@for='_vueltaManana']")]
        private IWebElement vueltaManana; // утром с6-12

        [FindsBy(How = How.XPath, Using = "//label[@for='_vueltaMediodia']")]
        private IWebElement vueltaMediodia; // днем с 12-19

        [FindsBy(How = How.XPath, Using = "//label[@for='_vueltaNoche']")]
        private IWebElement vueltaNoche; // вечером с 19-24

        [FindsBy(How = How.XPath, Using = "//input[@id='__numAdultos']")]
        private IWebElement numAdultos; // количество взрослых 

        [FindsBy(How = How.XPath, Using = "//input[@id='__numNinos']")]
        private IWebElement numNinos; // количество подростков 

        [FindsBy(How = How.XPath, Using = "//input[@id='__numBebe']")]
        private IWebElement numBebe; // количество детей до 4 

        [FindsBy(How = How.XPath, Using = "//input[@id='__tarjetaDorada']")]
        private IWebElement tarjetaDorada; // быбор имеющейся залотой карты скидок 

        [FindsBy(How = How.XPath, Using = "//input[@id='trenClaseOcupacion30']")]
        private IWebElement ClaseOcupacion; // быбор эконом класс

        [FindsBy(How = How.XPath, Using = "//a[@class='link_gris']")]
        private IWebElement linkGris; //просмотр промежуточных станций 



        public Page()
        {
            driver = new ChromeDriver(DriverPath);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            PageFactory.InitElements(driver, this);
        }

        public void TestCase1()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            IdOrigen.SendKeys("MADRID (TODAS)");
            Thread.Sleep(2000);
            IdOrigen.SendKeys(OpenQA.Selenium.Keys.Enter);
            IdDestino.SendKeys("ZARAGOZA (TODAS)");
            Thread.Sleep(2000);
            IdDestino.SendKeys(OpenQA.Selenium.Keys.Enter);
            fechaIdaVisual.Clear();
            fechaIdaVisual.SendKeys("16/01/2018");
            numAdultos.Clear();
            numAdultos.SendKeys("2");
            buttonInputFrom.Click();

            IWebElement secondTu = driver.FindElement(By.XPath("//*[@id='wrapper']/section[2]/div/aside/form/h2[2]"));
            string s = secondTu.Text.ToString();
            NUnit.Framework.Assert.AreEqual(s, "FILTRAR");

        }

        public void TestCase2()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            IdOrigen.SendKeys("MADRID (TODAS)");
            Thread.Sleep(2000);
            IdOrigen.SendKeys(OpenQA.Selenium.Keys.Enter);
            IdDestino.SendKeys("ZARAGOZA (TODAS)");
            Thread.Sleep(2000);
            IdDestino.SendKeys(OpenQA.Selenium.Keys.Enter);
            fechaIdaVisual.Clear();
            fechaIdaVisual.SendKeys("21/01/2018");
            idaManana.Click();
            numBebe.Clear();
            numBebe.SendKeys("2");
            buttonInputFrom.Click();

            IWebElement secondTu = driver.FindElement(By.XPath("//*[@id='wrapper']/section[2]/div/aside/form/h2[2]"));
            string s = secondTu.Text.ToString();
            NUnit.Framework.Assert.AreEqual(s, "FILTRAR");
        }

        public void TestCase3()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            IdOrigen.SendKeys("CADIZ");
            Thread.Sleep(2000);
            IdOrigen.SendKeys(OpenQA.Selenium.Keys.Enter);
            Thread.Sleep(1000);
            IdDestino.SendKeys("ZAMORA");
            Thread.Sleep(2000);
            IdDestino.SendKeys(OpenQA.Selenium.Keys.Enter);
            fechaIdaVisual.Clear();
            fechaIdaVisual.SendKeys("21/01/2018");
            idaNoche.Click();
            buttonInputFrom.Click();
            linkGris.Click();

            IWebElement second = driver.FindElement(By.XPath("//*[@id='Datos_del_Viaje_solicitado']/dl[1]/dt[1]/span"));
            string s = second.Text.ToString();
            NUnit.Framework.Assert.AreEqual(s, "Origen");
        }

        public void TestCase4()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            IdOrigen.SendKeys("CADIZ");
            Thread.Sleep(2000);
            IdOrigen.SendKeys(OpenQA.Selenium.Keys.Enter);
            IdDestino.SendKeys("ZAMORA");
            Thread.Sleep(2000);
            IdDestino.SendKeys(OpenQA.Selenium.Keys.Enter);
            fechaIdaVisual.Clear();
            fechaIdaVisual.SendKeys("21/01/2018");
            fechaVueltaVisual.Clear();
            fechaVueltaVisual.SendKeys("21/01/2018");
            numAdultos.Clear();
            numAdultos.SendKeys("2");
            buttonInputFrom.Click();

            IWebElement secondTu = driver.FindElement(By.XPath("//*[@id='wrapper']/section[2]/div/aside/form/h2[2]"));
            string s = secondTu.Text.ToString();
            NUnit.Framework.Assert.AreEqual(s, "FILTRAR");
        }


        public void TestCase5()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            IdOrigen.SendKeys("MALAGA AEROPUERTO");
            Thread.Sleep(2000);
            IdOrigen.SendKeys(OpenQA.Selenium.Keys.Enter);
            IdDestino.SendKeys("SEVILLA-SAN BERNARDO");
            Thread.Sleep(2000);
            IdDestino.SendKeys(OpenQA.Selenium.Keys.Enter);
            fechaIdaVisual.Clear();
            fechaIdaVisual.SendKeys("21/01/2018");

            IWebElement secondTu = driver.FindElement(By.XPath("//*[@id='myModalLabel']"));
            string s = secondTu.Text.ToString();
            NUnit.Framework.Assert.AreEqual(s, "Se han encontrado los siguientes errores:");
        }

        public void TestCase6()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            IdOrigen.SendKeys("CADIZ");
            Thread.Sleep(2000);
            IdOrigen.SendKeys(OpenQA.Selenium.Keys.Enter);
            IdDestino.SendKeys("ZAMORA");
            Thread.Sleep(2000);
            IdDestino.SendKeys(OpenQA.Selenium.Keys.Enter);
            fechaIdaVisual.Clear();
            fechaIdaVisual.SendKeys("1/01/2018");
            buttonInputFrom.Click();

            IWebElement secondTu = driver.FindElement(By.XPath("//*[@id='myModalLabel']"));
            string s = secondTu.Text.ToString();
            NUnit.Framework.Assert.AreEqual(s, "Se han encontrado los siguientes errores:");
        }

        public void TestCase7()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            IdOrigen.SendKeys("MADRID (TODAS)");
            Thread.Sleep(2000);
            IdOrigen.SendKeys(OpenQA.Selenium.Keys.Enter);
            IdDestino.SendKeys("ZARAGOZA (TODAS)");
            Thread.Sleep(2000);
            IdDestino.SendKeys(OpenQA.Selenium.Keys.Enter);
            fechaIdaVisual.Clear();
            fechaIdaVisual.SendKeys("21/01/2018");
            idaManana.Click();
            fechaVueltaVisual.Clear();
            fechaVueltaVisual.SendKeys("01/02/2018");
            vueltaNoche.Click();
            numNinos.Clear();
            numNinos.SendKeys("1");
            numBebe.Click();
            numBebe.SendKeys("1");
            tarjetaDorada.Clear();
            tarjetaDorada.SendKeys("2");
            buttonInputFrom.Click();
            ClaseOcupacion.Click();
            trenButtonDetalles.Click();
        }

        public void TestCase8()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            IdOrigen.SendKeys("CADIZ");
            Thread.Sleep(2000);
            IdOrigen.SendKeys(OpenQA.Selenium.Keys.Enter);
            IdDestino.SendKeys("ZAMORA");
            Thread.Sleep(2000);
            IdDestino.SendKeys(OpenQA.Selenium.Keys.Enter);
            fechaIdaVisual.Clear();
            fechaIdaVisual.SendKeys("21/01/2018");
            numAdultos.Clear();
            numAdultos.SendKeys("0");
            buttonInputFrom.Click();

            IWebElement secondTu = driver.FindElement(By.XPath("//*[@id='myModalLabel']"));
            string s = secondTu.Text.ToString();
            NUnit.Framework.Assert.AreEqual(s, "Se han encontrado los siguientes errores:");
        }

        public void TestCase9()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            IdOrigen.SendKeys("CADIZ");
            Thread.Sleep(2000);
            IdOrigen.SendKeys(OpenQA.Selenium.Keys.Enter);
            IdDestino.SendKeys("ZAMORA");
            Thread.Sleep(2000);
            IdDestino.SendKeys(OpenQA.Selenium.Keys.Enter);
            fechaIdaVisual.Clear();
            fechaIdaVisual.SendKeys("21/01/2018");
            numAdultos.Clear();
            numAdultos.SendKeys("0");
            numBebe.Clear();
            numBebe.SendKeys("1");
            buttonInputFrom.Click();

            IWebElement second = driver.FindElement(By.XPath("//*[@id='Datos_del_Viaje_solicitado']/dl[1]/dt[1]/span"));
            string s = second.Text.ToString();
            NUnit.Framework.Assert.AreEqual(s, "Origen");
        }

        public void TestCase10()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            IdOrigen.SendKeys("CADIZ");
            Thread.Sleep(2000);
            IdOrigen.SendKeys(OpenQA.Selenium.Keys.Enter);
            IdDestino.SendKeys("ZAMORA");
            Thread.Sleep(2000);
            IdDestino.SendKeys(OpenQA.Selenium.Keys.Enter);
            fechaIdaVisual.Clear();
            fechaIdaVisual.SendKeys("21/01/2018");
            numAdultos.Clear();
            numAdultos.SendKeys("0");
            numNinos.Clear();
            numNinos.SendKeys("1");
            numBebe.Clear();
            numBebe.SendKeys("1");
            buttonInputFrom.Click();

            IWebElement secondTu = driver.FindElement(By.XPath("//*[@id='wrapper']/section[2]/div/aside/form/h2[2]"));
            string s = secondTu.Text.ToString();
            NUnit.Framework.Assert.AreEqual(s, "FILTRAR");
        }


        public void Dispose()
        {
            driver.Quit();
            driver = null;

            foreach (var process in Process.GetProcessesByName(ChromeDriver))
            {
                process.Kill();
            }
        }
    }
}
