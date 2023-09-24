using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Exceptions
{
    public class userDefinedException:Exception
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public userDefinedException(int statusCode,string message)
        {
            this.StatusCode= statusCode;
            this.Message = message;
        }
    }
}
