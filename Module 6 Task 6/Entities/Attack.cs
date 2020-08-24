using System;
using System.Collections.Generic;
using System.Text;

namespace Module_6_Task_6.Entities
{
    public class Attack
    {
        protected Unit _attacker;
        protected static Random _rand = new Random();
        protected Log _log = null;

        public Attack(Log log = null)
        {
            if (log != null)
            {
                _log = log;
            }
        }

        public void  Init(Unit attacker)
        {
            if (_attacker == null)
            {
                _attacker = attacker;
            }            
        }

        protected void _addToLog(string message)
        {
            if (_log != null)
            {
                _log.Add(message);
            }
        }


        protected bool _checkMiss(Unit target)
        {
            int evasionChance = _rand.Next(0, 100);
            return evasionChance <= target.Evasion;
        }

        protected bool _checkTryeStrike()
        {
            int TryeStrikeChance = _rand.Next(0, 100);
            return TryeStrikeChance <= _attacker.Accuracy;
        }

        protected bool _checkSuccessStrike(Unit target)
        {
            return (!_checkMiss(target) || _checkTryeStrike());
        }

        public virtual void Do(Unit target)
        {
            if (_attacker.CheckAlive())
            {
                _log.Separator();
                _addToLog($"{_attacker.Name} strikes {target.Name}");

                if (_checkSuccessStrike(target))
                {
                    int damage = _rand.Next(_attacker.DamageLow, _attacker.DamageMax);
                    _addToLog($"{damage}DMG");
                    _addToLog($"{target.Armor} blocked");
                    damage -= target.Armor;
                    target.TakeDamage(damage);

                    if (target.CheckAlive())
                    {
                        _addToLog($"{target.Name}({target.Health}HP)");
                    }
                }
                else
                {
                    _addToLog("The blow went by!");
                }
                _log.Separator();
            }

        }
    }
}
