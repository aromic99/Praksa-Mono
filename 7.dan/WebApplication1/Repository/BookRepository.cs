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

namespace Project.Repository
{
    public class BookRepository : IBookRepository
    {
        private static readonly string myConnectionString = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
        private static readonly SqlConnection myConnection = new SqlConnection(myConnectionString);
        private static SqlDataReader reader;
        public async Task<List<IBooks>> AllBooks()
        {
            List<IBooks> books = new List<IBooks>();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * FROM Books ";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            IBooks book = null;
            while (reader.Read())
            {
                book = new Book();
                book.BookId = Convert.ToInt32(reader.GetValue(0));
                book.Name = reader.GetValue(1).ToString();
                book.Year = Convert.ToInt32(reader.GetValue(2));
                book.AuthorID = Convert.ToInt32(reader.GetValue(3));
                books.Add(book);
            }
            myConnection.Close();
            await Task.Delay(20);
            return books;

        }

        public async Task<IBooks> BookById(int id)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * FROM Books WHERE BookID=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            IBooks book = null;
            while (reader.Read())
            {
                book = new Book();
                book.BookId = Convert.ToInt32(reader.GetValue(0));
                book.Name = reader.GetValue(1).ToString();
                book.Year = Convert.ToInt32(reader.GetValue(2));
                book.AuthorID = Convert.ToInt32(reader.GetValue(3));
            }
            myConnection.Close();
            await Task.Delay(20);
            return book;
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