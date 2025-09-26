<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "704c94da1dde019de2d8eb1d671f418f",
  "translation_date": "2025-09-26T18:47:21+00:00",
  "source_file": "changelog.md",
  "language_code": "ms"
}
-->
# Perubahan: Kurikulum MCP untuk Pemula

Dokumen ini berfungsi sebagai rekod semua perubahan penting yang dibuat pada kurikulum Model Context Protocol (MCP) untuk Pemula. Perubahan didokumentasikan dalam susunan kronologi terbalik (perubahan terbaru di atas).

## 26 September 2025

### Penambahbaikan Kajian Kes - Integrasi GitHub MCP Registry

#### Kajian Kes (09-CaseStudy/) - Fokus Pembangunan Ekosistem
- **README.md**: Pengembangan besar dengan kajian kes komprehensif GitHub MCP Registry
  - **Kajian Kes GitHub MCP Registry**: Kajian kes baru yang mendalam mengenai pelancaran GitHub MCP Registry pada September 2025
    - **Analisis Masalah**: Pemeriksaan terperinci tentang cabaran penemuan dan penyebaran pelayan MCP yang terpecah-pecah
    - **Arkitektur Penyelesaian**: Pendekatan registry berpusat GitHub dengan pemasangan satu klik di VS Code
    - **Impak Perniagaan**: Peningkatan yang boleh diukur dalam onboarding dan produktiviti pembangun
    - **Nilai Strategik**: Fokus pada penyebaran agen modular dan interoperabiliti alat silang
    - **Pembangunan Ekosistem**: Posisi sebagai platform asas untuk integrasi agen
  - **Struktur Kajian Kes yang Ditingkatkan**: Semua tujuh kajian kes dikemas kini dengan format yang konsisten dan penerangan yang komprehensif
    - Azure AI Travel Agents: Penekanan pada orkestrasi multi-agen
    - Integrasi Azure DevOps: Fokus pada automasi aliran kerja
    - Pengambilan Dokumentasi Masa Nyata: Pelaksanaan klien konsol Python
    - Penjana Pelan Kajian Interaktif: Aplikasi web Chainlit yang bersifat perbualan
    - Dokumentasi Dalam Editor: Integrasi VS Code dan GitHub Copilot
    - Pengurusan API Azure: Corak integrasi API perusahaan
    - GitHub MCP Registry: Pembangunan ekosistem dan platform komuniti
  - **Kesimpulan Komprehensif**: Bahagian kesimpulan ditulis semula yang menonjolkan tujuh kajian kes yang merangkumi pelbagai dimensi pelaksanaan MCP
    - Integrasi Perusahaan, Orkestrasi Multi-Agen, Produktiviti Pembangun
    - Pembangunan Ekosistem, Aplikasi Pendidikan
    - Wawasan yang dipertingkatkan tentang corak arkitektur, strategi pelaksanaan, dan amalan terbaik
    - Penekanan pada MCP sebagai protokol matang yang sedia untuk pengeluaran

#### Kemas Kini Panduan Kajian (study_guide.md)
- **Peta Kurikulum Visual**: Peta minda dikemas kini untuk memasukkan GitHub MCP Registry dalam bahagian Kajian Kes
- **Penerangan Kajian Kes**: Ditingkatkan daripada penerangan umum kepada pecahan terperinci tujuh kajian kes komprehensif
- **Struktur Repositori**: Bahagian 10 dikemas kini untuk mencerminkan liputan kajian kes yang komprehensif dengan butiran pelaksanaan khusus
- **Integrasi Perubahan**: Ditambah entri 26 September 2025 yang mendokumentasikan penambahan GitHub MCP Registry dan penambahbaikan kajian kes
- **Kemas Kini Tarikh**: Kaki dokumen dikemas kini untuk mencerminkan semakan terkini (26 September 2025)

### Penambahbaikan Kualiti Dokumentasi
- **Peningkatan Konsistensi**: Format dan struktur kajian kes diseragamkan di semua tujuh contoh
- **Liputan Komprehensif**: Kajian kes kini merangkumi senario perusahaan, produktiviti pembangun, dan pembangunan ekosistem
- **Posisi Strategik**: Fokus yang dipertingkatkan pada MCP sebagai platform asas untuk penyebaran sistem agen
- **Integrasi Sumber**: Sumber tambahan dikemas kini untuk memasukkan pautan GitHub MCP Registry

## 15 September 2025

### Pengembangan Topik Lanjutan - Pengangkutan Tersuai & Kejuruteraan Konteks

#### Pengangkutan MCP Tersuai (05-AdvancedTopics/mcp-transport/) - Panduan Pelaksanaan Lanjutan Baru
- **README.md**: Panduan pelaksanaan lengkap untuk mekanisme pengangkutan MCP tersuai
  - **Pengangkutan Azure Event Grid**: Pelaksanaan pengangkutan berasaskan acara tanpa pelayan yang komprehensif
    - Contoh dalam C#, TypeScript, dan Python dengan integrasi Azure Functions
    - Corak seni bina berasaskan acara untuk penyelesaian MCP yang boleh diskalakan
    - Penerima webhook dan pengendalian mesej berasaskan push
  - **Pengangkutan Azure Event Hubs**: Pelaksanaan pengangkutan streaming throughput tinggi
    - Keupayaan streaming masa nyata untuk senario latensi rendah
    - Strategi pembahagian dan pengurusan checkpoint
    - Pengelompokan mesej dan pengoptimuman prestasi
  - **Corak Integrasi Perusahaan**: Contoh seni bina sedia pengeluaran
    - Pemprosesan MCP yang diedarkan di beberapa Azure Functions
    - Seni bina pengangkutan hibrid yang menggabungkan pelbagai jenis pengangkutan
    - Ketahanan mesej, kebolehpercayaan, dan strategi pengendalian ralat
  - **Keselamatan & Pemantauan**: Integrasi Azure Key Vault dan corak pemerhatian
    - Pengesahan identiti terurus dan akses keistimewaan minimum
    - Telemetri Application Insights dan pemantauan prestasi
    - Pemutus litar dan corak toleransi kesalahan
  - **Rangka Ujian**: Strategi ujian komprehensif untuk pengangkutan tersuai
    - Ujian unit dengan test double dan rangka kerja mocking
    - Ujian integrasi dengan Azure Test Containers
    - Pertimbangan ujian prestasi dan beban

#### Kejuruteraan Konteks (05-AdvancedTopics/mcp-contextengineering/) - Disiplin AI yang Muncul
- **README.md**: Eksplorasi komprehensif kejuruteraan konteks sebagai bidang yang sedang berkembang
  - **Prinsip Teras**: Perkongsian konteks lengkap, kesedaran keputusan tindakan, dan pengurusan tingkap konteks
  - **Penyelarasan Protokol MCP**: Bagaimana reka bentuk MCP menangani cabaran kejuruteraan konteks
    - Had tingkap konteks dan strategi pemuatan progresif
    - Penentuan relevansi dan pengambilan konteks dinamik
    - Pengendalian konteks multi-modal dan pertimbangan keselamatan
  - **Pendekatan Pelaksanaan**: Seni bina satu benang vs. multi-agen
    - Teknik chunking dan keutamaan konteks
    - Pemuatan progresif konteks dan strategi pemampatan
    - Pendekatan konteks berlapis dan pengoptimuman pengambilan
  - **Rangka Pengukuran**: Metrik yang muncul untuk penilaian keberkesanan konteks
    - Kecekapan input, prestasi, kualiti, dan pertimbangan pengalaman pengguna
    - Pendekatan eksperimen untuk pengoptimuman konteks
    - Analisis kegagalan dan metodologi penambahbaikan

#### Kemas Kini Navigasi Kurikulum (README.md)
- **Struktur Modul yang Ditingkatkan**: Jadual kurikulum dikemas kini untuk memasukkan topik lanjutan baru
  - Ditambah entri Kejuruteraan Konteks (5.14) dan Pengangkutan Tersuai (5.15)
  - Format dan pautan navigasi yang konsisten di semua modul
  - Penerangan dikemas kini untuk mencerminkan skop kandungan semasa

### Penambahbaikan Struktur Direktori
- **Penyeragaman Penamaan**: Nama "mcp transport" ditukar kepada "mcp-transport" untuk konsistensi dengan folder topik lanjutan lain
- **Organisasi Kandungan**: Semua folder 05-AdvancedTopics kini mengikuti corak penamaan yang konsisten (mcp-[topik])

### Penambahbaikan Kualiti Dokumentasi
- **Penyelarasan Spesifikasi MCP**: Semua kandungan baru merujuk kepada Spesifikasi MCP semasa 2025-06-18
- **Contoh Pelbagai Bahasa**: Contoh kod komprehensif dalam C#, TypeScript, dan Python
- **Fokus Perusahaan**: Corak sedia pengeluaran dan integrasi awan Azure di seluruh kandungan
- **Dokumentasi Visual**: Diagram Mermaid untuk visualisasi seni bina dan aliran

## 18 Ogos 2025

### Kemas Kini Dokumentasi Komprehensif - Piawaian MCP 2025-06-18

#### Amalan Terbaik Keselamatan MCP (02-Security/) - Pemodenan Lengkap
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Penulisan semula lengkap yang selaras dengan Spesifikasi MCP 2025-06-18
  - **Keperluan Mandatori**: Ditambah keperluan MUST/MUST NOT eksplisit daripada spesifikasi rasmi dengan penunjuk visual yang jelas
  - **12 Amalan Keselamatan Teras**: Disusun semula daripada senarai 15 item kepada domain keselamatan yang komprehensif
    - Keselamatan Token & Pengesahan dengan integrasi penyedia identiti luaran
    - Pengurusan Sesi & Keselamatan Pengangkutan dengan keperluan kriptografi
    - Perlindungan Ancaman AI-Specific dengan integrasi Microsoft Prompt Shields
    - Kawalan Akses & Kebenaran dengan prinsip keistimewaan minimum
    - Keselamatan Kandungan & Pemantauan dengan integrasi Azure Content Safety
    - Keselamatan Rantaian Bekalan dengan pengesahan komponen yang komprehensif
    - Keselamatan OAuth & Pencegahan Serangan Confused Deputy dengan pelaksanaan PKCE
    - Tindak Balas Insiden & Pemulihan dengan keupayaan automatik
    - Pematuhan & Tadbir Urus dengan penjajaran peraturan
    - Kawalan Keselamatan Lanjutan dengan seni bina zero trust
    - Integrasi Ekosistem Keselamatan Microsoft dengan penyelesaian komprehensif
    - Evolusi Keselamatan Berterusan dengan amalan adaptif
  - **Penyelesaian Keselamatan Microsoft**: Panduan integrasi yang dipertingkatkan untuk Prompt Shields, Azure Content Safety, Entra ID, dan GitHub Advanced Security
  - **Sumber Pelaksanaan**: Pautan sumber komprehensif yang dikategorikan mengikut Dokumentasi MCP Rasmi, Penyelesaian Keselamatan Microsoft, Piawaian Keselamatan, dan Panduan Pelaksanaan

#### Kawalan Keselamatan Lanjutan (02-Security/) - Pelaksanaan Perusahaan
- **MCP-SECURITY-CONTROLS-2025.md**: Penulisan semula lengkap dengan rangka kerja keselamatan perusahaan
  - **9 Domain Keselamatan Komprehensif**: Diperluas daripada kawalan asas kepada rangka kerja perusahaan yang terperinci
    - Pengesahan & Kebenaran Lanjutan dengan integrasi Microsoft Entra ID
    - Keselamatan Token & Kawalan Anti-Passthrough dengan pengesahan komprehensif
    - Kawalan Keselamatan Sesi dengan pencegahan hijacking
    - Kawalan Keselamatan AI-Specific dengan suntikan prompt dan pencegahan keracunan alat
    - Pencegahan Serangan Confused Deputy dengan keselamatan proksi OAuth
    - Keselamatan Pelaksanaan Alat dengan sandboxing dan pengasingan
    - Kawalan Keselamatan Rantaian Bekalan dengan pengesahan kebergantungan
    - Kawalan Pemantauan & Pengesanan dengan integrasi SIEM
    - Tindak Balas Insiden & Pemulihan dengan keupayaan automatik
  - **Contoh Pelaksanaan**: Ditambah blok konfigurasi YAML terperinci dan contoh kod
  - **Integrasi Penyelesaian Microsoft**: Liputan komprehensif perkhidmatan keselamatan Azure, GitHub Advanced Security, dan pengurusan identiti perusahaan

#### Keselamatan Topik Lanjutan (05-AdvancedTopics/mcp-security/) - Pelaksanaan Sedia Pengeluaran
- **README.md**: Penulisan semula lengkap untuk pelaksanaan keselamatan perusahaan
  - **Penyelarasan Spesifikasi Semasa**: Dikemas kini kepada Spesifikasi MCP 2025-06-18 dengan keperluan keselamatan mandatori
  - **Peningkatan Pengesahan**: Integrasi Microsoft Entra ID dengan contoh .NET dan Java Spring Security yang komprehensif
  - **Integrasi Keselamatan AI**: Pelaksanaan Microsoft Prompt Shields dan Azure Content Safety dengan contoh Python terperinci
  - **Mitigasi Ancaman Lanjutan**: Contoh pelaksanaan komprehensif untuk
    - Pencegahan Serangan Confused Deputy dengan PKCE dan pengesahan persetujuan pengguna
    - Pencegahan Token Passthrough dengan pengesahan audiens dan pengurusan token yang selamat
    - Pencegahan Hijacking Sesi dengan pengikatan kriptografi dan analisis tingkah laku
  - **Integrasi Keselamatan Perusahaan**: Pemantauan Application Insights Azure, saluran pengesanan ancaman, dan keselamatan rantaian bekalan
  - **Senarai Semak Pelaksanaan**: Kawalan keselamatan mandatori vs. yang disyorkan dengan manfaat ekosistem keselamatan Microsoft

### Penambahbaikan Kualiti & Penjajaran Piawaian Dokumentasi
- **Rujukan Spesifikasi**: Semua rujukan dikemas kini kepada Spesifikasi MCP semasa 2025-06-18
- **Ekosistem Keselamatan Microsoft**: Panduan integrasi yang dipertingkatkan di seluruh dokumentasi keselamatan
- **Pelaksanaan Praktikal**: Ditambah contoh kod terperinci dalam .NET, Java, dan Python dengan corak perusahaan
- **Organisasi Sumber**: Kategorisasi komprehensif dokumentasi rasmi, piawaian keselamatan, dan panduan pelaksanaan
- **Penunjuk Visual**: Penandaan jelas keperluan mandatori vs. amalan yang disyorkan

#### Konsep Teras (01-CoreConcepts/) - Pemodenan Lengkap
- **Kemas Kini Versi Protokol**: Dikemas kini untuk merujuk kepada Spesifikasi MCP semasa 2025-06-18 dengan penentuan versi berdasarkan tarikh (format YYYY-MM-DD)
- **Penyempurnaan Seni Bina**: Penerangan yang dipertingkatkan tentang Host, Klien, dan Pelayan untuk mencerminkan corak seni bina MCP semasa
  - Host kini ditakrifkan dengan jelas sebagai aplikasi AI yang menyelaraskan pelbagai sambungan klien MCP
  - Klien digambarkan sebagai penyambung protokol yang mengekalkan hubungan satu-ke-satu dengan pelayan
  - Pelayan ditingkatkan dengan senario penyebaran tempatan vs. jauh
- **Penyusunan Semula Primitif**: Penulisan semula lengkap primitif pelayan dan klien
  - Primitif Pelayan: Sumber (sumber data), Prompt (templat), Alat (fungsi yang boleh dilaksanakan) dengan penerangan dan contoh terperinci
  - Primitif Klien: Sampling (penyelesaian LLM), Elicitation (input pengguna), Logging (debugging/pemantauan)
  - Dikemas kini dengan corak kaedah penemuan (`*/list`), pengambilan (`*/get`), dan pelaksanaan (`*/call`)
- **Seni Bina Protokol**: Memperkenalkan model seni bina dua lapisan
  - Lapisan Data: Asas JSON-RPC 2.0 dengan pengurusan kitaran hayat dan primitif
  - Lapisan Pengangkutan: STDIO (tempatan) dan HTTP yang boleh distrim dengan SSE (jauh)
- **Rangka Keselamatan**: Prinsip keselamatan yang komprehensif termasuk persetujuan pengguna eksplisit, perlindungan privasi data, keselamatan pelaksanaan alat, dan keselamatan lapisan pengangkutan
- **Corak Komunikasi**: Mesej protokol dikemas kini untuk menunjukkan aliran inisialisasi, penemuan, pelaksanaan, dan pemberitahuan
- **Contoh Kod**: Contoh pelbagai bahasa yang diperbaharui (.NET, Java, Python, JavaScript) untuk mencerminkan corak SDK MCP semasa

#### Keselamatan (02-Security/) - Penulisan Semula Keselamatan Komprehensif  
- **Penjajaran Piawaian**: Penjajaran penuh dengan keperluan keselamatan Spesifikasi MCP 2025-06-18
- **Evolusi Pengesahan**: Dokumentasi evolusi daripada pelayan OAuth tersuai kepada delegasi penyedia identiti luaran (Microsoft Entra ID)
- **Analisis Ancaman AI-Specific**: Liputan yang dipertingkatkan tentang vektor serangan AI moden
  - Senario serangan suntikan prompt terperinci dengan contoh dunia nyata
  - Mekanisme keracunan alat dan corak serangan "rug pull"
  - Keracunan tingkap konteks dan serangan kekeliruan model
- **Penyelesaian Keselamatan AI Microsoft**: Liputan komprehensif ekosistem keselamatan Microsoft
  - AI Prompt Shields dengan pengesanan lanjutan, spotlighting, dan teknik delimiter
  - Corak integrasi Azure Content Safety
  - GitHub Advanced Security untuk perlindungan rantaian bekalan
- **Mitigasi Ancaman Lanjutan**: Kawalan keselamatan terperinci untuk
  - Hijacking sesi dengan senario serangan MCP khusus dan keperluan ID sesi kriptografi
  - Masalah Confused Deputy dalam senario proksi MCP dengan keperluan persetujuan eksplisit
  - Kerentanan token passthrough dengan kawalan pengesahan mandatori
- **Keselamatan Rantaian Bekalan**: Liputan rantaian bekalan AI yang diperluas termasuk model asas, perkhidmatan embeddings, penyedia konteks, dan API pihak ketiga
- **Keselamatan Asas**: Integrasi yang dipertingkatkan dengan corak keselamatan perusahaan termasuk seni bina zero trust dan ek
- Menggantikan tag `<details>` dengan format berasaskan jadual yang lebih mudah diakses
- Mencipta pilihan susun atur alternatif dalam folder "alternative_layouts" yang baru
- Menambah contoh navigasi berasaskan kad, gaya tab, dan gaya akordion
- Mengemas kini bahagian struktur repositori untuk memasukkan semua fail terkini
- Memperbaiki bahagian "Cara Menggunakan Kurikulum Ini" dengan cadangan yang jelas
- Mengemas kini pautan spesifikasi MCP untuk menunjuk ke URL yang betul
- Menambah bahagian Kejuruteraan Konteks (5.14) ke dalam struktur kurikulum

### Kemas Kini Panduan Pembelajaran
- Menyemak semula panduan pembelajaran sepenuhnya agar selaras dengan struktur repositori semasa
- Menambah bahagian baru untuk Klien dan Alat MCP, serta Pelayan MCP Popular
- Mengemas kini Peta Kurikulum Visual untuk mencerminkan semua topik dengan tepat
- Memperbaiki penerangan Topik Lanjutan untuk merangkumi semua bidang khusus
- Mengemas kini bahagian Kajian Kes untuk mencerminkan contoh sebenar
- Menambah changelog yang komprehensif ini

### Sumbangan Komuniti (06-CommunityContributions/)
- Menambah maklumat terperinci tentang pelayan MCP untuk penjanaan imej
- Menambah bahagian komprehensif tentang penggunaan Claude dalam VSCode
- Menambah arahan persediaan dan penggunaan klien terminal Cline
- Mengemas kini bahagian klien MCP untuk memasukkan semua pilihan klien popular
- Memperbaiki contoh sumbangan dengan sampel kod yang lebih tepat

### Topik Lanjutan (05-AdvancedTopics/)
- Menyusun semua folder topik khusus dengan penamaan yang konsisten
- Menambah bahan dan contoh kejuruteraan konteks
- Menambah dokumentasi integrasi ejen Foundry
- Memperbaiki dokumentasi integrasi keselamatan Entra ID

## 11 Jun 2025

### Penciptaan Awal
- Melancarkan versi pertama kurikulum MCP untuk Pemula
- Mencipta struktur asas untuk semua 10 bahagian utama
- Melaksanakan Peta Kurikulum Visual untuk navigasi
- Menambah projek contoh awal dalam pelbagai bahasa pengaturcaraan

### Memulakan (03-GettingStarted/)
- Mencipta contoh pelaksanaan pelayan pertama
- Menambah panduan pembangunan klien
- Termasuk arahan integrasi klien LLM
- Menambah dokumentasi integrasi VS Code
- Melaksanakan contoh pelayan Server-Sent Events (SSE)

### Konsep Asas (01-CoreConcepts/)
- Menambah penjelasan terperinci tentang seni bina klien-pelayan
- Mencipta dokumentasi tentang komponen utama protokol
- Mendokumentasikan corak pemesejan dalam MCP

## 23 Mei 2025

### Struktur Repositori
- Memulakan repositori dengan struktur folder asas
- Mencipta fail README untuk setiap bahagian utama
- Menyediakan infrastruktur terjemahan
- Menambah aset imej dan diagram

### Dokumentasi
- Mencipta README.md awal dengan gambaran keseluruhan kurikulum
- Menambah CODE_OF_CONDUCT.md dan SECURITY.md
- Menyediakan SUPPORT.md dengan panduan untuk mendapatkan bantuan
- Mencipta struktur panduan pembelajaran awal

## 15 April 2025

### Perancangan dan Kerangka
- Perancangan awal untuk kurikulum MCP untuk Pemula
- Menentukan objektif pembelajaran dan audiens sasaran
- Menggariskan struktur 10 bahagian kurikulum
- Membangunkan kerangka konseptual untuk contoh dan kajian kes
- Mencipta contoh prototaip awal untuk konsep utama

---

