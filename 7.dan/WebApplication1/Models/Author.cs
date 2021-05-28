using Models.Common;
using System;

namespace MyAuthors.Model
{
    public class Author : IAuthors
    {
        public Guid AuthorID { get; set; }
        public string Name { get; set; }
        public bool IsAlive { get; set; }
        public Author(Guid AuthorID, string Name, bool IsAlive)
        {
            this.AuthorID = AuthorID;
            this.Name = Name;
            this.IsAlive = IsAlive;
        }
        public Author() { }
    }
}