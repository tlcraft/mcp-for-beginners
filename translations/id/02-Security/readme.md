<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-17T07:42:22+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "id"
}
-->
# Praktik Keamanan Terbaik

Mengadopsi Model Context Protocol (MCP) membawa kemampuan baru yang kuat ke aplikasi berbasis AI, tetapi juga memperkenalkan tantangan keamanan unik yang melampaui risiko perangkat lunak tradisional. Selain kekhawatiran yang sudah ada seperti pengkodean aman, hak istimewa minimum, dan keamanan rantai pasokan, MCP dan beban kerja AI menghadapi ancaman baru seperti injeksi prompt, peracunan alat, dan modifikasi alat dinamis. Risiko ini dapat menyebabkan pencurian data, pelanggaran privasi, dan perilaku sistem yang tidak diinginkan jika tidak dikelola dengan baik.

Pelajaran ini mengeksplorasi risiko keamanan paling relevan yang terkait dengan MCP—termasuk otentikasi, otorisasi, izin berlebihan, injeksi prompt tidak langsung, dan kerentanan rantai pasokan—dan memberikan kontrol yang dapat diimplementasikan serta praktik terbaik untuk menguranginya. Anda juga akan belajar bagaimana memanfaatkan solusi Microsoft seperti Prompt Shields, Azure Content Safety, dan GitHub Advanced Security untuk memperkuat implementasi MCP Anda. Dengan memahami dan menerapkan kontrol ini, Anda dapat secara signifikan mengurangi kemungkinan pelanggaran keamanan dan memastikan sistem AI Anda tetap kuat dan dapat dipercaya.

# Tujuan Pembelajaran

Pada akhir pelajaran ini, Anda akan dapat:

- Mengidentifikasi dan menjelaskan risiko keamanan unik yang diperkenalkan oleh Model Context Protocol (MCP), termasuk injeksi prompt, peracunan alat, izin berlebihan, dan kerentanan rantai pasokan.
- Mendeskripsikan dan menerapkan kontrol mitigasi efektif untuk risiko keamanan MCP, seperti otentikasi yang kuat, hak istimewa minimum, manajemen token aman, dan verifikasi rantai pasokan.
- Memahami dan memanfaatkan solusi Microsoft seperti Prompt Shields, Azure Content Safety, dan GitHub Advanced Security untuk melindungi MCP dan beban kerja AI.
- Mengenali pentingnya memvalidasi metadata alat, memantau perubahan dinamis, dan membela diri dari serangan injeksi prompt tidak langsung.
- Mengintegrasikan praktik terbaik keamanan yang sudah mapan—seperti pengkodean aman, penguatan server, dan arsitektur zero trust—ke dalam implementasi MCP Anda untuk mengurangi kemungkinan dan dampak pelanggaran keamanan.

# Kontrol Keamanan MCP

Setiap sistem yang memiliki akses ke sumber daya penting memiliki tantangan keamanan yang tersirat. Tantangan keamanan secara umum dapat diatasi melalui penerapan yang benar dari kontrol dan konsep keamanan fundamental. Karena MCP baru saja didefinisikan, spesifikasinya berubah dengan sangat cepat seiring perkembangan protokol. Pada akhirnya kontrol keamanan di dalamnya akan matang, memungkinkan integrasi yang lebih baik dengan arsitektur keamanan perusahaan dan praktik terbaik yang sudah mapan.

Penelitian yang diterbitkan dalam [Microsoft Digital Defense Report](https://aka.ms/mddr) menyatakan bahwa 98% dari pelanggaran yang dilaporkan dapat dicegah dengan kebersihan keamanan yang kuat dan perlindungan terbaik terhadap segala jenis pelanggaran adalah dengan mendapatkan kebersihan keamanan dasar Anda, praktik terbaik pengkodean aman dan keamanan rantai pasokan yang tepat -- praktik yang sudah dicoba dan diuji yang sudah kita ketahui masih memberikan dampak terbesar dalam mengurangi risiko keamanan.

Mari kita lihat beberapa cara yang dapat Anda lakukan untuk mulai mengatasi risiko keamanan saat mengadopsi MCP.

# Otentikasi server MCP (jika implementasi MCP Anda sebelum 26 April 2025)

> **Catatan:** Informasi berikut ini benar per 26 April 2025. Protokol MCP terus berkembang, dan implementasi di masa depan mungkin memperkenalkan pola dan kontrol otentikasi baru. Untuk pembaruan dan panduan terbaru, selalu merujuk ke [Spesifikasi MCP](https://spec.modelcontextprotocol.io/) dan [repositori GitHub MCP](https://github.com/modelcontextprotocol) resmi.

### Pernyataan masalah
Spesifikasi MCP asli mengasumsikan bahwa pengembang akan menulis server otentikasi mereka sendiri. Ini memerlukan pengetahuan tentang OAuth dan batasan keamanan terkait. Server MCP bertindak sebagai Server Otorisasi OAuth 2.0, mengelola otentikasi pengguna yang diperlukan secara langsung daripada mendelegasikannya ke layanan eksternal seperti Microsoft Entra ID. Mulai 26 April 2025, pembaruan spesifikasi MCP memungkinkan server MCP untuk mendelegasikan otentikasi pengguna ke layanan eksternal.

### Risiko
- Logika otorisasi yang salah konfigurasi di server MCP dapat menyebabkan paparan data sensitif dan kontrol akses yang diterapkan secara tidak benar.
- Pencurian token OAuth di server MCP lokal. Jika dicuri, token tersebut kemudian dapat digunakan untuk menyamar sebagai server MCP dan mengakses sumber daya serta data dari layanan yang menjadi tujuan token OAuth tersebut.

### Kontrol mitigasi
- **Tinjau dan Perkuat Logika Otorisasi:** Audit dengan cermat implementasi otorisasi server MCP Anda untuk memastikan hanya pengguna dan klien yang dimaksudkan yang dapat mengakses sumber daya sensitif. Untuk panduan praktis, lihat [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) dan [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Terapkan Praktik Token Aman:** Ikuti [praktik terbaik Microsoft untuk validasi token dan masa hidup](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) untuk mencegah penyalahgunaan token akses dan mengurangi risiko pemutaran ulang atau pencurian token.
- **Lindungi Penyimpanan Token:** Selalu simpan token dengan aman dan gunakan enkripsi untuk melindungi mereka saat tidak aktif dan dalam transit. Untuk tips implementasi, lihat [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Izin berlebihan untuk server MCP

### Pernyataan masalah
Server MCP mungkin telah diberikan izin berlebihan ke layanan/sumber daya yang mereka akses. Misalnya, server MCP yang merupakan bagian dari aplikasi penjualan AI yang terhubung ke penyimpanan data perusahaan seharusnya memiliki akses yang dibatasi hanya pada data penjualan dan tidak diizinkan mengakses semua file di penyimpanan tersebut. Mengacu kembali pada prinsip hak istimewa minimum (salah satu prinsip keamanan tertua), tidak ada sumber daya yang seharusnya memiliki izin yang melebihi apa yang diperlukan untuk melaksanakan tugas yang dimaksudkan. AI menghadirkan tantangan yang meningkat di ruang ini karena untuk memungkinkannya menjadi fleksibel, bisa jadi sulit untuk mendefinisikan izin yang tepat yang diperlukan.

### Risiko
- Memberikan izin berlebihan dapat memungkinkan pencurian atau perubahan data yang tidak dimaksudkan untuk diakses oleh server MCP. Ini juga bisa menjadi masalah privasi jika data tersebut adalah informasi yang dapat diidentifikasi secara pribadi (PII).

### Kontrol mitigasi
- **Terapkan Prinsip Hak Istimewa Minimum:** Berikan server MCP hanya izin minimum yang diperlukan untuk melaksanakan tugas yang diperlukan. Tinjau dan perbarui izin ini secara teratur untuk memastikan mereka tidak melebihi apa yang dibutuhkan. Untuk panduan rinci, lihat [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Gunakan Kontrol Akses Berbasis Peran (RBAC):** Tetapkan peran kepada server MCP yang dibatasi secara ketat untuk sumber daya dan tindakan tertentu, menghindari izin yang luas atau tidak perlu.
- **Pantau dan Audit Izin:** Terus pantau penggunaan izin dan audit log akses untuk mendeteksi dan memperbaiki hak istimewa yang berlebihan atau tidak terpakai dengan segera.

# Serangan injeksi prompt tidak langsung

### Pernyataan masalah

Server MCP yang berbahaya atau terganggu dapat memperkenalkan risiko signifikan dengan mengekspos data pelanggan atau memungkinkan tindakan yang tidak diinginkan. Risiko ini sangat relevan dalam beban kerja berbasis AI dan MCP, di mana:

- **Serangan Injeksi Prompt**: Penyerang menyematkan instruksi berbahaya dalam prompt atau konten eksternal, menyebabkan sistem AI melakukan tindakan yang tidak diinginkan atau membocorkan data sensitif. Pelajari lebih lanjut: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Peracunan Alat**: Penyerang memanipulasi metadata alat (seperti deskripsi atau parameter) untuk mempengaruhi perilaku AI, berpotensi melewati kontrol keamanan atau mengekstraksi data. Detail: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Injeksi Prompt Lintas Domain**: Instruksi berbahaya disematkan dalam dokumen, halaman web, atau email, yang kemudian diproses oleh AI, mengakibatkan kebocoran data atau manipulasi.
- **Modifikasi Alat Dinamis (Rug Pulls)**: Definisi alat dapat diubah setelah persetujuan pengguna, memperkenalkan perilaku berbahaya baru tanpa sepengetahuan pengguna.

Kerentanan ini menyoroti kebutuhan akan validasi yang kuat, pemantauan, dan kontrol keamanan saat mengintegrasikan server dan alat MCP ke dalam lingkungan Anda. Untuk pemahaman yang lebih mendalam, lihat referensi yang terhubung di atas.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.4b2f1af239a32d46221a75c7bc5b6f392ebbacc47eccde241d4c60507232fa43.id.png)

**Injeksi Prompt Tidak Langsung** (juga dikenal sebagai injeksi prompt lintas domain atau XPIA) adalah kerentanan kritis dalam sistem AI generatif, termasuk yang menggunakan Model Context Protocol (MCP). Dalam serangan ini, instruksi berbahaya tersembunyi dalam konten eksternal—seperti dokumen, halaman web, atau email. Ketika sistem AI memproses konten ini, ia dapat menafsirkan instruksi yang disematkan sebagai perintah pengguna yang sah, mengakibatkan tindakan yang tidak diinginkan seperti kebocoran data, pembuatan konten berbahaya, atau manipulasi interaksi pengguna. Untuk penjelasan rinci dan contoh dunia nyata, lihat [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Bentuk serangan ini yang sangat berbahaya adalah **Peracunan Alat**. Di sini, penyerang menyuntikkan instruksi berbahaya ke dalam metadata alat MCP (seperti deskripsi alat atau parameter). Karena model bahasa besar (LLM) bergantung pada metadata ini untuk memutuskan alat mana yang akan digunakan, deskripsi yang terganggu dapat menipu model untuk mengeksekusi panggilan alat yang tidak sah atau melewati kontrol keamanan. Manipulasi ini sering kali tidak terlihat oleh pengguna akhir tetapi dapat diinterpretasikan dan diambil tindakan oleh sistem AI. Risiko ini meningkat di lingkungan server MCP yang dihosting, di mana definisi alat dapat diperbarui setelah persetujuan pengguna—skenario yang kadang-kadang disebut sebagai "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Dalam kasus seperti itu, alat yang sebelumnya aman mungkin kemudian dimodifikasi untuk melakukan tindakan berbahaya, seperti mengekstraksi data atau mengubah perilaku sistem, tanpa sepengetahuan pengguna. Untuk informasi lebih lanjut tentang vektor serangan ini, lihat [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.d4607023f69e16157954001ad81afd763676361f03db0a1cf24ec696b2ddcb88.id.png)

## Risiko
Tindakan AI yang tidak diinginkan menghadirkan berbagai risiko keamanan yang mencakup pencurian data dan pelanggaran privasi.

### Kontrol mitigasi
### Menggunakan prompt shield untuk melindungi dari serangan Injeksi Prompt Tidak Langsung
-----------------------------------------------------------------------------

**AI Prompt Shields** adalah solusi yang dikembangkan oleh Microsoft untuk mempertahankan diri dari serangan injeksi prompt langsung dan tidak langsung. Mereka membantu melalui:

1.  **Deteksi dan Penyaringan**: Prompt Shields menggunakan algoritma pembelajaran mesin dan pemrosesan bahasa alami yang canggih untuk mendeteksi dan menyaring instruksi berbahaya yang disematkan dalam konten eksternal, seperti dokumen, halaman web, atau email.
    
2.  **Spotlighting**: Teknik ini membantu sistem AI membedakan antara instruksi sistem yang valid dan input eksternal yang mungkin tidak dapat dipercaya. Dengan mengubah teks input sedemikian rupa sehingga lebih relevan dengan model, Spotlighting memastikan bahwa AI dapat lebih baik mengidentifikasi dan mengabaikan instruksi berbahaya.
    
3.  **Pembatas dan Penandaan Data**: Menyertakan pembatas dalam pesan sistem secara eksplisit menguraikan lokasi teks input, membantu sistem AI mengenali dan memisahkan input pengguna dari konten eksternal yang berpotensi berbahaya. Penandaan data memperluas konsep ini dengan menggunakan penanda khusus untuk menyoroti batas data tepercaya dan tidak tepercaya.
    
4.  **Pemantauan dan Pembaruan Berkelanjutan**: Microsoft terus memantau dan memperbarui Prompt Shields untuk mengatasi ancaman baru dan yang berkembang. Pendekatan proaktif ini memastikan bahwa pertahanan tetap efektif terhadap teknik serangan terbaru.
    
5. **Integrasi dengan Azure Content Safety:** Prompt Shields adalah bagian dari suite Azure AI Content Safety yang lebih luas, yang menyediakan alat tambahan untuk mendeteksi upaya jailbreak, konten berbahaya, dan risiko keamanan lainnya dalam aplikasi AI.

Anda dapat membaca lebih lanjut tentang AI prompt shield dalam [dokumentasi Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.a4dba28a04ea42d28053f233585290d4862b244ca1e59b8ff695c5530e1bba66.id.png)

### Keamanan rantai pasokan

Keamanan rantai pasokan tetap menjadi dasar di era AI, tetapi ruang lingkup apa yang menjadi bagian dari rantai pasokan Anda telah berkembang. Selain paket kode tradisional, Anda sekarang harus secara ketat memverifikasi dan memantau semua komponen terkait AI, termasuk model dasar, layanan embedding, penyedia konteks, dan API pihak ketiga. Masing-masing ini dapat memperkenalkan kerentanan atau risiko jika tidak dikelola dengan baik.

**Praktik keamanan rantai pasokan utama untuk AI dan MCP:**
- **Verifikasi semua komponen sebelum integrasi:** Ini termasuk tidak hanya pustaka sumber terbuka, tetapi juga model AI, sumber data, dan API eksternal. Selalu periksa asal, lisensi, dan kerentanan yang diketahui.
- **Pertahankan jalur penerapan yang aman:** Gunakan jalur CI/CD otomatis dengan pemindaian keamanan terintegrasi untuk menangkap masalah sejak dini. Pastikan bahwa hanya artefak tepercaya yang diterapkan ke produksi.
- **Pantau dan audit secara berkelanjutan:** Terapkan pemantauan berkelanjutan untuk semua dependensi, termasuk model dan layanan data, untuk mendeteksi kerentanan baru atau serangan rantai pasokan.
- **Terapkan hak istimewa minimum dan kontrol akses:** Batasi akses ke model, data, dan layanan hanya untuk apa yang diperlukan agar server MCP Anda dapat berfungsi.
- **Tanggapi ancaman dengan cepat:** Miliki proses untuk menambal atau mengganti komponen yang terganggu, dan untuk mengganti rahasia atau kredensial jika terjadi pelanggaran.

[GitHub Advanced Security](https://github.com/security/advanced-security) menyediakan fitur seperti pemindaian rahasia, pemindaian dependensi, dan analisis CodeQL. Alat ini terintegrasi dengan [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) dan [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) untuk membantu tim mengidentifikasi dan mengurangi kerentanan di seluruh komponen kode dan rantai pasokan AI.

Microsoft juga menerapkan praktik keamanan rantai pasokan yang luas secara internal untuk semua produk. Pelajari lebih lanjut di [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Praktik keamanan mapan yang akan meningkatkan postur keamanan implementasi MCP Anda

Setiap implementasi MCP mewarisi postur keamanan yang ada dari lingkungan organisasi Anda yang menjadi dasarnya, jadi ketika mempertimbangkan keamanan MCP sebagai komponen dari sistem AI Anda secara keseluruhan, disarankan agar Anda melihat peningkatan postur keamanan yang ada secara keseluruhan. Kontrol keamanan mapan berikut ini sangat relevan:

-   Praktik terbaik pengkodean aman dalam aplikasi AI Anda - lindungi dari [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 untuk LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), penggunaan brankas aman untuk rahasia dan token, menerapkan komunikasi aman end-to-end antara semua komponen aplikasi, dll.
-   Penguatan server -- gunakan MFA jika memungkinkan, jaga agar patch tetap terbaru, integrasikan server dengan penyedia identitas pihak ketiga untuk akses, dll.
-   Jaga agar perangkat, infrastruktur, dan aplikasi tetap terbaru dengan patch
-   Pemantauan keamanan -- menerapkan logging dan pemantauan aplikasi AI (termasuk klien/server MCP) dan mengirimkan log tersebut ke SIEM pusat untuk mendeteksi aktivitas yang tidak biasa
-   Arsitektur zero trust -- mengisolasi komponen melalui kontrol jaringan dan identitas dengan cara yang logis untuk meminimalkan pergerakan lateral jika aplikasi AI dikompromikan.

# Poin-poin Utama

- Prinsip keamanan tetap penting: Pengkodean aman, hak istimewa minimum, verifikasi rantai pasokan, dan pemantauan berkelanjutan sangat penting untuk beban kerja MCP dan AI.
- MCP memperkenalkan risiko baru—seperti injeksi prompt, peracunan alat, dan izin berlebihan—yang memerlukan kontrol tradisional dan khusus AI.
- Gunakan praktik otentikasi, otorisasi, dan manajemen token yang kuat, dengan memanfaatkan penyedia identitas eksternal seperti Microsoft Entra ID jika memungkinkan.
- Lindungi dari injeksi prompt tidak langsung dan peracunan alat dengan memvalidasi metadata alat, memantau perubahan dinamis, dan menggunakan solusi seperti Microsoft Prompt Shields.
- Perlakukan semua komponen dalam rantai pasokan AI Anda—termasuk model, embedding, dan penyedia konteks—dengan ketelitian yang sama seperti dependensi kode.
- Tetap terkini dengan spesifikasi MCP yang berkembang dan berkontribusi pada komunitas untuk membantu membentuk standar yang aman.

# Sumber Daya Tambahan

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
-
- [OWASP Top 10 untuk LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [Keamanan Lanjutan GitHub](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Perjalanan untuk Mengamankan Rantai Pasokan Perangkat Lunak di Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Akses Paling Terbatas yang Aman (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Praktik Terbaik untuk Validasi dan Masa Berlaku Token](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Gunakan Penyimpanan Token yang Aman dan Enkripsi Token (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management sebagai Gerbang Otorisasi untuk MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Menggunakan Microsoft Entra ID untuk Autentikasi dengan Server MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Selanjutnya 

Selanjutnya: [Bab 3: Memulai](/03-GettingStarted/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk mencapai akurasi, harap diingat bahwa terjemahan otomatis dapat mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang berwenang. Untuk informasi penting, disarankan untuk menggunakan terjemahan manusia profesional. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang salah yang timbul dari penggunaan terjemahan ini.