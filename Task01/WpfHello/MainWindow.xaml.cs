﻿using System;
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

namespace WpfHello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isDataDirty = false;

        public MainWindow()
        {
            InitializeComponent();

            lbl.Content = "Hello world!";

            setBut.IsEnabled = false;
            retBut.IsEnabled = false;
        }


        private void setBut_Click(object sender, RoutedEventArgs e)
        {
            // Save the entered text to a file
            System.IO.StreamWriter sw = null;

            try
            {
                sw = new System.IO.StreamWriter("username.txt");

                // Save text from TextBox
                sw.WriteLine(setTex.Text);

                isDataDirty = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }

            retBut.IsEnabled = true;
        }

        private void retBut_Click(object sender, RoutedEventArgs e)
        {
            System.IO.StreamReader sr = null;
            try
            {
                using (sr = new System.IO.StreamReader("username.txt"))
                    retLabel.Content = "Greetings to you, " + sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

        }

        private void setTex_TextChanged(object sender, TextChangedEventArgs e)
        {
            setBut.IsEnabled = true;

            isDataDirty = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.isDataDirty)
            {
                string msg = "Data changed but not saved";

                MessageBoxResult result = MessageBox.Show(msg, "Unsaved changes", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
