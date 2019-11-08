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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
       internal AddClientLogic AL = new AddClientLogic();

        public AddClient()
        {
            InitializeComponent();
            AL.ComboItem(Cb_Status);

        }


        /// <summary>
        /// сохраняет нового клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AL.SaveNewClient(Cb_Status, NumPassport, LstName, FstName, BrthDay, Bt_Rating);
            
        }

    

        /// <summary>
        /// открывает окно ввода данный о Адреле клиента и отображает его
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Adres_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AL.AddAdress(Adres);
        }

        /// <summary>
        /// Открывает окно ввода данных о работе и отображает его
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tbk_Work_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AL.AddWork(Tbk_Work, Cb_Status);
        }

        /// <summary>
        /// Изменение контента при выборе статуса в ComboBox Cb_Status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cb_Status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            AL.ChangeContent(Cb_Status,FstName, LFN,  LLN, LW, Tbk_Work, LINN, LBd);

        }
    }


   
}
