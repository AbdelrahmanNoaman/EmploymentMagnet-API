using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.DTOs
{
    //All The details of the question that should be returned to the user
    public class QuestionDTO
    {
            public string? id { get; set; }
            public string? Title { get; set; }
            public string? Type { get; set; }
            public string? SectionName { get; set; }
            public List<string>? Choices { get; set; }
            public bool? EnableOther { get; set; }
            public int? MaxChoiceAllowed { get; set; }
            public bool? IsHidden { get; set; }
            public bool? IsInternal { get; set; }
            public bool? IsMandatory { get; set; }
            public bool? IsDisqualified { get; set; }
    }
}
