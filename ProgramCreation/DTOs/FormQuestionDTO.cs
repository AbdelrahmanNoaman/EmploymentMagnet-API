﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.DTOs
{
    public class FormQuestionDTO
    {
        public QuestionDTO? Question { get; set; }
        public string FormId { get; set; }

    }
}