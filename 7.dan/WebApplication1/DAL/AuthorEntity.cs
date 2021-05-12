using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AuthorEntity
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public bool IsAlive { get; set; }
    }
}
