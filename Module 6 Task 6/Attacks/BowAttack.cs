using Module_6_Task_6.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module_6_Task_6.Attacks
{
    public class BowAttack : Entities.Attack
    {
        public BowAttack(Log log) : base(log)
        {
        }
        public override void Do(Unit target)
        {
            base.Do(target);
            base.Do(target);
        }
    }
}
