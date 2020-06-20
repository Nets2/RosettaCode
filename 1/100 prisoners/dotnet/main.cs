using System;
using System.Diagnostics;

namespace prisoner{

    class Perf{
        public int Success{get;private set;}
        public int Fail{get;private set;}
        public int Length{get;private set;}
        public Perf(){
            Success=0;
            Fail=0;
            Length=0;
        }
        public void add(bool isSucceed){
            if(isSucceed){
                Success++;
            } else {
                Fail++;
            }
            Length++;
        }

        public void disp(){
            Console.WriteLine("Operation launched {0} times to do performance study", Length);
            Console.WriteLine("Operation completed {0} => {1} percent of time",Success, (Success * 100 / Length));
            Console.WriteLine("Operation failed {0} => {1} percent of time ",Fail, (Fail * 100 / Length ));
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
            
            Perf perfdumb= new Perf();
            Perf perfOptimize = new Perf();
            // run
            for(int i=0; i<10000; i++){
                Dumb dumb = new Dumb();
                Optimize optimize = new Optimize();

                dumb.run();
                //if(flag)
                //dumb.aff();
                perfdumb.add(dumb.Success);

                optimize.run(); 
                if(flag)
                optimize.aff();
                perfOptimize.add(optimize.Success);
            }
                perfdumb.disp();
                perfOptimize.disp();
        }   
    }
}