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
    /// Логика взаимодействия для TransferToClient_Win.xaml
    /// </summary>
    public partial class TransferToClient_Win : Window
    {
        TranferLogic_AllAcc TL = new TranferLogic_AllAcc();

        internal TransferToClient_Win(Cash_Account selected_acc)
        {
            InitializeComponent();
            TL.Initialaze(selected_acc, Current_Acc, Current_Finance);
        }


        /// <summary>
        /// Отображает количество средств на выбранном счете
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TB_Selected_Acc_LostFocus(object sender, RoutedEventArgs e)
        {
            TL.TBLostFocus(TB_Selected_Acc, Selected_Finance);

        }


        /// <summary>
        /// Перевод средсв открываети ообрабатывает окно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bt_trans_Click(object sender, RoutedEventArgs e)
        {
            TL.Transfer(Sum_Transfer, Selected_Finance, Current_Finance);
        }        
    }
}
