using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexeraConsoleApp.Controller.Services
{
    public interface ICSVReaderService
    {
        public DataTable ReadFile(string location);
    }
    public class CSVReaderService : ICSVReaderService
    {
        public DataTable ReadFile(string location)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Value");
                DataRow row;

                using(var reader = new StreamReader(location))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        row = dt.NewRow();
                        row["Value"] = line;
                        dt.Rows.Add(row);
                    }
                }

                return dt;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
