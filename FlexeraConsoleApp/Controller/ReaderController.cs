using FlexeraConsoleApp.Controller.Services;
using FlexeraConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexeraConsoleApp.Controller
{
    public class ReaderController
    {
        private IFlexeraService _flexeraService;
        private IApplicationLicenses _appLicenses;

        public ReaderController(IFlexeraService service, IApplicationLicenses appLicenses)
        {
            _flexeraService = service;
            _appLicenses = appLicenses;
        }

        public List<LicenseReport> GetAppLicensesNeeded(string location)
        {
            List<Record> list = _flexeraService.GetFileRecords(location);
            List<LicenseReport> licenseReports = _appLicenses.GetNumberOfLicensesPerUserAndApp(list);

            return licenseReports;
        }

        public bool FileIsReadable(string location)
        {
            string path = Path.GetFullPath(location);
            if (File.Exists(path))
                return true;
            else
                return false;
        }

        public int? GetTotalAppLicensesNeeded(string location)
        {
            List<Record> list = _flexeraService.GetFileRecords(location);
            int? licenses = _appLicenses.GetNumberOfLicenses(list);

            return licenses;
        }
    }
}
