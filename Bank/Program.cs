using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Bank
{
    class Program
    {
        public const int sleepTime = 0;

        private readonly static List<BankServer> BankServers = new List<BankServer>();
        public static List<BankServer> _BankServers { get { return BankServers; } }

        private readonly static List<IRunnable> BankAgents = new List<IRunnable>();
        public static List<IRunnable> _BankAgents { get { return BankAgents; } }

        private readonly static List<Thread> ThreadList = new List<Thread>();

        static void GenerateRunnables()
        {
            BankServers.Add(new BankServer());
            for(int i = 0; i < 100; i++) { BankAgents.Add(new PlusConstantAgent()); }
            for(int i = 0; i < 100; i++) { BankAgents.Add(new MinusConsantAgent()); }
            
            //BankAgents.Add(new MinusProcentAgent());
            //BankAgents.Add(new PlusProcentAgent());
        }

        static void RunThreads()
        {
           foreach(Agent Agent in BankServers)
            {
                ThreadList.Add(new Thread(Agent.Run));
            }
           foreach(Agent Agent in BankAgents)
            {
                ThreadList.Add(new Thread(Agent.Run));
            }


           foreach( Thread Thread in ThreadList)
            {
                Thread.Start();
            }
            
        }
      
       
        static void Main(string[] args)
        {
            GenerateRunnables();
            RunThreads();
            
           
            
            Console.ReadKey();
        }
    }
}
