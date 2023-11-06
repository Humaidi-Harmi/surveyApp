namespace backend.Core.Entities

{
	public class Surveys : BaseEntity
    {
		public DateTime SubmitTime { get; set; } = DateTime.Now;

        public long SurveyQuestionsId { get; set; }
       
        public SurveysQuestions SurveysQuestions { get; set; }

        public ICollection<SurveysAnswers> SurveysAnswers { get; set; }
    }
}