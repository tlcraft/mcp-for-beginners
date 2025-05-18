<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b6b1bc868efed4cf02c52f8deada559d",
  "translation_date": "2025-05-17T17:32:07+00:00",
  "source_file": "09-CaseStudy/Readme.md",
  "language_code": "id"
}
-->
# Studi Kasus: Agen Perjalanan Azure AI – Implementasi Referensi

## Ikhtisar

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) adalah solusi referensi komprehensif yang dikembangkan oleh Microsoft yang menunjukkan cara membangun aplikasi perencanaan perjalanan bertenaga AI dengan banyak agen menggunakan Model Context Protocol (MCP), Azure OpenAI, dan Azure AI Search. Proyek ini menampilkan praktik terbaik untuk mengorkestrasi banyak agen AI, mengintegrasikan data perusahaan, dan menyediakan platform yang aman dan dapat diperluas untuk skenario dunia nyata.

## Fitur Utama
- **Orkestrasi Multi-Agen:** Menggunakan MCP untuk mengoordinasikan agen-agen khusus (misalnya, agen penerbangan, hotel, dan rencana perjalanan) yang berkolaborasi untuk menyelesaikan tugas perencanaan perjalanan yang kompleks.
- **Integrasi Data Perusahaan:** Terhubung ke Azure AI Search dan sumber data perusahaan lainnya untuk menyediakan informasi terbaru dan relevan untuk rekomendasi perjalanan.
- **Arsitektur Aman dan Skalabel:** Memanfaatkan layanan Azure untuk autentikasi, otorisasi, dan penyebaran yang skalabel, mengikuti praktik terbaik keamanan perusahaan.
- **Alat yang Dapat Diperluas:** Menerapkan alat MCP yang dapat digunakan kembali dan templat prompt, memungkinkan adaptasi cepat ke domain atau kebutuhan bisnis baru.
- **Pengalaman Pengguna:** Menyediakan antarmuka percakapan bagi pengguna untuk berinteraksi dengan agen perjalanan, didukung oleh Azure OpenAI dan MCP.

## Arsitektur
![Arsitektur](https://github.com/Azure-Samples/azure-ai-travel-agents/blob/main/docs/ai-travel-agents-architecture-diagram.png)

### Deskripsi Diagram Arsitektur

Solusi Azure AI Travel Agents dirancang untuk modularitas, skalabilitas, dan integrasi aman dari beberapa agen AI dan sumber data perusahaan. Komponen utama dan aliran data adalah sebagai berikut:

- **Antarmuka Pengguna:** Pengguna berinteraksi dengan sistem melalui UI percakapan (seperti obrolan web atau bot Teams), yang mengirimkan pertanyaan pengguna dan menerima rekomendasi perjalanan.
- **MCP Server:** Berfungsi sebagai pengatur pusat, menerima input pengguna, mengelola konteks, dan mengoordinasikan tindakan agen khusus (misalnya, FlightAgent, HotelAgent, ItineraryAgent) melalui Model Context Protocol.
- **Agen AI:** Setiap agen bertanggung jawab untuk domain tertentu (penerbangan, hotel, rencana perjalanan) dan diimplementasikan sebagai alat MCP. Agen menggunakan templat prompt dan logika untuk memproses permintaan dan menghasilkan respons.
- **Layanan Azure OpenAI:** Menyediakan pemahaman dan generasi bahasa alami tingkat lanjut, memungkinkan agen untuk menafsirkan maksud pengguna dan menghasilkan respons percakapan.
- **Azure AI Search & Data Perusahaan:** Agen mengkueri Azure AI Search dan sumber data perusahaan lainnya untuk mendapatkan informasi terbaru tentang penerbangan, hotel, dan opsi perjalanan.
- **Autentikasi & Keamanan:** Terintegrasi dengan Microsoft Entra ID untuk autentikasi yang aman dan menerapkan kontrol akses dengan hak istimewa paling rendah ke semua sumber daya.
- **Penyebaran:** Dirancang untuk penyebaran di Azure Container Apps, memastikan skalabilitas, pemantauan, dan efisiensi operasional.

Arsitektur ini memungkinkan orkestrasi mulus dari beberapa agen AI, integrasi aman dengan data perusahaan, dan platform yang kuat serta dapat diperluas untuk membangun solusi AI spesifik domain.

## Penjelasan Langkah-demi-Langkah dari Diagram Arsitektur
Bayangkan merencanakan perjalanan besar dan memiliki tim asisten ahli yang membantu Anda dengan setiap detail. Sistem Azure AI Travel Agents bekerja dengan cara yang mirip, menggunakan bagian-bagian berbeda (seperti anggota tim) yang masing-masing memiliki pekerjaan khusus. Berikut cara kerjanya:

### Antarmuka Pengguna (UI):
Anggaplah ini sebagai meja depan agen perjalanan Anda. Di sinilah Anda (pengguna) mengajukan pertanyaan atau membuat permintaan, seperti "Carikan saya penerbangan ke Paris." Ini bisa berupa jendela obrolan di situs web atau aplikasi pesan.

### MCP Server (Koordinator):
MCP Server seperti manajer yang mendengarkan permintaan Anda di meja depan dan memutuskan spesialis mana yang harus menangani setiap bagian. Ini melacak percakapan Anda dan memastikan semuanya berjalan lancar.

### Agen AI (Asisten Spesialis):
Setiap agen adalah ahli dalam area tertentu—satu tahu semua tentang penerbangan, yang lain tentang hotel, dan yang lain tentang merencanakan rencana perjalanan Anda. Ketika Anda meminta perjalanan, MCP Server mengirimkan permintaan Anda ke agen yang tepat. Agen-agen ini menggunakan pengetahuan dan alat mereka untuk menemukan opsi terbaik untuk Anda.

### Layanan Azure OpenAI (Pakar Bahasa):
Ini seperti memiliki pakar bahasa yang memahami persis apa yang Anda minta, tidak peduli bagaimana Anda mengungkapkannya. Ini membantu agen memahami permintaan Anda dan merespons dalam bahasa percakapan yang alami.

### Azure AI Search & Data Perusahaan (Perpustakaan Informasi):
Bayangkan perpustakaan besar yang selalu diperbarui dengan semua info perjalanan terbaru—jadwal penerbangan, ketersediaan hotel, dan lainnya. Agen mencari di perpustakaan ini untuk mendapatkan jawaban paling akurat untuk Anda.

### Autentikasi & Keamanan (Penjaga Keamanan):
Seperti penjaga keamanan yang memeriksa siapa yang bisa masuk ke area tertentu, bagian ini memastikan hanya orang dan agen yang berwenang yang dapat mengakses informasi sensitif. Ini menjaga data Anda tetap aman dan pribadi.

### Penyebaran di Azure Container Apps (Bangunan):
Semua asisten dan alat ini bekerja sama di dalam bangunan yang aman dan skalabel (cloud). Ini berarti sistem dapat menangani banyak pengguna sekaligus dan selalu tersedia ketika Anda membutuhkannya.

## Bagaimana semuanya bekerja bersama:

Anda mulai dengan mengajukan pertanyaan di meja depan (UI).
Manajer (MCP Server) menentukan spesialis (agen) mana yang harus membantu Anda.
Spesialis menggunakan pakar bahasa (OpenAI) untuk memahami permintaan Anda dan perpustakaan (AI Search) untuk menemukan jawaban terbaik.
Penjaga keamanan (Autentikasi) memastikan semuanya aman.
Semua ini terjadi di dalam bangunan yang andal dan skalabel (Azure Container Apps), sehingga pengalaman Anda lancar dan aman.
Kerja tim ini memungkinkan sistem untuk dengan cepat dan aman membantu Anda merencanakan perjalanan Anda, seperti tim agen perjalanan ahli yang bekerja bersama di kantor modern!

## Implementasi Teknis
- **MCP Server:** Menyediakan logika orkestrasi inti, mengekspos alat agen, dan mengelola konteks untuk alur kerja perencanaan perjalanan multi-langkah.
- **Agen:** Setiap agen (misalnya, FlightAgent, HotelAgent) diimplementasikan sebagai alat MCP dengan templat prompt dan logika masing-masing.
- **Integrasi Azure:** Menggunakan Azure OpenAI untuk pemahaman bahasa alami dan Azure AI Search untuk pengambilan data.
- **Keamanan:** Terintegrasi dengan Microsoft Entra ID untuk autentikasi dan menerapkan kontrol akses dengan hak istimewa paling rendah ke semua sumber daya.
- **Penyebaran:** Mendukung penyebaran ke Azure Container Apps untuk skalabilitas dan efisiensi operasional.

## Hasil dan Dampak
- Menunjukkan bagaimana MCP dapat digunakan untuk mengorkestrasi beberapa agen AI dalam skenario produksi dunia nyata.
- Mempercepat pengembangan solusi dengan menyediakan pola yang dapat digunakan kembali untuk koordinasi agen, integrasi data, dan penyebaran aman.
- Berfungsi sebagai cetak biru untuk membangun aplikasi bertenaga AI spesifik domain menggunakan MCP dan layanan Azure.

## Referensi
- [Repositori GitHub Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Layanan Azure OpenAI](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang berwenang. Untuk informasi penting, disarankan menggunakan terjemahan manusia profesional. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang salah yang timbul dari penggunaan terjemahan ini.