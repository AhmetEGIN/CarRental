using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, bool success, string message) : base(false, data, message)
        {

        }
        public ErrorDataResult(T data, bool success) : base(data, false)
        {

        }
        public ErrorDataResult() : base(default, false)
        {

        }
        public ErrorDataResult(string message) : base(false, default, message)
        {

        }

    }
}
