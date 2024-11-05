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

        Task EditCV(CVFormModel model, int cvId);

        Degree CreateDegree(DegreeFormModel model, int cvId);

        ProfessionalExperience CreateProfessionalExperience(ProfessionalExperienceFormModel model, int cvId);

        Task<CVViewModel> GetCVViewModelByUserId(string userId);

        Task<CVFormModel> GetCVFormModelByUserId(string userId);

        Task<bool> Exists(int cvId);

        Task<bool> UserHasCV(int cvId, string userId);
    }
}
