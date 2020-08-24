using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Module_6_Task_6.Attacks;
using Module_6_Task_6.Buiders;
using Module_6_Task_6.Entities;
using Module_6_Task_6.UI;

namespace Module_6_Task_6.MenuElements
{
    public class ChooseFighters : ElementMenu
    {
        private List<Unit> _units = new List<Unit>();
        public ChooseFighters()
        {
            Title = "Choose fighters";
            Description = "Choose fighters";
            Key = '1';
        }

        public override void Do(ref Storage storage, Menu menu)
        {
            _generateUnits(storage.Log);
            List<string> unitsList = _units.Select(unit => unit.Name).ToList();
            int choosetNumber = InOut.Select("Choose first fighter:", unitsList);
            storage.Unit1 = _units[choosetNumber];
            _units.RemoveAt(choosetNumber);
            Console.Clear();
            unitsList = _units.Select(unit => unit.Name).ToList();
            choosetNumber = InOut.Select("Choose second fighter:", unitsList);
            storage.Unit2 = _units[choosetNumber];
            _units.RemoveAt(choosetNumber);
            base.Do(ref storage, menu);
        }

        private void _generateUnits(Log log)
        {

            UnitBuilder builder = new UnitBuilder();
            builder.Attack(new Attack(log));
            _units.Add(builder.Build("Swordman"));
            builder.Attack(new BowAttack(log));
            _units.Add(builder.Build("Archer"));
            builder.Attack(new SpearAttack(log));
            _units.Add(builder.Build("Lancer"));
            builder.Attack(new KnifeAttack(log));
            _units.Add(builder.Build("Rogue"));
            builder.Attack(new HammerAttack(log));
            _units.Add(builder.Build("Paladin"));
        }
    }
}
