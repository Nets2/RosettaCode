using System;
using System.Diagnostics;

namespace doors{

    class Perf{
        public long Microseconds{get; private set;}
        public long Nanoseconds{get; private set;}
        public int Length{get; private set;}
        public Perf(){
            Microseconds=0;
            Nanoseconds=0;
            Length=0;
        }
        public void add(long usec, long nsec){
            Microseconds+=usec;
            Nanoseconds+=nsec;
            Length++;
        }
        public void dispTime(){
            Console.WriteLine("Operation launched {0} times to do performance study", Length);
            Console.WriteLine("Operation completed in: " + Microseconds/Length + " (us)");
            Console.WriteLine("Operation completed in: " + Nanoseconds/Length + " (ns)");
        }
        public void reset(){
            Nanoseconds=0;
            Microseconds=0;
            Length=0;
        }
    }
    class main{
        static void Main(string[] args){
            // checking debug mode
            bool flag=false;
            if(args.Length !=0 ){
                if(args[0] == "debug"){
                    flag=true;
                }
            }

            // create object
            Dumb dumb = new Dumb();
            Optimize optimize = new Optimize();
            Perf perfDumb = new Perf();
            Perf perfOptimize= new Perf();
            // run
            for(int i=0; i<1000; i++){
                dumb.run();
                if(flag)
                dumb.aff();
                perfDumb.add(dumb.Microseconds,dumb.Nanoseconds);

                optimize.run(); 
                if(flag)
                optimize.aff();
                perfOptimize.add(optimize.Microseconds,optimize.Nanoseconds);
                if(flag){
                    flag=!flag;
                }
            }
            perfDumb.dispTime();
            perfOptimize.dispTime();
        }   
    }
}