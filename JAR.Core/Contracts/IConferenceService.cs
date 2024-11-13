﻿using JAR.Core.Models.Conference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Contracts
{
    public interface IConferenceService
    {
        Task CreateConferenceAsync(ConferenceFormModel model);
    }
}
