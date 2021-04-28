using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using SimpleContactBook.Services;
using System.Linq;

namespace SimpleContactBook.ViewModels
{
    public class BookViewModel : ObservableObject
    {
        private ContactsViewModel _contactsVM;
        public ContactsViewModel ContactsVM
        {
            get { return _contactsVM; }
            set { _contactsVM = value; OnPropertyChanged(); }
        }

        // 没有选中用户时不能显示按钮
        private bool _isHidden;
        public bool IsHidden
        {
            get { return _isHidden; }
            set { _isHidden = value; OnPropertyChanged(); }
        }

        public IRelayCommand LoadFavoritesCommand { get; private set; }
        public IRelayCommand LoadContactsCommand { get; private set; }

        private readonly IContactDataService _dataService;
        private readonly IDialogService _dialogService;
        public BookViewModel(IContactDataService dataService, IDialogService dialogService)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            this.ContactsVM = new ContactsViewModel(dataService, dialogService);
            LoadContactsCommand = new RelayCommand(LoadContacts);
            LoadFavoritesCommand = new RelayCommand(LoadFavorites);
        }

        /// <summary>
        /// 获取联系人
        /// </summary>
        private void LoadContacts()
        {
            var contacts = _dataService.GetContacts();
            if (contacts!=null)
            {
                // 拿到转换集合类型后的联系人
                ContactsVM.LoadContacts(_dataService.GetContacts());
                IsHidden = true;
            }
        }
        private void LoadFavorites()
        {
            var favorites = _dataService.GetContacts().Where(c => c.IsFavorite);
            ContactsVM.LoadContacts(favorites);
        }
    }
}
