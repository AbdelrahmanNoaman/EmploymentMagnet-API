using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Exceptions
{
    //A user defined exception that will be handled different than the normal ones
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
