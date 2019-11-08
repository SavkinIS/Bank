using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BankApp
{
    class DepositLogic
    {
        public DepositLogic()
        {
        }


        List<Helper_deposite> helpD = new List<Helper_deposite> { new Helper_deposite("Ежемесячная капитализация"),
                                                                  new Helper_deposite("Ежегодная капитализация") };

        int procents = 12;
        uint passport;
        int rating = 0;

        /// <summary>
        ///  Заполняет поля при инициализации
        /// </summary>
        /// <param name="passport"></param>
        /// <param name="Combo_Selected_type"></param>
        /// <param name="Rating"></param>
        /// <param name="Procents"></param>
        internal void Initialaze(uint passport, ComboBox Combo_Selected_type, TextBlock Rating, TextBlock Procents)
        {
            this.passport = passport;

            rating = MainWindow.ML.clientData[passport].Rating;
            Combo_Selected_type.ItemsSource = helpD;
            Combo_Selected_type.SelectedIndex = 0;
            Rating.Text = rating.ToString();
            Procents.Text = (12 + rating).ToString();
            procents = (procents + rating);
        }

        /// <summary>
        /// Подсчитывает прибыль от вклада в зависимости от типа капитализации
        /// </summary>
        /// <param name="Combo_Selected_type"></param>
        /// <param name="Tbx_time"></param>
        /// <param name="Tbx_SumIn"></param>
        /// <param name="Finance_after_time"></param>
        internal void Canculate(ComboBox Combo_Selected_type, TextBox Tbx_time, TextBox Tbx_SumIn, TextBlock Finance_after_time)
        {
            try
            {


                if (((Helper_deposite)Combo_Selected_type.SelectedItem).Type == "Ежемесячная капитализация" && Tbx_SumIn.Text != "" && Tbx_time.Text != "")
                {
                    double beginsum = Convert.ToDouble(Tbx_SumIn.Text);
                    int month = Convert.ToInt32(Tbx_time.Text);

                    for (int m = 0; m < month; m++)
                    {
                        beginsum += ((beginsum / 100) * procents / 10);
                    }
                    Finance_after_time.Text = beginsum.ToString("f2");

                }
                else if (Tbx_SumIn.Text != "" && Tbx_time.Text != "")
                {
                    double beginsum = Convert.ToDouble(Tbx_SumIn.Text);
                    int month = Convert.ToInt32(Tbx_time.Text);



                    beginsum += ((beginsum / 100) * procents);

                    Finance_after_time.Text = beginsum.ToString("f2");

                }
            }

            catch (Exception e)
            {
                Tbx_SumIn.BorderBrush = Brushes.Red;
                Tbx_time.BorderBrush = Brushes.Red;

                MessageBox.Show("Проверьте коректность вводимых данных. " + e.Message);
            }

        }


        /// <summary>
        /// Открывает вклад и закрывает текущее окно
        /// </summary>
        /// <param name="Tbx_time"></param>
        /// <param name="Tbx_SumIn"></param>
        internal void Open(TextBox Tbx_time, TextBox Tbx_SumIn)
        {
            try
            {
                if (Convert.ToDouble(Tbx_SumIn.Text) > 0 && Convert.ToInt32(Tbx_time.Text) > 0)
                {
                    var ch_acc = new Cash_Account(MainWindow.ML.clientData[passport],
                                                                               MainWindow.ML.all_Cash_Accounts.All_cash_acc,
                                                                               "Вклад",
                                                                               Tbx_SumIn.Text,
                                                                               Tbx_time.Text);
                    MainWindow.ML.all_Cash_Accounts.All_cash_acc.Add(ch_acc);

                    //var cl1 = MainWindow.ML.all_Cash_Accounts.All_cash_acc.Last().Client;
                    var cl = MainWindow.ML.clientData[passport];
                    Ev_Mes += Mes;
                    Ev_Mes("Открыт вклад  на " + Tbx_SumIn.Text + " Руб.");
                    Ev_Mes -= Mes;
                    MainWindow.ML.LogiAll.Logis.Add(new Logi(("Выдан новый вклад на сумму " + Tbx_SumIn.Text + " Руб. " + (DateTime.Now).ToString())));
                    MainWindow.ML.LogiAll.Save();

                    foreach (Window window in App.Current.Windows)
                    {
                        if (window is Deposite_Win)
                            window.Close();
                    }
                }

            }
            catch (Exception e)
            {
                Tbx_SumIn.BorderBrush = Brushes.Red;
                Tbx_time.BorderBrush = Brushes.Red;

                MessageBox.Show("Проверьте коректность вводимых данных. " + e.Message);
            }


        }
        /// <summary>
        /// Инициализируем событие
        /// </summary>
        event Action<string> Ev_Mes;

        /// <summary>
        /// Метод выводит сообщение о закрытии
        /// </summary>
        void Mes(string a)
        {
            MessageBox.Show(a);
        }
    }


    /// <summary>
    /// Вспомагательный класс для ComboBox
    /// </summary>
    class Helper_deposite
    {
        string type;

        public Helper_deposite(string type)
        {
            Type = type;
        }

        public string Type { get => type; set => type = value; }
    }
}
