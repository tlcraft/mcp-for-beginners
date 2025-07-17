<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "382fddb4ee4d9c1bdc806e2ee99b70c8",
  "translation_date": "2025-07-17T07:57:33+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "id"
}
-->
# Praktik Terbaik Keamanan

Mengadopsi Model Context Protocol (MCP) membawa kemampuan baru yang kuat untuk aplikasi berbasis AI, namun juga menghadirkan tantangan keamanan unik yang melampaui risiko perangkat lunak tradisional. Selain kekhawatiran yang sudah ada seperti pengkodean yang aman, prinsip hak akses minimum, dan keamanan rantai pasokan, MCP dan beban kerja AI menghadapi ancaman baru seperti prompt injection, tool poisoning, modifikasi alat dinamis, pembajakan sesi, serangan confused deputy, dan kerentanan token passthrough. Risiko-risiko ini dapat menyebabkan pencurian data, pelanggaran privasi, dan perilaku sistem yang tidak diinginkan jika tidak dikelola dengan baik.

Pelajaran ini membahas risiko keamanan paling relevan yang terkait dengan MCP—termasuk autentikasi, otorisasi, izin berlebihan, prompt injection tidak langsung, keamanan sesi, masalah confused deputy, kerentanan token passthrough, dan kerentanan rantai pasokan—serta memberikan kontrol dan praktik terbaik yang dapat diterapkan untuk menguranginya. Anda juga akan belajar bagaimana memanfaatkan solusi Microsoft seperti Prompt Shields, Azure Content Safety, dan GitHub Advanced Security untuk memperkuat implementasi MCP Anda. Dengan memahami dan menerapkan kontrol ini, Anda dapat secara signifikan mengurangi kemungkinan terjadinya pelanggaran keamanan dan memastikan sistem AI Anda tetap kuat dan dapat dipercaya.

# Tujuan Pembelajaran

Pada akhir pelajaran ini, Anda akan mampu:

- Mengidentifikasi dan menjelaskan risiko keamanan unik yang diperkenalkan oleh Model Context Protocol (MCP), termasuk prompt injection, tool poisoning, izin berlebihan, pembajakan sesi, masalah confused deputy, kerentanan token passthrough, dan kerentanan rantai pasokan.
- Mendeskripsikan dan menerapkan kontrol mitigasi yang efektif untuk risiko keamanan MCP, seperti autentikasi yang kuat, prinsip hak akses minimum, manajemen token yang aman, kontrol keamanan sesi, dan verifikasi rantai pasokan.
- Memahami dan memanfaatkan solusi Microsoft seperti Prompt Shields, Azure Content Safety, dan GitHub Advanced Security untuk melindungi MCP dan beban kerja AI.
- Mengenali pentingnya memvalidasi metadata alat, memantau perubahan dinamis, melindungi dari serangan prompt injection tidak langsung, dan mencegah pembajakan sesi.
- Mengintegrasikan praktik terbaik keamanan yang sudah mapan—seperti pengkodean aman, penguatan server, dan arsitektur zero trust—ke dalam implementasi MCP Anda untuk mengurangi kemungkinan dan dampak pelanggaran keamanan.

# Kontrol Keamanan MCP

Setiap sistem yang memiliki akses ke sumber daya penting memiliki tantangan keamanan tersirat. Tantangan keamanan umumnya dapat diatasi melalui penerapan yang tepat dari kontrol dan konsep keamanan dasar. Karena MCP baru saja didefinisikan, spesifikasinya berubah sangat cepat seiring evolusi protokol. Pada akhirnya, kontrol keamanan di dalamnya akan matang, memungkinkan integrasi yang lebih baik dengan arsitektur keamanan perusahaan dan praktik terbaik yang sudah mapan.

Penelitian yang dipublikasikan dalam [Microsoft Digital Defense Report](https://aka.ms/mddr) menyatakan bahwa 98% pelanggaran yang dilaporkan dapat dicegah dengan kebersihan keamanan yang kuat dan perlindungan terbaik terhadap segala jenis pelanggaran adalah dengan memastikan kebersihan keamanan dasar, praktik pengkodean aman, dan keamanan rantai pasokan sudah benar — praktik yang sudah teruji ini masih memberikan dampak terbesar dalam mengurangi risiko keamanan.

Mari kita lihat beberapa cara yang dapat Anda mulai lakukan untuk mengatasi risiko keamanan saat mengadopsi MCP.

> **Note:** Informasi berikut benar per **29 Mei 2025**. Protokol MCP terus berkembang, dan implementasi di masa depan mungkin memperkenalkan pola autentikasi dan kontrol baru. Untuk pembaruan dan panduan terbaru, selalu rujuk ke [Spesifikasi MCP](https://spec.modelcontextprotocol.io/) dan repositori resmi [MCP GitHub](https://github.com/modelcontextprotocol) serta [halaman praktik terbaik keamanan](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Pernyataan Masalah  
Spesifikasi MCP asli mengasumsikan bahwa pengembang akan menulis server autentikasi mereka sendiri. Ini membutuhkan pengetahuan tentang OAuth dan batasan keamanan terkait. Server MCP bertindak sebagai OAuth 2.0 Authorization Server, mengelola autentikasi pengguna secara langsung daripada mendelegasikannya ke layanan eksternal seperti Microsoft Entra ID. Per tanggal **26 April 2025**, pembaruan spesifikasi MCP memungkinkan server MCP mendelegasikan autentikasi pengguna ke layanan eksternal.

### Risiko
- Logika otorisasi yang salah konfigurasi di server MCP dapat menyebabkan paparan data sensitif dan penerapan kontrol akses yang keliru.
- Pencurian token OAuth di server MCP lokal. Jika token dicuri, token tersebut dapat digunakan untuk menyamar sebagai server MCP dan mengakses sumber daya serta data dari layanan yang token OAuth-nya dimaksudkan.

#### Token Passthrough  
Token passthrough secara eksplisit dilarang dalam spesifikasi otorisasi karena memperkenalkan sejumlah risiko keamanan, antara lain:

#### Penghindaran Kontrol Keamanan  
Server MCP atau API hilir mungkin menerapkan kontrol keamanan penting seperti pembatasan laju, validasi permintaan, atau pemantauan lalu lintas, yang bergantung pada audiens token atau batasan kredensial lainnya. Jika klien dapat memperoleh dan menggunakan token langsung dengan API hilir tanpa server MCP memvalidasi dengan benar atau memastikan token diterbitkan untuk layanan yang tepat, mereka melewati kontrol ini.

#### Masalah Akuntabilitas dan Jejak Audit  
Server MCP tidak dapat mengidentifikasi atau membedakan antara Klien MCP ketika klien memanggil dengan token akses yang diterbitkan dari hulu yang mungkin tidak transparan bagi server MCP.  
Log server Resource Server hilir mungkin menunjukkan permintaan yang tampak berasal dari sumber berbeda dengan identitas berbeda, bukan dari server MCP yang sebenarnya meneruskan token.  
Kedua faktor ini menyulitkan investigasi insiden, kontrol, dan audit.  
Jika server MCP meneruskan token tanpa memvalidasi klaimnya (misalnya, peran, hak istimewa, atau audiens) atau metadata lainnya, aktor jahat yang memiliki token curian dapat menggunakan server sebagai proxy untuk pencurian data.

#### Masalah Batas Kepercayaan  
Resource Server hilir memberikan kepercayaan kepada entitas tertentu. Kepercayaan ini mungkin mencakup asumsi tentang asal atau pola perilaku klien. Melanggar batas kepercayaan ini dapat menyebabkan masalah tak terduga.  
Jika token diterima oleh beberapa layanan tanpa validasi yang tepat, penyerang yang berhasil mengkompromikan satu layanan dapat menggunakan token tersebut untuk mengakses layanan lain yang terhubung.

#### Risiko Kompatibilitas Masa Depan  
Meskipun server MCP saat ini berfungsi sebagai "proxy murni", mungkin perlu menambahkan kontrol keamanan di kemudian hari. Memulai dengan pemisahan audiens token yang tepat memudahkan evolusi model keamanan.

### Kontrol Mitigasi

**Server MCP TIDAK BOLEH menerima token yang tidak secara eksplisit diterbitkan untuk server MCP**

- **Tinjau dan Perkuat Logika Otorisasi:** Audit dengan cermat implementasi otorisasi server MCP Anda untuk memastikan hanya pengguna dan klien yang dimaksudkan yang dapat mengakses sumber daya sensitif. Untuk panduan praktis, lihat [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) dan [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Terapkan Praktik Token yang Aman:** Ikuti [praktik terbaik Microsoft untuk validasi token dan masa berlaku](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) untuk mencegah penyalahgunaan token akses dan mengurangi risiko replay atau pencurian token.
- **Lindungi Penyimpanan Token:** Selalu simpan token dengan aman dan gunakan enkripsi untuk melindunginya saat disimpan dan dalam perjalanan. Untuk tips implementasi, lihat [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Izin Berlebihan untuk Server MCP

### Pernyataan Masalah  
Server MCP mungkin diberikan izin berlebihan terhadap layanan/sumber daya yang diaksesnya. Misalnya, server MCP yang merupakan bagian dari aplikasi penjualan AI yang terhubung ke penyimpanan data perusahaan seharusnya hanya memiliki akses terbatas pada data penjualan dan tidak diizinkan mengakses semua file di penyimpanan tersebut. Mengacu pada prinsip hak akses minimum (salah satu prinsip keamanan tertua), tidak ada sumber daya yang seharusnya memiliki izin melebihi yang diperlukan untuk menjalankan tugas yang dimaksudkan. AI menghadirkan tantangan tambahan di area ini karena untuk membuatnya fleksibel, sulit untuk menentukan izin yang tepat dibutuhkan.

### Risiko  
- Memberikan izin berlebihan dapat memungkinkan pencurian atau pengubahan data yang tidak seharusnya diakses oleh server MCP. Ini juga bisa menjadi masalah privasi jika data tersebut adalah informasi pribadi yang dapat diidentifikasi (PII).

### Kontrol Mitigasi  
- **Terapkan Prinsip Hak Akses Minimum:** Berikan server MCP hanya izin minimum yang diperlukan untuk menjalankan tugasnya. Tinjau dan perbarui izin ini secara berkala untuk memastikan tidak melebihi kebutuhan. Untuk panduan rinci, lihat [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Gunakan Role-Based Access Control (RBAC):** Tetapkan peran kepada server MCP yang dibatasi secara ketat pada sumber daya dan tindakan tertentu, hindari izin yang luas atau tidak perlu.
- **Pantau dan Audit Izin:** Pantau penggunaan izin secara terus-menerus dan audit log akses untuk mendeteksi dan memperbaiki hak istimewa yang berlebihan atau tidak terpakai dengan cepat.

# Serangan Prompt Injection Tidak Langsung

### Pernyataan Masalah

Server MCP yang berbahaya atau telah dikompromikan dapat menimbulkan risiko signifikan dengan mengekspos data pelanggan atau memungkinkan tindakan yang tidak diinginkan. Risiko ini sangat relevan dalam beban kerja AI dan berbasis MCP, di mana:

- **Serangan Prompt Injection:** Penyerang menyisipkan instruksi berbahaya dalam prompt atau konten eksternal, menyebabkan sistem AI melakukan tindakan yang tidak diinginkan atau membocorkan data sensitif. Pelajari lebih lanjut: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning:** Penyerang memanipulasi metadata alat (seperti deskripsi atau parameter) untuk memengaruhi perilaku AI, berpotensi melewati kontrol keamanan atau mencuri data. Detail: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Instruksi berbahaya disisipkan dalam dokumen, halaman web, atau email, yang kemudian diproses oleh AI, menyebabkan kebocoran atau manipulasi data.
- **Modifikasi Alat Dinamis (Rug Pulls):** Definisi alat dapat diubah setelah persetujuan pengguna, memperkenalkan perilaku berbahaya baru tanpa sepengetahuan pengguna.

Kerentanan ini menyoroti kebutuhan akan validasi yang kuat, pemantauan, dan kontrol keamanan saat mengintegrasikan server MCP dan alat ke lingkungan Anda. Untuk penjelasan lebih mendalam, lihat referensi yang terhubung di atas.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.id.png)

**Indirect Prompt Injection** (juga dikenal sebagai cross-domain prompt injection atau XPIA) adalah kerentanan kritis dalam sistem AI generatif, termasuk yang menggunakan Model Context Protocol (MCP). Dalam serangan ini, instruksi berbahaya disembunyikan dalam konten eksternal—seperti dokumen, halaman web, atau email. Ketika sistem AI memproses konten ini, ia mungkin mengartikan instruksi yang disisipkan sebagai perintah pengguna yang sah, mengakibatkan tindakan yang tidak diinginkan seperti kebocoran data, pembuatan konten berbahaya, atau manipulasi interaksi pengguna. Untuk penjelasan rinci dan contoh nyata, lihat [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Bentuk serangan yang sangat berbahaya adalah **Tool Poisoning**. Di sini, penyerang menyisipkan instruksi berbahaya ke dalam metadata alat MCP (seperti deskripsi alat atau parameter). Karena model bahasa besar (LLM) mengandalkan metadata ini untuk memutuskan alat mana yang akan dipanggil, deskripsi yang dikompromikan dapat menipu model agar menjalankan panggilan alat yang tidak sah atau melewati kontrol keamanan. Manipulasi ini sering tidak terlihat oleh pengguna akhir tetapi dapat diinterpretasikan dan dijalankan oleh sistem AI. Risiko ini meningkat di lingkungan server MCP yang dihosting, di mana definisi alat dapat diperbarui setelah persetujuan pengguna—situasi yang kadang disebut sebagai "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Dalam kasus seperti ini, alat yang sebelumnya aman dapat diubah untuk melakukan tindakan berbahaya, seperti mencuri data atau mengubah perilaku sistem, tanpa sepengetahuan pengguna. Untuk lebih lanjut tentang vektor serangan ini, lihat [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.id.png)

## Risiko  
Tindakan AI yang tidak diinginkan menghadirkan berbagai risiko keamanan yang meliputi pencurian data dan pelanggaran privasi.

### Kontrol Mitigasi  
### Menggunakan prompt shields untuk melindungi dari serangan Indirect Prompt Injection  
-----------------------------------------------------------------------------

**AI Prompt Shields** adalah solusi yang dikembangkan oleh Microsoft untuk melindungi dari serangan prompt injection langsung maupun tidak langsung. Mereka membantu melalui:

1.  **Deteksi dan Penyaringan:** Prompt Shields menggunakan algoritma pembelajaran mesin canggih dan pemrosesan bahasa alami untuk mendeteksi dan menyaring instruksi berbahaya yang disisipkan dalam konten eksternal, seperti dokumen, halaman web, atau email.
    
2.  **Spotlighting:** Teknik ini membantu sistem AI membedakan antara instruksi sistem yang valid dan input eksternal yang berpotensi tidak dapat dipercaya. Dengan mengubah teks input agar lebih relevan bagi model, Spotlighting memastikan AI dapat lebih baik mengidentifikasi dan mengabaikan instruksi berbahaya.
    
3.  **Delimiter dan Datamarking:** Menyertakan delimiter dalam pesan sistem secara eksplisit menunjukkan lokasi teks input, membantu sistem AI mengenali dan memisahkan input pengguna dari konten eksternal yang berpotensi berbahaya. Datamarking memperluas konsep ini dengan menggunakan penanda khusus untuk menyoroti batas data yang dipercaya dan tidak dipercaya.
    
4.  **Pemantauan dan Pembaruan Berkelanjutan:** Microsoft secara terus-menerus memantau dan memperbarui Prompt Shields untuk mengatasi ancaman baru dan yang berkembang. Pendekatan proaktif ini memastikan pertahanan tetap efektif terhadap teknik serangan terbaru.
    
5. **Integrasi dengan Azure Content Safety:** Prompt Shields merupakan bagian dari rangkaian Azure AI Content Safety yang lebih luas, yang menyediakan alat tambahan untuk mendeteksi upaya jailbreak, konten berbahaya, dan risiko keamanan lainnya dalam aplikasi AI.

Anda dapat membaca lebih lanjut tentang AI prompt shields di [dokumentasi Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.id.png)

# Masalah Confused Deputy

### Pernyataan Masalah
Masalah confused deputy adalah kerentanan keamanan yang terjadi ketika server MCP bertindak sebagai perantara antara klien MCP dan API pihak ketiga. Kerentanan ini dapat dieksploitasi ketika server MCP menggunakan client ID statis untuk mengautentikasi dengan server otorisasi pihak ketiga yang tidak mendukung pendaftaran klien dinamis.

### Risiko

- **Bypass persetujuan berbasis cookie**: Jika pengguna sebelumnya telah mengautentikasi melalui server proxy MCP, server otorisasi pihak ketiga mungkin menetapkan cookie persetujuan di browser pengguna. Penyerang kemudian dapat mengeksploitasi ini dengan mengirimkan tautan berbahaya yang berisi permintaan otorisasi dengan redirect URI yang dibuat khusus.
- **Pencurian kode otorisasi**: Ketika pengguna mengklik tautan berbahaya, server otorisasi pihak ketiga mungkin melewati layar persetujuan karena cookie yang ada, dan kode otorisasi dapat diarahkan ke server penyerang.
- **Akses API tanpa izin**: Penyerang dapat menukar kode otorisasi yang dicuri dengan token akses dan menyamar sebagai pengguna untuk mengakses API pihak ketiga tanpa persetujuan eksplisit.

### Kontrol mitigasi

- **Persyaratan persetujuan eksplisit**: Server proxy MCP yang menggunakan client ID statis **HARUS** mendapatkan persetujuan pengguna untuk setiap klien yang didaftarkan secara dinamis sebelum meneruskan ke server otorisasi pihak ketiga.
- **Implementasi OAuth yang tepat**: Ikuti praktik keamanan terbaik OAuth 2.1, termasuk menggunakan code challenge (PKCE) untuk permintaan otorisasi guna mencegah serangan penyadapan.
- **Validasi klien**: Terapkan validasi ketat terhadap redirect URI dan identifier klien untuk mencegah eksploitasi oleh aktor jahat.


# Kerentanan Token Passthrough

### Pernyataan masalah

"Token passthrough" adalah pola buruk di mana server MCP menerima token dari klien MCP tanpa memvalidasi bahwa token tersebut benar-benar diterbitkan untuk server MCP itu sendiri, lalu "meneruskannya" ke API hilir. Praktik ini secara eksplisit melanggar spesifikasi otorisasi MCP dan menimbulkan risiko keamanan serius.

### Risiko

- **Penghindaran kontrol keamanan**: Klien dapat melewati kontrol keamanan penting seperti pembatasan laju, validasi permintaan, atau pemantauan lalu lintas jika mereka dapat menggunakan token langsung dengan API hilir tanpa validasi yang tepat.
- **Masalah akuntabilitas dan jejak audit**: Server MCP tidak dapat mengidentifikasi atau membedakan antara klien MCP ketika klien menggunakan token akses yang diterbitkan dari hulu, sehingga investigasi insiden dan audit menjadi lebih sulit.
- **Eksfiltrasi data**: Jika token diteruskan tanpa validasi klaim yang tepat, aktor jahat dengan token yang dicuri dapat menggunakan server sebagai proxy untuk eksfiltrasi data.
- **Pelanggaran batas kepercayaan**: Server sumber daya hilir mungkin memberikan kepercayaan kepada entitas tertentu dengan asumsi asal atau pola perilaku. Melanggar batas kepercayaan ini dapat menyebabkan masalah keamanan yang tidak terduga.
- **Penyalahgunaan token multi-layanan**: Jika token diterima oleh beberapa layanan tanpa validasi yang tepat, penyerang yang berhasil mengkompromikan satu layanan dapat menggunakan token tersebut untuk mengakses layanan lain yang terhubung.

### Kontrol mitigasi

- **Validasi token**: Server MCP **TIDAK BOLEH** menerima token yang tidak secara eksplisit diterbitkan untuk server MCP itu sendiri.
- **Verifikasi audiens**: Selalu validasi bahwa token memiliki klaim audiens yang sesuai dengan identitas server MCP.
- **Manajemen siklus hidup token yang tepat**: Terapkan token akses dengan masa berlaku singkat dan praktik rotasi token yang benar untuk mengurangi risiko pencurian dan penyalahgunaan token.


# Pembajakan Sesi

### Pernyataan masalah

Pembajakan sesi adalah vektor serangan di mana klien diberikan ID sesi oleh server, dan pihak yang tidak berwenang memperoleh dan menggunakan ID sesi yang sama untuk menyamar sebagai klien asli dan melakukan tindakan tanpa izin atas nama mereka. Ini sangat mengkhawatirkan pada server HTTP stateful yang menangani permintaan MCP.

### Risiko

- **Injeksi prompt pembajakan sesi**: Penyerang yang memperoleh ID sesi dapat mengirimkan event berbahaya ke server yang berbagi status sesi dengan server tempat klien terhubung, yang berpotensi memicu tindakan berbahaya atau mengakses data sensitif.
- **Penyamaran pembajakan sesi**: Penyerang dengan ID sesi yang dicuri dapat melakukan panggilan langsung ke server MCP, melewati autentikasi dan diperlakukan sebagai pengguna sah.
- **Aliran yang dapat dilanjutkan yang dikompromikan**: Ketika server mendukung pengiriman ulang/aliran yang dapat dilanjutkan, penyerang dapat menghentikan permintaan secara prematur, yang kemudian dilanjutkan oleh klien asli dengan konten yang berpotensi berbahaya.

### Kontrol mitigasi

- **Verifikasi otorisasi**: Server MCP yang menerapkan otorisasi **HARUS** memverifikasi semua permintaan masuk dan **TIDAK BOLEH** menggunakan sesi untuk autentikasi.
- **ID sesi yang aman**: Server MCP **HARUS** menggunakan ID sesi yang aman dan tidak deterministik yang dihasilkan dengan generator angka acak yang aman. Hindari identifier yang dapat diprediksi atau berurutan.
- **Pengikatan sesi spesifik pengguna**: Server MCP **SEBAIKNYA** mengikat ID sesi dengan informasi spesifik pengguna, menggabungkan ID sesi dengan informasi unik pengguna yang berwenang (seperti user ID internal) menggunakan format seperti `
<user_id>:<session_id>`.
- **Kadaluarsa sesi**: Terapkan kadaluarsa dan rotasi sesi yang tepat untuk membatasi jendela kerentanan jika ID sesi dikompromikan.
- **Keamanan transportasi**: Selalu gunakan HTTPS untuk semua komunikasi guna mencegah penyadapan ID sesi.


# Keamanan rantai pasokan

Keamanan rantai pasokan tetap menjadi hal mendasar di era AI, namun cakupan apa yang termasuk dalam rantai pasokan Anda telah meluas. Selain paket kode tradisional, Anda sekarang harus secara ketat memverifikasi dan memantau semua komponen terkait AI, termasuk model dasar, layanan embeddings, penyedia konteks, dan API pihak ketiga. Masing-masing dapat memperkenalkan kerentanan atau risiko jika tidak dikelola dengan baik.

**Praktik keamanan rantai pasokan utama untuk AI dan MCP:**
- **Verifikasi semua komponen sebelum integrasi:** Ini tidak hanya mencakup pustaka open-source, tetapi juga model AI, sumber data, dan API eksternal. Selalu periksa asal-usul, lisensi, dan kerentanan yang diketahui.
- **Pertahankan pipeline deployment yang aman:** Gunakan pipeline CI/CD otomatis dengan pemindaian keamanan terintegrasi untuk mendeteksi masalah sejak dini. Pastikan hanya artefak terpercaya yang dideploy ke produksi.
- **Pantau dan audit secara berkelanjutan:** Terapkan pemantauan berkelanjutan untuk semua dependensi, termasuk model dan layanan data, untuk mendeteksi kerentanan baru atau serangan rantai pasokan.
- **Terapkan prinsip least privilege dan kontrol akses:** Batasi akses ke model, data, dan layanan hanya pada yang diperlukan agar server MCP berfungsi.
- **Respons cepat terhadap ancaman:** Miliki proses untuk patching atau penggantian komponen yang dikompromikan, serta rotasi rahasia atau kredensial jika terjadi pelanggaran.

[GitHub Advanced Security](https://github.com/security/advanced-security) menyediakan fitur seperti pemindaian rahasia, pemindaian dependensi, dan analisis CodeQL. Alat ini terintegrasi dengan [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) dan [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) untuk membantu tim mengidentifikasi dan mengurangi kerentanan di kode dan komponen rantai pasokan AI.

Microsoft juga menerapkan praktik keamanan rantai pasokan yang luas secara internal untuk semua produk. Pelajari lebih lanjut di [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Praktik keamanan terbaik yang sudah mapan untuk meningkatkan postur keamanan implementasi MCP Anda

Setiap implementasi MCP mewarisi postur keamanan yang sudah ada dari lingkungan organisasi tempat ia dibangun, jadi saat mempertimbangkan keamanan MCP sebagai komponen dari sistem AI Anda secara keseluruhan, disarankan untuk meningkatkan postur keamanan yang sudah ada. Kontrol keamanan yang sudah mapan berikut sangat relevan:

- Praktik pengkodean aman di aplikasi AI Anda - lindungi dari [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 untuk LLM](https://genai.owasp.org/download/43299/?tmstv=1731900559), penggunaan vault aman untuk rahasia dan token, menerapkan komunikasi aman end-to-end antar semua komponen aplikasi, dll.
- Penguatan server -- gunakan MFA jika memungkinkan, selalu perbarui patch, integrasikan server dengan penyedia identitas pihak ketiga untuk akses, dll.
- Jaga perangkat, infrastruktur, dan aplikasi tetap terbaru dengan patch
- Pemantauan keamanan -- terapkan logging dan pemantauan aplikasi AI (termasuk klien/server MCP) dan kirim log tersebut ke SIEM pusat untuk mendeteksi aktivitas anomali
- Arsitektur zero trust -- isolasi komponen melalui kontrol jaringan dan identitas secara logis untuk meminimalkan pergerakan lateral jika aplikasi AI dikompromikan.

# Poin Penting

- Dasar keamanan tetap krusial: Pengkodean aman, prinsip least privilege, verifikasi rantai pasokan, dan pemantauan berkelanjutan sangat penting untuk beban kerja MCP dan AI.
- MCP memperkenalkan risiko baru—seperti injeksi prompt, keracunan alat, pembajakan sesi, masalah confused deputy, kerentanan token passthrough, dan izin berlebihan—yang memerlukan kontrol tradisional dan khusus AI.
- Gunakan praktik autentikasi, otorisasi, dan manajemen token yang kuat, memanfaatkan penyedia identitas eksternal seperti Microsoft Entra ID jika memungkinkan.
- Lindungi dari injeksi prompt tidak langsung dan keracunan alat dengan memvalidasi metadata alat, memantau perubahan dinamis, dan menggunakan solusi seperti Microsoft Prompt Shields.
- Terapkan manajemen sesi yang aman dengan menggunakan ID sesi non-deterministik, mengikat sesi ke identitas pengguna, dan jangan pernah menggunakan sesi untuk autentikasi.
- Cegah serangan confused deputy dengan mewajibkan persetujuan pengguna eksplisit untuk setiap klien yang didaftarkan secara dinamis dan menerapkan praktik keamanan OAuth yang tepat.
- Hindari kerentanan token passthrough dengan memastikan server MCP hanya menerima token yang secara eksplisit diterbitkan untuk mereka dan memvalidasi klaim token dengan benar.
- Perlakukan semua komponen dalam rantai pasokan AI Anda—termasuk model, embeddings, dan penyedia konteks—dengan ketelitian yang sama seperti dependensi kode.
- Tetap ikuti perkembangan spesifikasi MCP dan berkontribusi ke komunitas untuk membantu membentuk standar yang aman.

# Sumber Daya Tambahan

## Sumber Daya Eksternal
- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields Documentation (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

## Dokumen Keamanan Tambahan

Untuk panduan keamanan yang lebih rinci, silakan merujuk ke dokumen-dokumen berikut:

- [MCP Security Best Practices 2025](./mcp-security-best-practices-2025.md) - Daftar lengkap praktik keamanan terbaik untuk implementasi MCP
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md) - Contoh implementasi integrasi Azure Content Safety dengan server MCP
- [MCP Security Controls 2025](./mcp-security-controls-2025.md) - Kontrol dan teknik keamanan terbaru untuk mengamankan deployment MCP
- [MCP Best Practices](./mcp-best-practices.md) - Panduan referensi cepat untuk keamanan MCP

### Selanjutnya

Selanjutnya: [Bab 3: Memulai](../03-GettingStarted/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk mencapai akurasi, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.