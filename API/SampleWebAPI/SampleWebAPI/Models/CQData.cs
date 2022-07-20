using System;
using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace SampleWebAPI
{
    public class CQData
    {
        [Name("id")]
        public string Id { get; set; }

        [Name("Headline")]
        public string HeadLine { get; set; }

        [Name("OwnerFullName")]
        public string OwnerFullName { get; set; }

        [Name("State")]
        public string State { get; set; }

        [Name("Submitter.fullname")]
        public string SubmitterFullName { get; set; }

        [Name("FunctionalArea")]
        public string FunctionalArea { get; set; }

        [Name("SubmittedOn")]
        public string SubmittedOn { get; set; }

        [Name("ResolverFullName")]
        public string ResolverFullName { get; set; }

        [Name("ResolvedOn")]
        public string ResolvedOn { get; set; }

        [Name("InvestigatorFullName")]
        public string InvestigatorFullName { get; set; }

        [Name("InvestigatedOn")]
        public string InvestigatedOn { get; set; }

        [Name("CloseReason")]
        public string CloseReason { get; set; }

        [Name("Score")]
        public string Score { get; set; }

        [Name("Age")]
        public int? Age { get; set; }

        [Name("Submitted Week")]
        public string SubmittedWeek { get; set; }

        [Name("Resolved Week")]
        public string ResolvedWeek { get; set; }

        [Name("Investigated Week")]
        public string InvestigatedWeek { get; set; }

        [Name("Feature")]
        public string Feature { get; set; }
    }
}
