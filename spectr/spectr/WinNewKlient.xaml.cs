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
    /// Логика взаимодействия для WinNewKlient.xaml
    /// </summary>
    public partial class WinNewKlient : Window
    {
        public WinNewKlient()
        {
            InitializeComponent();
        }

        private void newklient_Click(object sender, RoutedEventArgs e)
        {
            int errInt = 0;
            double errDouble = 0;

            Transfer.ValueString1 = TB1.Text;
            Transfer.ValueString2 = TB2.Text;
            Transfer.ValueString3 = TB3.Text;
            Transfer.ValueString4 = TB4.Text;

            if (int.TryParse(TB5.Text, out errInt) == false)
            {
                MessageBox.Show("Некоректно введены данные");
            }
            else
            {
                Transfer.ValueInt1 = Convert.ToInt32(TB5.Text);

            }
           // Transfer.ValueInt1 = Convert.ToInt32(TB5.Text);
            Transfer.ValueString6 = TB6.Text;
            Transfer.ValueString7 = TB7.Text;
            Transfer.ValueString8 = TB8.Text;
            Transfer.ValueString9 = TB9.Text;
            if (int.TryParse(TB10.Text, out errInt) == false)
            {
                MessageBox.Show("Некоректно введены данные");
            }
            else
            {
                Transfer.ValueInt2 = Convert.ToInt32(TB10.Text);

            }
           // Transfer.ValueInt2 = Convert.ToInt32(TB10.Text);
            Transfer.ValueString11 = TB11.Text;
            Transfer.ValueString12 = TB12.Text;
            Transfer.ValueString13 = TB13.Text;
            Transfer.ValueString14 = TB14.Text;
            if (int.TryParse(TB15.Text, out errInt) == false)
            {
                MessageBox.Show("Некоректно введены данные");
            }
            else
            {
                Transfer.ValueInt6 = Convert.ToInt32(TB15.Text);

            }
            // Transfer.ValueInt6 = Convert.ToInt32(TB15.Text);
            if (int.TryParse(TB16.Text, out errInt) == false)
            {
                MessageBox.Show("Некоректно введены данные");
            }
            else
            {
                Transfer.ValueInt3 = Convert.ToInt32(TB16.Text);

            }
            // Transfer.ValueInt3 = Convert.ToInt32(TB16.Text);

            if (int.TryParse(TB17.Text, out errInt) == false)
            {
                MessageBox.Show("Некоректно введены данные");
            }
            else
            {
                Transfer.ValueInt4 = Convert.ToInt32(TB17.Text);

            }

            if (TB17.Text == "")
            {
                MessageBox.Show("поле пустое");
            }
            else
            {
                Transfer.ValueInt4 = Convert.ToInt32(TB17.Text);

            }

            if (int.TryParse(TB18.Text, out errInt) == false)
            {
                MessageBox.Show("Некоректно введены данные");
            }
            else
            {
                Transfer.ValueInt5 = Convert.ToInt32(TB18.Text);

            }
            if (TB18.Text == "")
            {
                MessageBox.Show("поле пустое");
            }
            else
            {
                Transfer.ValueInt5 = Convert.ToInt32(TB18.Text);

            }
            this.Close();
        }
    }
}
