<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8311f46a35cf608c9780f39b62c9dc3f",
  "translation_date": "2025-07-14T01:57:13+00:00",
  "source_file": "05-AdvancedTopics/mcp-root-contexts/README.md",
  "language_code": "en"
}
-->
## Example: Root Context Implementation for financial analysis

In this example, we will create a root context for a financial analysis session, showing how to maintain state across multiple interactions.

## Example: Root Context Management

Effectively managing root contexts is essential for preserving conversation history and state. Below is an example of how to implement root context management.

## Root Context for Multi-Turn Assistance

In this example, we will create a root context for a multi-turn assistance session, demonstrating how to maintain state across multiple interactions.

## Root Context Best Practices

Here are some best practices for managing root contexts effectively:

- **Create Focused Contexts**: Create separate root contexts for different conversation purposes or domains to keep things clear.

- **Set Expiration Policies**: Implement policies to archive or delete old contexts to manage storage and comply with data retention rules.

- **Store Relevant Metadata**: Use context metadata to save important information about the conversation that might be useful later.

- **Use Context IDs Consistently**: Once a context is created, use its ID consistently for all related requests to maintain continuity.

- **Generate Summaries**: When a context becomes large, consider creating summaries to capture key information while managing context size.

- **Implement Access Control**: For multi-user systems, set up proper access controls to ensure privacy and security of conversation contexts.

- **Handle Context Limitations**: Be aware of context size limits and implement strategies for managing very long conversations.

- **Archive When Complete**: Archive contexts when conversations are finished to free up resources while preserving conversation history.

## What's next

- [5.5 Routing](../mcp-routing/README.md)

**Disclaimer**:  
This document has been translated using the AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.