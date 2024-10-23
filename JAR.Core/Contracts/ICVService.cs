using JAR.Core.Models.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Contracts
{
    public interface ICVService
    {
        Task CreateCV(CVFormModel model, string userId);

        Task CreateDegree(DegreeFormModel model, int cvId);

        Task CreateProfessionalExperience(ProfessionalExperienceFormModel model, int cvId);
    }
}
