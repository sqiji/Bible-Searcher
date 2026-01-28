using BibleVerseSearcher.Models;

namespace BibleVerseSearcher.Services
{
    public interface ITWebDAO
    {
        List<TWeb> GetVersesByBookChapter(int bookNumber, int chapterNumber);
        List<TWeb> SearchVerses(string searchTerm, bool searchOldTestament, bool searchNewTestament);
        TWeb GetVerseById(int verseId);
    }
}
