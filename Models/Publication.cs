using System;
using System.Collections.Generic;

namespace RentBook.Models
{
    public partial class Publication
    {
        public Publication()
        {
            BookTable = new HashSet<BookTable>();
        }

        public int PublicationId { get; set; }
        public string PublicationName { get; set; }

        public virtual ICollection<BookTable> BookTable { get; set; }
    }
}
