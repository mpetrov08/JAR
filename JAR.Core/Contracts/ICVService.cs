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

        Degree CreateDegree(DegreeFormModel model, int cvId);

        ProfessionalExperience CreateProfessionalExperience(ProfessionalExperienceFormModel model, int cvId);

        Task<CVViewModel> GetCVByUserId(string userId);
    }
}
