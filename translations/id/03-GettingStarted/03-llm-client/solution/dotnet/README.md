<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:43:03+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "id"
}
-->
# Jalankan contoh ini

> [!NOTE]
> Contoh ini mengasumsikan Anda menggunakan instance GitHub Codespaces. Jika Anda ingin menjalankannya secara lokal, Anda perlu mengatur token akses pribadi di GitHub.

## Instal pustaka

```sh
dotnet restore
```

Harus menginstal pustaka berikut: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol

## Jalankan

```sh 
dotnet run
```

Anda harus melihat output yang mirip dengan:

```text
Setting up stdio transport
Listing tools
Connected to server with tools: Add
Tool description: Adds two numbers
Tool parameters: {"title":"Add","description":"Adds two numbers","type":"object","properties":{"a":{"type":"integer"},"b":{"type":"integer"}},"required":["a","b"]}
Tool definition: Azure.AI.Inference.ChatCompletionsToolDefinition
Properties: {"a":{"type":"integer"},"b":{"type":"integer"}}
MCP Tools def: 0: Azure.AI.Inference.ChatCompletionsToolDefinition
Tool call 0: Add with arguments {"a":2,"b":4}
Sum 6
```

Sebagian besar output hanya debugging tetapi yang penting adalah Anda mencantumkan alat dari MCP Server, ubah itu menjadi alat LLM dan Anda akan mendapatkan respons klien MCP "Sum 6".

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk memberikan terjemahan yang akurat, harap diingat bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang berwenang. Untuk informasi penting, disarankan menggunakan terjemahan manusia profesional. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.