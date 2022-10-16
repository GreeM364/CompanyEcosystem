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
        QuestionnaireDto GetQuestionnaire(int? id);
        IEnumerable<QuestionnaireDto> GetQuestionnaires();
        void CreateQuestionnaire(QuestionnaireDto questionnaireDto);
        void UpdateQuestionnaire(QuestionnaireDto questionnaireDto);
        void DeleteQuestionnaire(int? id);
    }
}
