using Microsoft.Win32;
using System;

namespace SimpleContactBook.Services
{
    public class DialogService : IDialogService
    {
        public string OpenFile(string filter)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                return ofd.FileName;
            }
            return null;
        }

        public void ShowMessageBox(string message)
        {
            throw new NotImplementedException();
        }
    }
}
