using ProgramCreation.Interfaces;
using ProgramCreation.Models.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramCreation.DTOs;

namespace ProgramCreation.Models.Factory
{
    public class QuestionFactory
    {
            
            public static IQuestion CreateQuestion(QuestionDTO quesInfo)
            {

                //We need to make an extra check here as the type should be from the stored ones in database;
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
