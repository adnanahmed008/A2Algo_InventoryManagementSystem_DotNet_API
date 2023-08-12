using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{
    public class Result
    {
        public bool HasError { get; set; } = false;
        public string Code { get; set; } = String.Empty;
        public string Message { get; set; } = String.Empty;
        public Exception? Exception { get; set; }
        public object? Data { get; set; }
    }

    public class Result<T> : Result
    {
        public new T? Data { get; set; }
    }
}
