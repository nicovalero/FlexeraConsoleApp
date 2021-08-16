using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexeraConsoleApp.Model
{
    public class Record
    {
        public string _computerID { get; set; }
        public string _userID { get; set; }
        public string _applicationID { get; set; }
        public string _computerType { get; set; }
        public string _comment { get; set; }

        public Record()
        {

        }

        public Record(string value)
        {
            string[] values = value.Split(",", StringSplitOptions.RemoveEmptyEntries);

            _computerID = values[0];
            _userID = values[1];
            _applicationID = values[2];
            _computerType = values[3];
            _comment = values[4];
        }
    }
}
