using ProgramCreation.Models;

namespace ProgramCreation.DTOs
{
    //Contains the detailed data about the form, not only the question ids, but the questions and their details
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
