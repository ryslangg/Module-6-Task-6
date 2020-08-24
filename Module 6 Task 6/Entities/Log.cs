using Module_6_Task_6;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module_6_Task_6.Entities
{
    public class Log
    {
        private string _log = "";

        public void Add(string message)
        {
            _log += $"{message}\r\n";
        }

        public void Separator()
        {
            _log += $"--------------------\r\n";
        }

        public void Print()
        {
            InOut.Alert(_log);
        }
    }
}
