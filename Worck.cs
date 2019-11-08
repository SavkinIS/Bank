using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
   public class Worck
    {
        #region Поля
        /// <summary>
        /// Имя компании
        /// </summary>
        string compName;

        /// <summary>
        /// Бюджет
        /// </summary>
        string budget;
        /// <summary>
        /// Количество работников
        /// </summary>
        string workers;
        /// <summary>
        /// Адрес работы
        /// </summary>
        Adress adressWork;
        /// <summary>
        /// ИНН
        /// </summary>
        string iNN;


        #endregion

        #region Конструктор
        public Worck() { }
        public Worck(string compName, string workers, Adress adressWork)
        {
            CompName = compName;
            Workers = workers;
            AdressWork = adressWork;
        }
        #endregion

        #region Свойства
        public string CompName { get => compName; set => compName = value; }
        public string Budget { get => budget; set => budget = value; }
        public string Workers { get => workers; set => workers = value; }
        public string INN { get => iNN; set => iNN = value; }
        internal Adress AdressWork { get => adressWork; set => adressWork = value; }
        #endregion


        #region Metods

        internal string FullWork()
        {
            return CompName;
        }
        #endregion
    }
}
