using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Newshore.Application.Wrappers
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? TotalItems { get; set; }
        public PagedResponse(T joruney, int pageNumber, int pageSize, int? totalItems = null)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Journey = joruney;
            this.Message = null;
            this.Succeeded = true;
            this.Erros = null;
            this.TotalItems = totalItems;
        }
    }
}
