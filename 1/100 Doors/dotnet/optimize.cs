using System;
using System.Diagnostics;

namespace doors
{
    class Optimize{
        public bool[] Doors{get; private set;}
        public long Microseconds{get;private set;}
        public long Nanoseconds{get;private set;}
        public Optimize(){
            Doors= new bool[100];
        }
        public void run(){
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int n=0;
            int d;
            while((d=(++n*n)) <= 100){
                Doors[d-1]=true;
            }
            sw.Stop();
            Microseconds = sw.ElapsedTicks / (Stopwatch.Frequency / (1000L*1000L));
            Nanoseconds = sw.ElapsedTicks / (Stopwatch.Frequency / (1000L*1000L*1000L));
        }
        public void aff(){
            for(int i = 1; i<=100; i++){
                if(Doors[i-1]){
                    Console.WriteLine("door {0} is open", i);
                } else {
                    Console.WriteLine("door {0} is close ", i);
                }
            }
        }
    }
}