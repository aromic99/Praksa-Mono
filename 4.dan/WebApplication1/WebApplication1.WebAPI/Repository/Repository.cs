using MyAuthors.Model;
using MyBooks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Http;
using System.Net.Http;

namespace Project.Repository
{
    public class LibraryRepository
    {
        private static readonly string myConnectionString = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
        private static readonly SqlConnection myConnection = new SqlConnection(myConnectionString);
        private static SqlDataReader reader;
        public static List<Books> AllBooks()
        {
            List<Books> books = new List<Books>();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * FROM Books ";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            Books book = null;
            while (reader.Read())
            {
                book = new Books();
                book.BookId = Convert.ToInt32(reader.GetValue(0));
                book.Name = reader.GetValue(1).ToString();
                book.Year = Convert.ToInt32(reader.GetValue(2));
                book.AuthorID = Convert.ToInt32(reader.GetValue(3));
                books.Add(book);
            }
            myConnection.Close();
            return books;
            
        }
        public static List<Authors> AllAuthors()
        {
            List<Authors> authors = new List<Authors>();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * FROM Authors ";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            Authors author = null;
            while (reader.Read())
            {
                author = new Authors();
                author.AuthorID = Convert.ToInt32(reader.GetValue(0));
                author.Name = reader.GetValue(1).ToString();
                author.IsAlive = Convert.ToBoolean(reader.GetValue(2));
                authors.Add(author);
            }
            myConnection.Close();
            return authors;
            
        }
        public static Books BookById(int id)
        {   
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * FROM Books WHERE BookID=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            Books book = null;
            while (reader.Read())
            {
                book = new Books();
                book.BookId = Convert.ToInt32(reader.GetValue(0));
                book.Name = reader.GetValue(1).ToString();
                book.Year = Convert.ToInt32(reader.GetValue(2));
                book.AuthorID = Convert.ToInt32(reader.GetValue(3));
            }
            myConnection.Close();
            return book;
        }
        public static void AddBook([FromBody] Books book)
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
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }
        public static void UpdateAuthor(int id, [FromBody] Authors author)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE Authors SET  Name = @Name, IsAlive= @IsAlive WHERE AuthorID=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            sqlCmd.Parameters.AddWithValue("@Name", author.Name);
            sqlCmd.Parameters.AddWithValue("@IsAlive", author.IsAlive);
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }
        public static void DeleteBook(int id)
        {   
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "DELETE FROM Books WHERE BookID=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            sqlCmd.ExecuteReader();
            myConnection.Close();
        }

    }

}