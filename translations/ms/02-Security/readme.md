<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-17T07:43:15+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "ms"
}
-->
# Amalan Terbaik Keselamatan

Mengguna pakai Model Context Protocol (MCP) memberikan keupayaan baru yang kuat kepada aplikasi yang dipacu AI, tetapi juga memperkenalkan cabaran keselamatan yang unik yang melampaui risiko perisian tradisional. Selain kebimbangan yang telah ditetapkan seperti pengkodan selamat, keistimewaan minimum, dan keselamatan rantaian bekalan, MCP dan beban kerja AI menghadapi ancaman baru seperti suntikan prompt, racun alat, dan pengubahsuaian alat dinamik. Risiko ini boleh menyebabkan pencerobohan data, pelanggaran privasi, dan tingkah laku sistem yang tidak diingini jika tidak diuruskan dengan betul.

Pelajaran ini meneroka risiko keselamatan yang paling relevan yang berkaitan dengan MCP—termasuk pengesahan, kebenaran, keizinan berlebihan, suntikan prompt tidak langsung, dan kelemahan rantaian bekalan—dan menyediakan kawalan tindakan dan amalan terbaik untuk mengurangkan mereka. Anda juga akan belajar bagaimana memanfaatkan penyelesaian Microsoft seperti Prompt Shields, Azure Content Safety, dan GitHub Advanced Security untuk memperkuat pelaksanaan MCP anda. Dengan memahami dan menerapkan kawalan ini, anda boleh mengurangkan kemungkinan pelanggaran keselamatan dengan ketara dan memastikan sistem AI anda tetap kukuh dan boleh dipercayai.

# Objektif Pembelajaran

Pada akhir pelajaran ini, anda akan dapat:

- Mengenal pasti dan menjelaskan risiko keselamatan unik yang diperkenalkan oleh Model Context Protocol (MCP), termasuk suntikan prompt, racun alat, keizinan berlebihan, dan kelemahan rantaian bekalan.
- Menggambarkan dan menerapkan kawalan mitigasi berkesan untuk risiko keselamatan MCP, seperti pengesahan yang kukuh, keistimewaan minimum, pengurusan token selamat, dan pengesahan rantaian bekalan.
- Memahami dan memanfaatkan penyelesaian Microsoft seperti Prompt Shields, Azure Content Safety, dan GitHub Advanced Security untuk melindungi MCP dan beban kerja AI.
- Mengakui kepentingan pengesahan metadata alat, pemantauan perubahan dinamik, dan mempertahankan terhadap serangan suntikan prompt tidak langsung.
- Mengintegrasikan amalan keselamatan yang telah ditetapkan—seperti pengkodan selamat, pengukuhan pelayan, dan seni bina kepercayaan sifar—ke dalam pelaksanaan MCP anda untuk mengurangkan kemungkinan dan kesan pelanggaran keselamatan.

# Kawalan keselamatan MCP

Mana-mana sistem yang mempunyai akses kepada sumber penting mempunyai cabaran keselamatan yang tersirat. Cabaran keselamatan secara amnya boleh diatasi melalui aplikasi yang betul terhadap kawalan dan konsep keselamatan asas. Oleh kerana MCP baru sahaja ditakrifkan, spesifikasi berubah dengan sangat cepat dan apabila protokol berkembang. Akhirnya kawalan keselamatan di dalamnya akan matang, membolehkan integrasi yang lebih baik dengan perusahaan dan seni bina keselamatan yang telah ditetapkan serta amalan terbaik.

Penyelidikan yang diterbitkan dalam [Microsoft Digital Defense Report](https://aka.ms/mddr) menyatakan bahawa 98% daripada pelanggaran yang dilaporkan akan dicegah oleh kebersihan keselamatan yang kukuh dan perlindungan terbaik terhadap sebarang jenis pelanggaran adalah mendapatkan kebersihan keselamatan asas anda, amalan terbaik pengkodan selamat dan keselamatan rantaian bekalan dengan betul -- amalan yang telah dicuba dan diuji yang kita sudah tahu masih memberikan kesan paling besar dalam mengurangkan risiko keselamatan.

Mari kita lihat beberapa cara anda boleh mula menangani risiko keselamatan apabila mengguna pakai MCP.

# Pengesahan pelayan MCP (jika pelaksanaan MCP anda sebelum 26 April 2025)

> **Nota:** Maklumat berikut adalah tepat pada 26 April 2025. Protokol MCP sentiasa berkembang, dan pelaksanaan masa depan mungkin memperkenalkan corak dan kawalan pengesahan baru. Untuk kemas kini dan panduan terkini, sentiasa rujuk [Spesifikasi MCP](https://spec.modelcontextprotocol.io/) dan [repositori rasmi MCP GitHub](https://github.com/modelcontextprotocol).

### Pernyataan masalah 
Spesifikasi MCP asal menganggap bahawa pembangun akan menulis pelayan pengesahan mereka sendiri. Ini memerlukan pengetahuan tentang OAuth dan kekangan keselamatan yang berkaitan. Pelayan MCP bertindak sebagai Pelayan Kebenaran OAuth 2.0, menguruskan pengesahan pengguna yang diperlukan secara langsung dan bukannya mendelegasikannya kepada perkhidmatan luaran seperti Microsoft Entra ID. Pada 26 April 2025, kemas kini kepada spesifikasi MCP membenarkan pelayan MCP untuk mendelegasikan pengesahan pengguna kepada perkhidmatan luaran.

### Risiko
- Logik kebenaran yang salah konfigurasi dalam pelayan MCP boleh menyebabkan pendedahan data sensitif dan kawalan akses yang salah diterapkan.
- Kecurian token OAuth pada pelayan MCP tempatan. Jika dicuri, token boleh digunakan untuk menyamar sebagai pelayan MCP dan mengakses sumber dan data dari perkhidmatan yang token OAuth adalah untuknya.

### Kawalan mitigasi
- **Semak dan Kukuhkan Logik Kebenaran:** Audit dengan teliti pelaksanaan kebenaran pelayan MCP anda untuk memastikan hanya pengguna dan pelanggan yang dimaksudkan dapat mengakses sumber sensitif. Untuk panduan praktikal, lihat [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) dan [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Tegaskan Amalan Token Selamat:** Ikuti [amalan terbaik Microsoft untuk pengesahan dan jangka hayat token](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) untuk mencegah penyalahgunaan token akses dan mengurangkan risiko ulangan atau kecurian token.
- **Lindungi Penyimpanan Token:** Sentiasa simpan token dengan selamat dan gunakan penyulitan untuk melindungi mereka semasa rehat dan dalam transit. Untuk petua pelaksanaan, lihat [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Keizinan berlebihan untuk pelayan MCP

### Pernyataan masalah
Pelayan MCP mungkin telah diberikan keizinan berlebihan kepada perkhidmatan/sumber yang mereka akses. Sebagai contoh, pelayan MCP yang merupakan sebahagian daripada aplikasi jualan AI yang berhubung dengan stor data perusahaan harus mempunyai akses yang terhad kepada data jualan dan tidak dibenarkan mengakses semua fail dalam stor. Merujuk kembali kepada prinsip keistimewaan minimum (salah satu prinsip keselamatan tertua), tiada sumber harus mempunyai keizinan melebihi apa yang diperlukan untuk melaksanakan tugas yang dimaksudkan. AI menghadirkan cabaran yang meningkat dalam ruang ini kerana untuk membolehkannya fleksibel, sukar untuk menentukan keizinan yang tepat diperlukan.

### Risiko 
- Memberikan keizinan berlebihan boleh membenarkan pencerobohan atau pengubahsuaian data yang pelayan MCP tidak dimaksudkan untuk dapat mengakses. Ini juga boleh menjadi isu privasi jika data adalah maklumat yang boleh dikenalpasti secara peribadi (PII).

### Kawalan mitigasi
- **Terapkan Prinsip Keistimewaan Minimum:** Berikan pelayan MCP hanya keizinan minimum yang diperlukan untuk melaksanakan tugas yang diperlukan. Semak dan kemas kini keizinan ini secara berkala untuk memastikan mereka tidak melebihi apa yang diperlukan. Untuk panduan terperinci, lihat [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Gunakan Kawalan Akses Berasaskan Peranan (RBAC):** Berikan peranan kepada pelayan MCP yang terhad dengan ketat kepada sumber dan tindakan tertentu, mengelakkan keizinan yang luas atau tidak perlu.
- **Pantau dan Audit Keizinan:** Pantau penggunaan keizinan secara berterusan dan audit log akses untuk mengesan dan membetulkan keistimewaan berlebihan atau tidak digunakan dengan cepat.

# Serangan suntikan prompt tidak langsung

### Pernyataan masalah

Pelayan MCP yang berniat jahat atau terkompromi boleh memperkenalkan risiko yang signifikan dengan mendedahkan data pelanggan atau membolehkan tindakan yang tidak diingini. Risiko ini sangat relevan dalam beban kerja AI dan berasaskan MCP, di mana:

- **Serangan Suntikan Prompt**: Penyerang menyematkan arahan berniat jahat dalam prompt atau kandungan luaran, menyebabkan sistem AI melaksanakan tindakan yang tidak diingini atau membocorkan data sensitif. Ketahui lebih lanjut: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Racun Alat**: Penyerang memanipulasi metadata alat (seperti deskripsi atau parameter) untuk mempengaruhi tingkah laku AI, berpotensi melewati kawalan keselamatan atau membocorkan data. Butiran: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Suntikan Prompt Lintas Domain**: Arahan berniat jahat disematkan dalam dokumen, halaman web, atau e-mel, yang kemudian diproses oleh AI, menyebabkan kebocoran atau manipulasi data.
- **Pengubahsuaian Alat Dinamik (Rug Pulls)**: Definisi alat boleh diubah selepas kelulusan pengguna, memperkenalkan tingkah laku berniat jahat baru tanpa kesedaran pengguna.

Kerentanan ini menekankan keperluan untuk pengesahan, pemantauan, dan kawalan keselamatan yang kukuh ketika mengintegrasikan pelayan dan alat MCP ke dalam persekitaran anda. Untuk penerokaan lebih mendalam, lihat rujukan yang dipautkan di atas.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.4b2f1af239a32d46221a75c7bc5b6f392ebbacc47eccde241d4c60507232fa43.ms.png)

**Suntikan Prompt Tidak Langsung** (juga dikenali sebagai suntikan prompt lintas domain atau XPIA) adalah kerentanan kritikal dalam sistem AI generatif, termasuk yang menggunakan Model Context Protocol (MCP). Dalam serangan ini, arahan berniat jahat disembunyikan dalam kandungan luaran—seperti dokumen, halaman web, atau e-mel. Apabila sistem AI memproses kandungan ini, ia mungkin menafsirkan arahan yang disematkan sebagai arahan pengguna yang sah, mengakibatkan tindakan yang tidak diingini seperti kebocoran data, penjanaan kandungan berbahaya, atau manipulasi interaksi pengguna. Untuk penjelasan terperinci dan contoh dunia nyata, lihat [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Bentuk serangan ini yang sangat berbahaya adalah **Racun Alat**. Di sini, penyerang menyuntik arahan berniat jahat ke dalam metadata alat MCP (seperti deskripsi alat atau parameter). Oleh kerana model bahasa besar (LLM) bergantung pada metadata ini untuk memutuskan alat mana yang akan dipanggil, deskripsi yang terkompromi boleh menipu model untuk melaksanakan panggilan alat yang tidak dibenarkan atau melewati kawalan keselamatan. Manipulasi ini sering tidak dapat dilihat oleh pengguna akhir tetapi boleh ditafsirkan dan dilaksanakan oleh sistem AI. Risiko ini meningkat dalam persekitaran pelayan MCP yang dihoskan, di mana definisi alat boleh dikemas kini selepas kelulusan pengguna—senario yang kadang-kadang dirujuk sebagai "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". Dalam kes sedemikian, alat yang sebelum ini selamat mungkin kemudian diubah untuk melaksanakan tindakan berniat jahat, seperti membocorkan data atau mengubah tingkah laku sistem, tanpa pengetahuan pengguna. Untuk maklumat lanjut mengenai vektor serangan ini, lihat [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.d4607023f69e16157954001ad81afd763676361f03db0a1cf24ec696b2ddcb88.ms.png)

## Risiko
Tindakan AI yang tidak diingini mempersembahkan pelbagai risiko keselamatan yang termasuk pencerobohan data dan pelanggaran privasi.

### Kawalan mitigasi
### Menggunakan perisai prompt untuk melindungi daripada serangan suntikan prompt tidak langsung
-----------------------------------------------------------------------------

**AI Prompt Shields** adalah penyelesaian yang dibangunkan oleh Microsoft untuk mempertahankan daripada serangan suntikan prompt langsung dan tidak langsung. Mereka membantu melalui:

1.  **Pengesanan dan Penapisan**: Prompt Shields menggunakan algoritma pembelajaran mesin canggih dan pemprosesan bahasa semulajadi untuk mengesan dan menapis arahan berniat jahat yang disematkan dalam kandungan luaran, seperti dokumen, halaman web, atau e-mel.
    
2.  **Spotlighting**: Teknik ini membantu sistem AI membezakan antara arahan sistem yang sah dan input luaran yang berpotensi tidak dipercayai. Dengan mengubah teks input dengan cara yang lebih relevan kepada model, Spotlighting memastikan AI dapat mengenal pasti dan mengabaikan arahan berniat jahat dengan lebih baik.
    
3.  **Pembatas dan Penandaan Data**: Termasuk pembatas dalam mesej sistem secara jelas menggariskan lokasi teks input, membantu sistem AI mengenali dan memisahkan input pengguna daripada kandungan luaran yang berpotensi berbahaya. Penandaan data memperluaskan konsep ini dengan menggunakan penanda khas untuk menonjolkan sempadan data yang dipercayai dan tidak dipercayai.
    
4.  **Pemantauan dan Kemas Kini Berterusan**: Microsoft memantau dan mengemas kini Prompt Shields secara berterusan untuk menangani ancaman baru dan yang berkembang. Pendekatan proaktif ini memastikan pertahanan tetap berkesan terhadap teknik serangan terkini.
    
5. **Integrasi dengan Azure Content Safety:** Prompt Shields adalah sebahagian daripada suite keselamatan kandungan Azure AI yang lebih luas, yang menyediakan alat tambahan untuk mengesan percubaan jailbreak, kandungan berbahaya, dan risiko keselamatan lain dalam aplikasi AI.

Anda boleh membaca lebih lanjut mengenai perisai prompt AI dalam [dokumentasi Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.a4dba28a04ea42d28053f233585290d4862b244ca1e59b8ff695c5530e1bba66.ms.png)

### Keselamatan rantaian bekalan

Keselamatan rantaian bekalan tetap asas dalam era AI, tetapi skop apa yang membentuk rantaian bekalan anda telah berkembang. Selain pakej kod tradisional, anda kini mesti mengesahkan dan memantau semua komponen berkaitan AI dengan teliti, termasuk model asas, perkhidmatan penambatan, penyedia konteks, dan API pihak ketiga. Setiap daripada ini boleh memperkenalkan kerentanan atau risiko jika tidak diuruskan dengan betul.

**Amalan keselamatan rantaian bekalan utama untuk AI dan MCP:**
- **Sahkan semua komponen sebelum integrasi:** Ini termasuk bukan sahaja perpustakaan sumber terbuka, tetapi juga model AI, sumber data, dan API luaran. Sentiasa periksa asal, pelesenan, dan kerentanan yang diketahui.
- **Mengekalkan saluran penyebaran yang selamat:** Gunakan saluran CI/CD automatik dengan pengimbasan keselamatan bersepadu untuk menangkap isu awal. Pastikan hanya artifak yang dipercayai disebarkan ke produksi.
- **Pantau dan audit secara berterusan:** Laksanakan pemantauan berterusan untuk semua kebergantungan, termasuk model dan perkhidmatan data, untuk mengesan kerentanan baru atau serangan rantaian bekalan.
- **Terapkan keistimewaan minimum dan kawalan akses:** Hadkan akses kepada model, data, dan perkhidmatan kepada hanya apa yang diperlukan untuk pelayan MCP anda berfungsi.
- **Bertindak balas dengan cepat terhadap ancaman:** Mempunyai proses untuk menampal atau menggantikan komponen yang terkompromi, dan untuk memutar rahsia atau kelayakan jika pelanggaran dikesan.

[GitHub Advanced Security](https://github.com/security/advanced-security) menyediakan ciri seperti pengimbasan rahsia, pengimbasan kebergantungan, dan analisis CodeQL. Alat-alat ini berintegrasi dengan [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) dan [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) untuk membantu pasukan mengenal pasti dan mengurangkan kerentanan merentas kod dan komponen rantaian bekalan AI.

Microsoft juga melaksanakan amalan keselamatan rantaian bekalan yang luas secara dalaman untuk semua produk. Ketahui lebih lanjut dalam [Perjalanan untuk Menjamin Rantaian Bekalan Perisian di Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Amalan keselamatan yang telah ditetapkan yang akan meningkatkan postur keselamatan pelaksanaan MCP anda

Mana-mana pelaksanaan MCP mewarisi postur keselamatan sedia ada persekitaran organisasi anda yang dibina di atasnya, jadi apabila mempertimbangkan keselamatan MCP sebagai komponen sistem AI keseluruhan anda, disyorkan agar anda melihat untuk meningkatkan postur keselamatan sedia ada keseluruhan anda. Kawalan keselamatan yang telah ditetapkan berikut adalah sangat relevan:

- Amalan terbaik pengkodan selamat dalam aplikasi AI anda - melindungi daripada [OWASP Top 10](https://owasp.org/www-project-top-ten/), [OWASP Top 10 untuk LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), penggunaan peti besi selamat untuk rahsia dan token, melaksanakan komunikasi selamat hujung ke hujung antara semua komponen aplikasi, dll.
- Pengukuhan pelayan - gunakan MFA di mana mungkin, pastikan tampalan terkini, integrasikan pelayan dengan penyedia identiti pihak ketiga untuk akses, dll.
- Pastikan peranti, infrastruktur dan aplikasi terkini dengan tampalan
- Pemantauan keselamatan - melaksanakan log dan pemantauan aplikasi AI (termasuk klien/pelayan MCP) dan menghantar log tersebut ke SIEM pusat untuk pengesanan aktiviti anomali
- Seni bina kepercayaan sifar - mengasingkan komponen melalui kawalan rangkaian dan identiti dengan cara yang logik untuk
- [OWASP Top 10 untuk LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Perjalanan untuk Menjamin Rantai Pembekalan Perisian di Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Akses Paling Minimum yang Selamat (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Amalan Terbaik untuk Pengesahan dan Tempoh Token](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Gunakan Penyimpanan Token yang Selamat dan Enkripsi Token (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Pengurusan API Azure sebagai Gerbang Pengesahan untuk MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Menggunakan Microsoft Entra ID untuk Pengesahan dengan Pelayan MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Seterusnya

Seterusnya: [Bab 3: Memulakan](/03-GettingStarted/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang berwibawa. Untuk maklumat kritikal, terjemahan manusia profesional adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.