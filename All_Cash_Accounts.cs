using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class All_Cash_Accounts<T>
        where T : Cash_Account
    {
        /// <summary>
        /// список всех счетов
        /// </summary>
        ObservableCollection<T> all_cash_acc;


        /// <summary>
        /// Конструктор
        /// </summary>
        public All_Cash_Accounts()
        {
            all_cash_acc = new ObservableCollection<T>();
        }


        /// <summary>
        /// Индексатор по клиенту
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public ObservableCollection<Cash_Account> this[uint passport]
        {
            get
            {
                var a = new ObservableCollection<Cash_Account>();
                foreach( var acc in All_cash_acc)
                {
                    if (acc.Client.Passport == passport)
                    {
                        a.Add(acc);

                    }
                    else if(acc.Client.Passport == 0)
                    {
                        if(((Client_Company)acc.Client).Inn == passport)
                        {
                            a.Add(acc);
                        }
                    }
                }

                return a;
            }
        }


        /// <summary>
        /// свойство
        /// </summary>
        public ObservableCollection<T> All_cash_acc { get => all_cash_acc; set => all_cash_acc = value; }
    }
}
