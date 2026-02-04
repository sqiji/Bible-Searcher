
# Bible Searcher Web Application

## 1. Project Overview:

The **Bible Searcher App** is a web-based application that allows users to search and read Bible verses efficiently. Users can search by keyword or phrase across the entire Bible, restrict searches to the Old Testament or New Testament, or browse by selecting a specific book and chapter. The application also allows users to add, update, and view personal notes for individual verses.
The project follows an **N-Layer Architecture** using **ASP.NET Core MVC**, with a **MySQL** relational database for persistent storage and a **JSON file** to manage Bible book-to-chapter mappings.

---

## 2. Technologies Used:

* **Program Language:** C#.
* **Framework:** ASP.NET Core MVC.
* **Frontend:** Razor Pages (HTML, CSS, and JavaScript).
* **Backend Architecture:** N-Layer Architecture (Presentation, Business Logic, Data Access).
* **Database:** MySQL.
* **Data Access Pattern**: DAO (Data Access Object).
* **Data Handling:** JSON for dynamic chapter mapping (e.g., mapping 28 chapters to Matthew vs. 4 to Ruth).
* **Development Tool:** Visual Studio 2022 (Solution Explorer structure).

---

## 3. Logical Solution Design:

The application follows a strict separation of concerns through three logical layers:
* **Presentation Layer:** Contains Razor pages (`.cshtml`) for user interaction, including Search, Results, and Details views.
* **Business Logic Layer:** Managed by the `HomeController.cs` to handle request routing and user input processing.
* **Data Access Layer:** Consists of Data Access Objects (DAO) and Interfaces (e.g., `ITWebDAO`, `IVerseNoteDAO`) to abstract database operations.
* **Data Sources:** MySQL Database include three tabels Bible verses, Bible chapters, and notes. Using JSON file to mapping book to chapter.
  
[Logical Solution](/Documents/LogicalSolution.jpg).

---

## 4. Physical Solution Design
* **Web Server:** Processes C# logic and serves dynamic content via the ASP.NET Core MVC runtime.
* **File System:** Stores the `bookChapters.json` configuration file within the `wwwroot/json` directory.
* **Database Server:** Application communicates with MySQL database server.

[Physical Solution](/Documents/PhysicalSolution.jpg).

---

## 5. Key Technical Design Decisions
* **Dependency Inversion:** Use of interfaces (e.g., `IKeyEnglishDAO`) in the Services folder to ensure the application is not tightly coupled to a specific database implementation.
* **Dynamic UI Validation:** Leveraging a JSON file to dynamically populate the "Select Chapter" dropdown based on the selected book, preventing "Page Not Found" errors for non-existent chapters.
* **Persistence:** Implementing a dedicated `VerseNotes` table to allow users to save, retrieve, and update personal insights for specific verses.

---

## 6. Schema ER Diagram
The `BibleApplication` database includes three core tables:
1.  **`dbo.key_english`**: Stores book names and metadata.
2.  **`dbo.t_web`**: Stores the Bible text (World English Bible).
3.  **`dbo.VerseNotes`**: Stores user-created notes linked to specific verses with timestamps.

[ER Diagram](/Documents/ER.jpg).

---

## 7. Flow Charts / Process Flows
**Note-Taking Process:**
1.  User views "Search Results" or "Chapter Reference."
2.  User clicks "Details" on a specific verse.
3.  The system loads the Details page and displays any existing notes.
4.  User enters text in the "Add Note" box and submits.
5.  The system saves the note to MySQL and refreshes the list with a timestamp.

[Flowchart](/Documents/FlowChart.jpg).

---

## 8. Sitemap Diagram
* **Home:** `Index.cshtml` (Search by keyword or Book/Chapter reference).
* **Search Results:** `SearchResults.cshtml` (List of verses found).
* **Full Chapter:** `ReferenceResults.cshtml` (Full text of a specific chapter).
* **Verse Details:** `Details.cshtml` (Note management for a single verse).
* **Privacy:** `Privacy.cshtml`.

[Sitemap](/Documents/Sitemap.jpg).

---

## 9. UML Diagrams
* **Controller:** `HomeController`.
* **Models:** `BookChapter`, `VerseNote`, `TWeb`, `KeyEnglish`, `SearchResultViewModel`, `ChapterVerseViewModel`, and `ErrorViewModel`.
* **Data Access:** `TWebDAO`, `KeyEnglishDAO`, `VerseNoteDAO` and their respective Interfaces.

[UML](/Documents/UML.jpg).

---

## 10. Conclusion
This project demonstrates the ability to build a data-driven web application using professional software engineering patterns. By utilizing an N-layer architecture and MySQL integration, the Bible Searcher provides a scalable solution for text-based searching and personal data management.

---

**Author: Soran Qiji\
Course: CST-350 (C sharp)\
Project: Bible Searcher App\
Grand Canyon University**
