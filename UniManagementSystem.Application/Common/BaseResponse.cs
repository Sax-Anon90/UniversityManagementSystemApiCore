using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniManagementSystem.Application.Common
{
    public class BaseResponse<T>
    {
        public bool Succeeded { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public List<string> ProblemErrors { get; set; } = new List<string>();
        public T? ResponseData { get; set; }
    }
}
