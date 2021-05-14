using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Common
{
    public class FilteringBooks : IFilteringBooks
    {
        public int Year { get; set; }

        public string HowToFilter(IFilteringBooks howToFilter)
        {
            if (howToFilter.Year > 0)
            {
                return "Where Year >" + howToFilter.Year;
            }

            return "";
        }

    }
}
