using AutoMapper;
using backend.Core.Context;
using backend.Core.Dtos.SurveysQuestions;
using backend.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensibility;
using System.Collections.Generic;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysQuestionsController : ControllerBase
    {
        private ApplicationDbContext _context { get; }
        private IMapper _mapper { get; }
        public SurveysQuestionsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Create survey questions
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateSurveyQuestions([FromBody] SurveysQuestionsDto surveysQuestionsDto)
        {
            var newSurveyQuestions = _mapper.Map<SurveysQuestions>(surveysQuestionsDto);
            await _context.SurveyQuestions.AddAsync(newSurveyQuestions);
            await _context.SaveChangesAsync();

            return Ok("Survey questions created successfully");
        }

        //Retrieve survey questions
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<IEnumerable<SurveyQuestionsRetrieveDto>>> GetSurveyQuestions()
        {
            var questions = await _context.SurveyQuestions.ToListAsync();
            var convertedQuestions = _mapper.Map<IEnumerable<SurveyQuestionsRetrieveDto>> (questions);

            return Ok(convertedQuestions);
        }

    }
}
