using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentBook.ViewModel
{
    public class MemberWithRent
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int? RentPrice { get; set; }
        public DateTime? BookTakenDate { get; set; }
        public DateTime? BookReturnDate { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public int fine { get; set; }
    }
}
