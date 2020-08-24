using Module_6_Task_6.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module_6_Task_6.UI
{
    public class Menu
    {
        public List<ElementMenu> Elements = new List<ElementMenu>();
        public bool Active = true;

        public Menu AddElement(ElementMenu element)
        {
            Elements.Add(element);
            return this;
        }

        public Menu Run(char Key, ref Storage storage)
        {
            foreach (ElementMenu element in Elements)
            {
                if (element.CheckKeyFits(Key) && element.Active)
                {
                    element.Do(ref storage, this);
                    break;
                }

            }
            return this;
        }

        public Menu Print()
        {
            foreach (ElementMenu element in Elements)
            {
                if (element.Active)
                {
                    Console.WriteLine($"{element.Key}){element.Title}");
                }                    
            }
            return this;
        }
    }
}
