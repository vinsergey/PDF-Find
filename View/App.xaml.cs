using Model;
using System.Windows;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (e.Args.Length == 0)
            {
                SettingsWindow settingsWindow = new SettingsWindow();
                settingsWindow.Show();
            }
            else
            {
                ReportDataModel reportDataModel = new ReportDataModel(new RegistryApplicationConfigurator());
                string path = e.Args[0].ToString();
                ReportConfiguration report = reportDataModel.FindReport(path);
                if (report == null)
                {
                    if (reportDataModel.FindGroup(path) != null)
                    {
                        PrinterSettingsWindow settingsWindow = new PrinterSettingsWindow();
                        settingsWindow.Show();
                    }
                    else
                    {
                        reportDataModel.OpenInReader(path);
                    }
                }
                else
                {
                    reportDataModel.OpenForPrint(path, report);
                }
            }
        }
    }
}
