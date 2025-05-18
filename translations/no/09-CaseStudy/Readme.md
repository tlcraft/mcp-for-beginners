<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b6b1bc868efed4cf02c52f8deada559d",
  "translation_date": "2025-05-17T17:30:07+00:00",
  "source_file": "09-CaseStudy/Readme.md",
  "language_code": "no"
}
-->
# Case Study: Azure AI Travel Agents – Reference Implementation

## Overview

[Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) adalah solusi referensi komprehensif yang dikembangkan oleh Microsoft yang menunjukkan cara membangun aplikasi perencanaan perjalanan bertenaga AI multi-agen menggunakan Model Context Protocol (MCP), Azure OpenAI, dan Azure AI Search. Proyek ini menampilkan praktik terbaik untuk mengorkestrasi beberapa agen AI, mengintegrasikan data perusahaan, dan menyediakan platform yang aman dan dapat diperluas untuk skenario dunia nyata.

## Key Features
- **Orkestrasi Multi-Agen:** Memanfaatkan MCP untuk mengoordinasikan agen khusus (misalnya, agen penerbangan, hotel, dan rencana perjalanan) yang bekerja sama untuk menyelesaikan tugas perencanaan perjalanan yang kompleks.
- **Integrasi Data Perusahaan:** Terhubung ke Azure AI Search dan sumber data perusahaan lainnya untuk menyediakan informasi terkini dan relevan untuk rekomendasi perjalanan.
- **Arsitektur Aman dan Skalabel:** Memanfaatkan layanan Azure untuk otentikasi, otorisasi, dan penerapan yang skalabel, mengikuti praktik terbaik keamanan perusahaan.
- **Alat yang Dapat Diperluas:** Mengimplementasikan alat MCP yang dapat digunakan kembali dan templat prompt, memungkinkan adaptasi cepat ke domain baru atau persyaratan bisnis.
- **Pengalaman Pengguna:** Menyediakan antarmuka percakapan bagi pengguna untuk berinteraksi dengan agen perjalanan, didukung oleh Azure OpenAI dan MCP.

## Architecture
![Architecture](https://github.com/Azure-Samples/azure-ai-travel-agents/blob/main/docs/ai-travel-agents-architecture-diagram.png)

### Architecture Diagram Description

Solusi Azure AI Travel Agents dirancang untuk modularitas, skalabilitas, dan integrasi yang aman dari beberapa agen AI dan sumber data perusahaan. Komponen utama dan aliran data adalah sebagai berikut:

- **Antarmuka Pengguna:** Pengguna berinteraksi dengan sistem melalui UI percakapan (seperti obrolan web atau bot Teams), yang mengirimkan kueri pengguna dan menerima rekomendasi perjalanan.
- **MCP Server:** Berfungsi sebagai pengatur pusat, menerima input pengguna, mengelola konteks, dan mengoordinasikan tindakan agen khusus (misalnya, FlightAgent, HotelAgent, ItineraryAgent) melalui Model Context Protocol.
- **AI Agents:** Setiap agen bertanggung jawab atas domain tertentu (penerbangan, hotel, rencana perjalanan) dan diimplementasikan sebagai alat MCP. Agen menggunakan templat prompt dan logika untuk memproses permintaan dan menghasilkan respons.
- **Azure OpenAI Service:** Menyediakan pemahaman dan pembuatan bahasa alami yang canggih, memungkinkan agen menafsirkan maksud pengguna dan menghasilkan respons percakapan.
- **Azure AI Search & Enterprise Data:** Agen melakukan kueri ke Azure AI Search dan sumber data perusahaan lainnya untuk mendapatkan informasi terkini tentang penerbangan, hotel, dan opsi perjalanan.
- **Otentikasi & Keamanan:** Terintegrasi dengan Microsoft Entra ID untuk otentikasi yang aman dan menerapkan kontrol akses hak istimewa minimal ke semua sumber daya.
- **Penerapan:** Dirancang untuk penerapan di Azure Container Apps, memastikan skalabilitas, pemantauan, dan efisiensi operasional.

Arsitektur ini memungkinkan orkestrasi yang mulus dari beberapa agen AI, integrasi yang aman dengan data perusahaan, dan platform yang kuat dan dapat diperluas untuk membangun solusi AI khusus domain.

## Step-by-Step Explanation of the Architecture Diagram
Bayangkan merencanakan perjalanan besar dan memiliki tim asisten ahli yang membantu Anda dengan setiap detail. Sistem Azure AI Travel Agents bekerja dengan cara yang serupa, menggunakan bagian yang berbeda (seperti anggota tim) yang masing-masing memiliki pekerjaan khusus. Berikut cara kerjanya:

### User Interface (UI):
Anggap ini sebagai meja depan agen perjalanan Anda. Di sinilah Anda (pengguna) mengajukan pertanyaan atau membuat permintaan, seperti "Temukan saya penerbangan ke Paris." Ini bisa berupa jendela obrolan di situs web atau aplikasi pesan.

### MCP Server (The Coordinator):
Server MCP seperti manajer yang mendengarkan permintaan Anda di meja depan dan memutuskan spesialis mana yang harus menangani setiap bagian. Ia melacak percakapan Anda dan memastikan semuanya berjalan lancar.

### AI Agents (Specialist Assistants):
Setiap agen adalah ahli dalam area tertentu—satu tahu semua tentang penerbangan, yang lain tentang hotel, dan yang lain tentang merencanakan rencana perjalanan Anda. Ketika Anda meminta perjalanan, Server MCP mengirimkan permintaan Anda ke agen yang tepat. Agen-agen ini menggunakan pengetahuan dan alat mereka untuk menemukan opsi terbaik untuk Anda.

### Azure OpenAI Service (Language Expert):
Ini seperti memiliki ahli bahasa yang memahami persis apa yang Anda minta, tidak peduli bagaimana Anda mengungkapkannya. Ini membantu agen memahami permintaan Anda dan merespons dalam bahasa percakapan yang alami.

### Azure AI Search & Enterprise Data (Information Library):
Bayangkan perpustakaan besar dan terkini dengan semua info perjalanan terbaru—jadwal penerbangan, ketersediaan hotel, dan lainnya. Agen mencari perpustakaan ini untuk mendapatkan jawaban yang paling akurat untuk Anda.

### Authentication & Security (Security Guard):
Seperti penjaga keamanan memeriksa siapa yang dapat memasuki area tertentu, bagian ini memastikan hanya orang dan agen yang berwenang yang dapat mengakses informasi sensitif. Ini menjaga data Anda tetap aman dan pribadi.

### Deployment on Azure Container Apps (The Building):
Semua asisten dan alat ini bekerja sama di dalam gedung yang aman dan skalabel (cloud). Ini berarti sistem dapat menangani banyak pengguna sekaligus dan selalu tersedia ketika Anda membutuhkannya.

## How it all works together:

Anda mulai dengan mengajukan pertanyaan di meja depan (UI).
Manajer (MCP Server) mencari tahu spesialis (agen) mana yang harus membantu Anda.
Spesialis menggunakan ahli bahasa (OpenAI) untuk memahami permintaan Anda dan perpustakaan (AI Search) untuk menemukan jawaban terbaik.
Penjaga keamanan (Otentikasi) memastikan semuanya aman.
Semua ini terjadi di dalam gedung yang dapat diandalkan dan skalabel (Azure Container Apps), sehingga pengalaman Anda lancar dan aman.
Kerja sama ini memungkinkan sistem untuk dengan cepat dan aman membantu Anda merencanakan perjalanan, seperti tim agen perjalanan ahli yang bekerja sama di kantor modern!

## Technical Implementation
- **MCP Server:** Menampung logika orkestrasi inti, mengekspos alat agen, dan mengelola konteks untuk alur kerja perencanaan perjalanan multi-langkah.
- **Agents:** Setiap agen (misalnya, FlightAgent, HotelAgent) diimplementasikan sebagai alat MCP dengan templat prompt dan logikanya sendiri.
- **Azure Integration:** Menggunakan Azure OpenAI untuk pemahaman bahasa alami dan Azure AI Search untuk pengambilan data.
- **Security:** Terintegrasi dengan Microsoft Entra ID untuk otentikasi dan menerapkan kontrol akses hak istimewa minimal ke semua sumber daya.
- **Deployment:** Mendukung penerapan ke Azure Container Apps untuk skalabilitas dan efisiensi operasional.

## Results and Impact
- Menunjukkan bagaimana MCP dapat digunakan untuk mengorkestrasi beberapa agen AI dalam skenario dunia nyata yang siap produksi.
- Mempercepat pengembangan solusi dengan menyediakan pola yang dapat digunakan kembali untuk koordinasi agen, integrasi data, dan penerapan yang aman.
- Berfungsi sebagai cetak biru untuk membangun aplikasi bertenaga AI khusus domain menggunakan MCP dan layanan Azure.

## References
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Ansvarsfraskrivelse**:  
Dette dokumentet har blitt oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Vi bestreber oss på å oppnå nøyaktighet, men vær oppmerksom på at automatiserte oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på sitt opprinnelige språk bør betraktes som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.