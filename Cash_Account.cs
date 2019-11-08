using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankApp
{
 internal class Cash_Account :INotifyPropertyChanged
    {
        /// <summary>
        ///Номер счета 
        /// </summary>
        string idCashAcc;

        /// <summary>
        /// Владелец счёта
        /// </summary>
        Client client;

        /// <summary>
        /// кол-во средст
        /// </summary>
        string acc_finance;
        /// <summary>
        /// Тип
        /// </summary>
        string type;
        /// <summary>
        /// Срок счета
        /// </summary>
        string period;

        bool active;

        #region Конструкторы
        public Cash_Account()
        {
        }

        public Cash_Account(  Client client, ObservableCollection<Cash_Account> cash_Accounts, string type, string acc_finance)
        {

            IdCashAcc = GetIDCash(cash_Accounts);
            Acc_finance = acc_finance;
            Client = client;
            Type = type;
            Acc_finance = acc_finance;
            Active = true;
        }

        public Cash_Account(Client client, ObservableCollection<Cash_Account> cash_Accounts, string type, string acc_finance, string period)
        {

            Active = true;
            IdCashAcc = GetIDCash(cash_Accounts);
            Acc_finance = acc_finance;
            Client = client;
            Type = type;
            Acc_finance = acc_finance;
            Period = period;
        }
        #endregion

        #region Свойства
        public string IdCashAcc { get => idCashAcc; set => idCashAcc = value; }
        public string Acc_finance
        {
            get => this.acc_finance;
            set
            {
                this.acc_finance = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Acc_finance)));
            }
        }
        public string Type { get => type; set => type = value; }
        public string Period { get => period; set => period = value; }
        public bool Active { get => active; set => active = value; }
        internal Client Client { get => client; set => client = value; }

        
        #endregion

        /// <summary>
        /// метод создаёт 12-ти значный код и проверяет его в базе
        /// </summary>
        /// <param name="cash_Accounts">база счетов</param>
        /// <returns></returns>
        string GetIDCash(ObservableCollection<Cash_Account> cash_Accounts)
        {
            string a = "";
            while (a == "")
            {
                Random rnd = new Random();

                for (int i = 0; i < 12; i++)
                {
                    a += rnd.Next(0, 9).ToString();

                }

                foreach (var id in cash_Accounts)
                {
                    if (a == id.IdCashAcc)
                    {
                        a = "";
                    }
                }
            }

            return a;
        }


        /// <summary>
        /// Событие
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;



        /// <summary>
        /// Перегрузка операций
        /// </summary>
        /// <param name="A">класс для сравнения</param>
        /// <param name="I">число для сравнения</param>
        /// <returns></returns>
        public static bool operator >(Cash_Account A, int I)
        {
            if(Convert.ToInt32(A.Acc_finance) > I)
            {
                return true;
            }
            else { return false; }
        }

        public static bool operator < (Cash_Account A, int I)
        {
            if (Convert.ToInt32(A.Acc_finance) > I)
            {
                return true;
            }
            else { return false; }
        }

    }
}
