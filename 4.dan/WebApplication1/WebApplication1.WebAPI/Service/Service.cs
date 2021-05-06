using System;
using System.Collections.Generic;
using System.Linq;
using Project.Repository;
using MyAuthors.Model;
using MyBooks.Model;
using System.Web.Http;

namespace Project.Service
{
    public class Service 
    {
        public static List<Books> FindAllBooks()
        {
            return LibraryRepository.AllBooks();
        }
        public static List<Authors> FindAllAuthors()
        {
            return LibraryRepository.AllAuthors();
        }
        public static Books FindBookById(int id)
        {
            return LibraryRepository.BookById(id);
        }
        public static void AddNewBook([FromBody] Books book)
        {
            LibraryRepository.AddBook(book);
        }
        public static void UpdateAnAuthor(int id, [FromBody] Authors author)
        {
            LibraryRepository.UpdateAuthor(id, author);
        }
        public static void DeleteTheBook(int id)
        {
            LibraryRepository.DeleteBook(id);
        }
    }
}