# Company Assistant

## Overview

Company Assistant is an internal AI-powered knowledge assistant for company employees and customers.

The system allows users to ask questions about:

- Accounting software products
- Support procedures
- Company policies
- Leave and vacation rules
- Frequently requested information

The assistant searches a knowledge base stored in Markdown files and returns the most relevant content.

---

## Goals

- Provide quick access to company knowledge
- Reduce repetitive support requests
- Centralize internal documentation
- Support future AI/RAG capabilities

---

## Technology Stack

### Frontend

- React
- TypeScript
- Vite

### Backend

- ASP.NET Core 9 Web API
- Vertical Slice Architecture
- Dependency Injection

### Knowledge Base

- Markdown (.md) files

---

## Current Search Strategy

Current implementation uses:

- Markdown documents
- Chunk-based search
- Keyword matching

Search Flow:

User Question
→ Search Knowledge Base
→ Find Best Chunk
→ Return Result

---

## Future Roadmap

### Phase 1

Keyword Search

### Phase 2

OpenAI Embeddings

### Phase 3

Vector Database

### Phase 4

Full RAG (Retrieval-Augmented Generation)

---

## Project Structure

backend/
frontend/
docs/

---

## Non-Goals

- Public chatbot
- General AI assistant
- Training custom language models

The system is focused only on company knowledge.