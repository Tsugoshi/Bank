using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Bank
{
    abstract class Agent : IRunnable
    {
        
        public static int id;

        static volatile bool[] Entering = new bool[Program.ilosc * 2];
        static volatile int[] Number = new int[Program.ilosc * 2];
        

        public static void Lock(int i)
        {
            Entering[i] = true;


            //Number[i] = 1 + Number.Max();
            Interlocked.Add(ref Number[i], Number.Max()+1);
            Entering[i] = false;
            for (int j = 0; j < Program.ilosc; j++)
            {
                while (Entering[j]) { }
                while ((Number[j] != 0) && ((Number[j] < Number[i]) || ((Number[j] == Number[i]) && j < i))) { }
            }

        }

        public static void Unlock(int i)
        {
            Number[i] = 0;
        }

        public void Run()
        {
            while(!HasFinished)
            {
                
                Update();
                Thread.Sleep(Program.sleepTime);
                
            }
        }
        public abstract void Update(); 
        
        public IEnumerator <float> CoroutineUpdate()
        {
            while (!HasFinished)
            {
                Update();
                if (!HasFinished) yield return 0;
                else yield break;
            }
                     
        }

       
        public bool HasFinished { get; protected set; }
    }
}
