﻿using JAR.Core.Models.Lecturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAR.Core.Models.Conference
{
    public class ConferenceDetailsViewModel
    {
        public int Id { get; set; }

        public string Topic { get; set; } = null!;

        public string Start { get; set; } = null!;

        public string End { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ConferenceUrl { get; set; } = null!;

        public LecturerDetailsViewModel Lecturer { get; set; } = null!; 
    }
}
