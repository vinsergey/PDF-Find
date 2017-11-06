using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Model.Tests
{
    [TestClass]
    public class GroupConfigurationTest
    {
        [TestMethod]
        public void GroupConfigurationCreateReportTest()
        {
            var groupName = "Report";
            var group = new GroupConfiguration() { GroupName = groupName };

            var printer = "testPrinter";

            var list = new List<ReportConfiguration>
            {
                new ReportConfiguration { PaperFormat = PaperFormat.Letter, PrinterName = printer, Duplex = true},
                new ReportConfiguration { PaperFormat = PaperFormat.Letter, PrinterName = printer, Duplex = true},
                new ReportConfiguration { PaperFormat = PaperFormat.Letter, PrinterName = printer, Duplex = true},
                new ReportConfiguration { PaperFormat = PaperFormat.Letter, PrinterName = printer, Duplex = false}
            };

            list.ForEach(group.Reports.Add);

            var reportName = groupName + "SomeName";
            var report = group.CreateReport(reportName);

            Assert.AreEqual(report.ReportName, reportName);
            Assert.AreEqual(report.PrinterName, printer);
            Assert.AreEqual(report.PaperFormat, PaperFormat.Letter);
            Assert.AreNotEqual(report.Duplex, true);
        }
    }
}
