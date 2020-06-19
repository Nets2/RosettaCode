using System;
using System.Diagnostics;

namespace doors
{
    class Optimize{
        private bool[] doors;

        private long microseconds;
        private long nanoseconds;
        public Optimize(){
            doors= new bool[100];
        }
        public long getUsec(){
            return this.microseconds;
        }
        public long getNsec(){
            return this.nanoseconds;
        }
        public void run(){
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int n=0;
            int d;
            while((d=(++n*n)) <= 100){
                this.doors[d-1]=true;
            }
            sw.Stop();
            microseconds = sw.ElapsedTicks / (Stopwatch.Frequency / (1000L*1000L));
            nanoseconds = sw.ElapsedTicks / (Stopwatch.Frequency / (1000L*1000L*1000L));
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
    }


}