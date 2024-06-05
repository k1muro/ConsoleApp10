using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp10
{
    public partial class Autor
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int BooksId { get; set; }dasdasdsa

        public virtual Book Books { get; set; }
    }
}
