﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using WpfApp5.ViewModels.PageViewModels;

namespace WpfApp5.Views.PageViews
{
    /// <summary>
    /// Interaction logic for ChoicePageView.xaml
    /// </summary>
    public partial class ChoicePageView : Page
    {
        public ChoicePageView()
        {
            InitializeComponent();
            DataContext = new ChoiceViewModel();
        }
    }
}
