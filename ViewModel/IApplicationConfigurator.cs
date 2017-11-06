using System.ComponentModel;
using System.Windows.Input;

namespace ViewModel
{
    public interface IApplicationConfigurator : INotifyPropertyChanged
    {
        string Language { get; set; }
        string ReaderPath { get; set; }
        string DataBaseConnectionString { get; set; }

        ICommand SaveCommand { get;} 
    }
}