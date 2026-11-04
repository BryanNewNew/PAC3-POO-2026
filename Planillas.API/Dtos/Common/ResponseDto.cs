using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planillas.API.Dtos.Common
{
    public class ResponseDto<T>
    {
        public int StatusCode { get; set; }
        public bool Status { get; set; }

        public string? Message { get; set; }

        public T? Data { get; set; }
    }
}