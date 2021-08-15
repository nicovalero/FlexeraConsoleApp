using FlexeraConsoleApp.Controller;
using FlexeraConsoleApp.Model;
using System;

namespace FlexeraConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Terminal terminal = DependencyModule.MakeTerminal();

            terminal.DisplayInstructions();
            terminal.Standby();
        }
    }
}
