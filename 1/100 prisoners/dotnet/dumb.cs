using System;
using System.Linq;
using System.Collections.Generic;
 
namespace prisoner
{
    class Dumb
    {
        public int[] Prisoner{get; private set;}
        public int[] Drawers{get; private set;}
        public int Succeeded{get; private set;}
        public bool Success{get; private set;}
        public Dumb(){
            // TODO : set random to drawer and Prisoner without same numbers
            var rand  = new Random();
            Succeeded=0;
            Prisoner = new int[100];
            List<int> possible = Enumerable.Range(0,100).ToList();
            for (int d = 0; d < 100; d++) {
                int index = rand.Next(possible.Count);
                Prisoner[d]=possible[index];
                possible.RemoveAt(index);
            }
            Drawers = new int[100];
            possible = Enumerable.Range(0,100).ToList();
            for (int d = 0; d < 100; d++) {
                int index = rand.Next(possible.Count);
                Drawers[d]=(possible[index]);
                possible.RemoveAt(index);
            }
            Succeeded=0;
            Success = false;
        }

        
        public void aff(){
            Console.WriteLine("{0} prisoner find",Succeeded);
        }   
        public void run(){
            var rand = new Random();
            for(int i = 0 ; i < 100;  i++){ // for each Prisoner
            List<int> possible = Enumerable.Range(0,100).ToList();
                int attempt=0;
                bool succeed = false;
                while(attempt < 50 && succeed == false ){
                    int index = rand.Next(possible.Count);
                    if(Prisoner[i] == Drawers[index]){
                        succeed = true;
                        Succeeded++;
                    } else {
                        attempt++;
                        possible.RemoveAt(index);
                    }
                } 
            }
            if(Succeeded == 100 ){
                Success=true;
            } else {
                Success = false;
            }
        }
    }
}

