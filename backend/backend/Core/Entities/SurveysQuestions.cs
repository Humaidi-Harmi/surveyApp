namespace backend.Core.Entities

{
    public class SurveysQuestions : BaseEntity
    {
        public string Question {  get; set; }

        public ICollection<Surveys> Surveys { get; set; }


    }
}

