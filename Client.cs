using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankApp
{

    /// <summary>
    /// Клиент Банка
    /// </summary>
   public class Client  : IComparable
    {

        #region Поля
        /// <summary>
        /// ID клиента
        /// </summary>
        string iUser;
        /// <summary>
        /// Имя
        /// </summary>
        string frtsName;
        /// <summary>
        /// Фамилия
        /// </summary>
        string lstName;
        /// <summary>
        /// Дата рождения
        /// </summary>
        DateTime bthDay;
        /// <summary>
        /// Паспорт
        /// </summary>
        uint passport;
        /// <summary>
        /// Адресс
        /// </summary>
        Adress adress;
        /// <summary>
        /// Место работы
        /// </summary>
        Worck worck;
        /// <summary>
        /// Количество средств
        /// </summary>
        string finance;
        /// <summary>
        /// Банковский рейтинг
        /// </summary>
        string bankRating;
        /// <summary>
        /// Сумма Кредита
        /// </summary>
        int credit;
        /// <summary>
        /// статус 
        /// </summary>
        string status;
        /// <summary>
        /// Вклады
        /// </summary>
        int deposits;
        /// <summary>
        /// Кредитный рейтинг
        /// </summary>
        int rating;

        List<Cash_Account> cash_Accounts;


        #endregion


        #region Конструктор
        public Client()
        {
        }

        public Client(string frtsName, string lstName, DateTime bthDay, uint passport, string finance, Adress adress, Worck worck)
        {
            FrtsName = frtsName;
            LstName = lstName;
            BthDay = bthDay;
            Passport = passport;
            Finance = finance;
            Adress = adress;
            Worck = worck;
            Rating = 0;
           
        }

       

        #endregion

        #region Свойства
        public string FrtsName { get => frtsName; set => frtsName = value; }
        public string LstName { get => lstName; set => lstName = value; }
        public DateTime BthDay { get => bthDay; set => bthDay = value; }
        public uint Passport { get => passport; set => passport = value; }
        public string Finance { get => finance; set => finance = value; }
        
        public string BankRating { get => bankRating; set => bankRating = value; }
        public int Credit { get => credit; set => credit = value; }
        public string Status { get => status; set => status = value; }
        public int Deposits { get => deposits; set => deposits = value; }
        public int Rating { get => rating; set => rating = value; }
        internal Adress Adress { get => adress; set => adress = value; }
        internal Worck Worck { get => worck; set => worck = value; }
        internal List<Cash_Account> Cash_Accounts { get => cash_Accounts; set => cash_Accounts = value; }

        public int CompareTo(object obj)
        {
            return lstName.CompareTo(obj);
        }



        #endregion


        /// <summary>
        /// уровень активности
        /// </summary>
        int level;


        /// <summary>
        /// Время первого перевода
        /// </summary>
        DateTime firstTrans;

        bool work = true;
        /// <summary>
        ///Свойство. получить уровень активности
        /// </summary>
        public int GetLevel => level;

        public bool Work { get => work; set => work = value; }

        /// <summary>
        ///Свойство. установить уровень Активности
        /// /// </summary>
        public void SetLeve()
        {
            if (this.level == 0)
            {
                firstTrans = DateTime.Now;
                this.level += 1;

            }
            else if (this.level < 4 && this.level != 0)
            {
                this.level += 1;
            }

            else if (this.level == 4)
            {
                if (DateTime.Now.Subtract(firstTrans) < new TimeSpan(0, 30, 0))
                {
                    Ev_Mes += Mes;
                    var s = DateTime.Now.Subtract(firstTrans);
                    Ev_Mes("Вы привысили лимит операций попробуте через + " + new TimeSpan(0, 30, 0).Subtract(s).TotalMinutes);
                    Work = false;
                    Ev_Mes -= Mes;
                }

                else
                {
                    this.level = 0;
                }
            }





        }

        /// <summary>
        /// блокировка
        /// </summary>
       
        

        /// <summary>
        /// Событие
        /// </summary>
        public event Action<string> Ev_Mes;

        /// <summary>
        /// сообщенеи для события
        /// </summary>
        /// <param name="a"></param>
        void Mes(string a)
        {
            MessageBox.Show(a);
        }
    }
}
