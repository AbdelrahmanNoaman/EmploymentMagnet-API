using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.DTOs
{
    //DTO that is used for sending just an id of an object
    public class ObjectWithId
    {
        public string id { get; set; }
        public ObjectWithId(string id)
        {
            this.id = id;
        }
    }
}
