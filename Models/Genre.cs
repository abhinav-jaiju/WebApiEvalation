using System;
using System.Collections.Generic;

namespace RentBook.Models
{
    public partial class Genre
    {
        public Genre()
        {
            BookTable = new HashSet<BookTable>();
        }

        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<BookTable> BookTable { get; set; }
    }
}
