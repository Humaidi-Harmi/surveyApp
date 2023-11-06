using AutoMapper;
using backend.Core.Dtos.Surveys;
using backend.Core.Dtos.SurveysAnswers;
using backend.Core.Dtos.SurveysQuestions;
using backend.Core.Entities;

namespace backend.Core.AutoMapperConfig
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<SurveysQuestionsDto, SurveysQuestions>();

            CreateMap<SurveysQuestions, SurveyQuestionsRetrieveDto>();

            CreateMap<SurveysDto, Surveys>();

            CreateMap<Surveys, SurveysRetrieveDto>()
                .ForMember(dest => dest.SurveyQuestion, opt => opt.MapFrom(src => src.SurveysQuestions.Question));

            CreateMap<SurveysAnswersDto, SurveysAnswers>();

            CreateMap<SurveysAnswers, SurveysAnswersRetrieveDto>();
        }
    }
}
