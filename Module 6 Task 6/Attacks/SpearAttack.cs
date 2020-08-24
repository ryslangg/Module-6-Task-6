using Module_6_Task_6.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module_6_Task_6.Attacks
{
    public class SpearAttack : Entities.Attack
    {
        public SpearAttack(Log log) : base(log)
        {
        }

        public override void Do(Unit target)
        {
            bool isMiss = _checkMiss(target);
            bool isTrueStrike = _checkTryeStrike();
            _addToLog($"{_attacker.Name} strikes {target.Name}");

            if (!isMiss || isTrueStrike)
            {
                int damage = _rand.Next(_attacker.DamageLow, _attacker.DamageMax);
                _addToLog($"{damage}DMG");
                

                if (!isTrueStrike)
                {
                    _addToLog($"{target.Armor} blocked");
                    damage -= target.Armor;
                }
                else 
                {
                    _addToLog($"The spear {_attacker.Name} went through the protection!");
                }
                target.TakeDamage(damage);

                if (target.CheckAlive())
                {
                    _addToLog($"{target.Name}({target.Health}HP)");
                }
            }

        }
    }
}
