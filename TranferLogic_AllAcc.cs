using MyExtention;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BankApp
{
    class TranferLogic_AllAcc
    {
        Agent agent = new Agent();
        Cash_Account selected_acc;
        int selectedId = 0;
        int needId = -1;


        /// <summary>
        ///  Заполняет поля при инициализации
        /// </summary>
        /// <param name="curent_acc_SEND"></param>
        /// <param name="selected_acc"></param>
        internal void Initialaze( Cash_Account selected_acc,  TextBlock Current_Acc, TextBlock Current_Finance)
        {


            this.selected_acc = selected_acc;
            Current_Acc.Text = selected_acc.IdCashAcc;
            Current_Finance.Text = selected_acc.Acc_finance;

        }

        /// <summary>
        /// Находит ID счета который переводи и счета на который переводит
        /// </summary>
        /// <param name="TB_Selected_Acc"></param>
        /// <param name="Selected_Finance"></param>
        internal void TBLostFocus(TextBox TB_Selected_Acc, TextBlock Selected_Finance)
        {
            for(int i = 0; i< MainWindow.ML.all_Cash_Accounts.All_cash_acc.Count; i++)
            {

                if (MainWindow.ML.all_Cash_Accounts.All_cash_acc[i] == selected_acc)
                {
                    selectedId = i;
                }

                else if (MainWindow.ML.all_Cash_Accounts.All_cash_acc[i].IdCashAcc == TB_Selected_Acc.Text)
                {
                    Selected_Finance.Text = MainWindow.ML.all_Cash_Accounts.All_cash_acc[i].Acc_finance;

                    needId = i;
                }

                
            }

            if(needId == -1)
            {
                MessageBox.Show("Введеный вами счет не существует");
            }

        }


        /// <summary>
        /// Перевод средств между клиентами
        /// </summary>
        /// <param name="Sum_Transfer"></param>
        internal void Transfer(TextBox Sum_Transfer, TextBlock Selected_Finance, TextBlock Current_Finance)
        {

            try
            {
                MainWindow.ML.all_Cash_Accounts.All_cash_acc[selectedId].Client.SetLeve();

                if( agent.Work == true)
                {
                    int x = 0;
                    if (Int32.TryParse(Sum_Transfer.Text, out x)) { }
                    else { throw new MyExeption("Сумма Перевода введена не корректно"); }

                    if(needId == -1) { throw new MyExeption("Вы пытаетесь сделать перевод на несуществующий счет!"); }
                    int sum = Convert.ToInt32(Sum_Transfer.Text);

                   // Перегрузка операторов > 
                    if (sum > 0 || MainWindow.ML.all_Cash_Accounts.All_cash_acc[selectedId] < sum /*sum < Convert.ToInt32(MainWindow.ML.all_Cash_Accounts.All_cash_acc[selectedId].Acc_finance)*/)
                    {
                        ///Используются методы расширения
                        MainWindow.ML.all_Cash_Accounts.All_cash_acc[selectedId].Acc_finance = MainWindow.ML.all_Cash_Accounts.All_cash_acc[selectedId].Acc_finance.SubUint(sum);

                        MainWindow.ML.all_Cash_Accounts.All_cash_acc[needId].Acc_finance = MainWindow.ML.all_Cash_Accounts.All_cash_acc[needId].Acc_finance.SumUint(sum);
                        //было
                        //MainWindow.ML.all_Cash_Accounts.All_cash_acc[selectedId].Acc_finance = (Convert.ToInt32(MainWindow.ML.all_Cash_Accounts.All_cash_acc[selectedId].Acc_finance) - sum).ToString();
                        //MainWindow.ML.all_Cash_Accounts.All_cash_acc[needId].Acc_finance = (Convert.ToInt32(MainWindow.ML.all_Cash_Accounts.All_cash_acc[needId].Acc_finance) + sum).ToString();
                        var cl = MainWindow.ML.all_Cash_Accounts.All_cash_acc[selectedId].Client;
                        var one = MainWindow.ML.all_Cash_Accounts.All_cash_acc[selectedId].IdCashAcc;
                        var two = MainWindow.ML.all_Cash_Accounts.All_cash_acc[needId].IdCashAcc;
                        Logi l = new Logi(("Перевод мeждусчитами " +one  + " и "+two+"  на сумму " + sum + "p. " + (DateTime.Now).ToString()) );
                        MainWindow.ML.LogiAll.Logis.Add(l);
                        MainWindow.ML.LogiAll.Save();

                        Current_Finance.Text = MainWindow.ML.all_Cash_Accounts.All_cash_acc[selectedId].Acc_finance;
                        Selected_Finance.Text = MainWindow.ML.all_Cash_Accounts.All_cash_acc[needId].Acc_finance;

                        Ev_Mes += Mes;
                        Ev_Mes("Вы перевели " + sum.ToString());
                        Ev_Mes -= Mes;
                    }
                    else
                    {
                        MessageBox.Show("Вы ввели не коректную сумму");
                    }
                }


                
            }

            catch(MyExeption e)
            {
                MessageBox.Show("Проверьте вводимые значения. " + e.Message);
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
