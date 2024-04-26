using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using vipief.Model;
using vipief.View;
using vipief.ViewModel;

namespace vipief
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            AddEditBookWindow addwindow = new AddEditBookWindow();
            addwindow.ShowDialog();
        } 
        private void Details_Click(object sender, RoutedEventArgs e)
        {
            BookDetailsWindow dtwindow = new BookDetailsWindow();
            dtwindow.ShowDialog();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SearchBookWindow swindow = new SearchBookWindow();
            swindow.ShowDialog();
        }
    }
}
