using System;
using System.Linq;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BooksaContext db = new BooksaContext())
            {
                /* db.Books.Add(new Book() { BookN = "1", DateBuy = DateTime.Now, DateReturn = DateTime.Now });
                 db.SaveChanges();*/
                Book b = db.Books.Where(o => o.Id == 1).First();
                db.Books.Remove(b);

            }
        }
    }
}
