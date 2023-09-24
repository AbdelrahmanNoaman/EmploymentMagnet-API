using ProgramCreation.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Models
{
    //Form of the application that contains all the needed data for the application of the program
    //It contains only the list of question Ids which will be stored in the database just to minimize the space locate as much as possible
    //And when we are going to retrieve it, then We would expand that id and get the needed data
    public class ProgramForm
    {

        private string _id;
        private bool _isCoverImgExist;
        private List<QuestionInfoDTO> _questionIds;
        public string id { get { return this._id; } set { this._id = value; }}
        public bool IsCoverImgExist { get { return this._isCoverImgExist; } set { this._isCoverImgExist = value; } }
        public List<QuestionInfoDTO> QuestionsIds { get { return this._questionIds; } set { this._questionIds = value; } }

        public ProgramForm()
        {
            IsCoverImgExist = false;
            QuestionsIds = new List<QuestionInfoDTO>();
        }
    }
}
