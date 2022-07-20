using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPI.Models
{
    public class OpenBugs
    {
        public string Id { get; set; }

        public string Headline { get; set; }

        public string Assignedto { get; set; }

        public string State { get; set; }

        public string Age { get; set; }

        public string ETA { get; set; }

        public string Comments { get; set; }

        public string Status { get; set; }

        public string Feature { get; set; }
    }
}
