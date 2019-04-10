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
                Id = Convert.ToInt32(reader["collection_id"]),
                UserId = Convert.ToInt32(reader["user_id"]),
                Title = Convert.ToString(reader["title"]),
                Image = Convert.ToString(reader["image"]),
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
            bool isSuccessful = false;

            
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO collections (user_id, title, image, description, public_access) VALUES (@user_id, @title, @image, @description, @public_access)", conn, transaction);
                    foreach (ComicCollection collection in collections)
                    {
                        cmd.Parameters.AddWithValue("@user_id", collection.UserId);
                        cmd.Parameters.AddWithValue("@title", collection.Title);
                        cmd.Parameters.AddWithValue("@image", collection.Image);
                        cmd.Parameters.AddWithValue("@description", collection.Description);
                        cmd.Parameters.AddWithValue("@public_access", collection.AccessLevel);
                        isSuccessful = cmd.ExecuteNonQuery() == 1;
                    }
                    transaction.Commit();
                }
                catch (SqlException)
                {
                    // LOG LEVEL: Error 
                    transaction.Rollback();
                    throw;
                }
            }

            return isSuccessful;
        }

        public ComicCollection GetASingleCollection(int id)
        {
            ComicCollection collection = new ComicCollection();
            try
            {
                using (SqlConnection conn = new SqlConnection(this.connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM collection WHERE @id = collection_id;", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        collection = ConvertSqlToCollection(reader);
                    }
                }
                // LOG LEVEL:Info Query successfull Collections retrived.
            }
            catch (SqlException)
            {
                // LOG LEVEL Error
                throw;
            }

            return collection;
        }
    }
}
