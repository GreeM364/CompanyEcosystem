using AutoMapper;
using CompanyEcosystem.BL.DataTransferObjects;
using CompanyEcosystem.BL.Infrastructure;
using CompanyEcosystem.BL.Interfaces;
using CompanyEcosystem.DAL.Entities;
using CompanyEcosystem.DAL.Interfaces;

namespace CompanyEcosystem.BL.Services
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly IRepository<Questionnaire> _repository;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public QuestionnaireService(IRepository<Questionnaire> repository, IAccountService service, IMapper mapper)
        {
            _repository = repository;
            _accountService = service;
            _mapper = mapper;
        }

        public IEnumerable<QuestionnaireDto> GetQuestionnaires()
        {
            var employee = _accountService.GetAll();

            var questionnaires = _repository.GetAll().Select(q => new QuestionnaireDto()
            {
                Id = q.Id,
                FirstName = q.FirstName,
                MiddleName = q.MiddleName,
                LastName = q.LastName,
                Phone = q.Phone,
                Email = employee.FirstOrDefault(e => e.Id == q.EmployeeId).Email,
                Birthday = q.Birthday,
                AboutMyself = q.AboutMyself,
                LinkToLinkedIn = q.LinkToLinkedIn,
                Position = employee.FirstOrDefault(e => e.Id == q.EmployeeId).Position
            });

            if (questionnaires.Count() == 0)
                throw new ValidationException("Questionnaires not found", "");

            return questionnaires;
        }

        public QuestionnaireDto GetQuestionnaire(int? id)
        {
            if (id == null)
                throw new ValidationException("Questionnaire ID not set", "");

            var questionnaire = _repository.Get(id.Value);

            if (questionnaire == null)
                throw new ValidationException("Questionnaire not found", "");

            var questionnaireDto = new QuestionnaireDto
            {
                Id = questionnaire.Id,
                FirstName = questionnaire.FirstName,
                MiddleName = questionnaire.MiddleName,
                LastName = questionnaire.LastName,
                Phone = questionnaire.Phone,
                Email = _accountService.GetById(questionnaire.EmployeeId).Email,
                Birthday = questionnaire.Birthday,
                AboutMyself = questionnaire.AboutMyself,
                LinkToLinkedIn = questionnaire.LinkToLinkedIn,
                Position = _accountService.GetById(questionnaire.EmployeeId).Position
            };

            return questionnaireDto;
        }

        public void CreateQuestionnaire(QuestionnaireDto questionnaireDto)
        {
            var employee = _accountService.GetById(questionnaireDto.EmployeeId);
            if (employee == null)
                throw new ValidationException("Employee not found", "");

            var questionnaire = _mapper.Map<QuestionnaireDto, Questionnaire>(questionnaireDto);

            _repository.Create(questionnaire);
        }

        public void UpdateQuestionnaire(QuestionnaireDto questionnaireDto)
        {
            var employee = _accountService.GetById(questionnaireDto.EmployeeId);
            if (employee == null)
                throw new ValidationException("Employee not found", "");

            var questionnaire = _mapper.Map<QuestionnaireDto, Questionnaire>(questionnaireDto);

            _repository.Update(questionnaire);
        }

        public void DeleteQuestionnaire(int? id)
        {
            if (id == null)
                throw new ValidationException("Questionnaire ID not set", "");

            _repository.Delete(id.Value);
        }
    }
}
