# About
This is a demo application - .NET 9 + Angular 20 (with Angular Material and Tailwind).

## Core details

A web application simulating a simple AI chatbot, built with future integration with a real artificial intelligence model in mind. The project consists of a frontend Angular application and a backend API based on ASP.NET Core Web API.

### ✨ Features

* **Conversation history** – all messages are stored and displayed with author distinction (user/chatbot).
* **Response rating** – each chatbot message can be rated ("👍" or "👎"), with the ability to change the rating at any time.
* **Typing simulation** – responses are generated gradually, imitating the typing process: from short sentences to multi-paragraph texts.
* **Cancel generation** – the user can interrupt the response generation at any time; only the already generated part remains visible and saved.
* **Data persistence** – chat history and ratings are stored in the database.

### ⚙️ Technologies

* **Frontend:** Angular + Angular Material + TailwindCSS
* **Backend:** ASP.NET Core Web API
* **ORM:** Entity Framework Core
* **Database:** Postgres
* **Extras:**
    * MediatR for managing application flows,
    * Bogus for generating sample responses.

### 🛠️ Notes

The application is designed with modularity in mind – it is easy to replace the "Lorem ipsum" with integration to a real AI model. Styling follows Angular Material standards, and the UI focuses on functionality rather than flashy colors.

---

Want to add something more personal or include screenshots? Let me know, and we'll add some color 🌈


## Project structure

### Backend (`/backend`)

  - `Controllers/` - API controllers (e.g., chat and session handling)
  - `Data/` - data access logic
    - `Models/` - data models (used by the DB)
    - `Repositories/` - repositories for database operations
  - `DTOs/` - Data Transfer Objects
    - `Chat/`, `Sessions/`, `Enums/`, etc. - divided by data types and operations
  - `Interfaces/` - service interfaces whose implementations can be easily swapped
  - `MediatR/` - CQRS implementation (commands, queries, handlers)
  - `Migrations/` - database migrations (Entity Framework)
  - `Services/` - business logic (mock service for generating responses)
  - `Program.cs` - application entry point
  - `appsettings.json` - application configuration
  - `Properties/` - launch settings

### Frontend (`/frontend`)

- `components/` - UI components
- `features/` - features (smart components)
- `layout/` - application layout
- `models/` - data models
- `services/` - services for backend communication
- `stores/` - state management


## Development

### Frontend
Run application
```
npm run start
```

### Backend

Before start:
>You have to install postgres database and configure connection string in appsettings.json (dev) file.

>You can use other database engine - in this case you need to change provider in program.cs

#### Run application
```
dotnet run
```

#### Create migration for DB sync
```
dotnet ef migrations add <MIGRATION_NAME>
```
>This command will create a new file with the migration description for use by the **update** process

#### Sync migration to DB
```
dotnet ef database update
```

### Troubleshooting
If the migration process does not work, check if the EF tool is installed:
```
dotnet tool install --global dotnet-ef
```


## Switching between mock and real AI model implementation

To switch the backend to use a real AI model:

1. Implement the communication logic with the model in `Services/RealChatService.cs`.
2. In your `appsettings.json` (or `appsettings.Development.json`), set the flag:
   ```json
   "UseRealModel": true
   ```
3. The backend will automatically inject the correct service based on this flag.

By default, the mock (`FakeChatService`) is used.
