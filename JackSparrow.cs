using System;

namespace mis321_pa2_annalegoullon{
    public class JackSparrow : Character{
        public JackSparrow(){
            name = "Jack Sparrow";
            maxPower = GetMaxPower();
            health = 100;
            attackStrength = GetAttackStrength(maxPower);
            defensivePower = GetDefensivePower(maxPower);
            characterAttack = new DistractBehavior();
        }

    }
}