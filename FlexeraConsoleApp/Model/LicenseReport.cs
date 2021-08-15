using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexeraConsoleApp.Model
{
    public class LicenseReport
    {
        public string _userID { get; set; }
        public string _applicationID { get; set; }
        public int _licenseCount { get; set; }

        public LicenseReport() { }
    }
}
