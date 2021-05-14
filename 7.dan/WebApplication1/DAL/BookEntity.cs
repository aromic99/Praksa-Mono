using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BookEntity
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int AuthorID { get; set; }
    }
}
