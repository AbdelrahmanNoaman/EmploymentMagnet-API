using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Models.ProgramInfo
{
    public class ProgramInfo
    {
        private string? _id;
        private string _title;
        private string? _summary;
        private string _description;
        private List<string>? _skills;
        private string? _benefits;
        private string? _applicationCriteria;
        private string _type;
        private string? _programStart;
        private string _applicationOpen;
        private string _applicationClose;
        private string? _duration;
        private string _programLocation;
        private bool _fullyRemote;
        private string? _minQualification;
        private int? _maxNumberOfApplication;
        public string id { get { return this._id; } set { this._id = value; } }
        public string Title { get { return this._title; } set { this._title = value; } }
        public string Summary { get { return this._summary; } set { this._summary = value; } }
        public string Description { get { return this._description; } set { this._description = value; } }
        public List<string> Skills { get { return this._skills; } set { this._skills = value; } }
        public string Benefits { get { return this._benefits; } set { this._benefits = value; } }
        public string ApplicationCriteria { get { return this._applicationCriteria; } set { this._applicationCriteria = value; } }
        public string Type { get { return this._type; } set { this._type = value; } }
        public string ProgramStart { get { return this._programStart; } set { this._programStart = value; } }
        public string ApplicationOpen { get { return this._applicationOpen; } set { this._applicationOpen = value; } }
        public string ApplicationClose { get { return this._applicationClose; } set { this._applicationClose = value; } }
        public string Duration { get { return this._duration; } set { this._duration = value; } }
        public string ProgramLocation { get { return this._programLocation; } set { this._programLocation = value; } }
        public bool FullyRemote { get { return this._fullyRemote; } set { this._fullyRemote = value; } }
        public string MinQualification { get { return this._minQualification; } set { this._minQualification = value; } }
        public int? MaxNumberOfApplication { get { return this._maxNumberOfApplication; } set { this._maxNumberOfApplication = value; } }

        /*public ProgramInfo(string id, string title, string summary, string description, List<string> skills, string benefits, string applicationCriteria, string type, string programStart, string applicationOpen, string applicationClose, string duration, string programLocation, bool fullyRemote, string minQualification, int maxNumberOfApplication)
        {
            this.id = id;
            Title = title;
            Summary = summary;
            Description = description;
            Skills = skills;
            Benefits = benefits;
            ApplicationCriteria = applicationCriteria;
            Type = type;
            ProgramStart = programStart;
            ApplicationOpen = applicationOpen;
            ApplicationClose = applicationClose;
            Duration = duration;
            ProgramLocation = programLocation;
            FullyRemote = fullyRemote;
            MinQualification = minQualification;
            MaxNumberOfApplication = maxNumberOfApplication;
        }*/
    }
}
