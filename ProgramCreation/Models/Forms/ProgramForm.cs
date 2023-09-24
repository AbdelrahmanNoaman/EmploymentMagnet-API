using ProgramCreation.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramCreation.Models
{
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
