using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankApp
{
  

    class MyEvents
    {
        public MyEvents()
        {
            //Ev_Mes += Mes;
            //Ev_Mes("Вы перевели " + sum_toTrans.ToString());
            //MainWindow.ML.LogiAll.Logis.Add(new Logi(("Перевод мкждусчитами на сумму " + sum_toTrans + "p. " + (DateTime.Now).ToString()), cur_acc1.Client));
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
