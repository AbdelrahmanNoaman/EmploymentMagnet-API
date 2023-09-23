using ProgramCreation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.DTOs
{
    public class StageDTO
    {
        public string? id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsShown { get; set; }
        public string? InterviewQuestion { get; set; }
        public string? AdditionalInfo { get;  set ; }
        public int? MaxDuration { get; set; }
        public TimeEnum? TimeIn { get; set ; }
        public int? NumberOfDaysLeft { get; set ; }

    }
}
