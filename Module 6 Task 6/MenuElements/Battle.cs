using System;
using System.Collections.Generic;
using System.Text;
using Module_6_Task_6.Entities;
using Module_6_Task_6.UI;

namespace Module_6_Task_6.MenuElements
{
    public class Battle : ElementMenu
    {
        public Battle()
        {
            Title = "Battle";
            Description = "run units battle";
            Key = '1';
            Active = false;
        }

        public override void Do(ref Storage storage, Menu menu)
        {
            do
            {
                storage.Unit1.Attack(storage.Unit2);
                storage.Unit2.Attack(storage.Unit1);
            }
            while (storage.Unit1.CheckAlive() && storage.Unit2.CheckAlive());

            string result;

            if (storage.Unit1.CheckAlive())
            {
                result = $"{storage.Unit1.Name} WIN!";
            }
            else
            {
                result = $"{storage.Unit2.Name} WIN!";
            }

            if (!storage.Unit1.CheckAlive() && !storage.Unit2.CheckAlive())
            {
                result = "Draw!";
            }

            storage.Log.Add(result);
            storage.Log.Print();
            menu.Active = false;
        }
    }
}
