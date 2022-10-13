using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyEcosystem.BL.Data_Transfer_Object;

namespace CompanyEcosystem.BL.Interfaces
{
    public interface IQuestionnaireService
    {
        QuestionnaireDTO GetQuestionnaire(int? id);
        IEnumerable<QuestionnaireDTO> GetQuestionnaires();
        void CreateQuestionnaire(QuestionnaireDTO questionnaireDto);
        void UpdateQuestionnaire(QuestionnaireDTO questionnaireDto);
        void DeleteQuestionnaire(int? id);
    }
}
