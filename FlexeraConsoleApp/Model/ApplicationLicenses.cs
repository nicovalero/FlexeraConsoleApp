using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexeraConsoleApp.Model
{
    public class ApplicationLicenses
    {
        public List<Tuple<string, int>> GetNumberOfLicenses(List<Record> list)
        {
            List<Tuple<string, int>> licenses = new List<Tuple<string, int>>();

            if (list != null)
            {
                List<string> applications = list.GroupBy(p => p._applicationID)
                                                .Select(p => p.First()._applicationID)
                                                .OrderBy(p => p)
                                                .ToList();
                int desktops;
                int laptops;
                int total;
                foreach(string appID in applications)
                {
                    desktops = list.Where(p => p._applicationID == appID && p._computerType.ToLower() == "desktop").Count();
                    laptops = list.Where(p => p._applicationID == appID && p._computerType.ToLower() == "laptop").Count();

                    total = (desktops >= laptops ? desktops : laptops);

                    licenses.Add(new Tuple<string, int>(appID, total));
                }
            }
            else
                return null;

            return licenses;
        }
    }
}
