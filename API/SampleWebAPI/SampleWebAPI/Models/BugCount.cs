using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPI.Models
{
    public class BugCount
    {
        public string TotalBugs { get; set; }
        public string TotalOpenBugs { get; set; }

        public string Submitted { get; set; }

        public string Accepted { get; set; }

        public string Investigated { get; set; }

        public string Scored { get; set; }

        public string Assigned { get; set; }

        public string Resolved { get; set; }
        public string Duplicated { get; set; }
        public string Rejected { get; set; }
    }
}
