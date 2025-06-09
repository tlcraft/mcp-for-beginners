<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e1cbc99fa7185139ad6d539eca09a2b3",
  "translation_date": "2025-06-02T20:29:50+00:00",
  "source_file": "05-AdvancedTopics/mcp-root-contexts/README.md",
  "language_code": "ms"
}
-->
## Example: Root Context Implementation for financial analysis

In this example, we will create a root context for a financial analysis session, demonstrating how to maintain state across multiple interactions.

## Example: Root Context Management

Managing root contexts effectively is crucial for maintaining conversation history and state. Below is an example of how to implement root context management.

## Root Context for Multi-Turn Assistance

In this example, we will create a root context for a multi-turn assistance session, demonstrating how to maintain state across multiple interactions.

## Root Context Best Practices

Here are some best practices for managing root contexts effectively:

- **Create Focused Contexts**: Create separate root contexts for different conversation purposes or domains to maintain clarity.

- **Set Expiration Policies**: Implement policies to archive or delete old contexts to manage storage and comply with data retention policies.

- **Store Relevant Metadata**: Use context metadata to store important information about the conversation that might be useful later.

- **Use Context IDs Consistently**: Once a context is created, use its ID consistently for all related requests to maintain continuity.

- **Generate Summaries**: When a context grows large, consider generating summaries to capture essential information while managing context size.

- **Implement Access Control**: For multi-user systems, implement proper access controls to ensure privacy and security of conversation contexts.

- **Handle Context Limitations**: Be aware of context size limitations and implement strategies for handling very long conversations.

- **Archive When Complete**: Archive contexts when conversations are complete to free resources while preserving the conversation history.

## What's next

- [Routing](../mcp-routing/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.