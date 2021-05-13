using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAuthors.Model;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Http;
using IRepository;
using Models.Common;
using AutoMapper;
using WebApp.Common;


namespace Project.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
       
        private static readonly string myConnectionString = ConfigurationManager.ConnectionStrings["defcon"].ConnectionString;
        private static readonly SqlConnection myConnection = new SqlConnection(myConnectionString);
        private static SqlDataReader reader;

        public async Task<List<IAuthors>> AllAuthors(SortingAuthors howToSort)
        {
            
            List<IAuthors> authors = new List<IAuthors>();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * FROM Authors ";
            if (!howToSort.Sort())
            {
                sqlCmd.CommandText += " ORDER BY " + howToSort.SortBy + " " + howToSort.SortOrder;
            }
            try 
            {
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    IAuthors author = new Author();
                    author.AuthorID = Convert.ToInt32(reader.GetValue(0));
                    author.Name = reader.GetValue(1).ToString();
                    author.IsAlive = Convert.ToBoolean(reader.GetValue(2));
                    authors.Add(author);
                }
            }
            finally
            {
                myConnection.Close();
                
            }
            await Task.Delay(20);
            return authors;

        }
        public async Task<IAuthors> AuthorById(int id)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * FROM Authors WHERE AuthorID=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            IAuthors author = null;
            while (reader.Read())
            {
                author = new Author();
                author.AuthorID = Convert.ToInt32(reader.GetValue(0));
                author.Name = reader.GetValue(1).ToString();
                author.IsAlive = Convert.ToBoolean(reader.GetValue(2));

            }
            myConnection.Close();
            await Task.Delay(20);
            return author;
        }
        public async Task AddAnAuthor([FromBody] IAuthors author)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO Authors(AuthorID, Name, IsAlive) VALUES(@AuthorID, @Name, @IsAlive); ";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            sqlCmd.Parameters.AddWithValue("@AuthorID", author.AuthorID);
            sqlCmd.Parameters.AddWithValue("@Name", author.Name);
            sqlCmd.Parameters.AddWithValue("@IsAlive", author.IsAlive);
            await Task.Delay(20);
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }
        public async Task UpdateAnAuthor(int id, [FromBody] IAuthors author)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE Authors SET  Name = @Name, IsAlive= @IsAlive WHERE AuthorID=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            sqlCmd.Parameters.AddWithValue("@Name", author.Name);
            sqlCmd.Parameters.AddWithValue("@IsAlive", author.IsAlive);
            await Task.Delay(20);
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }
        public async Task DeleteAnAuthor(int id)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "DELETE FROM Authors WHERE AuthorID=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            await Task.Delay(20);
            sqlCmd.ExecuteReader();
            myConnection.Close();
        }
    }
}
