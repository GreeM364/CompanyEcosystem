using AutoMapper;
using CompanyEcosystem.BL.Data_Transfer_Object;
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

        public IEnumerable<QuestionnaireDTO> GetQuestionnaires()
        {
            var questionnaires = _repository.GetAll();
            if (questionnaires.Count() == 0)
                throw new ValidationException("Questionnaires not found", "");

            return _mapper.Map<IEnumerable<Questionnaire>, List<QuestionnaireDTO>>(_repository.GetAll());
        }

        public QuestionnaireDTO GetQuestionnaire(int? id)
        {
            if (id == null)
                throw new ValidationException("Questionnaire ID not set", "");
            var questionnaire = _repository.Get(id.Value);
            if (questionnaire == null)
                throw new ValidationException("Questionnaire not found", "");

            return _mapper.Map<Questionnaire, QuestionnaireDTO>(questionnaire);
        }

        public void CreateQuestionnaire(QuestionnaireDTO questionnaireDto)
        {
            var questionnaire = _mapper.Map<QuestionnaireDTO, Questionnaire>(questionnaireDto);

            _repository.Create(questionnaire);
        }

        public void UpdateQuestionnaire(QuestionnaireDTO questionnaireDto)
        {
            var questionnaire = _mapper.Map<QuestionnaireDTO, Questionnaire>(questionnaireDto);

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
