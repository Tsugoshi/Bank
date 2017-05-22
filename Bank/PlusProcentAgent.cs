using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Bank
{
    class PlusProcentAgent :Agent
    {
        private float AccountStatus { get; set; }
        public override void Update()
        {
            AccountStatus = Program._BankServers[0].AccountStatus;
            AccountStatus *=1.05f;
            Program._BankServers[0].AccountStatus = AccountStatus;
            Console.WriteLine("Plus Procent Agent Account Status=" + AccountStatus);
            Thread.Sleep(2000);
        }
    }
}
