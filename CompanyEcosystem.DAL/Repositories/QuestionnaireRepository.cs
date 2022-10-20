using CompanyEcosystem.DAL.EF;
using CompanyEcosystem.DAL.Entities;
using CompanyEcosystem.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanyEcosystem.DAL.Repositories
{
    public class QuestionnaireRepository : IRepository<Questionnaire>
    {
        private readonly CompanyEcosystemContext _db;
        public QuestionnaireRepository(CompanyEcosystemContext context)
        {
            _db = context;
        }
        public IEnumerable<Questionnaire> GetAll()
        {
            return _db.Questionnaires;
        }

        public Questionnaire Get(int? id)
        {
            return _db.Questionnaires.Find(id);
        }

        public void Create(Questionnaire item)
        {
            _db.Questionnaires.Add(item);
            _db.SaveChanges();
        }

        public void Update(Questionnaire item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var questionnaire = _db.Questionnaires.Find(id);
            _db.Questionnaires.Remove(questionnaire);

            _db.SaveChanges();
        }
    }
}
