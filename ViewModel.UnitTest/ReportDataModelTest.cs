using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ViewModel.UnitTest
{
    [TestClass]
    public class ReportDataModelTest
    {
        [TestMethod]
        public void Constructor()
        {
            try
            {
                new ReportDataModel(null);
                Assert.Fail();
            }
            catch (ArgumentNullException)
            {
                // ignore
            }

            // todo add database
            //new ReportDataModel(new TestApplicationConfigurator(), null);

        }
      

        //[TestMethod]
        //public void FindReport()
        //{
        //    // todo add database
        //    //var reportDataModel = new ReportDataModel(new TestApplicationConfigurator(), null);

        //    try
        //    {
        //        reportDataModel.FindReport(null);
        //        Assert.Fail();
        //    }
        //    catch (Exception)
        //    {
        //        // ignore
        //    }

        //    var reportConfiguration = reportDataModel.FindReport("TestReport_1");
        //    Assert.Fail("check { reportConfiguration}");
        //}
    }
}
