using System;

namespace mis321_pa2_annalegoullon{
    public class DavyJones : Character{
        public DavyJones(){
            name = "Davy Jones";
            maxPower = GetMaxPower();
            health = 100;
            attackStrength = GetAttackStrength(maxPower);
            defensivePower = GetDefensivePower(maxPower);
            characterAttack = new CannonBehavior();
        }
    }
}