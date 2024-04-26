using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using vipief.Model;
using vipief.ViewModel.Helpers;
using vipief.Model;
using vipief.ViewModel.Helpers;
using static System.Reflection.Metadata.BlobBuilder;


namespace vipief.ViewModel
{
    internal class SearchBookViewModel : BindingHelper
    {
        #region Properties
        public ICommand SearchCommand { get; }

        #endregion

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

        private string selectedTitle;
        public string SelectedTitle
        {
            get { return selectedTitle; }
            set
            {
                selectedTitle = value;
                OnPropertyChanged();
            }
        }

        private readonly string filePath = "books.json"; // Переменная filePath объявлена в классе MainViewModel

        #region Constructor

        public SearchBookViewModel()
        {
            SearchCommand = new BindableCommand(_ => Search());
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
        private void Search()
        {
            if (string.IsNullOrEmpty(SelectedTitle))
            {
                LoadBooks();
            }
            else
            {
                var filteredBooks = Books.Where(book => book.Title.ToLower().Contains(SelectedTitle.ToLower())).ToList();
                Books.Clear();
                foreach (var book in filteredBooks)
                {
                    Books.Add(book);
                }
            }
        }
        #endregion
    }
}