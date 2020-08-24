using System;
using System.Collections.Generic;
using System.Text;
using Module_6_Task_6.Entities;
using Module_6_Task_6.UI;

namespace Module_6_Task_6.MenuElements
{
    public class Exit : ElementMenu
    {
        public Exit()
        {
            Title = "Exit";
            Description = "Turn off program";
            Key = '5';
        }

        public override void Do(ref Storage storage, Menu menu)
        {
            menu.Active = false;
        }
    }
}
