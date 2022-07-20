using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPI.Models
{
    public class Score
    {

        public string UnacceptableSafetyDefect { get; set; }

        public string UnacceptableDefect { get; set; }

        public string UndesirableDefect { get; set; }

        public string MinorDefect { get; set; }

        public string Total { get; set; }

    }
}
