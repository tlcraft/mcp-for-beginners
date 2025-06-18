<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f01d4263fc6eec331615fef42429b720",
  "translation_date": "2025-06-18T18:24:24+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "id"
}
-->
### -2- Buat proyek

Sekarang setelah SDK Anda terpasang, mari buat proyek berikutnya:

### -3- Buat file proyek

### -4- Buat kode server

### -5- Menambahkan alat dan sumber daya

Tambahkan alat dan sumber daya dengan menambahkan kode berikut:

### -6 Kode akhir

Mari tambahkan kode terakhir yang kita butuhkan agar server bisa berjalan:

### -7- Uji server

Jalankan server dengan perintah berikut:

### -8- Jalankan menggunakan inspector

Inspector adalah alat hebat yang bisa memulai server Anda dan memungkinkan Anda berinteraksi dengannya sehingga Anda bisa menguji apakah server berfungsi. Mari kita mulai:

> [!NOTE]
> mungkin tampilannya berbeda di kolom "command" karena berisi perintah untuk menjalankan server dengan runtime spesifik Anda

Anda akan melihat antarmuka pengguna berikut:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.id.png)

1. Sambungkan ke server dengan memilih tombol Connect  
   Setelah terhubung ke server, Anda akan melihat tampilan berikut:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.id.png)

2. Pilih "Tools" dan "listTools", Anda akan melihat opsi "Add" muncul, pilih "Add" dan isi nilai parameter.

   Anda akan melihat respons seperti berikut, yaitu hasil dari alat "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.id.png)

Selamat, Anda berhasil membuat dan menjalankan server pertama Anda!

### SDK Resmi

MCP menyediakan SDK resmi untuk berbagai bahasa:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Dipelihara bersama Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Dipelihara bersama Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Implementasi resmi TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Implementasi resmi Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Implementasi resmi Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Dipelihara bersama Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Implementasi resmi Rust

## Poin Penting

- Menyiapkan lingkungan pengembangan MCP cukup mudah dengan SDK khusus bahasa
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

1. Implementasikan alat tersebut dalam bahasa pilihan Anda (.NET, Java, Python, atau JavaScript).
2. Definisikan parameter input dan nilai keluaran.
3. Jalankan alat inspector untuk memastikan server berfungsi sebagaimana mestinya.
4. Uji implementasi dengan berbagai input.

## Solusi

[Solusi](./solution/README.md)

## Sumber Daya Tambahan

- [Membangun Agen menggunakan Model Context Protocol di Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP dengan Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Selanjutnya

Selanjutnya: [Memulai dengan Klien MCP](/03-GettingStarted/02-client/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk akurasi, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sah. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.