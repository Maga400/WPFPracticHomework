using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp5.Commands;
using WpfApp5.Models;

namespace WpfApp5.ViewModels.PageViewModels
{

    public class EditViewModel:INotifyPropertyChanged
    {
        private User? user1;
        public User? User { get => user1; set { user1 = value; OnPropertyChanged(); } }

        private User? referance;
        public User? Referance { get => referance; set { referance = value; OnPropertyChanged(); } }

        private Address? address;
        public Address? Address { get => address; set { address = value; OnPropertyChanged(); } }

        private Company? company;
        public Company? Company { get => company; set { company = value; OnPropertyChanged(); } }

        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand BackCommand { get; set; }

        public EditViewModel(User? user)
        {
            Referance = user;

            this.User = new User();
            this.Address = new Address();
            this.Company = new Company();
            this.User.id = user.id;
            this.User.name = user.name;
            this.User.username = user.username;
            this.User.email = user.email;
            this.Address.street = user.address.street;
            this.Address.city = user.address.city;
            this.Company.name = user.company.name;
            this.Company.bs = user.company.bs;
            this.User.website= user.website;
            
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);
            BackCommand = new RelayCommand(GoBack);
        }

        public void GoBack(object? paramter)
        {
            var window = paramter as Window;
            window.Close();
        }

        public void Cancel(object? paramter)
        {
            (paramter as Window)?.Close();
        }

        public void Save(object? paramter)
        {
            Referance!.id = User.id;
            Referance!.name = User.name;
            Referance!.username = User.username;
            Referance!.email = User.email;
            Referance!.address = Address;
            Referance!.company = Company;
            Referance!.website = User.website;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
