using System;
using System.Collections.Generic;

namespace RentBook.Models
{
    public partial class RentTable
    {
        public int RentId { get; set; }
        public int? BookId { get; set; }
        public int? RentPrice { get; set; }
        public DateTime? BookTakenDate { get; set; }
        public DateTime? BookReturnDate { get; set; }
        public int? MemberId { get; set; }

        public virtual BookTable Book { get; set; }
        public virtual Member Member { get; set; }
    }
}
