<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "873741da08dd6537858d5e14c3a386e1",
  "translation_date": "2025-07-04T18:08:04+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "id"
}
-->
# MCP dalam Aksi: Studi Kasus Dunia Nyata

Model Context Protocol (MCP) mengubah cara aplikasi AI berinteraksi dengan data, alat, dan layanan. Bagian ini menyajikan studi kasus dunia nyata yang menunjukkan penerapan praktis MCP dalam berbagai skenario perusahaan.

## Ikhtisar

Bagian ini menampilkan contoh konkret implementasi MCP, menyoroti bagaimana organisasi memanfaatkan protokol ini untuk menyelesaikan tantangan bisnis yang kompleks. Dengan mempelajari studi kasus ini, Anda akan mendapatkan wawasan tentang fleksibilitas, skalabilitas, dan manfaat praktis MCP dalam skenario dunia nyata.

## Tujuan Pembelajaran Utama

Dengan mengeksplorasi studi kasus ini, Anda akan:

- Memahami bagaimana MCP dapat diterapkan untuk menyelesaikan masalah bisnis tertentu
- Mempelajari berbagai pola integrasi dan pendekatan arsitektur
- Mengenali praktik terbaik dalam mengimplementasikan MCP di lingkungan perusahaan
- Mendapatkan wawasan tentang tantangan dan solusi yang ditemui dalam implementasi dunia nyata
- Mengidentifikasi peluang untuk menerapkan pola serupa dalam proyek Anda sendiri

## Studi Kasus Unggulan

### 1. [Azure AI Travel Agents – Implementasi Referensi](./travelagentsample.md)

Studi kasus ini mengulas solusi referensi komprehensif dari Microsoft yang menunjukkan cara membangun aplikasi perencanaan perjalanan bertenaga AI dengan multi-agent menggunakan MCP, Azure OpenAI, dan Azure AI Search. Proyek ini menampilkan:

- Orkestrasi multi-agent melalui MCP
- Integrasi data perusahaan dengan Azure AI Search
- Arsitektur yang aman dan skalabel menggunakan layanan Azure
- Alat yang dapat diperluas dengan komponen MCP yang dapat digunakan ulang
- Pengalaman pengguna percakapan yang didukung oleh Azure OpenAI

Detail arsitektur dan implementasi memberikan wawasan berharga dalam membangun sistem multi-agent yang kompleks dengan MCP sebagai lapisan koordinasi.

### 2. [Memperbarui Item Azure DevOps dari Data YouTube](./UpdateADOItemsFromYT.md)

Studi kasus ini menunjukkan penerapan praktis MCP untuk mengotomatisasi proses alur kerja. Ini memperlihatkan bagaimana alat MCP dapat digunakan untuk:

- Mengambil data dari platform online (YouTube)
- Memperbarui item kerja di sistem Azure DevOps
- Membuat alur kerja otomatis yang dapat diulang
- Mengintegrasikan data antar sistem yang berbeda

Contoh ini menggambarkan bagaimana implementasi MCP yang relatif sederhana dapat memberikan peningkatan efisiensi signifikan dengan mengotomatisasi tugas rutin dan meningkatkan konsistensi data antar sistem.

### 3. [Pengambilan Dokumentasi Real-Time dengan MCP](./docs-mcp/README.md)

Studi kasus ini memandu Anda menghubungkan klien konsol Python ke server Model Context Protocol (MCP) untuk mengambil dan mencatat dokumentasi Microsoft yang kontekstual dan real-time. Anda akan belajar bagaimana:

- Terhubung ke server MCP menggunakan klien Python dan SDK MCP resmi
- Menggunakan klien HTTP streaming untuk pengambilan data real-time yang efisien
- Memanggil alat dokumentasi di server dan mencatat respons langsung ke konsol
- Mengintegrasikan dokumentasi Microsoft terbaru ke dalam alur kerja tanpa meninggalkan terminal

Bab ini mencakup tugas praktis, contoh kode minimal yang berfungsi, dan tautan ke sumber daya tambahan untuk pembelajaran lebih mendalam. Lihat panduan lengkap dan kode di bab terkait untuk memahami bagaimana MCP dapat mengubah akses dokumentasi dan produktivitas pengembang di lingkungan berbasis konsol.

### 4. [Aplikasi Web Generator Rencana Studi Interaktif dengan MCP](./docs-mcp/README.md)

Studi kasus ini menunjukkan cara membangun aplikasi web interaktif menggunakan Chainlit dan Model Context Protocol (MCP) untuk menghasilkan rencana studi yang dipersonalisasi untuk topik apa pun. Pengguna dapat menentukan subjek (misalnya "sertifikasi AI-900") dan durasi belajar (misalnya 8 minggu), dan aplikasi akan memberikan rincian konten yang direkomendasikan per minggu. Chainlit memungkinkan antarmuka chat percakapan, membuat pengalaman menjadi menarik dan adaptif.

- Aplikasi web percakapan yang didukung oleh Chainlit
- Prompt yang dikendalikan pengguna untuk topik dan durasi
- Rekomendasi konten mingguan menggunakan MCP
- Respons adaptif real-time dalam antarmuka chat

Proyek ini menggambarkan bagaimana AI percakapan dan MCP dapat digabungkan untuk menciptakan alat edukasi dinamis yang dikendalikan pengguna dalam lingkungan web modern.

### 5. [Dokumentasi Dalam Editor dengan Server MCP di VS Code](./docs-mcp/README.md)

Studi kasus ini menunjukkan bagaimana Anda dapat menghadirkan Microsoft Learn Docs langsung ke lingkungan VS Code Anda menggunakan server MCP—tidak perlu lagi berganti tab browser! Anda akan melihat bagaimana:

- Mencari dan membaca dokumentasi secara instan di dalam VS Code menggunakan panel MCP atau command palette
- Merujuk dokumentasi dan menyisipkan tautan langsung ke file README atau markdown kursus Anda
- Menggunakan GitHub Copilot dan MCP bersama-sama untuk alur kerja dokumentasi dan kode yang mulus dan bertenaga AI
- Memvalidasi dan meningkatkan dokumentasi Anda dengan umpan balik real-time dan akurasi dari Microsoft
- Mengintegrasikan MCP dengan alur kerja GitHub untuk validasi dokumentasi berkelanjutan

Implementasi mencakup:
- Konfigurasi contoh `.vscode/mcp.json` untuk pengaturan mudah
- Panduan berbasis tangkapan layar tentang pengalaman dalam editor
- Tips menggabungkan Copilot dan MCP untuk produktivitas maksimal

Skenario ini ideal untuk penulis kursus, penulis dokumentasi, dan pengembang yang ingin tetap fokus di editor mereka saat bekerja dengan dokumen, Copilot, dan alat validasi—semuanya didukung oleh MCP.

### 6. [Pembuatan Server APIM MCP](./apimsample.md)

Studi kasus ini memberikan panduan langkah demi langkah tentang cara membuat server MCP menggunakan Azure API Management (APIM). Materi mencakup:
- Menyiapkan server MCP di Azure API Management
- Mengekspos operasi API sebagai alat MCP
- Mengonfigurasi kebijakan untuk pembatasan kecepatan dan keamanan
- Menguji server MCP menggunakan Visual Studio Code dan GitHub Copilot

Contoh ini menggambarkan bagaimana memanfaatkan kemampuan Azure untuk membuat server MCP yang tangguh yang dapat digunakan dalam berbagai aplikasi, meningkatkan integrasi sistem AI dengan API perusahaan.

## Kesimpulan

Studi kasus ini menyoroti fleksibilitas dan penerapan praktis Model Context Protocol dalam skenario dunia nyata. Dari sistem multi-agent yang kompleks hingga alur kerja otomatisasi yang terfokus, MCP menyediakan cara standar untuk menghubungkan sistem AI dengan alat dan data yang mereka butuhkan untuk memberikan nilai.

Dengan mempelajari implementasi ini, Anda dapat memperoleh wawasan tentang pola arsitektur, strategi implementasi, dan praktik terbaik yang dapat diterapkan pada proyek MCP Anda sendiri. Contoh-contoh ini menunjukkan bahwa MCP bukan hanya kerangka kerja teoretis, tetapi solusi praktis untuk tantangan bisnis nyata.

## Sumber Daya Tambahan

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

Selanjutnya: Hands on Lab [Streamlining AI Workflows: Building an MCP Server with AI Toolkit](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk akurasi, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sah. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang salah yang timbul dari penggunaan terjemahan ini.