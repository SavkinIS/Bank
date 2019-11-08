using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankApp
{
    class Logi_All 
        
    {

       /// <summary>
       /// Поле
       /// </summary>
        List<Logi> logis;


        ///Конструктор
        public Logi_All()
                
        {
            Logis = new List<Logi>();
        }

        /// <summary>
        /// Метод Десиреализации
        /// </summary>
        /// <returns>Возвращает колекцию логов</returns>
        internal void Read()


        {
            try
            {

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto

                };
                var json = File.ReadAllText("Logi.json");



                List<Logi> some = JsonConvert.DeserializeObject<List<Logi>>(json);
                this.logis =  some;
            }

            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                //return new List<Logi>();
            }
        }
        
        /// <summary>
        /// Метод Ыериализации
        /// </summary>
        /// <param name="a">Объект сериализации</param>
        internal void Save()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto

            };

            string json = JsonConvert.SerializeObject(this.logis);
            File.AppendAllText("Logi.json", json);
        }

        /// <summary>
        /// Свойство
        /// </summary>
        internal List<Logi> Logis
        {
            get => this.logis;
            set
            {
                this.logis = value;
                
            }
        }

        
        
    }
}
