namespace backend.Core.Dtos.SurveysAnswers
{
    public class SurveysAnswersRetrieveDto
    {
        public long Id { get; set; }
        public long SurveysId { get; set; }

        public string Answer { get; set; }
    }
}
