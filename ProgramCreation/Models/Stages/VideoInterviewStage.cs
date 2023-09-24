using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramCreation.Enums;
using ProgramCreation.Models;

namespace ProgramCreation.Models
{
    public class VideoInterviewStage:Stage
    {
        private string _interviewQuestion;
        private string _additionalInfo;
        private int _maxDurationOfVideo;
        private TimeEnum _timeIn;
        private int _numberOfDaysLeft;

        public string InterviewQuestion { get { return this._interviewQuestion; } set {this._interviewQuestion=value; } }
        public string AdditionalInfo { get { return this._additionalInfo; } set { this._additionalInfo = value; } }
        public int MaxDuration { get { return this._maxDurationOfVideo; } set { this._maxDurationOfVideo = value; } }
        public TimeEnum TimeIn { get { return this._timeIn; } set { this._timeIn = value; } }
        public int NumberOfDaysLeft { get { return this._numberOfDaysLeft; } set { this._numberOfDaysLeft = value; } }

        public VideoInterviewStage(string id,string name,bool isShown, string interviewQues, string additionalInfo, int maxDuration, TimeEnum timeIn,int numberOfDaysLeft ):base(id,name,"Video interview",isShown)
        {
            this.InterviewQuestion = interviewQues;
            this.AdditionalInfo = additionalInfo;
            this.MaxDuration = maxDuration;
            this.TimeIn = timeIn;
            this.NumberOfDaysLeft = numberOfDaysLeft;
        }
    }
}
