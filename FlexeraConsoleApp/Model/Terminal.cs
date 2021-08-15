using FlexeraConsoleApp.Controller;
using System;
using System.Collections.Generic;
using System.IO;
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
                    try
                    {
                        if (_controller.FileIsReadable(location))
                        {
                            int licenses = _controller.GetTotalAppLicensesNeeded(location);
                            if (licenses != -1)
                            {
                                DisplayTotalLicensesNeeded(licenses);
                            }
                            else
                            {
                                DisplayLicenseError();
                            }
                        }
                        else
                            DisplayPathError(location);
                    }
                    catch(Exception ex)
                    {
                        DisplayUnreadableError();
                    }
                }
            }
        }

        public void DisplayLicensesNeededPerUserAndApp(LicenseReport report)
        {
            DisplayMessage("Number of licenses for Application " + report._applicationID + " and the User with ID " + report._userID + ": " + report._licenseCount + "\n");
        }

        public void DisplayTotalLicensesNeeded(int licenses)
        {
            DisplayMessage("Number of licenses needed: " + licenses + "\n");
        }

        public void DisplayPathError(string path)
        {
            DisplayMessage(path + " is not a valid path, or file does not exist.\n");
        }

        public void DisplayLicenseError()
        {
            DisplayMessage("Could not check the number of licenses for this file.\n");
        }

        public void DisplayUnreadableError()
        {
            DisplayMessage("Could not read the file.\n");
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
