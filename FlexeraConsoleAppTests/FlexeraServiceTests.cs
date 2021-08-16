using FlexeraConsoleApp.Controller.Services;
using FlexeraConsoleApp.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FlexeraConsoleAppTests
{
    [TestClass]
    public class FlexeraServiceTests : IFlexeraService
    {
        public List<Record> GetFileRecords(string location)
        {
            throw new System.NotImplementedException();
        }
    }
}
