<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:40:17+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "id"
}
-->
## Memulai  

Bagian ini terdiri dari beberapa pelajaran:

- **-1- Server pertama Anda**, dalam pelajaran pertama ini, Anda akan belajar cara membuat server pertama Anda dan memeriksanya dengan alat inspector, cara yang berharga untuk menguji dan debug server Anda, [ke pelajaran](/03-GettingStarted/01-first-server/README.md)

- **-2- Klien**, dalam pelajaran ini, Anda akan belajar cara menulis klien yang dapat terhubung ke server Anda, [ke pelajaran](/03-GettingStarted/02-client/README.md)

- **-3- Klien dengan LLM**, cara yang lebih baik dalam menulis klien adalah dengan menambahkan LLM sehingga dapat "bernegosiasi" dengan server Anda tentang apa yang harus dilakukan, [ke pelajaran](/03-GettingStarted/03-llm-client/README.md)

- **-4- Menggunakan mode Agen GitHub Copilot server dalam Visual Studio Code**. Di sini, kita melihat menjalankan MCP Server kita dari dalam Visual Studio Code, [ke pelajaran](/03-GettingStarted/04-vscode/README.md)

- **-5- Mengonsumsi dari SSE (Server Sent Events)** SSE adalah standar untuk streaming dari server ke klien, memungkinkan server mengirim pembaruan waktu nyata ke klien melalui HTTP [ke pelajaran](/03-GettingStarted/05-sse-server/README.md)

- **-6- Memanfaatkan AI Toolkit untuk VSCode** untuk mengonsumsi dan menguji MCP Clients dan Servers Anda [ke pelajaran](/03-GettingStarted/06-aitk/README.md)

- **-7 Pengujian**. Di sini kita akan fokus terutama bagaimana kita bisa menguji server dan klien kita dengan berbagai cara, [ke pelajaran](/03-GettingStarted/07-testing/README.md)

- **-8- Deployment**. Bab ini akan membahas berbagai cara untuk mendepoy solusi MCP Anda, [ke pelajaran](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) adalah protokol terbuka yang menstandarisasi bagaimana aplikasi menyediakan konteks untuk LLM. Anggap MCP seperti port USB-C untuk aplikasi AI - menyediakan cara standar untuk menghubungkan model AI ke berbagai sumber data dan alat.

## Tujuan Pembelajaran

Pada akhir pelajaran ini, Anda akan mampu:

- Menyiapkan lingkungan pengembangan untuk MCP dalam C#, Java, Python, TypeScript, dan JavaScript
- Membangun dan mendepoy server MCP dasar dengan fitur khusus (resource, prompt, dan tools)
- Membuat aplikasi host yang terhubung ke server MCP
- Menguji dan debug implementasi MCP
- Memahami tantangan umum dalam pengaturan dan solusinya
- Menghubungkan implementasi MCP Anda ke layanan LLM populer

## Menyiapkan Lingkungan MCP Anda

Sebelum mulai bekerja dengan MCP, penting untuk mempersiapkan lingkungan pengembangan dan memahami alur kerja dasar. Bagian ini akan memandu Anda melalui langkah awal setup untuk memastikan awal yang lancar dengan MCP.

### Prasyarat

Sebelum mulai mengembangkan MCP, pastikan Anda memiliki:

- **Lingkungan Pengembangan**: Untuk bahasa pilihan Anda (C#, Java, Python, TypeScript, atau JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, atau editor kode modern lainnya
- **Package Manager**: NuGet, Maven/Gradle, pip, atau npm/yarn
- **API Keys**: Untuk layanan AI yang akan Anda gunakan dalam aplikasi host Anda


### SDK Resmi

Di bab-bab berikutnya Anda akan melihat solusi yang dibangun menggunakan Python, TypeScript, Java, dan .NET. Berikut adalah semua SDK resmi yang didukung.

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
- Membangun server MCP melibatkan pembuatan dan pendaftaran tools dengan skema yang jelas
- Klien MCP terhubung ke server dan model untuk memanfaatkan kemampuan yang diperluas
- Pengujian dan debugging penting untuk implementasi MCP yang andal
- Pilihan deployment mulai dari pengembangan lokal hingga solusi berbasis cloud

## Latihan

Kami memiliki beberapa contoh yang melengkapi latihan yang akan Anda lihat di semua bab dalam bagian ini. Selain itu setiap bab juga memiliki latihan dan tugas masing-masing

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Sumber Daya Tambahan

- [Membangun Agen menggunakan Model Context Protocol di Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP Remote dengan Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Selanjutnya

Selanjutnya: [Membuat MCP Server pertama Anda](/03-GettingStarted/01-first-server/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk memberikan terjemahan yang akurat, harap diingat bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi yang sangat penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.