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

namespace spectr
{
    /// <summary>
    /// Логика взаимодействия для WinNewZakaz.xaml
    /// </summary>
    public partial class WinNewZakaz : Window
    {
        public WinNewZakaz()
        {
            InitializeComponent();
        }

        private void newzakaz_Click(object sender, RoutedEventArgs e)
        {

            int errInt = 0;
            double errDouble = 0;

            if (int.TryParse(TB1.Text, out errInt) == false)
            {
                MessageBox.Show("Некоректно введены данные");
            }
            else
            {
                Transfer.ValueInt1 = Convert.ToInt32(TB1.Text);

            }

            if (int.TryParse(TB2.Text, out errInt) == false)
            {
                MessageBox.Show("Некоректно введены данные");
            }
            else
            {
                Transfer.ValueInt2 = Convert.ToInt32(TB2.Text);

            }

            if (int.TryParse(TB3.Text, out errInt) == false)
            {
                MessageBox.Show("Некоректно введены данные");
            }
            else
            {
                Transfer.ValueInt3 = Convert.ToInt32(TB3.Text);

            }

            if (int.TryParse(TB4.Text, out errInt) == false)
            {
                MessageBox.Show("Некоректно введены данные");
            }
            else
            {
                Transfer.ValueInt4 = Convert.ToInt32(TB4.Text);

            }
            if (int.TryParse(TB5.Text, out errInt) == false)
            {
                MessageBox.Show("Некоректно введены данные");
            }
            else
            {
                Transfer.ValueInt5 = Convert.ToInt32(TB5.Text);

            }

            if (int.TryParse(TB6.Text, out errInt) == false)
            {
                MessageBox.Show("Некоректно введены данные");
            }
            else
            {
                Transfer.ValueInt6 = Convert.ToInt32(TB6.Text);

            }
            if (int.TryParse(TB7.Text, out errInt) == false)
            {
                MessageBox.Show("Некоректно введены данные");
            }
            else
            {
                Transfer.ValueInt7 = Convert.ToInt32(TB7.Text);

            }

            if (int.TryParse(TB8.Text, out errInt) == false)
            {
                MessageBox.Show("Некоректно введены данные");
            }
            else
            {
                Transfer.ValueInt8 = Convert.ToInt32(TB8.Text);

            }


            if (double.TryParse(TB9.Text, out errDouble) == false)
            {
                MessageBox.Show("Некоректно введены данные");
            }
            else
            {
                Transfer.ValueDouble1 = Convert.ToDouble(TB9.Text);

            }

            if (double.TryParse(TB10.Text, out errDouble) == false)
            {
                MessageBox.Show("Некоректно введены данные");
            }
            else
            {
                Transfer.ValueDouble2 = Convert.ToDouble(TB10.Text);

            }

           /* Transfer.ValueInt1 = Convert.ToInt32(TB1.Text);
            Transfer.ValueInt2 = Convert.ToInt32(TB2.Text);
            Transfer.ValueInt3 = Convert.ToInt32(TB3.Text);
            Transfer.ValueInt4 = Convert.ToInt32(TB4.Text);
            Transfer.ValueInt5 = Convert.ToInt32(TB5.Text);
            Transfer.ValueInt6 = Convert.ToInt32(TB6.Text);
            Transfer.ValueInt7 = Convert.ToInt32(TB7.Text);
            Transfer.ValueInt8 = Convert.ToInt32(TB8.Text);
            Transfer.ValueDouble1 = Convert.ToDouble(TB9.Text);
            Transfer.ValueDouble2 = Convert.ToDouble(TB10.Text);*/
            Transfer.ValueString1 = TB11.Text;


            if (int.TryParse(TB12.Text, out errInt) == false)
            {
                MessageBox.Show("Некоректно введены данные");
            }
            else
            {
                Transfer.ValueInt9 = Convert.ToInt32(TB12.Text);

            }


            if (TB12.Text == "")
            {
                MessageBox.Show("поле пустое");
            }
            else
            {
                Transfer.ValueInt9 = Convert.ToInt32(TB12.Text);

            }
            this.Close();
        }
    }
}
