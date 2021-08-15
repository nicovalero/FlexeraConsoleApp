using FlexeraConsoleApp.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexeraConsoleApp.Model
{
    public class Terminal
    {
        private const string EXIT = "exit";
        private ReaderController _controller;

        public Terminal(ReaderController controller)
        {
            _controller = controller;
        }

        public void Standby()
        {
            var location = "";

            while (location.ToString().ToLower() != EXIT)
            {
                location = Console.ReadLine();

                if (location.ToLower() != EXIT)
                {
                    List<Tuple<string, int>> licenses = _controller.GetAppLicensesNeeded(location);

                    if (licenses != null)
                    {
                        foreach(Tuple<string,int> t in licenses)
                            DisplayLicensesNeeded(t);
                    }
                    else
                    {
                        DisplayRoadError(location);
                        //TerminateApplication();
                    }
                }
            }
        }

        public void DisplayLicensesNeeded(Tuple<string,int> info)
        {
            DisplayMessage("Number of licenses for Application " + info.Item1 + ": " + info.Item2 + "\n");
        }

        public void DisplayRoadError(string path)
        {
            DisplayMessage(path + " is not a valid path.\n");
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayInstructions()
        {
            Console.WriteLine("Please enter the path of the file you want to read, or type exit to terminate.");
        }

        private void TerminateApplication()
        {
            Environment.Exit(1);
        }
    }
}
