<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T22:23:47+00:00",
  "source_file": "changelog.md",
  "language_code": "id"
}
-->
# Catatan Perubahan: Kurikulum MCP untuk Pemula

Dokumen ini berfungsi sebagai catatan semua perubahan signifikan yang dilakukan pada kurikulum Model Context Protocol (MCP) untuk Pemula. Perubahan dicatat dalam urutan kronologis terbalik (perubahan terbaru terlebih dahulu).

## 15 September 2025

### Perluasan Topik Lanjutan - Transportasi Kustom & Rekayasa Konteks

#### MCP Transportasi Kustom (05-AdvancedTopics/mcp-transport/) - Panduan Implementasi Lanjutan Baru
- **README.md**: Panduan lengkap untuk mekanisme transportasi MCP kustom
  - **Azure Event Grid Transport**: Implementasi transportasi berbasis peristiwa tanpa server yang komprehensif
    - Contoh dalam C#, TypeScript, dan Python dengan integrasi Azure Functions
    - Pola arsitektur berbasis peristiwa untuk solusi MCP yang skalabel
    - Penerima webhook dan penanganan pesan berbasis dorongan
  - **Azure Event Hubs Transport**: Implementasi transportasi streaming dengan throughput tinggi
    - Kemampuan streaming real-time untuk skenario latensi rendah
    - Strategi partisi dan manajemen checkpoint
    - Pengelompokan pesan dan optimasi kinerja
  - **Pola Integrasi Perusahaan**: Contoh arsitektur siap produksi
    - Pemrosesan MCP terdistribusi di beberapa Azure Functions
    - Arsitektur transportasi hibrid yang menggabungkan beberapa jenis transportasi
    - Strategi ketahanan pesan, keandalan, dan penanganan kesalahan
  - **Keamanan & Pemantauan**: Integrasi Azure Key Vault dan pola observabilitas
    - Autentikasi identitas terkelola dan akses dengan hak istimewa minimal
    - Telemetri Application Insights dan pemantauan kinerja
    - Pemutus sirkuit dan pola toleransi kesalahan
  - **Kerangka Pengujian**: Strategi pengujian komprehensif untuk transportasi kustom
    - Pengujian unit dengan test double dan kerangka kerja mocking
    - Pengujian integrasi dengan Azure Test Containers
    - Pertimbangan pengujian kinerja dan beban

#### Rekayasa Konteks (05-AdvancedTopics/mcp-contextengineering/) - Disiplin AI yang Berkembang
- **README.md**: Eksplorasi komprehensif tentang rekayasa konteks sebagai bidang yang berkembang
  - **Prinsip Inti**: Berbagi konteks secara lengkap, kesadaran keputusan tindakan, dan manajemen jendela konteks
  - **Keselarasan Protokol MCP**: Bagaimana desain MCP mengatasi tantangan rekayasa konteks
    - Keterbatasan jendela konteks dan strategi pemuatan progresif
    - Penentuan relevansi dan pengambilan konteks dinamis
    - Penanganan konteks multi-modal dan pertimbangan keamanan
  - **Pendekatan Implementasi**: Arsitektur single-threaded vs. multi-agent
    - Teknik chunking dan prioritisasi konteks
    - Pemuatan progresif konteks dan strategi kompresi
    - Pendekatan konteks berlapis dan optimasi pengambilan
  - **Kerangka Pengukuran**: Metrik yang muncul untuk evaluasi efektivitas konteks
    - Efisiensi input, kinerja, kualitas, dan pertimbangan pengalaman pengguna
    - Pendekatan eksperimental untuk optimasi konteks
    - Analisis kegagalan dan metodologi perbaikan

#### Pembaruan Navigasi Kurikulum (README.md)
- **Struktur Modul yang Ditingkatkan**: Tabel kurikulum yang diperbarui untuk menyertakan topik lanjutan baru
  - Ditambahkan Rekayasa Konteks (5.14) dan Transportasi Kustom (5.15)
  - Format dan tautan navigasi yang konsisten di semua modul
  - Deskripsi yang diperbarui untuk mencerminkan cakupan konten saat ini

### Peningkatan Struktur Direktori
- **Standarisasi Penamaan**: Mengganti nama "mcp transport" menjadi "mcp-transport" untuk konsistensi dengan folder topik lanjutan lainnya
- **Organisasi Konten**: Semua folder 05-AdvancedTopics sekarang mengikuti pola penamaan yang konsisten (mcp-[topik])

### Peningkatan Kualitas Dokumentasi
- **Keselarasan Spesifikasi MCP**: Semua konten baru merujuk pada Spesifikasi MCP terkini 2025-06-18
- **Contoh Multi-Bahasa**: Contoh kode komprehensif dalam C#, TypeScript, dan Python
- **Fokus Perusahaan**: Pola siap produksi dan integrasi cloud Azure di seluruh dokumen
- **Dokumentasi Visual**: Diagram Mermaid untuk visualisasi arsitektur dan alur

## 18 Agustus 2025

### Pembaruan Dokumentasi Komprehensif - Standar MCP 2025-06-18

#### Praktik Keamanan MCP (02-Security/) - Modernisasi Lengkap
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Penulisan ulang lengkap yang selaras dengan Spesifikasi MCP 2025-06-18
  - **Persyaratan Wajib**: Ditambahkan persyaratan eksplisit HARUS/TIDAK BOLEH dari spesifikasi resmi dengan indikator visual yang jelas
  - **12 Praktik Keamanan Inti**: Disusun ulang dari daftar 15 item menjadi domain keamanan yang komprehensif
    - Keamanan Token & Autentikasi dengan integrasi penyedia identitas eksternal
    - Manajemen Sesi & Keamanan Transportasi dengan persyaratan kriptografi
    - Perlindungan Ancaman AI-Specific dengan integrasi Microsoft Prompt Shields
    - Kontrol Akses & Izin dengan prinsip hak istimewa minimal
    - Keamanan Konten & Pemantauan dengan integrasi Azure Content Safety
    - Keamanan Rantai Pasokan dengan verifikasi komponen yang komprehensif
    - Keamanan OAuth & Pencegahan Serangan Confused Deputy dengan implementasi PKCE
    - Respons Insiden & Pemulihan dengan kemampuan otomatis
    - Kepatuhan & Tata Kelola dengan keselarasan regulasi
    - Kontrol Keamanan Lanjutan dengan arsitektur zero trust
    - Integrasi Ekosistem Keamanan Microsoft dengan solusi yang komprehensif
    - Evolusi Keamanan Berkelanjutan dengan praktik adaptif
  - **Solusi Keamanan Microsoft**: Panduan integrasi yang ditingkatkan untuk Prompt Shields, Azure Content Safety, Entra ID, dan GitHub Advanced Security
  - **Sumber Daya Implementasi**: Tautan sumber daya komprehensif yang dikategorikan berdasarkan Dokumentasi MCP Resmi, Solusi Keamanan Microsoft, Standar Keamanan, dan Panduan Implementasi

#### Kontrol Keamanan Lanjutan (02-Security/) - Implementasi Perusahaan
- **MCP-SECURITY-CONTROLS-2025.md**: Perombakan lengkap dengan kerangka kerja keamanan tingkat perusahaan
  - **9 Domain Keamanan Komprehensif**: Diperluas dari kontrol dasar menjadi kerangka kerja perusahaan yang terperinci
    - Autentikasi & Otorisasi Lanjutan dengan integrasi Microsoft Entra ID
    - Keamanan Token & Kontrol Anti-Passthrough dengan validasi yang komprehensif
    - Kontrol Keamanan Sesi dengan pencegahan pembajakan
    - Kontrol Keamanan AI-Specific dengan pencegahan injeksi prompt dan keracunan alat
    - Pencegahan Serangan Confused Deputy dengan keamanan proxy OAuth
    - Keamanan Eksekusi Alat dengan sandboxing dan isolasi
    - Kontrol Keamanan Rantai Pasokan dengan verifikasi dependensi
    - Kontrol Pemantauan & Deteksi dengan integrasi SIEM
    - Respons Insiden & Pemulihan dengan kemampuan otomatis
  - **Contoh Implementasi**: Ditambahkan blok konfigurasi YAML yang terperinci dan contoh kode
  - **Integrasi Solusi Microsoft**: Cakupan komprehensif layanan keamanan Azure, GitHub Advanced Security, dan manajemen identitas perusahaan

#### Keamanan Topik Lanjutan (05-AdvancedTopics/mcp-security/) - Implementasi Siap Produksi
- **README.md**: Penulisan ulang lengkap untuk implementasi keamanan perusahaan
  - **Keselarasan Spesifikasi Terkini**: Diperbarui ke Spesifikasi MCP 2025-06-18 dengan persyaratan keamanan wajib
  - **Autentikasi yang Ditingkatkan**: Integrasi Microsoft Entra ID dengan contoh .NET dan Java Spring Security yang komprehensif
  - **Integrasi Keamanan AI**: Implementasi Microsoft Prompt Shields dan Azure Content Safety dengan contoh Python yang terperinci
  - **Mitigasi Ancaman Lanjutan**: Contoh implementasi komprehensif untuk
    - Pencegahan Serangan Confused Deputy dengan PKCE dan validasi persetujuan pengguna
    - Pencegahan Token Passthrough dengan validasi audiens dan manajemen token yang aman
    - Pencegahan Pembajakan Sesi dengan pengikatan kriptografi dan analisis perilaku
  - **Integrasi Keamanan Perusahaan**: Pemantauan Application Insights Azure, pipeline deteksi ancaman, dan keamanan rantai pasokan
  - **Daftar Periksa Implementasi**: Kontrol keamanan wajib vs. yang direkomendasikan dengan manfaat ekosistem keamanan Microsoft

### Peningkatan Kualitas & Keselarasan Standar Dokumentasi
- **Referensi Spesifikasi**: Memperbarui semua referensi ke Spesifikasi MCP terkini 2025-06-18
- **Ekosistem Keamanan Microsoft**: Panduan integrasi yang ditingkatkan di seluruh dokumentasi keamanan
- **Implementasi Praktis**: Ditambahkan contoh kode terperinci dalam .NET, Java, dan Python dengan pola perusahaan
- **Organisasi Sumber Daya**: Kategorisasi komprehensif dokumentasi resmi, standar keamanan, dan panduan implementasi
- **Indikator Visual**: Penandaan yang jelas untuk persyaratan wajib vs. praktik yang direkomendasikan

## 16 Juli 2025

### Peningkatan README dan Navigasi
- Mendesain ulang navigasi kurikulum sepenuhnya di README.md
- Mengganti tag `<details>` dengan format berbasis tabel yang lebih mudah diakses
- Membuat opsi tata letak alternatif di folder "alternative_layouts" baru
- Menambahkan contoh navigasi berbasis kartu, gaya tab, dan gaya akordeon
- Memperbarui bagian struktur repositori untuk menyertakan semua file terbaru
- Meningkatkan bagian "Cara Menggunakan Kurikulum Ini" dengan rekomendasi yang jelas
- Memperbarui tautan spesifikasi MCP untuk mengarah ke URL yang benar
- Menambahkan bagian Rekayasa Konteks (5.14) ke struktur kurikulum

### Pembaruan Panduan Belajar
- Merevisi panduan belajar sepenuhnya agar selaras dengan struktur repositori saat ini
- Menambahkan bagian baru untuk Klien dan Alat MCP, serta Server MCP Populer
- Memperbarui Peta Kurikulum Visual agar mencerminkan semua topik secara akurat
- Meningkatkan deskripsi Topik Lanjutan untuk mencakup semua area spesialisasi
- Memperbarui bagian Studi Kasus agar mencerminkan contoh nyata
- Menambahkan catatan perubahan yang komprehensif ini

### Kontribusi Komunitas (06-CommunityContributions/)
- Menambahkan informasi terperinci tentang server MCP untuk pembuatan gambar
- Menambahkan bagian komprehensif tentang penggunaan Claude di VSCode
- Menambahkan instruksi pengaturan dan penggunaan klien terminal Cline
- Memperbarui bagian klien MCP untuk menyertakan semua opsi klien populer
- Meningkatkan contoh kontribusi dengan sampel kode yang lebih akurat

### Topik Lanjutan (05-AdvancedTopics/)
- Mengorganisasi semua folder topik khusus dengan penamaan yang konsisten
- Menambahkan materi dan contoh rekayasa konteks
- Menambahkan dokumentasi integrasi agen Foundry
- Meningkatkan dokumentasi integrasi keamanan Entra ID

## 11 Juni 2025

### Pembuatan Awal
- Merilis versi pertama kurikulum MCP untuk Pemula
- Membuat struktur dasar untuk semua 10 bagian utama
- Mengimplementasikan Peta Kurikulum Visual untuk navigasi
- Menambahkan proyek contoh awal dalam berbagai bahasa pemrograman

### Memulai (03-GettingStarted/)
- Membuat contoh implementasi server pertama
- Menambahkan panduan pengembangan klien
- Menyertakan instruksi integrasi klien LLM
- Menambahkan dokumentasi integrasi VS Code
- Mengimplementasikan contoh server Server-Sent Events (SSE)

### Konsep Inti (01-CoreConcepts/)
- Menambahkan penjelasan terperinci tentang arsitektur klien-server
- Membuat dokumentasi tentang komponen utama protokol
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
- Menguraikan struktur 10 bagian dari kurikulum
- Mengembangkan kerangka kerja konseptual untuk contoh dan studi kasus
- Membuat contoh prototipe awal untuk konsep utama

---

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan penerjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk memberikan hasil yang akurat, harap diingat bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang otoritatif. Untuk informasi yang bersifat kritis, disarankan menggunakan jasa penerjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.