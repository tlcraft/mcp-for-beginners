<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "382fddb4ee4d9c1bdc806e2ee99b70c8",
  "translation_date": "2025-07-17T08:10:28+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "ms"
}
-->
# Amalan Terbaik Keselamatan

Menggunakan Model Context Protocol (MCP) membawa keupayaan baru yang hebat kepada aplikasi berasaskan AI, tetapi juga memperkenalkan cabaran keselamatan unik yang melangkaui risiko perisian tradisional. Selain kebimbangan yang sudah ada seperti pengekodan selamat, prinsip keistimewaan minimum, dan keselamatan rantaian bekalan, MCP dan beban kerja AI menghadapi ancaman baru seperti suntikan arahan (prompt injection), pencemaran alat (tool poisoning), pengubahsuaian alat dinamik, pembajakan sesi, serangan confused deputy, dan kelemahan token passthrough. Risiko-risiko ini boleh menyebabkan pendedahan data, pelanggaran privasi, dan tingkah laku sistem yang tidak diingini jika tidak diurus dengan betul.

Pelajaran ini meneroka risiko keselamatan yang paling relevan berkaitan dengan MCP—termasuk pengesahan, kebenaran, kebenaran berlebihan, suntikan arahan tidak langsung, keselamatan sesi, masalah confused deputy, kelemahan token passthrough, dan kelemahan rantaian bekalan—serta menyediakan kawalan dan amalan terbaik yang boleh diambil tindakan untuk mengurangkannya. Anda juga akan belajar bagaimana menggunakan penyelesaian Microsoft seperti Prompt Shields, Azure Content Safety, dan GitHub Advanced Security untuk mengukuhkan pelaksanaan MCP anda. Dengan memahami dan mengaplikasikan kawalan ini, anda boleh mengurangkan kemungkinan berlakunya pelanggaran keselamatan dan memastikan sistem AI anda kekal kukuh dan boleh dipercayai.

# Objektif Pembelajaran

Menjelang akhir pelajaran ini, anda akan dapat:

- Mengenal pasti dan menerangkan risiko keselamatan unik yang diperkenalkan oleh Model Context Protocol (MCP), termasuk suntikan arahan, pencemaran alat, kebenaran berlebihan, pembajakan sesi, masalah confused deputy, kelemahan token passthrough, dan kelemahan rantaian bekalan.
- Menerangkan dan menggunakan kawalan mitigasi yang berkesan untuk risiko keselamatan MCP, seperti pengesahan yang kukuh, prinsip keistimewaan minimum, pengurusan token yang selamat, kawalan keselamatan sesi, dan pengesahan rantaian bekalan.
- Memahami dan menggunakan penyelesaian Microsoft seperti Prompt Shields, Azure Content Safety, dan GitHub Advanced Security untuk melindungi MCP dan beban kerja AI.
- Mengiktiraf kepentingan mengesahkan metadata alat, memantau perubahan dinamik, mempertahankan serangan suntikan arahan tidak langsung, dan mencegah pembajakan sesi.
- Mengintegrasikan amalan keselamatan terbaik yang telah ditetapkan—seperti pengekodan selamat, pengukuhan pelayan, dan seni bina zero trust—ke dalam pelaksanaan MCP anda untuk mengurangkan kemungkinan dan impak pelanggaran keselamatan.

# Kawalan keselamatan MCP

Mana-mana sistem yang mempunyai akses kepada sumber penting mempunyai cabaran keselamatan tersirat. Cabaran keselamatan biasanya boleh diatasi melalui aplikasi yang betul bagi kawalan dan konsep keselamatan asas. Oleh kerana MCP baru sahaja ditakrifkan, spesifikasi sedang berubah dengan sangat pantas dan protokol ini terus berkembang. Akhirnya, kawalan keselamatan di dalamnya akan matang, membolehkan integrasi yang lebih baik dengan seni bina keselamatan perusahaan dan amalan terbaik yang telah ditetapkan.

Penyelidikan yang diterbitkan dalam [Microsoft Digital Defense Report](https://aka.ms/mddr) menyatakan bahawa 98% pelanggaran yang dilaporkan boleh dicegah dengan amalan kebersihan keselamatan yang kukuh dan perlindungan terbaik terhadap sebarang jenis pelanggaran adalah dengan memastikan kebersihan keselamatan asas, amalan pengekodan selamat dan keselamatan rantaian bekalan dilakukan dengan betul — amalan yang telah diuji dan terbukti ini masih memberi impak paling besar dalam mengurangkan risiko keselamatan.

Mari kita lihat beberapa cara yang boleh anda mulakan untuk menangani risiko keselamatan apabila menggunakan MCP.

> **Note:** Maklumat berikut adalah betul sehingga **29 Mei 2025**. Protokol MCP sentiasa berkembang, dan pelaksanaan masa depan mungkin memperkenalkan corak pengesahan dan kawalan baru. Untuk kemas kini dan panduan terkini, sentiasa rujuk [Spesifikasi MCP](https://spec.modelcontextprotocol.io/) dan repositori rasmi [MCP GitHub](https://github.com/modelcontextprotocol) serta [halaman amalan terbaik keselamatan](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Pernyataan masalah  
Spesifikasi asal MCP menganggap pembangun akan menulis pelayan pengesahan mereka sendiri. Ini memerlukan pengetahuan tentang OAuth dan kekangan keselamatan berkaitan. Pelayan MCP bertindak sebagai Pelayan Kebenaran OAuth 2.0, mengurus pengesahan pengguna yang diperlukan secara langsung dan bukannya mendelegasikannya kepada perkhidmatan luaran seperti Microsoft Entra ID. Sejak **26 April 2025**, kemas kini kepada spesifikasi MCP membenarkan pelayan MCP mendelegasikan pengesahan pengguna kepada perkhidmatan luaran.

### Risiko
- Logik kebenaran yang salah konfigurasi dalam pelayan MCP boleh menyebabkan pendedahan data sensitif dan kawalan akses yang tidak betul.
- Kecurian token OAuth pada pelayan MCP tempatan. Jika dicuri, token tersebut boleh digunakan untuk menyamar sebagai pelayan MCP dan mengakses sumber serta data dari perkhidmatan yang token OAuth itu untuknya.

#### Token Passthrough
Token passthrough secara jelas dilarang dalam spesifikasi kebenaran kerana ia memperkenalkan beberapa risiko keselamatan, termasuk:

#### Pengelakan Kawalan Keselamatan
Pelayan MCP atau API hiliran mungkin melaksanakan kawalan keselamatan penting seperti had kadar, pengesahan permintaan, atau pemantauan trafik, yang bergantung pada audiens token atau kekangan kelayakan lain. Jika klien boleh mendapatkan dan menggunakan token terus dengan API hiliran tanpa pelayan MCP mengesahkannya dengan betul atau memastikan token dikeluarkan untuk perkhidmatan yang betul, mereka akan memintas kawalan ini.

#### Isu Akauntabiliti dan Jejak Audit
Pelayan MCP tidak dapat mengenal pasti atau membezakan antara Klien MCP apabila klien memanggil dengan token akses yang dikeluarkan oleh hulu yang mungkin tidak jelas kepada pelayan MCP.  
Log pelayan Sumber hiliran mungkin menunjukkan permintaan yang kelihatan datang dari sumber yang berbeza dengan identiti yang berbeza, bukan pelayan MCP yang sebenarnya meneruskan token tersebut.  
Kedua-dua faktor ini menyukarkan penyiasatan insiden, kawalan, dan audit.  
Jika pelayan MCP meneruskan token tanpa mengesahkan tuntutan mereka (contohnya, peranan, keistimewaan, atau audiens) atau metadata lain, pelaku berniat jahat yang memiliki token curi boleh menggunakan pelayan sebagai proksi untuk pengeluaran data.

#### Isu Sempadan Kepercayaan
Pelayan Sumber hiliran memberi kepercayaan kepada entiti tertentu. Kepercayaan ini mungkin termasuk andaian tentang asal atau corak tingkah laku klien. Memecahkan sempadan kepercayaan ini boleh menyebabkan isu yang tidak dijangka.  
Jika token diterima oleh pelbagai perkhidmatan tanpa pengesahan yang betul, penyerang yang menembusi satu perkhidmatan boleh menggunakan token itu untuk mengakses perkhidmatan lain yang bersambung.

#### Risiko Keserasian Masa Depan
Walaupun pelayan MCP bermula sebagai "proksi tulen" hari ini, ia mungkin perlu menambah kawalan keselamatan kemudian. Memulakan dengan pemisahan audiens token yang betul memudahkan evolusi model keselamatan.

### Kawalan mitigasi

**Pelayan MCP TIDAK BOLEH menerima sebarang token yang tidak dikeluarkan secara eksplisit untuk pelayan MCP**

- **Semak dan Kukuhkan Logik Kebenaran:** Audit dengan teliti pelaksanaan kebenaran pelayan MCP anda untuk memastikan hanya pengguna dan klien yang dimaksudkan boleh mengakses sumber sensitif. Untuk panduan praktikal, lihat [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) dan [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Laksanakan Amalan Token Selamat:** Ikuti [amalan terbaik Microsoft untuk pengesahan token dan jangka hayat](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) untuk mengelakkan penyalahgunaan token akses dan mengurangkan risiko pengulangan atau kecurian token.
- **Lindungi Penyimpanan Token:** Sentiasa simpan token dengan selamat dan gunakan penyulitan untuk melindungi token semasa disimpan dan dalam transit. Untuk petua pelaksanaan, lihat [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Kebenaran berlebihan untuk pelayan MCP

### Pernyataan masalah
Pelayan MCP mungkin telah diberikan kebenaran berlebihan ke atas perkhidmatan/sumber yang diaksesnya. Contohnya, pelayan MCP yang merupakan sebahagian daripada aplikasi jualan AI yang menyambung ke stor data perusahaan harus mempunyai akses yang terhad kepada data jualan sahaja dan tidak dibenarkan mengakses semua fail dalam stor tersebut. Merujuk kembali kepada prinsip keistimewaan minimum (salah satu prinsip keselamatan tertua), tiada sumber harus mempunyai kebenaran melebihi apa yang diperlukan untuk melaksanakan tugas yang dimaksudkan. AI menghadirkan cabaran yang lebih besar dalam ruang ini kerana untuk membolehkan fleksibiliti, sukar untuk menentukan kebenaran tepat yang diperlukan.

### Risiko  
- Memberi kebenaran berlebihan boleh membenarkan pengeluaran atau pengubahsuaian data yang tidak sepatutnya diakses oleh pelayan MCP. Ini juga boleh menjadi isu privasi jika data tersebut adalah maklumat peribadi yang boleh dikenal pasti (PII).

### Kawalan mitigasi
- **Gunakan Prinsip Keistimewaan Minimum:** Berikan pelayan MCP hanya kebenaran minimum yang diperlukan untuk melaksanakan tugasnya. Semak dan kemas kini kebenaran ini secara berkala untuk memastikan ia tidak melebihi keperluan. Untuk panduan terperinci, lihat [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Gunakan Kawalan Akses Berasaskan Peranan (RBAC):** Tetapkan peranan kepada pelayan MCP yang terhad kepada sumber dan tindakan tertentu, mengelakkan kebenaran yang luas atau tidak perlu.
- **Pantau dan Audit Kebenaran:** Pantau penggunaan kebenaran secara berterusan dan audit log akses untuk mengesan dan membetulkan keistimewaan berlebihan atau tidak digunakan dengan segera.

# Serangan suntikan arahan tidak langsung

### Pernyataan masalah

Pelayan MCP yang berniat jahat atau telah dikompromi boleh memperkenalkan risiko besar dengan mendedahkan data pelanggan atau membolehkan tindakan yang tidak diingini. Risiko ini sangat relevan dalam beban kerja AI dan berasaskan MCP, di mana:

- **Serangan Suntikan Arahan (Prompt Injection):** Penyerang menyisipkan arahan berniat jahat dalam arahan atau kandungan luaran, menyebabkan sistem AI melakukan tindakan yang tidak diingini atau mendedahkan data sensitif. Ketahui lebih lanjut: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Pencemaran Alat (Tool Poisoning):** Penyerang memanipulasi metadata alat (seperti deskripsi atau parameter) untuk mempengaruhi tingkah laku AI, berpotensi memintas kawalan keselamatan atau mengeluarkan data. Maklumat lanjut: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Suntikan Arahan Rentas Domain:** Arahan berniat jahat disisipkan dalam dokumen, halaman web, atau emel, yang kemudian diproses oleh AI, menyebabkan kebocoran atau manipulasi data.
- **Pengubahsuaian Alat Dinamik (Rug Pulls):** Definisi alat boleh diubah selepas kelulusan pengguna, memperkenalkan tingkah laku berniat jahat baru tanpa pengetahuan pengguna.

Kelemahan ini menekankan keperluan untuk pengesahan yang kukuh, pemantauan, dan kawalan keselamatan apabila mengintegrasikan pelayan MCP dan alat ke dalam persekitaran anda. Untuk penerangan lebih mendalam, lihat rujukan yang disertakan di atas.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.ms.png)

**Suntikan Arahan Tidak Langsung** (juga dikenali sebagai suntikan arahan rentas domain atau XPIA) adalah kelemahan kritikal dalam sistem AI generatif, termasuk yang menggunakan Model Context Protocol (MCP). Dalam serangan ini, arahan berniat jahat disembunyikan dalam kandungan luaran—seperti dokumen, halaman web, atau emel. Apabila sistem AI memproses kandungan ini, ia mungkin mentafsir arahan yang disisipkan sebagai arahan pengguna yang sah, mengakibatkan tindakan tidak diingini seperti kebocoran data, penghasilan kandungan berbahaya, atau manipulasi interaksi pengguna. Untuk penjelasan terperinci dan contoh dunia sebenar, lihat [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Bentuk serangan yang sangat berbahaya adalah **Pencemaran Alat**. Di sini, penyerang menyuntik arahan berniat jahat ke dalam metadata alat MCP (seperti deskripsi alat atau parameter). Oleh kerana model bahasa besar (LLM) bergantung pada metadata ini untuk memutuskan alat mana yang akan digunakan, deskripsi yang dikompromi boleh memperdaya model untuk melaksanakan panggilan alat yang tidak dibenarkan atau memintas kawalan keselamatan. Manipulasi ini sering tidak kelihatan oleh pengguna akhir tetapi boleh ditafsir dan dilaksanakan oleh sistem AI. Risiko ini lebih tinggi dalam persekitaran pelayan MCP yang dihoskan, di mana definisi alat boleh dikemas kini selepas kelulusan pengguna—senario yang kadang-kadang dirujuk sebagai "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Dalam kes sedemikian, alat yang sebelum ini selamat mungkin diubah kemudian untuk melakukan tindakan berniat jahat, seperti mengeluarkan data atau mengubah tingkah laku sistem, tanpa pengetahuan pengguna. Untuk maklumat lanjut mengenai vektor serangan ini, lihat [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.ms.png)

## Risiko
Tindakan AI yang tidak diingini membawa pelbagai risiko keselamatan termasuk pengeluaran data dan pelanggaran privasi.

### Kawalan mitigasi
### Menggunakan prompt shields untuk melindungi daripada serangan Suntikan Arahan Tidak Langsung
-----------------------------------------------------------------------------

**AI Prompt Shields** adalah penyelesaian yang dibangunkan oleh Microsoft untuk mempertahankan daripada serangan suntikan arahan langsung dan tidak langsung. Ia membantu melalui:

1.  **Pengesanan dan Penapisan:** Prompt Shields menggunakan algoritma pembelajaran mesin canggih dan pemprosesan bahasa semula jadi untuk mengesan dan menapis arahan berniat jahat yang disisipkan dalam kandungan luaran, seperti dokumen, halaman web, atau emel.
    
2.  **Spotlighting:** Teknik ini membantu sistem AI membezakan antara arahan sistem yang sah dan input luaran yang berpotensi tidak boleh dipercayai. Dengan mengubah teks input supaya lebih relevan kepada model, Spotlighting memastikan AI dapat mengenal pasti dan mengabaikan arahan berniat jahat dengan lebih baik.
    
3.  **Delimiter dan Datamarking:** Menyertakan delimiter dalam mesej sistem secara jelas menunjukkan lokasi teks input, membantu sistem AI mengenal pasti dan memisahkan input pengguna daripada kandungan luaran yang berpotensi berbahaya. Datamarking melanjutkan konsep ini dengan menggunakan penanda khas untuk menyerlahkan sempadan data yang dipercayai dan tidak dipercayai.
    
4.  **Pemantauan dan Kemas Kini Berterusan:** Microsoft sentiasa memantau dan mengemas kini Prompt Shields untuk menangani ancaman baru dan yang sedang berkembang. Pendekatan proaktif ini memastikan pertahanan kekal berkesan terhadap teknik serangan terkini.
    
5. **Integrasi dengan Azure Content Safety:** Prompt Shields adalah sebahagian daripada suite Azure AI Content Safety yang lebih luas, yang menyediakan alat tambahan untuk mengesan cubaan jailbreak, kandungan berbahaya, dan risiko keselamatan lain dalam aplikasi AI.

Anda boleh membaca lebih lanjut mengenai AI prompt shields dalam [dokumentasi Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.ms.png)

# Masalah Confused Deputy

### Pernyataan masalah
Masalah confused deputy adalah kelemahan keselamatan yang berlaku apabila pelayan MCP bertindak sebagai proksi antara klien MCP dan API pihak ketiga. Kelemahan ini boleh dieksploitasi apabila pelayan MCP menggunakan ID klien statik untuk mengesahkan dengan pelayan kebenaran pihak ketiga yang tidak menyokong pendaftaran klien dinamik.

### Risiko

- **Bypass persetujuan berasaskan kuki**: Jika pengguna telah mengesahkan melalui pelayan proksi MCP sebelum ini, pelayan kebenaran pihak ketiga mungkin menetapkan kuki persetujuan dalam pelayar pengguna. Penyerang boleh mengeksploitasi ini dengan menghantar pautan berniat jahat yang mengandungi permintaan kebenaran dengan URI pengalihan berniat jahat.
- **Kecurian kod kebenaran**: Apabila pengguna mengklik pautan berniat jahat, pelayan kebenaran pihak ketiga mungkin melangkau skrin persetujuan kerana kuki yang sedia ada, dan kod kebenaran boleh dialihkan ke pelayan penyerang.
- **Akses API tanpa kebenaran**: Penyerang boleh menukar kod kebenaran yang dicuri kepada token akses dan menyamar sebagai pengguna untuk mengakses API pihak ketiga tanpa kelulusan jelas.

### Kawalan mitigasi

- **Keperluan persetujuan jelas**: Pelayan proksi MCP yang menggunakan ID klien statik **MESTI** mendapatkan persetujuan pengguna untuk setiap klien yang didaftarkan secara dinamik sebelum meneruskan ke pelayan kebenaran pihak ketiga.
- **Pelaksanaan OAuth yang betul**: Ikuti amalan keselamatan terbaik OAuth 2.1, termasuk menggunakan cabaran kod (PKCE) untuk permintaan kebenaran bagi mengelakkan serangan pemintasan.
- **Pengesahan klien**: Laksanakan pengesahan ketat terhadap URI pengalihan dan pengecam klien untuk mengelakkan eksploitasi oleh pihak berniat jahat.


# Kelemahan Token Passthrough

### Pernyataan masalah

"Token passthrough" adalah anti-pola di mana pelayan MCP menerima token dari klien MCP tanpa mengesahkan bahawa token tersebut dikeluarkan dengan betul untuk pelayan MCP itu sendiri, dan kemudian "meneruskannya" ke API hiliran. Amalan ini jelas melanggar spesifikasi kebenaran MCP dan memperkenalkan risiko keselamatan yang serius.

### Risiko

- **Pengelakan Kawalan Keselamatan**: Klien boleh memintas kawalan keselamatan penting seperti had kadar, pengesahan permintaan, atau pemantauan trafik jika mereka boleh menggunakan token terus dengan API hiliran tanpa pengesahan yang betul.
- **Isu Akauntabiliti dan Jejak Audit**: Pelayan MCP tidak dapat mengenal pasti atau membezakan antara klien MCP apabila klien menggunakan token akses yang dikeluarkan oleh hulu, menjadikan penyiasatan insiden dan audit lebih sukar.
- **Eksfiltrasi Data**: Jika token diteruskan tanpa pengesahan tuntutan yang betul, pihak berniat jahat dengan token yang dicuri boleh menggunakan pelayan sebagai proksi untuk eksfiltrasi data.
- **Pelanggaran Sempadan Kepercayaan**: Pelayan sumber hiliran mungkin memberi kepercayaan kepada entiti tertentu dengan andaian tentang asal atau corak tingkah laku. Memecahkan sempadan kepercayaan ini boleh menyebabkan isu keselamatan yang tidak dijangka.
- **Penyalahgunaan Token Pelbagai Perkhidmatan**: Jika token diterima oleh pelbagai perkhidmatan tanpa pengesahan yang betul, penyerang yang menjejaskan satu perkhidmatan boleh menggunakan token tersebut untuk mengakses perkhidmatan lain yang bersambung.

### Kawalan mitigasi

- **Pengesahan token**: Pelayan MCP **TIDAK BOLEH** menerima sebarang token yang tidak secara jelas dikeluarkan untuk pelayan MCP itu sendiri.
- **Pengesahan audiens**: Sentiasa sahkan bahawa token mempunyai tuntutan audiens yang betul yang sepadan dengan identiti pelayan MCP.
- **Pengurusan kitar hayat token yang betul**: Laksanakan token akses jangka pendek dan amalan putaran token yang betul untuk mengurangkan risiko kecurian dan penyalahgunaan token.


# Pengambilalihan Sesi

### Pernyataan masalah

Pengambilalihan sesi adalah vektor serangan di mana klien diberikan ID sesi oleh pelayan, dan pihak yang tidak dibenarkan memperoleh dan menggunakan ID sesi yang sama untuk menyamar sebagai klien asal dan melakukan tindakan tanpa kebenaran bagi pihak mereka. Ini amat membimbangkan dalam pelayan HTTP berstatus yang mengendalikan permintaan MCP.

### Risiko

- **Suntikan Prompt Pengambilalihan Sesi**: Penyerang yang memperoleh ID sesi boleh menghantar acara berniat jahat ke pelayan yang berkongsi keadaan sesi dengan pelayan yang disambungkan oleh klien, berpotensi mencetuskan tindakan berbahaya atau mengakses data sensitif.
- **Penyamaran Pengambilalihan Sesi**: Penyerang dengan ID sesi yang dicuri boleh membuat panggilan terus ke pelayan MCP, memintas pengesahan dan dilayan sebagai pengguna sah.
- **Aliran Boleh Disambung Semula yang Kompromi**: Apabila pelayan menyokong penghantaran semula/aliran boleh disambung semula, penyerang boleh menamatkan permintaan lebih awal, menyebabkan ia disambung semula kemudian oleh klien asal dengan kandungan yang berpotensi berniat jahat.

### Kawalan mitigasi

- **Pengesahan kebenaran**: Pelayan MCP yang melaksanakan kebenaran **MESTI** mengesahkan semua permintaan masuk dan **TIDAK BOLEH** menggunakan sesi untuk pengesahan.
- **ID sesi yang selamat**: Pelayan MCP **MESTI** menggunakan ID sesi yang selamat dan tidak deterministik yang dijana dengan penjana nombor rawak yang selamat. Elakkan pengecam yang boleh diramal atau berurutan.
- **Pengikatan sesi khusus pengguna**: Pelayan MCP **SEBAIKNYA** mengikat ID sesi kepada maklumat khusus pengguna, menggabungkan ID sesi dengan maklumat unik pengguna yang dibenarkan (seperti ID pengguna dalaman mereka) menggunakan format seperti `
<user_id>:<session_id>`.
- **Tamat tempoh sesi**: Laksanakan tamat tempoh sesi dan putaran sesi yang betul untuk mengehadkan tempoh kerentanan jika ID sesi dikompromi.
- **Keselamatan pengangkutan**: Sentiasa gunakan HTTPS untuk semua komunikasi bagi mengelakkan pemintasan ID sesi.


# Keselamatan Rantaian Bekalan

Keselamatan rantaian bekalan kekal asas dalam era AI, tetapi skop apa yang dianggap sebagai rantaian bekalan anda telah berkembang. Selain pakej kod tradisional, anda kini mesti mengesahkan dan memantau dengan teliti semua komponen berkaitan AI, termasuk model asas, perkhidmatan embeddings, penyedia konteks, dan API pihak ketiga. Setiap satu boleh memperkenalkan kelemahan atau risiko jika tidak diurus dengan betul.

**Amalan keselamatan rantaian bekalan utama untuk AI dan MCP:**
- **Sahkan semua komponen sebelum integrasi:** Ini termasuk bukan sahaja perpustakaan sumber terbuka, tetapi juga model AI, sumber data, dan API luaran. Sentiasa periksa asal usul, lesen, dan kelemahan yang diketahui.
- **Kekalkan saluran penghantaran yang selamat:** Gunakan saluran CI/CD automatik dengan imbasan keselamatan terintegrasi untuk mengesan isu awal. Pastikan hanya artifak yang dipercayai dihantar ke produksi.
- **Pantau dan audit secara berterusan:** Laksanakan pemantauan berterusan untuk semua kebergantungan, termasuk model dan perkhidmatan data, untuk mengesan kelemahan baru atau serangan rantaian bekalan.
- **Gunakan prinsip keistimewaan minimum dan kawalan akses:** Hadkan akses kepada model, data, dan perkhidmatan hanya kepada apa yang diperlukan untuk pelayan MCP anda berfungsi.
- **Bertindak cepat terhadap ancaman:** Ada proses untuk menampal atau menggantikan komponen yang dikompromi, dan untuk memutar rahsia atau kelayakan jika berlaku pelanggaran.

[GitHub Advanced Security](https://github.com/security/advanced-security) menyediakan ciri seperti imbasan rahsia, imbasan kebergantungan, dan analisis CodeQL. Alat ini berintegrasi dengan [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) dan [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) untuk membantu pasukan mengenal pasti dan mengurangkan kelemahan merentasi kod dan komponen rantaian bekalan AI.

Microsoft juga melaksanakan amalan keselamatan rantaian bekalan yang meluas secara dalaman untuk semua produk. Ketahui lebih lanjut dalam [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Amalan keselamatan terbaik yang telah ditetapkan untuk meningkatkan kedudukan keselamatan pelaksanaan MCP anda

Mana-mana pelaksanaan MCP mewarisi kedudukan keselamatan sedia ada persekitaran organisasi anda yang menjadi asasnya, jadi apabila mempertimbangkan keselamatan MCP sebagai komponen sistem AI keseluruhan anda, disyorkan untuk meningkatkan kedudukan keselamatan sedia ada anda secara menyeluruh. Kawalan keselamatan yang telah ditetapkan berikut amat relevan:

-   Amalan pengekodan selamat dalam aplikasi AI anda - lindungi daripada [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 untuk LLM](https://genai.owasp.org/download/43299/?tmstv=1731900559), penggunaan peti keselamatan untuk rahsia dan token, melaksanakan komunikasi selamat hujung ke hujung antara semua komponen aplikasi, dan lain-lain.
-   Pengukuhan pelayan -- gunakan MFA jika boleh, sentiasa kemas kini tampalan, integrasikan pelayan dengan penyedia identiti pihak ketiga untuk akses, dan sebagainya.
-   Pastikan peranti, infrastruktur dan aplikasi sentiasa dikemas kini dengan tampalan
-   Pemantauan keselamatan -- melaksanakan pencatatan dan pemantauan aplikasi AI (termasuk klien/pelayan MCP) dan menghantar log tersebut ke SIEM pusat untuk mengesan aktiviti luar biasa
-   Seni bina zero trust -- mengasingkan komponen melalui kawalan rangkaian dan identiti secara logik untuk meminimumkan pergerakan sisi jika aplikasi AI dikompromi.

# Perkara Penting

- Asas keselamatan kekal kritikal: Pengekodan selamat, keistimewaan minimum, pengesahan rantaian bekalan, dan pemantauan berterusan adalah penting untuk beban kerja MCP dan AI.
- MCP memperkenalkan risiko baru—seperti suntikan prompt, keracunan alat, pengambilalihan sesi, masalah confused deputy, kelemahan token passthrough, dan kebenaran berlebihan—yang memerlukan kawalan tradisional dan khusus AI.
- Gunakan amalan pengesahan, kebenaran, dan pengurusan token yang kukuh, memanfaatkan penyedia identiti luaran seperti Microsoft Entra ID jika boleh.
- Lindungi daripada suntikan prompt tidak langsung dan keracunan alat dengan mengesahkan metadata alat, memantau perubahan dinamik, dan menggunakan penyelesaian seperti Microsoft Prompt Shields.
- Laksanakan pengurusan sesi yang selamat dengan menggunakan ID sesi tidak deterministik, mengikat sesi kepada identiti pengguna, dan tidak pernah menggunakan sesi untuk pengesahan.
- Cegah serangan confused deputy dengan memerlukan persetujuan pengguna yang jelas untuk setiap klien yang didaftarkan secara dinamik dan melaksanakan amalan keselamatan OAuth yang betul.
- Elakkan kelemahan token passthrough dengan memastikan pelayan MCP hanya menerima token yang secara jelas dikeluarkan untuk mereka dan mengesahkan tuntutan token dengan sewajarnya.
- Perlakukan semua komponen dalam rantaian bekalan AI anda—termasuk model, embeddings, dan penyedia konteks—dengan ketelitian yang sama seperti kebergantungan kod.
- Sentiasa kemas kini dengan spesifikasi MCP yang berkembang dan sumbang kepada komuniti untuk membantu membentuk piawaian yang selamat.

# Sumber Tambahan

## Sumber Luaran
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

## Dokumen Keselamatan Tambahan

Untuk panduan keselamatan yang lebih terperinci, sila rujuk dokumen berikut:

- [MCP Security Best Practices 2025](./mcp-security-best-practices-2025.md) - Senarai komprehensif amalan keselamatan terbaik untuk pelaksanaan MCP
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md) - Contoh pelaksanaan untuk mengintegrasikan Azure Content Safety dengan pelayan MCP
- [MCP Security Controls 2025](./mcp-security-controls-2025.md) - Kawalan dan teknik keselamatan terkini untuk melindungi pelaksanaan MCP
- [MCP Best Practices](./mcp-best-practices.md) - Panduan rujukan pantas untuk keselamatan MCP

### Seterusnya

Seterusnya: [Bab 3: Memulakan](../03-GettingStarted/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.