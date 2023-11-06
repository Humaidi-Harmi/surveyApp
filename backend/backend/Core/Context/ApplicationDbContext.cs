using Microsoft.EntityFrameworkCore;
using backend.Core.Entities;

namespace backend.Core.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<SurveysQuestions> SurveyQuestions { get; set; }
        public DbSet<Surveys> Surveys { get; set; }
        public DbSet<SurveysAnswers> SurveysAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Surveys>()
                .HasOne(surveys => surveys.SurveysQuestions)
                .WithMany(surveysQuestions => surveysQuestions.Surveys)
                .HasForeignKey(surveys => surveys.SurveyQuestionsId);

            modelBuilder.Entity<SurveysAnswers>()
                .HasOne(surveysAnswers => surveysAnswers.Surveys)
                .WithMany(surveys => surveys.SurveysAnswers)
                .HasForeignKey(surveyAnswers => surveyAnswers.SurveysId);


        }
    }
}
