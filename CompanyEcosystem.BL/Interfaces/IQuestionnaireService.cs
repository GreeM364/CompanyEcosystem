using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyEcosystem.BL.DataTransferObjects;

namespace CompanyEcosystem.BL.Interfaces
{
    public interface IQuestionnaireService
    {
        Task<QuestionnaireDto> GetQuestionnaireAsync(int? id);
        Task<IEnumerable<QuestionnaireDto>> GetQuestionnairesAsync();
        Task CreateQuestionnaireAsync(QuestionnaireDto questionnaireDto);
        Task UpdateQuestionnaireAsync(QuestionnaireDto questionnaireDto);
        Task DeleteQuestionnaireAsync(int? id);
    }
}
