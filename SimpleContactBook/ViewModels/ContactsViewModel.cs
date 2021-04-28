using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using SimpleContactBook.Models;
using SimpleContactBook.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SimpleContactBook.ViewModels
{
    public class ContactsViewModel : ObservableObject
    {
        private readonly IContactDataService _dataService;
        private readonly IDialogService _dialogService;

        private ObservableCollection<Contact> _contacts;
        public ObservableCollection<Contact> Contacts
        {
            get { return _contacts; }
            set { _contacts = value; OnPropertyChanged(); }
        }

        private Contact _selectedContact;
        public Contact SelectedContact
        {
            get { return _selectedContact; }
            set { _selectedContact = value; OnPropertyChanged(); }
        }

        // 是否为编辑状态, 标识
        // bool类型默认为false
        private bool _isEditMode;
        public bool IsEditMode
        {
            get { return _isEditMode; }
            set
            {
                _isEditMode = value;
                OnPropertyChanged();
                // 通知切换设置
                OnPropertyChanged(nameof(IsDisplayMode));
            }
        }

        public bool IsDisplayMode
        {
            get { return !_isEditMode; }
        }

        public IRelayCommand AddCommand { get; private set; }
        public IRelayCommand EditCommand { get; private set; }
        public IRelayCommand DeleteCommand { get; private set; }
        public IRelayCommand UpdateCommand { get; private set; }
        public IRelayCommand SaveCommand { get; private set; }
        public IRelayCommand BrowseImageCommand { get; private set; }

        public ContactsViewModel(IContactDataService dataService, IDialogService dialogService)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand(Edit);
            DeleteCommand = new RelayCommand(Delete);
            UpdateCommand = new RelayCommand(Update);
            SaveCommand = new RelayCommand(Save);
            BrowseImageCommand = new RelayCommand(BrowseImage);
        }

        private void Add()
        {
            if (SelectedContact != null)
            {
                var newContact = new Contact
                {
                    Name = "N/A",
                    PhoneNumbers = new string[2],
                    Emails = new string[2],
                    Locations = new string[2]
                };
                Contacts.Add(newContact);
                SelectedContact = newContact;
            }
        }

        private void Edit()
        {
            // 编辑时,设置为True
            IsEditMode = true;
        }

        private void Delete()
        {
            if (SelectedContact != null)
            {
                Contacts.Remove(SelectedContact);
                Save();
            }
        }

        private void Update()
        {
            _dataService.Save(Contacts);
        }

        private void Save()
        {
            _dataService.Save(Contacts);
            // 取消编辑模式
            IsEditMode = false;
            // 立即通知界面做了修改,而不是界面刷新或切换后才更新
            OnPropertyChanged(nameof(SelectedContact));
        }

        private bool CanEdit()
        {
            if (SelectedContact == null)
                return false;
            return !IsEditMode;
        }
        private bool IsEdit()
        {
            return IsEditMode;
        }
        private bool CanDelete()
        {
            return SelectedContact == null ? false : true;
        }

        private void BrowseImage()
        {
            var filePath = _dialogService.OpenFile("Image files|*.bmp;*.jpg;*.jpeg;*.png|All files");
            SelectedContact.ImagePath = filePath;
        }

        /// <summary>
        /// 对联系人集合进行集合类型转换为ObservableCollection
        /// </summary>
        /// <param name="contacts">IEnumerable类型的联系人</param>
        public void LoadContacts(IEnumerable<Contact> contacts)
        {
            this.Contacts = new ObservableCollection<Contact>(contacts);
        }
    }
}
