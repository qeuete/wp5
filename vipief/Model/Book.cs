using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vipief.Model
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Page { get; set; }

        public Book(string tittle, string authoe, string genre, int page)
        {
            Title = tittle;
            Author = authoe;
            Genre = genre;
            Page = page;
        }
        public Book() { }
    }
}