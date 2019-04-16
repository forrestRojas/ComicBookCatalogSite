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
            IList<ComicCollection> largestCollections = new List<ComicCollection>();
            List<Search> results = new List<Search>();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"select count(*) as count, collection_id from collection_comic
                                                    group by collection_id
                                                    order by count desc;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Search search = new Search();

                        search.Id = Convert.ToInt32(reader["collection_id"]);
                        search.Value = Convert.ToInt32(reader["count"]);
                        results.Add(search);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            try
            {
                foreach (Search result in results)
                {
                    using (SqlConnection conn = new SqlConnection(this.connectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("select * from collection where collection_id = @collection", conn);
                        cmd.Parameters.AddWithValue("@collection", result.Id);

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            ComicCollection collection = ConvertSqlToCollection(reader);
                            largestCollections.Add(collection);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }


            return largestCollections;
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

        public int TotalCollections()
        {
            int total = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT count(*) as count FROM collection;", conn);
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

        private ComicCollection ConvertSqlToCollection(SqlDataReader reader)
        {
            ComicCollection covertedCollection = new ComicCollection
            {
                Id = Convert.ToInt32(reader["collection_id"]),
                UserId = Convert.ToInt32(reader["user_id"]),
                Title = Convert.ToString(reader["title"]),
                Image = Convert.ToString(reader["image"]),
                Description = Convert.ToString(reader["description"]),
                AccessLevel = Convert.ToString(reader["public_access"])
            };

            return covertedCollection;
        }

    }
}
