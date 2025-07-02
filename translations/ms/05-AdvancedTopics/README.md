<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "748c61250d4a326206b72b28f6154615",
  "translation_date": "2025-07-02T09:44:37+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "ms"
}
-->
# Topik Lanjutan dalam MCP

Bab ini bertujuan untuk membincangkan beberapa topik lanjutan dalam pelaksanaan Model Context Protocol (MCP), termasuk integrasi multi-modal, kebolehsuaian, amalan terbaik keselamatan, dan integrasi perusahaan. Topik-topik ini penting untuk membina aplikasi MCP yang kukuh dan bersedia untuk pengeluaran yang mampu memenuhi keperluan sistem AI moden.

## Gambaran Keseluruhan

Pelajaran ini meneroka konsep lanjutan dalam pelaksanaan Model Context Protocol, dengan fokus pada integrasi multi-modal, kebolehsuaian, amalan terbaik keselamatan, dan integrasi perusahaan. Topik-topik ini penting untuk membina aplikasi MCP tahap pengeluaran yang boleh mengendalikan keperluan kompleks dalam persekitaran perusahaan.

## Objektif Pembelajaran

Menjelang akhir pelajaran ini, anda akan dapat:

- Melaksanakan keupayaan multi-modal dalam rangka kerja MCP
- Mereka bentuk seni bina MCP yang boleh diskalakan untuk senario permintaan tinggi
- Mengaplikasikan amalan terbaik keselamatan yang selaras dengan prinsip keselamatan MCP
- Mengintegrasikan MCP dengan sistem dan rangka kerja AI perusahaan
- Mengoptimumkan prestasi dan kebolehpercayaan dalam persekitaran pengeluaran

## Pelajaran dan Projek Contoh

| Pautan | Tajuk | Penerangan |
|--------|-------|------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrasi dengan Azure | Pelajari cara mengintegrasikan MCP Server anda di Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | Contoh Multi Modal MCP | Contoh untuk audio, imej dan respons multi-modal |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | Demo MCP OAuth2 | Aplikasi Spring Boot minimal yang menunjukkan OAuth2 dengan MCP, sebagai Authorization dan Resource Server. Memperlihatkan penerbitan token selamat, titik akhir terlindung, penyebaran Azure Container Apps, dan integrasi Pengurusan API. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Konteks Root | Pelajari lebih lanjut mengenai konteks root dan cara melaksanakannya |
| [5.5 Routing](./mcp-routing/README.md) | Penghalaan | Pelajari pelbagai jenis penghalaan |
| [5.6 Sampling](./mcp-sampling/README.md) | Persampelan | Pelajari cara bekerja dengan persampelan |
| [5.7 Scaling](./mcp-scaling/README.md) | Penyesuaian Skala | Pelajari mengenai penyesuaian skala |
| [5.8 Security](./mcp-security/README.md) | Keselamatan | Lindungi MCP Server anda |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Carian Web MCP | Server dan klien MCP Python yang mengintegrasi dengan SerpAPI untuk carian web masa nyata, berita, produk, dan soal jawab. Memperlihatkan orkestrasi multi-alat, integrasi API luaran, dan pengendalian ralat yang kukuh. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Penstriman | Penstriman data masa nyata menjadi penting dalam dunia berasaskan data hari ini, di mana perniagaan dan aplikasi memerlukan akses segera kepada maklumat untuk membuat keputusan tepat pada masanya. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Carian Web | Carian web masa nyata bagaimana MCP mengubah carian web masa nyata dengan menyediakan pendekatan standard untuk pengurusan konteks merentasi model AI, enjin carian, dan aplikasi. |
| [5.12 Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Pengesahan Entra ID | Microsoft Entra ID menyediakan penyelesaian pengurusan identiti dan akses berasaskan awan yang kukuh, membantu memastikan hanya pengguna dan aplikasi yang diberi kuasa dapat berinteraksi dengan MCP server anda. |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Integrasi Azure AI Foundry | Pelajari cara mengintegrasikan server Model Context Protocol dengan agen Azure AI Foundry, membolehkan orkestrasi alat yang berkuasa dan keupayaan AI perusahaan dengan sambungan sumber data luaran yang standard. |

## Rujukan Tambahan

Untuk maklumat terkini mengenai topik MCP lanjutan, rujuk:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Perkara Penting

- Pelaksanaan MCP multi-modal meluaskan keupayaan AI melebihi pemprosesan teks
- Kebolehsuaian penting untuk penyebaran perusahaan dan boleh diatasi melalui penyesuaian skala mendatar dan menegak
- Langkah keselamatan menyeluruh melindungi data dan memastikan kawalan akses yang betul
- Integrasi perusahaan dengan platform seperti Azure OpenAI dan Microsoft AI Foundry meningkatkan keupayaan MCP
- Pelaksanaan MCP lanjutan mendapat manfaat daripada seni bina yang dioptimumkan dan pengurusan sumber yang teliti

## Latihan

Reka pelaksanaan MCP tahap perusahaan untuk kes penggunaan tertentu:

1. Kenal pasti keperluan multi-modal untuk kes penggunaan anda
2. Gariskan kawalan keselamatan yang diperlukan untuk melindungi data sensitif
3. Reka seni bina yang boleh diskalakan untuk mengendalikan beban yang berubah-ubah
4. Rancang titik integrasi dengan sistem AI perusahaan
5. Dokumentasikan potensi kesesakan prestasi dan strategi mitigasi

## Sumber Tambahan

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Apa seterusnya

- [5.1 MCP Integration](./mcp-integration/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.