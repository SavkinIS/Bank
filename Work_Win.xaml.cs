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
    /// Логика взаимодействия для Work_Win.xaml
    /// </summary>
    public partial class Work_Win : Window
    {
        internal Worck worck = new Worck();
        Adress adress = new Adress();
        public Work_Win(Worck worck)
        {
            this.worck = worck;
            adress = this.worck.AdressWork;
            InitializeComponent();
            PrintWork();
        }


        /// <summary>
        /// Обрабатыват вводимые данные  и закрывает окно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Tb_CompName.Text.Trim() != "" && Tb_Workers.Text.Trim() != "" && adress.City  != null && adress.House != null && adress.Street != null && adress.Room != null)
            {
                
                    worck = new Worck(Tb_CompName.Text, Tb_Workers.Text, adress);
                    Close();
                

                
                
            }
            else
            {
                MessageBox.Show("Вы ввели некоректные значения!");
            }
        }

        
        /// <summary>
        /// открывает окно адреса обрабатывает и сохраняет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_CompAdress_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Addres_Win addres_Win = new Addres_Win(adress);
            addres_Win.ShowDialog();
            adress = addres_Win.adress;
            if (adress.City != null && adress.House != null && adress.Street != null && adress.Room != null)
            {
                try
                {
                    if (adress.City.Trim() != "" && adress.House.Trim() != "" && adress.Street.Trim() != "" && adress.Room.Trim() != "")
                    {
                        Tb_CompAdress.Text = adress.FullAdres();
                    }
                    else
                    {
                        MessageBox.Show("Значения Адресса не коректны");
                    }
                }
                catch(Exception q)
                {
                    MessageBox.Show(q.Message);
                }

                
            }
            else
            {
                MessageBox.Show("Значения Адресса не коректны");
            }

        }
        /// <summary>
        /// метод Заполняет поля если данные о работе уже вводились
        /// </summary>
        void PrintWork()
        {
            try
            {
                var cn = worck.CompName.ToString();
                Tb_CompName.Text = cn;
                cn = worck.Workers.ToString();
                Tb_Workers.Text = cn;
                cn = worck.AdressWork.FullAdres();
                Tb_CompAdress.Text = cn ;
            }
            catch
            {

            }
        }
    }
}
