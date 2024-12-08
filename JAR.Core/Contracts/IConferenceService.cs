using JAR.Core.Models.Conference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Contracts
{
    public interface IConferenceService
    {
        Task<IEnumerable<ConferenceViewModel>> AllAsync();

        Task<IEnumerable<ConferenceViewModel>> AllByUserIdAsync(string userId);

        Task<IEnumerable<ConferenceViewModel>> AllByLecturerIdAsync(string userId);

        Task CreateConferenceAsync(ConferenceFormModel model);

        Task EditConferenceAsync(ConferenceFormModel model, int id);

        Task DeleteConferenceAsync(int id);

        Task<ConferenceFormModel> GetConferenceFormModelByIdAsync(int id);

        Task<ConferenceViewModel> GetConferenceViewModelByIdAsync(int id);

        Task<ConferenceDetailsViewModel> GetConferenceDetailsViewModelByIdAsync(int id);

        Task<bool> ExistsAsync(int id);

        Task SignUpAsync(int conferenceId, string userId);

        Task UnregisterAsync(int conferenceId, string userId);

        Task<bool> HasUserSignedUpAsync(int conferenceId, string userId);

        Task<bool> IsConferenceOverAsync(int conferenceId, DateTime currentTime);
    }
}
