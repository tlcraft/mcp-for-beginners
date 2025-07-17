<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5f321ea583cf087a94e47ee74c62b504",
  "translation_date": "2025-07-17T07:59:35+00:00",
  "source_file": "study_guide.md",
  "language_code": "ms"
}
-->
# Model Context Protocol (MCP) untuk Pemula - Panduan Pembelajaran

Panduan pembelajaran ini memberikan gambaran keseluruhan tentang struktur dan kandungan repositori untuk kurikulum "Model Context Protocol (MCP) untuk Pemula". Gunakan panduan ini untuk menavigasi repositori dengan cekap dan memanfaatkan sumber yang tersedia dengan sebaiknya.

## Gambaran Keseluruhan Repositori

Model Context Protocol (MCP) adalah rangka kerja standard untuk interaksi antara model AI dan aplikasi klien. Pada mulanya dicipta oleh Anthropic, MCP kini diselenggara oleh komuniti MCP yang lebih luas melalui organisasi rasmi GitHub. Repositori ini menyediakan kurikulum menyeluruh dengan contoh kod praktikal dalam C#, Java, JavaScript, Python, dan TypeScript, direka untuk pembangun AI, arkitek sistem, dan jurutera perisian.

## Peta Kurikulum Visual

```mermaid
mindmap
  root((MCP for Beginners))
    00. Introduction
      ::icon(fa fa-book)
      (Protocol Overview)
      (Standardization)
      (Use Cases)
    01. Core Concepts
      ::icon(fa fa-puzzle-piece)
      (Client-Server Architecture)
      (Protocol Components)
      (Messaging Patterns)
    02. Security
      ::icon(fa fa-shield)
      (Threat Models)
      (Best Practices)
      (Auth Strategies)
    03. Getting Started
      ::icon(fa fa-rocket)
      (First Server)
      (Client)
      (LLM Client)
      (VS Code Integration)
      (SSE Server)
      (HTTP Streaming)
      (AI Toolkit)
      (Testing)
      (Deployment)
    04. Practical Implementation
      ::icon(fa fa-code)
      (SDKs)
      (Testing/Debugging)
      (Prompt Templates)
      (Sample Projects)
    05. Advanced Topics
      ::icon(fa fa-graduation-cap)
      (Context Engineering)
      (Foundry Integration)
      (Multi-modal AI)
      (OAuth2 Demo)
      (Real-time Search)
      (Streaming)
      (Root Contexts)
      (Routing)
      (Sampling)
      (Scaling)
      (Security)
      (Entra ID)
      (Web Search)
      
    06. Community
      ::icon(fa fa-users)
      (Code Contributions)
      (Documentation)
      (MCP Clients)
      (MCP Servers)
      (Image Generation)
    07. Early Adoption
      ::icon(fa fa-lightbulb)
      (Real-world Examples)
      (Deployment Stories)
      (Future Roadmap)
    08. Best Practices
      ::icon(fa fa-check)
      (Performance)
      (Fault Tolerance)
      (Resilience)
    09. Case Studies
      ::icon(fa fa-file-text)
      (API Management)
      (Travel Agent)
      (Azure DevOps)
      (Documentation MCP)
    10. Hands-on Workshop
      ::icon(fa fa-laptop)
      (AI Toolkit Integration)
      (Custom Server Development)
      (Production Deployment)
```

## Struktur Repositori

Repositori ini disusun kepada sepuluh bahagian utama, setiap satu memberi tumpuan kepada aspek berbeza MCP:

1. **Pengenalan (00-Introduction/)**
   - Gambaran keseluruhan Model Context Protocol
   - Mengapa standardisasi penting dalam saluran AI
   - Kes penggunaan praktikal dan manfaat

2. **Konsep Teras (01-CoreConcepts/)**
   - Seni bina klien-pelayan
   - Komponen utama protokol
   - Corak penghantaran mesej dalam MCP

3. **Keselamatan (02-Security/)**
   - Ancaman keselamatan dalam sistem berasaskan MCP
   - Amalan terbaik untuk memastikan keselamatan pelaksanaan
   - Strategi pengesahan dan kebenaran

4. **Memulakan (03-GettingStarted/)**
   - Persediaan dan konfigurasi persekitaran
   - Membina pelayan dan klien MCP asas
   - Integrasi dengan aplikasi sedia ada
   - Termasuk bahagian untuk:
     - Pelaksanaan pelayan pertama
     - Pembangunan klien
     - Integrasi klien LLM
     - Integrasi VS Code
     - Pelayan Server-Sent Events (SSE)
     - Penstriman HTTP
     - Integrasi AI Toolkit
     - Strategi pengujian
     - Garis panduan penyebaran

5. **Pelaksanaan Praktikal (04-PracticalImplementation/)**
   - Menggunakan SDK dalam pelbagai bahasa pengaturcaraan
   - Teknik debug, ujian, dan pengesahan
   - Membina templat prompt dan aliran kerja yang boleh digunakan semula
   - Projek contoh dengan contoh pelaksanaan

6. **Topik Lanjutan (05-AdvancedTopics/)**
   - Teknik kejuruteraan konteks
   - Integrasi agen Foundry
   - Aliran kerja AI pelbagai modaliti
   - Demo pengesahan OAuth2
   - Keupayaan carian masa nyata
   - Penstriman masa nyata
   - Pelaksanaan konteks akar
   - Strategi penghalaan
   - Teknik pensampelan
   - Pendekatan penskalaan
   - Pertimbangan keselamatan
   - Integrasi keselamatan Entra ID
   - Integrasi carian web

7. **Sumbangan Komuniti (06-CommunityContributions/)**
   - Cara menyumbang kod dan dokumentasi
   - Bekerjasama melalui GitHub
   - Penambahbaikan dan maklum balas yang dipacu komuniti
   - Menggunakan pelbagai klien MCP (Claude Desktop, Cline, VSCode)
   - Bekerja dengan pelayan MCP popular termasuk penjanaan imej

8. **Pengajaran dari Penggunaan Awal (07-LessonsfromEarlyAdoption/)**
   - Pelaksanaan dunia sebenar dan kisah kejayaan
   - Membina dan menyebarkan penyelesaian berasaskan MCP
   - Trend dan peta jalan masa depan

9. **Amalan Terbaik (08-BestPractices/)**
   - Penalaan prestasi dan pengoptimuman
   - Reka bentuk sistem MCP tahan ralat
   - Strategi ujian dan ketahanan

10. **Kajian Kes (09-CaseStudy/)**
    - Kajian kes: Integrasi Azure API Management
    - Kajian kes: Pelaksanaan ejen pelancongan
    - Kajian kes: Integrasi Azure DevOps dengan YouTube
    - Contoh pelaksanaan dengan dokumentasi terperinci

11. **Bengkel Praktikal (10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/)**
    - Bengkel praktikal menyeluruh menggabungkan MCP dengan AI Toolkit
    - Membina aplikasi pintar yang menghubungkan model AI dengan alat dunia sebenar
    - Modul praktikal merangkumi asas, pembangunan pelayan tersuai, dan strategi penyebaran produksi
    - Pendekatan pembelajaran berasaskan makmal dengan arahan langkah demi langkah

## Sumber Tambahan

Repositori ini termasuk sumber sokongan:

- **Folder Imej**: Mengandungi rajah dan ilustrasi yang digunakan sepanjang kurikulum
- **Terjemahan**: Sokongan pelbagai bahasa dengan terjemahan automatik dokumentasi
- **Sumber Rasmi MCP**:
  - [MCP Documentation](https://modelcontextprotocol.io/)
  - [MCP Specification](https://spec.modelcontextprotocol.io/)
  - [MCP GitHub Repository](https://github.com/modelcontextprotocol)

## Cara Menggunakan Repositori Ini

1. **Pembelajaran Berurutan**: Ikuti bab mengikut urutan (00 hingga 10) untuk pengalaman pembelajaran yang tersusun.
2. **Fokus Bahasa Tertentu**: Jika berminat dengan bahasa pengaturcaraan tertentu, terokai direktori contoh untuk pelaksanaan dalam bahasa pilihan anda.
3. **Pelaksanaan Praktikal**: Mulakan dengan bahagian "Memulakan" untuk menyediakan persekitaran dan membina pelayan serta klien MCP pertama anda.
4. **Eksplorasi Lanjutan**: Setelah mahir dengan asas, terokai topik lanjutan untuk memperluas pengetahuan anda.
5. **Penglibatan Komuniti**: Sertai komuniti MCP melalui perbincangan GitHub dan saluran Discord untuk berhubung dengan pakar dan pembangun lain.

## Klien dan Alat MCP

Kurikulum ini merangkumi pelbagai klien dan alat MCP:

1. **Klien Rasmi**:
   - Visual Studio Code
   - MCP dalam Visual Studio Code
   - Claude Desktop
   - Claude dalam VSCode
   - Claude API

2. **Klien Komuniti**:
   - Cline (berasaskan terminal)
   - Cursor (penyunting kod)
   - ChatMCP
   - Windsurf

3. **Alat Pengurusan MCP**:
   - MCP CLI
   - MCP Manager
   - MCP Linker
   - MCP Router

## Pelayan MCP Popular

Repositori ini memperkenalkan pelbagai pelayan MCP, termasuk:

1. **Pelayan Rujukan Rasmi**:
   - Filesystem
   - Fetch
   - Memory
   - Sequential Thinking

2. **Penjanaan Imej**:
   - Azure OpenAI DALL-E 3
   - Stable Diffusion WebUI
   - Replicate

3. **Alat Pembangunan**:
   - Git MCP
   - Terminal Control
   - Code Assistant

4. **Pelayan Khusus**:
   - Salesforce
   - Microsoft Teams
   - Jira & Confluence

## Menyumbang

Repositori ini mengalu-alukan sumbangan daripada komuniti. Lihat bahagian Sumbangan Komuniti untuk panduan bagaimana menyumbang dengan berkesan kepada ekosistem MCP.

## Log Perubahan

| Tarikh | Perubahan |
|--------|-----------|
| 16 Julai, 2025 | - Struktur repositori dikemas kini untuk mencerminkan kandungan semasa<br>- Ditambah bahagian Klien dan Alat MCP<br>- Ditambah bahagian Pelayan MCP Popular<br>- Peta Kurikulum Visual dikemas kini dengan semua topik terkini<br>- Bahagian Topik Lanjutan diperkaya dengan semua bidang khusus<br>- Kajian Kes dikemas kini untuk mencerminkan contoh sebenar<br>- Penjelasan asal MCP sebagai ciptaan Anthropic |
| 11 Jun, 2025 | - Penciptaan awal panduan pembelajaran<br>- Ditambah Peta Kurikulum Visual<br>- Garis besar struktur repositori<br>- Termasuk projek contoh dan sumber tambahan |

---

*Panduan pembelajaran ini dikemas kini pada 16 Julai, 2025, dan memberikan gambaran keseluruhan repositori sehingga tarikh tersebut. Kandungan repositori mungkin dikemas kini selepas tarikh ini.*

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.