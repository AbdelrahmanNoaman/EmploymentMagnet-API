using ProgramCreation.Interfaces;
using ProgramCreation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramCreation.DTOs;

namespace ProgramCreation.Models
{
    public class QuestionFactory
    {
        //Question Factory is Responsible for making a new Question Depening on it's type
        //As each type of Questions Has it's own Specifications
        //So I decided to make this using Factory design pattern
            
            public static IQuestion CreateQuestion(QuestionDTO quesInfo)
            {

                return quesInfo.Type switch
                {
                    "Yes/No" => new YesOrNoQuestion(quesInfo.id, quesInfo.Title, quesInfo.SectionName, (bool)quesInfo.IsDisqualified),
                    "Dropdown" => new DropdownQuestion(quesInfo.id, quesInfo.Title, quesInfo.SectionName, quesInfo.Choices, (bool)quesInfo.EnableOther),
                    "Multiple choice" => new MultipleChoiceQuestion(quesInfo.id, quesInfo.Title, quesInfo.SectionName, quesInfo.Choices, (bool)quesInfo.EnableOther, (int)quesInfo.MaxChoiceAllowed),
                    _ => new NormalQuestion(quesInfo.id, quesInfo.Title, quesInfo.SectionName, quesInfo.Type)
                } ;
            }
    }
}
