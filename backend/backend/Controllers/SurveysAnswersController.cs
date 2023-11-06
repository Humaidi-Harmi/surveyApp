using AutoMapper;
using backend.Core.Context;
using backend.Core.Dtos.SurveysAnswers;
using backend.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysAnswersController : ControllerBase
    {
        private ApplicationDbContext _context { get; }
        private IMapper _mapper { get; }

        public SurveysAnswersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Create answer 
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateSurveysAnswers([FromBody] SurveysAnswersDto surveysAnswersDto)
        {
            SurveysAnswers newSurveyAnswer = _mapper.Map<SurveysAnswers>(surveysAnswersDto);
            await _context.SurveysAnswers.AddAsync(newSurveyAnswer);
            await _context.SaveChangesAsync();

            return Ok("Surveys answer created successfully");
        }

        //Retrieve survey answer
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<IEnumerable<SurveysAnswersRetrieveDto>>> GetSurveyAnswers()
        {
            var answer = await _context.SurveysAnswers.ToListAsync();
            var convertedAnswers = _mapper.Map<IEnumerable<SurveysAnswersRetrieveDto>>(answer);

            return Ok(convertedAnswers);
        }
    }
}
