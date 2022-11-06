using System.Collections.Generic;
using AutoMapper;
using CompanyEcosystem.BL.DataTransferObjects;
using CompanyEcosystem.BL.Infrastructure;
using CompanyEcosystem.BL.Interfaces;
using CompanyEcosystem.PL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEcosystem.PL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionnaireController : ControllerBase
    {
        private readonly IQuestionnaireService _questionnaireService;
        private readonly IMapper _mapper;

        public QuestionnaireController(IQuestionnaireService questionnaireService, IMapper mapper)
        {
            _questionnaireService = questionnaireService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var source = await _questionnaireService.GetQuestionnairesAsync();

                var questionnaires = _mapper.Map<IEnumerable<QuestionnaireDto>, List<QuestionnaireViewModel>>(source);

                return Ok(questionnaires);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            try
            {
                var source = await _questionnaireService.GetQuestionnaireAsync(id);

                var questionnaireViewModel = _mapper.Map<QuestionnaireDto, QuestionnaireViewModel>(source);

                return Ok(questionnaireViewModel);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(QuestionnaireCreateUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            try
            {
                var questionnaireDto = _mapper.Map<QuestionnaireCreateUpdateViewModel, QuestionnaireDto>(model);

                await _questionnaireService.CreateQuestionnaireAsync(questionnaireDto);

                return Ok();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(QuestionnaireCreateUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            try
            {
                var questionnaireDto = _mapper.Map<QuestionnaireCreateUpdateViewModel, QuestionnaireDto>(model);

                await _questionnaireService.UpdateQuestionnaireAsync(questionnaireDto);

                return Ok();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                await _questionnaireService.DeleteQuestionnaireAsync(id);

                return Ok();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
