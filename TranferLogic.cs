using MyExtention;///Библиотека Расширений
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BankApp
{
    class TranferLogic
    {
        public TranferLogic()
        {
        }

        Agent agent = new Agent();
        internal ObservableCollection<Cash_Account> curent_acc = new ObservableCollection<Cash_Account>();
        List<Helper_transfer> helper = new List<Helper_transfer>();
        Cash_Account cur_acc1 = new Cash_Account();

        /// <summary>
        ///  Заполняет поля при инициализации
        /// </summary>
        /// <param name="curent_acc_SEND"></param>
        /// <param name="selected_acc"></param>
        internal void Initialaze(ObservableCollection<Cash_Account> curent_acc_SEND, Cash_Account selected_acc, ComboBox Combo_Selected_Acc, TextBlock Current_Acc, TextBlock Current_Finance)
        {
            curent_acc = curent_acc_SEND;

            cur_acc1 = selected_acc;
            foreach (var cur in curent_acc)
            {
                if (cur.IdCashAcc != selected_acc.IdCashAcc)
                {
                    helper.Add(new Helper_transfer(cur.IdCashAcc.ToString()));
                }

            }

            Combo_Selected_Acc.ItemsSource = curent_acc;
            Current_Acc.Text = selected_acc.IdCashAcc;
            Current_Finance.Text = selected_acc.Acc_finance;

        }

        /// <summary>
        /// Переводит средства со счета на счет
        /// </summary>
        /// <param name="Combo_Selected_Acc"></param>
        /// <param name="Sum_Transfer"></param>
        /// <param name="Selected_Finance"></param>
        internal void Trasfer(ComboBox Combo_Selected_Acc, TextBox Sum_Transfer, TextBlock Selected_Finance, TextBlock Current_Finance)
        {
            if (Sum_Transfer.Text != "")
            {
                try
                {
                    var id = ((Cash_Account)Combo_Selected_Acc.SelectedItem);
                    (MainWindow.ML.all_Cash_Accounts[id.Client.Passport])[0].Client.SetLeve();

                    if ((MainWindow.ML.all_Cash_Accounts[id.Client.Passport])[0].Client.Work == true)
                    {

                        // var id = ((Cash_Account)Combo_Selected_Acc.SelectedItem);
                        uint sum_toTrans = 0;
                        if (UInt32.TryParse(Sum_Transfer.Text, out sum_toTrans)) { }
                        else { throw new MyExeption("Вы ввели некоректную сумму для перевода"); }


                        if (sum_toTrans > Convert.ToUInt32(Selected_Finance.Text))
                        {
                            MessageBox.Show("Недостаточно средств!");
                        }


                        else
                        {

                            foreach (var acc in curent_acc)
                            {
                                if (id == acc)
                                {
                                    ///Используются методы расширения
                                    acc.Acc_finance = acc.Acc_finance.SubUint(sum_toTrans);
                                   // acc.Acc_finance = (Convert.ToUInt32(acc.Acc_finance) - sum_toTrans).ToString();
                                    //Selected_Finance.Text = acc.Acc_finance;
                                }
                                else if (acc.IdCashAcc == cur_acc1.IdCashAcc)
                                {

                                    ///Используются методы расширения
                                    acc.Acc_finance = acc.Acc_finance.SumUint(sum_toTrans);
                                    //БЫЛО
                                   // acc.Acc_finance = (Convert.ToUInt32(acc.Acc_finance) + sum_toTrans).ToString();
                                    Current_Finance.Text = acc.Acc_finance;
                                }
                            }
                            Sum_Transfer.BorderBrush = Brushes.Gray;
                            Combo_Selected_Acc.SelectedItem = null;
                            Sum_Transfer.Text = "";
                            Ev_Mes += Mes;
                            Ev_Mes("Вы перевели " + sum_toTrans.ToString());
                            var l = new Logi(("Перевод междусчитами на сумму "+ sum_toTrans + "p. " + (DateTime.Now).ToString()));
                            MainWindow.ML.LogiAll.Logis.Add(l);
                            MainWindow.ML.LogiAll.Save();

                            Ev_Mes -= Mes;
                        }
                    }
                }

                catch (MyExeption e)
                {
                    Sum_Transfer.BorderBrush = Brushes.Red;
                    MessageBox.Show("Вы ввели некоректные данные. " + e.Message);
                }

               
            }
            else { MessageBox.Show("ВВедите Сумму перевода."); }
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

    class Helper_transfer
    {
        string account;

        public Helper_transfer()
        {

        }

        public Helper_transfer(string account)
        {
            Account = account;
        }

        public string Account { get => account; set => account = value; }
    }
}
