<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b96f2864e0bcb6fae9b4926813c3feb1",
  "translation_date": "2025-06-26T14:12:24+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "id"
}
-->
# Topik Lanjutan dalam MCP

Bab ini bertujuan untuk membahas serangkaian topik lanjutan dalam implementasi Model Context Protocol (MCP), termasuk integrasi multi-modal, skalabilitas, praktik keamanan terbaik, dan integrasi enterprise. Topik-topik ini sangat penting untuk membangun aplikasi MCP yang tangguh dan siap produksi yang dapat memenuhi kebutuhan sistem AI modern.

## Ikhtisar

Pelajaran ini mengeksplorasi konsep lanjutan dalam implementasi Model Context Protocol, dengan fokus pada integrasi multi-modal, skalabilitas, praktik keamanan terbaik, dan integrasi enterprise. Topik-topik ini penting untuk membangun aplikasi MCP kelas produksi yang mampu menangani kebutuhan kompleks di lingkungan enterprise.

## Tujuan Pembelajaran

Setelah menyelesaikan pelajaran ini, Anda akan mampu:

- Mengimplementasikan kemampuan multi-modal dalam kerangka kerja MCP  
- Merancang arsitektur MCP yang skalabel untuk skenario dengan permintaan tinggi  
- Menerapkan praktik keamanan terbaik sesuai dengan prinsip keamanan MCP  
- Mengintegrasikan MCP dengan sistem dan kerangka kerja AI enterprise  
- Mengoptimalkan kinerja dan keandalan di lingkungan produksi  

## Pelajaran dan Proyek Contoh

| Link | Judul | Deskripsi |
|------|-------|-----------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrasi dengan Azure | Pelajari cara mengintegrasikan MCP Server Anda di Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | Contoh Multi modal MCP | Contoh untuk respons audio, gambar, dan multi modal |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | Demo MCP OAuth2 | Aplikasi Spring Boot minimal yang menunjukkan OAuth2 dengan MCP, baik sebagai Authorization maupun Resource Server. Menunjukkan penerbitan token yang aman, endpoint terlindungi, deployment Azure Container Apps, dan integrasi API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts | Pelajari lebih lanjut tentang root context dan cara mengimplementasikannya |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Pelajari berbagai jenis routing |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Pelajari cara bekerja dengan sampling |
| [5.7 Scaling](./mcp-scaling/README.md) | Skalabilitas | Pelajari tentang scaling |
| [5.8 Security](./mcp-security/README.md) | Keamanan | Amankan MCP Server Anda |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Server dan klien MCP Python yang terintegrasi dengan SerpAPI untuk pencarian web, berita, produk, dan Q&A secara real-time. Menunjukkan orkestrasi multi-tool, integrasi API eksternal, dan penanganan error yang kuat. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Streaming data real-time telah menjadi hal penting di dunia yang didorong oleh data saat ini, di mana bisnis dan aplikasi membutuhkan akses langsung ke informasi untuk pengambilan keputusan yang tepat waktu. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Pencarian Web | Pencarian web real-time bagaimana MCP mengubah pencarian web real-time dengan menyediakan pendekatan standar untuk manajemen konteks di antara model AI, mesin pencari, dan aplikasi. |
| [5.12 Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Autentikasi Entra ID | Microsoft Entra ID menyediakan solusi manajemen identitas dan akses berbasis cloud yang tangguh, membantu memastikan hanya pengguna dan aplikasi yang berwenang yang dapat berinteraksi dengan server MCP Anda. |

## Referensi Tambahan

Untuk informasi terbaru mengenai topik lanjutan MCP, lihat:
- [Dokumentasi MCP](https://modelcontextprotocol.io/)
- [Spesifikasi MCP](https://spec.modelcontextprotocol.io/)
- [Repositori GitHub](https://github.com/modelcontextprotocol)

## Poin Penting

- Implementasi MCP multi-modal memperluas kemampuan AI di luar pemrosesan teks  
- Skalabilitas sangat penting untuk deployment enterprise dan dapat diatasi melalui scaling horizontal dan vertikal  
- Langkah keamanan yang komprehensif melindungi data dan memastikan kontrol akses yang tepat  
- Integrasi enterprise dengan platform seperti Azure OpenAI dan Microsoft AI Foundry meningkatkan kapabilitas MCP  
- Implementasi MCP lanjutan mendapatkan manfaat dari arsitektur yang dioptimalkan dan pengelolaan sumber daya yang hati-hati  

## Latihan

Rancang implementasi MCP kelas enterprise untuk kasus penggunaan tertentu:

1. Identifikasi kebutuhan multi-modal untuk kasus penggunaan Anda  
2. Rancang kontrol keamanan yang diperlukan untuk melindungi data sensitif  
3. Rancang arsitektur skalabel yang dapat menangani beban yang bervariasi  
4. Rencanakan titik integrasi dengan sistem AI enterprise  
5. Dokumentasikan potensi bottleneck kinerja dan strategi mitigasinya  

## Sumber Daya Tambahan

- [Dokumentasi Azure OpenAI](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Dokumentasi Microsoft AI Foundry](https://learn.microsoft.com/en-us/ai-services/)

---

## Selanjutnya

- [5.1 MCP Integration](./mcp-integration/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sah. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.