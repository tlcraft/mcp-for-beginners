<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:43:18+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "ms"
}
-->
# Jalankan sampel ini

> [!NOTE]
> Sampel ini menganggap anda menggunakan instance GitHub Codespaces. Jika anda ingin menjalankannya secara lokal, anda perlu menetapkan token akses peribadi di GitHub.

## Pasang perpustakaan

```sh
dotnet restore
```

Perlu memasang perpustakaan berikut: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol 

## Jalankan

```sh 
dotnet run
```

Anda sepatutnya melihat output yang serupa dengan:

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

Banyak daripada output hanyalah penyahpepijatan tetapi yang penting ialah anda menyenaraikan alat dari MCP Server, menukarkannya menjadi alat LLM dan anda akan mendapat respons klien MCP "Sum 6".

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang berwibawa. Untuk maklumat kritikal, terjemahan manusia profesional adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.