using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BankApp
{
    class AddClientLogic
    {
        /// <summary>
        /// конструктор
        /// </summary>
        public AddClientLogic()
        {

        }
        /// <summary>
        /// Клиент который будет добавлен
        /// </summary>
        internal Client client = new Client();
        /// <summary>
        /// Адрес нового клиента
        /// </summary>
        Adress adress = new Adress();
        /// <summary>
        /// Место работы нового клиента
        /// </summary>
        Worck work = new Worck();

        /// <summary>
        /// Заполняет ComboBox 
        /// </summary>
        /// <param name="Cb_Status"></param>
        internal void ComboItem(ComboBox Cb_Status)
        {
            List<AddClient_Helper> client_Helpers = new List<AddClient_Helper>();
            client_Helpers.Add(new AddClient_Helper("VIP"));
            client_Helpers.Add(new AddClient_Helper("STANDART"));
            client_Helpers.Add(new AddClient_Helper("COMPANY"));
            Cb_Status.ItemsSource = client_Helpers;
        }

        /// <summary>
        /// Сохраняет нового клиента и закрывает текущее окно
        /// </summary>
        /// <param name="Cb_Status">ComboBox выбора статуса</param>
        /// <param name="NumPassport">TextBox паспорта или ИНН</param>
        /// <param name="LstName">TextBox Фамилии</param>
        /// <param name="FstName">TextBox Имени</param>
        /// <param name="BrthDay">DatePicker Дня рождения</param>
        /// <param name="Bt_Rating">TextBox Кпедитного рейтинга</param>
        internal void SaveNewClient(ComboBox Cb_Status, TextBox NumPassport, TextBox LstName, TextBox FstName, DatePicker BrthDay, TextBox Bt_Rating)
        {
            try
            {
                bool flag = true;
            if (NumPassport.Text != "")
            {


                    //Если клиент Компания
                    if (((AddClient_Helper)Cb_Status.SelectedValue).Status == "COMPANY")
                    {


                        ///проверка ИНН на совпадение 
                        foreach (var cl in MainWindow.ML.clientData.Clients)
                        {
                            if (cl.Passport == 0)
                            {

                                object clc = cl;
                                if (NumPassport.Text != "")
                                {
                                    try
                                    {
                                        if (Convert.ToUInt32(NumPassport.Text) == ((Client_Company)clc).Inn)
                                        {
                                            MessageBox.Show("Клиент с таким ИНН  уже существует!");

                                            NumPassport.Text = "";
                                            flag = false;
                                            break;
                                        }
                                    }
                                    catch


                                    {
                                        MessageBox.Show("Номер ИНН должен сосоять только из чисел");
                                        flag = false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Вы не заполнили все поля");
                                    flag = false;
                                }


                            }

                        }


                        if (flag == true)
                        {
                            try
                            {
                                 var client = new Client_Company(LstName.Text, Convert.ToDateTime(BrthDay.Text), Convert.ToUInt32(NumPassport.Text), "0", adress, "COMPANY");
                                
                                client.Rating = Convert.ToInt32(Bt_Rating.Text);
                                MainWindow.ML.clientData.Clients.Add(client);



                                MainWindow.ML.LogiAll.Logis.Add(new Logi((client.Inn.ToString() + " ДОБАВЛЕН в " + (DateTime.Now).ToString())));
                                MainWindow.ML.LogiAll.Save();
                                Bt_Rating.BorderBrush = Brushes.Gray;
                            }
                            catch
                            {
                                MessageBox.Show("Рейтинг должен состоять из целых чисел");
                                Bt_Rating.BorderBrush = Brushes.Red;
                                flag = false;
                            }
                           

                        }

                    }

                    //если клиент физическое лицо
                    else
                    {
                        try
                        {

                        
                        // Проверка Паспорта на совпадение
                        foreach (var cl in MainWindow.ML.clientData.Clients)
                        {
                            if (NumPassport.Text != "")
                            {

                                    if (Convert.ToUInt32(NumPassport.Text) == cl.Passport)
                                    {
                                        MessageBox.Show("Клиент с таким номером паспорта уже существует!");
                                        flag = false;
                                        NumPassport.Text = "";
                                        break;
                                    }
                                

                               

                            }
                            else
                            {
                                MessageBox.Show("Вы не заполнили все поля");
                                flag = false;
                            }

                        }
                         }
                        catch
                        {
                            MessageBox.Show("Номер Паспорта должен сосоять только из чисел");
                            flag = false;
                        }

                        if (flag == true)
                        {
                            try
                            {

                            
                            client = new Client(FstName.Text, LstName.Text, Convert.ToDateTime(BrthDay.Text), Convert.ToUInt32(NumPassport.Text), "", adress, work);
                            client.Status = ((AddClient_Helper)Cb_Status.SelectedValue).Status;
                              MainWindow.ML.clientData.Clients.Add(client);


                                client.Rating = Convert.ToInt32(Bt_Rating.Text);

                            MainWindow.ML.LogiAll.Logis.Add(new Logi((client.Passport.ToString() + " ДОБАВЛЕН в " + (DateTime.Now).ToString())));
                                MainWindow.ML.LogiAll.Save();
                                Bt_Rating.BorderBrush = Brushes.Gray;
                            }
                            catch
                            {
                               
                            }
                        }


                    }

                

              
            }
            else
            {
                MessageBox.Show("Вы не заполнили все поля");
                    flag = false;
            }

            if (flag == true)
            {
                ///перебирает открытые окна и закрывает текущее
                foreach (Window window in App.Current.Windows)
                {
                    if (window is AddClient)
                        {
                            Ev_Mes += Mes; // добавляем метод в событие

                            window.Close();
                            Ev_Mes?.Invoke("Добавлен новый клиент");
                        }
                        
                }
            }
            }
            catch(MyExeption e)
            {
                BrthDay.BorderBrush = Brushes.Red;
                NumPassport.BorderBrush = Brushes.Red;

                Bt_Rating.BorderBrush = Brushes.Red;


                MessageBox.Show("Проверьте коректность вводимых данных. " + e.Message);

            }
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



        /// <summary>
        /// Открывает окно Добавить адрес, обрабатывае и звкрывает его
        /// </summary>
        /// <param name="Adres"></param>
        internal void AddAdress(TextBlock Adres)
        {
            Addres_Win addres_Win = new Addres_Win(adress);
            addres_Win.ShowDialog();
            adress = addres_Win.adress;
            if (adress.FullAdres().Trim() != "")
            {
                Adres.Text = adress.FullAdres();
            }
           
        }

        /// <summary>
        /// Открывает окно Добавить место работы , обрабатывае и звкрывает его
        /// </summary>
        /// <param name="Tbk_Work">TextBlock </param>
        /// <param name="Cb_Status"></param>
        internal void AddWork(TextBlock Tbk_Work, ComboBox Cb_Status)
        {
            try
            {
                
                if (((AddClient_Helper)Cb_Status.SelectedValue).Status != "COMPANY")
                {
                    var begin = Tbk_Work.Text;
                    Work_Win work_Win = new Work_Win(work);
                    work_Win.ShowDialog();
                    work = work_Win.worck;
                    try
                    {
                        if (work.FullWork().Trim() != "" || work.FullWork() != null)
                        {
                            Tbk_Work.Text = work.FullWork();
                        }
                        
                    }
                    catch
                    {
                        MessageBox.Show("Данные о работе были заполнены некорректно ");
                        Tbk_Work.Text = begin;
                    }
                  
                    
                }
                //else { MessageBox.Show("Вы не выбрали категорию клиента"); }
            }
            catch
            {
                MessageBox.Show("Вы не выбрали категорию клиента");
            }
         

        }

        /// <summary>
        /// Изменение контента при выборе статуса в ComboBox Cb_Status
        /// </summary>
        /// <param name="Cb_Status">ComboBox выбора статуса</param>
        /// <param name="FstName">TextBox Имени</param>
        /// <param name="LFN">Label Имя</param>
        /// <param name="LLN">Label Фамилия</param>
        /// <param name="LW">Label Работа</param>
        /// <param name="Tbk_Work">TextBlock Места работы </param>
        /// <param name="LINN">Label ИНН или Паспорт</param>
        /// <param name="LBd">Label Дата рождения или создания</param>
        internal void ChangeContent(ComboBox Cb_Status, TextBox FstName, Label LFN, Label LLN, Label LW, TextBlock Tbk_Work, Label LINN, Label LBd)
        {
            if (((AddClient_Helper)Cb_Status.SelectedValue).Status == "COMPANY")
            {
                FstName.Visibility = Visibility.Hidden;
                LFN.Content = "";
                LLN.Content = "Имя Компании";
                LW.Visibility = Visibility.Hidden;
                Tbk_Work.Visibility = Visibility.Hidden;
                LINN.Content = "ИНН";
                LBd.Content = "Дата Создания";
            }
            else
            {
                FstName.Visibility = Visibility.Visible;
                LFN.Content = "Имя";
                LLN.Content = "Фамилия";
                LW.Visibility = Visibility.Visible;
                Tbk_Work.Visibility = Visibility.Visible;
                LINN.Content = "Паспорт";
                LBd.Content = "Дата рождения";
            }
        }



        

        
    }

/// <summary>
/// Вспомагательный класс для работы с ComboBox
/// </summary>
internal class AddClient_Helper
    {
        string status;

        public AddClient_Helper(string status)
        {
            Status = status;
        }

        public string Status { get => status; set => status = value; }
    }
}

