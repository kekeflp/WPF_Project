namespace WPF_SimpleTrader.WPF.ViewModels.Messages
{
    public class MessageViewModel : ViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasMessage));
            }
        }

        public bool HasMessage => !string.IsNullOrEmpty(Message);
    }
}
