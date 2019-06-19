using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace convert_value_json
{
    public class CustomElement : TextBlock
    {
        public double NormalValue;
        public string Charcode;
        string progress;
        public CustomElement(Valute v)
        {
            if (v.Nominal != 1)
            {
                v.Value = v.Value / v.Nominal;
                v.Nominal = 1;
            }
            NormalValue = v.Value;
            Charcode = v.CharCode;

            if (v.Value < v.Previous)
            {
                progress = "↓  ";
            }
            else { progress = "↑  "; }

            Text = progress + v.CharCode + " : " + v.Name;
        }
    }
}
