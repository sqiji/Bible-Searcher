using BibleVerseSearcher.Models;
using Microsoft.Data.SqlClient;

namespace BibleVerseSearcher.Services
{
    public class VerseNoteDAO : IVerseNoteDAO
    {
        private string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BibleApplication;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public List<VerseNote> GetNotesForVerse(int verseId)
        {
            List<VerseNote> notes = new List<VerseNote>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT Id, VerseId, NoteText, CreatedDate FROM VerseNotes WHERE VerseId = @verseId ORDER BY CreatedDate DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@verseId", verseId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            VerseNote note = new VerseNote
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                VerseId = Convert.ToInt32(reader["VerseId"]),
                                NoteText = reader["NoteText"].ToString(),
                                CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                            };
                            notes.Add(note);
                        }
                    }
                }
            }
            return notes;
        }

        public void AddNote(VerseNote note)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "INSERT INTO VerseNotes (VerseId, NoteText) VALUES (@verseId, @noteText)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@verseId", note.VerseId);
                    cmd.Parameters.AddWithValue("@noteText", note.NoteText);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
