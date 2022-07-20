using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SampleWebAPI.Data;

namespace SampleWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CQDataController : ControllerBase
    {
        private readonly ILogger<CQDataController> _logger;

        private CQDataContext _cqDataContext = null;

        public CQDataController(ILogger<CQDataController> logger)
        {
            _logger = logger;
            _cqDataContext = CQDataContext.GetInstance();
        }


        #region This api may not be needed
        //[HttpGet]
        //[Route("GetCQData")]
        //public IActionResult GetCQData()
        //{

        //   var cqrecords = _cqDataContext.GetAllCQDataFromCSVFile();
        //   return Ok(cqrecords);
        //}
        #endregion

        [HttpGet]
        [Route("GetBugCount")]
        public IActionResult GetBugCount()
        {
            var bugcount = _cqDataContext.CalculateBugCount();
            return Ok(bugcount);
        }

        [HttpGet]
        [Route("GetScore")]
        public IActionResult GetScore()
        {
            var score = _cqDataContext.GetAllScores();
            return Ok(score);
        }


        [HttpGet]
        [Route("GetFeaturesTotalBugs")]
        public IActionResult GetFeatureWiseTotalBugs()
        {
            var featurewithTotalbugs = _cqDataContext.GetAllFeaturesWithCount();
            return Ok(featurewithTotalbugs);
        }

        [HttpGet]
        [Route("GetFeaturesOpenBugs")]
        public IActionResult GetFeatureWiseOpenBugs()
        {
            var featurewithOpenbugs = _cqDataContext.GetAllFeaturesOpenBugCount();
            return Ok(featurewithOpenbugs);
        }

        [HttpGet]
        [Route("GetOpenBugs")]
        public IActionResult GetOpenBugs()
        {
            var allOpenBugs = _cqDataContext.GetAllOpenBugsList();
            return Ok(allOpenBugs);
        }

    }
}
