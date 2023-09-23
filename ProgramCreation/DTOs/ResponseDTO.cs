using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.DTOs
{
    internal class ResponseDTO<T>
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
