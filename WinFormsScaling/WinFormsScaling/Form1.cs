using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
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
                                                              .AddUserSecrets(Assembly.GetExecutingAssembly())
                                                              .Build();

            bool isCool = config.GetSection("IsCool").Value == "True";
            var conStrings = config.GetSection("ConnectionStrings");
            var conStringDb1 = conStrings.GetSection("db1").Value;

            if (isCool)
            {
                BackColor = Color.SteelBlue;
            }

            textBox1.Text = conStringDb1;
        }
    }
}
