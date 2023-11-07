using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp5.Commands;
using WpfApp5.Models;

namespace WpfApp5.ViewModels.PageViewModels
{
    public class AddViewModel:INotifyPropertyChanged
    {
        private User? user1;
        public User? User { get => user1; set { user1 = value; OnPropertyChanged(); } }

        private Address? address;
        public Address? Address { get => address; set { address = value; OnPropertyChanged(); } }

        private Company? company;
        public Company? Company { get => company; set { company = value; OnPropertyChanged(); } }

        private ObservableCollection<User> users;
        public ObservableCollection<User> Users
        {
            get { return users; }
            set { users = value; OnPropertyChanged(); }
        }
        public ICommand AddCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public AddViewModel(ObservableCollection<User> users)
        {
            User = new User();
            Address = new Address();
            Company = new Company();
            Users = users;
            AddCommand = new RelayCommand(AddElement);
            BackCommand = new RelayCommand(GoBack);
        }

        public void GoBack(object? parametr)
        {
            var page = parametr as Page;
            page.NavigationService.GoBack();
        }

        public void AddElement(object?parametr) 
        {
            User!.address = Address;
            User!.company = Company;
            Users.Add(User);

            var folder = new DirectoryInfo("../../../Database");
            var fullPath = Path.Combine(folder.FullName, "User.json");

            var json = JsonSerializer.Serialize<ObservableCollection<User>>(Users);
            File.WriteAllText(fullPath, json);
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
