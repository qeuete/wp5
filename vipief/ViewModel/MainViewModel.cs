using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Linq;
using vipief.Model;
using vipief.ViewModel.Helpers;
using static System.Reflection.Metadata.BlobBuilder;

namespace vipief.ViewModel
{
    internal class MainViewModel : BindingHelper
    {
        private ObservableCollection<Book> books;
        public ObservableCollection<Book> Books
        {
            get { return books; }
            set
            {
                books = value;
                OnPropertyChanged();
            }
        }

        private readonly string filePath = "books.json"; // Переменная filePath объявлена в классе MainViewModel

        #region Constructor

        public MainViewModel()
        {
            LoadBooks(); 
        }

        #endregion

        #region Methods

        private void LoadBooks()
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var deserializedBooks = JsonConvert.DeserializeObject<List<Book>>(json);
                Books = new ObservableCollection<Book>(deserializedBooks);
            }
            else
            {
              
                Books = new ObservableCollection<Book>();
            }
        }

        #endregion
    }
}