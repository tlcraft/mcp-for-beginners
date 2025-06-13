<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3b97186cd9162b9fe9b90261e63e32d",
  "translation_date": "2025-06-13T14:21:38+00:00",
  "source_file": "README.md",
  "language_code": "id"
}
-->
![MCP-untuk-pemula](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.id.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


Ikuti langkah-langkah ini untuk memulai menggunakan sumber daya ini:
1. **Fork Repository**: Klik [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Clone Repository**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Bergabung dengan Azure AI Foundry Discord dan temui para ahli serta pengembang lainnya**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Dukungan Multi-Bahasa

#### Didukung melalui GitHub Action (Otomatis & Selalu Terbaru)

# 🚀 Kurikulum Model Context Protocol (MCP) untuk Pemula

## **Belajar MCP dengan Contoh Kode Praktis dalam C#, Java, JavaScript, Python, dan TypeScript**

## 🧠 Gambaran Umum Kurikulum Model Context Protocol

**Model Context Protocol (MCP)** adalah kerangka kerja mutakhir yang dirancang untuk menstandarisasi interaksi antara model AI dan aplikasi klien. Kurikulum open-source ini menawarkan jalur pembelajaran terstruktur, lengkap dengan contoh kode praktis dan kasus penggunaan nyata, dalam bahasa pemrograman populer seperti C#, Java, JavaScript, TypeScript, dan Python.

Baik Anda pengembang AI, arsitek sistem, atau insinyur perangkat lunak, panduan ini adalah sumber daya lengkap untuk menguasai dasar-dasar MCP dan strategi implementasinya.

## 🔗 Sumber Resmi MCP

- 📘 [MCP Documentation](https://modelcontextprotocol.io/) – Tutorial dan panduan pengguna secara detail  
- 📜 [MCP Specification](https://spec.modelcontextprotocol.io/) – Arsitektur protokol dan referensi teknis  
- 🧑‍💻 [MCP GitHub Repository](https://github.com/modelcontextprotocol) – SDK open-source, alat, dan contoh kode  

## 🧭 Struktur Lengkap Kurikulum MCP

| Ch | Judul | Deskripsi | Tautan |
|--|--|--|--|
| 00 | **Pengantar MCP** | Gambaran umum Model Context Protocol dan pentingnya dalam pipeline AI, termasuk apa itu Model Context Protocol, mengapa standarisasi penting, serta kasus penggunaan dan manfaat praktis | [Introduction](./00-Introduction/README.md) |
| 01 | **Konsep Inti Dijelaskan** | Penjelasan mendalam tentang konsep inti MCP, termasuk arsitektur client-server, komponen utama protokol, dan pola pesan | [Core Concepts](./01-CoreConcepts/README.md) |
| 02 | **Keamanan dalam MCP** | Mengidentifikasi ancaman keamanan dalam sistem berbasis MCP, teknik dan praktik terbaik untuk mengamankan implementasi | [Security](/02-Security/README.md) |
| 03 | **Memulai dengan MCP** | Pengaturan dan konfigurasi lingkungan, membuat server dan klien MCP dasar, mengintegrasikan MCP dengan aplikasi yang sudah ada | [Getting Started](./03-GettingStarted/README.md) |
| 3.1 | **Server pertama** | Menyiapkan server dasar menggunakan protokol MCP, memahami interaksi server-klien, dan menguji server | [First Server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Klien pertama**  | Menyiapkan klien dasar menggunakan protokol MCP, memahami interaksi klien-server, dan menguji klien | [First Client](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Klien dengan LLM**  | Menyiapkan klien menggunakan protokol MCP dengan Large Language Model (LLM) | [Client with LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Menggunakan server dengan Visual Studio Code** | Menyiapkan Visual Studio Code untuk menggunakan server dengan protokol MCP | [Consuming a server with Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Membuat server menggunakan SSE** | SSE membantu kita mengekspos server ke internet. Bagian ini akan membantu Anda membuat server menggunakan SSE | [Creating a server using SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **HTTP Streaming** | Pelajari cara mengimplementasikan streaming HTTP untuk transfer data real-time antara klien dan server MCP | [HTTP Streaming](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **Menggunakan AI Toolkit** | AI toolkit adalah alat hebat yang akan membantu Anda mengelola alur kerja AI dan MCP Anda. | [Use AI Toolkit](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **Menguji server Anda** | Pengujian adalah bagian penting dari proses pengembangan. Bagian ini akan membantu Anda menguji dengan berbagai alat berbeda. | [Testing your server](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **Mendeploy server Anda** | Bagaimana cara beralih dari pengembangan lokal ke produksi? Bagian ini akan membantu Anda mengembangkan dan mendeploy server. | [Deploy your server](./03-GettingStarted/09-deployment/README.md) |
| 04 | **Implementasi Praktis** | Menggunakan SDK di berbagai bahasa, debugging, pengujian, dan validasi, membuat template prompt dan alur kerja yang dapat digunakan ulang | [Practical Implementation](./04-PracticalImplementation/README.md) |
| 05 | **Topik Lanjutan dalam MCP** | Alur kerja AI multimodal dan ekstensi, strategi skalabilitas yang aman, MCP dalam ekosistem perusahaan | [Advanced Topics](./05-AdvancedTopics/README.md) |
| 5.1 | **Integrasi MCP dengan Azure** | Menampilkan integrasi dengan Azure | [MCP Azure integration](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Multimodalitas** | Menunjukkan cara bekerja dengan berbagai modalitas seperti gambar dan lainnya | [Multi modality](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **Demo MCP OAuth2** | Aplikasi Spring Boot minimal yang menunjukkan OAuth2 dengan MCP, baik sebagai Authorization dan Resource Server. Menampilkan penerbitan token yang aman, endpoint terlindungi, deployment Azure Container Apps, dan integrasi API Management. | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Pelajari lebih lanjut tentang root context dan cara mengimplementasikannya | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Pelajari berbagai jenis routing | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Pelajari cara bekerja dengan sampling | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Scaling** | Pelajari tentang skalabilitas server MCP, termasuk strategi skalabilitas horizontal dan vertikal, optimasi sumber daya, dan tuning performa | [Scaling](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Keamanan** | Amankan Server MCP Anda, termasuk strategi autentikasi, otorisasi, dan perlindungan data | [Security](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Server dan klien MCP Python yang terintegrasi dengan SerpAPI untuk pencarian web, berita, produk, dan tanya jawab secara real-time. Menampilkan orkestrasi multi-alat, integrasi API eksternal, dan penanganan error yang kuat | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Streaming Real-time** | Streaming data real-time telah menjadi penting di dunia yang didorong data saat ini, di mana bisnis dan aplikasi membutuhkan akses langsung ke informasi untuk mengambil keputusan tepat waktu. | [Realtime Streaming](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Pencarian Web Real-time** | Pencarian web real-time bagaimana MCP mengubah pencarian web real-time dengan menyediakan pendekatan standar untuk manajemen konteks di antara model AI, mesin pencari, dan aplikasi. | [Realtime Web Search](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Kontribusi Komunitas** | Cara berkontribusi kode dan dokumentasi, kolaborasi melalui GitHub, peningkatan dan masukan yang digerakkan komunitas | [Community Contributions](./06-CommunityContributions/README.md) |
| 07 | **Wawasan dari Adopsi Awal** | Implementasi dunia nyata dan apa yang berhasil, membangun dan menerapkan solusi berbasis MCP, tren dan peta jalan masa depan | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Praktik Terbaik untuk MCP** | Penyempurnaan dan optimasi performa, merancang sistem MCP yang tahan kesalahan, strategi pengujian dan ketahanan | [Best Practices](./08-BestPractices/README.md) |
| 09 | **Studi Kasus MCP** | Penyelaman mendalam ke arsitektur solusi MCP, blueprint penerapan dan tips integrasi, diagram beranotasi dan panduan proyek | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **Menyederhanakan Alur Kerja AI: Membangun Server MCP dengan AI Toolkit** | Workshop praktis lengkap yang menggabungkan MCP dengan AI Toolkit Microsoft untuk VS Code. Pelajari cara membangun aplikasi cerdas yang menghubungkan model AI dengan alat dunia nyata melalui modul praktis yang mencakup dasar-dasar, pengembangan server khusus, dan strategi penerapan produksi. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Proyek Contoh

### 🧮 Proyek Contoh Kalkulator MCP:
<details>
  <summary><strong>Jelajahi Implementasi Kode berdasarkan Bahasa</strong></summary>

  - [Contoh Server MCP C#](./03-GettingStarted/samples/csharp/README.md)
  - [Kalkulator MCP Java](./03-GettingStarted/samples/java/calculator/README.md)
  - [Demo MCP JavaScript](./03-GettingStarted/samples/javascript/README.md)
  - [Server MCP Python](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [Contoh MCP TypeScript](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 Proyek Kalkulator MCP Lanjutan:
<details>
  <summary><strong>Jelajahi Contoh Lanjutan</strong></summary>

  - [Contoh C# Lanjutan](./04-PracticalImplementation/samples/csharp/README.md)
  - [Contoh Aplikasi Kontainer Java](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [Contoh JavaScript Lanjutan](./04-PracticalImplementation/samples/javascript/README.md)
  - [Implementasi Kompleks Python](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [Contoh Kontainer TypeScript](./04-PracticalImplementation/samples/typescript/README.md)

</details>

## 🎯 Prasyarat untuk Belajar MCP

Agar bisa mendapatkan manfaat maksimal dari kurikulum ini, kamu sebaiknya memiliki:

- Pengetahuan dasar tentang C#, Java, atau Python  
- Pemahaman tentang model client-server dan API  
- (Opsional) Familiar dengan konsep pembelajaran mesin  

## 📚 Panduan Belajar

Panduan belajar [Study Guide](./study_guide.md) yang lengkap tersedia untuk membantu kamu menavigasi repositori ini dengan efektif. Panduan ini mencakup:

- Peta kurikulum visual yang menunjukkan semua topik yang dibahas  
- Rincian setiap bagian repositori  
- Petunjuk penggunaan proyek contoh  
- Jalur belajar yang direkomendasikan untuk berbagai tingkat keahlian  
- Sumber tambahan untuk melengkapi perjalanan belajar kamu  

## 🛠️ Cara Menggunakan Kurikulum Ini dengan Efektif

Setiap pelajaran dalam panduan ini mencakup:

1. Penjelasan jelas tentang konsep MCP  
2. Contoh kode langsung dalam berbagai bahasa  
3. Latihan untuk membangun aplikasi MCP nyata  
4. Sumber tambahan untuk pembelajar tingkat lanjut  

## 📜 Informasi Lisensi

Konten ini dilisensikan di bawah **MIT License**. Untuk syarat dan ketentuan, lihat [LICENSE](../../LICENSE).

## 🤝 Panduan Kontribusi

Proyek ini menyambut kontribusi dan saran. Sebagian besar kontribusi mengharuskan kamu menyetujui  
Contributor License Agreement (CLA) yang menyatakan bahwa kamu memiliki hak dan memang memberikan  
izin kepada kami untuk menggunakan kontribusimu. Untuk detailnya, kunjungi <https://cla.opensource.microsoft.com>.

Saat kamu mengirimkan pull request, bot CLA akan secara otomatis menentukan apakah kamu perlu menyediakan  
CLA dan menandai PR dengan tepat (misalnya, pemeriksaan status, komentar). Cukup ikuti instruksi  
yang diberikan oleh bot. Kamu hanya perlu melakukan ini sekali untuk semua repositori yang menggunakan CLA kami.

Proyek ini telah mengadopsi [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).  
Untuk informasi lebih lanjut, lihat [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) atau  
hubungi [opencode@microsoft.com](mailto:opencode@microsoft.com) untuk pertanyaan atau komentar tambahan.

## 🎒 Kursus Lainnya  
Tim kami juga membuat kursus lain! Cek di:

- [AI Agents For Beginners](https://github.com/microsoft/ai-agents-for-beginners?WT.mc_id=academic-105485-koreyst)  
- [Generative AI for Beginners using .NET](https://github.com/microsoft/Generative-AI-for-beginners-dotnet?WT.mc_id=academic-105485-koreyst)  
- [Generative AI for Beginners using JavaScript](https://github.com/microsoft/generative-ai-with-javascript?WT.mc_id=academic-105485-koreyst)  
- [Generative AI for Beginners](https://github.com/microsoft/generative-ai-for-beginners?WT.mc_id=academic-105485-koreyst)  
- [ML for Beginners](https://aka.ms/ml-beginners?WT.mc_id=academic-105485-koreyst)  
- [Data Science for Beginners](https://aka.ms/datascience-beginners?WT.mc_id=academic-105485-koreyst)  
- [AI for Beginners](https://aka.ms/ai-beginners?WT.mc_id=academic-105485-koreyst)  
- [Cybersecurity for Beginners](https://github.com/microsoft/Security-101??WT.mc_id=academic-96948-sayoung)  
- [Web Dev for Beginners](https://aka.ms/webdev-beginners?WT.mc_id=academic-105485-koreyst)  
- [IoT for Beginners](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)  
- [XR Development for Beginners](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Menguasai GitHub Copilot untuk Pemrograman Berpasangan AI](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [Menguasai GitHub Copilot untuk Pengembang C#/.NET](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Pilih Petualangan Copilot Anda Sendiri](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Pemberitahuan Merek Dagang

Proyek ini mungkin berisi merek dagang atau logo untuk proyek, produk, atau layanan. Penggunaan merek dagang atau logo Microsoft yang sah harus mematuhi dan mengikuti
[Pedoman Merek Dagang & Merek Microsoft](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
Penggunaan merek dagang atau logo Microsoft dalam versi modifikasi dari proyek ini tidak boleh menimbulkan kebingungan atau mengindikasikan dukungan Microsoft.
Setiap penggunaan merek dagang atau logo pihak ketiga tunduk pada kebijakan pihak ketiga tersebut.

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.