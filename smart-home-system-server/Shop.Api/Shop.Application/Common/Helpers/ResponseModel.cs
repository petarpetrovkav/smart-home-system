using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Helpers
{
    public class ResponseModel
    {
        public bool isValid { get; set; }

        public string? ResponseMessage { get; set; }
    }
}
