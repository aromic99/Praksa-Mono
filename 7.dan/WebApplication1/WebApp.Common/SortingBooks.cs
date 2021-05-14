using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Common
{
    public class SortingBooks : ISortingBooks
    {
        public string SortOrder { get; set; }
        public string SortBy { get; set; }

        public bool Sort()
        {
            if (SortBy == null && SortOrder == null)
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
                case "Year":
                    break;
                default:
                    return false;
            }
            return true;
        }

    }
}
