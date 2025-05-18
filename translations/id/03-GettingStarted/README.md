<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:12:57+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "id"
}
-->
## Memulai  

Bagian ini terdiri dari beberapa pelajaran:

- **-1- Server pertama Anda**, dalam pelajaran pertama ini, Anda akan belajar bagaimana membuat server pertama Anda dan memeriksanya dengan alat inspeksi, cara yang berharga untuk menguji dan memperbaiki server Anda, [ke pelajaran](/03-GettingStarted/01-first-server/README.md)

- **-2- Klien**, dalam pelajaran ini, Anda akan belajar bagaimana menulis klien yang dapat terhubung ke server Anda, [ke pelajaran](/03-GettingStarted/02-client/README.md)

- **-3- Klien dengan LLM**, cara yang lebih baik untuk menulis klien adalah dengan menambahkan LLM sehingga dapat "bernegosiasi" dengan server Anda tentang apa yang harus dilakukan, [ke pelajaran](/03-GettingStarted/03-llm-client/README.md)

- **-4- Menggunakan mode Agen GitHub Copilot server di Visual Studio Code**. Di sini, kita akan melihat cara menjalankan MCP Server dari dalam Visual Studio Code, [ke pelajaran](/03-GettingStarted/04-vscode/README.md)

- **-5- Menggunakan dari SSE (Server Sent Events)** SSE adalah standar untuk streaming dari server ke klien, memungkinkan server untuk memberikan pembaruan real-time ke klien melalui HTTP [ke pelajaran](/03-GettingStarted/05-sse-server/README.md)

- **-6- Memanfaatkan AI Toolkit untuk VSCode** untuk menggunakan dan menguji Klien dan Server MCP Anda [ke pelajaran](/03-GettingStarted/06-aitk/README.md)

- **-7 Pengujian**. Di sini kita akan fokus terutama pada bagaimana kita dapat menguji server dan klien kita dengan cara yang berbeda, [ke pelajaran](/03-GettingStarted/07-testing/README.md)

- **-8- Penerapan**. Bab ini akan melihat berbagai cara penerapan solusi MCP Anda, [ke pelajaran](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) adalah protokol terbuka yang menstandarkan cara aplikasi memberikan konteks ke LLM. Anggap MCP seperti port USB-C untuk aplikasi AI - ia menyediakan cara standar untuk menghubungkan model AI ke berbagai sumber data dan alat.

## Tujuan Pembelajaran

Pada akhir pelajaran ini, Anda akan dapat:

- Menyiapkan lingkungan pengembangan untuk MCP dalam C#, Java, Python, TypeScript, dan JavaScript
- Membangun dan menerapkan server MCP dasar dengan fitur kustom (sumber daya, prompt, dan alat)
- Membuat aplikasi host yang terhubung ke server MCP
- Menguji dan memperbaiki implementasi MCP
- Memahami tantangan pengaturan umum dan solusinya
- Menghubungkan implementasi MCP Anda ke layanan LLM populer

## Menyiapkan Lingkungan MCP Anda

Sebelum Anda mulai bekerja dengan MCP, penting untuk mempersiapkan lingkungan pengembangan Anda dan memahami alur kerja dasar. Bagian ini akan memandu Anda melalui langkah-langkah awal pengaturan untuk memastikan awal yang lancar dengan MCP.

### Prasyarat

Sebelum terjun ke pengembangan MCP, pastikan Anda memiliki:

- **Lingkungan Pengembangan**: Untuk bahasa pilihan Anda (C#, Java, Python, TypeScript, atau JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, atau editor kode modern lainnya
- **Pengelola Paket**: NuGet, Maven/Gradle, pip, atau npm/yarn
- **API Keys**: Untuk layanan AI yang Anda rencanakan untuk digunakan dalam aplikasi host Anda


### SDK Resmi

Dalam bab-bab mendatang Anda akan melihat solusi yang dibangun menggunakan Python, TypeScript, Java, dan .NET. Berikut adalah semua SDK resmi yang didukung.

MCP menyediakan SDK resmi untuk berbagai bahasa:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Dikelola bekerja sama dengan Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Dikelola bekerja sama dengan Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Implementasi resmi TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Implementasi resmi Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Implementasi resmi Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Dikelola bekerja sama dengan Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Implementasi resmi Rust

## Poin Penting

- Menyiapkan lingkungan pengembangan MCP mudah dilakukan dengan SDK khusus bahasa
- Membangun server MCP melibatkan pembuatan dan mendaftarkan alat dengan skema yang jelas
- Klien MCP terhubung ke server dan model untuk memanfaatkan kemampuan yang diperluas
- Pengujian dan debugging sangat penting untuk implementasi MCP yang andal
- Opsi penerapan berkisar dari pengembangan lokal hingga solusi berbasis cloud

## Berlatih

Kami memiliki serangkaian contoh yang melengkapi latihan yang akan Anda lihat di semua bab dalam bagian ini. Selain itu, setiap bab juga memiliki latihan dan tugasnya sendiri

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Sumber Daya Tambahan

- [Repositori GitHub MCP](https://github.com/microsoft/mcp-for-beginners)

## Selanjutnya

Selanjutnya: [Membuat Server MCP pertama Anda](/03-GettingStarted/01-first-server/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan penerjemah AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk mencapai akurasi, harap disadari bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang berwenang. Untuk informasi penting, disarankan untuk menggunakan terjemahan manusia profesional. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.