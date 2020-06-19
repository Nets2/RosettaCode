using System;
using System.Diagnostics;
 
namespace doors
{
    class Dumb
    {
        private bool[] doors;
        private long microseconds;
        private long nanoseconds;
        public Dumb(){
            doors= new bool[100];
            for (int d = 0; d < 100; d++) doors[d] = false;
        }

        public long getUsec(){
            return this.microseconds;
        }
        public long getNsec(){
            return this.nanoseconds;
        }
        public void aff(){
            for(int i = 1; i<=100; i++){
                if(this.doors[i-1]){
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
                    this.doors[j]=!this.doors[j];
                }
            }
            sw.Stop();
            microseconds = sw.ElapsedTicks / (Stopwatch.Frequency / (1000L*1000L));
            nanoseconds = sw.ElapsedTicks / (Stopwatch.Frequency / (1000L*1000L*1000L));
        }
    }
}
