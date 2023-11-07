using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp5.Models;

namespace WpfApp5.Views.PageViews
{
    /// <summary>
    /// Interaction logic for AddPageView.xaml
    /// </summary>
    public partial class AddPageView : Page
    {
        //User user { get;set;}
        //public ObservableCollection<User> Users { get; set; }
        public AddPageView()
        {
            InitializeComponent();
        }

        //private void asdfsdf(object sender, RoutedEventArgs e)
        //{
        //    user.id = Convert.ToInt32(id.Text.ToString());
        //    user.name = name.Text;
        //    user.username = username.Text;
        //    user.email = email.Text;
        //    user.company.bs = Bs.Text.ToString();
        //    user.company.name = cname.Text;
        //    user.website= website.Text;
        //    user.address.city = city.Text;
        //    user.address.street = street.Text;

        //    Users.Add(user);

        //    var folder = new DirectoryInfo("../../../Database");
        //    var fullPath = System.IO.Path.Combine(folder.FullName, "User.json");

        //    var json = JsonSerializer.Serialize<ObservableCollection<User>>(Users);
        //    File.WriteAllText(fullPath, json);

        //    user = new();
        //}
    }
}
