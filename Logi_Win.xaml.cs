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

namespace BankApp
{
    /// <summary>
    /// Логика взаимодействия для Logi_Win.xaml
    /// </summary>
    public partial class Logi_Win : Window
    {
        public Logi_Win()
        {
            
            InitializeComponent();
            LV_Logs.ItemsSource = MainWindow.ML.LogiAll.Logis;
                
        }
    }
}
