namespace backend.Core.Entities

{
    public class SurveysAnswers : BaseEntity
    {
        public string Answer { get; set; }

        public long SurveysId { get; set; }

        public Surveys Surveys { get; set; }
    }
}
