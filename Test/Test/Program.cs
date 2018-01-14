using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest
{
    class Program
    {
        private static IWebDriver webDriver;
        static void Main(string[] args)
        {
            try
            {
                webDriver = new ChromeDriver(@"C:\Users\Andre\Desktop\Test");
                webDriver.Navigate().GoToUrl("https://github.com/login?return_to=%2Fjoin%3Fsource%3Dheader-repo");
                webDriver.FindElement(By.Id("login_field")).SendKeys("andreiboy84@rambler.ru");
                webDriver.FindElement(By.XPath("//input[@class='form-control form-control input-block'] ")).SendKeys("Gthdsqrkfcc8");
                webDriver.FindElement(By.XPath("//input[@class='btn btn-primary btn-block'][@name='commit']")).Click();
                System.Threading.Thread.Sleep(3000);
                if (webDriver != null)
                    webDriver.Quit();
            }
            catch (Exception e)
            {
                e.StackTrace.ToString();
            }
        }
    }
}
