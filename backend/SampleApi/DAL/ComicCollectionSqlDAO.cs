using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SampleApi.Models;

namespace SampleApi.DAL
{
    /// <summary>
    /// Represents a Comic Collection Sql DAO.
    /// </summary>
    public class ComicCollectionSqlDAO : IComicCollectionDAO
    {
        /// <summary>
        /// The Sql connection string.
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// Creates a comic collection Sql DAO via a connection string.
        /// </summary>
        /// <param name="connectionString">The Sql connection string.</param>
        public ComicCollectionSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Gets all the Collections from the SQL DB.
        /// </summary>
        /// <returns>A List of Collections.</returns>
        public IList<ComicCollection> GetCollections()
        {
            List<ComicCollection> collections = new List<ComicCollection>();
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM collection;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ComicCollection collection = ConvertSqlToCollection(reader);
                        collections.Add(collection);
                    }
                }
                // LOG LEVEL:Info Query successfull Collections retrived.
            }
            catch (SqlException)
            {
                // LOG LEVEL Error
                throw;
            }

            return collections;
        }

        private ComicCollection ConvertSqlToCollection(SqlDataReader reader)
        {
            ComicCollection covertedCollection = new ComicCollection
            {
                Id = Convert.ToInt32(reader["id"]),
                UserId = Convert.ToInt32(reader["user_id"]),
                Title = Convert.ToString(reader["title"]),
                Description = Convert.ToString(reader["description"]),
                AccessLevel = Convert.ToString(reader["public_access"])
            };

            return covertedCollection;
        }

        /// <summary>
        /// Saves the collections to the Sql DB.
        /// </summary>
        /// <param name="collections">A List of Collections.</param>
        /// <returns>A bool indicating if the transaction was succefull.</returns>
        public bool SaveCollections(IList<ComicCollection> collections)
        {
            throw new NotImplementedException();
        }
    }
}
