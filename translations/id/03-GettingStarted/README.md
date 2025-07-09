<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "860935ff95d05b006d1d3323e8e3f9e8",
  "translation_date": "2025-07-09T22:33:33+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "id"
}
-->
## Memulai  

Bagian ini terdiri dari beberapa pelajaran:

- **1 Server pertamamu**, dalam pelajaran pertama ini, kamu akan belajar cara membuat server pertamamu dan memeriksanya dengan alat inspector, cara yang berguna untuk menguji dan men-debug servermu, [ke pelajaran](01-first-server/README.md)

- **2 Klien**, dalam pelajaran ini, kamu akan belajar cara menulis klien yang dapat terhubung ke servermu, [ke pelajaran](02-client/README.md)

- **3 Klien dengan LLM**, cara yang lebih baik untuk menulis klien adalah dengan menambahkan LLM agar dapat "bernegosiasi" dengan servermu tentang apa yang harus dilakukan, [ke pelajaran](03-llm-client/README.md)

- **4 Menggunakan mode Agen GitHub Copilot server di Visual Studio Code**. Di sini, kita akan melihat cara menjalankan MCP Server dari dalam Visual Studio Code, [ke pelajaran](04-vscode/README.md)

- **5 Mengkonsumsi dari SSE (Server Sent Events)** SSE adalah standar untuk streaming server-ke-klien, memungkinkan server mengirim pembaruan real-time ke klien melalui HTTP [ke pelajaran](05-sse-server/README.md)

- **6 HTTP Streaming dengan MCP (Streamable HTTP)**. Pelajari tentang streaming HTTP modern, notifikasi progres, dan cara mengimplementasikan server dan klien MCP yang skalabel dan real-time menggunakan Streamable HTTP. [ke pelajaran](06-http-streaming/README.md)

- **7 Memanfaatkan AI Toolkit untuk VSCode** untuk mengkonsumsi dan menguji MCP Klien dan Servermu [ke pelajaran](07-aitk/README.md)

- **8 Pengujian**. Di sini kita akan fokus terutama pada cara menguji server dan klien kita dengan berbagai metode, [ke pelajaran](08-testing/README.md)

- **9 Deployment**. Bab ini akan membahas berbagai cara untuk melakukan deployment solusi MCP-mu, [ke pelajaran](09-deployment/README.md)


Model Context Protocol (MCP) adalah protokol terbuka yang menstandarisasi cara aplikasi menyediakan konteks ke LLM. Anggap MCP seperti port USB-C untuk aplikasi AI - menyediakan cara standar untuk menghubungkan model AI ke berbagai sumber data dan alat.

## Tujuan Pembelajaran

Di akhir pelajaran ini, kamu akan mampu:

- Menyiapkan lingkungan pengembangan untuk MCP di C#, Java, Python, TypeScript, dan JavaScript
- Membangun dan menerapkan server MCP dasar dengan fitur kustom (resources, prompts, dan tools)
- Membuat aplikasi host yang terhubung ke server MCP
- Menguji dan men-debug implementasi MCP
- Memahami tantangan umum dalam pengaturan dan solusinya
- Menghubungkan implementasi MCP-mu ke layanan LLM populer

## Menyiapkan Lingkungan MCP-mu

Sebelum mulai bekerja dengan MCP, penting untuk menyiapkan lingkungan pengembangan dan memahami alur kerja dasar. Bagian ini akan membimbingmu melalui langkah-langkah awal agar memulai MCP berjalan lancar.

### Prasyarat

Sebelum terjun ke pengembangan MCP, pastikan kamu memiliki:

- **Lingkungan Pengembangan**: Untuk bahasa pilihanmu (C#, Java, Python, TypeScript, atau JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, atau editor kode modern lainnya
- **Package Manager**: NuGet, Maven/Gradle, pip, atau npm/yarn
- **API Keys**: Untuk layanan AI yang akan kamu gunakan dalam aplikasi hostmu


### SDK Resmi

Di bab-bab berikutnya kamu akan melihat solusi yang dibangun menggunakan Python, TypeScript, Java, dan .NET. Berikut adalah semua SDK resmi yang didukung.

MCP menyediakan SDK resmi untuk berbagai bahasa:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Dipelihara bekerja sama dengan Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Dipelihara bekerja sama dengan Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Implementasi resmi TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Implementasi resmi Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Implementasi resmi Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Dipelihara bekerja sama dengan Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Implementasi resmi Rust

## Poin Penting

- Menyiapkan lingkungan pengembangan MCP cukup mudah dengan SDK khusus bahasa
- Membangun server MCP melibatkan pembuatan dan pendaftaran tools dengan skema yang jelas
- Klien MCP terhubung ke server dan model untuk memanfaatkan kemampuan tambahan
- Pengujian dan debugging penting untuk implementasi MCP yang andal
- Pilihan deployment mulai dari pengembangan lokal hingga solusi berbasis cloud

## Latihan

Kami menyediakan beberapa contoh yang melengkapi latihan yang akan kamu temui di semua bab dalam bagian ini. Selain itu, setiap bab juga memiliki latihan dan tugasnya sendiri.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Sumber Tambahan

- [Membangun Agen menggunakan Model Context Protocol di Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP Remote dengan Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Selanjutnya

Selanjutnya: [Membuat MCP Server pertamamu](01-first-server/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk akurasi, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sah. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.