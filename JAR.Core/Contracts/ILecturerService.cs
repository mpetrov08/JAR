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
        Task<bool> ExistsAsync(int id);

        Task<bool> IsLecturerAsync(string userId);

        Task<bool> PromoteToLecturerAsync(LecturerFormModel model);

        Task<bool> DemoteFromLecturerAsync(int id);

        Task<bool> HasLecturerConferenceAsync(string userId, int conferenceId);

        Task<int> GetLecturerIdAsync(string userId);

        Task<LecturerOptionViewModel> GetLecturerOptionViewModelAsync(int id);

        Task<LecturerFormModel> GetLecturerFormModelAsync(int id);

        Task<IEnumerable<LecturerOptionViewModel>> AllOptionsAsync();

        Task<IEnumerable<LecturerDetailsViewModel>> AllAsync();

        Task EditAsync(LecturerFormModel model, int id);
    }
}
