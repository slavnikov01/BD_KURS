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
    /// Логика взаимодействия для WinNewMaster.xaml
    /// </summary>
    public partial class WinNewMaster : Window
    {
        public WinNewMaster()
        {
            InitializeComponent();
        }

        private void newmaster_Click(object sender, RoutedEventArgs e)
        {
            int errInt = 0;
            double errDouble = 0;

            Transfer.ValueString1 = TB1.Text;
            Transfer.ValueString2 = TB2.Text;
            Transfer.ValueString3 = TB3.Text;
            if (double.TryParse(TB4.Text, out errDouble) == false)
            {
                MessageBox.Show("Некоректно введены данные");
            }
            else
            {
                Transfer.ValueDouble1 = Convert.ToDouble(TB4.Text);

            }
            //  Transfer.ValueDouble1 = Convert.ToDouble(TB4.Text);
            //Transfer.ValueString5 = TB5.Text;
            //Transfer.ValueString6 = TB6.Text;

            if (int.TryParse(TB5.Text, out errInt) == false)
            {
                MessageBox.Show("Некоректно введены данные");
            }
            else
            {
                Transfer.ValueInt1 = Convert.ToInt32(TB5.Text);

            }
            // Transfer.ValueInt1 = Convert.ToInt32(TB5.Text);
            if (int.TryParse(TB6.Text, out errInt) == false)
            {
                MessageBox.Show("Некоректно введены данные");
            }
            else
            {
                Transfer.ValueInt2 = Convert.ToInt32(TB6.Text);

            }
            // Transfer.ValueInt2 = Convert.ToInt32(TB6.Text);

            if (int.TryParse(TB7.Text, out errInt) == false)
            {
                MessageBox.Show("Некоректно введены данные");
            }
            else
            {
                Transfer.ValueInt4 = Convert.ToInt32(TB7.Text);

            }

            if (TB7.Text == "")
            {
                MessageBox.Show("поле пустое");
            } else 
            {Transfer.ValueInt4 = Convert.ToInt32(TB7.Text);

            }
            this.Close();
        }
    }
}
