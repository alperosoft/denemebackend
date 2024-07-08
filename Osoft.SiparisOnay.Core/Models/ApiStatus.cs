using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osoft.SiparisOnay.Core.Models
{
    public class ApiStatus<T>
    {
        public int statusCode { get; set; }
        public int tableId { get; set; }
        public object json { get; set; }
        public List<T> data { get; set; }
        public int rowCount { get; set; } = 0;
        public object? errors { get; set; }

        //public string type { get; set; }
        //public string title { get; set; }
        //public string traceId { get; set; }

    }
}
