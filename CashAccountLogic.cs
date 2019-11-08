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
    class CashAccountLogic
    {
        public CashAccountLogic()
        {
        }

        ObservableCollection<Cash_Account> curent_acc = new ObservableCollection<Cash_Account>();
        Cash_Account selected_acc = new Cash_Account();
        uint passport;

        /// <summary>
        /// Метод инициалиизации при запуске окна
        /// </summary>
        /// <param name="passport"></param>
        /// <param name="clientData"></param>
        /// <param name="TxClientName"></param>
        /// <param name="Lv_cashAcc"></param>
        internal void Initialaze(uint passport, ClientData clientData, TextBlock TxClientName, ListView Lv_cashAcc)
        {
            this.passport = passport;

            /// при запуске окна создант четыре счета автоматически
            MainWindow.ML.all_Cash_Accounts.All_cash_acc.Add(new Cash_Account(clientData[passport], MainWindow.ML.all_Cash_Accounts.All_cash_acc, "Дебетовый", "15546"));

            MainWindow.ML.all_Cash_Accounts.All_cash_acc.Add(new Cash_Account(clientData[passport], MainWindow.ML.all_Cash_Accounts.All_cash_acc, "Кредит", "10000"));

            MainWindow.ML.all_Cash_Accounts.All_cash_acc.Add(new Cash_Account(clientData[passport], MainWindow.ML.all_Cash_Accounts.All_cash_acc, "Вклад", "200000"));

            MainWindow.ML.all_Cash_Accounts.All_cash_acc.Add(new Cash_Account(clientData[passport], MainWindow.ML.all_Cash_Accounts.All_cash_acc, "Дебетовый", "5021"));

            // cash.All_cash_acc.Add(new Cash_Account(clientData[passport], cash.All_cash_acc));


            //контролирует коректное отображение для физ лиц и компаний

            if (clientData[passport].Status != "COMPANY")
            {
                TxClientName.Text = clientData[passport].LstName + " " + clientData[passport].FrtsName;
            }
            else
            {
                object cl = clientData[passport];
                TxClientName.Text = ((Client_Company)cl).LstName;
            }
            curent_acc = MainWindow.ML.all_Cash_Accounts[passport];
            Lv_cashAcc.ItemsSource = MainWindow.ML.all_Cash_Accounts[passport];
        }

        /// <summary>
        /// Открывает окно трансфера обрабатывает его и закрывает
        /// </summary>
        /// <param name="Lv_cashAcc"></param>
        internal void Tranfer(ListView Lv_cashAcc)
        {
            if (Lv_cashAcc.SelectedItem != null)
            {
                selected_acc = (Cash_Account)Lv_cashAcc.SelectedItem;
                Transfer_Win transfer = new Transfer_Win(curent_acc, selected_acc);

                transfer.ShowDialog();

                foreach (var acc in MainWindow.ML.all_Cash_Accounts.All_cash_acc)
                {
                    foreach (var acc_1 in transfer.TL.curent_acc)
                    {
                        if (acc.IdCashAcc == acc_1.IdCashAcc)
                        {
                            acc.Acc_finance = acc_1.Acc_finance;
                        }
                    }
                }
                Lv_cashAcc.ItemsSource = MainWindow.ML.all_Cash_Accounts[passport];
            }
            else
            {
                MessageBox.Show("Выберите счет");
            }
        }

        /// <summary>
        /// Открывает окно Открытия депозита обрабатывает его и закрывает
        /// </summary>
        /// <param name="Lv_cashAcc"></param>
        internal void Deposit(ListView Lv_cashAcc)
        {
            Deposite_Win deposite = new Deposite_Win(passport);
            deposite.ShowDialog();
            Lv_cashAcc.ItemsSource = MainWindow.ML.all_Cash_Accounts[passport];
        }


        /// <summary>
        /// Открывает окно Кредита депозита обрабатывает его и закрывает
        /// </summary>
        /// <param name="Lv_cashAcc"></param>
        internal void Credit(ListView Lv_cashAcc)
        {
            Credit_Win credit = new Credit_Win(passport);
            credit.ShowDialog();
            Lv_cashAcc.ItemsSource = MainWindow.ML.all_Cash_Accounts[passport];
        }

        /// <summary>
        /// Создаёт новый счет с нулевым балансом
        /// </summary>
        /// <param name="Lv_cashAcc"></param>
        internal void NewCashAcc(ListView Lv_cashAcc)
        {
            MainWindow.ML.all_Cash_Accounts.All_cash_acc.Add(new Cash_Account(MainWindow.ML.clientData[passport],
                                                                            MainWindow.ML.all_Cash_Accounts.All_cash_acc,
                                                                            "Дебетовый",
                                                                             "0"));
            Ev_Mes += Mes;
            Ev_Mes("Открыт новый счет " + MainWindow.ML.all_Cash_Accounts.All_cash_acc.Last().IdCashAcc);
            
            MainWindow.ML.LogiAll.Logis.Add(new Logi(("Был открыт новый счет " + MainWindow.ML.all_Cash_Accounts.All_cash_acc.Last().IdCashAcc +" " + (DateTime.Now).ToString())));
            MainWindow.ML.LogiAll.Save();
            Ev_Mes -= Mes;
            Lv_cashAcc.ItemsSource = MainWindow.ML.all_Cash_Accounts[passport];
        }

        /// <summary>
        /// Удаляет выбраный счет
        /// </summary>
        /// <param name="Lv_cashAcc"></param>
        internal void DeletAcc(ListView Lv_cashAcc)
        {
            if (Lv_cashAcc.SelectedItem != null)
            {
                Cash_Account selected = (Cash_Account)Lv_cashAcc.SelectedItem;

                for (int i = 0; i < MainWindow.ML.all_Cash_Accounts.All_cash_acc.Count(); i++)
                {
                    if (MainWindow.ML.all_Cash_Accounts.All_cash_acc[i] == selected)
                    {
                        MainWindow.ML.all_Cash_Accounts.All_cash_acc.Remove(MainWindow.ML.all_Cash_Accounts.All_cash_acc[i]);
                    }
                }
                
                Ev_Mes += Mes;
                Ev_Mes("Вы удалили счет " + selected.IdCashAcc);
                MainWindow.ML.LogiAll.Logis.Add(new Logi(("Был удалён счет " + selected.IdCashAcc + " " + (DateTime.Now).ToString())));
                MainWindow.ML.LogiAll.Save();
                 Ev_Mes -= Mes;
            }

           
            
            Lv_cashAcc.ItemsSource = MainWindow.ML.all_Cash_Accounts[passport];
        }


        /// <summary>
        /// Открывае окно перевода другому клиенту
        /// </summary>
        /// <param name="Lv_cashAcc"></param>
        internal void TransferToClient( ListView Lv_cashAcc)
        {
            selected_acc = (Cash_Account)Lv_cashAcc.SelectedItem;
            if(selected_acc == null)
            {
                MessageBox.Show("Выберите счет с которого хотите сделать перевод");
            }
            else
            {
                TransferToClient_Win tla = new TransferToClient_Win(selected_acc);
                tla.ShowDialog();
                Lv_cashAcc.ItemsSource = MainWindow.ML.all_Cash_Accounts[passport];
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
