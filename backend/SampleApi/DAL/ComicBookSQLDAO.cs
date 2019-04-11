using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using SampleApi.Models;

namespace SampleApi.DAL
{
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
            ComicBook book = new ComicBook();
            book.ID = Convert.ToInt32(reader["comic_id"]);
            book.Description = Convert.ToString(reader["description"]);
            book.Publisher = Convert.ToString(reader["publisher"]);
            book.Deck = Convert.ToString(reader["deck"]);
            book.Image = Convert.ToString(reader["image"]);
            book.IssueNumber = Convert.ToInt32(reader["issue_number"]);
            book.Name = Convert.ToString(reader["name"]);
            book.Volume = Convert.ToInt32(reader["volume"]);
            book.CoverDate = Convert.ToDateTime(reader["cover_date"]);
            book.Credits = Convert.ToString(reader["person_credits"]);
            book.Title = Convert.ToString(reader["title"]);

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

                    SqlCommand cmd = new SqlCommand("INSERT INTO comic VALUES (@description, @publisher, @deck, @image, @issue_number, @name, @volume, @cover_date, @person_credits, @title);", conn);
                    cmd.Parameters.AddWithValue("@description", book.Description);
                    cmd.Parameters.AddWithValue("@publisher", book.Publisher);
                    cmd.Parameters.AddWithValue("@deck", book.Deck);
                    cmd.Parameters.AddWithValue("@image", book.Image);
                    cmd.Parameters.AddWithValue("@issue_number", book.IssueNumber);
                    cmd.Parameters.AddWithValue("@name", book.Name);
                    cmd.Parameters.AddWithValue("@volume", book.Volume);
                    cmd.Parameters.AddWithValue("@cover_date", book.CoverDate);
                    cmd.Parameters.AddWithValue("@person_credits", book.Credits);
                    cmd.Parameters.AddWithValue("@title", book.Title);

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
                    SqlCommand cmd = new SqlCommand("SELECT * FROM comic WHERE comic_title = @seriesTitle AND issue_number = @issueNumber", conn);
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
        public void ComicInfo(ComicBookSQLDAO cbsd, string seriesTitle, int issueNumber)
        {
            ComicApiInfo comicApiInfo = new ComicApiInfo();
            int volumeId = 0;
            string publisherName = "";
            ComicBook book = new ComicBook();
            volumeId = comicApiInfo.GetVolumeInfo(seriesTitle);
            book = comicApiInfo.GetIssueInfo(volumeId, issueNumber);
            cbsd.AddComicBook(book);
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
            /// Map of the JSON ComicVine sends back for volume queries.
            /// Items without a description are unused.
            /// </summary>
            public class ComicVineVolumeResponse
            {
                public string error { get; set; }
                public int limit { get; set; }
                public int offset { get; set; }
                public int number_of_page_results { get; set; }
                public int number_of_total_results { get; set; }
                public int status_code { get; set; }

                /// <summary>
                /// array of results from request
                /// </summary>
                public VolumeResult[] results { get; set; }
                public string version { get; set; }
            }

            /// <summary>
            /// array of volumes matching the seriesTitle
            /// </summary>
            public class VolumeResult
            {
                public string aliases { get; set; }
                public string api_detail_url { get; set; }
                public int count_of_issues { get; set; }
                public string date_added { get; set; }
                public string date_last_updated { get; set; }
                public string deck { get; set; }
                public string description { get; set; }
                public string first_issue { get; set; }

                /// <summary>
                /// Volume ID, used to retrieve issue record
                /// </summary>
                public int id { get; set; }

                public string image { get; set; }
                public string last_issue { get; set; }

                /// <summary>
                /// Series title
                /// </summary>
                public string name { get; set; }

                /// <summary>
                /// object for publisher info
                /// </summary>
                public Publisher publisher { get; set; }

                public string site_detail_url { get; set; }
                public string start_year { get; set; }
            }

            /// <summary>
            /// Used to get the publisher name
            /// </summary>
            public class Publisher
            {
                public string api_detail_url { get; set; }
                public int id { get; set; }

                /// <summary>
                /// The publisher name, stored in comic detail database
                /// </summary>
                public string name { get; set; }
            }

            /// <summary>
            /// Map of the JSON ComicVine sends back for issue queries.
            /// Items without a description are unused.
            /// </summary>
            public class ComicVineIssueResponse
            {
                public string error { get; set; }
                public int limit { get; set; }
                public int offset { get; set; }
                public int number_of_page_results { get; set; }
                public int number_of_total_results { get; set; }
                public int status_code { get; set; }

                /// <summary>
                /// array of results from request
                /// </summary>
                public IssueResult[] results { get; set; }
                public string version { get; set; }
            }

            /// <summary>
            /// Array of issues matching the issue number for this volume 
            /// (We hope there will be only one)
            /// </summary>
            public class IssueResult
            {
                public object aliases { get; set; }
                public string api_detail_url { get; set; }

                /// <summary>
                /// The issue date of the comic
                /// </summary>
                public string cover_date { get; set; }

                public string date_added { get; set; }
                public string date_last_updated { get; set; }

                /// <summary>
                /// Short summary of the issue
                /// </summary>
                public object deck { get; set; }

                /// <summary>
                /// Long description of the issue
                /// </summary>
                public object description { get; set; }

                public bool has_staff_review { get; set; }

                /// <summary>
                /// ComicVine ID of the issue - saved in case we need to re-reference
                /// </summary>
                public int id { get; set; }

                /// <summary>
                /// Array of images related to the issue
                /// We will use the thumbnail image
                /// </summary>
                public Image image { get; set; }

                /// <summary>
                /// The issue number
                /// </summary>
                public string issue_number { get; set; }

                /// <summary>
                /// The issue title
                /// </summary>
                public object name { get; set; }

                public string site_detail_url { get; set; }
                public object store_date { get; set; }
                public string volume { get; set; }
            }

            public class Image
            {
                public string icon_url { get; set; }
                public string medium_url { get; set; }
                public string screen_url { get; set; }
                public string screen_large_url { get; set; }
                public string small_url { get; set; }
                public string super_url { get; set; }

                /// <summary>
                /// This is the image the website will use
                /// </summary>
                public string thumb_url { get; set; }

                public string tiny_url { get; set; }
                public string original_url { get; set; }
                public string image_tags { get; set; }
            }

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
                ComicVineVolumeResponse volumeResponse = (ComicVineVolumeResponse)response;
                foreach (VolumeResult volume in volumeResponse.results)
                {
                    if (volume.name == seriesTitle)
                    {
                        volumeId = volume.id;
                        publisherName = volume.publisher.name;
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
                var client = new RestClient("http://www.comicvine.com/api/issues/?api_key=c4bfb45f7bcb288c0dba5973d0888b3dd4f4b05f&format=json&filter=volume:filter=volume:" + volumeId + ",issue_number:" + issueNumber);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");
                IRestResponse response = client.Execute(request);
                ComicVineIssueResponse issueResponse = (ComicVineIssueResponse)response;
                ComicBook book = new ComicBook();
                book.CoverDate = DateTime.Parse(issueResponse.results[0].cover_date);
                book.Deck = (string)issueResponse.results[0].deck;
                book.Description = (string)issueResponse.results[0].description;
                book.ID = issueResponse.results[0].id;
                book.Image = issueResponse.results[0].image.thumb_url;
                book.IssueNumber = int.Parse(issueResponse.results[0].issue_number);
                book.Name = (string)issueResponse.results[0].name;
                book.Publisher = publisherName;
                book.Title = seriesTitle;

                return book;
            }
        }
    }
}

