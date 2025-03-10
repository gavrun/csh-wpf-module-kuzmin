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

namespace WpfRoutedEvent_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show("Event handeled by TextBox");
            e.Handled = (bool)radBut1.IsChecked;
        }

        private void Grid_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show("Event handeled by Grid");
            e.Handled = (bool)radBut2.IsChecked;
        }

        private void Window_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show("Event handeled by Window");
            e.Handled = (bool)radBut3.IsChecked;
        }
    }
}
