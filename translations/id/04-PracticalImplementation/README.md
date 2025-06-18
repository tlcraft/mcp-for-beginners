<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T09:22:05+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "id"
}
-->
# Implementasi Praktis

Implementasi praktis adalah saat kekuatan Model Context Protocol (MCP) menjadi nyata. Meskipun memahami teori dan arsitektur di balik MCP penting, nilai sebenarnya muncul ketika Anda menerapkan konsep-konsep ini untuk membangun, menguji, dan menerapkan solusi yang menyelesaikan masalah dunia nyata. Bab ini menjembatani kesenjangan antara pengetahuan konseptual dan pengembangan langsung, membimbing Anda melalui proses mewujudkan aplikasi berbasis MCP.

Apakah Anda mengembangkan asisten cerdas, mengintegrasikan AI ke dalam alur kerja bisnis, atau membangun alat khusus untuk pemrosesan data, MCP menyediakan fondasi yang fleksibel. Desainnya yang tidak bergantung pada bahasa dan SDK resmi untuk bahasa pemrograman populer membuatnya dapat diakses oleh beragam pengembang. Dengan memanfaatkan SDK ini, Anda dapat dengan cepat membuat prototipe, mengulang, dan mengembangkan solusi Anda di berbagai platform dan lingkungan.

Di bagian-bagian berikut, Anda akan menemukan contoh praktis, kode sampel, dan strategi penerapan yang menunjukkan cara mengimplementasikan MCP dalam C#, Java, TypeScript, JavaScript, dan Python. Anda juga akan belajar cara melakukan debug dan pengujian server MCP, mengelola API, serta menerapkan solusi ke cloud menggunakan Azure. Sumber daya praktis ini dirancang untuk mempercepat pembelajaran Anda dan membantu Anda membangun aplikasi MCP yang kokoh dan siap produksi dengan percaya diri.

## Gambaran Umum

Pelajaran ini berfokus pada aspek praktis implementasi MCP di berbagai bahasa pemrograman. Kita akan mengeksplorasi cara menggunakan SDK MCP di C#, Java, TypeScript, JavaScript, dan Python untuk membangun aplikasi yang tangguh, melakukan debug dan pengujian server MCP, serta membuat sumber daya, prompt, dan alat yang dapat digunakan kembali.

## Tujuan Pembelajaran

Pada akhir pelajaran ini, Anda akan mampu:
- Mengimplementasikan solusi MCP menggunakan SDK resmi dalam berbagai bahasa pemrograman
- Melakukan debug dan pengujian server MCP secara sistematis
- Membuat dan menggunakan fitur server (Resources, Prompts, dan Tools)
- Merancang alur kerja MCP yang efektif untuk tugas-tugas kompleks
- Mengoptimalkan implementasi MCP untuk kinerja dan keandalan

## Sumber SDK Resmi

Model Context Protocol menyediakan SDK resmi untuk beberapa bahasa:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Bekerja dengan MCP SDK

Bagian ini menyediakan contoh praktis implementasi MCP di berbagai bahasa pemrograman. Anda dapat menemukan kode sampel di direktori `samples` yang diorganisir berdasarkan bahasa.

### Sampel yang Tersedia

Repositori ini mencakup [implementasi sampel](../../../04-PracticalImplementation/samples) dalam bahasa-bahasa berikut:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Setiap sampel menunjukkan konsep utama MCP dan pola implementasi untuk bahasa dan ekosistem tertentu tersebut.

## Fitur Utama Server

Server MCP dapat mengimplementasikan kombinasi fitur berikut:

### Resources  
Resources menyediakan konteks dan data yang digunakan oleh pengguna atau model AI:  
- Repositori dokumen  
- Basis pengetahuan  
- Sumber data terstruktur  
- Sistem berkas  

### Prompts  
Prompts adalah pesan dan alur kerja yang disusun dalam template untuk pengguna:  
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

Repositori SDK resmi C# berisi beberapa contoh implementasi yang menunjukkan berbagai aspek MCP:

- **Basic MCP Client**: Contoh sederhana yang menunjukkan cara membuat klien MCP dan memanggil tools  
- **Basic MCP Server**: Implementasi server minimal dengan pendaftaran tool dasar  
- **Advanced MCP Server**: Server lengkap dengan pendaftaran tool, autentikasi, dan penanganan error  
- **Integrasi ASP.NET**: Contoh integrasi dengan ASP.NET Core  
- **Pola Implementasi Tool**: Berbagai pola untuk mengimplementasikan tool dengan tingkat kompleksitas berbeda  

SDK MCP C# masih dalam tahap preview dan API dapat berubah. Kami akan terus memperbarui blog ini seiring evolusi SDK.

### Fitur Utama  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Membangun [Server MCP pertama Anda](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Untuk contoh implementasi C# lengkap, kunjungi [repositori sampel SDK C# resmi](https://github.com/modelcontextprotocol/csharp-sdk)

## Contoh Implementasi: Java

SDK Java menawarkan opsi implementasi MCP yang kuat dengan fitur kelas enterprise.

### Fitur Utama

- Integrasi Spring Framework  
- Tipe data yang kuat  
- Dukungan pemrograman reaktif  
- Penanganan error yang komprehensif  

Untuk contoh implementasi Java lengkap, lihat [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) di direktori sampel.

## Contoh Implementasi: JavaScript

SDK JavaScript menyediakan pendekatan ringan dan fleksibel untuk implementasi MCP.

### Fitur Utama

- Dukungan Node.js dan browser  
- API berbasis Promise  
- Integrasi mudah dengan Express dan framework lainnya  
- Dukungan WebSocket untuk streaming  

Untuk contoh implementasi JavaScript lengkap, lihat [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) di direktori sampel.

## Contoh Implementasi: Python

SDK Python menawarkan pendekatan Pythonic untuk implementasi MCP dengan integrasi framework ML yang sangat baik.

### Fitur Utama

- Dukungan async/await dengan asyncio  
- Integrasi Flask dan FastAPI  
- Pendaftaran tool yang sederhana  
- Integrasi native dengan pustaka ML populer  

Untuk contoh implementasi Python lengkap, lihat [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) di direktori sampel.

## Manajemen API

Azure API Management adalah solusi yang sangat baik untuk mengamankan Server MCP. Ide dasarnya adalah menempatkan instance Azure API Management di depan Server MCP Anda dan membiarkannya menangani fitur-fitur yang mungkin Anda butuhkan seperti:

- pembatasan kecepatan (rate limiting)  
- manajemen token  
- pemantauan  
- load balancing  
- keamanan  

### Contoh Azure

Berikut adalah Contoh Azure yang melakukan hal tersebut, yaitu [membuat Server MCP dan mengamankannya dengan Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Lihat bagaimana alur otorisasi berlangsung pada gambar di bawah:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

Pada gambar tersebut, terjadi hal-hal berikut:

- Autentikasi/Otorisasi dilakukan menggunakan Microsoft Entra.  
- Azure API Management bertindak sebagai gateway dan menggunakan kebijakan untuk mengarahkan serta mengelola trafik.  
- Azure Monitor mencatat semua permintaan untuk analisis lebih lanjut.  

#### Alur Otorisasi

Mari kita lihat alur otorisasi lebih detail:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Spesifikasi otorisasi MCP

Pelajari lebih lanjut tentang [spesifikasi Otorisasi MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Menerapkan Remote MCP Server ke Azure

Mari kita coba menerapkan contoh yang disebutkan sebelumnya:

1. Clone repositori

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Daftarkan `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` setelah beberapa saat untuk memeriksa apakah pendaftaran sudah selesai.

3. Jalankan perintah [azd](https://aka.ms/azd) ini untuk menyediakan layanan api management, function app (dengan kode) dan semua sumber daya Azure lain yang diperlukan

    ```shell
    azd up
    ```

    Perintah ini akan menerapkan semua sumber daya cloud di Azure

### Menguji server Anda dengan MCP Inspector

1. Di **jendela terminal baru**, instal dan jalankan MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Anda akan melihat antarmuka seperti ini:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.id.png)

2. CTRL klik untuk membuka aplikasi web MCP Inspector dari URL yang ditampilkan oleh aplikasi (misalnya http://127.0.0.1:6274/#resources)  
3. Atur tipe transportasi ke `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` dan **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Daftar Tools**. Klik pada sebuah tool dan **Run Tool**.

Jika semua langkah berhasil, Anda sekarang terhubung ke server MCP dan berhasil memanggil sebuah tool.

## Server MCP untuk Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Sekumpulan repositori ini adalah template quickstart untuk membangun dan menerapkan server MCP (Model Context Protocol) remote kustom menggunakan Azure Functions dengan Python, C# .NET, atau Node/TypeScript.

Sampel ini menyediakan solusi lengkap yang memungkinkan pengembang untuk:

- Membangun dan menjalankan secara lokal: Mengembangkan dan melakukan debug server MCP di mesin lokal  
- Menerapkan ke Azure: Mudah menerapkan ke cloud dengan perintah azd up sederhana  
- Terhubung dari klien: Terhubung ke server MCP dari berbagai klien termasuk mode agen Copilot di VS Code dan alat MCP Inspector  

### Fitur Utama:

- Keamanan sejak desain: Server MCP diamankan menggunakan kunci dan HTTPS  
- Opsi autentikasi: Mendukung OAuth dengan autentikasi bawaan dan/atau API Management  
- Isolasi jaringan: Memungkinkan isolasi jaringan menggunakan Azure Virtual Networks (VNET)  
- Arsitektur tanpa server: Memanfaatkan Azure Functions untuk eksekusi yang skalabel dan berbasis event  
- Pengembangan lokal: Dukungan lengkap untuk pengembangan dan debugging lokal  
- Penerapan sederhana: Proses penerapan yang mudah ke Azure  

Repositori ini mencakup semua file konfigurasi, kode sumber, dan definisi infrastruktur yang diperlukan untuk memulai dengan cepat implementasi server MCP yang siap produksi.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Contoh implementasi MCP menggunakan Azure Functions dengan Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Contoh implementasi MCP menggunakan Azure Functions dengan C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Contoh implementasi MCP menggunakan Azure Functions dengan Node/TypeScript.

## Poin Penting

- SDK MCP menyediakan alat khusus bahasa untuk mengimplementasikan solusi MCP yang tangguh  
- Proses debugging dan pengujian sangat penting untuk aplikasi MCP yang dapat diandalkan  
- Template prompt yang dapat digunakan ulang memungkinkan interaksi AI yang konsisten  
- Alur kerja yang dirancang dengan baik dapat mengatur tugas kompleks menggunakan berbagai tools  
- Mengimplementasikan solusi MCP membutuhkan pertimbangan keamanan, kinerja, dan penanganan error  

## Latihan

Rancang alur kerja MCP praktis yang menangani masalah dunia nyata di bidang Anda:

1. Identifikasi 3-4 tools yang berguna untuk menyelesaikan masalah ini  
2. Buat diagram alur kerja yang menunjukkan bagaimana tools ini saling berinteraksi  
3. Implementasikan versi dasar salah satu tools menggunakan bahasa pilihan Anda  
4. Buat template prompt yang membantu model menggunakan tool Anda secara efektif  

## Sumber Daya Tambahan


---

Selanjutnya: [Topik Lanjutan](../05-AdvancedTopics/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk memberikan terjemahan yang akurat, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sah. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.