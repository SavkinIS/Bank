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
    /// Логика взаимодействия для Transfer_Win.xaml
    /// </summary>
   public partial class Transfer_Win : Window
    {
       internal TranferLogic TL = new TranferLogic();

       internal Transfer_Win(ObservableCollection<Cash_Account> curent_acc_SEND, Cash_Account selected_acc)
        {
            InitializeComponent();

            TL.Initialaze(curent_acc_SEND, selected_acc, Combo_Selected_Acc, Current_Acc, Current_Finance);

            
        }


        /// <summary>
        /// Переводит средства со счета на счет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bt_trans_Click(object sender, RoutedEventArgs e)
        {
            TL.Trasfer(Combo_Selected_Acc, Sum_Transfer, Selected_Finance, Current_Finance);
        }

        
    }

    
}
