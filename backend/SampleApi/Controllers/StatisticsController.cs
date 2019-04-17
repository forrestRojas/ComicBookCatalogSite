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
        private readonly IStatsDAO statsDao;
        private readonly IComicCollectionDAO collectionDao;
        private readonly IComicBookDAO comicDao;

        /// <summary>
        /// Creates a comic collections controller.
        /// </summary>
        /// <param name="dao">the statistics dao</param>
        /// <param name="collectionDao">the collection dao</param>
        /// <param name="comicDao">the comic dao</param>
        public StatisticsController(IStatsDAO statsDao, IComicCollectionDAO collectionDao, IComicBookDAO comicDao)
        {
            this.statsDao = statsDao;
            this.collectionDao = collectionDao;
            this.comicDao = comicDao;
        }

        [HttpGet("totalcomics")]
        public int TotalComics()
        {
            return statsDao.TotalComics();
        }

        [HttpGet("totalcollections")]
        public int TotalCollections()
        {
            return statsDao.TotalCollections();
        }

        [HttpGet("largestcollections")]
        public IList<ComicCollection> LargestCollections()
        {
            IList<Search> sorted = statsDao.LargestCollection();
            IList<ComicCollection> largestCollections = new List<ComicCollection>();
            foreach(Search result in sorted)
            {
                largestCollections.Add(collectionDao.GetASingleCollection(result.Id));
            }
            return largestCollections;
        }

        [HttpGet("mostpopular")]
        public IList<Search> MostPopularComic()
        {
            return statsDao.MostPopularComic();
        }

        [HttpGet("bestuser")]
        public IList<Search> UsersWithMostComics()
        {
            return statsDao.UserWithMostComics();
        }


        [HttpGet("publisher")]
        public IList<Search> MostPopularPublisher()
        {
            return statsDao.MostPopularPublisher();
        }
    }
}