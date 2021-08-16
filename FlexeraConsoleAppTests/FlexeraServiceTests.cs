using FlexeraConsoleApp.Controller.Services;
using FlexeraConsoleApp.Model;
using FlexeraConsoleAppTests.fake;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data;

namespace FlexeraConsoleAppTests
{
    [TestClass]
    public class FlexeraServiceTests
    {
        private FlexeraService _underTests;
        private FakeCSVReaderService _CSVReaderService;

        [TestInitialize]
        public void Setup()
        {
            _CSVReaderService = new FakeCSVReaderService();
            _underTests = new FlexeraService(_CSVReaderService);
        }

        [TestMethod]
        public void NullIsRetrieved_WHEN_locationIsNull()
        {
            string location = null;
            _CSVReaderService.ReadFileResults = null;

            List<Record> result = _underTests.GetFileRecords(location);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void NullIsRetrieved_WHEN_serviceIsSuccessful_AND_FileIsNotFound()
        {
            string location = "any";
            _CSVReaderService.ReadFileResults = null;

            List<Record> result = _underTests.GetFileRecords(location);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ListIsRetrieved_WHEN_serviceIsSuccessful_AND_FileIsFound()
        {
            string location = "any";
            DataTable dt = new DataTable();
            dt.Columns.Add("Value");
            DataRow row = dt.NewRow();
            row["Value"] = "anyHeader,anyHeader,anyHeader,anyHeader,anyHeader";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["Value"] = "any,any,any,any,any";
            dt.Rows.Add(row);
            _CSVReaderService.ReadFileResults = dt;

            List<Record> result = _underTests.GetFileRecords(location);

            Assert.IsNotNull(result);
        }
    }
}
