using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.DTOs
{
    public class ObjectWithId
    {
        public string id { get; set; }
        public ObjectWithId(string id)
        {
            this.id = id;
        }
    }
}
