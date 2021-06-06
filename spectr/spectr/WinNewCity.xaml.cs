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
using MySql.Data.MySqlClient;
using System.Data;

namespace spectr
{
    /// <summary>
    /// Логика взаимодействия для WinNewCity.xaml
    /// </summary>
    public partial class WinNewCity : Window
    {
        private readonly string dataConnect = "server=localhost;user=root;database=garantii;port=3306;password=535659bbb";
        public WinNewCity()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void mewapparatura_Click(object sender, RoutedEventArgs e)
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
            Transfer.ValueString1 = TB2.Text;
            Transfer.ValueString2 = TB3.Text;
            Transfer.ValueString3 = TB4.Text;
            this.Close();
        }
    }
}
