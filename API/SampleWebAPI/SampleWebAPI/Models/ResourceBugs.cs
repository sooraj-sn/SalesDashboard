using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPI.Models
{
    /// <summary>
    ///     Class Template for ResourceWise Bugs List
    /// </summary>
    public class ResourceBugs
    {
        public string Resource { get; set; }

        public string CodeId { get; set; }

        public string  Resolved { get; set; }

        public string Investigated { get; set; }

        public List<Week> AssociatedWeeks { get; set; }
    }
}
