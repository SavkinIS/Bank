using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankApp
{
   internal class ClientData
      
    {
        /// <summary>
        /// Список клиентов
        /// </summary>
       ObservableCollection<Client> clients;

        public ClientData()
        {
            Clients = new ObservableCollection<Client>();
        }


        /// <summary>
        /// Индексатор
        /// </summary>
        /// <param name="iUser"></param>
        /// <returns></returns>
        public Client this[uint passport]
        {
            get
            {
                var a = new Client();
                for (int i = 0; i < Clients.Count; i++)
                {
                    
                    if(Clients[i].Passport == passport && Clients[i].Passport != 0)
                    {
                        a =  Clients[i];
                    }
                    else if(Clients[i].Passport == 0)
                    {

                        Client f = Clients[i];
                        object fo = f;
                        Client_Company co = (Client_Company)fo;
                        if (((Client_Company)fo).Inn == passport)
                        {
                            a = Clients[i];
                        }
                    }
                }
                return a;
            }

        }

        public ObservableCollection<Client> Clients { get => clients; set => clients = value; }

        /// <summary>
        /// метод возвращает список ВИП клиентов
        /// </summary>
        /// <returns></returns>
       internal ObservableCollection<Client> VIP_Clients()
        {
            ObservableCollection<Client> vip = new ObservableCollection<Client> ();
            for(int i = 0; i < this.clients.Count(); i++)
            {
                if(clients[i].Status == "VIP")
                {
                    vip.Add(clients[i]);
                }
            }
            return vip;
        }

        /// <summary>
        /// Метод Возвращает список клиентов компаний
        /// </summary>
        /// <returns></returns>
        internal ObservableCollection<Client> Company_Clients()
        {
            ObservableCollection<Client> client = new ObservableCollection<Client>();
            for (int i = 0; i < this.clients.Count(); i++)
            {
                if (clients[i].Status == "COMPANY")
                {
                    client.Add(clients[i]);
                }
            }
            return client;
        }
        /// <summary>
        /// Метод возвращает список Стандартных компаний
        /// </summary>
        /// <returns></returns>
        internal ObservableCollection<Client> Sandart_Clients()
        {
            ObservableCollection<Client> client = new ObservableCollection<Client>();
            for (int i = 0; i < this.clients.Count(); i++)
            {
                if (clients[i].Status != "VIP" && clients[i].Status != "COMPANY")
                {
                    client.Add(clients[i]);
                }
            }
            return client;
        }
    }
}
