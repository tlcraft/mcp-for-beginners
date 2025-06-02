<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e1cbc99fa7185139ad6d539eca09a2b3",
  "translation_date": "2025-06-02T20:20:13+00:00",
  "source_file": "05-AdvancedTopics/mcp-root-contexts/README.md",
  "language_code": "en"
}
-->
## Example: Root Context Implementation for financial analysis

In this example, we will set up a root context for a financial analysis session, showing how to maintain state across multiple interactions.

## Example: Root Context Management

Effectively managing root contexts is essential for preserving conversation history and state. Here’s an example of how to implement root context management.

## Root Context for Multi-Turn Assistance

In this example, we will create a root context for a multi-turn assistance session, illustrating how to maintain state throughout several interactions.

## Root Context Best Practices

Here are some best practices for managing root contexts effectively:

- **Create Focused Contexts**: Establish separate root contexts for different conversation topics or domains to keep things clear.

- **Set Expiration Policies**: Apply policies to archive or delete old contexts to manage storage and comply with data retention rules.

- **Store Relevant Metadata**: Use context metadata to save important information about the conversation that could be useful later.

- **Use Context IDs Consistently**: After creating a context, consistently use its ID for all related requests to maintain continuity.

- **Generate Summaries**: When a context becomes large, consider creating summaries to capture key information while controlling context size.

- **Implement Access Control**: For multi-user systems, set up proper access controls to protect the privacy and security of conversation contexts.

- **Handle Context Limitations**: Be mindful of context size limits and develop strategies to manage very long conversations.

- **Archive When Complete**: Archive contexts once conversations are finished to free up resources while preserving conversation history.

## What's next

- [Routing](../mcp-routing/README.md)

**Disclaimer**:  
This document has been translated using the AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.