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
                    int licenses = _controller.GetTotalAppLicensesNeeded(location);

                    if (licenses != -1)
                    {
                        DisplayTotalLicensesNeeded(licenses);
                    }
                    else
                    {
                        DisplayRoadError(location);
                        //TerminateApplication();
                    }
                }
            }
        }

        public void DisplayLicensesNeededPerUserAndApp(LicenseReport report)
        {
            DisplayMessage("Number of licenses for Application " + report._applicationID + " for the User with ID " + report._userID + ": " + report._licenseCount + "\n");
        }

        public void DisplayTotalLicensesNeeded(int licenses)
        {
            DisplayMessage("Number of licenses needed: " + licenses + "\n");
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
