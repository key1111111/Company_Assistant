# AGENT_CONTEXT

## Project Purpose

This project is an internal Company Assistant.

The application answers questions using company knowledge stored in Markdown files.

---

## Architecture

Backend follows Vertical Slice Architecture.

Feature folders contain:

- Endpoint
- Request
- Response
- Handler

Example:

Features/
└── AskQuestion/
    ├── AskQuestionEndpoint.cs
    ├── AskQuestionRequest.cs
    ├── AskQuestionResponse.cs
    └── AskQuestionHandler.cs

---

## Backend Rules

### Dependency Injection

Register services through Program.cs.

Example:

builder.Services.AddScoped<IKnowledgeBaseService,
    MarkdownKnowledgeBaseService>();

---

### Service Design

Business logic must remain inside services.

Endpoints should only:

- Receive requests
- Call handlers
- Return results

---

### Search Logic

Knowledge search is abstracted behind:

IKnowledgeBaseService

Current implementation:

MarkdownKnowledgeBaseService

Future implementations may include:

VectorKnowledgeBaseService
OpenAiKnowledgeBaseService

Handlers should depend only on interfaces.

---

### Markdown Knowledge Base

All knowledge documents are stored under:

docs/

Example:

docs/
├── faq.md
├── support.md
├── vacation-rules.md
└── product.md

---

### Chunking Strategy

Documents should be organized using Markdown headings.

Example:

## Product: Accounting Pro

Description...

## Product: Accounting Enterprise

Description...

Each section represents one searchable chunk.

---

### Coding Standards

- Use async/await
- Prefer records for DTOs
- Use dependency injection
- Keep methods small
- Follow SOLID principles

---

### Future AI Roadmap

Current:
Keyword Search

Planned:
Embeddings
Vector Search
RAG

Code should be written to allow replacing the knowledge service without changing endpoints.

---

### Frontend

React application calls:

POST /api/ask

Request:

{
  "question": "How many leave days do employees receive?"
}

Response:

{
  "answer": "...",
  "source": "leave-rules.md"
}