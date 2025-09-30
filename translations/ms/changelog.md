<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f9d56a1327805a9f6df085a41fb81083",
  "translation_date": "2025-09-30T19:24:40+00:00",
  "source_file": "changelog.md",
  "language_code": "ms"
}
-->
# Perubahan: Kurikulum MCP untuk Pemula

Dokumen ini berfungsi sebagai rekod semua perubahan penting yang dibuat pada kurikulum Model Context Protocol (MCP) untuk Pemula. Perubahan didokumentasikan dalam susunan kronologi terbalik (perubahan terbaru di atas).

## 29 September 2025

### Makmal Integrasi Pangkalan Data MCP Server - Laluan Pembelajaran Praktikal Komprehensif

#### 11-MCPServerHandsOnLabs - Kurikulum Integrasi Pangkalan Data Lengkap Baharu
- **Laluan Pembelajaran 13 Makmal Lengkap**: Menambah kurikulum praktikal komprehensif untuk membina MCP server bersedia untuk pengeluaran dengan integrasi pangkalan data PostgreSQL
  - **Pelaksanaan Dunia Sebenar**: Kes penggunaan analitik Zava Retail yang menunjukkan corak tahap perusahaan
  - **Perkembangan Pembelajaran Berstruktur**:
    - **Makmal 00-03: Asas** - Pengenalan, Seni Bina Teras, Keselamatan & Multi-Tenancy, Persediaan Persekitaran
    - **Makmal 04-06: Membina MCP Server** - Reka Bentuk & Skema Pangkalan Data, Pelaksanaan MCP Server, Pembangunan Alat  
    - **Makmal 07-09: Ciri Lanjutan** - Integrasi Carian Semantik, Ujian & Debugging, Integrasi VS Code
    - **Makmal 10-12: Pengeluaran & Amalan Terbaik** - Strategi Penghantaran, Pemantauan & Pemerhatian, Amalan Terbaik & Pengoptimuman
  - **Teknologi Perusahaan**: Rangka kerja FastMCP, PostgreSQL dengan pgvector, Azure OpenAI embeddings, Azure Container Apps, Application Insights
  - **Ciri Lanjutan**: Keselamatan Tahap Baris (RLS), carian semantik, akses data multi-tenant, embeddings vektor, pemantauan masa nyata

#### Penyeragaman Terminologi - Penukaran Modul kepada Makmal
- **Kemas Kini Dokumentasi Komprehensif**: Sistematik mengemas kini semua fail README dalam 11-MCPServerHandsOnLabs untuk menggunakan terminologi "Makmal" dan bukannya "Modul"
  - **Tajuk Bahagian**: Mengemas kini "Apa yang Diliputi Modul Ini" kepada "Apa yang Diliputi Makmal Ini" di semua 13 makmal
  - **Penerangan Kandungan**: Menukar "Modul ini menyediakan..." kepada "Makmal ini menyediakan..." di seluruh dokumentasi
  - **Objektif Pembelajaran**: Mengemas kini "Menjelang akhir modul ini..." kepada "Menjelang akhir makmal ini..."
  - **Pautan Navigasi**: Menukar semua rujukan "Modul XX:" kepada "Makmal XX:" dalam rujukan silang dan navigasi
  - **Penjejakan Penyelesaian**: Mengemas kini "Selepas menyelesaikan modul ini..." kepada "Selepas menyelesaikan makmal ini..."
  - **Rujukan Teknikal Dikekalkan**: Mengekalkan rujukan modul Python dalam fail konfigurasi (contoh: `"module": "mcp_server.main"`)

#### Peningkatan Panduan Kajian (study_guide.md)
- **Peta Kurikulum Visual**: Menambah bahagian baharu "11. Makmal Integrasi Pangkalan Data" dengan visualisasi struktur makmal yang komprehensif
- **Struktur Repositori**: Dikemas kini daripada sepuluh kepada sebelas bahagian utama dengan penerangan terperinci 11-MCPServerHandsOnLabs
- **Panduan Laluan Pembelajaran**: Meningkatkan arahan navigasi untuk meliputi bahagian 00-11
- **Liputan Teknologi**: Menambah butiran integrasi FastMCP, PostgreSQL, dan perkhidmatan Azure
- **Hasil Pembelajaran**: Menekankan pembangunan server bersedia untuk pengeluaran, corak integrasi pangkalan data, dan keselamatan perusahaan

#### Peningkatan Struktur README Utama
- **Terminologi Berasaskan Makmal**: Mengemas kini README.md utama dalam 11-MCPServerHandsOnLabs untuk menggunakan struktur "Makmal" secara konsisten
- **Organisasi Laluan Pembelajaran**: Perkembangan yang jelas daripada konsep asas melalui pelaksanaan lanjutan kepada penghantaran pengeluaran
- **Fokus Dunia Sebenar**: Penekanan pada pembelajaran praktikal dengan corak dan teknologi tahap perusahaan

### Peningkatan Kualiti & Konsistensi Dokumentasi
- **Penekanan Pembelajaran Praktikal**: Memperkuat pendekatan berasaskan makmal praktikal di seluruh dokumentasi
- **Fokus Corak Perusahaan**: Menonjolkan pelaksanaan bersedia untuk pengeluaran dan pertimbangan keselamatan perusahaan
- **Integrasi Teknologi**: Liputan komprehensif perkhidmatan Azure moden dan corak integrasi AI
- **Perkembangan Pembelajaran**: Laluan berstruktur yang jelas daripada konsep asas kepada penghantaran pengeluaran

## 26 September 2025

### Peningkatan Kajian Kes - Integrasi Registry MCP GitHub

#### Kajian Kes (09-CaseStudy/) - Fokus Pembangunan Ekosistem
- **README.md**: Pengembangan besar dengan kajian kes Registry MCP GitHub yang komprehensif
  - **Kajian Kes Registry MCP GitHub**: Kajian kes baharu yang komprehensif mengkaji pelancaran Registry MCP GitHub pada September 2025
    - **Analisis Masalah**: Pemeriksaan terperinci tentang cabaran penemuan dan penghantaran MCP server yang terpecah-pecah
    - **Seni Bina Penyelesaian**: Pendekatan registry terpusat GitHub dengan pemasangan VS Code satu klik
    - **Kesan Perniagaan**: Peningkatan yang boleh diukur dalam onboarding dan produktiviti pembangun
    - **Nilai Strategik**: Fokus pada penghantaran agen modular dan interoperabiliti alat silang
    - **Pembangunan Ekosistem**: Posisi sebagai platform asas untuk integrasi agentic
  - **Struktur Kajian Kes yang Dipertingkatkan**: Mengemas kini semua tujuh kajian kes dengan format yang konsisten dan penerangan yang komprehensif
    - Azure AI Travel Agents: Penekanan pada orkestrasi multi-agen
    - Integrasi Azure DevOps: Fokus pada automasi aliran kerja
    - Pengambilan Dokumentasi Masa Nyata: Pelaksanaan klien konsol Python
    - Penjana Pelan Kajian Interaktif: Aplikasi web Chainlit perbualan
    - Dokumentasi Dalam Editor: Integrasi VS Code dan GitHub Copilot
    - Pengurusan API Azure: Corak integrasi API perusahaan
    - Registry MCP GitHub: Pembangunan ekosistem dan platform komuniti
  - **Kesimpulan Komprehensif**: Menulis semula bahagian kesimpulan yang menonjolkan tujuh kajian kes yang merangkumi pelbagai dimensi pelaksanaan MCP
    - Integrasi Perusahaan, Orkestrasi Multi-Agen, Produktiviti Pembangun
    - Pembangunan Ekosistem, Kategori Aplikasi Pendidikan
    - Wawasan yang dipertingkatkan tentang corak seni bina, strategi pelaksanaan, dan amalan terbaik
    - Penekanan pada MCP sebagai protokol matang dan bersedia untuk pengeluaran

#### Kemas Kini Panduan Kajian (study_guide.md)
- **Peta Kurikulum Visual**: Dikemas kini mindmap untuk memasukkan Registry MCP GitHub dalam bahagian Kajian Kes
- **Penerangan Kajian Kes**: Dipertingkatkan daripada penerangan umum kepada pecahan terperinci tujuh kajian kes yang komprehensif
- **Struktur Repositori**: Dikemas kini bahagian 10 untuk mencerminkan liputan kajian kes yang komprehensif dengan butiran pelaksanaan khusus
- **Integrasi Perubahan**: Menambah entri 26 September 2025 yang mendokumentasikan penambahan Registry MCP GitHub dan peningkatan kajian kes
- **Kemas Kini Tarikh**: Dikemas kini cap masa footer untuk mencerminkan semakan terkini (26 September 2025)

### Peningkatan Kualiti Dokumentasi
- **Peningkatan Konsistensi**: Memperstandardkan format dan struktur kajian kes di semua tujuh contoh
- **Liputan Komprehensif**: Kajian kes kini merangkumi senario perusahaan, produktiviti pembangun, dan pembangunan ekosistem
- **Posisi Strategik**: Fokus yang dipertingkatkan pada MCP sebagai platform asas untuk penghantaran sistem agentic
- **Integrasi Sumber**: Dikemas kini sumber tambahan untuk memasukkan pautan Registry MCP GitHub

## 15 September 2025

### Pengembangan Topik Lanjutan - Pengangkutan Tersuai & Kejuruteraan Konteks

#### Pengangkutan Tersuai MCP (05-AdvancedTopics/mcp-transport/) - Panduan Pelaksanaan Lanjutan Baharu
- **README.md**: Panduan pelaksanaan lengkap untuk mekanisme pengangkutan MCP tersuai
  - **Pengangkutan Azure Event Grid**: Pelaksanaan pengangkutan berasaskan acara tanpa server yang komprehensif
    - Contoh C#, TypeScript, dan Python dengan integrasi Azure Functions
    - Corak seni bina berasaskan acara untuk penyelesaian MCP yang boleh diskalakan
    - Penerima webhook dan pengendalian mesej berasaskan push
  - **Pengangkutan Azure Event Hubs**: Pelaksanaan pengangkutan streaming throughput tinggi
    - Keupayaan streaming masa nyata untuk senario latensi rendah
    - Strategi pembahagian dan pengurusan checkpoint
    - Pengelompokan mesej dan pengoptimuman prestasi
  - **Corak Integrasi Perusahaan**: Contoh seni bina bersedia untuk pengeluaran
    - Pemprosesan MCP teragih merentasi pelbagai Azure Functions
    - Seni bina pengangkutan hibrid yang menggabungkan pelbagai jenis pengangkutan
    - Ketahanan mesej, kebolehpercayaan, dan strategi pengendalian ralat
  - **Keselamatan & Pemantauan**: Integrasi Azure Key Vault dan corak pemerhatian
    - Pengesahan identiti terurus dan akses keistimewaan minimum
    - Telemetri Application Insights dan pemantauan prestasi
    - Pemutus litar dan corak toleransi kesalahan
  - **Rangka Ujian**: Strategi ujian komprehensif untuk pengangkutan tersuai
    - Ujian unit dengan test doubles dan rangka kerja mocking
    - Ujian integrasi dengan Azure Test Containers
    - Pertimbangan ujian prestasi dan beban

#### Kejuruteraan Konteks (05-AdvancedTopics/mcp-contextengineering/) - Disiplin AI yang Muncul
- **README.md**: Eksplorasi komprehensif kejuruteraan konteks sebagai bidang yang muncul
  - **Prinsip Teras**: Perkongsian konteks lengkap, kesedaran keputusan tindakan, dan pengurusan tingkap konteks
  - **Penjajaran Protokol MCP**: Bagaimana reka bentuk MCP menangani cabaran kejuruteraan konteks
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
    - Analisis kegagalan dan metodologi peningkatan

#### Kemas Kini Navigasi Kurikulum (README.md)
- **Struktur Modul yang Dipertingkatkan**: Dikemas kini jadual kurikulum untuk memasukkan topik lanjutan baharu
  - Menambah Kejuruteraan Konteks (5.14) dan Pengangkutan Tersuai (5.15)
  - Format dan pautan navigasi yang konsisten di semua modul
  - Penerangan yang dikemas kini untuk mencerminkan skop kandungan semasa

### Peningkatan Struktur Direktori
- **Penyeragaman Penamaan**: Menamakan semula "mcp transport" kepada "mcp-transport" untuk konsistensi dengan folder topik lanjutan lain
- **Organisasi Kandungan**: Semua folder 05-AdvancedTopics kini mengikuti corak penamaan yang konsisten (mcp-[topik])

### Peningkatan Kualiti Dokumentasi
- **Penjajaran Spesifikasi MCP**: Semua kandungan baharu merujuk kepada Spesifikasi MCP semasa 2025-06-18
- **Contoh Pelbagai Bahasa**: Contoh kod komprehensif dalam C#, TypeScript, dan Python
- **Fokus Perusahaan**: Corak bersedia untuk pengeluaran dan integrasi awan Azure di seluruh
- **Dokumentasi Visual**: Diagram Mermaid untuk visualisasi seni bina dan aliran

## 18 Ogos 2025

### Kemas Kini Komprehensif Dokumentasi - Piawaian MCP 2025-06-18

#### Amalan Terbaik Keselamatan MCP (02-Security/) - Pemodenan Lengkap
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Penulisan semula lengkap sejajar dengan Spesifikasi MCP 2025-06-18
  - **Keperluan Mandatori**: Menambah keperluan MUST/MUST NOT eksplisit daripada spesifikasi rasmi dengan indikator visual yang jelas
  - **12 Amalan Keselamatan Teras**: Disusun semula daripada senarai 15 item kepada domain keselamatan yang komprehensif
    - Keselamatan Token & Pengesahan dengan integrasi penyedia identiti luaran
    - Pengurusan Sesi & Keselamatan Pengangkutan dengan keperluan kriptografi
    - Perlindungan Ancaman Khusus AI dengan integrasi Microsoft Prompt Shields
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
- **MCP-SECURITY-CONTROLS-2025.md**: Penulisan semula lengkap dengan rangka kerja keselamatan tahap perusahaan
  - **9 Domain Keselamatan Komprehensif**: Diperluas daripada kawalan asas kepada rangka kerja perusahaan yang terperinci
    - Pengesahan & Kebenaran Lanjutan dengan integrasi Microsoft Entra ID
    - Keselamatan Token & Kawalan Anti-Passthrough dengan pengesahan yang komprehensif
    - Kawalan Keselamatan Sesi dengan pencegahan hijacking
    - Kawalan Keselamatan Khusus AI dengan pencegahan suntikan prompt dan keracunan alat
    - Pencegahan Serangan Confused Deputy dengan keselamatan proksi OAuth
    - Keselamatan Pelaksanaan Alat dengan sandboxing dan pengasingan
    - Kawalan Keselamatan Rantaian Bekalan dengan pengesahan kebergantungan
    - Kawalan Pemantauan & Pengesanan dengan integrasi SIEM
    - Tindak Balas Insiden & Pemulihan dengan keupayaan automatik
  - **Contoh Pelaksanaan**: Menambah blok konfigurasi YAML terperinci dan contoh kod
  - **Integrasi Penyelesaian Microsoft**: Liputan komprehensif perkhidmatan keselamatan Azure, GitHub Advanced Security, dan pengurusan identiti perusahaan

#### Keselamatan Topik Lanjutan (05-AdvancedTopics/mcp-security/) - Pelaksanaan Bersedia untuk Pengeluaran
- **README.md**: Penulisan semula lengkap untuk pelaksanaan keselamatan perusahaan
  - **Penjajaran Spesifikasi Semasa**: Dikemas kini kepada Spesifikasi MCP 2025-06-18 dengan keperluan keselamatan mandatori
  - **Pengesahan yang Dipertingkatkan**: Integrasi Microsoft Entra ID dengan contoh .NET dan Java Spring Security yang komprehensif
  - **Integrasi Keselamatan AI**: Pelaksanaan Microsoft Prompt Shields dan Azure Content Safety dengan contoh Python terperinci
  - **Mitigasi Ancaman Lanjutan**: Contoh pelaksanaan komprehensif untuk
    - Pencegahan Serangan Confused Deputy dengan PKCE dan pengesahan persetujuan pengguna
    - Pencegahan Passthrough Token dengan pengesahan audiens dan pengurusan token yang selamat
    - Pencegahan Hijacking Sesi dengan pengikatan kriptografi dan analisis tingkah laku
  - **Integrasi Keselamatan Perusahaan**: Pemantauan Application Insights Azure, saluran pengesanan ancaman, dan keselamatan rantaian bekalan
  - **Senarai Semak Pelaksanaan**: Kawalan keselamatan mandatori vs. yang disyorkan dengan manfaat ekosistem keselamatan Microsoft yang jelas

### Kualiti Dokumentasi & Penjajaran Piawaian
- **Rujukan Sp
- **Petunjuk Visual**: Penandaan yang jelas untuk keperluan wajib berbanding amalan yang disyorkan

#### Konsep Teras (01-CoreConcepts/) - Pemodenan Lengkap
- **Kemas Kini Versi Protokol**: Dikemas kini untuk merujuk kepada Spesifikasi MCP semasa 2025-06-18 dengan penomboran versi berdasarkan tarikh (format YYYY-MM-DD)
- **Penambahbaikan Seni Bina**: Penerangan yang dipertingkatkan tentang Hos, Klien, dan Pelayan untuk mencerminkan corak seni bina MCP semasa
  - Hos kini ditakrifkan dengan jelas sebagai aplikasi AI yang menyelaraskan pelbagai sambungan klien MCP
  - Klien diterangkan sebagai penyambung protokol yang mengekalkan hubungan satu-ke-satu dengan pelayan
  - Pelayan dipertingkatkan dengan senario penggunaan tempatan vs. jauh
- **Penyusunan Semula Primitif**: Penstrukturan semula sepenuhnya primitif pelayan dan klien
  - Primitif Pelayan: Sumber (pangkalan data), Prompt (templat), Alat (fungsi boleh laksana) dengan penerangan dan contoh terperinci
  - Primitif Klien: Sampling (penyelesaian LLM), Elicitation (input pengguna), Logging (debugging/pemantauan)
  - Dikemas kini dengan corak kaedah penemuan (`*/list`), pengambilan (`*/get`), dan pelaksanaan (`*/call`) semasa
- **Seni Bina Protokol**: Memperkenalkan model seni bina dua lapisan
  - Lapisan Data: Asas JSON-RPC 2.0 dengan pengurusan kitaran hayat dan primitif
  - Lapisan Pengangkutan: STDIO (tempatan) dan HTTP boleh distrim dengan SSE (jauh) sebagai mekanisme pengangkutan
- **Rangka Kerja Keselamatan**: Prinsip keselamatan yang komprehensif termasuk persetujuan pengguna yang jelas, perlindungan privasi data, keselamatan pelaksanaan alat, dan keselamatan lapisan pengangkutan
- **Corak Komunikasi**: Mesej protokol dikemas kini untuk menunjukkan aliran inisialisasi, penemuan, pelaksanaan, dan pemberitahuan
- **Contoh Kod**: Contoh pelbagai bahasa (.NET, Java, Python, JavaScript) dikemas kini untuk mencerminkan corak SDK MCP semasa

#### Keselamatan (02-Security/) - Penambahbaikan Keselamatan Komprehensif  
- **Penyelarasan Piawaian**: Penyesuaian penuh dengan keperluan keselamatan Spesifikasi MCP 2025-06-18
- **Evolusi Pengesahan**: Dokumentasi evolusi daripada pelayan OAuth tersuai kepada delegasi penyedia identiti luaran (Microsoft Entra ID)
- **Analisis Ancaman AI Khusus**: Liputan yang dipertingkatkan tentang vektor serangan AI moden
  - Senario serangan suntikan prompt dengan contoh dunia sebenar yang terperinci
  - Mekanisme keracunan alat dan corak serangan "rug pull"
  - Keracunan tetingkap konteks dan serangan kekeliruan model
- **Penyelesaian Keselamatan AI Microsoft**: Liputan komprehensif ekosistem keselamatan Microsoft
  - AI Prompt Shields dengan teknik pengesanan, penyorotan, dan pemisah yang maju
  - Corak integrasi Azure Content Safety
  - GitHub Advanced Security untuk perlindungan rantaian bekalan
- **Pengurangan Ancaman Lanjutan**: Kawalan keselamatan terperinci untuk
  - Rampasan sesi dengan senario serangan khusus MCP dan keperluan ID sesi kriptografi
  - Masalah timbalan keliru dalam senario proksi MCP dengan keperluan persetujuan yang jelas
  - Kerentanan passtrough token dengan kawalan pengesahan mandatori
- **Keselamatan Rantaian Bekalan**: Liputan rantaian bekalan AI yang diperluaskan termasuk model asas, perkhidmatan embedding, penyedia konteks, dan API pihak ketiga
- **Keselamatan Asas**: Integrasi yang dipertingkatkan dengan corak keselamatan perusahaan termasuk seni bina zero trust dan ekosistem keselamatan Microsoft
- **Organisasi Sumber**: Pautan sumber komprehensif dikategorikan mengikut jenis (Dokumen Rasmi, Piawaian, Penyelidikan, Penyelesaian Microsoft, Panduan Pelaksanaan)

### Penambahbaikan Kualiti Dokumentasi
- **Objektif Pembelajaran Berstruktur**: Objektif pembelajaran yang dipertingkatkan dengan hasil yang spesifik dan boleh dilaksanakan
- **Rujukan Silang**: Menambah pautan antara topik keselamatan dan konsep teras yang berkaitan
- **Maklumat Terkini**: Mengemas kini semua rujukan tarikh dan pautan spesifikasi kepada piawaian semasa
- **Panduan Pelaksanaan**: Menambah panduan pelaksanaan yang spesifik dan boleh dilaksanakan di seluruh kedua-dua bahagian

## 16 Julai 2025

### README dan Penambahbaikan Navigasi
- Reka bentuk semula sepenuhnya navigasi kurikulum dalam README.md
- Menggantikan tag `<details>` dengan format berasaskan jadual yang lebih mudah diakses
- Mencipta pilihan susun atur alternatif dalam folder "alternative_layouts" yang baru
- Menambah contoh navigasi gaya kad, tab, dan akordion
- Mengemas kini bahagian struktur repositori untuk memasukkan semua fail terkini
- Mempertingkatkan bahagian "Cara Menggunakan Kurikulum Ini" dengan cadangan yang jelas
- Mengemas kini pautan spesifikasi MCP untuk menunjuk kepada URL yang betul
- Menambah bahagian Kejuruteraan Konteks (5.14) kepada struktur kurikulum

### Kemas Kini Panduan Kajian
- Menyemak semula sepenuhnya panduan kajian untuk sejajar dengan struktur repositori semasa
- Menambah bahagian baru untuk Klien MCP dan Alat, serta Pelayan MCP Popular
- Mengemas kini Peta Kurikulum Visual untuk mencerminkan semua topik dengan tepat
- Mempertingkatkan penerangan tentang Topik Lanjutan untuk merangkumi semua kawasan khusus
- Mengemas kini bahagian Kajian Kes untuk mencerminkan contoh sebenar
- Menambah changelog komprehensif ini

### Sumbangan Komuniti (06-CommunityContributions/)
- Menambah maklumat terperinci tentang pelayan MCP untuk penjanaan imej
- Menambah bahagian komprehensif tentang menggunakan Claude dalam VSCode
- Menambah arahan persediaan dan penggunaan klien terminal Cline
- Mengemas kini bahagian klien MCP untuk memasukkan semua pilihan klien popular
- Mempertingkatkan contoh sumbangan dengan sampel kod yang lebih tepat

### Topik Lanjutan (05-AdvancedTopics/)
- Mengatur semua folder topik khusus dengan penamaan yang konsisten
- Menambah bahan dan contoh kejuruteraan konteks
- Menambah dokumentasi integrasi ejen Foundry
- Mempertingkatkan dokumentasi integrasi keselamatan Entra ID

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

### Konsep Teras (01-CoreConcepts/)
- Menambah penerangan terperinci tentang seni bina klien-pelayan
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
- Mencipta struktur panduan kajian awal

## 15 April 2025

### Perancangan dan Rangka Kerja
- Perancangan awal untuk kurikulum MCP untuk Pemula
- Menentukan objektif pembelajaran dan sasaran audiens
- Menggariskan struktur 10 bahagian kurikulum
- Membangunkan rangka kerja konseptual untuk contoh dan kajian kes
- Mencipta contoh prototaip awal untuk konsep utama

---

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk memastikan ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang berwibawa. Untuk maklumat yang kritikal, terjemahan manusia profesional adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.