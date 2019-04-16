using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        /// <summary>
        /// Counts the total number of comics in the database
        /// </summary>
        /// <returns>total</returns>
        public int TotalComics()
        {
            int total = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT count(*) as count FROM comic;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        total = Convert.ToInt32(reader["count"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return total;
        }

        public IList<UserDisplay> UserWithMostComics()
        {
            throw new NotImplementedException();
        }
    }
}
