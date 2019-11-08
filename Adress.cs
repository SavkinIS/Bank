using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
   public class Adress
    {
        /// <summary>
        /// город
        /// </summary>
        string city;
        /// <summary>
        /// улица
        /// </summary>
        string street;
        /// <summary>
        /// дом
        /// </summary>
        string house;
        /// <summary>
        /// квартира
        /// </summary>
        string room;

        /// <summary>
        /// Конструктор
        /// </summary>
        public Adress() { }
        /// <summary>
        /// Конструктор
        /// </summary>
        public Adress(string city, string street, string house, string room)
        {
            City = city;
            Street = street;
            House = house;
            Room = room;
        }
        #region Свойства
        public string City { get => city; set => city = value; }
        public string Street { get => street; set => street = value; }
        public string House { get => house; set => house = value; }
        public string Room { get => room; set => room = value; }
        #endregion

        /// <summary>
        /// Метод ыозвращает адресс в одной строке
        /// </summary>
        /// <returns></returns>
        internal string FullAdres()
        {
            return this.city + " " + this.street + " " + this.house + " " + this.room;
        }


    }


}
