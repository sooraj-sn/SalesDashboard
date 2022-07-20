using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPI.Models
{
    public class Week
    {
        public string WeekId { get; set; }

        public string Investigated { get; set; }

        public string Resolved { get; set; }
    }
}
