using BibleVerseSearcher.Models;
using Microsoft.Data.SqlClient;

namespace BibleVerseSearcher.Services
{
    public class KeyEnglishDAO : IKeyEnglishDAO
    {
        private string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BibleApplication;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public List<KeyEnglish> GetAllBooks()
        {
            List<KeyEnglish> books = new List<KeyEnglish>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT b, n, t, g FROM key_english ORDER BY b";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            KeyEnglish book = new KeyEnglish
                            {
                                b = Convert.ToInt32(reader["b"]),
                                n = reader["n"].ToString(),
                                t = reader["t"].ToString(),
                                g = Convert.ToInt32(reader["g"])
                            };
                            books.Add(book);
                        }
                    }
                }
            }
            return books;
        }

        public string GetBookName(int bookNumber)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT n FROM key_english WHERE b = @bookNumber";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bookNumber", bookNumber);
                    object result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
        }

    }
}

