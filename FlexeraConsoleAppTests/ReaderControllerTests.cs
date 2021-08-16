using FlexeraConsoleApp.Controller;
using FlexeraConsoleApp.Model;
using FlexeraConsoleAppTests.fake;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FlexeraConsoleAppTests
{
    [TestClass]
    public class ReaderControllerTests
    {
        private ReaderController _underTests;
        private FakeFlexeraService _flexeraService;
        private FakeApplicationLicenses _applicationLicenses;

        [TestInitialize]
        public void Setup()
        {
            _flexeraService = new FakeFlexeraService();
            _applicationLicenses = new FakeApplicationLicenses();
            _underTests = new ReaderController(_flexeraService, _applicationLicenses);
        }

        [TestMethod]
        public void NullIsRetrieved_WHEN_locationIsNull()
        {
            string location = null;

            var result = _underTests.GetTotalAppLicensesNeeded(location);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void NullIsRetrieved_WHEN_serviceIsSuccessful_AND_fileIsNotFound()
        {
            string location = "\\file\\unit-test.csv";
            _flexeraService.GetFileRecordsResult = null;
            _applicationLicenses.GetNumberOfLicensesResult = null;

            var result = _underTests.GetTotalAppLicensesNeeded(location);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void NumberOfLicensesIsNotNull_WHEN_serviceIsSuccessful_AND_fileIsFound()
        {
            string location = "\\file\\unit-test.csv";
            List<Record> list = new List<Record>();
            Record record = new Record();
            list.Add(record);
            int? expectedResult = 1;
            _flexeraService.GetFileRecordsResult = list;
            _applicationLicenses.GetNumberOfLicensesResult = expectedResult;

            var result = _underTests.GetTotalAppLicensesNeeded(location);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
