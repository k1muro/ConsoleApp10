using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp10
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerBooks = new HashSet<CustomerBook>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Titel { get; set; }
        public bool? IsDebtor { get; set; }

        public virtual ICollection<CustomerBook> CustomerBooks { get; set; }
    }
}
