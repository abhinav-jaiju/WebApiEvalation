using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentBook.ViewModel
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string GenreName { get; set; }
        public int? Price { get; set; }

        public string PublicationName { get; set; }
        public int? RentPrice { get; set; }
    }
}
