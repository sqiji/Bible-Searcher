
# Bible Searcher Web Application

## 1. Project Overview
[cite_start]The **Bible Searcher App** is a robust web application designed to facilitate Bible study through advanced search and personal reflection tools[cite: 5, 6]. [cite_start]Built with an **N-layer architecture**, it allows users to navigate the text via keyword searches or specific book/chapter references[cite: 7, 8, 11].

## 2. Hardware and Software Technologies
* [cite_start]**Framework:** ASP.NET Core MVC (N-Layered)[cite: 11].
* [cite_start]**Language:** C#[cite: 11].
* [cite_start]**Frontend:** Razor Pages (HTML), CSS, and JavaScript[cite: 11].
* [cite_start]**Database:** MySQL[cite: 12].
* [cite_start]**Data Handling:** JSON for dynamic chapter mapping (e.g., mapping 28 chapters to Matthew vs. 4 to Ruth)[cite: 13].
* **Development Tool:** Visual Studio 2022 (Solution Explorer structure).

---

## 3. Logical Solution Design
The application follows a strict separation of concerns through three logical layers:
* **Presentation Layer:** Contains Razor pages (`.cshtml`) for user interaction, including Search, Results, and Details views.
* **Business Logic Layer:** Managed by the `HomeController.cs` to handle request routing and user input processing.
* **Data Access Layer (DAL):** Consists of Data Access Objects (DAO) and Interfaces (e.g., `ITWebDAO`, `IVerseNoteDAO`) to abstract database operations.



---

## 4. Physical Solution Design
* **Web Server:** Processes C# logic and serves dynamic content via the ASP.NET Core runtime.
* **File System:** Stores the `bookChapters.json` configuration file within the `wwwroot/json` directory.
* **Database Server:** A MySQL instance hosting the `BibleApplication` database, containing the primary data tables.

---

## 5. Key Technical Design Decisions
* **Dependency Inversion:** Use of interfaces (e.g., `IKeyEnglishDAO`) in the Services folder to ensure the application is not tightly coupled to a specific database implementation.
* [cite_start]**Dynamic UI Validation:** Leveraging a JSON file to dynamically populate the "Select Chapter" dropdown based on the selected book, preventing "Page Not Found" errors for non-existent chapters[cite: 13, 139].
* **Persistence:** Implementing a dedicated `VerseNotes` table to allow users to save, retrieve, and update personal insights for specific verses.

---

## 6. Schema ER Diagram
The `BibleApplication` database includes three core tables:
1.  **`dbo.key_english`**: Stores book names and metadata.
2.  **`dbo.t_web`**: Stores the Bible text (World English Bible).
3.  **`dbo.VerseNotes`**: Stores user-created notes linked to specific verses with timestamps.



---

## 7. Flow Charts / Process Flows
**Note-Taking Process:**
1.  [cite_start]User views "Search Results" or "Chapter Reference"[cite: 31, 86].
2.  [cite_start]User clicks "Details" on a specific verse[cite: 33, 106].
3.  [cite_start]The system loads the Details page and displays any existing notes[cite: 112, 117].
4.  [cite_start]User enters text in the "Add Note" box and submits[cite: 114, 115].
5.  [cite_start]The system saves the note to MySQL and refreshes the list with a timestamp[cite: 106, 127].

---

## 8. Sitemap Diagram
* **Home:** `Index.cshtml` (Search by keyword or Book/Chapter reference).
* **Search Results:** `SearchResults.cshtml` (List of verses found).
* **Full Chapter:** `ReferenceResults.cshtml` (Full text of a specific chapter).
* **Verse Details:** `Details.cshtml` (Note management for a single verse).
* **Privacy:** `Privacy.cshtml`.

---

## 9. UML Diagrams
* **Models:** `BookChapter`, `VerseNote`, `TWeb`, `KeyEnglish`, `SearchResultViewModel`, `ChapterVerseViewModel`.
* **Data Access:** `TWebDAO`, `KeyEnglishDAO`, `VerseNoteDAO` and their respective Interfaces.



---

## 10. Conclusion
[cite_start]This project demonstrates the ability to build a data-driven web application using professional software engineering patterns[cite: 11]. [cite_start]By utilizing an N-layer architecture and MySQL integration, the Bible Searcher provides a scalable solution for text-based searching and personal data management[cite: 5, 9, 12].
