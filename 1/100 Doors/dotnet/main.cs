using System;
using System.Diagnostics;

namespace doors{

    class Perf{
        private long microseconds{get;set;}
        private long nanoseconds{get;set;}
        private int length{get;set;}
        public Perf(){
            microseconds=0;
            nanoseconds=0;
            length=0;
        }
        public void add(long usec, long nsec){
            this.microseconds+=usec;
            this.nanoseconds+=nsec;
            length++;
        }
        public void dispTime(){
            Console.WriteLine("Operation launched {0} times to do performance study", length);
            Console.WriteLine("Operation completed in: " + microseconds/length + " (us)");
            Console.WriteLine("Operation completed in: " + nanoseconds/length + " (ns)");
        }
        public void reset(){
            this.nanoseconds=0;
            this.microseconds=0;
            this.length=0;
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
                perfDumb.add(dumb.getUsec(),dumb.getNsec());

                optimize.run(); 
                if(flag)
                optimize.aff();
                perfOptimize.add(optimize.getUsec(),optimize.getNsec());
            }
            perfDumb.dispTime();
            perfOptimize.dispTime();
        }   
    }
}