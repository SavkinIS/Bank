using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BankApp
{

    /// <summary>
    /// Класс основной логики
    /// </summary>
    class MainLogic
    {
        internal Logi_All LogiAll = new Logi_All();
        
        internal  ClientData clientData = new ClientData();
        ClientData cD_VIP = new ClientData();
        internal  All_Cash_Accounts<Cash_Account> all_Cash_Accounts = new All_Cash_Accounts<Cash_Account>();

        internal MyEvents myEvents = new MyEvents();

        /// <summary>
        /// Начальный конструктор заполняет первичных клиентов
        /// </summary>
        public MainLogic()
        {

         
            Client client = new Client("Ivanov", "Ivan", new DateTime(1989, 12, 22), 13513, "5353", new Adress("Moscow", "Sovetskay", "22", "1"),
               new Worck("OOO NULL", "21", new Adress("Moscow", "Lenina", "1", "1")));
            client.Rating = 1;
            Client client_Vip = new Client("Smirnov", "Jon", new DateTime(1989, 12, 22), 19513, "5353", new Adress("Moscow", "Sovetskay", "22", "1"),
                new Worck("OOO NULL", "21", new Adress("Moscow", "Lenina", "1", "1")));
            client_Vip.Rating = 2;
            client_Vip.Status = "VIP";
            //cD_VIP.Clients.Add(client_Vip);
            clientData.Clients.Add(client);
            clientData.Clients.Add(client_Vip);
            clientData.Clients.Add(new Client_Company("OOO Data", new DateTime(1989, 12, 22), 28451486, "53844", new Adress("Moscow", "Lenina", "5", "1"), "COMPANY"));
        }



        /// <summary>
        /// Метод выводит список клиентов по статусу
        /// </summary>
        /// <param name="LV_Comp_Clients">ListView Клиенты компании </param>
        /// <param name="LV_VIP_Clients">ListView ВИП клиенты</param>
        /// <param name="LV_Standart">ListView обычные клиенты </param>
        internal void PrintClients( ListView LV_Comp_Clients, ListView LV_VIP_Clients, ListView LV_Standart)
        {
            LV_Comp_Clients.ItemsSource = clientData.Company_Clients();
            LV_VIP_Clients.ItemsSource = clientData.VIP_Clients();
            LV_Standart.ItemsSource = clientData.Sandart_Clients();
        }



        /// <summary>
        /// метод добавляет клиентов
        /// </summary>
        /// <param name="LV_Comp_Clients">ListView Клиенты компании </param>
        /// <param name="LV_VIP_Clients">ListView ВИП клиенты</param>
        /// <param name="LV_Standart">ListView обычные клиенты </param>
        internal void AddClient(ListView LV_Comp_Clients, ListView LV_VIP_Clients, ListView LV_Standart)
        {
            AddClient addClient = new AddClient();
            addClient.ShowDialog();
            
           //clientData.Clients.Add(addClient.AL.client);
            
            

           
            PrintClients(LV_Comp_Clients, LV_VIP_Clients, LV_Standart);
        }


        /// <summary>
        /// выводит данные клиента 
        /// </summary>
        /// <param name="LV">ListView из когорого выбран клиент</param>
        /// <param name="FstName">Имя</param>
        /// <param name="LstName">Фамилия</param>
        /// <param name="BrthDay">Дата рождения</param>
        /// <param name="NumPassport">Номе паспорта ил ИНН</param>
        /// <param name="Adres">Адрес</param>
        /// <param name="AllCash">Количество средств</param>
        /// <param name="Tb_rating">кредитный рейтинг</param>
        /// <param name="Tb_UserDeposit">Количество вкладов</param>
        /// <param name="Tbk_Work">место работы</param>
        internal void PrintClient(ListView LV, TextBlock FstName, TextBlock LstName, 
                                TextBlock BrthDay, TextBlock NumPassport,
                                TextBlock Adres, TextBlock AllCash, TextBlock Tb_rating, 
                                TextBlock Tb_UserDeposit, TextBlock Tbk_Work)
        {


            var cl = (Client)LV.SelectedItem;

            FstName.Text = cl.FrtsName;
            LstName.Text = cl.LstName;
            BrthDay.Text = cl.BthDay.ToUniversalTime().ToString();
            NumPassport.Text = cl.Passport.ToString();
            if (cl.Passport == 0)
            {
                NumPassport.Text = ((Client_Company)cl).Inn.ToString();
            }
            Adres.Text = cl.Adress.FullAdres();
            AllCash.Text = AllFinance(cl);
            Tb_rating.Text = cl.Rating.ToString();
            Tb_UserDeposit.Text = cl.Deposits.ToString();
            Tbk_Work.Text = "";
            if (cl.Worck != null)
            {
                Tbk_Work.Text = cl.Worck.FullWork();
            }

        }




        /// <summary>
        /// Выводит данные одно клиента физического лица
        /// </summary>
        /// <param name="L_name"></param>
        /// <param name="L_lname"></param>
        /// <param name="L_create"></param>
        /// <param name="L_pass"></param>
        /// <param name="L_work"></param>
        /// <param name="LV"></param>
        /// <param name="FstName"></param>
        /// <param name="LstName"></param>
        /// <param name="BrthDay"></param>
        /// <param name="NumPassport"></param>
        /// <param name="Adres"></param>
        /// <param name="AllCash"></param>
        /// <param name="Tb_rating"></param>
        /// <param name="Tb_UserDeposit"></param>
        /// <param name="Tbk_Work"></param>
        internal void PrintOneClient(Label L_name, Label L_lname, Label L_create, Label L_pass, Label L_work, 
                                ListView LV, TextBlock FstName, TextBlock LstName,
                                TextBlock BrthDay, TextBlock NumPassport,
                                TextBlock Adres, TextBlock AllCash, TextBlock Tb_rating,
                                TextBlock Tb_UserDeposit, TextBlock Tbk_Work)
        {
            ChangeLableBack(L_name, L_lname, L_create, L_pass, L_work);
            PrintClient(LV,  FstName,  LstName,
                                 BrthDay,  NumPassport,
                                 Adres,  AllCash, Tb_rating,
                                 Tb_UserDeposit,  Tbk_Work);
        }


        /// <summary>
        /// Выводит данные одной компании
        /// </summary>
        /// <param name="L_name"></param>
        /// <param name="L_lname"></param>
        /// <param name="L_create"></param>
        /// <param name="L_pass"></param>
        /// <param name="L_work"></param>
        /// <param name="LV"></param>
        /// <param name="FstName"></param>
        /// <param name="LstName"></param>
        /// <param name="BrthDay"></param>
        /// <param name="NumPassport"></param>
        /// <param name="Adres"></param>
        /// <param name="AllCash"></param>
        /// <param name="Tb_rating"></param>
        /// <param name="Tb_UserDeposit"></param>
        /// <param name="Tbk_Work"></param>
        internal void PrintOneCompany(Label L_name, Label L_lname, Label L_create, Label L_pass, Label L_work,
                                ListView LV, TextBlock FstName, TextBlock LstName,
                                TextBlock BrthDay, TextBlock NumPassport,
                                TextBlock Adres, TextBlock AllCash, TextBlock Tb_rating,
                                TextBlock Tb_UserDeposit, TextBlock Tbk_Work)
        {
            ChangeLableForCompany(L_name, L_lname, L_create, L_pass, L_work);
            PrintClient(LV, FstName, LstName,
                                 BrthDay, NumPassport,
                                 Adres, AllCash, Tb_rating,
                                 Tb_UserDeposit, Tbk_Work);
        }


        /// <summary>
        /// меняет Label для коректного отображения компании
        /// </summary>
        private void ChangeLableForCompany(Label L_name, Label L_lname, Label L_create, Label L_pass, Label L_work)
        {
            L_name.Content = "";
            L_lname.Content = "Имя Компании";
            L_create.Content = "Дата основания";
            L_pass.Content = "ИНН";
            L_work.Content = "";
        }
        /// <summary>
        /// возвращает изначельное значение Label
        /// </summary>
        private void ChangeLableBack(Label L_name, Label L_lname, Label L_create, Label L_pass, Label L_work)
        {
            L_name.Content = "Имя";
            L_lname.Content = "Фамилия";
            L_create.Content = "Дата рождения";
            L_pass.Content = "Номер Паспорта";
            L_work.Content = "Место работы";


        }




        /// <summary>
        /// Выводит сумму всех средств клиента
        /// </summary>
        /// <param name="cl"></param>
        /// <returns></returns>
        string AllFinance(Client cl)
        {
            double allFin = 0;
            var all_cash = all_Cash_Accounts[cl.Passport];

            foreach (var clt in all_cash)
            {
                if (clt.Type != "Кредит")
                {
                    allFin += Convert.ToDouble(clt.Acc_finance);
                }


            }
            return allFin.ToString("f2");
        }

        /// <summary>
        /// Метод открывает окно со Счеами
        /// </summary>
        /// <param name="NumPassport"></param>
        /// <param name="AllCash"></param>
        internal void OpenCashWin(TextBlock NumPassport, TextBlock AllCash)
        {
            if (NumPassport.Text == "")
            {
                MessageBox.Show("Выберите клиента");

            }
            else
            {
                CashAccounts_Win cash = new CashAccounts_Win(Convert.ToUInt32(NumPassport.Text), clientData);
                cash.ShowDialog();
                AllCash.Text = AllFinance(clientData[Convert.ToUInt32(NumPassport.Text)]);
            }
        }

        /// <summary>
        /// Удаляет Клиента и его счета
        /// </summary>
        /// <param name="NumPassport"></param>
        internal void DelClient(TextBlock NumPassport, TextBlock FstName, TextBlock LstName,
                                TextBlock BrthDay,
                                TextBlock Adres, TextBlock AllCash, TextBlock Tb_rating,
                                TextBlock Tb_UserDeposit, TextBlock Tbk_Work,
                                ListView LV_Comp_Clients, ListView LV_VIP_Clients, ListView LV_Standart)
        {
            try
            {
                uint pass = Convert.ToUInt32(NumPassport.Text);


                for (int i = 0; i < all_Cash_Accounts.All_cash_acc.Count(); i++)
                {
                    if (all_Cash_Accounts.All_cash_acc[i].Client == clientData[pass])
                    {
                        all_Cash_Accounts.All_cash_acc.Remove(all_Cash_Accounts.All_cash_acc[i]);
                    }
                }

                FstName.Text = "";
                LstName.Text = "";
                BrthDay.Text = "";
                NumPassport.Text = "";
                Adres.Text = "";
                AllCash.Text = "";
                Tb_rating.Text = "";
                Tb_UserDeposit.Text = "";
                Tbk_Work.Text = "";

                

                LogiAll.Logis.Add(new Logi(("Клиент " + clientData[pass].Passport.ToString() + " удалён" + (DateTime.Now).ToString())));
                LogiAll.Save();
                clientData.Clients.Remove(clientData[pass]);
                PrintClients(LV_Comp_Clients, LV_VIP_Clients, LV_Standart);
                MessageBox.Show("Клиент удалён!");
            }
            catch
            {
                MessageBox.Show("Выберите клиента");
            }
            


           

        }

        /// <summary>
        /// открывает окно логов
        /// </summary>
        internal void History()
        {
            LogiAll.Read();
            Logi_Win logi_Win = new Logi_Win();
            logi_Win.ShowDialog();
        }
    }
}
