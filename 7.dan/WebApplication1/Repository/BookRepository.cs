using MyAuthors.Model;
using MyBooks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Http;
using System.Threading.Tasks;
using IRepository;
using Models.Common;
using WebApp.Common;
using AutoMapper;
using DAL;

namespace Project.Repository
{
    public class BookRepository : IBookRepository
    {
        private static readonly string myConnectionString = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
        private static readonly SqlConnection myConnection = new SqlConnection(myConnectionString);
        private static SqlDataReader reader;

        private readonly IMapper mapper;

        public BookRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<List<IBooks>> AllBooks(ISortingBooks howToSort, IFilteringBooks howToFilter, IPaging bookPaging)
        {
            List<BookEntity> books = new List<BookEntity>();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * FROM Books ";
            sqlCmd.CommandText += howToFilter.HowToFilter(howToFilter);
            if (!howToSort.Sort())
            {
                sqlCmd.CommandText += " ORDER BY " + howToSort.SortBy + " " + howToSort.SortOrder;
            }
            if (bookPaging == null)
            {
                sqlCmd.CommandText += "";
            }
            else
            {
                if (howToSort.SortBy != "")
                    if (bookPaging.DataPerPage != 0 && bookPaging.Page != 0)
                    {
                        sqlCmd.CommandText += " OFFSET " + bookPaging.DataPerPage * (bookPaging.Page - 1) + " ROWS FETCH NEXT " + bookPaging.DataPerPage + " ROWS ONLY ";
                    }
            }
            try
            {
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                reader = sqlCmd.ExecuteReader();
                BookEntity book = null;
                while (reader.Read())
                {
                    book = new BookEntity();
                    book.BookId = Convert.ToInt32(reader.GetValue(0));
                    book.Name = reader.GetValue(1).ToString();
                    book.Year = Convert.ToInt32(reader.GetValue(2));
                    book.AuthorID = Convert.ToInt32(reader.GetValue(3));
                    books.Add(book);
                }
            }
            finally
            {
                myConnection.Close();
            }

            await Task.Delay(20);
            return mapper.Map<List<IBooks>>(books);

        }

        public async Task<IBooks> BookById(int id)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * FROM Books WHERE BookID=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            BookEntity book = null;
            while (reader.Read())
            {
                book = new BookEntity();
                book.BookId = Convert.ToInt32(reader.GetValue(0));
                book.Name = reader.GetValue(1).ToString();
                book.Year = Convert.ToInt32(reader.GetValue(2));
                book.AuthorID = Convert.ToInt32(reader.GetValue(3));
            }
            myConnection.Close();
            await Task.Delay(20);
            return mapper.Map<IBooks>(book);
        }
        public async Task AddBook([FromBody] IBooks book)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO Books(BookID, Name, Year, AuthorID) VALUES(@BookID, @Name, @Year, @AuthorID); ";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            sqlCmd.Parameters.AddWithValue("@BookID", book.BookId);
            sqlCmd.Parameters.AddWithValue("@Name", book.Name);
            sqlCmd.Parameters.AddWithValue("@Year", book.Year);
            sqlCmd.Parameters.AddWithValue("@AuthorID", book.AuthorID);
            await Task.Delay(20);
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }
        public async Task Updatebook(int id, [FromBody] IBooks book)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE Books SET  Name = @Name, Year= @Year, AuthorID = @AuthorID WHERE BookID=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            sqlCmd.Parameters.AddWithValue("@Name", book.Name);
            sqlCmd.Parameters.AddWithValue("@Year", book.Year);
            sqlCmd.Parameters.AddWithValue("@AuthorID", book.AuthorID);
            await Task.Delay(20);
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }
        public async Task DeleteBook(int id)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "DELETE FROM Books WHERE BookID=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            await Task.Delay(20);
            sqlCmd.ExecuteReader();
            myConnection.Close();
        }

    }

}