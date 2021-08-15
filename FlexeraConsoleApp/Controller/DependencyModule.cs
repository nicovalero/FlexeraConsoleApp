using FlexeraConsoleApp.Controller.Services;
using FlexeraConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexeraConsoleApp.Controller
{
    public static class DependencyModule
    {
        public static ApplicationLicenses MakeApplicationLicenses()
        {
            return new ApplicationLicenses();
        }

        public static ICSVReaderService MakeCSVReaderService()
        {
            return new CSVReaderService();
        }

        public static FlexeraService MakeFlexeraService()
        {
            return new FlexeraService(MakeCSVReaderService());
        }

        public static Terminal MakeTerminal()
        {
            return new Terminal(MakeReaderController());
        }

        public static ReaderController MakeReaderController()
        {
            return new ReaderController(MakeFlexeraService(), MakeApplicationLicenses());
        }
    }
}
