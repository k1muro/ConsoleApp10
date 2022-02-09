using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp10
{
    public partial class Book
    {
        public Book()
        {
            Autors = new HashSet<Autor>();
            CustomerBooks = new HashSet<CustomerBook>();
        }

        public int Id { get; set; }
        public string BookN { get; set; }
        public DateTime? DateBuy { get; set; }
        public DateTime? DateReturn { get; set; }

        public virtual ICollection<Autor> Autors { get; set; }
        public virtual ICollection<CustomerBook> CustomerBooks { get; set; }
    }
}
