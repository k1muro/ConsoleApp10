using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp10
{
    public partial class CustomerBook
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? BooksId { get; set; }

        public virtual Book Books { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
