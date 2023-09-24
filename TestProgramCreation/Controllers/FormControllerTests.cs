using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using ProgramCreation.Controllers;
using ProgramCreation.Data.Repositories;
using ProgramCreation.DTOs;

namespace TestProgramCreation.Controllers
{
    public class FormControllerTests
    {
        private readonly FormRepository _formRepository;
        private readonly QuestionRepository _quesRepo;
        private readonly FormQuestionRepository _formQuesRepository;
        public FormControllerTests()
        {
            _formRepository = A.Fake<FormRepository>();
            _quesRepo = A.Fake<QuestionRepository>();
            _formQuesRepository = A.Fake<FormQuestionRepository>();
        }

    }
}
