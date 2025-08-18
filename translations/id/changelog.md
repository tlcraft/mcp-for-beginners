<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-18T17:28:06+00:00",
  "source_file": "changelog.md",
  "language_code": "id"
}
-->
# Catatan Perubahan: Kurikulum MCP untuk Pemula

Dokumen ini berfungsi sebagai catatan semua perubahan signifikan yang dilakukan pada kurikulum Model Context Protocol (MCP) untuk Pemula. Perubahan dicatat dalam urutan kronologis terbalik (perubahan terbaru di atas).

## 18 Agustus 2025

### Pembaruan Komprehensif Dokumentasi - Standar MCP 2025-06-18

#### Praktik Keamanan Terbaik MCP (02-Security/) - Modernisasi Lengkap
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Penulisan ulang lengkap sesuai dengan Spesifikasi MCP 2025-06-18
  - **Persyaratan Wajib**: Ditambahkan persyaratan eksplisit HARUS/TIDAK BOLEH dari spesifikasi resmi dengan indikator visual yang jelas
  - **12 Praktik Keamanan Inti**: Disusun ulang dari daftar 15 item menjadi domain keamanan yang komprehensif
    - Keamanan Token & Autentikasi dengan integrasi penyedia identitas eksternal
    - Manajemen Sesi & Keamanan Transportasi dengan persyaratan kriptografi
    - Perlindungan Ancaman Khusus AI dengan integrasi Microsoft Prompt Shields
    - Kontrol Akses & Izin dengan prinsip hak akses minimum
    - Keamanan & Pemantauan Konten dengan integrasi Azure Content Safety
    - Keamanan Rantai Pasokan dengan verifikasi komponen yang komprehensif
    - Keamanan OAuth & Pencegahan Confused Deputy dengan implementasi PKCE
    - Tanggap Insiden & Pemulihan dengan kemampuan otomatis
    - Kepatuhan & Tata Kelola dengan penyelarasan regulasi
    - Kontrol Keamanan Lanjutan dengan arsitektur zero trust
    - Integrasi Ekosistem Keamanan Microsoft dengan solusi yang komprehensif
    - Evolusi Keamanan Berkelanjutan dengan praktik adaptif
  - **Solusi Keamanan Microsoft**: Panduan integrasi yang ditingkatkan untuk Prompt Shields, Azure Content Safety, Entra ID, dan GitHub Advanced Security
  - **Sumber Daya Implementasi**: Tautan sumber daya komprehensif yang dikategorikan berdasarkan Dokumentasi Resmi MCP, Solusi Keamanan Microsoft, Standar Keamanan, dan Panduan Implementasi

#### Kontrol Keamanan Lanjutan (02-Security/) - Implementasi Perusahaan
- **MCP-SECURITY-CONTROLS-2025.md**: Perombakan lengkap dengan kerangka kerja keamanan tingkat perusahaan
  - **9 Domain Keamanan Komprehensif**: Diperluas dari kontrol dasar menjadi kerangka kerja perusahaan yang terperinci
    - Autentikasi & Otorisasi Lanjutan dengan integrasi Microsoft Entra ID
    - Keamanan Token & Kontrol Anti-Passthrough dengan validasi komprehensif
    - Kontrol Keamanan Sesi dengan pencegahan pembajakan
    - Kontrol Keamanan Khusus AI dengan pencegahan injeksi prompt dan peracunan alat
    - Pencegahan Serangan Confused Deputy dengan keamanan proxy OAuth
    - Keamanan Eksekusi Alat dengan sandboxing dan isolasi
    - Kontrol Keamanan Rantai Pasokan dengan verifikasi dependensi
    - Kontrol Pemantauan & Deteksi dengan integrasi SIEM
    - Tanggap Insiden & Pemulihan dengan kemampuan otomatis
  - **Contoh Implementasi**: Ditambahkan blok konfigurasi YAML dan contoh kode yang terperinci
  - **Integrasi Solusi Microsoft**: Cakupan komprehensif layanan keamanan Azure, GitHub Advanced Security, dan manajemen identitas perusahaan

#### Topik Keamanan Lanjutan (05-AdvancedTopics/mcp-security/) - Implementasi Siap Produksi
- **README.md**: Penulisan ulang lengkap untuk implementasi keamanan perusahaan
  - **Penyelarasan Spesifikasi Terkini**: Diperbarui ke Spesifikasi MCP 2025-06-18 dengan persyaratan keamanan wajib
  - **Autentikasi yang Ditingkatkan**: Integrasi Microsoft Entra ID dengan contoh .NET dan Java Spring Security yang komprehensif
  - **Integrasi Keamanan AI**: Implementasi Microsoft Prompt Shields dan Azure Content Safety dengan contoh Python yang terperinci
  - **Mitigasi Ancaman Lanjutan**: Contoh implementasi komprehensif untuk
    - Pencegahan Serangan Confused Deputy dengan PKCE dan validasi persetujuan pengguna
    - Pencegahan Token Passthrough dengan validasi audiens dan manajemen token yang aman
    - Pencegahan Pembajakan Sesi dengan pengikatan kriptografi dan analisis perilaku
  - **Integrasi Keamanan Perusahaan**: Pemantauan Azure Application Insights, pipeline deteksi ancaman, dan keamanan rantai pasokan
  - **Daftar Periksa Implementasi**: Kontrol keamanan wajib vs. yang direkomendasikan dengan manfaat ekosistem keamanan Microsoft

### Kualitas Dokumentasi & Penyelarasan Standar
- **Referensi Spesifikasi**: Semua referensi diperbarui ke Spesifikasi MCP 2025-06-18 terkini
- **Ekosistem Keamanan Microsoft**: Panduan integrasi yang ditingkatkan di seluruh dokumentasi keamanan
- **Implementasi Praktis**: Ditambahkan contoh kode terperinci dalam .NET, Java, dan Python dengan pola perusahaan
- **Organisasi Sumber Daya**: Kategorisasi komprehensif dokumentasi resmi, standar keamanan, dan panduan implementasi
- **Indikator Visual**: Penandaan yang jelas untuk persyaratan wajib vs. praktik yang direkomendasikan

#### Konsep Inti (01-CoreConcepts/) - Modernisasi Lengkap
- **Pembaruan Versi Protokol**: Diperbarui untuk merujuk pada Spesifikasi MCP 2025-06-18 terkini dengan penomoran versi berbasis tanggal (format YYYY-MM-DD)
- **Penyempurnaan Arsitektur**: Deskripsi yang ditingkatkan tentang Host, Klien, dan Server untuk mencerminkan pola arsitektur MCP terkini
  - Host kini didefinisikan dengan jelas sebagai aplikasi AI yang mengoordinasikan beberapa koneksi klien MCP
  - Klien dijelaskan sebagai konektor protokol yang mempertahankan hubungan satu-ke-satu dengan server
  - Server ditingkatkan dengan skenario penerapan lokal vs. jarak jauh
- **Restrukturisasi Primitif**: Perombakan lengkap primitif server dan klien
  - Primitif Server: Sumber Daya (data sources), Prompts (templates), Tools (fungsi yang dapat dieksekusi) dengan penjelasan dan contoh terperinci
  - Primitif Klien: Sampling (penyelesaian LLM), Elicitation (input pengguna), Logging (debugging/pemantauan)
  - Diperbarui dengan pola metode penemuan (`*/list`), pengambilan (`*/get`), dan eksekusi (`*/call`) terkini
- **Arsitektur Protokol**: Diperkenalkan model arsitektur dua lapis
  - Lapisan Data: Fondasi JSON-RPC 2.0 dengan manajemen siklus hidup dan primitif
  - Lapisan Transportasi: STDIO (lokal) dan HTTP yang dapat di-streaming dengan SSE (jarak jauh)
- **Kerangka Keamanan**: Prinsip keamanan yang komprehensif termasuk persetujuan pengguna eksplisit, perlindungan privasi data, keamanan eksekusi alat, dan keamanan lapisan transportasi
- **Pola Komunikasi**: Pesan protokol diperbarui untuk menunjukkan alur inisialisasi, penemuan, eksekusi, dan notifikasi
- **Contoh Kode**: Contoh multi-bahasa diperbarui (.NET, Java, Python, JavaScript) untuk mencerminkan pola SDK MCP terkini

#### Keamanan (02-Security/) - Perombakan Keamanan Komprehensif  
- **Penyelarasan Standar**: Penyelarasan penuh dengan persyaratan keamanan Spesifikasi MCP 2025-06-18
- **Evolusi Autentikasi**: Dokumentasi evolusi dari server OAuth khusus ke delegasi penyedia identitas eksternal (Microsoft Entra ID)
- **Analisis Ancaman Khusus AI**: Cakupan yang ditingkatkan tentang vektor serangan AI modern
  - Skenario serangan injeksi prompt yang terperinci dengan contoh dunia nyata
  - Mekanisme peracunan alat dan pola serangan "rug pull"
  - Peracunan jendela konteks dan serangan kebingungan model
- **Solusi Keamanan AI Microsoft**: Cakupan komprehensif ekosistem keamanan Microsoft
  - AI Prompt Shields dengan deteksi canggih, spotlighting, dan teknik delimiter
  - Pola integrasi Azure Content Safety
  - GitHub Advanced Security untuk perlindungan rantai pasokan
- **Mitigasi Ancaman Lanjutan**: Kontrol keamanan terperinci untuk
  - Pembajakan sesi dengan skenario serangan spesifik MCP dan persyaratan ID sesi kriptografi
  - Masalah confused deputy dalam skenario proxy MCP dengan persyaratan persetujuan eksplisit
  - Kerentanan token passthrough dengan kontrol validasi wajib
- **Keamanan Rantai Pasokan**: Cakupan rantai pasokan AI yang diperluas termasuk model fondasi, layanan embeddings, penyedia konteks, dan API pihak ketiga
- **Keamanan Fondasi**: Integrasi yang ditingkatkan dengan pola keamanan perusahaan termasuk arsitektur zero trust dan ekosistem keamanan Microsoft
- **Organisasi Sumber Daya**: Tautan sumber daya komprehensif yang dikategorikan berdasarkan jenis (Dokumen Resmi, Standar, Penelitian, Solusi Microsoft, Panduan Implementasi)

### Peningkatan Kualitas Dokumentasi
- **Tujuan Pembelajaran yang Terstruktur**: Tujuan pembelajaran yang ditingkatkan dengan hasil yang spesifik dan dapat ditindaklanjuti
- **Referensi Silang**: Ditambahkan tautan antara topik keamanan dan konsep inti yang terkait
- **Informasi Terkini**: Semua referensi tanggal dan tautan spesifikasi diperbarui ke standar terkini
- **Panduan Implementasi**: Ditambahkan panduan implementasi yang spesifik dan dapat ditindaklanjuti di seluruh bagian

## 16 Juli 2025

### Peningkatan README dan Navigasi
- Desain ulang total navigasi kurikulum di README.md
- Mengganti tag `<details>` dengan format berbasis tabel yang lebih mudah diakses
- Membuat opsi tata letak alternatif di folder "alternative_layouts" baru
- Menambahkan contoh navigasi berbasis kartu, tab, dan gaya akordeon
- Memperbarui bagian struktur repositori untuk menyertakan semua file terbaru
- Meningkatkan bagian "Cara Menggunakan Kurikulum Ini" dengan rekomendasi yang jelas
- Memperbarui tautan spesifikasi MCP ke URL yang benar
- Menambahkan bagian Teknik Konteks (5.14) ke struktur kurikulum

### Pembaruan Panduan Belajar
- Panduan belajar direvisi sepenuhnya agar selaras dengan struktur repositori terkini
- Menambahkan bagian baru untuk Klien dan Alat MCP, serta Server MCP Populer
- Memperbarui Peta Kurikulum Visual agar mencerminkan semua topik dengan akurat
- Meningkatkan deskripsi Topik Lanjutan untuk mencakup semua area khusus
- Memperbarui bagian Studi Kasus agar mencerminkan contoh nyata
- Menambahkan catatan perubahan komprehensif ini

### Kontribusi Komunitas (06-CommunityContributions/)
- Menambahkan informasi terperinci tentang server MCP untuk pembuatan gambar
- Menambahkan bagian komprehensif tentang penggunaan Claude di VSCode
- Menambahkan instruksi pengaturan dan penggunaan klien terminal Cline
- Memperbarui bagian klien MCP untuk menyertakan semua opsi klien populer
- Meningkatkan contoh kontribusi dengan sampel kode yang lebih akurat

### Topik Lanjutan (05-AdvancedTopics/)
- Mengorganisasi semua folder topik khusus dengan penamaan yang konsisten
- Menambahkan materi dan contoh teknik konteks
- Menambahkan dokumentasi integrasi agen Foundry
- Meningkatkan dokumentasi integrasi keamanan Entra ID

## 11 Juni 2025

### Pembuatan Awal
- Merilis versi pertama kurikulum MCP untuk Pemula
- Membuat struktur dasar untuk semua 10 bagian utama
- Mengimplementasikan Peta Kurikulum Visual untuk navigasi
- Menambahkan proyek sampel awal dalam berbagai bahasa pemrograman

### Memulai (03-GettingStarted/)
- Membuat contoh implementasi server pertama
- Menambahkan panduan pengembangan klien
- Menyertakan instruksi integrasi klien LLM
- Menambahkan dokumentasi integrasi VS Code
- Mengimplementasikan contoh server Server-Sent Events (SSE)

### Konsep Inti (01-CoreConcepts/)
- Menambahkan penjelasan terperinci tentang arsitektur klien-server
- Membuat dokumentasi tentang komponen protokol utama
- Mendokumentasikan pola pesan dalam MCP

## 23 Mei 2025

### Struktur Repositori
- Menginisialisasi repositori dengan struktur folder dasar
- Membuat file README untuk setiap bagian utama
- Menyiapkan infrastruktur terjemahan
- Menambahkan aset gambar dan diagram

### Dokumentasi
- Membuat README.md awal dengan gambaran umum kurikulum
- Menambahkan CODE_OF_CONDUCT.md dan SECURITY.md
- Menyiapkan SUPPORT.md dengan panduan untuk mendapatkan bantuan
- Membuat struktur panduan belajar awal

## 15 April 2025

### Perencanaan dan Kerangka Kerja
- Perencanaan awal untuk kurikulum MCP untuk Pemula
- Mendefinisikan tujuan pembelajaran dan audiens target
- Menguraikan struktur 10 bagian kurikulum
- Mengembangkan kerangka konseptual untuk contoh dan studi kasus
- Membuat contoh prototipe awal untuk konsep utama

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan penerjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk memberikan hasil yang akurat, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang berwenang. Untuk informasi yang bersifat kritis, disarankan menggunakan jasa penerjemahan manusia profesional. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.