using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPI.Models
{
    public class RecentBugs
    {
        public List<string> NewlyAssignedBugs { get; set; }

        public List<string>  RecentlyResolvedBugs { get; set; }

        public List<string> RecentlyRejectedBugs { get; set; }

        public List<string> RecentlyReassignedBugs { get; set; }
    }
}
