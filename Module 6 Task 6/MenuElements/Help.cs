using System;
using System.Collections.Generic;
using System.Text;
using Module_6_Task_6.Entities;
using Module_6_Task_6.UI;

namespace Module_6_Task_6.MenuElements
{
    public class Help : ElementMenu
    {
        public Help()
        {
            Title = "Help";
            Description = "Show menu info";
            Key = '4';
        }

        public override void Do(ref Storage storage, Menu menu)
        {
            foreach (ElementMenu element in menu.Elements)
            {
                Console.WriteLine($"{element.Key}){element.GetInfo()}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
