using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using WpfApp5.Commands;
using WpfApp5.Models;
using WpfApp5.Views.PageViews;
using WpfApp5.Views.WindowViews;

namespace WpfApp5.ViewModels.PageViewModels
{
    public class ChoiceViewModel:INotifyPropertyChanged
    {

		private ObservableCollection<User> users;

		public  ObservableCollection<User> Users
		{
			get { return  users; }
			set { users = value; OnPropertyChanged(); }
		}

		public ICommand RemoveCommand { get; set; }
		public ICommand GetAllCommand { get; set; }
		public ICommand AddCommand { get; set; }
		public ICommand EditCommand { get; set; }

		public ChoiceViewModel()
		{
			var folder = new DirectoryInfo("../../../Database");
			var fullPath = Path.Combine(folder.FullName, "User.json");

			var JsonText = File.ReadAllText(fullPath);
			var users2 = JsonSerializer.Deserialize<ObservableCollection<User>>(JsonText);

			Users = users2;

			GetAllCommand = new RelayCommand(GetAllAdd);
			RemoveCommand = new RelayCommand(RemoveElement,checkRemove);
			AddCommand = new RelayCommand(AddElement);
            EditCommand = new RelayCommand(EditCar, CanEditCar);

		}

        public void EditCar(object? parameter)
        {
            User newCar = Users[(int)parameter];
            EditView? editView = new EditView();
            editView!.DataContext = new EditViewModel(newCar);
            editView.ShowDialog();

            var folder = new DirectoryInfo("../../../Database");
            var fullPath = Path.Combine(folder.FullName, "User.json");

            var json = JsonSerializer.Serialize<ObservableCollection<User>>(Users);
            File.WriteAllText(fullPath, json);

        }

        public bool CanEditCar(object? parameter)
        {
            var param = (int)parameter;
            return param != -1;
        }

        public void AddElement(object? parametr)
        {
            var page2 = parametr as Page;

            if (page2 != null)
            {
                var page = new AddPageView();
                page.DataContext = new AddViewModel(Users);
                page2.NavigationService.Navigate(page);
            }
        }

        public void GetAllAdd(object?parametr) 
		{
			var page2 = parametr as Page; 

			if(page2 != null)
			{
                var page = new GetAllPageView();
                page.DataContext = new GetAllViewModel(Users);
                page2.NavigationService.Navigate(page);
            }
		}

        public void RemoveElement(object? parametr)
        {


            int index = Convert.ToInt32(parametr);
            Users.RemoveAt(index);

            var folder = new DirectoryInfo("../../../Database");
            var fullPath = Path.Combine(folder.FullName, "User.json");

            var json = JsonSerializer.Serialize<ObservableCollection<User>>(Users);
			File.WriteAllText(fullPath,json);

        }

        public bool checkRemove(object? parametr)
        {

			if(parametr != null)
			{
                int index = Convert.ToInt32(parametr);
                if (index != -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
			return false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string? propertyName = null) 
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}
