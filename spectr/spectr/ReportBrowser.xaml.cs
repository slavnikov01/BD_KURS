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
using System.Windows.Xps.Packaging;
using Microsoft.Office.Interop.Word;

namespace spectr
{
    /// <summary>
    /// Логика взаимодействия для ReportBrowser.xaml
    /// </summary>
    public partial class ReportBrowser : System.Windows.Window
    {
        public ReportBrowser()
        {
            InitializeComponent();
        }

        private XpsDocument ConvertWordDocToXPSDoc(string wordDocName, string xpsDocName)
        {
            Microsoft.Office.Interop.Word.Application
                wordApplication = new Microsoft.Office.Interop.Word.Application();
            wordApplication.Documents.Add(wordDocName);

            Document doc = wordApplication.ActiveDocument;

            try
            {
                doc.SaveAs(xpsDocName, WdSaveFormat.wdFormatXPS);
                wordApplication.Quit();

                XpsDocument xpsDoc = new XpsDocument(xpsDocName, System.IO.FileAccess.Read);
                return xpsDoc;
            }
            catch (Exception exp)
            {
                string str = exp.Message;
            }
            return null;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".doc*";
            dlg.Filter = "Word documents (.doc*)|*.doc*";

            dlg.InitialDirectory = Environment.CurrentDirectory + "\\readyreports";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                if (dlg.FileName.Length > 0)
                {
                    string newXPSDocumentName = String.Concat(System.IO.Path.GetDirectoryName(dlg.FileName),
                        System.IO.Path.GetFileNameWithoutExtension(dlg.FileName), ".xps");

                    DocumentViever.Document = ConvertWordDocToXPSDoc(dlg.FileName, newXPSDocumentName).GetFixedDocumentSequence();
                }
            }
           
        }
    }
}
