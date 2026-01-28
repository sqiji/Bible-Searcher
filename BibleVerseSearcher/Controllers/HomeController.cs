using System.Diagnostics;
using System.Text.Json;
using BibleVerseSearcher.Models;
using BibleVerseSearcher.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BibleVerseSearcher.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITWebDAO _tWebDAO;
        private readonly IKeyEnglishDAO _keyEnglishDAO; 
        private readonly IVerseNoteDAO _verseNoteDAO; 

        public HomeController(ITWebDAO tWebDAO, IKeyEnglishDAO keyEnglishDAO, IVerseNoteDAO verseNoteDAO)
        {
            _tWebDAO = tWebDAO;
            _keyEnglishDAO = keyEnglishDAO;
            _verseNoteDAO = verseNoteDAO;
        }

        public IActionResult Index()
        {
            ViewBag.Books = _keyEnglishDAO.GetAllBooks();
            return View();
        }

        public IActionResult SearchResults(string searchTerm, bool searchOldTestament, bool searchNewTestament)
        {
            if (searchTerm.IsNullOrEmpty())
            {
                return RedirectToAction("Index");
            }

            List<TWeb> results = _tWebDAO.SearchVerses(searchTerm, searchOldTestament, searchNewTestament);
            List<SearchResultViewModel> viewModel = results.Select(verse => new SearchResultViewModel
            {
                Verse = verse,
                BookName = _keyEnglishDAO.GetBookName(verse.b)
            }).ToList();
            return View(viewModel);
        }

        public IActionResult ReferenceResults(int bookNumber, int chapterNumber)
        {
            List<TWeb> verses = _tWebDAO.GetVersesByBookChapter(bookNumber, chapterNumber);
            List<ChapterVerseViewModel> viewModel = verses.Select(verse => new ChapterVerseViewModel
            {
                Verse = verse,
                BookName = _keyEnglishDAO.GetBookName(verse.b)
            }).ToList();
            ViewBag.BookName = _keyEnglishDAO.GetBookName(bookNumber);
            ViewBag.BookNumber = bookNumber;
            ViewBag.ChapterNumber = chapterNumber;
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            TWeb verse = _tWebDAO.GetVerseById(id);
            if (verse == null)
            {
                return NotFound();
            }

            ViewBag.Notes = _verseNoteDAO.GetNotesForVerse(id);
            ViewBag.BookName = _keyEnglishDAO.GetBookName(verse.b); // Get book name for details view
            return View(verse);
        }

        [HttpPost]
        public IActionResult AddNote(int verseId, string noteText)
        {
            if (string.IsNullOrEmpty(noteText))
            {
                return BadRequest("Note text is required.");
            }

            VerseNote newNote = new VerseNote
            {
                VerseId = verseId,
                NoteText = noteText
            };
            _verseNoteDAO.AddNote(newNote);
            return RedirectToAction("Details", new { id = verseId });
        }

        [HttpGet]
        public IActionResult GetChapterCount(int bookNumber)
        {
            string jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/json", "bookChapters.json"); // Adjust path if needed
            string json = System.IO.File.ReadAllText(jsonPath);

            var bookChapterData = JsonSerializer.Deserialize<List<BookChapter>>(json);

            var book = bookChapterData.FirstOrDefault(b => b.bookNumber == bookNumber);

            if (book != null)
            {
                return Content(book.chapters.ToString());
                // Or, to return JSON: return Json(new { chapterCount = book.chapters });
            }
            else
            {
                return Content("52"); 
            }
        }
    }
}

