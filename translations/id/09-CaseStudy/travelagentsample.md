<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d3415b9d2bf58bc69be07f945a69e07",
  "translation_date": "2025-06-13T21:50:55+00:00",
  "source_file": "09-CaseStudy/travelagentsample.md",
  "language_code": "id"
}
-->
# Studi Kasus: Azure AI Travel Agents – Implementasi Referensi

## Ikhtisar

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) adalah solusi referensi komprehensif yang dikembangkan oleh Microsoft yang menunjukkan cara membangun aplikasi perencanaan perjalanan bertenaga AI dengan banyak agen menggunakan Model Context Protocol (MCP), Azure OpenAI, dan Azure AI Search. Proyek ini menampilkan praktik terbaik untuk mengatur banyak agen AI, mengintegrasikan data perusahaan, dan menyediakan platform yang aman dan dapat diperluas untuk skenario dunia nyata.

## Fitur Utama
- **Orkestrasi Multi-Agen:** Memanfaatkan MCP untuk mengoordinasikan agen khusus (misalnya, agen penerbangan, hotel, dan rencana perjalanan) yang bekerja sama untuk menyelesaikan tugas perencanaan perjalanan yang kompleks.
- **Integrasi Data Perusahaan:** Terhubung ke Azure AI Search dan sumber data perusahaan lainnya untuk menyediakan informasi terbaru dan relevan bagi rekomendasi perjalanan.
- **Arsitektur Aman dan Skalabel:** Memanfaatkan layanan Azure untuk autentikasi, otorisasi, dan penyebaran yang skalabel, mengikuti praktik keamanan perusahaan terbaik.
- **Alat yang Dapat Diperluas:** Menerapkan alat MCP yang dapat digunakan ulang dan template prompt, memungkinkan adaptasi cepat ke domain atau kebutuhan bisnis baru.
- **Pengalaman Pengguna:** Menyediakan antarmuka percakapan bagi pengguna untuk berinteraksi dengan agen perjalanan, didukung oleh Azure OpenAI dan MCP.

## Arsitektur
![Architecture](https://raw.githubusercontent.com/Azure-Samples/azure-ai-travel-agents/main/docs/ai-travel-agents-architecture-diagram.png)

### Deskripsi Diagram Arsitektur

Solusi Azure AI Travel Agents dirancang untuk modularitas, skalabilitas, dan integrasi aman dari banyak agen AI dan sumber data perusahaan. Komponen utama dan aliran data adalah sebagai berikut:

- **Antarmuka Pengguna:** Pengguna berinteraksi dengan sistem melalui UI percakapan (seperti chat web atau bot Teams), yang mengirimkan pertanyaan pengguna dan menerima rekomendasi perjalanan.
- **MCP Server:** Berfungsi sebagai pengatur pusat, menerima input pengguna, mengelola konteks, dan mengoordinasikan tindakan agen khusus (misalnya FlightAgent, HotelAgent, ItineraryAgent) melalui Model Context Protocol.
- **Agen AI:** Setiap agen bertanggung jawab untuk domain tertentu (penerbangan, hotel, rencana perjalanan) dan diimplementasikan sebagai alat MCP. Agen menggunakan template prompt dan logika untuk memproses permintaan dan menghasilkan respons.
- **Azure OpenAI Service:** Menyediakan pemahaman dan generasi bahasa alami yang canggih, memungkinkan agen memahami maksud pengguna dan menghasilkan respons percakapan.
- **Azure AI Search & Data Perusahaan:** Agen melakukan kueri ke Azure AI Search dan sumber data perusahaan lainnya untuk mendapatkan informasi terkini tentang penerbangan, hotel, dan opsi perjalanan.
- **Autentikasi & Keamanan:** Terintegrasi dengan Microsoft Entra ID untuk autentikasi yang aman dan menerapkan kontrol akses hak minimum ke semua sumber daya.
- **Penyebaran:** Dirancang untuk penyebaran di Azure Container Apps, memastikan skalabilitas, pemantauan, dan efisiensi operasional.

Arsitektur ini memungkinkan orkestrasi mulus dari banyak agen AI, integrasi aman dengan data perusahaan, dan platform yang kuat serta dapat diperluas untuk membangun solusi AI spesifik domain.

## Penjelasan Langkah demi Langkah Diagram Arsitektur
Bayangkan merencanakan perjalanan besar dan memiliki tim asisten ahli yang membantu Anda dengan setiap detail. Sistem Azure AI Travel Agents bekerja dengan cara serupa, menggunakan bagian-bagian berbeda (seperti anggota tim) yang masing-masing memiliki tugas khusus. Berikut cara semuanya bekerja bersama:

### Antarmuka Pengguna (UI):
Bayangkan ini sebagai meja depan agen perjalanan Anda. Di sini Anda (pengguna) mengajukan pertanyaan atau permintaan, seperti “Cari penerbangan ke Paris.” Ini bisa berupa jendela chat di situs web atau aplikasi pesan.

### MCP Server (Koordinator):
MCP Server seperti manajer yang mendengarkan permintaan Anda di meja depan dan memutuskan spesialis mana yang harus menangani setiap bagian. Server ini menjaga percakapan Anda dan memastikan semuanya berjalan lancar.

### Agen AI (Asisten Spesialis):
Setiap agen adalah ahli di bidang tertentu—satu menguasai penerbangan, satu lagi hotel, dan satu lagi perencanaan rencana perjalanan. Ketika Anda meminta perjalanan, MCP Server mengirim permintaan Anda ke agen yang tepat. Agen-agen ini menggunakan pengetahuan dan alat mereka untuk menemukan opsi terbaik bagi Anda.

### Azure OpenAI Service (Ahli Bahasa):
Ini seperti memiliki ahli bahasa yang memahami dengan tepat apa yang Anda tanyakan, tidak peduli bagaimana Anda mengungkapkannya. Ini membantu agen memahami permintaan Anda dan merespons dengan bahasa percakapan yang alami.

### Azure AI Search & Data Perusahaan (Perpustakaan Informasi):
Bayangkan perpustakaan besar dan terkini dengan semua informasi perjalanan terbaru—jadwal penerbangan, ketersediaan hotel, dan lainnya. Agen mencari perpustakaan ini untuk mendapatkan jawaban yang paling akurat untuk Anda.

### Autentikasi & Keamanan (Penjaga Keamanan):
Seperti penjaga keamanan yang memeriksa siapa yang boleh masuk ke area tertentu, bagian ini memastikan hanya orang dan agen yang berwenang yang dapat mengakses informasi sensitif. Ini menjaga data Anda tetap aman dan pribadi.

### Penyebaran di Azure Container Apps (Gedung):
Semua asisten dan alat ini bekerja bersama di dalam gedung yang aman dan skalabel (cloud). Ini berarti sistem dapat menangani banyak pengguna sekaligus dan selalu tersedia saat Anda membutuhkannya.

## Cara semuanya bekerja bersama:

Anda mulai dengan mengajukan pertanyaan di meja depan (UI).
Manajer (MCP Server) menentukan spesialis (agen) mana yang akan membantu Anda.
Spesialis menggunakan ahli bahasa (OpenAI) untuk memahami permintaan Anda dan perpustakaan (AI Search) untuk mencari jawaban terbaik.
Penjaga keamanan (Autentikasi) memastikan semuanya aman.
Semua ini terjadi di dalam gedung yang andal dan skalabel (Azure Container Apps), sehingga pengalaman Anda lancar dan aman.
Kerjasama ini memungkinkan sistem membantu Anda merencanakan perjalanan dengan cepat dan aman, seperti tim agen perjalanan ahli yang bekerja bersama di kantor modern!

## Implementasi Teknis
- **MCP Server:** Menyediakan logika orkestrasi inti, mengekspose alat agen, dan mengelola konteks untuk alur kerja perencanaan perjalanan multi-langkah.
- **Agen:** Setiap agen (misalnya FlightAgent, HotelAgent) diimplementasikan sebagai alat MCP dengan template prompt dan logika masing-masing.
- **Integrasi Azure:** Menggunakan Azure OpenAI untuk pemahaman bahasa alami dan Azure AI Search untuk pengambilan data.
- **Keamanan:** Terintegrasi dengan Microsoft Entra ID untuk autentikasi dan menerapkan kontrol akses hak minimum ke semua sumber daya.
- **Penyebaran:** Mendukung penyebaran ke Azure Container Apps untuk skalabilitas dan efisiensi operasional.

## Hasil dan Dampak
- Menunjukkan bagaimana MCP dapat digunakan untuk mengoordinasikan banyak agen AI dalam skenario produksi dunia nyata.
- Mempercepat pengembangan solusi dengan menyediakan pola yang dapat digunakan ulang untuk koordinasi agen, integrasi data, dan penyebaran yang aman.
- Berfungsi sebagai cetak biru untuk membangun aplikasi bertenaga AI spesifik domain menggunakan MCP dan layanan Azure.

## Referensi
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sah. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.