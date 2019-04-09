using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SampleApi.Models;

namespace SampleApi.DAL
{
    public class ComicBookDAO : IComicBookDAO
    {
        private string connectionString;

        /// <summary>
        /// Creates a new SQL-based ComicBook dao
        /// </summary>
        /// <param name="databaseConnectionString"></param>
        public ComicBookDAO(string databaseConnectionString)
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

                    while(reader.Read()){
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
            book.ID = Convert.ToInt32(reader["coimc_id"]);
            book.Description = Convert.ToString(reader["description"]);
            book.Deck = Convert.ToString(reader["deck"]);
            book.Image = Convert.ToString(reader["image"]);
            book.IssueNumber = Convert.ToInt32(reader["issue_number"]);
            book.Name = Convert.ToString(reader["name"]);
            book.Volume = Convert.ToInt32(reader["volume"]);
            book.CoverDate = Convert.ToDateTime(reader["cover_date"]);
            book.Credits = Convert.ToString(reader["person_credits"]);

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

                    SqlCommand cmd = new SqlCommand("INSERT INTO comic VALUES (@description, @deck, @image, @issue_number, @name, @volume, @cover_date, @person_credits);", conn);
                    cmd.Parameters.AddWithValue("@description", book.Description);
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
                    cmd.Parameters.AddWithValue("@comic_id", id);

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
    }
}

