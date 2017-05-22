using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Bank
{
    class BankServer : Agent
    {
        public float AccountStatus { get; set; }
        private int ID;
        public BankServer()
        {
            ID = ++id;
        }
        public override void Update()
        {
            Console.WriteLine("Bank Account Status=" + AccountStatus);
            Thread.Sleep(2000);
           
           
        }
    }
}
