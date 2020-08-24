using Module_6_Task_6.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module_6_Task_6.Attacks
{
    public class HammerAttack : Entities.Attack
    {
        public HammerAttack(Log log) : base(log)
        {
        }
        public override void Do(Unit target)
        {
            bool isTrueStrike = _checkTryeStrike();
            _addToLog($"{_attacker.Name} strikes {target.Name}");

            if (isTrueStrike)
            {
                int damage = _rand.Next(_attacker.DamageLow, _attacker.DamageMax);
                _addToLog($"{damage}DMG");
                _addToLog("This blow goes through the defense!");

                if (!isTrueStrike)
                {
                    damage *= 3;
                }
                target.TakeDamage(damage);
            }
            else
            {
                _addToLog("The blow went by!");
            }

        }
    }
}
