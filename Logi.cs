using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp 
{
    class Logi : INotifyPropertyChanged
    {
        /// <summary>
        /// что произошло 
        /// </summary>
        string process;

        /// <summary>
        /// клиент;
        /// </summary>
     //   Client client;

        /// <summary>
        /// время процесса
        /// </summary>
        DateTime time_process;

        public Logi(string process)
        {
            Process = process;
           // Client= client;
            Time_process = DateTime.Now;

          
           
           
        }

        public string Process { get => process; set => process = value; }
       
        public DateTime Time_process { get => time_process; set => time_process = value; }
      //  public Client Client { get => client; set => client = value; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
