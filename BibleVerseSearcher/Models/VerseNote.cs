namespace BibleVerseSearcher.Models
{
    public class VerseNote
    {
        public int Id { get; set; }
        public int VerseId { get; set; }
        public string NoteText { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
