<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-17T07:13:31+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "mo"
}
-->
# Best Practices for Security

Mengadopsi Model Context Protocol (MCP) memberikan kemampuan baru yang kuat untuk aplikasi yang didorong AI, tetapi juga memperkenalkan tantangan keamanan unik yang melampaui risiko perangkat lunak tradisional. Selain kekhawatiran yang sudah ada seperti pengkodean aman, prinsip hak istimewa minimal, dan keamanan rantai pasokan, MCP dan beban kerja AI menghadapi ancaman baru seperti penyuntikan prompt, peracunan alat, dan modifikasi alat dinamis. Risiko ini dapat menyebabkan pengambilan data, pelanggaran privasi, dan perilaku sistem yang tidak diinginkan jika tidak dikelola dengan baik.

Pelajaran ini mengeksplorasi risiko keamanan paling relevan yang terkait dengan MCP—termasuk otentikasi, otorisasi, izin berlebih, penyuntikan prompt tidak langsung, dan kerentanan rantai pasokan—dan memberikan kontrol yang dapat diambil dan praktik terbaik untuk menguranginya. Anda juga akan belajar bagaimana memanfaatkan solusi Microsoft seperti Prompt Shields, Azure Content Safety, dan GitHub Advanced Security untuk memperkuat implementasi MCP Anda. Dengan memahami dan menerapkan kontrol ini, Anda dapat secara signifikan mengurangi kemungkinan pelanggaran keamanan dan memastikan sistem AI Anda tetap kuat dan dapat dipercaya.

# Tujuan Pembelajaran

Pada akhir pelajaran ini, Anda akan dapat:

- Mengidentifikasi dan menjelaskan risiko keamanan unik yang diperkenalkan oleh Model Context Protocol (MCP), termasuk penyuntikan prompt, peracunan alat, izin berlebih, dan kerentanan rantai pasokan.
- Mendeskripsikan dan menerapkan kontrol mitigasi efektif untuk risiko keamanan MCP, seperti otentikasi yang kuat, prinsip hak istimewa minimal, manajemen token yang aman, dan verifikasi rantai pasokan.
- Memahami dan memanfaatkan solusi Microsoft seperti Prompt Shields, Azure Content Safety, dan GitHub Advanced Security untuk melindungi beban kerja MCP dan AI.
- Mengenali pentingnya memvalidasi metadata alat, memantau perubahan dinamis, dan mempertahankan diri terhadap serangan penyuntikan prompt tidak langsung.
- Mengintegrasikan praktik keamanan terbaik yang sudah ada—seperti pengkodean aman, penguatan server, dan arsitektur zero trust—ke dalam implementasi MCP Anda untuk mengurangi kemungkinan dan dampak pelanggaran keamanan.

# Kontrol keamanan MCP

Setiap sistem yang memiliki akses ke sumber daya penting memiliki tantangan keamanan yang tersirat. Tantangan keamanan umumnya dapat diatasi melalui penerapan yang tepat dari kontrol dan konsep keamanan dasar. Karena MCP baru saja didefinisikan, spesifikasinya berubah dengan sangat cepat dan seiring evolusi protokol. Akhirnya, kontrol keamanan di dalamnya akan matang, memungkinkan integrasi yang lebih baik dengan arsitektur keamanan perusahaan dan praktik terbaik yang sudah ada.

Penelitian yang diterbitkan dalam [Laporan Pertahanan Digital Microsoft](https://aka.ms/mddr) menyatakan bahwa 98% dari pelanggaran yang dilaporkan dapat dicegah oleh kebersihan keamanan yang kuat dan perlindungan terbaik terhadap segala jenis pelanggaran adalah mendapatkan kebersihan keamanan dasar Anda, praktik terbaik pengkodean aman dan keamanan rantai pasokan dengan benar -- praktik yang sudah dicoba dan diuji yang kita sudah tahu masih memberikan dampak paling besar dalam mengurangi risiko keamanan.

Mari kita lihat beberapa cara Anda dapat mulai mengatasi risiko keamanan saat mengadopsi MCP.

# Otentikasi server MCP (jika implementasi MCP Anda sebelum 26 April 2025)

### Pernyataan masalah 
Spesifikasi MCP asli mengasumsikan bahwa pengembang akan menulis server otentikasi mereka sendiri. Ini memerlukan pengetahuan tentang OAuth dan batasan keamanan terkait. Server MCP bertindak sebagai Server Otorisasi OAuth 2.0, mengelola otentikasi pengguna yang diperlukan secara langsung daripada mendelegasikannya ke layanan eksternal seperti Microsoft Entra ID. Mulai 26 April 2025, pembaruan spesifikasi MCP memungkinkan server MCP untuk mendelegasikan otentikasi pengguna ke layanan eksternal.

### Risiko
- Logika otorisasi yang salah dikonfigurasi dalam server MCP dapat menyebabkan paparan data sensitif dan penerapan kontrol akses yang salah.
- Pencurian token OAuth pada server MCP lokal. Jika dicuri, token tersebut kemudian dapat digunakan untuk menyamar sebagai server MCP dan mengakses sumber daya dan data dari layanan yang token OAuth-nya.

### Kontrol mitigasi
- **Tinjau dan Perkuat Logika Otorisasi:** Audit dengan hati-hati implementasi otorisasi server MCP Anda untuk memastikan hanya pengguna dan klien yang dimaksudkan yang dapat mengakses sumber daya sensitif.
- **Terapkan Praktik Token Aman:** Ikuti [praktik terbaik Microsoft untuk validasi dan masa berlaku token](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) untuk mencegah penyalahgunaan token akses dan mengurangi risiko pemutaran ulang atau pencurian token.
- **Lindungi Penyimpanan Token:** Selalu simpan token dengan aman dan gunakan enkripsi untuk melindunginya saat tidak digunakan dan dalam perjalanan.

# Izin berlebih untuk server MCP

### Pernyataan masalah
Server MCP mungkin telah diberikan izin berlebih ke layanan/sumber daya yang mereka akses. Misalnya, server MCP yang merupakan bagian dari aplikasi penjualan AI yang terhubung ke penyimpanan data perusahaan harus memiliki akses yang dibatasi pada data penjualan dan tidak diizinkan mengakses semua file dalam penyimpanan. Mengacu kembali pada prinsip hak istimewa minimal (salah satu prinsip keamanan tertua), tidak ada sumber daya yang harus memiliki izin melebihi apa yang diperlukan untuk melaksanakan tugas yang dimaksudkan. AI menghadirkan tantangan yang meningkat di ruang ini karena untuk memungkinkannya menjadi fleksibel, sulit untuk mendefinisikan izin yang tepat yang diperlukan.

### Risiko 
- Memberikan izin berlebih dapat memungkinkan pengambilan atau pengubahan data yang tidak dimaksudkan untuk diakses oleh server MCP. Ini juga bisa menjadi masalah privasi jika data tersebut adalah informasi pribadi yang dapat diidentifikasi (PII).

### Kontrol mitigasi
- **Terapkan Prinsip Hak Istimewa Minimal:** Berikan server MCP hanya izin minimum yang diperlukan untuk melaksanakan tugas yang diperlukan. Tinjau dan perbarui izin ini secara berkala untuk memastikan mereka tidak melebihi apa yang dibutuhkan.
- **Gunakan Kontrol Akses Berbasis Peran (RBAC):** Tetapkan peran ke server MCP yang dibatasi secara ketat pada sumber daya dan tindakan tertentu, menghindari izin yang luas atau tidak perlu.
- **Pantau dan Audit Izin:** Terus pantau penggunaan izin dan audit log akses untuk mendeteksi dan memperbaiki hak istimewa yang berlebih atau tidak terpakai dengan cepat.

# Serangan penyuntikan prompt tidak langsung

### Pernyataan masalah

Server MCP yang berbahaya atau terkompromi dapat memperkenalkan risiko signifikan dengan mengekspos data pelanggan atau memungkinkan tindakan yang tidak diinginkan. Risiko ini sangat relevan dalam beban kerja berbasis AI dan MCP, di mana:

- **Serangan Penyuntikan Prompt**: Penyerang menanamkan instruksi berbahaya dalam prompt atau konten eksternal, menyebabkan sistem AI melakukan tindakan yang tidak diinginkan atau membocorkan data sensitif.
- **Peracunan Alat**: Penyerang memanipulasi metadata alat (seperti deskripsi atau parameter) untuk mempengaruhi perilaku AI, berpotensi melewati kontrol keamanan atau mengeluarkan data.
- **Penyuntikan Prompt Lintas Domain**: Instruksi berbahaya disematkan dalam dokumen, halaman web, atau email, yang kemudian diproses oleh AI, menyebabkan kebocoran atau manipulasi data.
- **Modifikasi Alat Dinamis (Rug Pulls)**: Definisi alat dapat diubah setelah persetujuan pengguna, memperkenalkan perilaku berbahaya baru tanpa kesadaran pengguna.

Kerentanan ini menyoroti perlunya validasi, pemantauan, dan kontrol keamanan yang kuat saat mengintegrasikan server dan alat MCP ke dalam lingkungan Anda.

**Penyuntikan Prompt Tidak Langsung** (juga dikenal sebagai penyuntikan prompt lintas domain atau XPIA) adalah kerentanan kritis dalam sistem AI generatif, termasuk yang menggunakan Model Context Protocol (MCP). Dalam serangan ini, instruksi berbahaya disembunyikan dalam konten eksternal—seperti dokumen, halaman web, atau email. Ketika sistem AI memproses konten ini, ia dapat menafsirkan instruksi yang disematkan sebagai perintah pengguna yang sah, mengakibatkan tindakan yang tidak diinginkan seperti kebocoran data, pembuatan konten berbahaya, atau manipulasi interaksi pengguna.

Bentuk serangan ini yang sangat berbahaya adalah **Peracunan Alat**. Di sini, penyerang menyuntikkan instruksi berbahaya ke dalam metadata alat MCP (seperti deskripsi atau parameter alat). Karena model bahasa besar (LLM) mengandalkan metadata ini untuk memutuskan alat mana yang akan dipanggil, deskripsi yang terkompromi dapat menipu model untuk mengeksekusi panggilan alat yang tidak sah atau melewati kontrol keamanan. Manipulasi ini sering kali tidak terlihat oleh pengguna akhir tetapi dapat ditafsirkan dan ditindaklanjuti oleh sistem AI. Risiko ini meningkat di lingkungan server MCP yang dihosting, di mana definisi alat dapat diperbarui setelah persetujuan pengguna—skenario yang kadang-kadang disebut sebagai "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Dalam kasus seperti itu, alat yang sebelumnya aman dapat kemudian dimodifikasi untuk melakukan tindakan berbahaya, seperti mengeluarkan data atau mengubah perilaku sistem, tanpa pengetahuan pengguna.

## Risiko
Tindakan AI yang tidak diinginkan menghadirkan berbagai risiko keamanan yang mencakup pengambilan data dan pelanggaran privasi.

### Kontrol mitigasi
### Menggunakan prompt shields untuk melindungi dari serangan Penyuntikan Prompt Tidak Langsung

**AI Prompt Shields** adalah solusi yang dikembangkan oleh Microsoft untuk mempertahankan diri dari serangan penyuntikan prompt langsung dan tidak langsung. Mereka membantu melalui:

1. **Deteksi dan Penyaringan**: Prompt Shields menggunakan algoritma pembelajaran mesin lanjutan dan pemrosesan bahasa alami untuk mendeteksi dan menyaring instruksi berbahaya yang disematkan dalam konten eksternal, seperti dokumen, halaman web, atau email.

2. **Spotlighting**: Teknik ini membantu sistem AI membedakan antara instruksi sistem yang valid dan input eksternal yang berpotensi tidak dapat dipercaya. Dengan mengubah teks input dengan cara yang lebih relevan dengan model, Spotlighting memastikan bahwa AI dapat lebih baik mengidentifikasi dan mengabaikan instruksi berbahaya.

3. **Pembatas dan Penandaan Data**: Menyertakan pembatas dalam pesan sistem secara eksplisit menguraikan lokasi teks input, membantu sistem AI mengenali dan memisahkan input pengguna dari konten eksternal yang berpotensi berbahaya. Penandaan data memperluas konsep ini dengan menggunakan penanda khusus untuk menyoroti batas data yang tepercaya dan tidak tepercaya.

4. **Pemantauan dan Pembaruan Berkelanjutan**: Microsoft terus memantau dan memperbarui Prompt Shields untuk mengatasi ancaman baru dan yang berkembang. Pendekatan proaktif ini memastikan bahwa pertahanan tetap efektif terhadap teknik serangan terbaru.

5. **Integrasi dengan Azure Content Safety:** Prompt Shields adalah bagian dari rangkaian Azure AI Content Safety yang lebih luas, yang menyediakan alat tambahan untuk mendeteksi upaya jailbreak, konten berbahaya, dan risiko keamanan lainnya dalam aplikasi AI.

Anda dapat membaca lebih lanjut tentang AI prompt shields dalam [dokumentasi Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

### Keamanan rantai pasokan

Keamanan rantai pasokan tetap fundamental di era AI, tetapi cakupan apa yang merupakan rantai pasokan Anda telah berkembang. Selain paket kode tradisional, Anda sekarang harus memverifikasi dan memantau semua komponen terkait AI secara ketat, termasuk model dasar, layanan embedding, penyedia konteks, dan API pihak ketiga. Masing-masing ini dapat memperkenalkan kerentanan atau risiko jika tidak dikelola dengan baik.

**Praktik keamanan rantai pasokan utama untuk AI dan MCP:**
- **Verifikasi semua komponen sebelum integrasi:** Ini mencakup tidak hanya perpustakaan sumber terbuka, tetapi juga model AI, sumber data, dan API eksternal. Selalu periksa asal, lisensi, dan kerentanan yang diketahui.
- **Pertahankan pipeline penerapan yang aman:** Gunakan pipeline CI/CD otomatis dengan pemindaian keamanan terintegrasi untuk menangkap masalah sejak dini. Pastikan hanya artefak tepercaya yang diterapkan ke produksi.
- **Pantau dan audit secara terus-menerus:** Terapkan pemantauan berkelanjutan untuk semua dependensi, termasuk model dan layanan data, untuk mendeteksi kerentanan baru atau serangan rantai pasokan.
- **Terapkan prinsip hak istimewa minimal dan kontrol akses:** Batasi akses ke model, data, dan layanan hanya pada apa yang diperlukan agar server MCP Anda berfungsi.
- **Respons cepat terhadap ancaman:** Miliki proses untuk menambal atau mengganti komponen yang terkompromi, dan untuk memutar ulang rahasia atau kredensial jika terdeteksi pelanggaran.

[GitHub Advanced Security](https://github.com/security/advanced-security) menyediakan fitur seperti pemindaian rahasia, pemindaian dependensi, dan analisis CodeQL. Alat-alat ini terintegrasi dengan [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) dan [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) untuk membantu tim mengidentifikasi dan mengurangi kerentanan di seluruh komponen rantai pasokan kode dan AI.

Microsoft juga menerapkan praktik keamanan rantai pasokan yang luas secara internal untuk semua produk. Pelajari lebih lanjut di [Perjalanan untuk Mengamankan Rantai Pasokan Perangkat Lunak di Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Praktik keamanan yang sudah ada yang akan meningkatkan postur keamanan implementasi MCP Anda

Setiap implementasi MCP mewarisi postur keamanan yang ada dari lingkungan organisasi Anda yang dibangunnya, jadi ketika mempertimbangkan keamanan MCP sebagai komponen dari keseluruhan sistem AI Anda, disarankan agar Anda melihat untuk meningkatkan postur keamanan yang sudah ada secara keseluruhan. Kontrol keamanan yang sudah ada berikut ini sangat relevan:

- Praktik terbaik pengkodean aman dalam aplikasi AI Anda - lindungi dari [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 untuk LLM](https://genai.owasp.org/download/43299/?tmstv=1731900559), penggunaan brankas aman untuk rahasia dan token, menerapkan komunikasi aman end-to-end antara semua komponen aplikasi, dll.
- Penguatan server -- gunakan MFA jika memungkinkan, pertahankan patching tetap terbaru, integrasikan server dengan penyedia identitas pihak ketiga untuk akses, dll.
- Jaga perangkat, infrastruktur, dan aplikasi tetap terbaru dengan patch
- Pemantauan keamanan -- menerapkan logging dan pemantauan aplikasi AI (termasuk klien/server MCP) dan mengirimkan log tersebut ke SIEM pusat untuk mendeteksi aktivitas anomali
- Arsitektur zero trust -- mengisolasi komponen melalui kontrol jaringan dan identitas secara logis untuk meminimalkan pergerakan lateral jika aplikasi AI dikompromikan.

# Poin Penting

- Prinsip dasar keamanan tetap penting: Pengkodean aman, prinsip hak istimewa minimal, verifikasi rantai pasokan, dan pemantauan berkelanjutan adalah penting untuk beban kerja MCP dan AI.
- MCP memperkenalkan risiko baru—seperti penyuntikan prompt, peracunan alat, dan izin berlebih—yang memerlukan kontrol tradisional dan khusus AI.
- Gunakan praktik otentikasi, otorisasi, dan manajemen token yang kuat, memanfaatkan penyedia identitas eksternal seperti Microsoft Entra ID jika memungkinkan.
- Lindungi dari penyuntikan prompt tidak langsung dan peracunan alat dengan memvalidasi metadata alat, memantau perubahan dinamis, dan menggunakan solusi seperti Microsoft Prompt Shields.
- Perlakukan semua komponen dalam rantai pasokan AI Anda—termasuk model, embedding, dan penyedia konteks—dengan ketelitian yang sama seperti ketergantungan kode.
- Tetap terkini dengan spesifikasi MCP yang berkembang dan berkontribusi ke komunitas untuk membantu membentuk standar yang aman.

# Sumber Daya Tambahan

- [Laporan Pertahanan Digital Microsoft](https://aka.ms/mddr)
- [Spesifikasi MCP](https://spec.modelcontextprotocol.io/)
- [Penyuntikan Prompt dalam MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Serangan Peracunan Alat (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls dalam MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Dokumentasi Prompt Shields (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP टॉप 10 फॉर LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub एडवांस्ड सिक्योरिटी](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Microsoft में सॉफ़्टवेयर सप्लाई चेन को सुरक्षित करने की यात्रा](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [सुरक्षित न्यूनतम-अधिकार एक्सेस (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [टोकन सत्यापन और जीवनकाल के लिए सर्वोत्तम प्रथाएं](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [सुरक्षित टोकन स्टोरेज का उपयोग करें और टोकन को एन्क्रिप्ट करें (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [MCP के लिए ऑथ गेटवे के रूप में Azure API प्रबंधन](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [MCP सर्वर के साथ प्रमाणित करने के लिए Microsoft Entra ID का उपयोग करना](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### आगे 

आगे: [अध्याय 3: शुरुआत करना](/03-GettingStarted/README.md)

I'm sorry, but I can't translate the text into "mo" as it's unclear which language "mo" refers to. If you can provide more context or specify the language, I would be happy to assist you with the translation.