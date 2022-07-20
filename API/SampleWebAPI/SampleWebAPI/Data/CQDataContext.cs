using System;
using System.Collections.Generic;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using SampleWebAPI.Models;


namespace SampleWebAPI.Data
{
    /// <summary>
    ///     CQDataContext
    /// </summary>
    public class CQDataContext
    {
        private static string FilePath = @"SampleData\SampleData.csv";

        public List<CQData> AllCQData { get; set; }

        private Dictionary<string, string> AllFeaturesWithBugCount { get; set; }

        private List<string> AllFeatures { get; set; }

        private CQDataContext()
        {


        }

        private static CQDataContext _instance;

        private static readonly object _lock = new object();

        /// <summary>
        ///     GetInstance
        /// </summary>
        /// <returns></returns>
        public static CQDataContext GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new CQDataContext();
                    }
                }
            }

            return _instance;
        }


        /// <summary>
        ///     Read CSV file from a path 
        /// </summary>
        /// <returns></returns>
        public List<CQData> GetAllCQDataFromCSVFile()
        {
            List<CQData> records;

            using (var streamReader = new StreamReader(FilePath))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    records = csvReader.GetRecords<CQData>().ToList();
                }
            }

            AllCQData = records;
            return records;
        }


        public BugCount CalculateBugCount()
        {
            if (AllCQData == null || AllCQData.Count == 0)
            {
                GetAllCQDataFromCSVFile();
            }

            BugCount bugcount = new BugCount();
            bugcount.TotalBugs = AllCQData.Count.ToString();
            bugcount.TotalOpenBugs = AllCQData.Count(x => (x.State == "Assigned" || x.State == "Accepted")).ToString();
            bugcount.Submitted = AllCQData.Count(x => x.State == "Submitted").ToString();
            bugcount.Accepted = AllCQData.Count(x => x.State == "Accepted").ToString();
            bugcount.Investigated = AllCQData.Count(x => x.State == "Investigated").ToString();
            bugcount.Scored = AllCQData.Count(x => x.State == "Scored").ToString();
            bugcount.Assigned = AllCQData.Count(x => x.State == "Assigned").ToString();
            bugcount.Resolved = AllCQData.Count(x => x.State == "Resolved").ToString();
            bugcount.Duplicated = AllCQData.Count(x => x.CloseReason == "Duplicated").ToString();
            bugcount.Rejected = AllCQData.Count(x => x.CloseReason == "Rejected").ToString();

            return bugcount;
        }

        public Score GetAllScores()
        {
            if (AllCQData == null || AllCQData.Count == 0)
            {
                GetAllCQDataFromCSVFile();
            }
            Score score = new Score();
            score.UnacceptableSafetyDefect = AllCQData.Count(x => (x.Score == "1-Unacceptable Safety Defect")).ToString();
            score.UnacceptableDefect = AllCQData.Count(x => (x.Score == "2-Unacceptable Defect")).ToString();
            score.UndesirableDefect = AllCQData.Count(x => (x.Score == "3-Undesirable Defect")).ToString();
            score.MinorDefect = AllCQData.Count(x => (x.Score == "4-Minor Defect")).ToString();
            score.Total = GetTotalScoreCount(score);

            return score;
        }

        //public OpenBugs GetAllOpenBugs()
        //{
        //    if (AllCQData == null || AllCQData.Count == 0)
        //    {
        //        GetAllCQDataFromCSVFile();
        //    }
        //    AllCQData.Where
        //    OpenBugs openbugs = new OpenBugs;
        //}

        public List<string> GetFeaturesList()
        {
            Dictionary<string, int> uniquefeatures = new Dictionary<string, int>();
            if (AllCQData == null || AllCQData.Count == 0)
            {
                GetAllCQDataFromCSVFile();
            }

            foreach (var item in AllCQData)
            {
                if (!uniquefeatures.ContainsKey(item.Feature))
                {
                    uniquefeatures.Add(item.Feature,1);
                }
            }
            AllFeatures = uniquefeatures.Keys.ToList();
            return AllFeatures;

        }

        /// <summary>
        /// TODO: Logic check needed
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetAllFeaturesOpenBugCount()
        {
            int total = 0;
            Dictionary<string, string> featureWithOpenBugs = new Dictionary<string, string>();
            if (AllCQData == null || AllCQData.Count == 0 )
            {
                GetAllCQDataFromCSVFile();
            }
            if (AllFeatures == null || AllFeatures.Count == 0)
            {
                GetFeaturesList();
            }

            foreach (var feature in AllFeatures)
            {
               
                var openbugsforfeature  = AllCQData.Where(x => x.Feature == feature && (x.State == "Accepted" || x.State == "Assigned")).ToList();
                foreach (var item in openbugsforfeature)
                {
                    if (featureWithOpenBugs.ContainsKey(item.Feature))
                    {
                        string value = string.Empty;
                        featureWithOpenBugs.TryGetValue(item.Feature,out value);
                        int intvalue = 0;
                        Int32.TryParse(value,out intvalue);
                        intvalue++;
                        featureWithOpenBugs[item.Feature] = intvalue.ToString();
                        total++;
                    }
                    else
                    {
                        featureWithOpenBugs.Add(item.Feature,"1");
                        total++;
                    }
                }
                

            }

            featureWithOpenBugs.Add("Total", total.ToString());
            return featureWithOpenBugs;
        }
             
        public Dictionary<string,string> GetAllFeaturesWithCount()
        {
            Dictionary<string, string> featureDict = new Dictionary<string, string>();
            int total = 0;

            if (AllCQData == null || AllCQData.Count == 0)
            {
                GetAllCQDataFromCSVFile();
            }

            foreach (var cq in AllCQData)
            {
                if (featureDict.ContainsKey(cq.Feature))
                {
                    string value = string.Empty;
                    featureDict.TryGetValue(cq.Feature,out value);
                    int intvalue = 0;
                    Int32.TryParse(value,out intvalue);
                    intvalue++;
                    featureDict[cq.Feature] = intvalue.ToString();
                    total++;
                }
                else
                {
                    int value = 1;

                    featureDict.Add(cq.Feature,value.ToString());
                    total++;
                }
            }
            featureDict.Add("Total",total.ToString());
            AllFeaturesWithBugCount = featureDict;
            return featureDict;
        }

        public List<OpenBugs> GetAllOpenBugsList()
        {
            List<CQData> opencqdata = new List<CQData>();
            List<OpenBugs> openBugsList = new List<OpenBugs>();
            if (AllCQData == null || AllCQData.Count == 0)
            {
                GetAllCQDataFromCSVFile();
            }
            opencqdata = AllCQData.Where(x => x.State == "Assigned" || x.State == "Accepted").ToList();
            foreach (var item in opencqdata)
            {
                OpenBugs openbug = new OpenBugs();
                openbug.Id = item.Id;
                openbug.Headline = item.HeadLine;
                openbug.Assignedto = item.OwnerFullName;
                openbug.State = item.State;
                openbug.Age = item.Age.ToString();
                openbug.ETA = string.Empty;
                openbug.Comments = string.Empty;
                openbug.Status = string.Empty;
                openbug.Feature = item.Feature;


                openBugsList.Add(openbug);
            }
            return openBugsList;
        }

        private string GetTotalScoreCount(Score score)
        {
            var total = Int32.Parse(score.UnacceptableSafetyDefect) + Int32.Parse(score.UndesirableDefect) + Int32.Parse(score.UnacceptableDefect)
                                + Int32.Parse(score.MinorDefect);
            return total.ToString();
        }

    }
}
