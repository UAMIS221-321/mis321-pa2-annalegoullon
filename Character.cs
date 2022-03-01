using System;
using mis321_pa2_annalegoullon.Interfaces;

namespace mis321_pa2_annalegoullon{

    public abstract class Character{
        public string name{get;set;}
        public int maxPower{get;set;}
        public double health{get;set;}
        public int attackStrength{get;set;}
        public int defensivePower {get;set;}

        public IAttack characterAttack{get;set;}


        // randomly generates number 1-100 for character max power
        public static int GetMaxPower(){
            Random rand = new Random();
            int num = rand.Next(1,101);
            return num;
        }

        //methods generate random attack strength and defensive power for character
        public static int GetAttackStrength(int max){
            Random rand = new Random();
            int num = rand.Next(1,max+1);
            return num;
        }

        public static int GetDefensivePower(int max){
            Random rand = new Random();
            int num = rand.Next(1,max+1);
            return num;
        }
    }
}