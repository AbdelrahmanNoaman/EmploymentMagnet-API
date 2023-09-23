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
    internal class QuestionFactory
    {
        internal class QuestionsFactory
        {
            
            public static IQuestion CreateQuestion(QuestionDTO quesInfo)
            {

                //We need to make an extra check here as the type should be from the stored ones in database;
                string newId = Guid.NewGuid().ToString();
                return quesInfo.Type switch
                {
                    "Yes/No" => new YesOrNoQuestion(newId, quesInfo.Title, quesInfo.SectionName, (bool)quesInfo.IsDisqualified),
                    "Dropdown" => new DropdownQuestion(newId, quesInfo.Title, quesInfo.SectionName, quesInfo.Choices, (bool)quesInfo.EnableOther),
                    "Multiple choice" => new MultipleChoiceQuestion(newId, quesInfo.Title, quesInfo.SectionName, quesInfo.Choices, (bool)quesInfo.EnableOther, (int)quesInfo.MaxChoiceAllowed),
                    _ => new NormalQuestion(newId, quesInfo.Title, quesInfo.SectionName, quesInfo.Type)
                } ;
            }
        }
    }
}
