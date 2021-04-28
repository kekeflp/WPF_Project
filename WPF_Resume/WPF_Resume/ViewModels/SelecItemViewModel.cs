using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using WPF_Resume.Models;

namespace WPF_Resume.ViewModels
{
    public class SelecItemViewModel : ObservableObject
    {
        public Person Person { get; set; }
        public List<Experience> Experiences { get; set; }
    }
}
