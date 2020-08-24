using Module_6_Task_6.MenuElements;
using Module_6_Task_6.UI;
using Module_6_Task_6.Entities;
using System;

namespace Module_6_Task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.AddElement(new ChooseFighters());
            menu.AddElement(new Battle());
            menu.AddElement(new Help());
            menu.AddElement(new Exit());

            Storage storage = new Storage();
            storage.Log = new Log();

            while (menu.Active)
            {

                Console.Clear();

                if(storage.Unit1 != null && storage.Unit2 != null)
                {
                    Console.WriteLine(storage.Unit1.Info()+"\r\n"+storage.Unit2.Info());
                }
                menu.Print();
                char keySymbol = Console.ReadKey(true).KeyChar;
                Console.Clear();
                menu.Run(keySymbol, ref storage);
            }
        }
    }
}
