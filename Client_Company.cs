using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class Client_Company : Client
    {
        #region Поля
        /// <summary>
        /// ID клиента
        /// </summary>
        string iUser;
        /// <summary>
        /// Имя
        /// </summary>
       // string frtsName;
        /// <summary>
        /// Фамилия
        /// </summary>
        string compName;
        /// <summary>
        /// Дата рождения
        /// </summary>
        DateTime createDay;
        /// <summary>
        /// Паспорт
        /// </summary>
        uint inn;
        /// <summary>
        /// Адресс
        /// </summary>
       // Adress adress;
        /// <summary>
        /// Место работы
        /// </summary>
      //  Worck worck;
        /// <summary>
        /// Количество средств
        /// </summary>
      //  string finance;
        /// <summary>
        /// Банковский рейтинг
       // /// </summary>
       // string bankRating;
        /// <summary>
        /// Сумма Кредита
        /// </summary>
       // int credit;
        /// <summary>
        /// статус 
        /// </summary>
       // string status;
        /// <summary>
        /// Вклады
        /// </summary>
       // int deposits;

        #endregion


        public Client_Company()
        {
        }

        public Client_Company(string compName, DateTime createDay, uint inn, string finance, Adress adress, string status)
        {
            LstName = compName;
            CreateDay = createDay;
            Inn = inn;
            Finance = finance;
            //BankRating = bankRating;
            //Credit = credit;
            Status = status;
            //Deposits = deposits;
            Adress = adress;
        }

        public string CompName { get => compName; set => compName = value; }
        public DateTime CreateDay { get => createDay; set => createDay = value; }
        public uint Inn { get => inn; set => inn = value; }
      
    }
}
