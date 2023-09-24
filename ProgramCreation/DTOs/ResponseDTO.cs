using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.DTOs
{
    //Response object that will be used with each controller to return a response that contains a data that the user cares about
    public class ResponseDTO<T>
    {
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public T Data { get; set; }

        public ResponseDTO(int statusCode, string statusDescription, T data)
        {
            this.StatusCode = statusCode;
            this.StatusDescription = statusDescription;
            this.Data = data;
        }
    }
}
