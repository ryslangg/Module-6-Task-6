using System;
using System.Collections.Generic;
using System.Text;

namespace Module_6_Task_6.Entities
{
    public class Unit
    {
        public virtual string Name { get; private set; }
        public virtual int Health { get; private set; } = 100;
        public virtual int DamageLow { get; private set; } = 10;
        public virtual int DamageMax { get; private set; } = 20;
        public virtual int Evasion { get; private set; } = 10;
        public virtual int Accuracy { get; private set; } = 10;
        public virtual int Armor { get; private set; } = 1;
        private Attack _attack;

        public Unit(string name, Attack attack, Dictionary<string, int> AttributesValues = null, Log log = null)
        {
            Name = name;
            _attack = attack;
            _attack.Init(this);
            _setAttribute(AttributesValues);
        }

        private void _setAttribute(Dictionary<string, int> AttributesValues = null)
        {
            if (AttributesValues != null)
            {
                foreach (KeyValuePair<string, int> AttributeValue in AttributesValues)
                {
                    switch (AttributeValue.Key)
                    {
                        case "Health":
                            Health = AttributeValue.Value;
                            break;
                        case "Accuracy":
                            Accuracy = AttributeValue.Value;
                            break;
                        case "Armor":
                            Armor = AttributeValue.Value;
                            break;
                        case "DamageLow":
                            DamageLow = AttributeValue.Value;
                            break;
                        case "DamageMax":
                            DamageMax = AttributeValue.Value;
                            break;
                        case "Evasion":
                            Evasion = AttributeValue.Value;
                            break;
                    }
                }
            }
        }

        public void Attack(Unit target)
        {
            _attack.Do(target);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;

            if (Health < 0)
            {
                Health = 0;
            }
        }

        public bool CheckAlive()
        {
            return Health > 0;
        }

        public string Info()
        {
            string info = "-------------------------\r\n";
            info += $"Name:{this.Name}\r\n";
            info += $"HP:{this.Health}\r\n";
            info += $"Damage:{this.DamageLow}-{this.DamageMax}\r\n";
            info += $"Evasion:{this.Evasion}\r\n";
            info += $"Accuracy:{this.Accuracy}\r\n";
            info += $"Armor:{this.Armor}\r\n";
            info += "-------------------------\r\n";

            return info;
        }
    }
}
