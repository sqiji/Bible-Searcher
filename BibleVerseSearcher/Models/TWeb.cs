namespace BibleVerseSearcher.Models
{
    public class TWeb
    {
        public int id { get; set; }
        public int b { get; set; } // Book number
        public int c { get; set; } // Chapter number
        public int v { get; set; } // Verse number
        public string t { get; set; } // Verse text
    }
}
