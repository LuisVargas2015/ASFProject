using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class RequestEmployeeSearch
    {
        public string Name { get; set; }
        public DateTime? DateEntry { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public int Sorting { get; set; }


    }
}
