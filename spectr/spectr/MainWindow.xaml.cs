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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;

using System.Drawing;
using System.Drawing.Printing;
using Size = System.Windows.Size;

using System.Windows.Controls.Primitives;
using System.Collections;



using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;

using Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;

using iTextSharp.text;
using iTextSharp.text.pdf;
//using iTextSharp.text.html;

using System.IO;

using System.Drawing;
using System.Drawing.Printing;
using Size = System.Windows.Size;*/


namespace spectr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        // private int MyRowCount;
        System.Data.DataTable HelpTable;
        private readonly string dataConnect = "server=localhost;user=root;database=garantii;port=3306;password=12344321";

        string cch;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MakeColumnNameList (System.Data.DataTable HelpTable)
        {
            TablesList.Items.Clear();
            foreach (DataColumn HelpColumn in HelpTable.Columns)
                TablesList.Items.Add(HelpColumn.ColumnName);
            if (TablesList.Items.IsEmpty)
            {
                MessageBox.Show("Ошибка заполнения элементами");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            try
            {
                string sql = "Select * from klient";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);
                DataSet ds = new DataSet("garantii");
                adapter.Fill(ds);
                DG1.DataContext = ds.Tables[0];

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            try
            {
                string selectedState = ComboBox.Text;
                if (selectedState == "Аппаратура")
                    selectedState = "apparatura";
                else if (selectedState == "Клиенты")
                    selectedState = "klient";
                else if (selectedState == "Заказ")
                    selectedState = "zakaz";
                else
                    selectedState = "master";

                string sql = "Select * from " + selectedState;
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);
                DataSet ds = new DataSet("garantii");
                adapter.Fill(ds);
                DG1.DataContext = ds.Tables[0];
                //вызов метода заполнения списка TablesList именами столбцов отображаемой таблицы для поиска
                MakeColumnNameList(ds.Tables[0]);
                HelpTable = ds.Tables[0];
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            DG1.Columns[0].IsReadOnly = true;

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //DG1.Columns[0].IsReadOnly = true;

            string selectedState = ComboBox.Text;
            if (selectedState == "Аппаратура")
            {
                selectedState = "apparatura";
                WinNewCity WNC = new WinNewCity();
                WNC.ShowDialog();
                if (Transfer.ValueInt1 != 0)
                {
                    String sql = "select * From apparatura";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);
                    DataSet ds = new DataSet("garantii");
                    adapter.Fill(ds);
                    var MyNewRow = ds.Tables[0].NewRow();
                    MyNewRow[1] = Transfer.ValueInt1;
                    MyNewRow[2] = Transfer.ValueString1;
                    MyNewRow[3] = Transfer.ValueString2;
                    MyNewRow[4] = Transfer.ValueString3;
                    ds.Tables[0].Rows.Add(MyNewRow);
                    DG1.DataContext = ds.Tables[0];
                    MySqlCommandBuilder My = new MySqlCommandBuilder(adapter);
                    adapter.InsertCommand = My.GetInsertCommand();
                    adapter.Update(ds.Tables[0]);
                }
            }
            else if (selectedState == "Клиенты")
            {
                selectedState = "klient";
                WinNewKlient WNK = new WinNewKlient();
                WNK.ShowDialog();
                if ((Transfer.ValueInt4 != 0) & (Transfer.ValueInt5 != 0) & (Transfer.ValueInt3 != 0) & (Transfer.ValueInt2 != 0) & (Transfer.ValueInt1 != 0))
                {
                    String sql = "select * From klient";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);
                    DataSet ds = new DataSet("garantii");
                    adapter.Fill(ds);
                    var MyNewRow = ds.Tables[0].NewRow();
                    MyNewRow[1] = Transfer.ValueString1;
                    MyNewRow[2] = Transfer.ValueString2;
                    MyNewRow[3] = Transfer.ValueString3;
                    MyNewRow[4] = Transfer.ValueString4;
                    MyNewRow[5] = Transfer.ValueInt1;
                    MyNewRow[6] = Transfer.ValueString6;
                    MyNewRow[7] = Transfer.ValueString7;
                    MyNewRow[8] = Transfer.ValueString8;
                    MyNewRow[9] = Transfer.ValueString9;
                    MyNewRow[10] = Transfer.ValueInt2;
                    MyNewRow[11] = Transfer.ValueString11;
                    MyNewRow[12] = Transfer.ValueString12;
                    MyNewRow[13] = Transfer.ValueString13;
                    MyNewRow[14] = Transfer.ValueString14;
                    MyNewRow[15] = Transfer.ValueInt6;
                    MyNewRow[16] = Transfer.ValueInt3;
                    MyNewRow[17] = Transfer.ValueInt4;
                    MyNewRow[18] = Transfer.ValueInt5;
                    ds.Tables[0].Rows.Add(MyNewRow);
                    DG1.DataContext = ds.Tables[0];
                    MySqlCommandBuilder My = new MySqlCommandBuilder(adapter);
                    adapter.InsertCommand = My.GetInsertCommand();
                    adapter.Update(ds.Tables[0]);
                }

            }
            else if (selectedState == "Заказ")
            {
                selectedState = "zakaz";
                WinNewZakaz WNZ = new WinNewZakaz();
                WNZ.ShowDialog();
                if ((Transfer.ValueInt4 != 0) & (Transfer.ValueInt1 != 0) & (Transfer.ValueInt2 != 0) & (Transfer.ValueInt3 != 0) & (Transfer.ValueInt5 != 0))
                {
                    String sql = "select * From zakaz";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);
                    DataSet ds = new DataSet("garantii");
                    adapter.Fill(ds);
                    var MyNewRow = ds.Tables[0].NewRow();
                    MyNewRow[1] = Transfer.ValueInt1;
                    MyNewRow[2] = Transfer.ValueInt2;
                    MyNewRow[3] = Transfer.ValueInt3;
                    MyNewRow[4] = Transfer.ValueInt4;
                    MyNewRow[5] = Transfer.ValueInt5;
                    MyNewRow[6] = Transfer.ValueInt6;
                    MyNewRow[7] = Transfer.ValueInt7;
                    MyNewRow[8] = Transfer.ValueInt8;
                    MyNewRow[9] = Transfer.ValueDouble1;
                    MyNewRow[10] = Transfer.ValueDouble2;
                    MyNewRow[11] = Transfer.ValueString1;
                    MyNewRow[12] = Transfer.ValueInt9;
                    ds.Tables[0].Rows.Add(MyNewRow);
                    DG1.DataContext = ds.Tables[0];
                    MySqlCommandBuilder My = new MySqlCommandBuilder(adapter);
                    adapter.InsertCommand = My.GetInsertCommand();
                    adapter.Update(ds.Tables[0]);
                }

            }
            else 

            {
                selectedState = "master";

                WinNewMaster WNM = new WinNewMaster();
                WNM.ShowDialog();
                if ((Transfer.ValueInt4 != 0) & (Transfer.ValueInt1 != 0) & (Transfer.ValueInt2 != 0))
                {
                    String sql = "select * From master";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);
                    DataSet ds = new DataSet("garantii");
                    adapter.Fill(ds);
                    // MyRowCount = ds.Tables[0].Rows.Count;
                    var MyNewRow = ds.Tables[0].NewRow();
                    // MyNewRow[0] = MyRowCount + 1;
                    MyNewRow[1] = Transfer.ValueString1;
                    MyNewRow[2] = Transfer.ValueString2;
                    MyNewRow[3] = Transfer.ValueString3;
                    MyNewRow[4] = Transfer.ValueDouble1;
                    MyNewRow[5] = Transfer.ValueInt1;
                    MyNewRow[6] = Transfer.ValueInt2;
                    MyNewRow[7] = Transfer.ValueInt4;
                   /* MessageBox.Show(Transfer.ValueString1 + " " + Transfer.ValueString2 + " " + Transfer.ValueString3 + " "
                        + Transfer.ValueDouble1.ToString()+ " " + Transfer.ValueInt1.ToString()
                        + " " + Transfer.ValueInt2.ToString() + " " + Transfer.ValueInt4.ToString());*/
                    ds.Tables[0].Rows.Add(MyNewRow);
                    DG1.DataContext = ds.Tables[0];
                    MySqlCommandBuilder My = new MySqlCommandBuilder(adapter);
                    adapter.InsertCommand = My.GetInsertCommand();
                    adapter.Update(ds.Tables[0]);
                }
                //changeData_IsClicked(sender, e);
            }
            changeData_IsClicked(sender, e);


        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }
        private void Delete_Row_Click(object sender, RoutedEventArgs e)
        {
            string selectedState = ComboBox.Text;
            if (selectedState == "Аппаратура")
                selectedState = "apparatura";
            else if (selectedState == "Клиенты")
                selectedState = "klient";
            else if (selectedState == "Заказ")
                selectedState = "zakaz";
            else 
                selectedState = "master";
            if (DG1.SelectedIndex == -1) 
            {
                MessageBox.Show("Строка для удаления не выделена");
            }
            else
            {
                int index;
                string sql = "select * from " + selectedState;
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);
                DataSet ds = new DataSet("garantii");
                adapter.Fill(ds);
                index = DG1.SelectedIndex;
                ds.Tables[0].Rows[index].Delete();
                MySqlCommandBuilder My = new MySqlCommandBuilder(adapter);
                adapter.DeleteCommand = My.GetDeleteCommand();
                adapter.Update(ds.Tables[0]);
                ds.Tables[0].AcceptChanges();
                DG1.DataContext = ds.Tables[0];
            }


        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            System.Data.DataTable filterTable;
            string filterValue, filterValueL, filterValueR, filterColumnName, filter;
            int l, r;
            double dl, dr;
            if (TablesList.SelectedItems.Count == 0)
            {
                filterColumnName = null;
                MessageBox.Show("Не выбрано имя столбца для поиска");
            }
            else
            {
                filterColumnName = TablesList.SelectedItem.ToString();
                if (condition.Text == "=")
                {
                    if (int.TryParse(searchConditionLeft.Text, out l) || double.TryParse(searchConditionLeft.Text, out dl))
                    {
                        filterValue = searchConditionLeft.Text;
                        filter = filterColumnName + " " + condition.Text + " '" + filterValue + "'";
                        DataRow[] helpDataRows = HelpTable.Select(filter);
                        filterTable = HelpTable.Clone();
                        for (int i = 0; i < helpDataRows.Length; i++)
                        {
                            filterTable.ImportRow(helpDataRows[i]);
                        }
                        DG1.DataContext = filterTable;
                    }
                    else
                    {
                        MessageBox.Show("Некорректные условия поиска");
                    }
                }
                else if (condition.Text == "<>")
                {
                    if (int.TryParse(searchConditionLeft.Text, out l) || double.TryParse(searchConditionLeft.Text, out dl))
                    {
                        filterValue = searchConditionLeft.Text;
                        filter = filterColumnName + " <>'" + filterValue + "'";
                        DataRow[] helpDataRows = HelpTable.Select(filter);
                        filterTable = HelpTable.Clone();
                        for (int i = 0; i < helpDataRows.Length; i++)
                        {
                            filterTable.ImportRow(helpDataRows[i]);
                        }
                        DG1.DataContext = filterTable;
                    }
                    else
                    {
                        MessageBox.Show("Некорректные условия поиска");
                    }
                }
                else if (condition.Text == "<")
                {
                    if (int.TryParse(searchConditionLeft.Text, out l) || double.TryParse(searchConditionLeft.Text, out dl))
                    {
                        filterValue = searchConditionLeft.Text;
                        filter = filterColumnName + " <'" + filterValue + "'";
                        DataRow[] helpDataRows = HelpTable.Select(filter);
                        filterTable = HelpTable.Clone();
                        for (int i = 0; i < helpDataRows.Length; i++)
                        {
                            filterTable.ImportRow(helpDataRows[i]);
                        }
                        DG1.DataContext = filterTable;
                    }
                    else
                    {
                        MessageBox.Show("Некорректные условия поиска");
                    }
                }
                else if (condition.Text == "<=")
                {
                    if (int.TryParse(searchConditionLeft.Text, out l) || double.TryParse(searchConditionLeft.Text, out dl))
                    {
                        filterValue = searchConditionLeft.Text;
                        filter = filterColumnName + " <='" + filterValue + "'";
                        DataRow[] helpDataRows = HelpTable.Select(filter);
                        filterTable = HelpTable.Clone();
                        for (int i = 0; i < helpDataRows.Length; i++)
                        {
                            filterTable.ImportRow(helpDataRows[i]);
                        }
                        DG1.DataContext = filterTable;
                    }
                    else
                    {
                        MessageBox.Show("Некорректные условия поиска");
                    }
                }
                else if (condition.Text == ">")
                {
                    if (int.TryParse(searchConditionLeft.Text, out l) || double.TryParse(searchConditionLeft.Text, out dl))
                    {
                        filterValue = searchConditionLeft.Text;
                        filter = filterColumnName + " " + condition.Text + " '" + filterValue + "'";
                        DataRow[] helpDataRows = HelpTable.Select(filter);
                        filterTable = HelpTable.Clone();
                        for (int i = 0; i < helpDataRows.Length; i++)
                        {
                            filterTable.ImportRow(helpDataRows[i]);
                        }
                        DG1.DataContext = filterTable;
                    }
                    else
                    {
                        MessageBox.Show("Некорректные условия поиска");
                    }
                }
                else if (condition.Text == ">=")
                {
                    if (int.TryParse(searchConditionLeft.Text, out l) || double.TryParse(searchConditionLeft.Text, out dl))
                    {
                        filterValue = searchConditionLeft.Text;
                        filter = filterColumnName + " " + condition.Text + " '" + filterValue + "'";
                        DataRow[] helpDataRows = HelpTable.Select(filter);
                        filterTable = HelpTable.Clone();
                        for (int i = 0; i < helpDataRows.Length; i++)
                        {
                            filterTable.ImportRow(helpDataRows[i]);
                        }
                        DG1.DataContext = filterTable;
                    }
                    else
                    {
                        MessageBox.Show("Некорректные условия поиска");
                    }
                }
                else if (condition.Text == "BETWEEN")
                {
                    if ((int.TryParse(searchConditionLeft.Text, out l) && int.TryParse(searchConditionRight.Text, out r)) || (double.TryParse(searchConditionLeft.Text, out dl) || double.TryParse(searchConditionRight.Text, out dr)))
                    {
                        filterValueL = searchConditionLeft.Text;
                        filterValueR = searchConditionRight.Text;
                        filter = filterColumnName + " >'" + filterValueL + "' AND " + filterColumnName + " <'" + filterValueR + "'";
                        DataRow[] helpDataRows = HelpTable.Select(filter);
                        filterTable = HelpTable.Clone();
                        for (int i = 0; i < helpDataRows.Length; i++)
                        {
                            filterTable.ImportRow(helpDataRows[i]);
                        }
                        DG1.DataContext = filterTable;
                    }
                    else
                    {
                        MessageBox.Show("Некорректные условия поиска");
                    }
                }
                else if (condition.Text == "LIKE")
                {
                    if (int.TryParse(searchConditionLeft.Text, out l) || double.TryParse(searchConditionLeft.Text, out dl))
                    {
                        MessageBox.Show("Введено числовое значение");
                    }
                    else if (searchConditionLeft.Text != string.Empty)
                    {
                        filterValue = searchConditionLeft.Text;
                        filter = filterColumnName + " " + condition.Text + " " + "'" + filterValue + "'";
                        DataRow[] helpDataRows = HelpTable.Select(filter);
                        filterTable = HelpTable.Clone();
                        for (int i = 0; i < helpDataRows.Length; i++)
                        {
                            filterTable.ImportRow(helpDataRows[i]);
                        }
                        DG1.DataContext = filterTable;
                    }
                    else
                    {
                        MessageBox.Show("Некорректные условия поиска");
                    }
                }
            }

        }

        private void SearchReset_Click(object sender, RoutedEventArgs e)
        {
            DG1.DataContext = HelpTable;
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            {
                PrintDialog Printdlg = new PrintDialog();
                if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
                {
                    Size pageSize = new Size((int)Printdlg.PrintableAreaWidth, (int)Printdlg.PrintableAreaHeight);
                    DG1.Measure(pageSize);
                    DG1.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                    Printdlg.PrintVisual(DG1, Title);
                }
            }
        }

        private void Excel_Click(object sender, RoutedEventArgs e)
        {


            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            for (int j = 0; j < DG1.Columns.Count; j++)
            {
                Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15;
                myRange.Value2 = DG1.Columns[j].Header;
            }
            for (int i = 0; i < DG1.Columns.Count; i++)
            {
                for (int j = 0; j < DG1.Items.Count; j++)
                {
                    TextBlock b = DG1.Columns[i].GetCellContent(DG1.Items[j]) as TextBlock;
                   /* Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;*/

                    if (b != null)
                    {
                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                        myRange.Value2 = b.Text;
                    }
                }
            }
        }

        private void changeData_IsClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedState = ComboBox.Text;
                if (selectedState == "Аппаратура")
                    selectedState = "apparatura";
                else if (selectedState == "Клиенты")
                    selectedState = "klient";
                else if (selectedState == "Заказ")
                    selectedState = "zakaz";
                else
                    selectedState = "master";
                string sql = "Select * from " + selectedState;
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);
                DataSet ds = new DataSet("garantii");
                adapter.Fill(ds);
                DG1.DataContext = ds.Tables[0];
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        
        /*private void changeData_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string selectedState = ComboBox.Text;
                if (selectedState == "Аппаратура")
                    selectedState = "apparatura";
                else if (selectedState == "Клиенты")
                    selectedState = "klient";
                else if (selectedState == "Заказ")
                    selectedState = "zakaz";
                else
                    selectedState = "master";
                string sql = "Select * from " + selectedState;
                DataSet ds = new DataSet("garantii");
                MySqlConnection update = new MySqlConnection(dataConnect);
                MySqlCommand updCommand = new MySqlCommand(sql, update);
                updCommand.Connection = update;
                MySqlDataAdapter adapter = new MySqlDataAdapter(updCommand);
                MySqlCommandBuilder myCB = new MySqlCommandBuilder(adapter);
                adapter.UpdateCommand = myCB.GetUpdateCommand();
                adapter.Fill(ds);
                try
                {
                    if (DG1.SelectedIndex == -1)
                    {
                        MessageBox.Show("Не выбрана строка для обновления");
                    }
                    else
                    {
                        int index = DG1.SelectedIndex;
                        object row = DG1.Items[index];
                        var MyNewRow = ds.Tables[0].NewRow();
                        int columns = DG1.Columns.Count;
                        for (int j = 0; j < columns; ++j)
                        {
                            if ((DG1.SelectedCells[j].Column.GetCellContent(row) as TextBlock).Text != "")
                            {
                                try
                                {
                                    ds.Tables[0].Rows[index][j] = (DG1.SelectedCells[j].Column.GetCellContent(row) as TextBlock).Text;
                                }
                                catch (MySql.Data.MySqlClient.MySqlException ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally
                                {
                                    Console.WriteLine("Невеный тип данных.");
                                }
                            }
                        }
                        update.Open();
                        adapter.UpdateCommand = myCB.GetUpdateCommand();
                        adapter.Update(ds);
                        update.Close();
                        changeData_IsClicked(sender, e);
                    }
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/

        private void DG1_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string Filter = "";
            var t = e.EditingElement as System.Windows.Controls.TextBox;
            DataGridRow row = e.Row;
            int rowIndex = ((DataGrid)sender).ItemContainerGenerator.IndexFromContainer(row);
            DataGridColumn column = e.Column;
            int columnIndex = column.DisplayIndex;

            DataRowView dataRow = (DataRowView)DG1.SelectedItem;
            string cellValue = dataRow.Row.ItemArray[0].ToString();
            string lastValue = dataRow.Row.ItemArray[columnIndex].ToString();

            switch (ComboBox.Text)
            {
                case "Аппаратура":
                    Filter = "UPDATE apparatura SET " + cch + "='" + t.Text + "' WHERE idapparatura = " + cellValue;
                    break;
                case "Клиенты":
                    Filter = "UPDATE klient SET " + cch + "='" + t.Text + "' WHERE idklient = " + cellValue;
                    break;
                case "Заказ":
                    Filter = "UPDATE zakaz SET " + cch + "='" + t.Text + "' WHERE idzakaz = " + cellValue;
                    break;
                case "Мастер":
                    Filter = "UPDATE master SET " + cch + "='" + t.Text + "' WHERE idmaster = '" + cellValue + "'";
                    break;
            }



            using (MySqlConnection connection = new MySqlConnection(dataConnect))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(Filter, connection);
                try
                {
                    command.ExecuteNonQuery();
                    condition.IsEnabled = true;
                    Open.IsEnabled = true;
                    ComboBox.IsEnabled = true;
                    Create_Row.IsEnabled = true;
                    Delete_Row.IsEnabled = true;
                    Excel.IsEnabled = true;
                    ExportPDF.IsEnabled = true;
                    Print.IsEnabled = true;
                    Search.IsEnabled = true;
                    searchConditionLeft.IsEnabled = true;
                    searchConditionRight.IsEnabled = true;
                    TablesList.IsEnabled = true;
                    SearchReset.IsEnabled = true;
                }
                catch
                {
                    condition.IsEnabled = false;
                    Open.IsEnabled = false;
                    ComboBox.IsEnabled = false;
                    Create_Row.IsEnabled = false;
                    Delete_Row.IsEnabled = false;
                    Excel.IsEnabled = false;
                    ExportPDF.IsEnabled = false;
                    Print.IsEnabled = false;
                    Search.IsEnabled = false;
                    searchConditionLeft.IsEnabled = false;
                    searchConditionRight.IsEnabled = false;
                    TablesList.IsEnabled = false;
                    SearchReset.IsEnabled = false;

                    MessageBox.Show("Введены некорректные данные");
                    //(e.Row.Item as DataRowView).Row[rowIndex + 1] = lastValue;
                }

                connection.Close();
            }


        }

        private void ExportPDF_Click(object sender, RoutedEventArgs e)
        {
            PdfPTable table = new PdfPTable(DG1.Columns.Count);
            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);

            string mydocu = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            PdfWriter writer = PdfWriter.GetInstance(doc, new System.IO.FileStream(mydocu + @"\aaa.pdf", System.IO.FileMode.Create));
            doc.Open();

            for (int j = 0; j < DG1.Columns.Count; j++)
            {
                table.AddCell(new Phrase(DG1.Columns[j].Header.ToString()));
            }
            table.HeaderRows = 1;
            IEnumerable itemSource = DG1.ItemsSource as IEnumerable; // hhh
            if (itemSource != null)
            {
                foreach (var item in itemSource)
                {
                    DataGridRow row = DG1.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                    if (row != null)
                    {
                        DataGridCellsPresenter presenter = Help.FindVisualChild<DataGridCellsPresenter>(row);
                        for (int i = 0; i < DG1.Columns.Count; ++i)
                        {
                            DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(i);
                            TextBlock txt = cell.Content as TextBlock;
                            if (txt != null)
                            {
                                table.AddCell(new Phrase(txt.Text));
                            }

                        }
                    }
                }
                doc.Add(table);
                doc.Close();
                MessageBox.Show("Таблица была сохранена в папку с вашими документами");
            }
        }

        private void DG1_PreparingCellForEdit(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            cch = DG1.CurrentCell.Column.Header.ToString();
            condition.IsEnabled = false;
            Open.IsEnabled = false;
            ComboBox.IsEnabled = false;
            Create_Row.IsEnabled = false;
            Delete_Row.IsEnabled = false;
            Excel.IsEnabled = false;
            ExportPDF.IsEnabled = false;
            Print.IsEnabled = false;
            Search.IsEnabled = false;
            searchConditionLeft.IsEnabled = false;
            searchConditionRight.IsEnabled = false;
            TablesList.IsEnabled = false;
            SearchReset.IsEnabled = false;

        }

        private void shaping_Click(object sender, RoutedEventArgs e)
        {

            int selectInd = DG1.SelectedIndex;
            string time = DateTime.Now.ToString("dd_MM_yyyy HH_mm");

            if (selectInd != -1)
            {
                DataRowView dataRow = (DataRowView)DG1.SelectedItem;
                switch (ComboBox.Text)
                {
                    case "Заказ":
                        string idzakaza = dataRow.Row.ItemArray[0].ToString();
                        string den = dataRow.Row.ItemArray[4].ToString();
                        string mec = dataRow.Row.ItemArray[5].ToString();
                        string god = dataRow.Row.ItemArray[6].ToString();
                        string cost = dataRow.Row.ItemArray[9].ToString();

                        string templateFileName = Environment.CurrentDirectory + "\\blanks\\1rep.docx";
                        var wordApp = new Microsoft.Office.Interop.Word.Application();
                        wordApp.Visible = false;

                        var wordDocument = wordApp.Documents.Open(templateFileName);
                        Help.ReplaceWordStab("{idzakaza}", idzakaza, wordDocument);
                        Help.ReplaceWordStab("{den}", den, wordDocument);
                        Help.ReplaceWordStab("{mec}", mec, wordDocument);
                        Help.ReplaceWordStab("{god}", god, wordDocument);
                        Help.ReplaceWordStab("{cost}", cost, wordDocument);
                        Help.ReplaceWordStab("{cost}", cost, wordDocument);
                        Help.ReplaceWordStab("{cost}", cost, wordDocument);



                        string tempName = Environment.CurrentDirectory + "\\readyreports\\Time " + time + " receipt.docx";
                        MessageBox.Show(tempName);
                        wordDocument.SaveAs(tempName);
                        wordApp.Visible = true;
                        break;
                    case "Клиент":
                     
                        break;
                    case "Мастер":

                        break;
                    case "Аппаратура":

                        break;

                }

            }
        }

        private void report_Click(object sender, RoutedEventArgs e)
        {
          ReportBrowser RB = new ReportBrowser();
          RB.ShowDialog();
        }

        private void Talon_Click(object sender, RoutedEventArgs e)
        {
            int selectInd = DG1.SelectedIndex;
            string time = DateTime.Now.ToString("dd_MM_yyyy HH_mm");

            if (selectInd != -1)
            {
                DataRowView dataRow = (DataRowView)DG1.SelectedItem;
                switch (ComboBox.Text)
                {
                    case "Клиенты":
                        string famil = dataRow.Row.ItemArray[2].ToString();
                        string imya = dataRow.Row.ItemArray[3].ToString();
                        string otch = dataRow.Row.ItemArray[4].ToString();
                        string inn = dataRow.Row.ItemArray[5].ToString();
                        string idzakaz = dataRow.Row.ItemArray[18].ToString();


                        string templateFileName = Environment.CurrentDirectory + "\\blanks\\2rep.docx";
                        var wordApp = new Microsoft.Office.Interop.Word.Application();
                        wordApp.Visible = false;

                        var wordDocument = wordApp.Documents.Open(templateFileName);
                        Help.ReplaceWordStab("{famil}", famil, wordDocument);
                        Help.ReplaceWordStab("{imya}", imya, wordDocument);
                        Help.ReplaceWordStab("{otch}", otch, wordDocument);
                        Help.ReplaceWordStab("{inn}", inn, wordDocument);
                        Help.ReplaceWordStab("{idzakaz}", idzakaz, wordDocument);




                        string tempName = Environment.CurrentDirectory + "\\readyreports\\Time " + time + " garantTalon.docx";
                        MessageBox.Show(tempName);
                        wordDocument.SaveAs(tempName);
                        wordApp.Visible = true;
                        break;
                    case "Заказ":

                        break;
                    case "Мастер":

                        break;
                    case "Аппаратура":

                        break;

                }

            }
        }
    }

    class Help
    {
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject obj)
        where T : DependencyObject
        {
            if (obj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(obj, i);

                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
        public static childItem FindVisualChild<childItem>(DependencyObject obj)
        where childItem : DependencyObject
        {
            foreach (childItem child in FindVisualChildren<childItem>(obj))
            {
                return child;
            }
            return null;
        }

        public static void ReplaceWordStab(string stabToReplace, string text, Microsoft.Office.Interop.Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stabToReplace, ReplaceWith: text);
        }
    }

}
