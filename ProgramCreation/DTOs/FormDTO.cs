using ProgramCreation.Models;

namespace ProgramCreation.DTOs
{
    public class FormDTO
    {
        public string Id { get; set; }
        public bool IsCoverImgExist { get; set; }
        public List<QuestionDTO> PersonalInformationQuestions { get; set; }
        public List<QuestionDTO> ProfileQuestions { get; set; }
        public List<QuestionDTO> AdditionalQuestions { get; set; }

        public FormDTO(ProgramForm simpleForm,List<QuestionDTO>personalInfo, List<QuestionDTO> profile, List<QuestionDTO> additional)
        {
            this.Id = simpleForm.id;
            this.IsCoverImgExist = simpleForm.IsCoverImgExist;
            this.PersonalInformationQuestions = personalInfo;
            this.ProfileQuestions= profile;
            this.AdditionalQuestions = additional;
        }
    }
}
