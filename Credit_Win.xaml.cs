using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для Credit_Win.xaml
    /// </summary>
    public partial class Credit_Win : Window
    {
        CreditLogic CL = new CreditLogic();
       
        public Credit_Win(uint passport)
        {
            InitializeComponent();
            CL.Initialaze(passport, Tb_rating, Tb_Procent);

        }

        /// <summary>
        /// Открывает новый кредитный счет и закрывает окно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Give_Click(object sender, RoutedEventArgs e)
        {
            CL.GiveCredit(Tbx_SumCredit, Tbx_period);
        }


        /// <summary>
        /// Отображае ежемесячный платёж
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {

            CL.CalculateCredit(Tbx_SumCredit, Tbx_period, Tb_PayforMonth);
        }

        
    }
}
