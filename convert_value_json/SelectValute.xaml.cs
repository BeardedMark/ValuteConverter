using System;
using System.Collections.Generic;
using System.Linq;
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
    /// <summary>
    /// Логика взаимодействия для SelectValute.xaml
    /// </summary>
    public partial class SelectValute : Window
    {
        public Label label;
        public MainWindow main;
        public SelectValute(RootObject user, MainWindow m, Label l)
        {
            InitializeComponent();
            label = l;
            main = m;
            foreach (var v in user.Valute)
            {
                valuteList.Items.Add(new CustomElement(v.Value));
            }
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(label.Name == "out_label")
            {
                main.out_ce = (CustomElement)valuteList.SelectedItem;
                main.Selected();
                Close();
            }
            else
            {
                main.in_ce = (CustomElement)valuteList.SelectedItem;
                main.Selected();
                Close();
            }
        }
    }
}
