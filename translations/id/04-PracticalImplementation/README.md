<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:21:07+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "id"
}
-->
# Implementasi Praktis

Implementasi praktis adalah tempat kekuatan Model Context Protocol (MCP) menjadi nyata. Meskipun memahami teori dan arsitektur di balik MCP penting, nilai sebenarnya muncul saat Anda menerapkan konsep-konsep ini untuk membangun, menguji, dan menerapkan solusi yang menyelesaikan masalah dunia nyata. Bab ini menjembatani kesenjangan antara pengetahuan konseptual dan pengembangan langsung, membimbing Anda melalui proses menghidupkan aplikasi berbasis MCP.

Apakah Anda mengembangkan asisten cerdas, mengintegrasikan AI ke dalam alur kerja bisnis, atau membangun alat khusus untuk pemrosesan data, MCP menyediakan fondasi yang fleksibel. Desainnya yang tidak bergantung pada bahasa dan SDK resmi untuk bahasa pemrograman populer membuatnya dapat diakses oleh berbagai pengembang. Dengan memanfaatkan SDK ini, Anda dapat dengan cepat membuat prototipe, iterasi, dan mengembangkan solusi Anda di berbagai platform dan lingkungan.

Di bagian berikut, Anda akan menemukan contoh praktis, kode sampel, dan strategi penerapan yang menunjukkan cara mengimplementasikan MCP dalam C#, Java, TypeScript, JavaScript, dan Python. Anda juga akan belajar cara debug dan menguji server MCP Anda, mengelola API, dan menerapkan solusi ke cloud menggunakan Azure. Sumber daya langsung ini dirancang untuk mempercepat pembelajaran Anda dan membantu Anda membangun aplikasi MCP yang kuat dan siap produksi dengan percaya diri.

## Ikhtisar

Pelajaran ini berfokus pada aspek praktis implementasi MCP di berbagai bahasa pemrograman. Kita akan mengeksplorasi cara menggunakan SDK MCP di C#, Java, TypeScript, JavaScript, dan Python untuk membangun aplikasi yang tangguh, debug dan uji server MCP, serta membuat sumber daya, prompt, dan alat yang dapat digunakan ulang.

## Tujuan Pembelajaran

Pada akhir pelajaran ini, Anda akan dapat:
- Mengimplementasikan solusi MCP menggunakan SDK resmi di berbagai bahasa pemrograman
- Debug dan uji server MCP secara sistematis
- Membuat dan menggunakan fitur server (Resources, Prompts, dan Tools)
- Merancang alur kerja MCP yang efektif untuk tugas kompleks
- Mengoptimalkan implementasi MCP untuk performa dan keandalan

## Sumber Daya SDK Resmi

Model Context Protocol menawarkan SDK resmi untuk berbagai bahasa:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Bekerja dengan SDK MCP

Bagian ini menyediakan contoh praktis implementasi MCP di berbagai bahasa pemrograman. Anda dapat menemukan kode sampel di direktori `samples` yang diorganisasi berdasarkan bahasa.

### Sampel yang Tersedia

Repositori ini mencakup implementasi sampel dalam bahasa berikut:

- C#
- Java
- TypeScript
- JavaScript
- Python

Setiap sampel menunjukkan konsep utama MCP dan pola implementasi untuk bahasa dan ekosistem tersebut.

## Fitur Inti Server

Server MCP dapat mengimplementasikan kombinasi fitur berikut:

### Resources
Resources menyediakan konteks dan data untuk digunakan oleh pengguna atau model AI:
- Repositori dokumen
- Basis pengetahuan
- Sumber data terstruktur
- Sistem berkas

### Prompts
Prompts adalah pesan dan alur kerja yang sudah dipola untuk pengguna:
- Template percakapan yang telah ditentukan
- Pola interaksi terpandu
- Struktur dialog khusus

### Tools
Tools adalah fungsi yang dapat dijalankan oleh model AI:
- Utilitas pemrosesan data
- Integrasi API eksternal
- Kapabilitas komputasi
- Fungsi pencarian

## Contoh Implementasi: C#

Repositori SDK C# resmi berisi beberapa contoh implementasi yang menunjukkan berbagai aspek MCP:

- **Basic MCP Client**: Contoh sederhana cara membuat klien MCP dan memanggil tools
- **Basic MCP Server**: Implementasi server minimal dengan pendaftaran tool dasar
- **Advanced MCP Server**: Server lengkap dengan pendaftaran tool, autentikasi, dan penanganan kesalahan
- **Integrasi ASP.NET**: Contoh integrasi dengan ASP.NET Core
- **Pola Implementasi Tools**: Berbagai pola untuk mengimplementasikan tools dengan tingkat kompleksitas berbeda

SDK MCP C# masih dalam pratinjau dan API mungkin berubah. Kami akan terus memperbarui blog ini seiring perkembangan SDK.

### Fitur Utama 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Membangun [MCP Server pertama Anda](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Untuk contoh implementasi C# lengkap, kunjungi [repositori sampel SDK C# resmi](https://github.com/modelcontextprotocol/csharp-sdk)

## Contoh Implementasi: Java

SDK Java menawarkan opsi implementasi MCP yang kuat dengan fitur kelas enterprise.

### Fitur Utama

- Integrasi Spring Framework
- Keamanan tipe yang kuat
- Dukungan pemrograman reaktif
- Penanganan kesalahan yang komprehensif

Untuk contoh implementasi Java lengkap, lihat [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) di direktori sampel.

## Contoh Implementasi: JavaScript

SDK JavaScript menyediakan pendekatan ringan dan fleksibel untuk implementasi MCP.

### Fitur Utama

- Dukungan Node.js dan browser
- API berbasis Promise
- Integrasi mudah dengan Express dan framework lain
- Dukungan WebSocket untuk streaming

Untuk contoh implementasi JavaScript lengkap, lihat [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) di direktori sampel.

## Contoh Implementasi: Python

SDK Python menawarkan pendekatan Pythonik untuk implementasi MCP dengan integrasi framework ML yang sangat baik.

### Fitur Utama

- Dukungan async/await dengan asyncio
- Integrasi Flask dan FastAPI
- Pendaftaran tool yang sederhana
- Integrasi native dengan perpustakaan ML populer

Untuk contoh implementasi Python lengkap, lihat [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) di direktori sampel.

## Manajemen API

Azure API Management adalah solusi yang bagus untuk mengamankan server MCP. Ide dasarnya adalah menempatkan instance Azure API Management di depan server MCP Anda dan membiarkannya menangani fitur-fitur yang kemungkinan Anda butuhkan seperti:

- pembatasan kecepatan
- manajemen token
- pemantauan
- penyeimbangan beban
- keamanan

### Contoh Azure

Berikut adalah contoh Azure yang melakukan hal tersebut, yaitu [membuat MCP Server dan mengamankannya dengan Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Lihat bagaimana alur otorisasi terjadi pada gambar di bawah:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Pada gambar di atas, hal-hal berikut terjadi:

- Autentikasi/Otorisasi dilakukan menggunakan Microsoft Entra.
- Azure API Management bertindak sebagai gateway dan menggunakan kebijakan untuk mengarahkan dan mengelola lalu lintas.
- Azure Monitor mencatat semua permintaan untuk analisis lebih lanjut.

#### Alur Otorisasi

Mari kita lihat alur otorisasi lebih detail:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Spesifikasi otorisasi MCP

Pelajari lebih lanjut tentang [spesifikasi Otorisasi MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Deploy Remote MCP Server ke Azure

Mari kita lihat apakah kita bisa menerapkan contoh yang disebutkan sebelumnya:

1. Clone repo

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Daftarkan `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` setelah beberapa saat untuk memeriksa apakah pendaftaran sudah selesai.

2. Jalankan perintah [azd](https://aka.ms/azd) ini untuk menyediakan layanan manajemen API, function app (dengan kode) dan semua sumber daya Azure lain yang diperlukan

    ```shell
    azd up
    ```

    Perintah ini harus menerapkan semua sumber daya cloud di Azure

### Menguji server Anda dengan MCP Inspector

1. Di **jendela terminal baru**, instal dan jalankan MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Anda akan melihat antarmuka seperti:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.id.png) 

1. Klik CTRL untuk memuat aplikasi web MCP Inspector dari URL yang ditampilkan oleh aplikasi (misalnya http://127.0.0.1:6274/#resources)
1. Atur tipe transport ke `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` dan **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Daftar Tools**. Klik pada sebuah tool dan **Run Tool**.  

Jika semua langkah berhasil, sekarang Anda terhubung ke server MCP dan berhasil memanggil sebuah tool.

## Server MCP untuk Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Set repositori ini adalah template cepat untuk membangun dan menerapkan server remote MCP (Model Context Protocol) kustom menggunakan Azure Functions dengan Python, C# .NET, atau Node/TypeScript.

Sampel ini menyediakan solusi lengkap yang memungkinkan pengembang untuk:

- Membangun dan menjalankan secara lokal: Kembangkan dan debug server MCP di mesin lokal
- Deploy ke Azure: Mudah menerapkan ke cloud dengan perintah azd up sederhana
- Terhubung dari klien: Terhubung ke server MCP dari berbagai klien termasuk mode agen Copilot di VS Code dan alat MCP Inspector

### Fitur Utama:

- Keamanan sejak desain: Server MCP diamankan menggunakan kunci dan HTTPS
- Opsi autentikasi: Mendukung OAuth dengan autentikasi bawaan dan/atau API Management
- Isolasi jaringan: Memungkinkan isolasi jaringan menggunakan Azure Virtual Networks (VNET)
- Arsitektur tanpa server: Memanfaatkan Azure Functions untuk eksekusi yang skalabel dan berbasis event
- Pengembangan lokal: Dukungan pengembangan lokal dan debugging yang lengkap
- Deployment sederhana: Proses deployment yang ramping ke Azure

Repositori ini mencakup semua file konfigurasi, kode sumber, dan definisi infrastruktur yang diperlukan untuk memulai dengan cepat implementasi server MCP yang siap produksi.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Contoh implementasi MCP menggunakan Azure Functions dengan Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Contoh implementasi MCP menggunakan Azure Functions dengan C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Contoh implementasi MCP menggunakan Azure Functions dengan Node/TypeScript.

## Poin Penting

- SDK MCP menyediakan alat spesifik bahasa untuk mengimplementasikan solusi MCP yang tangguh
- Proses debugging dan pengujian sangat penting untuk aplikasi MCP yang andal
- Template prompt yang dapat digunakan ulang memungkinkan interaksi AI yang konsisten
- Alur kerja yang dirancang dengan baik dapat mengatur tugas kompleks menggunakan berbagai tools
- Mengimplementasikan solusi MCP memerlukan pertimbangan keamanan, performa, dan penanganan kesalahan

## Latihan

Rancang alur kerja MCP praktis yang menangani masalah dunia nyata di bidang Anda:

1. Identifikasi 3-4 tools yang akan berguna untuk menyelesaikan masalah ini
2. Buat diagram alur kerja yang menunjukkan bagaimana tools ini berinteraksi
3. Implementasikan versi dasar dari salah satu tools menggunakan bahasa pilihan Anda
4. Buat template prompt yang membantu model menggunakan tool Anda secara efektif

## Sumber Daya Tambahan


---

Selanjutnya: [Topik Lanjutan](../05-AdvancedTopics/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk akurasi, harap diingat bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi yang penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.