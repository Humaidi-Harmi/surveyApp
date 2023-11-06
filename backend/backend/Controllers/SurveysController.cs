using AutoMapper;
using backend.Core.Context;
using backend.Core.Dtos.Surveys;
using backend.Core.Dtos.SurveysQuestions;
using backend.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private ApplicationDbContext _context { get; }
        private IMapper _mapper { get; }
        public SurveysController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Create survey 
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateSurveys([FromBody] SurveysDto surveysDto)
        {
            Surveys newSurvey = _mapper.Map<Surveys>(surveysDto);
            await _context.Surveys.AddAsync(newSurvey);
            await _context.SaveChangesAsync();

            return Ok("Surveys created successfully");
        }

        //Retrieve survey 
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<IEnumerable<SurveysRetrieveDto>>> GetSurveys()
        {
            var surveys = await _context.Surveys.Include(survey => survey.SurveysQuestions).ToListAsync();
            var convertedSurveys = _mapper.Map<IEnumerable<SurveysRetrieveDto>>(surveys);

            return Ok(convertedSurveys);
        }
    }
}
