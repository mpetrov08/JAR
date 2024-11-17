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

        Task<List<ConferenceViewModel>> AllByUserId(string userId);

        Task<List<ConferenceViewModel>> AllByLecturerId(string userId);

        Task CreateConferenceAsync(ConferenceFormModel model);

        Task EditConferenceAsync(ConferenceFormModel model, int id);

        Task DeleteConferenceAsync(int id);

        Task<ConferenceFormModel> GetConferenceFormModelByIdAsync(int id);

        Task<ConferenceViewModel> GetConferenceViewModelByIdAsync(int id);

        Task<ConferenceDetailsViewModel> GetConferenceDetailsViewModelByIdAsync(int id);

        Task<bool> ExistsAsync(int id);

        Task SignUp(int conferenceId, string userId);

        Task Unregister(int conferenceId, string userId);

        Task<bool> HasUserSignedUp(int conferenceId, string userId);

        Task<bool> IsConferenceOver(int conferenceId, DateTime currentTime);
    }
}
