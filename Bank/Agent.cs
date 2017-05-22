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
        //public IEnumerator<float> a;
        public static int id;
        
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
