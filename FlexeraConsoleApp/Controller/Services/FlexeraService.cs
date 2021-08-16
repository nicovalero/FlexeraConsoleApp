using FlexeraConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexeraConsoleApp.Controller.Services
{

    public interface IFlexeraService
    {
        public List<Record> GetFileRecords(string location);
    }
    public class FlexeraService : IFlexeraService
    {
        private ICSVReaderService _service;
        public FlexeraService(ICSVReaderService service)
        {
            _service = service;
        }

        public List<Record> GetFileRecords(string location)
        {
            List<Record> records = new List<Record>();
            DataTable dt = _service.ReadFile(location);
            string value;
            Record currentRecord;

            if (dt != null)
            {
                dt.Rows.RemoveAt(0);

                foreach (DataRow row in dt.Rows)
                {
                    value = row["Value"].ToString();
                    if (!string.IsNullOrEmpty(value))
                    {
                        currentRecord = new Record(value);
                        records.Add(currentRecord);
                    }
                }
            }
            else
                return null;

            return records;
        }
    }
}
