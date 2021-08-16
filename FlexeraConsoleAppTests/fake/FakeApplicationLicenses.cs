using FlexeraConsoleApp.Model;
using System.Collections.Generic;

namespace FlexeraConsoleAppTests.fake
{
    public class FakeApplicationLicenses : IApplicationLicenses
    {
        public int? GetNumberOfLicensesResult = null;
        public List<LicenseReport> GetLicenseReportsResult = null;
        public List<LicenseReport> GetNumberOfLicensesPerUserAndAppResult = null;

        public List<LicenseReport> GetLicenseReports(List<Record> list)
        {
            return GetLicenseReportsResult;
        }

        public int? GetNumberOfLicenses(List<Record> list)
        {
            return GetNumberOfLicensesResult;
        }

        public List<LicenseReport> GetNumberOfLicensesPerUserAndApp(List<Record> list)
        {
            return GetNumberOfLicensesPerUserAndAppResult;
        }
    }
}
