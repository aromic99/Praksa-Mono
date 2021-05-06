using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Configuration;

namespace WebApplication2.webAPI.Controllers
{
    public class Authors
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public bool IsAlive { get; set; }

    }
    public class Books
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int AuthorID { get; set; }
    }

    public class ValuesController : ApiController
    {
        // GET api/values
        /*
        [HttpGet]
        public List<Books> GetBooks()
        {
            SqlDataReader reader;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=tcp:praksa.database.windows.net,1433;Initial Catalog=Praksa-Mono;Persist Security Info=False;User ID=aromic;Password=Praksamono21;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

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
            return books;
        
        }*/
        [HttpGet]
        public List<Authors> GetAuthors()
        {
            SqlDataReader reader;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=tcp:praksa.database.windows.net,1433;Initial Catalog=Praksa-Mono;Persist Security Info=False;User ID=aromic;Password=Praksamono21;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

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
            return authors;

        }
        
        // GET api/values/5

        [HttpGet]
        public Books Get(int id)
        {
            //return listEmp.First(e => e.ID == id);  
            SqlDataReader reader;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=tcp:praksa.database.windows.net,1433;Initial Catalog=Praksa-Mono;Persist Security Info=False;User ID=aromic;Password=Praksamono21;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

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

            return book;
        }

        // POST api/values


        [HttpPost]
        public void AddBook([FromBody] Books book)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=tcp:praksa.database.windows.net,1433;Initial Catalog=Praksa-Mono;Persist Security Info=False;User ID=aromic;Password=Praksamono21;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

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

        
    // PUT api/values/5
    [HttpPut]
    public void UpdateAuthor(int id, [FromBody] Authors author)
    {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=tcp:praksa.database.windows.net,1433;Initial Catalog=Praksa-Mono;Persist Security Info=False;User ID=aromic;Password=Praksamono21;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE Authors SET AuthorID= @AuthorID , Name = @Name, IsAlive= @IsAlive WHERE AuthorID=" + id +"";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            sqlCmd.Parameters.AddWithValue("@AuthorID", author.AuthorID);
            sqlCmd.Parameters.AddWithValue("@Name", author.Name);
            sqlCmd.Parameters.AddWithValue("@IsAlive", author.IsAlive);
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();
    }

        // DELETE api/values/5
    public void Delete(int id)
    {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=tcp:praksa.database.windows.net,1433;Initial Catalog=Praksa-Mono;Persist Security Info=False;User ID=aromic;Password=Praksamono21;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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

