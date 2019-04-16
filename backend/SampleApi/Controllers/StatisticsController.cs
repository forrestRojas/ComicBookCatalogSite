using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApi.DAL;

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

        [HttpGet("total")]
        public int TotalComics()
        {
            return dao.TotalComics();
        }
    }
}