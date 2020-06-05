using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoNet.Web.Helpers
{
    public class Response<DTO>
    {
        public DTO Data { get; set; }
        public string Errors { get; set; }
    }
}
