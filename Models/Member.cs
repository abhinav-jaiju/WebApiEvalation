using System;
using System.Collections.Generic;

namespace RentBook.Models
{
    public partial class Member
    {
        public Member()
        {
            RentTable = new HashSet<RentTable>();
        }

        public int MemberId { get; set; }
        public string MemberName { get; set; }

        public virtual ICollection<RentTable> RentTable { get; set; }
    }
}
