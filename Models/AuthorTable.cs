using System;
using System.Collections.Generic;

namespace RentBook.Models
{
    public partial class AuthorTable
    {
        public AuthorTable()
        {
            BookTable = new HashSet<BookTable>();
        }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public virtual ICollection<BookTable> BookTable { get; set; }
    }
}
