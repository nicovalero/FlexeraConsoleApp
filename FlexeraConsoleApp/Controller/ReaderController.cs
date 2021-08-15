using FlexeraConsoleApp.Controller.Services;
using FlexeraConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexeraConsoleApp.Controller
{
    public class ReaderController
    {
        private FlexeraService _flexeraService;
        private ApplicationLicenses _appLicenses;

        public ReaderController(FlexeraService service, ApplicationLicenses appLicenses)
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

        public int GetTotalAppLicensesNeeded(string location)
        {
            List<Record> list = _flexeraService.GetFileRecords(location);
            int licenses = _appLicenses.GetNumberOfLicenses(list);

            return licenses;
        }
    }
}
