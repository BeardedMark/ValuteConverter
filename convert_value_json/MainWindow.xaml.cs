using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;

namespace convert_value_json
{
    public partial class MainWindow : Window
    {
        RootObject json;

        public CustomElement out_ce;
        public CustomElement in_ce;

        public MainWindow(RootObject user)
        {
            InitializeComponent();
            json = user;
            original.TextChanged += Original_TextChanged;
            Selected();
        }


        public void Selected()
        {
            if (out_ce != null)
            {
                out_kol.Content = out_ce.Charcode + ":";
            }
            else out_kol.Content = "Валюта не выбрана";

            if (in_ce != null)
            {
                in_kol.Content = in_ce.Charcode + ":";
            }
            else in_kol.Content = "Валюта не выбрана";

            if((in_ce != null) && (out_ce != null))
            {
                double res = (out_ce.NormalValue / in_ce.NormalValue) * double.Parse(original.Text);
                result.Text = Convert.ToString(res);
            }
        }

        private void Original_TextChanged(object sender, TextChangedEventArgs e)
        {
            Selected();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SelectValute sv = new SelectValute(json, this, (Label)sender);
            sv.Show();
        }
    }
}

