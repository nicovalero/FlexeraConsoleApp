using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexeraConsoleApp.Model
{
    public interface IApplicationLicenses
    {
        public List<LicenseReport> GetNumberOfLicensesPerUserAndApp(List<Record> list);
        public int? GetNumberOfLicenses(List<Record> list);
        public List<LicenseReport> GetLicenseReports(List<Record> list);
    }
    public class ApplicationLicenses : IApplicationLicenses
    {
        public List<LicenseReport> GetNumberOfLicensesPerUserAndApp(List<Record> list)
        {
            if (list != null)
            {
                List<LicenseReport> results = GetLicenseReports(list);
                return results;
            }
            else
                return null;
        }

        public int? GetNumberOfLicenses(List<Record> list)
        {
            if (list != null)
            {
                List<LicenseReport> results = GetLicenseReports(list);
                int count = 0;
                foreach (LicenseReport report in results)
                {
                    count += report._licenseCount;
                }
                return count;
            }
            else
                return null;
        }

        public List<LicenseReport> GetLicenseReports(List<Record> list)
        {
            //The following GroupBy serves to remove the duplicates
            var duplicatesRemoved = (from r in list
                                     group r by new { r._applicationID, r._computerID, r._userID, r._computerType } into grp
                                     select new
                                     {
                                         _computerID = grp.Key._computerID,
                                         _userID = grp.Key._userID,
                                         _computerType = grp.Key._computerType,
                                         _applicationID = grp.Key._applicationID
                                     }).Distinct().ToList();

            //Calculation of two lists: one for desktops and one for laptops; and grouping
            var desktops = (from r in duplicatesRemoved
                            where r._computerType.ToLower() == "desktop"
                            group r by new { r._applicationID, r._computerID, r._userID, r._computerType } into grp
                            select new
                            {
                                UserID = grp.Key._userID,
                                ComputerType = grp.Key._computerType,
                                ApplicationID = grp.Key._applicationID,
                                LicenseCount = grp.Count()
                            }).ToList();
            var laptops = (from r in duplicatesRemoved
                           where r._computerType.ToLower() == "laptop"
                           group r by new { r._applicationID, r._computerID, r._userID, r._computerType } into grp
                           select new
                           {
                               UserID = grp.Key._userID,
                               ComputerType = grp.Key._computerType,
                               ApplicationID = grp.Key._applicationID,
                               LicenseCount = grp.Count()
                           }).ToList();

            //Union of both lists
            var union = desktops.Union(laptops);

            //Selection of the number of licenses needed.
            //The license count is, after all, the maximum number of installations between laptops and desktops for the same UserID and AppID
            List<LicenseReport> results = (from r in union
                                           group r by new { r.ApplicationID, r.UserID } into grp
                                           select new LicenseReport()
                                           {
                                               _userID = grp.Key.UserID,
                                               _applicationID = grp.Key.ApplicationID,
                                               _licenseCount = (from r2 in grp select r2.LicenseCount).Max()
                                           }).ToList();

            return results;
        }
    }
}
