using AutoMapper;
using CompanyEcosystem.BL.Data_Transfer_Object;
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
        public IActionResult Get()
        {
            try
            {
                IEnumerable<QuestionnaireDTO> questionnaireDtos = _questionnaireService.GetQuestionnaires();

                var questionnaires = _mapper.Map<IEnumerable<QuestionnaireDTO>, List<QuestionnaireViewModel>>(questionnaireDtos);

                return Ok(questionnaires);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            try
            {
                QuestionnaireDTO questionnaireDto = _questionnaireService.GetQuestionnaire(id);

                var questionnaireViewModel = _mapper.Map<QuestionnaireDTO, QuestionnaireViewModel>(questionnaireDto);

                return Ok(questionnaireViewModel);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(QuestionnaireViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            try
            {
                var questionnaireDto = _mapper.Map<QuestionnaireViewModel, QuestionnaireDTO>(model);

                _questionnaireService.CreateQuestionnaire(questionnaireDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(QuestionnaireViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            try
            {
                var questionnaireDto = _mapper.Map<QuestionnaireViewModel, QuestionnaireDTO>(model);

                _questionnaireService.UpdateQuestionnaire(questionnaireDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            try
            {
                _questionnaireService.DeleteQuestionnaire(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
