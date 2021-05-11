using Models.Common;

namespace MyAuthors.Model
{
    public class Author : IAuthors
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public bool IsAlive { get; set; }
        public Author(int AuthorID, string Name, bool IsAlive)
        {
            this.AuthorID = AuthorID;
            this.Name = Name;
            this.IsAlive = IsAlive;
        }
        public Author() { }
    }
}