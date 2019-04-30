using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using SampleApi.Models;
using Newtonsoft.Json.Linq;

namespace SampleApi.DAL
{
    /// <summary>
    /// Moderates the data communication used for the comic book model.
    /// </summary>
    public class ComicBookSQLDAO : IComicBookDAO
    {
        private string connectionString;

        /// <summary>
        /// Creates a new SQL-based ComicBook dao
        /// </summary>
        /// <param name="databaseConnectionString"></param>
        public ComicBookSQLDAO(string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }

        /// <summary>
        /// Returns all comic books
        /// </summary>
        /// <returns></returns>
        public IList<ComicBook> GetAllComicBooks()
        {
            List<ComicBook> comicBooks = new List<ComicBook>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM comic", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ComicBook book = ConvertReaderToComicBook(reader);
                        comicBooks.Add(book);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred retrieving all comic books.");
                Console.WriteLine(ex.Message);
                throw;
            }
            return comicBooks;
        }

        private ComicBook ConvertReaderToComicBook(SqlDataReader reader)
        {
            ComicBook book = new ComicBook
            {
                ID = Convert.ToInt32(reader["comic_id"]),
                Description = Convert.ToString(reader["description"]),
                Publisher = Convert.ToString(reader["publisher"]),
                Deck = Convert.ToString(reader["deck"]),
                Image = Convert.ToString(reader["image"]),
                IssueNumber = Convert.ToInt32(reader["issue_number"]),
                Name = Convert.ToString(reader["name"]),
                Volume = Convert.ToInt32(reader["volume"]),
                CoverDate = Convert.ToDateTime(reader["cover_date"]),
                Credits = Convert.ToString(reader["person_credits"]),
                Title = Convert.ToString(reader["title"])
            };

            return book;
        }

        /// <summary>
        /// Adds a comic book to database
        /// </summary>
        /// <param name="book"></param>
        public void AddComicBook(ComicBook book)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO comic VALUES (@title, @description, @publisher, @deck, @image, @issue_number, @name, @volume, @cover_date, @person_credits);", conn);
                    cmd.Parameters.AddWithValue("@title", book.Title);
                    cmd.Parameters.AddWithValue("@description", book.Description);
                    cmd.Parameters.AddWithValue("@publisher", book.Publisher);
                    cmd.Parameters.AddWithValue("@deck", book.Deck);
                    cmd.Parameters.AddWithValue("@image", book.Image);
                    cmd.Parameters.AddWithValue("@issue_number", book.IssueNumber);
                    cmd.Parameters.AddWithValue("@name", book.Name);
                    cmd.Parameters.AddWithValue("@volume", book.Volume);
                    cmd.Parameters.AddWithValue("@cover_date", book.CoverDate);
                    cmd.Parameters.AddWithValue("@person_credits", book.Credits);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred adding the comic book.");
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Finds a comic book by the ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ComicBook GetComicBookByID(int id)
        {
            ComicBook comicbook = new ComicBook();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //Do comic_id and @ID need to be switched
                    SqlCommand cmd = new SqlCommand("SELECT * FROM comic WHERE comic_id = @ID", conn);
                    //@comic_id might need to be @ID?
                    cmd.Parameters.AddWithValue("@ID", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ComicBook book = ConvertReaderToComicBook(reader);
                        // possibly incorrect?
                        comicbook = book;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred retrieving the comic book by the ID.");
                Console.WriteLine(ex.Message);
                throw;
            }
            return comicbook;
        }

        /// <summary>
        /// Returns a list of comics in a collection
        /// </summary>
        /// <param name="id">the collection ID</param>
        /// <returns>A list of comic book objects</returns>
        public IList<ComicBook> GetComicsByCollectionID(int id)
        {
            IList<ComicBook> comics = new List<ComicBook>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //Do comic_id and @ID need to be switched
                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM comic 
                                                    JOIN collection_comic ON comic.comic_id = collection_comic.comic_id
                                                    WHERE collection_id = @ID
                                                    order by comic.publisher, comic.title, comic.issue_number", conn);
                    //@comic_id might need to be @ID?
                    cmd.Parameters.AddWithValue("@ID", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ComicBook book = ConvertReaderToComicBook(reader);
                        // possibly incorrect?
                        comics.Add(book);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred retrieving the comic book by the ID.");
                Console.WriteLine(ex.Message);
                throw;
            }
            return comics;
        }

        /// <summary>
        /// Finds a comic book by the issue number and title
        /// </summary>
        /// <param name="seriesTitle">Title of the comic series</param>
        /// <param name="issueNumber">Issue number being searched for</param>
        /// <returns></returns>
        public ComicBook GetComicBookByIssue(string seriesTitle, int issueNumber)
        {
            ComicBook comicbook = new ComicBook();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //Do comic_id and @ID need to be switched
                    SqlCommand cmd = new SqlCommand("SELECT * FROM comic WHERE title = @seriesTitle AND issue_number = @issueNumber", conn);
                    //@comic_id might need to be @ID?
                    cmd.Parameters.AddWithValue("@seriesTitle", seriesTitle);
                    cmd.Parameters.AddWithValue("@issueNumber", issueNumber);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ComicBook book = ConvertReaderToComicBook(reader);
                            // possibly incorrect?
                            comicbook = book;
                        }
                    }
                    else
                    {
                        ComicInfo(this, seriesTitle, issueNumber);
                        comicbook = GetComicBookByIssue(seriesTitle, issueNumber);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred retrieving the comic book by the ID.");
                Console.WriteLine(ex.Message);
                throw;
            }
            return comicbook;
        }

        /// <summary>
        /// Get comic information from ComicVine
        /// </summary>
        /// <param name="cbsd">Instance of the DAO to enable two-way communication</param>
        /// <param name="seriesTitle">Title of the comic</param>
        /// <param name="issueNumber">Issue we're looking for</param>
        public ComicBook ComicInfo(ComicBookSQLDAO cbsd, string seriesTitle, int issueNumber)
        {
            ComicApiInfo comicApiInfo = new ComicApiInfo();
            int volumeId = comicApiInfo.GetVolumeInfo(seriesTitle);
            ComicBook book = comicApiInfo.GetIssueInfo(volumeId, issueNumber);
            cbsd.AddComicBook(book);
            return book;
        }

        /// <summary>
        /// Get information from ComicVine if issue not found in database.
        /// </summary>
        public class ComicApiInfo
        {
            int volumeId = 0;
            string publisherName = "";
            string seriesTitle = "";

            /// <summary>
            /// Get volume information to retrieve publisher
            /// </summary>
            /// <param name="seriesTitle"></param>
            /// <returns></returns>
            public int GetVolumeInfo(string seriesTitle)
            {
                var client = new RestClient("http://www.comicvine.com/api/volumes/?api_key=c4bfb45f7bcb288c0dba5973d0888b3dd4f4b05f&format=json&filter=name:" + seriesTitle);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");
                IRestResponse response = client.Execute(request);
                JObject content = (JObject)JsonConvert.DeserializeObject(response.Content);
                JArray results = (JArray)content["results"];
                foreach (JObject volume in results)
                {
                    string title = (string)volume["name"];
                    if (title == seriesTitle)
                    {
                        this.seriesTitle = seriesTitle;
                        volumeId = (int)volume["id"];
                        publisherName = (string)volume["publisher"]["name"];
                        break; // Found the volume we need
                    }
                }
                return volumeId;
            }

            /// <summary>
            /// Build record to populate comic DB
            /// </summary>
            /// <param name="volumeId">Volume for this title</param>
            /// <param name="issueNumber">Issue number we're building a record for</param>
            /// <returns></returns>
            public ComicBook GetIssueInfo(int volumeId, int issueNumber)
            {
                var client = new RestClient("http://www.comicvine.com/api/issues/?api_key=c4bfb45f7bcb288c0dba5973d0888b3dd4f4b05f&format=json&filter=volume:" + volumeId + ",issue_number:" + issueNumber);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");
                IRestResponse response = client.Execute(request);
                JObject content = JsonConvert.DeserializeObject<JObject>(response.Content);
                JArray results = (JArray)content["results"];
                ComicBook book = new ComicBook();
                book.ID = (int)results[0]["id"];
                book.Description = (string)results[0]["description"];
                book.Deck = (string)results[0]["deck"];
                book.Image = (string)results[0]["image"]["small_url"];
                book.IssueNumber = (int)results[0]["issue_number"];
                book.Name = (string)results[0]["name"];
                book.CoverDate = DateTime.Parse((string)results[0]["cover_date"]);
                book.Credits = (string)results[0]["person_credits"];
                book.Publisher = publisherName;
                book.Title = seriesTitle;
                if (book.Deck == null)
                {
                    book.Deck = string.Empty;
                }
                if (book.Description == null)
                {
                    book.Description = string.Empty;
                }
                if (book.Credits == null)
                {
                    book.Credits = string.Empty;
                }
                if (book.Name == null)
                {
                    book.Name = string.Empty;
                }

                return book;
            }
        }

        public IList<ComicBook> ComicsFromDateRange(DateTime start, DateTime end)
        {
            IList<ComicBook> comics = new List<ComicBook>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM comic 
                                                    WHERE cover_date >= @start and cover_date <= @end", conn);
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@end", end);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ComicBook book = ConvertReaderToComicBook(reader);
                        comics.Add(book);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred retrieving the comic book by Date.");
                Console.WriteLine(ex.Message);
                throw;
            }
            return comics;
        }

        /// <summary>
        /// A list of comics from a single publisher
        /// </summary>
        /// <param name="publisher">The publisher</param>
        /// <returns>A list of comic books</returns>
        public IList<ComicBook> SearchByPublisher(string publisher)
        {
            IList<ComicBook> comics = new List<ComicBook>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //Do comic_id and @ID need to be switched
                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM comic 
                                                    WHERE publisher = @publisher", conn);
                    //@comic_id might need to be @ID?
                    cmd.Parameters.AddWithValue("@publisher", publisher);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ComicBook book = ConvertReaderToComicBook(reader);
                        // possibly incorrect?
                        comics.Add(book);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred retrieving the comic book by the Publisher.");
                Console.WriteLine(ex.Message);
                throw;
            }
            return comics;
        }

    }
}

