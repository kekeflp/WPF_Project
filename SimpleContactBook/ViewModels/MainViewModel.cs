using Microsoft.Toolkit.Mvvm.ComponentModel;
using SimpleContactBook.Services;

namespace SimpleContactBook.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        private BookViewModel _bookVM;
        public BookViewModel BookVM
        {
            get { return _bookVM; }
            set { _bookVM = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {
            var dataService = new ContactDataService();
            var dialogService = new DialogService();
            //var dataService = new JsonContactDataService();
            this.BookVM = new BookViewModel(dataService, dialogService);
            this.CurrentView = this.BookVM;
        }
    }
}
