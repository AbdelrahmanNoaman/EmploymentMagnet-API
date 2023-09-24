using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.DTOs
{
    //DTO that is used to add a question, as it will be aded in question container and the ofrm will be modified
    public class FormQuestionDTO
    {
        public QuestionDTO? Question { get; set; }
        public string FormId { get; set; }

    }
}
