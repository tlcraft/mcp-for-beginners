<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-13T00:31:07+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "id"
}
-->
## Memulai  

Bagian ini terdiri dari beberapa pelajaran:

- **1 Server pertama Anda**, dalam pelajaran pertama ini, Anda akan belajar cara membuat server pertama Anda dan memeriksanya dengan alat inspector, cara yang berguna untuk menguji dan debug server Anda, [ke pelajaran](/03-GettingStarted/01-first-server/README.md)

- **2 Client**, dalam pelajaran ini, Anda akan belajar cara menulis client yang dapat terhubung ke server Anda, [ke pelajaran](/03-GettingStarted/02-client/README.md)

- **3 Client dengan LLM**, cara yang lebih baik untuk menulis client adalah dengan menambahkan LLM agar dapat "bernegosiasi" dengan server Anda tentang apa yang harus dilakukan, [ke pelajaran](/03-GettingStarted/03-llm-client/README.md)

- **4 Menggunakan mode GitHub Copilot Agent server di Visual Studio Code**. Di sini, kita melihat cara menjalankan MCP Server dari dalam Visual Studio Code, [ke pelajaran](/03-GettingStarted/04-vscode/README.md)

- **5 Mengkonsumsi dari SSE (Server Sent Events)** SSE adalah standar untuk streaming dari server ke client, memungkinkan server mengirim pembaruan waktu nyata ke client melalui HTTP [ke pelajaran](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP Streaming dengan MCP (Streamable HTTP)**. Pelajari tentang streaming HTTP modern, notifikasi progres, dan cara mengimplementasikan server dan client MCP yang skalabel dan real-time menggunakan Streamable HTTP. [ke pelajaran](/03-GettingStarted/06-http-streaming/README.md)

- **7 Memanfaatkan AI Toolkit untuk VSCode** untuk mengkonsumsi dan menguji MCP Client dan Server Anda [ke pelajaran](/03-GettingStarted/07-aitk/README.md)

- **8 Pengujian**. Di sini kita akan fokus khususnya bagaimana kita dapat menguji server dan client kita dengan berbagai cara, [ke pelajaran](/03-GettingStarted/08-testing/README.md)

- **9 Deployment**. Bab ini akan membahas berbagai cara untuk mendistribusikan solusi MCP Anda, [ke pelajaran](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) adalah protokol terbuka yang menstandarisasi bagaimana aplikasi menyediakan konteks ke LLM. Anggap MCP seperti port USB-C untuk aplikasi AI - menyediakan cara standar untuk menghubungkan model AI ke berbagai sumber data dan alat.

## Tujuan Pembelajaran

Pada akhir pelajaran ini, Anda akan mampu:

- Menyiapkan lingkungan pengembangan untuk MCP dalam C#, Java, Python, TypeScript, dan JavaScript
- Membangun dan mendistribusikan server MCP dasar dengan fitur kustom (resource, prompt, dan alat)
- Membuat aplikasi host yang terhubung ke server MCP
- Menguji dan debug implementasi MCP
- Memahami tantangan pengaturan umum dan solusinya
- Menghubungkan implementasi MCP Anda ke layanan LLM populer

## Menyiapkan Lingkungan MCP Anda

Sebelum mulai bekerja dengan MCP, penting untuk mempersiapkan lingkungan pengembangan dan memahami alur kerja dasar. Bagian ini akan membimbing Anda melalui langkah awal agar memulai dengan MCP berjalan lancar.

### Prasyarat

Sebelum terjun ke pengembangan MCP, pastikan Anda memiliki:

- **Lingkungan Pengembangan**: Untuk bahasa pilihan Anda (C#, Java, Python, TypeScript, atau JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, atau editor kode modern lainnya
- **Manajer Paket**: NuGet, Maven/Gradle, pip, atau npm/yarn
- **API Keys**: Untuk layanan AI yang akan Anda gunakan dalam aplikasi host Anda


### SDK Resmi

Dalam bab-bab berikutnya Anda akan melihat solusi yang dibangun menggunakan Python, TypeScript, Java, dan .NET. Berikut semua SDK resmi yang didukung.

MCP menyediakan SDK resmi untuk berbagai bahasa:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Dipelihara bekerja sama dengan Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Dipelihara bekerja sama dengan Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Implementasi resmi TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Implementasi resmi Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Implementasi resmi Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Dipelihara bekerja sama dengan Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Implementasi resmi Rust

## Hal Penting yang Perlu Diingat

- Menyiapkan lingkungan pengembangan MCP cukup mudah dengan SDK spesifik bahasa
- Membangun server MCP melibatkan pembuatan dan pendaftaran alat dengan skema yang jelas
- Client MCP terhubung ke server dan model untuk memanfaatkan kemampuan yang diperluas
- Pengujian dan debugging penting untuk implementasi MCP yang andal
- Pilihan deployment mulai dari pengembangan lokal hingga solusi berbasis cloud

## Berlatih

Kami memiliki sejumlah contoh yang melengkapi latihan yang akan Anda lihat di semua bab dalam bagian ini. Selain itu setiap bab juga memiliki latihan dan tugas masing-masing

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
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk akurasi, harap diingat bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sah. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.