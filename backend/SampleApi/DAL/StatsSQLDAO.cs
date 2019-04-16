using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleApi.Models;

namespace SampleApi.DAL
{
    public class StatsSQLDAO : IStatsDAO
    {
        private readonly string connectionString;

        public StatsSQLDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public IList<ComicBook> ComicsFromDateRange()
        {
            throw new NotImplementedException();
        }

        public IList<ComicCollection> LargestCollection()
        {
            throw new NotImplementedException();
        }

        public IList<ComicBook> MostPopularComic()
        {
            throw new NotImplementedException();
        }

        public IList<(string, int)> MostPopularPublisher()
        {
            throw new NotImplementedException();
        }

        public IList<ComicCollection> RecentlyUpdated()
        {
            throw new NotImplementedException();
        }

        public int TotalComics()
        {
            throw new NotImplementedException();
        }

        public IList<UserDisplay> UserWithMostComics()
        {
            throw new NotImplementedException();
        }
    }
}
