using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class PaginationResult<T>
    {
        public List<T> Data { get; set; }
        public int PageCount { get; set; }
    }
}
