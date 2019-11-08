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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

       internal static MainLogic ML = new MainLogic();
        public static event Action<string> Ev_one;

        public MainWindow()
        {
            InitializeComponent();


            ML.PrintClients(LV_Comp_Clients, LV_VIP_Clients, LV_Standart);
           
        }

        /// <summary>
        /// Открывает окно добавления клиента, добавляет клиента и обновляет LIstViews
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddClient(object sender, RoutedEventArgs e)
        {
            ML.AddClient(LV_Comp_Clients, LV_VIP_Clients, LV_Standart);


        }

        
        /// <summary>
        /// отобразить обычного клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LV_Standart_GotFocus(object sender, RoutedEventArgs e)
        {
            ML.PrintOneClient(L_name, L_lname, L_create, L_pass, L_work, LV_Standart, FstName, LstName,
                                 BrthDay, NumPassport,
                                 Adres, AllCash, Tb_rating,
                                 Tb_UserDeposit, Tbk_Work);
        }

        /// <summary>
        /// отобразить ВИП клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LV_VIP_Clients_GotFocus(object sender, RoutedEventArgs e)
        {
            ML.PrintOneClient(L_name, L_lname, L_create, L_pass, L_work, LV_VIP_Clients, FstName, LstName,
                                 BrthDay, NumPassport,
                                 Adres, AllCash, Tb_rating,
                                 Tb_UserDeposit, Tbk_Work);
        }

        /// <summary>
        /// отобразить клиента компанию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VL_Comp_Clients_GotFocus(object sender, RoutedEventArgs e)
        {
            ML.PrintOneCompany(L_name, L_lname, L_create, L_pass, L_work, LV_Comp_Clients, FstName, LstName,
                                 BrthDay, NumPassport,
                                 Adres, AllCash, Tb_rating,
                                 Tb_UserDeposit, Tbk_Work);
        }


        /// <summary>
        /// Обновить список
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TC_Bank_office_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ML.PrintClients(LV_Comp_Clients, LV_VIP_Clients, LV_Standart);
        }


        
        /// <summary>
        /// Открывает окно счетов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bt_CashAcc_Click(object sender, RoutedEventArgs e)
        {

            ML.OpenCashWin(NumPassport, AllCash);


        }


      
        /// <summary>
        /// Удаляет клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ML.DelClient(NumPassport,FstName, LstName,
                                 BrthDay,
                                Adres, AllCash, Tb_rating,
                                 Tb_UserDeposit,Tbk_Work,
                                 LV_Comp_Clients, LV_VIP_Clients, LV_Standart);
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            
            ML.History();
        }
    }
}
