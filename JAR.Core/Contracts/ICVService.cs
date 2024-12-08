using JAR.Core.Models.CV;
using JAR.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Contracts
{
    public interface ICVService
    {
        Task CreateCVAsync(CVFormModel model, string userId);

        Task EditCVAsync(CVFormModel model, int cvId);

        Task DeleteCVAsync(int cvId);

        Degree CreateDegree(DegreeFormModel model, int cvId);

        Task DeleteDegree(int degreeId);

        ProfessionalExperience CreateProfessionalExperience(ProfessionalExperienceFormModel model, int cvId);

        Task DeleteProfessionalExperienceAsync(int professionalExperience);

        Task<CVViewModel> GetCVViewModelByUserIdAsync(string userId);

        Task<CVFormModel> GetCVFormModelByUserIdAsync(string userId);

        Task<bool> ExistsAsync(int cvId);

        Task<bool> UserHasCVWithIdAsync(int cvId, string userId);

        Task<bool> UserHasCVAsync(string userId);
    }
}
