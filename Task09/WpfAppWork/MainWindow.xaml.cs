using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace WpfAppWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker aWorker = new BackgroundWorker();

        private delegate void UpdateDelegate(int i);

        public MainWindow()
        {
            InitializeComponent();

            aWorker.WorkerSupportsCancellation = true;

            aWorker.DoWork += aWorker_DoWork;
            aWorker.RunWorkerCompleted += aWorker_RunWorkerCompleted;
        }

        private void UpdateLabel(int i)
        {
            label1.Content = "Cycles: " + i.ToString();
        }

        private void aWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 500; i++)
            {
                // simulate some work
                for (int j = 1; j <= 10000000; j++)
                {
                    
                }

                if (aWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                UpdateDelegate update = new UpdateDelegate(UpdateLabel);

                label1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, update, i);

            }

        }

        private void aWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!(e.Cancelled))
            {
                label2.Content = "Run Completed";
            }
            else
            {
                label2.Content = "Run Cancelled";
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            aWorker.RunWorkerAsync();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            aWorker.CancelAsync();
        }
    }
}
