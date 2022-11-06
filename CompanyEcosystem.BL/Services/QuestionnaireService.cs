using AutoMapper;
using CompanyEcosystem.BL.DataTransferObjects;
using CompanyEcosystem.BL.Infrastructure;
using CompanyEcosystem.BL.Interfaces;
using CompanyEcosystem.DAL.Entities;
using CompanyEcosystem.DAL.Interfaces;
using System.Linq.Expressions;

namespace CompanyEcosystem.BL.Services
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly IRepository<Questionnaire> _dbQuestionnaire;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public QuestionnaireService(IRepository<Questionnaire> dbQuestionnaire, IAccountService service, IMapper mapper)
        {
            _dbQuestionnaire = dbQuestionnaire;
            _accountService = service;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuestionnaireDto>> GetQuestionnairesAsync()
        {
            var source = await _dbQuestionnaire.GetAsync(includes: new List<Expression<Func<Questionnaire, object>>>()
            {
                x => x.Employee
            });

            if (source == null || !source.Any())
                throw new ValidationException("Questionnaires not found", "");

            var questionnaires = _mapper.Map<List<Questionnaire>, List<QuestionnaireDto>>(source);

            return questionnaires;
        }

        public async Task<QuestionnaireDto> GetQuestionnaireAsync(int? id)
        {
            if (id == null)
                throw new ValidationException("Questionnaire ID not set", "");

            var sourceQuestionnaire = await _dbQuestionnaire.GetByIdAsync(id.Value);
            var sourceEmployee = await _accountService.GetByIdAsync(sourceQuestionnaire.EmployeeId);

            if (sourceQuestionnaire == null)
                throw new ValidationException("Questionnaire not found", "");

            var questionnaireDto = _mapper.Map<Questionnaire, QuestionnaireDto>(sourceQuestionnaire);
            questionnaireDto.Email = sourceEmployee.Email;
            questionnaireDto.Position = sourceEmployee.Position;

            return questionnaireDto;
        }

        public Task CreateQuestionnaireAsync(QuestionnaireDto questionnaireDto)
        {
            var employee = _accountService.GetByIdAsync(questionnaireDto.EmployeeId);
            if (employee == null)
                throw new ValidationException("Employee not found", "");

            var questionnaire = _mapper.Map<QuestionnaireDto, Questionnaire>(questionnaireDto);

            return _dbQuestionnaire.CreateAsync(questionnaire);
        }

        public Task UpdateQuestionnaireAsync(QuestionnaireDto questionnaireDto)
        {
            var employee = _accountService.GetByIdAsync(questionnaireDto.EmployeeId);
            if (employee == null)
                throw new ValidationException("Employee not found", "");

            var questionnaire = _mapper.Map<QuestionnaireDto, Questionnaire>(questionnaireDto);

            return _dbQuestionnaire.UpdateAsync(questionnaire);
        }

        public Task DeleteQuestionnaireAsync(int? id)
        {
            if (id == null)
                throw new ValidationException("Questionnaire ID not set", "");

            return _dbQuestionnaire.DeleteAsync(id.Value);
        }
    }
}
