using FlexeraConsoleApp.Controller.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexeraConsoleAppTests.fake
{
    public class FakeCSVReaderService : ICSVReaderService
    {
        public DataTable ReadFileResults;
        public DataTable ReadFile(string location)
        {
            return ReadFileResults;
        }
    }
}
