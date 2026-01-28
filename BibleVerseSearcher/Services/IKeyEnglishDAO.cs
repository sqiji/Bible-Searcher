using BibleVerseSearcher.Models;

namespace BibleVerseSearcher.Services
{
    public interface IKeyEnglishDAO
    {
        List<KeyEnglish> GetAllBooks();
        string GetBookName(int kebookNumbery);
    }
}
