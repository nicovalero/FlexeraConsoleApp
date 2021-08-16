using FlexeraConsoleApp.Controller.Services;
using FlexeraConsoleApp.Model;
using System.Collections.Generic;

namespace FlexeraConsoleAppTests.fake
{
    public class FakeFlexeraService : IFlexeraService
    {
        public List<Record> GetFileRecordsResult = null;
        public List<Record> GetFileRecords(string location)
        {
            return GetFileRecordsResult;
        }
    }
}
