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

        /// <summary>
        /// A list of search objects for the largest collections
        /// </summary>
        /// <returns>search objects for largest collections</returns>
        public IList<Search> LargestCollection()
        {
            IList<Search> results = new List<Search>();

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

            return results;
        }

        /// <summary>
        /// A list of search objects for the most popular comics
        /// </summary>
        /// <returns>search objects for most popular comics</returns>
        public IList<Search> MostPopularComic()
        {
            IList<Search> results = new List<Search>();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"select top 10 count(*) as count, comic_id from collection_comic
                                                    group by comic_id
                                                    order by count desc;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Search search = new Search();

                        search.Id = Convert.ToInt32(reader["comic_id"]);
                        search.Value = Convert.ToInt32(reader["count"]);
                        results.Add(search);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return results;
        }

        public IList<Search> MostPopularPublisher()
        {
            IList<Search> results = new List<Search>();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"select count(*) as count, publisher from comic
                                                    group by publisher
                                                    order by count desc;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Search search = new Search();

                        search.Name = Convert.ToString(reader["publisher"]);
                        search.Value = Convert.ToInt32(reader["count"]);
                        results.Add(search);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return results;

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

        /// <summary>
        /// Counts the number of collections in the database
        /// </summary>
        /// <returns>The number of collections</returns>
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

        public IList<Search> UserWithMostComics()
        {
            IList<Search> results = new List<Search>();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"select top 10 count(*) as count, id as userId from users
                                                    join collection on users.id = collection.user_id
                                                    join collection_comic on collection.collection_id = collection_comic.collection_id
                                                    group by users.id
                                                    order by count desc;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Search search = new Search();

                        search.Id = Convert.ToInt32(reader["userId"]);
                        search.Value = Convert.ToInt32(reader["count"]);
                        results.Add(search);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return results;
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
