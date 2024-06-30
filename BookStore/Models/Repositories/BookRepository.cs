using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repositories
{
    public class BookRepository : IBookStoreRepository<Book>
    {
        List<Book> Books; 
        public BookRepository()
        {
            Books = new List<Book>() 
            {
                new Book
                {
                    Id = 1, 
                    Title = "abcd", 
                    Description = "gfejdoncsopmwes", 
                    ImageUrl = "", //image
                    Author = new Author{Id = 1, FullName = "auth1"}
                },
                new Book
                {
                    Id = 2,
                    Title = "rwcdsxa",
                    Description = "gvjofnckwdmslpx,;zgvfjcdskl,xrfewweww",
                    ImageUrl = "",//image
                    Author = new Author{Id = 1, FullName = "auth2"}
                },
                new Book
                {
                    Id = 3,
                    Title = "poiuy",
                    Description = "ghbfniwdcskxlkvefdmc",
                    ImageUrl = "",//images
                    Author = new Author{Id = 1, FullName = "auth3"}
                }
            };
        }
        public void Add(Book NewBook)
        {
            NewBook.Id = Books.Max(b => b.Id) + 1; 
            Books.Add(NewBook);
        }

        public void Delete(int Id)
        {
            Book book = Find(Id);
            Books.Remove(book);
        }

        public Book Find(int Id)
        {
            Book book = Books.SingleOrDefault(b => b.Id == Id);
            return book; 
        }

        public IList<Book> List()
        {
            return Books; 
        }

        public List<Book> Search(string term)
        {
            var result = Books.
                Where(b =>
                b.Title.Contains(term) ||
                b.Description.Contains(term) ||
                b.Author.FullName.Contains(term)
                ).ToList();
            return result;
        }

        public void Update(int Id, Book NewBook)
        {
            Book book = Find(Id);
            book.Title = NewBook.Title;
            book.Description = NewBook.Description;
            book.Author = NewBook.Author;
            book.ImageUrl = NewBook.ImageUrl;
        }

        public void Update(Book Entity)
        {
            throw new NotImplementedException();
        }
    }
}
