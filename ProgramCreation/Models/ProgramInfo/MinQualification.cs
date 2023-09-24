using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Models
{
    public class MinQualification
    {
        private string _name;

        public string Name { get { return _name; } set { this._name = value; } }

        public MinQualification(string name)
        {
            this.Name = name;
        }
    }
}
