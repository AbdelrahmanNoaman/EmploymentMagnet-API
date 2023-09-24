using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramCreation.Models;

namespace ProgramCreation.DTOs
{
    //DTO is used to add a program info to a specified program using its id
    public class ProgramInfoDTO
    {
        public ProgramInfo programInfo { get; set; }
        public string ProgramId { get; set; }
    }
}
