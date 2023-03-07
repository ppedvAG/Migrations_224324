using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsScaling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", true)
                                                              .AddUserSecrets("ebe077d9-b326-4c8d-9ba0-838bcbf4248a")
                                                              .Build();

            bool isCool = config.GetSection("IsCool").Value == "True";
            var conStrings = config.GetSection("ConnectionStrings");
            var conStringDb1 = conStrings.GetSection("db1").Value;


            ConfigurationManager cm = new ConfigurationManager();
            cm.AddUserSecrets("ebe077d9-b326-4c8d-9ba0-838bcbf4248a");
            cm.GetSection("IsCool").Value = "AAAA";


            if (isCool)
            {
                BackColor = Color.Gold;
            }

            textBox1.Text = conStringDb1;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var http = new HttpClient();

            await Task.Delay(5000);

            var htmlSource = await http.GetStringAsync("http://ppedv.de");

            //var fileContent = File.ReadAllLines("c:\\tolleDatei.txt");
            //var fileContent = await File.ReadAllLinesAsync("c:\\tolleDatei.txt");

            textBox2.Text = htmlSource;
        }
    }
}
