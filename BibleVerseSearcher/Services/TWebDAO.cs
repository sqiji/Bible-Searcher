using BibleVerseSearcher.Models;
using Microsoft.Data.SqlClient;

namespace BibleVerseSearcher.Services
{
    public class TWebDAO : ITWebDAO
    {

        private string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BibleApplication;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public List<TWeb> GetVersesByBookChapter(int bookNumber, int chapterNumber)
        {
            List<TWeb> verses = new List<TWeb>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT id, b, c, v, t FROM t_web WHERE b = @bookNumber AND c = @chapterNumber ORDER BY v";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bookNumber", bookNumber);
                    cmd.Parameters.AddWithValue("@chapterNumber", chapterNumber);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TWeb verse = new TWeb
                            {
                                id = Convert.ToInt32(reader["id"]),
                                b = Convert.ToInt32(reader["b"]),
                                c = Convert.ToInt32(reader["c"]),
                                v = Convert.ToInt32(reader["v"]),
                                t = reader["t"].ToString()
                            };
                            verses.Add(verse);
                        }
                    }
                }
            }
            return verses;
        }

        public List<TWeb> SearchVerses(string searchTerm, bool searchOldTestament, bool searchNewTestament)
        {
            List<TWeb> results = new List<TWeb>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT tw.id, tw.b, tw.c, tw.v, tw.t
                        FROM t_web tw
                        INNER JOIN key_english ke ON tw.b = ke.b
                        ";

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " AND LOWER(tw.t) LIKE LOWER(@searchTerm) ";
                    if (searchOldTestament == true)
                    {
                        query += "WHERE(@searchOld = 1 AND ke.t = 'OT') ";
                    }
                    if (searchNewTestament == true)
                    {
                        query += "WHERE (@searchNew = 1 AND ke.t = 'NT')";
                    }
                    
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                    }

                    cmd.Parameters.AddWithValue("@searchOld", searchOldTestament ? 1 : 0);
                    cmd.Parameters.AddWithValue("@searchNew", searchNewTestament ? 1 : 0);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TWeb verse = new TWeb
                            {
                                id = Convert.ToInt32(reader["id"]),
                                b = Convert.ToInt32(reader["b"]),
                                c = Convert.ToInt32(reader["c"]),
                                v = Convert.ToInt32(reader["v"]),
                                t = reader["t"].ToString()
                            };
                            results.Add(verse);
                        }
                    }
                }
            }
            return results;
        }

        public TWeb GetVerseById(int verseId)
        {
            TWeb verse = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT id, b, c, v, t FROM t_web WHERE id = @verseId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@verseId", verseId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            verse = new TWeb
                            {
                                id = Convert.ToInt32(reader["id"]),
                                b = Convert.ToInt32(reader["b"]),
                                c = Convert.ToInt32(reader["c"]),
                                v = Convert.ToInt32(reader["v"]),
                                t = reader["t"].ToString()
                            };
                        }
                    }
                }
            }
            return verse;
        }
    }
}
