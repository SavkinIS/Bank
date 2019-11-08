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
    class CreditLogic
    {
        public CreditLogic()
        {
        }

        int procents = 16;
        uint passport;
        int rating = 0;

        /// <summary>
        /// Заполняет поля при инициализации
        /// </summary>
        /// <param name="passport">uint passport</param>
        /// <param name="Tb_rating">TextBlock Tb_rating</param>
        /// <param name="Tb_Procent">TextBlock Tb_Procent</param>
        internal void Initialaze(uint passport, TextBlock Tb_rating, TextBlock Tb_Procent)
        {
            this.passport = passport;
            rating = MainWindow.ML.clientData[passport].Rating;
            procents -= rating;
            Tb_rating.Text = "Кредитный рейтинг " + rating + ".";
            Tb_Procent.Text = "Итоговый процент " + (procents) + ".";
        }


        /// <summary>
        /// Выдача нового кредита
        /// </summary>
        /// <param name="Tbx_SumCredit"></param>
        /// <param name="Tbx_period"></param>
        internal void GiveCredit(TextBox Tbx_SumCredit, TextBox Tbx_period)
        {
            try
            {    int x = 0;
                int y = 0;
                if (Int32.TryParse(Tbx_SumCredit.Text, out x) && Int32.TryParse(Tbx_period.Text, out y)) { }
                else {throw new MyExeption("Проверьте коректность вводимых данных."); }

                
                if (Convert.ToInt32(Tbx_SumCredit.Text) > 0 && Convert.ToInt32(Tbx_period.Text) > 0)
                {

                    MainWindow.ML.all_Cash_Accounts.All_cash_acc.Add(new Cash_Account(MainWindow.ML.clientData[passport],
                                                                                    MainWindow.ML.all_Cash_Accounts.All_cash_acc,
                                                                                    "Кредит",
                                                                                    Tbx_SumCredit.Text,
                                                                                    Tbx_period.Text));
                    foreach (Window window in App.Current.Windows)
                    {
                        if (window is Credit_Win)
                        {
                            window.Close();
                            Ev_Mes += Mes;
                            Ev_Mes("Выдан кредит на " + Tbx_SumCredit.Text + " Руб.");
                            MainWindow.ML.LogiAll.Logis.Add(new Logi(("Выдан новый кредит на сумму " + Tbx_SumCredit.Text + " Руб. " + (DateTime.Now).ToString())));
                            MainWindow.ML.LogiAll.Save();
                        }
                           
                    }
                }
                else
                {
                    MessageBox.Show("Вводимые значения должны быть положительными!");
                }
                

            }
            catch(MyExeption e)
            {
                
                Tbx_period.BorderBrush = Brushes.Red;
                Tbx_SumCredit.BorderBrush = Brushes.Red;
                MessageBox.Show(e.Message );
            }
        }

        /// <summary>
        /// Производит расчет ежемесячного платежа
        /// </summary>
        /// <param name="Tbx_SumCredit"></param>
        /// <param name="Tbx_period"></param>
        /// <param name="Tb_PayforMonth"></param>
        internal void CalculateCredit(TextBox Tbx_SumCredit, TextBox Tbx_period, TextBlock Tb_PayforMonth)
        {
            try
            {
                if (Tbx_SumCredit.Text != "" && Tbx_period.Text != "")
                {
                    double sumCRD = 0;
                    double sum = Convert.ToDouble(Tbx_SumCredit.Text);

                    double period = Convert.ToInt32(Tbx_period.Text);

                    double years = (period / 12);


                    double monthProc = (procents / 12.0) / 100;


                    double kofAut = (monthProc * Math.Pow(1 + monthProc, period)) / (Math.Pow(1 + monthProc, period) - 1);
                    sumCRD = sum * kofAut;

                    Tb_PayforMonth.Text = "Ежемесячный платёж " + (sumCRD.ToString("f2"));

                    Tbx_period.BorderBrush = Brushes.Gray;
                    Tbx_SumCredit.BorderBrush = Brushes.Gray;
                }

            }
            catch
            {
                Tbx_period.BorderBrush = Brushes.Red;
                Tbx_SumCredit.BorderBrush = Brushes.Red;
                MessageBox.Show("Проверьте коректность вводимых данных");
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
}
