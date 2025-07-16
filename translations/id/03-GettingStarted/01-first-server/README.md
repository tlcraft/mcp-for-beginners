<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d5b044c0924d393af3066e03d7d89c5",
  "translation_date": "2025-07-16T09:48:32+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "id"
}
-->
### -2- Buat proyek

Sekarang setelah Anda menginstal SDK, mari buat proyek berikutnya:

### -3- Buat file proyek

### -4- Buat kode server

### -5- Menambahkan alat dan sumber daya

Tambahkan alat dan sumber daya dengan menambahkan kode berikut:

### -6 Kode akhir

Mari tambahkan kode terakhir yang kita butuhkan agar server dapat dijalankan:

### -7- Uji server

Mulai server dengan perintah berikut:

### -8- Jalankan menggunakan inspector

Inspector adalah alat hebat yang dapat memulai server Anda dan memungkinkan Anda berinteraksi dengannya sehingga Anda dapat menguji apakah server berfungsi. Mari kita mulai:
> [!NOTE]  
> mungkin terlihat berbeda di bidang "command" karena berisi perintah untuk menjalankan server dengan runtime spesifik Anda/
Anda seharusnya melihat antarmuka pengguna berikut:

![Connect](/03-GettingStarted/01-first-server/assets/connect.png)

1. Sambungkan ke server dengan memilih tombol Connect  
   Setelah terhubung ke server, Anda akan melihat tampilan berikut:

   ![Connected](/03-GettingStarted/01-first-server/assets/connected.png)

1. Pilih "Tools" dan "listTools", Anda akan melihat "Add" muncul, pilih "Add" dan isi nilai parameter.

   Anda akan melihat respons berikut, yaitu hasil dari alat "add":

   ![Result of running add](/03-GettingStarted/01-first-server/assets/ran-tool.png)

Selamat, Anda telah berhasil membuat dan menjalankan server pertama Anda!

### Official SDKs

MCP menyediakan SDK resmi untuk berbagai bahasa pemrograman:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Dipelihara bekerja sama dengan Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Dipelihara bekerja sama dengan Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Implementasi resmi TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Implementasi resmi Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Implementasi resmi Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Dipelihara bekerja sama dengan Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Implementasi resmi Rust

## Hal-Hal Penting

- Menyiapkan lingkungan pengembangan MCP mudah dengan SDK khusus bahasa
- Membangun server MCP melibatkan pembuatan dan pendaftaran alat dengan skema yang jelas
- Pengujian dan debugging sangat penting untuk implementasi MCP yang andal

## Contoh

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Tugas

Buat server MCP sederhana dengan alat pilihan Anda:

1. Implementasikan alat tersebut dalam bahasa favorit Anda (.NET, Java, Python, atau JavaScript).  
2. Definisikan parameter input dan nilai kembalian.  
3. Jalankan alat inspector untuk memastikan server berjalan sesuai harapan.  
4. Uji implementasi dengan berbagai input.

## Solusi

[Solution](./solution/README.md)

## Sumber Daya Tambahan

- [Membangun Agen menggunakan Model Context Protocol di Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [Remote MCP dengan Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Selanjutnya

Selanjutnya: [Memulai dengan MCP Clients](../02-client/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk mencapai akurasi, harap diingat bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.