<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T13:57:28+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "id"
}
-->
# Implementasi Praktis

Implementasi praktis adalah tempat kekuatan Model Context Protocol (MCP) menjadi nyata. Meskipun memahami teori dan arsitektur di balik MCP itu penting, nilai sebenarnya muncul ketika Anda menerapkan konsep-konsep ini untuk membangun, menguji, dan menerapkan solusi yang menyelesaikan masalah dunia nyata. Bab ini menjembatani kesenjangan antara pengetahuan konseptual dan pengembangan langsung, membimbing Anda melalui proses menghidupkan aplikasi berbasis MCP.

Apakah Anda mengembangkan asisten cerdas, mengintegrasikan AI ke dalam alur kerja bisnis, atau membangun alat khusus untuk pemrosesan data, MCP menyediakan fondasi yang fleksibel. Desainnya yang tidak tergantung bahasa dan SDK resmi untuk bahasa pemrograman populer membuatnya dapat diakses oleh berbagai pengembang. Dengan memanfaatkan SDK ini, Anda dapat dengan cepat membuat prototipe, iterasi, dan skalabilitas solusi Anda di berbagai platform dan lingkungan.

Di bagian berikut, Anda akan menemukan contoh praktis, kode sampel, dan strategi penerapan yang menunjukkan cara mengimplementasikan MCP dalam C#, Java, TypeScript, JavaScript, dan Python. Anda juga akan belajar cara debug dan menguji server MCP Anda, mengelola API, dan menerapkan solusi ke cloud menggunakan Azure. Sumber daya praktis ini dirancang untuk mempercepat pembelajaran Anda dan membantu Anda membangun aplikasi MCP yang kuat dan siap produksi dengan percaya diri.

## Gambaran Umum

Pelajaran ini berfokus pada aspek praktis implementasi MCP di berbagai bahasa pemrograman. Kami akan mengeksplorasi cara menggunakan SDK MCP dalam C#, Java, TypeScript, JavaScript, dan Python untuk membangun aplikasi yang kuat, debug dan menguji server MCP, dan membuat sumber daya yang dapat digunakan kembali, prompt, dan alat.

## Tujuan Pembelajaran

Pada akhir pelajaran ini, Anda akan dapat:
- Mengimplementasikan solusi MCP menggunakan SDK resmi dalam berbagai bahasa pemrograman
- Debug dan menguji server MCP secara sistematis
- Membuat dan menggunakan fitur server (Sumber Daya, Prompt, dan Alat)
- Merancang alur kerja MCP yang efektif untuk tugas yang kompleks
- Mengoptimalkan implementasi MCP untuk kinerja dan keandalan

## Sumber Daya SDK Resmi

Model Context Protocol menawarkan SDK resmi untuk beberapa bahasa:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Bekerja dengan SDK MCP

Bagian ini menyediakan contoh praktis implementasi MCP di berbagai bahasa pemrograman. Anda dapat menemukan kode sampel di direktori `samples` yang diorganisir berdasarkan bahasa.

### Sampel Tersedia

Repositori ini mencakup implementasi sampel dalam bahasa berikut:

- C#
- Java
- TypeScript
- JavaScript
- Python

Setiap sampel menunjukkan konsep utama MCP dan pola implementasi untuk bahasa dan ekosistem tertentu.

## Fitur Server Inti

Server MCP dapat mengimplementasikan kombinasi fitur berikut:

### Sumber Daya
Sumber daya menyediakan konteks dan data untuk digunakan oleh pengguna atau model AI:
- Repositori dokumen
- Basis pengetahuan
- Sumber data terstruktur
- Sistem file

### Prompt
Prompt adalah pesan dan alur kerja yang sudah di template untuk pengguna:
- Template percakapan yang telah ditentukan sebelumnya
- Pola interaksi yang dipandu
- Struktur dialog khusus

### Alat
Alat adalah fungsi untuk dieksekusi oleh model AI:
- Utilitas pemrosesan data
- Integrasi API eksternal
- Kemampuan komputasi
- Fungsi pencarian

## Implementasi Sampel: C#

Repositori SDK C# resmi berisi beberapa implementasi sampel yang menunjukkan berbagai aspek MCP:

- **Klien MCP Dasar**: Contoh sederhana yang menunjukkan cara membuat klien MCP dan memanggil alat
- **Server MCP Dasar**: Implementasi server minimal dengan pendaftaran alat dasar
- **Server MCP Lanjutan**: Server lengkap dengan pendaftaran alat, autentikasi, dan penanganan kesalahan
- **Integrasi ASP.NET**: Contoh yang menunjukkan integrasi dengan ASP.NET Core
- **Pola Implementasi Alat**: Berbagai pola untuk mengimplementasikan alat dengan tingkat kompleksitas yang berbeda

SDK MCP C# sedang dalam pratinjau dan API dapat berubah. Kami akan terus memperbarui blog ini seiring perkembangan SDK.

### Fitur Utama 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Membangun [Server MCP pertama Anda](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Untuk sampel implementasi C# lengkap, kunjungi [repositori sampel SDK C# resmi](https://github.com/modelcontextprotocol/csharp-sdk)

## Implementasi Sampel: Implementasi Java

SDK Java menawarkan opsi implementasi MCP yang kuat dengan fitur kelas perusahaan.

### Fitur Utama

- Integrasi Kerangka Kerja Spring
- Keamanan tipe yang kuat
- Dukungan pemrograman reaktif
- Penanganan kesalahan yang komprehensif

Untuk sampel implementasi Java lengkap, lihat [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) di direktori sampel.

## Implementasi Sampel: Implementasi JavaScript

SDK JavaScript menyediakan pendekatan yang ringan dan fleksibel untuk implementasi MCP.

### Fitur Utama

- Dukungan Node.js dan browser
- API berbasis janji
- Integrasi mudah dengan Express dan kerangka kerja lainnya
- Dukungan WebSocket untuk streaming

Untuk sampel implementasi JavaScript lengkap, lihat [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) di direktori sampel.

## Implementasi Sampel: Implementasi Python

SDK Python menawarkan pendekatan Pythonic untuk implementasi MCP dengan integrasi kerangka kerja ML yang sangat baik.

### Fitur Utama

- Dukungan async/await dengan asyncio
- Integrasi Flask dan FastAPI
- Pendaftaran alat yang sederhana
- Integrasi native dengan pustaka ML populer

Untuk sampel implementasi Python lengkap, lihat [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) di direktori sampel.

## Manajemen API

Azure API Management adalah jawaban yang bagus untuk bagaimana kita dapat mengamankan server MCP. Ide utamanya adalah menempatkan instance Azure API Management di depan server MCP Anda dan membiarkannya menangani fitur-fitur yang kemungkinan Anda inginkan seperti:

- pembatasan tingkat
- manajemen token
- pemantauan
- penyeimbangan beban
- keamanan

### Sampel Azure

Berikut adalah sampel Azure yang melakukan hal tersebut, yaitu [membuat server MCP dan mengamankannya dengan Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Lihat bagaimana alur otorisasi terjadi pada gambar di bawah ini:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

Dalam gambar di atas, yang terjadi adalah:

- Autentikasi/Otorisasi terjadi menggunakan Microsoft Entra.
- Azure API Management bertindak sebagai gateway dan menggunakan kebijakan untuk mengarahkan dan mengelola lalu lintas.
- Azure Monitor mencatat semua permintaan untuk analisis lebih lanjut.

#### Alur Otorisasi

Mari kita lihat alur otorisasi lebih detail:

![Diagram Urutan](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Spesifikasi otorisasi MCP

Pelajari lebih lanjut tentang [spesifikasi Otorisasi MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Menerapkan Server MCP Jarak Jauh ke Azure

Mari kita lihat apakah kita bisa menerapkan sampel yang kita sebutkan sebelumnya:

1. Clone repo

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Daftarkan `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` setelah beberapa waktu untuk memeriksa apakah pendaftaran selesai.

2. Jalankan perintah [azd](https://aka.ms/azd) ini untuk menyediakan layanan manajemen api, aplikasi fungsi (dengan kode) dan semua sumber daya Azure yang diperlukan lainnya

    ```shell
    azd up
    ```

    Perintah ini harus menerapkan semua sumber daya cloud di Azure

### Menguji server Anda dengan MCP Inspector

1. Di **jendela terminal baru**, instal dan jalankan MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Anda akan melihat antarmuka yang mirip dengan:

    ![Connect to Node inspector](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.id.png)

1. Klik CTRL untuk memuat aplikasi web MCP Inspector dari URL yang ditampilkan oleh aplikasi (misalnya http://127.0.0.1:6274/#resources)
1. Atur jenis transport ke `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` dan **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Daftar Alat**. Klik pada alat dan **Jalankan Alat**.

Jika semua langkah berhasil, Anda sekarang harus terhubung ke server MCP dan Anda telah berhasil memanggil alat.

## Server MCP untuk Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Set repositori ini adalah template mulai cepat untuk membangun dan menerapkan server MCP (Model Context Protocol) jarak jauh menggunakan Azure Functions dengan Python, C# .NET atau Node/TypeScript.

Sampel ini menyediakan solusi lengkap yang memungkinkan pengembang untuk:

- Membangun dan menjalankan secara lokal: Mengembangkan dan debug server MCP di mesin lokal
- Menerapkan ke Azure: Mudah menerapkan ke cloud dengan perintah azd up sederhana
- Terhubung dari klien: Terhubung ke server MCP dari berbagai klien termasuk mode agen Copilot VS Code dan alat MCP Inspector

### Fitur Utama:

- Keamanan menurut desain: Server MCP diamankan menggunakan kunci dan HTTPS
- Opsi autentikasi: Mendukung OAuth menggunakan autentikasi bawaan dan/atau Manajemen API
- Isolasi jaringan: Memungkinkan isolasi jaringan menggunakan Jaringan Virtual Azure (VNET)
- Arsitektur tanpa server: Memanfaatkan Azure Functions untuk eksekusi yang skalabel dan berbasis acara
- Pengembangan lokal: Dukungan pengembangan dan debugging lokal yang komprehensif
- Penerapan sederhana: Proses penerapan yang efisien ke Azure

Repositori ini mencakup semua file konfigurasi yang diperlukan, kode sumber, dan definisi infrastruktur untuk memulai implementasi server MCP yang siap produksi dengan cepat.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Implementasi sampel MCP menggunakan Azure Functions dengan Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Implementasi sampel MCP menggunakan Azure Functions dengan C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Implementasi sampel MCP menggunakan Azure Functions dengan Node/TypeScript.

## Poin Penting

- SDK MCP menyediakan alat khusus bahasa untuk mengimplementasikan solusi MCP yang kuat
- Proses debugging dan pengujian sangat penting untuk aplikasi MCP yang andal
- Template prompt yang dapat digunakan kembali memungkinkan interaksi AI yang konsisten
- Alur kerja yang dirancang dengan baik dapat mengatur tugas yang kompleks menggunakan beberapa alat
- Mengimplementasikan solusi MCP memerlukan pertimbangan keamanan, kinerja, dan penanganan kesalahan

## Latihan

Rancang alur kerja MCP praktis yang mengatasi masalah dunia nyata di domain Anda:

1. Identifikasi 3-4 alat yang akan berguna untuk menyelesaikan masalah ini
2. Buat diagram alur kerja yang menunjukkan bagaimana alat-alat ini berinteraksi
3. Implementasikan versi dasar dari salah satu alat menggunakan bahasa pilihan Anda
4. Buat template prompt yang akan membantu model menggunakan alat Anda secara efektif

## Sumber Daya Tambahan

---

Berikutnya: [Topik Lanjutan](../05-AdvancedTopics/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang berwenang. Untuk informasi penting, disarankan untuk menggunakan terjemahan manusia profesional. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.