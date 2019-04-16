using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApi.DAL;
using SampleApi.Models;

namespace SampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatsDAO dao;
        /// <summary>
        /// Creates a comic collections controller.
        /// </summary>
        /// <param name="dao">the statistics dao</param>
        public StatisticsController(IStatsDAO dao)
        {
            this.dao = dao;
        }

        [HttpGet("totalcomics")]
        public int TotalComics()
        {
            return dao.TotalComics();
        }

        [HttpGet("totalcollections")]
        public int TotalCollections()
        {
            return dao.TotalCollections();
        }

        [HttpGet("largestcollections")]
        public IList<ComicCollection> LargestCollections()
        {
            return dao.LargestCollection();
        }
    }
}