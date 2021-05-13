using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Common
{
    public class SortingAuthors
    {
        public string SortOrder { get; set; }
        public string SortBy { get; set; }

        public bool Sort()
        {
            if(SortBy == null && SortOrder == null)
            {
                return true;
            }
            switch (SortOrder)
            {
                case "asc":
                    break;
                case "desc":
                    break;
                default:
                    return false;
            }
            switch (SortBy)
            {
                case "Name":
                    break;
                case "AuthorID":
                    break;
                default:
                    return false;
            }
            return true;
        }
    }
}
