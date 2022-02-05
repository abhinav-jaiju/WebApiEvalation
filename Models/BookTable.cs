using System;
using System.Collections.Generic;

namespace RentBook.Models
{
    public partial class BookTable
    {
        public BookTable()
        {
            RentTable = new HashSet<RentTable>();
        }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public int? PublicationId { get; set; }
        public int? GenreId { get; set; }
        public int? Price { get; set; }
        public int? AuthorId { get; set; }

        public virtual AuthorTable Author { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Publication Publication { get; set; }
        public virtual ICollection<RentTable> RentTable { get; set; }
    }
}
