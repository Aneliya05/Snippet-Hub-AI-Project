# Snippet-Hub-AI-Project
AnL Snippet Hub is a powerful project based on MVC layer architecture. The aim of the project is to help people in storing their code snippets which solve a great variety of algorithmic tasks. The integrated LLM will help with code analysis and allocation of snippets in different categories.

# AI Code Snippet Hub

**AI Code Snippet Hub** е платформа за съхранение и анализ на кодови snippet-и за състезателна информатика. Потребителите могат да добавят свои алгоритми, да ги категоризират и да използват AI за анализ и документация на кода.

---

## Features

- **CRUD за кодови snippet-и** (Create, Read, Update, Delete)
- **Потребителска система** (Login/Register) с ASP.NET Identity
- **Категоризация** по език и тип алгоритъм
- **Филтриране и търсене** по категория и език
- **AI интеграция** с OpenAI API:
  - Explain code
  - Code review
  - Generate documentation
  - Algorithm detection
  - Test case generation
- **Syntax highlighting** с highlight.js
- **Responsive дизайн** с Bootstrap (поддържа desktop, tablet и mobile)
- **UX/UI подобрения**: dark mode, copy code button, tags, dashboard статистики

---

## Technologies

- ASP.NET Core MVC  
- Bootstrap  
- SQLite  
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
Database (SQLite)




---

# ✅ Workflow таблица (чеклист за проекта)

```markdown
# AI Code Snippet Hub - Project Workflow

| Task | Status | Notes |
|------|--------|-------|
| Setup ASP.NET Core MVC project | ☐ | |
| Configure SQLite database | ☐ | |
| Create Snippet model | ☐ | |
| Setup ASP.NET Identity (users) | ☐ | |
| Implement SnippetsController | ☐ | CRUD: Index, Create, Details, Edit, Delete |
| Create Views (Index, Create, Details, Edit) | ☐ | Bootstrap layout |
| Implement search & filter | ☐ | By language & category |
| Integrate highlight.js for code | ☐ | Syntax highlighting |
| Create AIService | ☐ | OpenAI API calls |
| Implement Explain Code feature | ☐ | |
| Implement Code Review feature | ☐ | |
| Implement Generate Documentation feature | ☐ | |
| Implement Algorithm Detection feature | ☐ | |
| Implement Test Case Generation feature | ☐ | |
| Improve UI/UX (dark mode, cards, tags, copy code) | ☐ | |
| Make website responsive (mobile-friendly) | ☐ | Bootstrap |
| Add Dashboard & snippet statistics | ☐ | |
| Write README.md | ☐ | Include architecture, features, prompts, screenshots |
| Optional: MAUI mobile client | ☐ | For bonus points |
