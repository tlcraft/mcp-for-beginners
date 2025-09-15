<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T22:24:51+00:00",
  "source_file": "changelog.md",
  "language_code": "ms"
}
-->
# Perubahan: Kurikulum MCP untuk Pemula

Dokumen ini berfungsi sebagai rekod semua perubahan penting yang dibuat pada kurikulum Model Context Protocol (MCP) untuk Pemula. Perubahan didokumentasikan dalam urutan kronologi terbalik (perubahan terbaru di atas).

## 15 September 2025

### Pengembangan Topik Lanjutan - Pengangkutan Tersuai & Kejuruteraan Konteks

#### MCP Pengangkutan Tersuai (05-AdvancedTopics/mcp-transport/) - Panduan Pelaksanaan Lanjutan Baharu
- **README.md**: Panduan pelaksanaan lengkap untuk mekanisme pengangkutan MCP tersuai
  - **Pengangkutan Azure Event Grid**: Pelaksanaan pengangkutan tanpa pelayan yang didorong oleh acara
    - Contoh dalam C#, TypeScript, dan Python dengan integrasi Azure Functions
    - Corak seni bina yang didorong oleh acara untuk penyelesaian MCP yang boleh diskalakan
    - Penerima webhook dan pengendalian mesej berasaskan push
  - **Pengangkutan Azure Event Hubs**: Pelaksanaan pengangkutan aliran throughput tinggi
    - Keupayaan aliran masa nyata untuk senario latensi rendah
    - Strategi pembahagian dan pengurusan titik semak
    - Pengelompokan mesej dan pengoptimuman prestasi
  - **Corak Integrasi Perusahaan**: Contoh seni bina sedia pengeluaran
    - Pemprosesan MCP yang diedarkan merentasi pelbagai Azure Functions
    - Seni bina pengangkutan hibrid yang menggabungkan pelbagai jenis pengangkutan
    - Ketahanan mesej, kebolehpercayaan, dan strategi pengendalian ralat
  - **Keselamatan & Pemantauan**: Integrasi Azure Key Vault dan corak pemerhatian
    - Pengesahan identiti terurus dan akses keistimewaan minimum
    - Telemetri Application Insights dan pemantauan prestasi
    - Pemutus litar dan corak toleransi kesalahan
  - **Kerangka Pengujian**: Strategi pengujian menyeluruh untuk pengangkutan tersuai
    - Pengujian unit dengan rangka kerja pengganti dan pemalsuan
    - Pengujian integrasi dengan Azure Test Containers
    - Pertimbangan pengujian prestasi dan beban

#### Kejuruteraan Konteks (05-AdvancedTopics/mcp-contextengineering/) - Disiplin AI yang Muncul
- **README.md**: Penjelajahan menyeluruh tentang kejuruteraan konteks sebagai bidang yang sedang berkembang
  - **Prinsip Teras**: Perkongsian konteks lengkap, kesedaran keputusan tindakan, dan pengurusan tetingkap konteks
  - **Penyelarasan Protokol MCP**: Bagaimana reka bentuk MCP menangani cabaran kejuruteraan konteks
    - Had tetingkap konteks dan strategi pemuatan progresif
    - Penentuan relevansi dan pengambilan konteks dinamik
    - Pengendalian konteks multi-modal dan pertimbangan keselamatan
  - **Pendekatan Pelaksanaan**: Seni bina satu benang vs. multi-ejen
    - Teknik pengelompokan dan keutamaan konteks
    - Pemuatan progresif konteks dan strategi pemampatan
    - Pendekatan berlapis konteks dan pengoptimuman pengambilan
  - **Kerangka Pengukuran**: Metrik yang muncul untuk penilaian keberkesanan konteks
    - Kecekapan input, prestasi, kualiti, dan pertimbangan pengalaman pengguna
    - Pendekatan eksperimen untuk pengoptimuman konteks
    - Analisis kegagalan dan metodologi penambahbaikan

#### Kemas Kini Navigasi Kurikulum (README.md)
- **Struktur Modul yang Dipertingkatkan**: Jadual kurikulum yang dikemas kini untuk memasukkan topik lanjutan baharu
  - Ditambah entri Kejuruteraan Konteks (5.14) dan Pengangkutan Tersuai (5.15)
  - Pemformatan dan pautan navigasi yang konsisten di semua modul
  - Deskripsi yang dikemas kini untuk mencerminkan skop kandungan semasa

### Penambahbaikan Struktur Direktori
- **Penyelarasan Penamaan**: Menamakan semula "mcp transport" kepada "mcp-transport" untuk konsistensi dengan folder topik lanjutan lain
- **Organisasi Kandungan**: Semua folder 05-AdvancedTopics kini mengikuti corak penamaan yang konsisten (mcp-[topik])

### Penambahbaikan Kualiti Dokumentasi
- **Penyelarasan Spesifikasi MCP**: Semua kandungan baharu merujuk kepada Spesifikasi MCP semasa 2025-06-18
- **Contoh Pelbagai Bahasa**: Contoh kod menyeluruh dalam C#, TypeScript, dan Python
- **Fokus Perusahaan**: Corak sedia pengeluaran dan integrasi awan Azure di seluruh dokumen
- **Dokumentasi Visual**: Diagram Mermaid untuk visualisasi seni bina dan aliran

## 18 Ogos 2025

### Kemas Kini Dokumentasi Menyeluruh - Piawaian MCP 2025-06-18

#### Amalan Terbaik Keselamatan MCP (02-Security/) - Pemodenan Lengkap
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Penulisan semula lengkap yang selaras dengan Spesifikasi MCP 2025-06-18
  - **Keperluan Wajib**: Ditambah keperluan MESTI/TIDAK MESTI yang jelas daripada spesifikasi rasmi dengan penunjuk visual yang jelas
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
    - Integrasi Ekosistem Keselamatan Microsoft dengan penyelesaian yang menyeluruh
    - Evolusi Keselamatan Berterusan dengan amalan adaptif
  - **Penyelesaian Keselamatan Microsoft**: Panduan integrasi yang dipertingkatkan untuk Prompt Shields, Azure Content Safety, Entra ID, dan GitHub Advanced Security
  - **Sumber Pelaksanaan**: Pautan sumber yang dikategorikan secara menyeluruh mengikut Dokumentasi MCP Rasmi, Penyelesaian Keselamatan Microsoft, Piawaian Keselamatan, dan Panduan Pelaksanaan

#### Kawalan Keselamatan Lanjutan (02-Security/) - Pelaksanaan Perusahaan
- **MCP-SECURITY-CONTROLS-2025.md**: Penulisan semula lengkap dengan kerangka keselamatan perusahaan
  - **9 Domain Keselamatan Komprehensif**: Diperluas daripada kawalan asas kepada kerangka perusahaan yang terperinci
    - Pengesahan & Kebenaran Lanjutan dengan integrasi Microsoft Entra ID
    - Keselamatan Token & Kawalan Anti-Passthrough dengan pengesahan yang menyeluruh
    - Kawalan Keselamatan Sesi dengan pencegahan pengambilalihan
    - Kawalan Keselamatan AI-Specific dengan pencegahan suntikan prompt dan keracunan alat
    - Pencegahan Serangan Confused Deputy dengan keselamatan proksi OAuth
    - Keselamatan Pelaksanaan Alat dengan pengkotakan dan pengasingan
    - Kawalan Keselamatan Rantaian Bekalan dengan pengesahan kebergantungan
    - Kawalan Pemantauan & Pengesanan dengan integrasi SIEM
    - Tindak Balas Insiden & Pemulihan dengan keupayaan automatik
  - **Contoh Pelaksanaan**: Ditambah blok konfigurasi YAML terperinci dan contoh kod
  - **Integrasi Penyelesaian Microsoft**: Liputan menyeluruh perkhidmatan keselamatan Azure, GitHub Advanced Security, dan pengurusan identiti perusahaan

#### Keselamatan Topik Lanjutan (05-AdvancedTopics/mcp-security/) - Pelaksanaan Sedia Pengeluaran
- **README.md**: Penulisan semula lengkap untuk pelaksanaan keselamatan perusahaan
  - **Penyelarasan Spesifikasi Semasa**: Dikemas kini kepada Spesifikasi MCP 2025-06-18 dengan keperluan keselamatan wajib
  - **Pengesahan yang Dipertingkatkan**: Integrasi Microsoft Entra ID dengan contoh keselamatan .NET dan Java Spring yang menyeluruh
  - **Integrasi Keselamatan AI**: Pelaksanaan Microsoft Prompt Shields dan Azure Content Safety dengan contoh Python terperinci
  - **Mitigasi Ancaman Lanjutan**: Contoh pelaksanaan menyeluruh untuk
    - Pencegahan Serangan Confused Deputy dengan PKCE dan pengesahan persetujuan pengguna
    - Pencegahan Passthrough Token dengan pengesahan audiens dan pengurusan token yang selamat
    - Pencegahan Pengambilalihan Sesi dengan pengikatan kriptografi dan analisis tingkah laku
  - **Integrasi Keselamatan Perusahaan**: Pemantauan Application Insights Azure, saluran pengesanan ancaman, dan keselamatan rantaian bekalan
  - **Senarai Semak Pelaksanaan**: Kawalan keselamatan wajib vs. yang disyorkan dengan manfaat ekosistem keselamatan Microsoft

### Penambahbaikan Kualiti & Penjajaran Piawaian Dokumentasi
- **Rujukan Spesifikasi**: Dikemas kini semua rujukan kepada Spesifikasi MCP semasa 2025-06-18
- **Ekosistem Keselamatan Microsoft**: Panduan integrasi yang dipertingkatkan di seluruh dokumentasi keselamatan
- **Panduan Pelaksanaan Praktikal**: Ditambah contoh kod terperinci dalam .NET, Java, dan Python dengan corak perusahaan
- **Organisasi Sumber**: Pengkategorian menyeluruh dokumentasi rasmi, piawaian keselamatan, dan panduan pelaksanaan
- **Penunjuk Visual**: Penandaan yang jelas untuk keperluan wajib vs. amalan yang disyorkan

#### Konsep Teras (01-CoreConcepts/) - Pemodenan Lengkap
- **Kemas Kini Versi Protokol**: Dikemas kini untuk merujuk kepada Spesifikasi MCP semasa 2025-06-18 dengan penentuan versi berdasarkan tarikh (format YYYY-MM-DD)
- **Penyempurnaan Seni Bina**: Deskripsi yang dipertingkatkan tentang Host, Klien, dan Pelayan untuk mencerminkan corak seni bina MCP semasa
  - Host kini ditakrifkan dengan jelas sebagai aplikasi AI yang menyelaraskan pelbagai sambungan klien MCP
  - Klien digambarkan sebagai penyambung protokol yang mengekalkan hubungan satu-ke-satu dengan pelayan
  - Pelayan dipertingkatkan dengan senario penyebaran tempatan vs. jauh
- **Penyusunan Semula Primitif**: Penulisan semula lengkap primitif pelayan dan klien
  - Primitif Pelayan: Sumber (sumber data), Prompt (templat), Alat (fungsi yang boleh dilaksanakan) dengan penjelasan dan contoh terperinci
  - Primitif Klien: Sampling (penyelesaian LLM), Elicitation (input pengguna), Logging (debugging/pemantauan)
  - Dikemas kini dengan corak kaedah penemuan (`*/list`), pengambilan (`*/get`), dan pelaksanaan (`*/call`) semasa
- **Seni Bina Protokol**: Memperkenalkan model seni bina dua lapisan
  - Lapisan Data: Asas JSON-RPC 2.0 dengan pengurusan kitaran hayat dan primitif
  - Lapisan Pengangkutan: STDIO (tempatan) dan HTTP yang boleh dialirkan dengan SSE (jauh) mekanisme pengangkutan
- **Kerangka Keselamatan**: Prinsip keselamatan yang komprehensif termasuk persetujuan pengguna yang eksplisit, perlindungan privasi data, keselamatan pelaksanaan alat, dan keselamatan lapisan pengangkutan
- **Corak Komunikasi**: Dikemas kini mesej protokol untuk menunjukkan aliran inisialisasi, penemuan, pelaksanaan, dan pemberitahuan
- **Contoh Kod**: Contoh pelbagai bahasa yang diperbaharui (.NET, Java, Python, JavaScript) untuk mencerminkan corak SDK MCP semasa

#### Keselamatan (02-Security/) - Penulisan Semula Keselamatan Menyeluruh  
- **Penjajaran Piawaian**: Penjajaran penuh dengan keperluan keselamatan Spesifikasi MCP 2025-06-18
- **Evolusi Pengesahan**: Dokumentasi evolusi daripada pelayan OAuth tersuai kepada delegasi penyedia identiti luaran (Microsoft Entra ID)
- **Analisis Ancaman AI-Specific**: Liputan yang dipertingkatkan tentang vektor serangan AI moden
  - Senario serangan suntikan prompt terperinci dengan contoh dunia nyata
  - Mekanisme keracunan alat dan corak serangan "rug pull"
  - Keracunan tetingkap konteks dan serangan kekeliruan model
- **Penyelesaian Keselamatan AI Microsoft**: Liputan menyeluruh ekosistem keselamatan Microsoft
  - AI Prompt Shields dengan pengesanan lanjutan, spotlighting, dan teknik delimiter
  - Corak integrasi Azure Content Safety
  - GitHub Advanced Security untuk perlindungan rantaian bekalan
- **Mitigasi Ancaman Lanjutan**: Kawalan keselamatan terperinci untuk
  - Pengambilalihan sesi dengan senario serangan MCP-specific dan keperluan ID sesi kriptografi
  - Masalah Confused Deputy dalam senario proksi MCP dengan keperluan persetujuan eksplisit
  - Kerentanan Passthrough Token dengan kawalan pengesahan wajib
- **Keselamatan Rantaian Bekalan**: Liputan rantaian bekalan AI yang diperluas termasuk model asas, perkhidmatan embeddings, penyedia konteks, dan API pihak ketiga
- **Keselamatan Asas**: Integrasi yang dipertingkatkan dengan corak keselamatan perusahaan termasuk seni bina zero trust dan ekosistem keselamatan Microsoft
- **Organisasi Sumber**: Pautan sumber yang dikategorikan secara menyeluruh mengikut jenis (Dokumen Rasmi, Piawaian, Penyelidikan, Penyelesaian Microsoft, Panduan Pelaksanaan)

### Penambahbaikan Kualiti Dokumentasi
- **Objektif Pembelajaran Berstruktur**: Objektif pembelajaran yang dipertingkatkan dengan hasil yang spesifik dan boleh dilaksanakan 
- **Rujukan Silang**: Ditambah pautan antara topik keselamatan dan konsep teras yang berkaitan
- **Maklumat Semasa**: Dikemas kini semua rujukan tarikh dan pautan spesifikasi kepada piawaian semasa
- **Panduan Pelaksanaan**: Ditambah panduan pelaksanaan yang spesifik dan boleh dilaksanakan di seluruh kedua-dua bahagian

## 16 Julai 2025

### Penambahbaikan README dan Navigasi
- Direka semula sepenuhnya navigasi kurikulum dalam README.md
- Menggantikan tag `<details>` dengan format berasaskan jadual yang lebih mudah diakses
- Mencipta pilihan susun atur alternatif dalam folder "alternative_layouts" baharu
- Ditambah contoh navigasi gaya kad, tab, dan akordion
- Dikemas kini bahagian struktur repositori untuk memasukkan semua fail terkini
- Mempertingkatkan bahagian "Cara Menggunakan Kurikulum Ini" dengan cadangan yang jelas
- Dikemas kini pautan spesifikasi MCP untuk menunjuk kepada URL yang betul
- Ditambah bahagian Kejuruteraan Konteks (5.14) kepada struktur kurikulum

### Kemas Kini Panduan Pembelajaran
- Disemak sepenuhnya panduan pembelajaran untuk selaras dengan struktur repositori semasa
- Ditambah bahagian baharu untuk Klien MCP dan Alat, serta Pelayan MCP Popular
- Dikemas kini Peta Kurikulum Visual untuk mencerminkan semua topik dengan tepat
- Mempertingkatkan deskripsi Topik Lanjutan untuk merangkumi semua bidang khusus
- Dikemas kini bahagian Kajian Kes untuk mencerminkan contoh sebenar
- Ditambah changelog yang komprehensif ini

### Sumbangan Komuniti (06-CommunityContributions/)
- Ditambah maklumat terperinci tentang pelayan MCP untuk penjanaan imej
- Ditambah bahagian komprehensif tentang menggunakan Claude dalam VSCode
- Ditambah arahan persediaan dan penggunaan klien terminal Cline
- Dikemas kini bahagian klien MCP untuk memasukkan semua pilihan klien popular
- Mempertingkatkan contoh sumbangan dengan sampel kod yang lebih tepat

### Topik Lanjutan (05-AdvancedTopics/)
- Mengatur semua folder topik khusus dengan penamaan yang konsisten
- Ditambah bahan dan contoh kejuruteraan konteks
- Ditambah dokumentasi integrasi ejen Foundry
- Mempertingkatkan dokumentasi integrasi keselamatan Entra ID

## 11 Jun 2025

### Penciptaan Awal
- Melancarkan versi pertama kurikulum MCP untuk Pemula
- Mencipta struktur asas untuk semua 10 bahagian utama
- Melaksanakan Peta Kurikulum Visual untuk navigasi
- Ditambah projek sampel awal dalam pelbagai bahasa pengaturcaraan

### Memulakan (03-GettingStarted/)
- Mencipta contoh pelaksanaan pelayan pertama
- Ditambah panduan pembangunan klien
- Termasuk arahan integrasi klien LLM
- Ditambah dokumentasi integrasi VS Code
- Melaksanakan contoh pelayan Server-Sent Events (SSE

---

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk memastikan ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang berwibawa. Untuk maklumat yang kritikal, terjemahan manusia profesional adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.