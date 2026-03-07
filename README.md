# Snippet-Hub-AI-Project
** AnL AI Code Snippet Hub** is a platform helping in storing and analyzing code snippets solving problems from Competitive Informatics. Users can add their own algorithms, categorize them and use LLM for code analysis and documentation.

# AI Code Snippet Hub

**AI Code Snippet Hub** е платформа за съхранение и анализ на кодови snippet-и за състезателна информатика. Потребителите могат да добавят свои алгоритми, да ги категоризират и да използват AI за анализ и документация на кода.

---

## Features

- **CRUD for code snippets** (Create, Read, Update, Delete)
- **User system** (Login/Register) with ASP.NET Identity
- **Categories of snippets** by language and type of algorithm
- **Filtering and searching** by language and category
- **AI integration** with OpenAI API:
  - Explain code
  - Code review
  - Generate documentation
  - Algorithm detection
  - Test case generation
- **Syntax highlighting** with highlight.js
- **Responsive design** with Bootstrap (supports desktop, tablet and mobile)
- **UX/UI improvements**: dark mode, copy code button, tags, dashboard statistics

---

## Technologies

- ASP.NET Core MVC  
- Bootstrap  
- SQL Server
- OpenAI API  
- highlight.js  
- ASP.NET Identity  

---

## Architecture

```text
User
 ↓
ASP.NET Core MVC Application
 ↓
Services (OpenAIService)
 ↓
OpenAI API
 ↓
Database (SQL Server)
---
```

# ✅ Workflow таблица (чеклист за проекта)

# AI Code Snippet Hub - Project Workflow (Kanban Style)

## 📝 To Do
- [ ] Setup ASP.NET Core MVC project
- [ ] Configure SQLite database
- [ ] Create Snippet model
- [ ] Setup ASP.NET Identity (users)
- [ ] Implement SnippetsController (CRUD)
- [ ] Create Views (Index, Create, Details, Edit)
- [ ] Implement search & filter (language & category)
- [ ] Integrate highlight.js for code highlighting
- [ ] Create OpenAIService (API calls)
- [ ] Implement Explain Code feature
- [ ] Implement Code Review feature
- [ ] Implement Generate Documentation feature
- [ ] Implement Algorithm Detection feature
- [ ] Implement Test Case Generation feature
- [ ] Improve UI/UX (dark mode, cards, tags, copy code)
- [ ] Make website responsive (Bootstrap)
- [ ] Add Dashboard & snippet statistics
- [ ] Write README.md
- [ ] Optional: MAUI mobile client (for bonus points)

## 🔄 In Progress
- [ ] (tasks which are in progress of completing)

## ✅ Done
- [ ] (completed tasks)
