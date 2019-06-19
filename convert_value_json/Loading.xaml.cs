using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace convert_value_json
{
    public partial class Loading : Window
    {
        RootObject us;
        public Loading()
        {
            InitializeComponent();

            Start();
        }

        async void Start()
        {
            await Task.Factory.StartNew(Run);

            MainWindow main = new MainWindow(us);
            main.Show();

            Close();
        }

        void Run()
        {
            Task.Delay(2000).Wait();
            WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };
            var json = wc.DownloadString("https://www.cbr-xml-daily.ru/daily_json.js");
            var user = JsonConvert.DeserializeObject<RootObject>(json);
            us = user;
        }
    }
}
