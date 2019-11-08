using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankApp
{
    class Agent
    {
        int level;

        

        DateTime firstTrans;

        bool work = true;

        public int GetLevel => level;
        public void SetLeve() 
            {
                if(this.level == 0)
                {
                    firstTrans = DateTime.Now;
                    this.level += 1;

            }
                else if(this.level < 4 && this.level != 0)
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
                        work = false;
                        Ev_Mes -= Mes;
                }
                    
                    else
                    {
                        this.level = 0;
                    }
                }





            }
        

        public bool Work { get => work; }

        public event Action<string> Ev_Mes;

        void Mes(string a)
        {
            MessageBox.Show(a);
        }
    }
}
