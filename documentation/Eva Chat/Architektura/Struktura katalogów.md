ChatbotApi/
├── Interfaces/
│   └── IChatService.cs
├── Services/
│   ├── Real/
│   │   └── OpenAiChatService.cs
│   └── Mocks/
│       └── FakeChatService.cs
├── Controllers/
│   └── ChatController.cs
├── Data/
│   └── ApplicationDbContext.cs
├── DTOs/
│   ├── SendMessageDto.cs
│   ├── BotResponseDto.cs
│   └── ChatHistoryDto.cs
├── MediatR/
│   ├── Commands/
│   │   └── SendMessageCommand.cs
│   ├── Queries/
│   │   └── GetHistoryQuery.cs
│   └── Handlers/
│       ├── SendMessageHandler.cs
│       └── GetHistoryHandler.cs
└── Program.cs
