using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Bank
{
    class MinusConsantAgent : BankServer
    {
        new private float AccountStatus { get; set; }
        int i = 0;
        bool lockToken = false;
        public override void Update()
        {
            lockToken = false;
            ///mutex
            ///Program._BankServers[0].mutex.WaitOne();

            //lock(Program._BankServers[0])
            //spinlock
            try
            {
                ///SpinLock
                Program._BankServers[0].spinLock.Enter(ref lockToken);


                i++;
                AccountStatus = Program._BankServers[0].AccountStatus;
                AccountStatus -= 50;
                Program._BankServers[0].AccountStatus = AccountStatus;
                Console.WriteLine("Minus Constant Agent Account Status=" + AccountStatus);
                if (i == 9999) { HasFinished = true; }
            }
            finally { if(lockToken) { Program._BankServers[0].spinLock.Exit(); } }
            //Mutex
            //Program._BankServers[0].mutex.ReleaseMutex();

        }
    }
}
