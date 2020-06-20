using System;
using System.Diagnostics;
 
namespace doors
{
    class Dumb
    {
        public bool[] Doors{get; private set;}
        public long Microseconds{get; private set;}
        public long Nanoseconds{get; private set;}
        public Dumb(){
            Doors= new bool[100];
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
        public void run(){
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for(int i=1 ; i<=100; ++i ){
                for(int j=i-1; j<100; j+=i){
                    Doors[j]=!Doors[j];
                }
            }
            sw.Stop();
            Microseconds = sw.ElapsedTicks / (Stopwatch.Frequency / (1000L*1000L));
            Nanoseconds = sw.ElapsedTicks / (Stopwatch.Frequency / (1000L*1000L*1000L));
        }
    }
}
