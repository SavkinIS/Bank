using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для CashAccounts_Win.xaml
    /// </summary>
    public partial class CashAccounts_Win : Window
    {
        CashAccountLogic CaL = new CashAccountLogic();

        internal CashAccounts_Win( uint passport, ClientData clientData)
        {
            
            InitializeComponent();

            CaL.Initialaze(passport, clientData, TxClientName, Lv_cashAcc);



        }

        /// <summary>
        /// открывает окно перевода между счетами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bn_transfer_Click(object sender, RoutedEventArgs e)
        {
            CaL.Tranfer(Lv_cashAcc);
        }


        /// <summary>
        /// открывает окно воткрытия вклада
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bn_Deposit_Click(object sender, RoutedEventArgs e)
        {
            CaL.Deposit(Lv_cashAcc);
        }

        /// <summary>
        /// открвывает окно расчета кредита
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bn_Credit_Click(object sender, RoutedEventArgs e)
        {
            CaL.Credit(Lv_cashAcc);
        }

        /// <summary>
        /// Создает новый счет Дебетовый
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewCashAcc_Click(object sender, RoutedEventArgs e)
        {
            CaL.NewCashAcc(Lv_cashAcc);
        }

        /// <summary>
        /// удаляет выбранный аккаунт
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bn_Delete_Click(object sender, RoutedEventArgs e)
        {
            CaL.DeletAcc(Lv_cashAcc);
        }

        private void Bn_transferToUser_Click(object sender, RoutedEventArgs e)
        {
            CaL.TransferToClient(Lv_cashAcc);
        }
    }
}
