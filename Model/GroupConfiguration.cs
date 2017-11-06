using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class GroupConfiguration : PrinterConfiguration
    {
        #region Fields

        private string _groupName;

        #endregion

        #region Properties

        public ICollection<ReportConfiguration> Reports { get; set; }

        public string GroupName
        {
            get { return _groupName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Argument is null or whitespace", nameof(value));
                if (value.Length != 6)
                    throw new ArgumentException("Group name can'be other that 6 symbols", nameof(value));
                _groupName = value;
            }
        }

        #endregion

        public GroupConfiguration()
        {
            Reports = new HashSet<ReportConfiguration>();
        }

        #region Methods

        public ReportConfiguration CreateReport(string reportName)
        {
            if (string.IsNullOrWhiteSpace(reportName))
                throw new ArgumentException("Argument is null or whitespace", nameof(reportName));
            if (reportName.Length < 12)
                throw new ArgumentException("Report name can'be less that 12 symbols", nameof(reportName));
            // todo exception localizations
            // todo exception type
            if (!reportName.Substring(0, reportName.Length - 6).StartsWith(GroupName))
                throw new ArgumentException($"{nameof(reportName)} is not from this group.");

            var reportConfiguration = new ReportConfiguration { ReportName = reportName };

            if (Reports.Count > 0)
            {
                var first = Reports.First();
                if (Reports.All(configuration => configuration.PrinterName == first.PrinterName))
                    reportConfiguration.PrinterName = first.PrinterName;
                if (Reports.All(configuration => configuration.Duplex == first.Duplex))
                    reportConfiguration.Duplex = first.Duplex;
                if (Reports.All(configuration => configuration.PaperFormat == first.PaperFormat))
                    reportConfiguration.PaperFormat = first.PaperFormat;
            }

            return reportConfiguration;
        }

        #endregion
    }
}