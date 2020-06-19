using System;
using System.Diagnostics;

namespace dotnet
{
    class Dumb
    {
        public void aff(bool[] doors){
            for(int i = 1; i<=100; i++){
                if(doors[i-1]){
                    Console.WriteLine("door {0} is open", i);
                } else {
                    Console.WriteLine("door {0} is close ", i);
                }
            }
        }   

        static void Main(string[] args)
        {
            Dumb p= new Dumb();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            bool[] doors = new bool[100];
            for (int d = 0; d < 100; d++) doors[d] = false;
            for(int i=1 ; i<=100; ++i ){
                for(int j=i-1; j<100; j+=i){
                    doors[j]=!doors[j];
                }
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            long microseconds = stopWatch.ElapsedTicks / (Stopwatch.Frequency / (1000L*1000L));
            long nanoseconds = stopWatch.ElapsedTicks / (Stopwatch.Frequency / (1000L*1000L*1000L));
            p.aff(doors);
            Console.WriteLine("Operation completed in: " + microseconds + " (us)");
            Console.WriteLine("Operation completed in: " + nanoseconds + " (ns)");
        }
    }
}
