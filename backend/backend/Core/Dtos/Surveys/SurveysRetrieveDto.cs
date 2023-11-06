namespace backend.Core.Dtos.Surveys
{
    public class SurveysRetrieveDto
    {
        public long Id { get; set; }

        public DateTime SubmitTime { get; set; }

        public long SurveyQuestionsId { get; set; }

        public string SurveyQuestion { get; set; }
    }
}
