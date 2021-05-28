using System;

namespace Models.Common
{
    public interface IAuthors
    {
        Guid AuthorID { get; set; }
        bool IsAlive { get; set; }
        string Name { get; set; }
    }
}