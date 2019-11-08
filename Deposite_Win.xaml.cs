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
    /// Логика взаимодействия для Deposite_Win.xaml
    /// </summary>
    public partial class Deposite_Win : Window
    {
        DepositLogic Dl = new DepositLogic();

        public Deposite_Win(uint passport)
        {
            InitializeComponent();
            Dl.Initialaze(passport,Combo_Selected_type, Rating, Procents);

        }

        /// <summary>
        /// считает сумму прибыли при выборе капитализации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bt_Open_Click(object sender, RoutedEventArgs e)
        {
            Dl.Canculate(Combo_Selected_type, Tbx_time, Tbx_SumIn, Finance_after_time);

        }


        /// <summary>
        /// открывает вклад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bt_Close_Click(object sender, RoutedEventArgs e)
        {
            Dl.Open(Tbx_time, Tbx_SumIn);

        }
    }

   
}
