<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "61a160248efabe92b09d7b08293d17db",
  "translation_date": "2025-08-18T17:28:46+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "id"
}
-->
# MCP dalam Aksi: Studi Kasus Dunia Nyata

[![MCP dalam Aksi: Studi Kasus Dunia Nyata](../../../translated_images/10.3262cc80b4de5071fde8ba74c5c5d6738a0a9f398dcc0423f0210f632e2238b8.id.png)](https://youtu.be/IxshWb2Az5w)

_(Klik gambar di atas untuk menonton video pelajaran ini)_

Model Context Protocol (MCP) sedang mengubah cara aplikasi AI berinteraksi dengan data, alat, dan layanan. Bagian ini menyajikan studi kasus dunia nyata yang menunjukkan penerapan praktis MCP dalam berbagai skenario perusahaan.

## Ikhtisar

Bagian ini menampilkan contoh konkret implementasi MCP, menyoroti bagaimana organisasi memanfaatkan protokol ini untuk menyelesaikan tantangan bisnis yang kompleks. Dengan mempelajari studi kasus ini, Anda akan mendapatkan wawasan tentang fleksibilitas, skalabilitas, dan manfaat praktis MCP dalam skenario dunia nyata.

## Tujuan Pembelajaran Utama

Dengan mempelajari studi kasus ini, Anda akan:

- Memahami bagaimana MCP dapat diterapkan untuk menyelesaikan masalah bisnis tertentu
- Mempelajari berbagai pola integrasi dan pendekatan arsitektur
- Mengenali praktik terbaik untuk mengimplementasikan MCP di lingkungan perusahaan
- Mendapatkan wawasan tentang tantangan dan solusi yang dihadapi dalam implementasi dunia nyata
- Mengidentifikasi peluang untuk menerapkan pola serupa dalam proyek Anda sendiri

## Studi Kasus Unggulan

### 1. [Azure AI Travel Agents – Implementasi Referensi](./travelagentsample.md)

Studi kasus ini membahas solusi referensi komprehensif dari Microsoft yang menunjukkan cara membangun aplikasi perencanaan perjalanan berbasis AI multi-agen menggunakan MCP, Azure OpenAI, dan Azure AI Search. Proyek ini menampilkan:

- Orkestrasi multi-agen melalui MCP
- Integrasi data perusahaan dengan Azure AI Search
- Arsitektur yang aman dan skalabel menggunakan layanan Azure
- Alat yang dapat diperluas dengan komponen MCP yang dapat digunakan kembali
- Pengalaman pengguna percakapan yang didukung oleh Azure OpenAI

Detail arsitektur dan implementasi memberikan wawasan berharga tentang cara membangun sistem multi-agen yang kompleks dengan MCP sebagai lapisan koordinasi.

### 2. [Memperbarui Item Azure DevOps dari Data YouTube](./UpdateADOItemsFromYT.md)

Studi kasus ini menunjukkan penerapan praktis MCP untuk mengotomatisasi proses alur kerja. Ini menunjukkan bagaimana alat MCP dapat digunakan untuk:

- Mengekstrak data dari platform online (YouTube)
- Memperbarui item kerja di sistem Azure DevOps
- Membuat alur kerja otomatis yang dapat diulang
- Mengintegrasikan data di berbagai sistem

Contoh ini menggambarkan bagaimana bahkan implementasi MCP yang relatif sederhana dapat memberikan peningkatan efisiensi yang signifikan dengan mengotomatisasi tugas rutin dan meningkatkan konsistensi data di seluruh sistem.

### 3. [Pengambilan Dokumentasi Real-Time dengan MCP](./docs-mcp/README.md)

Studi kasus ini memandu Anda melalui penghubungan klien konsol Python ke server Model Context Protocol (MCP) untuk mengambil dan mencatat dokumentasi Microsoft yang kontekstual secara real-time. Anda akan belajar cara:

- Menghubungkan ke server MCP menggunakan klien Python dan MCP SDK resmi
- Menggunakan klien HTTP streaming untuk pengambilan data real-time yang efisien
- Memanggil alat dokumentasi di server dan mencatat respons langsung ke konsol
- Mengintegrasikan dokumentasi Microsoft terkini ke dalam alur kerja Anda tanpa meninggalkan terminal

Bab ini mencakup tugas langsung, contoh kode kerja minimal, dan tautan ke sumber daya tambahan untuk pembelajaran lebih mendalam. Lihat panduan lengkap dan kode di bab yang ditautkan untuk memahami bagaimana MCP dapat mengubah akses dokumentasi dan produktivitas pengembang di lingkungan berbasis konsol.

### 4. [Aplikasi Web Generator Rencana Studi Interaktif dengan MCP](./docs-mcp/README.md)

Studi kasus ini menunjukkan cara membangun aplikasi web interaktif menggunakan Chainlit dan Model Context Protocol (MCP) untuk menghasilkan rencana studi yang dipersonalisasi untuk topik apa pun. Pengguna dapat menentukan subjek (seperti "sertifikasi AI-900") dan durasi studi (misalnya, 8 minggu), dan aplikasi akan memberikan rincian konten yang direkomendasikan minggu demi minggu. Chainlit memungkinkan antarmuka obrolan percakapan, membuat pengalaman menjadi menarik dan adaptif.

- Aplikasi web percakapan yang didukung oleh Chainlit
- Prompt yang digerakkan pengguna untuk topik dan durasi
- Rekomendasi konten minggu demi minggu menggunakan MCP
- Respons adaptif real-time dalam antarmuka obrolan

Proyek ini menggambarkan bagaimana AI percakapan dan MCP dapat digabungkan untuk menciptakan alat pendidikan yang dinamis dan digerakkan pengguna di lingkungan web modern.

### 5. [Dokumentasi Dalam Editor dengan Server MCP di VS Code](./docs-mcp/README.md)

Studi kasus ini menunjukkan bagaimana Anda dapat membawa Microsoft Learn Docs langsung ke lingkungan VS Code Anda menggunakan server MCP—tidak perlu lagi beralih tab browser! Anda akan melihat cara:

- Mencari dan membaca dokumen secara instan di dalam VS Code menggunakan panel MCP atau palet perintah
- Merujuk dokumentasi dan menyisipkan tautan langsung ke file README atau markdown kursus Anda
- Menggunakan GitHub Copilot dan MCP bersama-sama untuk alur kerja dokumentasi dan kode yang didukung AI
- Memvalidasi dan meningkatkan dokumentasi Anda dengan umpan balik real-time dan akurasi yang bersumber dari Microsoft
- Mengintegrasikan MCP dengan alur kerja GitHub untuk validasi dokumentasi berkelanjutan

Implementasi ini mencakup:

- Contoh konfigurasi `.vscode/mcp.json` untuk pengaturan yang mudah
- Panduan berbasis tangkapan layar tentang pengalaman dalam editor
- Tips untuk menggabungkan Copilot dan MCP untuk produktivitas maksimal

Skenario ini ideal untuk penulis kursus, penulis dokumentasi, dan pengembang yang ingin tetap fokus di editor mereka sambil bekerja dengan dokumen, Copilot, dan alat validasi—semuanya didukung oleh MCP.

### 6. [Pembuatan Server MCP APIM](./apimsample.md)

Studi kasus ini menyediakan panduan langkah demi langkah tentang cara membuat server MCP menggunakan Azure API Management (APIM). Ini mencakup:

- Menyiapkan server MCP di Azure API Management
- Mengekspos operasi API sebagai alat MCP
- Mengonfigurasi kebijakan untuk pembatasan tingkat dan keamanan
- Menguji server MCP menggunakan Visual Studio Code dan GitHub Copilot

Contoh ini menggambarkan bagaimana memanfaatkan kemampuan Azure untuk membuat server MCP yang kuat yang dapat digunakan dalam berbagai aplikasi, meningkatkan integrasi sistem AI dengan API perusahaan.

## Kesimpulan

Studi kasus ini menyoroti fleksibilitas dan penerapan praktis Model Context Protocol dalam skenario dunia nyata. Dari sistem multi-agen yang kompleks hingga alur kerja otomatis yang terfokus, MCP menyediakan cara standar untuk menghubungkan sistem AI dengan alat dan data yang mereka butuhkan untuk memberikan nilai.

Dengan mempelajari implementasi ini, Anda dapat memperoleh wawasan tentang pola arsitektur, strategi implementasi, dan praktik terbaik yang dapat diterapkan pada proyek MCP Anda sendiri. Contoh-contoh ini menunjukkan bahwa MCP bukan hanya kerangka kerja teoretis tetapi solusi praktis untuk tantangan bisnis nyata.

## Sumber Daya Tambahan

- [Repositori GitHub Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Alat MCP Azure DevOps](https://github.com/microsoft/azure-devops-mcp)
- [Alat MCP Playwright](https://github.com/microsoft/playwright-mcp)
- [Server MCP Microsoft Docs](https://github.com/MicrosoftDocs/mcp)
- [Contoh Komunitas MCP](https://github.com/microsoft/mcp)

Selanjutnya: Lab Praktis [Menyederhanakan Alur Kerja AI: Membangun Server MCP dengan AI Toolkit](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk memberikan hasil yang akurat, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang berwenang. Untuk informasi yang bersifat kritis, disarankan menggunakan jasa terjemahan manusia profesional. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.