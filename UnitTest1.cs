
using OpenQA.Selenium.Support.UI;
using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.Generic;
using OpenQA.Selenium.DevTools.V85.HeadlessExperimental;


namespace Formulaire
{
    
    [TestFixture]
    public class SendForm
    {
        public IWebDriver driver; //Déclarer mon driver afin de l'utiliser dans mes méthodes
        IJavaScriptExecutor js;   // Déclarer un IJavaScriptExecutor : un objet qui permet d'exécuter du code JavaScript
        ReadData read = new ReadData();

        public List<Class1>client;
        //public Class1 client1;

        [SetUp]
        public void Debut()
        {
            js = (IJavaScriptExecutor)driver;
            driver = new ChromeDriver(@"C:\\selenium\chromedriver.exe");
            client = read.ReadDataFromJson();
        }

        [TearDown]
        public void Fin()
        {
            driver.Quit();
            driver.Dispose();
        }


        [Test]
        public void ClientHomme()
        {
            
            //client1 = client[0];


            driver.Navigate().GoToUrl("https://sendform.nicepage.io/?version=13efcba7-1a49-45a5-9967-c2da8ebdd189&uid=f7bd60f0-34c8-40e3-8e2c-06cc19fcb730");
            //driver.Manage().Window.Maximize();
            //Assert.AreEqual("Your Name", driver.FindElement(By.Id("label_4")).Text);


            //ChoisirHomme

            driver.FindElement(By.XPath("//*[@id=\"carousel_1853\"]/div/div/div/div/form/div[1]/div/div[1]/label")).Click();
            //Selectionner le pays
            SelectElement select = new SelectElement(driver.FindElement(By.Id("select-9648")));
            select.SelectByIndex(0);

            driver.FindElement(By.Id("email-c6a3")).SendKeys(client[0].Email);
            driver.FindElement(By.Id("name-c6a3")).SendKeys(client[0].Nom);
            driver.FindElement(By.Id("phone-84d9")).SendKeys(client[0].Phone);
            driver.FindElement(By.Id("address-be2d")).SendKeys($"{client[0].Address.Num} {client[0].Address.NomRue} {client[0].Address.CodePostal}");
            driver.FindElement(By.Id("message-c6a3")).SendKeys(client[0].Message);
            
            //choisir le produit
            SelectElement selectt = new SelectElement(driver.FindElement(By.Id("select-c283")));
            selectt.SelectByIndex(0);


            //js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.Id("label_input_7_1")));
            driver.FindElement(By.Id("checkbox-8214")).Click(); //cliquer sur sport

            //driver.FindElement(By.XPath("//*[@id=\"carousel_1853\"]/div/div/div/div/form/div[12]/a")).Click();

            string genderSelected = driver.FindElement(By.Id("field-2688")).GetAttribute("value");
            string PaysSelected = select.SelectedOption.GetAttribute("value");
            SelectElement selectProduct = new SelectElement(driver.FindElement(By.Id("select-c283")));

            if (genderSelected == "man" && PaysSelected == "FR")
            {

                selectProduct.SelectByValue("mot");
                driver.FindElement(By.Id("checkbox-8214"));
            }
            else
            {
                selectProduct.SelectByValue("velo");
                driver.FindElement(By.Id("checkbox-3842"));


            }

        }

        [Test]
        public void ClientFemme()
        {
            //client = read.ReadDataFromJson();



            driver.Navigate().GoToUrl("https://sendform.nicepage.io/?version=13efcba7-1a49-45a5-9967-c2da8ebdd189&uid=f7bd60f0-34c8-40e3-8e2c-06cc19fcb730");
            //driver.Manage().Window.Maximize();
            //Assert.AreEqual("Your Name", driver.FindElement(By.Id("label_4")).Text);
            //Homme

            driver.FindElement(By.XPath("//*[@id=\"carousel_1853\"]/div/div/div/div/form/div[1]/div/div[2]/label")).Click();
            SelectElement select = new SelectElement(driver.FindElement(By.Id("select-9648")));
            select.SelectByIndex(2);

            driver.FindElement(By.Id("email-c6a3")).SendKeys(client[1].Email);
            driver.FindElement(By.Id("name-c6a3")).SendKeys(client[1].Nom);
            driver.FindElement(By.Id("phone-84d9")).SendKeys(client[1].Phone);
            driver.FindElement(By.Id("address-be2d")).SendKeys($"{client[1].Address.Num} {client[1].Address.NomRue} {client[1].Address.CodePostal}");
            driver.FindElement(By.Id("message-c6a3")).SendKeys(client[1].Message);
            SelectElement selectt = new SelectElement(driver.FindElement(By.Id("select-c283")));
            selectt.SelectByIndex(1);
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.Id("label_input_7_1")));

            //cliquer sur sport et littérature 
            driver.FindElement(By.XPath("//*[@id=\"carousel_1853\"]/div/div/div/div/form/div[9]")).Click();

            driver.FindElement(By.XPath("//*[@id=\"carousel_1853\"]/div/div/div/div/form/div[12]/a")).Click();


            string genderSelected = driver.FindElement(By.Id("field-2688")).GetAttribute("value");
            string PaysSelected = select.SelectedOption.GetAttribute("value");
            SelectElement selectProduct = new SelectElement(driver.FindElement(By.Id("select-c283")));

            if (genderSelected == "women" && PaysSelected == "IT")
            {

                selectProduct.SelectByValue("vel");
                driver.FindElement(By.Id("checkbox-1848"));
            }
            else
            {
                selectProduct.SelectByValue("mot");
                driver.FindElement(By.Id("checkbox-3250"));


            }
        }


    }
}
