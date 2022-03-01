using System;

namespace mis321_pa2_annalegoullon{
    class WillTurner : Character{
        public WillTurner(){
            name = "Will Turner";
            maxPower = GetMaxPower();
            health = 100;
            attackStrength = GetAttackStrength(maxPower);
            defensivePower = GetDefensivePower(maxPower);
            characterAttack = new SwordBehavior();
            
        }
    }
}