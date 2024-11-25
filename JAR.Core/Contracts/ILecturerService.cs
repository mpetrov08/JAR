using JAR.Core.Models.Lecturer;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Contracts
{
    public interface ILecturerService
    {
        Task<bool> Exists(int id);

        Task<bool> IsLecturer(string userId);

        Task<bool> PromoteToLecturer(LecturerFormModel model);

        Task<bool> DemoteFromLecturerAsync(int id);

        Task<bool> HasLecturerConference(string userId, int conferenceId);

        Task<int> GetLecturerId(string userId);

        Task<LecturerOptionViewModel> GetLecturerOptionViewModel(int id);

        Task<LecturerFormModel> GetLecturerFormModel(int id);

        Task<IEnumerable<LecturerOptionViewModel>> AllOptionsAsync();

        Task<IEnumerable<LecturerDetailsViewModel>> AllAsync();

        Task Edit(LecturerFormModel model, int id);
    }
}
