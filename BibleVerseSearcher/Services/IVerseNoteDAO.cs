using BibleVerseSearcher.Models;

namespace BibleVerseSearcher.Services
{
    public interface IVerseNoteDAO
    {
        List<VerseNote> GetNotesForVerse(int verseId);
        void AddNote(VerseNote note);
    }
}
