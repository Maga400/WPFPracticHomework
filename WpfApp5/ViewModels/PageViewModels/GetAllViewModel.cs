using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp5.Commands;
using WpfApp5.Models;

namespace WpfApp5.ViewModels.PageViewModels
{
    public class GetAllViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        public ICommand BackCommand { get; set; }
        public GetAllViewModel(ObservableCollection<User> users)
        {
            Users = users;
            BackCommand = new RelayCommand(GoBack);
        }
        public void GoBack(object? parametr)
        {
            var page = parametr as Page;
            page.NavigationService.GoBack();
        }

    }
}
