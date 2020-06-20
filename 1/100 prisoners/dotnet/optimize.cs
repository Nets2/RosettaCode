using System;
using System.Linq;
using System.Collections.Generic;

namespace prisoner{
    class Optimize{
        public int[] Prisoner{get; private set;}
        public int[] Drawers{get; private set;}
        public bool Success{get; private set;}
        public int Succeeded{get; private set;}

        public Optimize(){
            // TODO : set random to drawer and prisoner without same numbers
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
            // TODO : seaking by starting at prisoner number and continue seaking
            for(int i = 0; i<100; i++){
                int attempt = 0;
                bool succeed = false;
                int nextNumber = Prisoner[i];

                while(attempt < 50 && succeed == false ){
                    if(Drawers[nextNumber] == Prisoner[i]){
                        succeed=true;
                        Succeeded++;
                    } else {
                        attempt++;
                        nextNumber=Drawers[nextNumber];
                    }
                }
            }
            if(Succeeded == 100 ){
                Success=true;
            }
        }
    }
}