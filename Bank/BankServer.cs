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
        public Mutex mutex;
        public SpinLock spinLock;
        public float AccountStatus { get; set; }
        private int ID;
        int i=0;
        public BankServer()
        {
            ID = ++id;
            mutex = new Mutex();
            spinLock = new SpinLock();
        }
        public override void Update()
        {
            i++;
            Console.WriteLine("Bank Account Status=" + AccountStatus);
            
            if (Program._BankAgents.All(e => e.HasFinished))
            {
                Console.WriteLine("Finalna Wartość Account Status=" + AccountStatus);
                HasFinished = true;
            }
        }
    }
}
