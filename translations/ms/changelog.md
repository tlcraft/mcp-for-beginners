<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-18T17:48:59+00:00",
  "source_file": "changelog.md",
  "language_code": "ms"
}
-->
# Perubahan: Kurikulum MCP untuk Pemula

Dokumen ini berfungsi sebagai rekod semua perubahan penting yang dibuat pada kurikulum Model Context Protocol (MCP) untuk Pemula. Perubahan didokumentasikan dalam urutan kronologi terbalik (perubahan terbaru di atas).

## 18 Ogos 2025

### Kemas Kini Komprehensif Dokumentasi - Piawaian MCP 2025-06-18

#### Amalan Terbaik Keselamatan MCP (02-Security/) - Pemodenan Lengkap
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Penulisan semula sepenuhnya sejajar dengan Spesifikasi MCP 2025-06-18
  - **Keperluan Wajib**: Ditambah keperluan MUST/MUST NOT eksplisit daripada spesifikasi rasmi dengan penunjuk visual yang jelas
  - **12 Amalan Keselamatan Teras**: Disusun semula daripada senarai 15 item kepada domain keselamatan yang komprehensif
    - Keselamatan Token & Pengesahan dengan integrasi penyedia identiti luaran
    - Pengurusan Sesi & Keselamatan Pengangkutan dengan keperluan kriptografi
    - Perlindungan Ancaman AI-Specific dengan integrasi Microsoft Prompt Shields
    - Kawalan Akses & Kebenaran dengan prinsip keistimewaan minimum
    - Keselamatan Kandungan & Pemantauan dengan integrasi Azure Content Safety
    - Keselamatan Rantaian Bekalan dengan pengesahan komponen yang menyeluruh
    - Keselamatan OAuth & Pencegahan Serangan Confused Deputy dengan pelaksanaan PKCE
    - Tindak Balas Insiden & Pemulihan dengan keupayaan automatik
    - Pematuhan & Tadbir Urus dengan penjajaran peraturan
    - Kawalan Keselamatan Lanjutan dengan seni bina zero trust
    - Integrasi Ekosistem Keselamatan Microsoft dengan penyelesaian komprehensif
    - Evolusi Keselamatan Berterusan dengan amalan adaptif
  - **Penyelesaian Keselamatan Microsoft**: Panduan integrasi yang dipertingkatkan untuk Prompt Shields, Azure Content Safety, Entra ID, dan GitHub Advanced Security
  - **Sumber Pelaksanaan**: Pautan sumber komprehensif yang dikategorikan mengikut Dokumentasi MCP Rasmi, Penyelesaian Keselamatan Microsoft, Piawaian Keselamatan, dan Panduan Pelaksanaan

#### Kawalan Keselamatan Lanjutan (02-Security/) - Pelaksanaan Perusahaan
- **MCP-SECURITY-CONTROLS-2025.md**: Penulisan semula sepenuhnya dengan rangka kerja keselamatan gred perusahaan
  - **9 Domain Keselamatan Komprehensif**: Diperluas daripada kawalan asas kepada rangka kerja perusahaan yang terperinci
    - Pengesahan & Kebenaran Lanjutan dengan integrasi Microsoft Entra ID
    - Keselamatan Token & Kawalan Anti-Passthrough dengan pengesahan menyeluruh
    - Kawalan Keselamatan Sesi dengan pencegahan hijacking
    - Kawalan Keselamatan AI-Specific dengan pencegahan suntikan prompt dan keracunan alat
    - Pencegahan Serangan Confused Deputy dengan keselamatan proksi OAuth
    - Keselamatan Pelaksanaan Alat dengan sandboxing dan pengasingan
    - Kawalan Keselamatan Rantaian Bekalan dengan pengesahan kebergantungan
    - Kawalan Pemantauan & Pengesanan dengan integrasi SIEM
    - Tindak Balas Insiden & Pemulihan dengan keupayaan automatik
  - **Contoh Pelaksanaan**: Ditambah blok konfigurasi YAML terperinci dan contoh kod
  - **Integrasi Penyelesaian Microsoft**: Liputan komprehensif perkhidmatan keselamatan Azure, GitHub Advanced Security, dan pengurusan identiti perusahaan

#### Topik Keselamatan Lanjutan (05-AdvancedTopics/mcp-security/) - Pelaksanaan Sedia Produksi
- **README.md**: Penulisan semula sepenuhnya untuk pelaksanaan keselamatan perusahaan
  - **Penjajaran Spesifikasi Semasa**: Dikemas kini kepada Spesifikasi MCP 2025-06-18 dengan keperluan keselamatan wajib
  - **Pengesahan Dipertingkatkan**: Integrasi Microsoft Entra ID dengan contoh terperinci .NET dan Java Spring Security
  - **Integrasi Keselamatan AI**: Pelaksanaan Microsoft Prompt Shields dan Azure Content Safety dengan contoh Python terperinci
  - **Mitigasi Ancaman Lanjutan**: Contoh pelaksanaan komprehensif untuk
    - Pencegahan Serangan Confused Deputy dengan PKCE dan pengesahan persetujuan pengguna
    - Pencegahan Token Passthrough dengan pengesahan audiens dan pengurusan token yang selamat
    - Pencegahan Hijacking Sesi dengan pengikatan kriptografi dan analisis tingkah laku
  - **Integrasi Keselamatan Perusahaan**: Pemantauan Azure Application Insights, saluran pengesanan ancaman, dan keselamatan rantaian bekalan
  - **Senarai Semak Pelaksanaan**: Kawalan keselamatan wajib vs. yang disyorkan dengan manfaat ekosistem keselamatan Microsoft

### Penjajaran Kualiti Dokumentasi & Piawaian
- **Rujukan Spesifikasi**: Dikemas kini semua rujukan kepada Spesifikasi MCP semasa 2025-06-18
- **Ekosistem Keselamatan Microsoft**: Panduan integrasi yang dipertingkatkan di seluruh dokumentasi keselamatan
- **Pelaksanaan Praktikal**: Ditambah contoh kod terperinci dalam .NET, Java, dan Python dengan corak perusahaan
- **Organisasi Sumber**: Kategorisasi komprehensif dokumentasi rasmi, piawaian keselamatan, dan panduan pelaksanaan
- **Penunjuk Visual**: Penandaan jelas keperluan wajib vs. amalan yang disyorkan

#### Konsep Teras (01-CoreConcepts/) - Pemodenan Lengkap
- **Kemas Kini Versi Protokol**: Dikemas kini untuk merujuk kepada Spesifikasi MCP semasa 2025-06-18 dengan penentuan versi berdasarkan tarikh (format YYYY-MM-DD)
- **Penyempurnaan Seni Bina**: Penerangan yang dipertingkatkan tentang Hosts, Clients, dan Servers untuk mencerminkan corak seni bina MCP semasa
  - Hosts kini ditakrifkan dengan jelas sebagai aplikasi AI yang menyelaraskan pelbagai sambungan MCP client
  - Clients diterangkan sebagai penyambung protokol yang mengekalkan hubungan satu-ke-satu dengan server
  - Servers dipertingkatkan dengan senario penyebaran tempatan vs. jauh
- **Penyusunan Semula Primitif**: Penulisan semula sepenuhnya primitif server dan client
  - Primitif Server: Resources (sumber data), Prompts (templat), Tools (fungsi boleh laksana) dengan penerangan dan contoh terperinci
  - Primitif Client: Sampling (penyelesaian LLM), Elicitation (input pengguna), Logging (debugging/pemantauan)
  - Dikemas kini dengan corak kaedah penemuan (`*/list`), pengambilan (`*/get`), dan pelaksanaan (`*/call`) semasa
- **Seni Bina Protokol**: Memperkenalkan model seni bina dua lapisan
  - Lapisan Data: Asas JSON-RPC 2.0 dengan pengurusan kitaran hayat dan primitif
  - Lapisan Pengangkutan: STDIO (tempatan) dan Streamable HTTP dengan SSE (pengangkutan jauh)
- **Rangka Keselamatan**: Prinsip keselamatan yang komprehensif termasuk persetujuan pengguna eksplisit, perlindungan privasi data, keselamatan pelaksanaan alat, dan keselamatan lapisan pengangkutan
- **Corak Komunikasi**: Dikemas kini mesej protokol untuk menunjukkan aliran inisialisasi, penemuan, pelaksanaan, dan pemberitahuan
- **Contoh Kod**: Contoh pelbagai bahasa yang diperbaharui (.NET, Java, Python, JavaScript) untuk mencerminkan corak SDK MCP semasa

#### Keselamatan (02-Security/) - Penulisan Semula Keselamatan Komprehensif  
- **Penjajaran Piawaian**: Penjajaran penuh dengan keperluan keselamatan Spesifikasi MCP 2025-06-18
- **Evolusi Pengesahan**: Dokumentasi evolusi daripada server OAuth tersuai kepada delegasi penyedia identiti luaran (Microsoft Entra ID)
- **Analisis Ancaman AI-Specific**: Liputan yang dipertingkatkan tentang vektor serangan AI moden
  - Senario serangan suntikan prompt terperinci dengan contoh dunia nyata
  - Mekanisme keracunan alat dan corak serangan "rug pull"
  - Keracunan tetingkap konteks dan serangan kekeliruan model
- **Penyelesaian Keselamatan AI Microsoft**: Liputan komprehensif ekosistem keselamatan Microsoft
  - AI Prompt Shields dengan pengesanan lanjutan, spotlighting, dan teknik delimiter
  - Corak integrasi Azure Content Safety
  - GitHub Advanced Security untuk perlindungan rantaian bekalan
- **Mitigasi Ancaman Lanjutan**: Kawalan keselamatan terperinci untuk
  - Hijacking sesi dengan senario serangan MCP-specific dan keperluan ID sesi kriptografi
  - Masalah Confused Deputy dalam senario proksi MCP dengan keperluan persetujuan eksplisit
  - Kerentanan token passthrough dengan kawalan pengesahan wajib
- **Keselamatan Rantaian Bekalan**: Liputan rantaian bekalan AI yang diperluas termasuk model asas, perkhidmatan embeddings, penyedia konteks, dan API pihak ketiga
- **Keselamatan Asas**: Integrasi yang dipertingkatkan dengan corak keselamatan perusahaan termasuk seni bina zero trust dan ekosistem keselamatan Microsoft
- **Organisasi Sumber**: Pautan sumber komprehensif yang dikategorikan mengikut jenis (Dokumen Rasmi, Piawaian, Penyelidikan, Penyelesaian Microsoft, Panduan Pelaksanaan)

### Penambahbaikan Kualiti Dokumentasi
- **Objektif Pembelajaran Berstruktur**: Objektif pembelajaran yang dipertingkatkan dengan hasil yang spesifik dan boleh dilaksanakan 
- **Rujukan Silang**: Ditambah pautan antara topik keselamatan dan konsep teras yang berkaitan
- **Maklumat Terkini**: Dikemas kini semua rujukan tarikh dan pautan spesifikasi kepada piawaian semasa
- **Panduan Pelaksanaan**: Ditambah panduan pelaksanaan yang spesifik dan boleh dilaksanakan di seluruh kedua-dua bahagian

## 16 Julai 2025

### Penambahbaikan README dan Navigasi
- Reka bentuk semula sepenuhnya navigasi kurikulum dalam README.md
- Menggantikan tag `<details>` dengan format berasaskan jadual yang lebih mudah diakses
- Mencipta pilihan susun atur alternatif dalam folder "alternative_layouts" yang baru
- Ditambah contoh navigasi gaya kad, tab, dan akordion
- Dikemas kini bahagian struktur repositori untuk memasukkan semua fail terkini
- Memperbaiki bahagian "Cara Menggunakan Kurikulum Ini" dengan cadangan yang jelas
- Dikemas kini pautan spesifikasi MCP untuk menunjuk ke URL yang betul
- Ditambah bahagian Kejuruteraan Konteks (5.14) ke struktur kurikulum

### Kemas Kini Panduan Pembelajaran
- Menyemak semula sepenuhnya panduan pembelajaran untuk sejajar dengan struktur repositori semasa
- Ditambah bahagian baru untuk MCP Clients dan Tools, serta MCP Servers yang popular
- Dikemas kini Peta Kurikulum Visual untuk mencerminkan semua topik dengan tepat
- Penerangan yang dipertingkatkan tentang Topik Lanjutan untuk merangkumi semua bidang khusus
- Dikemas kini bahagian Kajian Kes untuk mencerminkan contoh sebenar
- Ditambah changelog komprehensif ini

### Sumbangan Komuniti (06-CommunityContributions/)
- Ditambah maklumat terperinci tentang MCP servers untuk penjanaan imej
- Ditambah bahagian komprehensif tentang menggunakan Claude dalam VSCode
- Ditambah arahan persediaan dan penggunaan client terminal Cline
- Dikemas kini bahagian client MCP untuk memasukkan semua pilihan client yang popular
- Contoh sumbangan yang dipertingkatkan dengan sampel kod yang lebih tepat

### Topik Lanjutan (05-AdvancedTopics/)
- Mengatur semua folder topik khusus dengan penamaan yang konsisten
- Ditambah bahan dan contoh kejuruteraan konteks
- Ditambah dokumentasi integrasi ejen Foundry
- Dokumentasi integrasi keselamatan Entra ID yang dipertingkatkan

## 11 Jun 2025

### Penciptaan Awal
- Dikeluarkan versi pertama kurikulum MCP untuk Pemula
- Mencipta struktur asas untuk semua 10 bahagian utama
- Melaksanakan Peta Kurikulum Visual untuk navigasi
- Ditambah projek sampel awal dalam pelbagai bahasa pengaturcaraan

### Memulakan (03-GettingStarted/)
- Mencipta contoh pelaksanaan server pertama
- Ditambah panduan pembangunan client
- Termasuk arahan integrasi client LLM
- Ditambah dokumentasi integrasi VS Code
- Melaksanakan contoh server Server-Sent Events (SSE)

### Konsep Teras (01-CoreConcepts/)
- Ditambah penerangan terperinci tentang seni bina client-server
- Mencipta dokumentasi tentang komponen utama protokol
- Mendokumentasikan corak mesej dalam MCP

## 23 Mei 2025

### Struktur Repositori
- Memulakan repositori dengan struktur folder asas
- Mencipta fail README untuk setiap bahagian utama
- Menyediakan infrastruktur terjemahan
- Ditambah aset imej dan diagram

### Dokumentasi
- Mencipta README.md awal dengan gambaran keseluruhan kurikulum
- Ditambah CODE_OF_CONDUCT.md dan SECURITY.md
- Menyediakan SUPPORT.md dengan panduan untuk mendapatkan bantuan
- Mencipta struktur panduan pembelajaran awal

## 15 April 2025

### Perancangan dan Rangka Kerja
- Perancangan awal untuk kurikulum MCP untuk Pemula
- Menentukan objektif pembelajaran dan audiens sasaran
- Menggariskan struktur 10 bahagian kurikulum
- Membangunkan rangka kerja konseptual untuk contoh dan kajian kes
- Mencipta contoh prototaip awal untuk konsep utama

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk memastikan ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang berwibawa. Untuk maklumat penting, terjemahan manusia profesional adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.