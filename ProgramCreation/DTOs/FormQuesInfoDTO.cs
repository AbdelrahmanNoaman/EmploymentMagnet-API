using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.DTOs
{
    //DTO is used to add question Info for the form
    public class FormQuesInfoDTO
    {
        public QuestionInfoDTO? QuestionInfo { get; set; }
        public string FormId { get; set; }
    }
}
