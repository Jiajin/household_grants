using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GovtGrants.Models
{
    public class ResponseObj
    {
        public DateTime Timestamp { get; set; }
        public bool IsSuccess { get; set; }
        public object Message { get; set; }
    }
}