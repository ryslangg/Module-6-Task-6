using Module_6_Task_6.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module_6_Task_6.UI
{
    public class ElementMenu
    {
        public virtual string Title { get; protected set; } = "Some";
        public virtual string Description { get; protected set; } = "Some menu element";
        public virtual char Key { get; protected set; } = '1';

        public bool Active = true;

        public virtual bool CheckKeyFits(char key)
        {
            return (key == Key);
        }

        public virtual void Do(ref Storage storage, Menu menu)
        {
            Active = false;
            bool activateNext = false;

            foreach (ElementMenu element in menu.Elements)
            {
                if (activateNext)
                {
                    element.Active = true;
                    break;
                }

                if (element == this)
                {
                    activateNext = true;
                }                
            }
        }

        public virtual string GetInfo()
        {
            return $"{Title} - {Description}";
        }
    }
}
