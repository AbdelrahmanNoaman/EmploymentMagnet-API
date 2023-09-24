using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Models
{
    public class ProgramType
    {
        private string _name;

        public string Name { get { return _name; } set { this._name = value; } }

        public ProgramType(string name)
        {
            this.Name = name;
        }
    }
}
