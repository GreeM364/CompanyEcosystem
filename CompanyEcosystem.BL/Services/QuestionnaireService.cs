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
        private readonly IMapper _mapper;

        public QuestionnaireService(IRepository<Questionnaire> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<QuestionnaireDto> GetQuestionnaires()
        {
            var questionnaires = _repository.GetAll();
            if (questionnaires.Count() == 0)
                throw new ValidationException("Questionnaires not found", "");

            return _mapper.Map<IEnumerable<Questionnaire>, List<QuestionnaireDto>>(_repository.GetAll());
        }

        public QuestionnaireDto GetQuestionnaire(int? id)
        {
            if (id == null)
                throw new ValidationException("Questionnaire ID not set", "");
            var questionnaire = _repository.Get(id.Value);
            if (questionnaire == null)
                throw new ValidationException("Questionnaire not found", "");

            return _mapper.Map<Questionnaire, QuestionnaireDto>(questionnaire);
        }

        public void CreateQuestionnaire(QuestionnaireDto questionnaireDto)
        {
            var questionnaire = _mapper.Map<QuestionnaireDto, Questionnaire>(questionnaireDto);

            _repository.Create(questionnaire);
        }

        public void UpdateQuestionnaire(QuestionnaireDto questionnaireDto)
        {
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
