using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfWinForms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> PhoneNumbers = new List<String>();

        SaveFileDialog aDialog;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MaskedTextBox aBox;

            aBox = (MaskedTextBox)windowsFormsHost1.Child;

            PhoneNumbers.Add(aBox.Text);

            aBox.Clear();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            aDialog = new SaveFileDialog();

            aDialog.Filter = "Text Files | *.txt";
            aDialog.ShowDialog();

            StreamWriter myWriter = new
            StreamWriter(aDialog.FileName, true);

            foreach (string s in PhoneNumbers)
            {
                myWriter.WriteLine(s);
            }
            
            myWriter.Close();
        }
    }
}
