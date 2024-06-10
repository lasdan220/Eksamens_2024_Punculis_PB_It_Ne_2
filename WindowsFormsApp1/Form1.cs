using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private IWebDriver driver;
        private Stack<string> meklesanasPiepras; // steks lai saglabat meklessanas vaicajumus

        public Form1()
        {
            InitializeComponent(); //formas komponentu inicializacija
            WebDriver(); // chromedriver palaisanas metodes inicializacija
            EbayPage(); // ebay majaslapas atversanas metode inicializacija
            meklesanasPiepras = new Stack<string>(); // inicializejam steku
        }

        private void WebDriver()
        {
            var options = new ChromeOptions();
            driver = new ChromeDriver(@"C:\Users\marek\source\repos\lasdan220\Eksamens_2024_Punculis_PB_It_Ne_2\packages\Selenium.WebDriver.ChromeDriver.125.0.6422.14100\driver\win32", options); //inicializejam chrome driver
        }

        private void EbayPage()
        {
            driver.Navigate().GoToUrl("https://www.ebay.com"); // atveram ebay majas lapu
        }
        private void button1_Click(object sender, EventArgs e) // SEARCH
        {
            string pieprasijums = textBox1.Text; //dabujam tekstu
            if (!string.IsNullOrWhiteSpace(pieprasijums))
            {
                meklesanasPiepras.Push(pieprasijums); // saglabajam meklessenas vaicajumu steka
                string ebayLink = $"https://www.ebay.com/sch/i.html?_nkw={Uri.EscapeDataString(pieprasijums)}"; //izveido meklessanas url ar iepriekssejo vaicajumu
                driver.Navigate().GoToUrl(ebayLink); //navige uz ebay meklessanas lapu
                textBox2.Text = ebayLink;

                if (!string.IsNullOrWhiteSpace(richTextBox1.Text)) //parbauda vai nav tukss
                {
                    richTextBox1.AppendText(Environment.NewLine); //pievieno jaunu rindu
                }
                richTextBox1.AppendText(ebayLink); //pievieno meklessanas vaicajumu
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (meklesanasPiepras.Count > 1) // parbauda vai steks satur vairak neka vienu vaicajumu
            {
                meklesanasPiepras.Pop(); // iznem no steka passreizejo vaicajumu
                string ieprieksPiepras = meklesanasPiepras.Peek(); // lai dabut iepriekssejo meklessanas vaicajumu
                string ebayLink = $"https://www.ebay.com/sch/i.html?_nkw={Uri.EscapeDataString(ieprieksPiepras)}"; //izveido meklessanas vaicajumu ar iepriekssejo vaicajumu
                driver.Navigate().GoToUrl(ebayLink); // navige uz iepriekssejo vaicajumu
                textBox1.Text = ieprieksPiepras; // Atjauno meklesanas logu
                textBox2.Text = ebayLink; // Atjauno linka tekstlodziņu
            }
            else
            {
                driver.Navigate().Back(); // iepriesseja lapa parlukaa
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            driver.Quit(); // aizveram timekla parluku
            Application.Exit();
        }
    }
}
