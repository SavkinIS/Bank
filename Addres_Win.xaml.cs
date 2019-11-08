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
    /// Логика взаимодействия для Addres_Win.xaml
    /// </summary>
    public partial class Addres_Win : Window
    {
        internal Adress adress = new Adress();
        public Addres_Win(Adress adress)
        {
            this.adress = adress;
            InitializeComponent();
            PrintAdress();
        }

        /// <summary>
        /// Сохраняет адрес
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Tb_City.Text.Trim() != ""&& Tb_Street.Text.Trim() != "" && Tb_House.Text.Trim() != "" && Tb_Flat.Text.Trim() != "")
            {
                adress = new Adress(Tb_City.Text, Tb_Street.Text, Tb_House.Text, Tb_Flat.Text);
                Close();
            }

            else
            {
                MessageBox.Show("Вы ввели некоректные значения!");
            }
             
            
        }

        /// <summary>
        /// метод заполняет поля если адресс был введен ранее
        /// </summary>
        void PrintAdress()
        {
            try
            {
                var cl = adress.City;
                Tb_City.Text = cl;
                cl = adress.Street;
                Tb_Street.Text = cl;
                cl = adress.House;
                Tb_House.Text = cl;
                cl = adress.Room;
                Tb_Flat.Text = cl;
            }
            catch
            {

            }
        }
    }
}
