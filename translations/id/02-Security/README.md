<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T23:18:11+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "id"
}
-->
# Praktik Terbaik Keamanan

Mengadopsi Model Context Protocol (MCP) membawa kemampuan baru yang kuat untuk aplikasi berbasis AI, namun juga menghadirkan tantangan keamanan unik yang melampaui risiko perangkat lunak tradisional. Selain kekhawatiran yang sudah dikenal seperti pengkodean aman, prinsip hak istimewa paling sedikit, dan keamanan rantai pasokan, MCP dan beban kerja AI menghadapi ancaman baru seperti prompt injection, tool poisoning, dan modifikasi alat dinamis. Risiko-risiko ini dapat menyebabkan pencurian data, pelanggaran privasi, dan perilaku sistem yang tidak diinginkan jika tidak dikelola dengan benar.

Pelajaran ini membahas risiko keamanan paling relevan yang terkait dengan MCP—termasuk autentikasi, otorisasi, izin berlebihan, prompt injection tidak langsung, dan kerentanan rantai pasokan—serta menyediakan kontrol yang dapat diterapkan dan praktik terbaik untuk menguranginya. Anda juga akan belajar cara memanfaatkan solusi Microsoft seperti Prompt Shields, Azure Content Safety, dan GitHub Advanced Security untuk memperkuat implementasi MCP Anda. Dengan memahami dan menerapkan kontrol ini, Anda dapat secara signifikan mengurangi kemungkinan pelanggaran keamanan dan memastikan sistem AI Anda tetap tangguh dan dapat dipercaya.

# Tujuan Pembelajaran

Pada akhir pelajaran ini, Anda akan mampu:

- Mengidentifikasi dan menjelaskan risiko keamanan unik yang diperkenalkan oleh Model Context Protocol (MCP), termasuk prompt injection, tool poisoning, izin berlebihan, dan kerentanan rantai pasokan.
- Mendeskripsikan dan menerapkan kontrol mitigasi yang efektif untuk risiko keamanan MCP, seperti autentikasi yang kuat, prinsip hak istimewa paling sedikit, manajemen token yang aman, dan verifikasi rantai pasokan.
- Memahami dan memanfaatkan solusi Microsoft seperti Prompt Shields, Azure Content Safety, dan GitHub Advanced Security untuk melindungi MCP dan beban kerja AI.
- Mengenali pentingnya memvalidasi metadata alat, memantau perubahan dinamis, dan melindungi terhadap serangan prompt injection tidak langsung.
- Mengintegrasikan praktik terbaik keamanan yang sudah mapan—seperti pengkodean aman, penguatan server, dan arsitektur zero trust—ke dalam implementasi MCP Anda untuk mengurangi kemungkinan dan dampak pelanggaran keamanan.

# Kontrol Keamanan MCP

Setiap sistem yang memiliki akses ke sumber daya penting memiliki tantangan keamanan tersendiri. Tantangan keamanan umumnya dapat diatasi melalui penerapan yang tepat dari kontrol dan konsep keamanan dasar. Karena MCP baru saja didefinisikan, spesifikasinya berubah sangat cepat seiring protokol berkembang. Pada akhirnya, kontrol keamanan di dalamnya akan matang, memungkinkan integrasi yang lebih baik dengan arsitektur keamanan perusahaan dan praktik terbaik yang sudah mapan.

Penelitian yang dipublikasikan dalam [Microsoft Digital Defense Report](https://aka.ms/mddr) menyatakan bahwa 98% pelanggaran yang dilaporkan dapat dicegah dengan menjaga kebersihan keamanan yang kuat, dan perlindungan terbaik terhadap segala jenis pelanggaran adalah memastikan kebersihan keamanan dasar, praktik pengkodean aman, dan keamanan rantai pasokan sudah tepat — praktik-praktik yang sudah teruji ini masih memberikan dampak terbesar dalam mengurangi risiko keamanan.

Mari kita lihat beberapa cara yang bisa Anda mulai untuk mengatasi risiko keamanan saat mengadopsi MCP.

# Autentikasi Server MCP (jika implementasi MCP Anda sebelum 26 April 2025)

> **Note:** Informasi berikut benar per 26 April 2025. Protokol MCP terus berkembang, dan implementasi di masa depan mungkin memperkenalkan pola dan kontrol autentikasi baru. Untuk pembaruan dan panduan terbaru, selalu rujuk ke [MCP Specification](https://spec.modelcontextprotocol.io/) dan repositori resmi [MCP GitHub](https://github.com/modelcontextprotocol).

### Pernyataan Masalah  
Spesifikasi MCP asli mengasumsikan bahwa pengembang akan menulis server autentikasi mereka sendiri. Ini memerlukan pengetahuan tentang OAuth dan batasan keamanan terkait. Server MCP bertindak sebagai OAuth 2.0 Authorization Servers, mengelola autentikasi pengguna secara langsung daripada mendelegasikannya ke layanan eksternal seperti Microsoft Entra ID. Per 26 April 2025, pembaruan spesifikasi MCP memungkinkan server MCP mendelegasikan autentikasi pengguna ke layanan eksternal.

### Risiko
- Logika otorisasi yang salah konfigurasi pada server MCP dapat menyebabkan paparan data sensitif dan penerapan kontrol akses yang keliru.
- Pencurian token OAuth pada server MCP lokal. Jika token dicuri, token tersebut dapat digunakan untuk menyamar sebagai server MCP dan mengakses sumber daya serta data dari layanan yang menggunakan token OAuth tersebut.

### Kontrol Mitigasi
- **Tinjau dan Perkuat Logika Otorisasi:** Audit dengan cermat implementasi otorisasi server MCP Anda untuk memastikan hanya pengguna dan klien yang dimaksudkan yang dapat mengakses sumber daya sensitif. Untuk panduan praktis, lihat [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) dan [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Terapkan Praktik Token yang Aman:** Ikuti [praktik terbaik Microsoft untuk validasi token dan masa berlaku](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) untuk mencegah penyalahgunaan token akses dan mengurangi risiko token replay atau pencurian.
- **Lindungi Penyimpanan Token:** Selalu simpan token dengan aman dan gunakan enkripsi untuk melindunginya saat disimpan dan saat transit. Untuk tips implementasi, lihat [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Izin Berlebihan untuk Server MCP

### Pernyataan Masalah  
Server MCP mungkin diberikan izin yang berlebihan terhadap layanan/sumber daya yang mereka akses. Misalnya, server MCP yang merupakan bagian dari aplikasi penjualan AI yang terhubung ke penyimpanan data perusahaan seharusnya memiliki akses yang dibatasi hanya ke data penjualan dan tidak diizinkan mengakses semua file di penyimpanan tersebut. Mengacu pada prinsip least privilege (salah satu prinsip keamanan tertua), tidak ada sumber daya yang boleh memiliki izin melebihi yang diperlukan untuk menjalankan tugas yang dimaksudkan. AI menghadirkan tantangan tambahan di area ini karena untuk membuatnya fleksibel, sulit untuk menentukan izin yang tepat dibutuhkan.

### Risiko  
- Memberikan izin berlebihan dapat memungkinkan pencurian data atau pengubahan data yang sebenarnya tidak seharusnya dapat diakses oleh server MCP. Ini juga bisa menjadi masalah privasi jika data tersebut merupakan informasi pribadi yang dapat diidentifikasi (PII).

### Kontrol Mitigasi
- **Terapkan Prinsip Least Privilege:** Berikan server MCP hanya izin minimum yang diperlukan untuk menjalankan tugasnya. Tinjau dan perbarui izin ini secara berkala untuk memastikan tidak melebihi yang diperlukan. Untuk panduan rinci, lihat [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Gunakan Role-Based Access Control (RBAC):** Tetapkan peran ke server MCP yang dibatasi ketat pada sumber daya dan tindakan tertentu, hindari izin yang luas atau tidak perlu.
- **Pantau dan Audit Izin:** Pantau penggunaan izin secara terus-menerus dan audit log akses untuk mendeteksi dan memperbaiki hak istimewa yang berlebihan atau tidak terpakai dengan cepat.

# Serangan Prompt Injection Tidak Langsung

### Pernyataan Masalah

Server MCP yang berbahaya atau telah dikompromikan dapat memperkenalkan risiko signifikan dengan mengekspos data pelanggan atau memungkinkan tindakan yang tidak diinginkan. Risiko ini sangat relevan dalam beban kerja AI dan berbasis MCP, di mana:

- **Prompt Injection Attacks**: Penyerang menyisipkan instruksi berbahaya dalam prompt atau konten eksternal, menyebabkan sistem AI melakukan tindakan yang tidak diinginkan atau membocorkan data sensitif. Pelajari lebih lanjut: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning**: Penyerang memanipulasi metadata alat (seperti deskripsi atau parameter) untuk memengaruhi perilaku AI, berpotensi melewati kontrol keamanan atau mencuri data. Detail: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Instruksi berbahaya disisipkan dalam dokumen, halaman web, atau email, yang kemudian diproses oleh AI, menyebabkan kebocoran data atau manipulasi.
- **Dynamic Tool Modification (Rug Pulls)**: Definisi alat dapat diubah setelah persetujuan pengguna, memperkenalkan perilaku berbahaya baru tanpa disadari pengguna.

Kerentanan ini menyoroti kebutuhan akan validasi, pemantauan, dan kontrol keamanan yang kuat saat mengintegrasikan server dan alat MCP ke dalam lingkungan Anda. Untuk penjelasan lebih mendalam, lihat referensi yang terhubung di atas.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.id.png)

**Indirect Prompt Injection** (juga dikenal sebagai cross-domain prompt injection atau XPIA) adalah kerentanan kritis dalam sistem AI generatif, termasuk yang menggunakan Model Context Protocol (MCP). Dalam serangan ini, instruksi berbahaya disembunyikan dalam konten eksternal—seperti dokumen, halaman web, atau email. Ketika sistem AI memproses konten ini, ia mungkin mengartikan instruksi yang disisipkan sebagai perintah pengguna yang sah, sehingga menghasilkan tindakan tidak diinginkan seperti kebocoran data, pembuatan konten berbahaya, atau manipulasi interaksi pengguna. Untuk penjelasan rinci dan contoh nyata, lihat [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Bentuk serangan yang sangat berbahaya adalah **Tool Poisoning**. Di sini, penyerang menyisipkan instruksi berbahaya ke dalam metadata alat MCP (seperti deskripsi alat atau parameter). Karena model bahasa besar (LLM) bergantung pada metadata ini untuk memutuskan alat mana yang akan dipanggil, deskripsi yang dikompromikan dapat menipu model agar menjalankan panggilan alat yang tidak sah atau melewati kontrol keamanan. Manipulasi ini sering tidak terlihat oleh pengguna akhir tetapi dapat diinterpretasikan dan dijalankan oleh sistem AI. Risiko ini meningkat di lingkungan server MCP yang dihosting, di mana definisi alat dapat diperbarui setelah persetujuan pengguna—skenario yang kadang disebut sebagai "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Dalam kasus seperti itu, alat yang sebelumnya aman dapat dimodifikasi untuk melakukan tindakan berbahaya, seperti mencuri data atau mengubah perilaku sistem, tanpa sepengetahuan pengguna. Untuk informasi lebih lanjut tentang vektor serangan ini, lihat [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.id.png)

## Risiko  
Tindakan AI yang tidak diinginkan menghadirkan berbagai risiko keamanan yang meliputi pencurian data dan pelanggaran privasi.

### Kontrol Mitigasi  
### Menggunakan prompt shields untuk melindungi dari serangan Indirect Prompt Injection
-----------------------------------------------------------------------------

**AI Prompt Shields** adalah solusi yang dikembangkan oleh Microsoft untuk melindungi dari serangan prompt injection langsung dan tidak langsung. Mereka membantu melalui:

1.  **Deteksi dan Penyaringan**: Prompt Shields menggunakan algoritma pembelajaran mesin canggih dan pemrosesan bahasa alami untuk mendeteksi dan menyaring instruksi berbahaya yang disisipkan dalam konten eksternal, seperti dokumen, halaman web, atau email.
    
2.  **Spotlighting**: Teknik ini membantu sistem AI membedakan antara instruksi sistem yang valid dan input eksternal yang berpotensi tidak dapat dipercaya. Dengan mengubah teks input agar lebih relevan dengan model, Spotlighting memastikan AI dapat lebih baik mengenali dan mengabaikan instruksi berbahaya.
    
3.  **Delimiter dan Datamarking**: Menyertakan delimiter dalam pesan sistem secara eksplisit menunjukkan lokasi teks input, membantu sistem AI mengenali dan memisahkan input pengguna dari konten eksternal yang berpotensi berbahaya. Datamarking memperluas konsep ini dengan menggunakan penanda khusus untuk menyoroti batas data yang dipercaya dan tidak dipercaya.
    
4.  **Pemantauan dan Pembaruan Berkelanjutan**: Microsoft secara terus menerus memantau dan memperbarui Prompt Shields untuk mengatasi ancaman baru dan yang berkembang. Pendekatan proaktif ini memastikan pertahanan tetap efektif terhadap teknik serangan terbaru.
    
5. **Integrasi dengan Azure Content Safety:** Prompt Shields merupakan bagian dari suite Azure AI Content Safety yang lebih luas, yang menyediakan alat tambahan untuk mendeteksi upaya jailbreak, konten berbahaya, dan risiko keamanan lain dalam aplikasi AI.

Anda dapat membaca lebih lanjut tentang AI prompt shields di [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.id.png)

### Keamanan Rantai Pasokan

Keamanan rantai pasokan tetap fundamental di era AI, namun cakupan apa yang termasuk dalam rantai pasokan Anda telah berkembang. Selain paket kode tradisional, Anda sekarang harus secara ketat memverifikasi dan memantau semua komponen terkait AI, termasuk model dasar, layanan embedding, penyedia konteks, dan API pihak ketiga. Masing-masing dapat memperkenalkan kerentanan atau risiko jika tidak dikelola dengan benar.

**Praktik keamanan rantai pasokan kunci untuk AI dan MCP:**
- **Verifikasi semua komponen sebelum integrasi:** Ini tidak hanya mencakup pustaka open-source, tetapi juga model AI, sumber data, dan API eksternal. Selalu periksa asal-usul, lisensi, dan kerentanan yang diketahui.
- **Pertahankan pipeline deployment yang aman:** Gunakan pipeline CI/CD otomatis dengan pemindaian keamanan terintegrasi untuk mendeteksi masalah sejak dini. Pastikan hanya artefak yang terpercaya yang dideploy ke produksi.
- **Pantau dan audit secara terus-menerus:** Terapkan pemantauan berkelanjutan untuk semua dependensi, termasuk model dan layanan data, untuk mendeteksi kerentanan baru atau serangan rantai pasokan.
- **Terapkan prinsip least privilege dan kontrol akses:** Batasi akses ke model, data, dan layanan hanya pada yang diperlukan agar server MCP berfungsi.
- **Respons cepat terhadap ancaman:** Miliki proses untuk memperbaiki atau mengganti komponen yang dikompromikan, serta untuk merotasi rahasia atau kredensial jika terjadi pelanggaran.

[GitHub Advanced Security](https://github.com/security/advanced-security) menyediakan fitur seperti pemindaian rahasia, pemindaian dependensi, dan analisis CodeQL. Alat-alat ini terintegrasi dengan [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) dan [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) untuk membantu tim mengidentifikasi dan mengurangi kerentanan baik pada kode maupun komponen rantai pasokan AI.

Microsoft juga menerapkan praktik keamanan rantai pasokan yang luas secara internal untuk semua produk. Pelajari lebih lanjut di [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Praktik Keamanan Terbaik yang Sudah Mapan untuk Meningkatkan Postur Keamanan Implementasi MCP Anda

Setiap implementasi MCP mewarisi postur keamanan yang sudah ada dari lingkungan organisasi tempat ia dibangun, jadi saat mempertimbangkan keamanan MCP sebagai komponen sistem AI Anda secara keseluruhan, disarankan untuk meningkatkan postur keamanan yang sudah ada secara menyeluruh. Kontrol keamanan yang sudah mapan berikut ini sangat relevan:

- Praktik pengkodean aman dalam aplikasi AI Anda — melindungi terhadap [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 untuk LLM](https://genai.owasp.org/download/43299/?tmstv=1731900559), penggunaan vault yang aman untuk rahasia dan token, penerapan komunikasi aman end-to-end antar semua komponen aplikasi, dan sebagainya.
- Penguatan server — gunakan MFA jika memungkinkan, selalu lakukan patching terkini, integrasikan server dengan penyedia identitas pihak ketiga untuk akses, dan lain-lain.
- Jaga perangkat, infrastruktur, dan aplikasi tetap terbaru dengan patch.
- Pemantauan keamanan — terapkan logging dan monitoring pada aplikasi AI (termasuk klien/server MCP) dan kirim log tersebut ke SIEM pusat untuk mendeteksi aktivitas anomali.
- Arsitektur zero trust — isolasi komponen melalui kontrol jaringan dan identitas secara logis untuk meminimalkan pergerakan lateral jika aplikasi AI dikompromikan.

# Poin Penting

- Dasar keamanan tetap krusial: pengkodean aman, prinsip least privilege, verifikasi rantai pasokan, dan pemantauan berkelanjutan adalah esensial untuk MCP dan beban kerja AI.
- MCP memperkenalkan risiko baru—seperti prompt injection, tool poisoning, dan izin berlebihan—yang membutuhkan kontrol tradisional dan khusus AI.
- Gunakan praktik autentikasi, otorisasi, dan manajemen token yang kuat, memanfaatkan penyedia identitas eksternal seperti Microsoft Entra ID jika memungkinkan.
- Lindungi dari prompt injection tidak langsung dan tool poisoning dengan memvalidasi metadata alat, memantau perubahan dinamis, dan menggunakan solusi seperti Microsoft Prompt Shields.
- Perlakukan semua komponen dalam rantai pasokan AI Anda—termasuk model, embedding, dan penyedia konteks—dengan ketelitian yang sama seperti dependensi kode.
- Tetap ikuti perkembangan spesifikasi MCP dan berkontribusi pada komunitas untuk membantu membentuk standar keamanan.

# Sumber Tambahan

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers
- [OWASP Top 10 untuk LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Perjalanan untuk Mengamankan Rantai Pasokan Perangkat Lunak di Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Akses Least-Privileged yang Aman (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Praktik Terbaik untuk Validasi Token dan Masa Berlaku](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Gunakan Penyimpanan Token yang Aman dan Enkripsi Token (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management sebagai Gerbang Auth untuk MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Menggunakan Microsoft Entra ID untuk Otentikasi dengan Server MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Selanjutnya

Selanjutnya: [Bab 3: Memulai](/03-GettingStarted/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diingat bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang otoritatif. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.