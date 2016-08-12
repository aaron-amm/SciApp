using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CassiniDev;

namespace SciHospital.WinApp
{
    public partial class Form1 : Form
    {
        private readonly CassiniDevServer server;

        public Form1()
        {
            InitializeComponent();
            server = new CassiniDevServer();


            // our content is Copy Always into bin
            var webFolder = Path.Combine(Environment.CurrentDirectory, "WebContent");
            server.StartServer(@"D:\projects\sci-hospital\SciHospital.WebApp", 8080, "/","localhost" );

        }
    }
}
