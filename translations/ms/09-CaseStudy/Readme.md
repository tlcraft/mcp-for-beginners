<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b6b1bc868efed4cf02c52f8deada559d",
  "translation_date": "2025-05-17T17:32:31+00:00",
  "source_file": "09-CaseStudy/Readme.md",
  "language_code": "ms"
}
-->
# Kajian Kes: Ejen Pelancongan Azure AI – Pelaksanaan Rujukan

## Gambaran Keseluruhan

[Ejen Pelancongan Azure AI](https://github.com/Azure-Samples/azure-ai-travel-agents) adalah penyelesaian rujukan komprehensif yang dibangunkan oleh Microsoft yang menunjukkan cara membina aplikasi perancangan perjalanan berkuasa AI dengan berbilang ejen menggunakan Model Context Protocol (MCP), Azure OpenAI, dan Azure AI Search. Projek ini mempamerkan amalan terbaik untuk mengorchestrasi berbilang ejen AI, mengintegrasikan data perusahaan, dan menyediakan platform yang selamat dan boleh diperluas untuk senario dunia sebenar.

## Ciri-ciri Utama
- **Orkestrasi Berbilang Ejen:** Menggunakan MCP untuk menyelaraskan ejen pakar (contohnya, ejen penerbangan, hotel, dan jadual perjalanan) yang bekerjasama untuk memenuhi tugas perancangan perjalanan yang kompleks.
- **Integrasi Data Perusahaan:** Menyambung ke Azure AI Search dan sumber data perusahaan lain untuk menyediakan maklumat terkini dan relevan bagi cadangan perjalanan.
- **Seni Bina Selamat dan Boleh Skala:** Memanfaatkan perkhidmatan Azure untuk pengesahan, kebenaran, dan penempatan boleh skala, mengikut amalan terbaik keselamatan perusahaan.
- **Alat Boleh Diperluas:** Melaksanakan alat MCP yang boleh digunakan semula dan templat prompt, membolehkan penyesuaian pantas kepada domain baru atau keperluan perniagaan.
- **Pengalaman Pengguna:** Menyediakan antara muka perbualan untuk pengguna berinteraksi dengan ejen pelancongan, dikuasakan oleh Azure OpenAI dan MCP.

## Seni Bina
![Seni Bina](https://github.com/Azure-Samples/azure-ai-travel-agents/blob/main/docs/ai-travel-agents-architecture-diagram.png)

### Penerangan Rajah Seni Bina

Penyelesaian Ejen Pelancongan Azure AI direka untuk modulariti, kebolehskalaan, dan integrasi selamat berbilang ejen AI dan sumber data perusahaan. Komponen utama dan aliran data adalah seperti berikut:

- **Antara Muka Pengguna:** Pengguna berinteraksi dengan sistem melalui UI perbualan (seperti sembang web atau bot Teams), yang menghantar pertanyaan pengguna dan menerima cadangan perjalanan.
- **Pelayan MCP:** Berfungsi sebagai pengorkestra pusat, menerima input pengguna, mengurus konteks, dan menyelaraskan tindakan ejen pakar (contohnya, FlightAgent, HotelAgent, ItineraryAgent) melalui Model Context Protocol.
- **Ejen AI:** Setiap ejen bertanggungjawab untuk domain tertentu (penerbangan, hotel, jadual perjalanan) dan dilaksanakan sebagai alat MCP. Ejen menggunakan templat prompt dan logik untuk memproses permintaan dan menjana respons.
- **Perkhidmatan Azure OpenAI:** Menyediakan pemahaman dan penjanaan bahasa semula jadi yang maju, membolehkan ejen mentafsir niat pengguna dan menjana respons perbualan.
- **Azure AI Search & Data Perusahaan:** Ejen menyoal Azure AI Search dan sumber data perusahaan lain untuk mendapatkan maklumat terkini mengenai penerbangan, hotel, dan pilihan perjalanan.
- **Pengesahan & Keselamatan:** Berintegrasi dengan Microsoft Entra ID untuk pengesahan selamat dan menerapkan kawalan akses hak minimum kepada semua sumber.
- **Penempatan:** Direka untuk penempatan pada Azure Container Apps, memastikan kebolehskalaan, pemantauan, dan kecekapan operasi.

Seni bina ini membolehkan orkestrasi lancar berbilang ejen AI, integrasi selamat dengan data perusahaan, dan platform yang kukuh dan boleh diperluas untuk membina penyelesaian AI khusus domain.

## Penjelasan Langkah demi Langkah Rajah Seni Bina
Bayangkan merancang perjalanan besar dan mempunyai pasukan pembantu pakar membantu anda dengan setiap perincian. Sistem Ejen Pelancongan Azure AI berfungsi dengan cara yang serupa, menggunakan bahagian yang berbeza (seperti ahli pasukan) yang masing-masing mempunyai tugas khas. Inilah cara semuanya sesuai bersama:

### Antara Muka Pengguna (UI):
Anggap ini sebagai kaunter depan ejen pelancongan anda. Di sinilah anda (pengguna) bertanya soalan atau membuat permintaan, seperti "Cari saya penerbangan ke Paris." Ini boleh menjadi tingkap sembang di laman web atau aplikasi mesej.

### Pelayan MCP (Penyelaras):
Pelayan MCP seperti pengurus yang mendengar permintaan anda di kaunter depan dan memutuskan pakar mana yang harus menangani setiap bahagian. Ia menyimpan rekod perbualan anda dan memastikan semuanya berjalan lancar.

### Ejen AI (Pembantu Pakar):
Setiap ejen adalah pakar dalam bidang tertentu—satu tahu semua tentang penerbangan, satu lagi tentang hotel, dan satu lagi tentang merancang jadual perjalanan anda. Apabila anda meminta perjalanan, Pelayan MCP menghantar permintaan anda kepada ejen yang betul. Ejen-ejen ini menggunakan pengetahuan dan alat mereka untuk mencari pilihan terbaik untuk anda.

### Perkhidmatan Azure OpenAI (Pakar Bahasa):
Ini seperti mempunyai pakar bahasa yang memahami dengan tepat apa yang anda minta, tidak kira bagaimana anda mengungkapkannya. Ia membantu ejen memahami permintaan anda dan bertindak balas dalam bahasa perbualan semula jadi.

### Azure AI Search & Data Perusahaan (Perpustakaan Maklumat):
Bayangkan sebuah perpustakaan besar yang sentiasa terkini dengan semua maklumat perjalanan terkini—jadual penerbangan, ketersediaan hotel, dan banyak lagi. Ejen mencari perpustakaan ini untuk mendapatkan jawapan yang paling tepat untuk anda.

### Pengesahan & Keselamatan (Pengawal Keselamatan):
Seperti pengawal keselamatan memeriksa siapa yang boleh memasuki kawasan tertentu, bahagian ini memastikan hanya orang dan ejen yang diberi kuasa boleh mengakses maklumat sensitif. Ia menjaga data anda selamat dan peribadi.

### Penempatan pada Azure Container Apps (Bangunan):
Semua pembantu dan alat ini bekerjasama di dalam bangunan yang selamat dan boleh skala (awan). Ini bermakna sistem boleh menangani banyak pengguna sekaligus dan sentiasa tersedia apabila anda memerlukannya.

## Bagaimana semuanya berfungsi bersama:

Anda bermula dengan bertanya soalan di kaunter depan (UI).
Pengurus (Pelayan MCP) menentukan pakar (ejen) mana yang harus membantu anda.
Pakar menggunakan pakar bahasa (OpenAI) untuk memahami permintaan anda dan perpustakaan (AI Search) untuk mencari jawapan terbaik.
Pengawal keselamatan (Pengesahan) memastikan semuanya selamat.
Semua ini berlaku di dalam bangunan yang boleh dipercayai dan boleh skala (Azure Container Apps), jadi pengalaman anda lancar dan selamat.
Kerjasama ini membolehkan sistem dengan cepat dan selamat membantu anda merancang perjalanan anda, seperti pasukan ejen pelancongan pakar bekerja bersama dalam pejabat moden!

## Pelaksanaan Teknikal
- **Pelayan MCP:** Menempatkan logik orkestrasi teras, mendedahkan alat ejen, dan mengurus konteks untuk aliran kerja perancangan perjalanan berbilang langkah.
- **Ejen:** Setiap ejen (contohnya, FlightAgent, HotelAgent) dilaksanakan sebagai alat MCP dengan templat prompt dan logiknya sendiri.
- **Integrasi Azure:** Menggunakan Azure OpenAI untuk pemahaman bahasa semula jadi dan Azure AI Search untuk pengambilan data.
- **Keselamatan:** Berintegrasi dengan Microsoft Entra ID untuk pengesahan dan menerapkan kawalan akses hak minimum kepada semua sumber.
- **Penempatan:** Menyokong penempatan ke Azure Container Apps untuk kebolehskalaan dan kecekapan operasi.

## Keputusan dan Impak
- Menunjukkan bagaimana MCP boleh digunakan untuk mengorkestra berbilang ejen AI dalam senario pengeluaran dunia sebenar.
- Mempercepatkan pembangunan penyelesaian dengan menyediakan corak yang boleh digunakan semula untuk penyelarasan ejen, integrasi data, dan penempatan selamat.
- Berfungsi sebagai pelan untuk membina aplikasi berkuasa AI khusus domain menggunakan MCP dan perkhidmatan Azure.

## Rujukan
- [Repositori GitHub Ejen Pelancongan Azure AI](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Perkhidmatan Azure OpenAI](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang berwibawa. Untuk maklumat penting, terjemahan manusia profesional disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.