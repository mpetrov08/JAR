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
    }
}
