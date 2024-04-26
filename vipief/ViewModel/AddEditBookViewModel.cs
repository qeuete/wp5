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

    internal class AddEditBookViewModel : BindingHelper
    {
        #region Properties
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand EditCommand { get; }
        #endregion

        private Book selected = new Book();
        public Book Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged();
            }
        }

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
        private readonly string filePath = "books.json";

        #region Constructor

        public AddEditBookViewModel()
        {
            AddCommand = new BindableCommand(_ => AddBook());
            DeleteCommand = new BindableCommand(_ => RemoveBook());
            EditCommand = new BindableCommand(_ => UpdateBook());

            LoadBooks();
        }
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
                Books = new ObservableCollection<Book>()
                {
                    new Book("Книга1", "Автор1", "Жанр1", 123),
                    new Book("Книга2", "Автор2", "Жанр2", 456)
                };
            }
        }

        public void AddBook()
        {
            Books.Add(Selected);
            Selected = new Book();

            SerializeBooks();
        }


        public void UpdateBook()
        {
            int index = Books.IndexOf(Selected);

            if (index != -1)
            {
                Books[index].Title = Selected.Title;
                Books[index].Author = Selected.Author;
                Books[index].Genre = Selected.Genre;
                Books[index].Page = Selected.Page;

                SerializeBooks();
            }
        }

        public void RemoveBook()
        {
            Books.Remove(Selected);
            SerializeBooks();
        }

        private void SerializeBooks()
        {
            var json = JsonConvert.SerializeObject(Books);
            File.WriteAllText(filePath, json);
        }

        #endregion
    }

    #region Event Handlers
    #endregion
}
    
