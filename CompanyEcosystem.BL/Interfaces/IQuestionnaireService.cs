using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyEcosystem.BL.DataTransferObjects;
using Microsoft.AspNetCore.Http;

namespace CompanyEcosystem.BL.Interfaces
{
    public interface IQuestionnaireService
    {
        Task<QuestionnaireDto> GetQuestionnaireAsync(int? id);
        Task<IEnumerable<QuestionnaireDto>> GetQuestionnairesAsync();
        Task CreateQuestionnaireAsync(QuestionnaireDto questionnaireDto, IFormFile formFile, string directoryPath);
        Task UpdateQuestionnaireAsync(QuestionnaireDto questionnaireDto, IFormFile formFile, string directoryPath);
        Task DeleteQuestionnaireAsync(int? id);
    }
}
