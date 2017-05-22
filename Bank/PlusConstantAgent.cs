using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Bank
{
    class PlusConstantAgent : Agent
    {
        private float AccountStatus { get; set; }

        public override void Update()
        {
            AccountStatus = Program._BankServers[0].AccountStatus;
            AccountStatus += 50;
            Program._BankServers[0].AccountStatus = AccountStatus;
            Console.WriteLine("Plus Constant Agent Account Status=" + AccountStatus);
            Thread.Sleep(2000);
        }

    }
}
