using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOAN52.Authentication
{
    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public long TotalItems { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public dynamic Data { get; set; }
    }
}
