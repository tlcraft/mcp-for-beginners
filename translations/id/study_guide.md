<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e2c6ed897fa98fa08e0146101776c7ff",
  "translation_date": "2025-07-18T10:10:15+00:00",
  "source_file": "study_guide.md",
  "language_code": "id"
}
-->
# Model Context Protocol (MCP) untuk Pemula - Panduan Belajar

Panduan belajar ini memberikan gambaran tentang struktur dan isi repositori untuk kurikulum "Model Context Protocol (MCP) untuk Pemula". Gunakan panduan ini untuk menavigasi repositori dengan efisien dan memanfaatkan sumber daya yang tersedia secara maksimal.

## Gambaran Repositori

Model Context Protocol (MCP) adalah kerangka kerja standar untuk interaksi antara model AI dan aplikasi klien. Awalnya dibuat oleh Anthropic, MCP kini dikelola oleh komunitas MCP yang lebih luas melalui organisasi resmi di GitHub. Repositori ini menyediakan kurikulum lengkap dengan contoh kode praktis dalam C#, Java, JavaScript, Python, dan TypeScript, yang dirancang untuk pengembang AI, arsitek sistem, dan insinyur perangkat lunak.

## Peta Kurikulum Visual

```mermaid
mindmap
  root((MCP for Beginners))
    00. Introduction
      ::icon(fa fa-book)
      (Protocol Overview)
      (Standardization Benefits)
      (Real-world Use Cases)
      (AI Integration Fundamentals)
    01. Core Concepts
      ::icon(fa fa-puzzle-piece)
      (Client-Server Architecture)
      (Protocol Components)
      (Messaging Patterns)
      (Transport Mechanisms)
    02. Security
      ::icon(fa fa-shield)
      (AI-Specific Threats)
      (Best Practices 2025)
      (Azure Content Safety)
      (Auth & Authorization)
      (Microsoft Prompt Shields)
    03. Getting Started
      ::icon(fa fa-rocket)
      (First Server Implementation)
      (Client Development)
      (LLM Client Integration)
      (VS Code Extensions)
      (SSE Server Setup)
      (HTTP Streaming)
      (AI Toolkit Integration)
      (Testing Frameworks)
      (Deployment Strategies)
    04. Practical Implementation
      ::icon(fa fa-code)
      (Multi-Language SDKs)
      (Testing & Debugging)
      (Prompt Templates)
      (Sample Projects)
      (Production Patterns)
    05. Advanced Topics
      ::icon(fa fa-graduation-cap)
      (Context Engineering)
      (Foundry Agent Integration)
      (Multi-modal AI Workflows)
      (OAuth2 Authentication)
      (Real-time Search)
      (Streaming Protocols)
      (Root Contexts)
      (Routing Strategies)
      (Sampling Techniques)
      (Scaling Solutions)
      (Security Hardening)
      (Entra ID Integration)
      (Web Search MCP)
      
    06. Community
      ::icon(fa fa-users)
      (Code Contributions)
      (Documentation)
      (MCP Client Ecosystem)
      (MCP Server Registry)
      (Image Generation Tools)
      (GitHub Collaboration)
    07. Early Adoption
      ::icon(fa fa-lightbulb)
      (Production Deployments)
      (Microsoft MCP Servers)
      (Azure MCP Service)
      (Enterprise Case Studies)
      (Future Roadmap)
    08. Best Practices
      ::icon(fa fa-check)
      (Performance Optimization)
      (Fault Tolerance)
      (System Resilience)
      (Monitoring & Observability)
    09. Case Studies
      ::icon(fa fa-file-text)
      (Azure API Management)
      (AI Travel Agent)
      (Azure DevOps Integration)
      (Documentation MCP)
      (Real-world Implementations)
    10. Hands-on Workshop
      ::icon(fa fa-laptop)
      (MCP Server Fundamentals)
      (Advanced Development)
      (AI Toolkit Integration)
      (Production Deployment)
      (4-Lab Structure)
```

## Struktur Repositori

Repositori ini diorganisir menjadi sepuluh bagian utama, masing-masing fokus pada aspek berbeda dari MCP:

1. **Introduction (00-Introduction/)**
   - Gambaran umum Model Context Protocol
   - Mengapa standarisasi penting dalam pipeline AI
   - Kasus penggunaan praktis dan manfaatnya

2. **Core Concepts (01-CoreConcepts/)**
   - Arsitektur client-server
   - Komponen utama protokol
   - Pola pengiriman pesan dalam MCP

3. **Security (02-Security/)**
   - Ancaman keamanan dalam sistem berbasis MCP
   - Praktik terbaik untuk mengamankan implementasi
   - Strategi autentikasi dan otorisasi
   - **Dokumentasi Keamanan Lengkap**:
     - MCP Security Best Practices 2025
     - Panduan Implementasi Azure Content Safety
     - Kontrol dan Teknik Keamanan MCP
     - Referensi Cepat Praktik Terbaik MCP
   - **Topik Keamanan Utama**:
     - Serangan prompt injection dan tool poisoning
     - Pembajakan sesi dan masalah confused deputy
     - Kerentanan token passthrough
     - Izin berlebihan dan kontrol akses
     - Keamanan rantai pasokan untuk komponen AI
     - Integrasi Microsoft Prompt Shields

4. **Getting Started (03-GettingStarted/)**
   - Pengaturan dan konfigurasi lingkungan
   - Membuat server dan klien MCP dasar
   - Integrasi dengan aplikasi yang sudah ada
   - Termasuk bagian untuk:
     - Implementasi server pertama
     - Pengembangan klien
     - Integrasi klien LLM
     - Integrasi VS Code
     - Server-Sent Events (SSE) server
     - HTTP streaming
     - Integrasi AI Toolkit
     - Strategi pengujian
     - Panduan deployment

5. **Practical Implementation (04-PracticalImplementation/)**
   - Menggunakan SDK di berbagai bahasa pemrograman
   - Teknik debugging, pengujian, dan validasi
   - Membuat template prompt dan workflow yang dapat digunakan ulang
   - Proyek contoh dengan contoh implementasi

6. **Advanced Topics (05-AdvancedTopics/)**
   - Teknik rekayasa konteks
   - Integrasi agen Foundry
   - Workflow AI multi-modal
   - Demo autentikasi OAuth2
   - Kemampuan pencarian real-time
   - Streaming real-time
   - Implementasi root contexts
   - Strategi routing
   - Teknik sampling
   - Pendekatan scaling
   - Pertimbangan keamanan
   - Integrasi keamanan Entra ID
   - Integrasi pencarian web

7. **Community Contributions (06-CommunityContributions/)**
   - Cara berkontribusi kode dan dokumentasi
   - Kolaborasi melalui GitHub
   - Peningkatan dan umpan balik yang digerakkan komunitas
   - Menggunakan berbagai klien MCP (Claude Desktop, Cline, VSCode)
   - Bekerja dengan server MCP populer termasuk generasi gambar

8. **Lessons from Early Adoption (07-LessonsfromEarlyAdoption/)**
   - Implementasi nyata dan kisah sukses
   - Membangun dan menerapkan solusi berbasis MCP
   - Tren dan roadmap masa depan
   - **Panduan Microsoft MCP Servers**: Panduan lengkap untuk 10 server MCP Microsoft siap produksi termasuk:
     - Microsoft Learn Docs MCP Server
     - Azure MCP Server (15+ konektor khusus)
     - GitHub MCP Server
     - Azure DevOps MCP Server
     - MarkItDown MCP Server
     - SQL Server MCP Server
     - Playwright MCP Server
     - Dev Box MCP Server
     - Azure AI Foundry MCP Server
     - Microsoft 365 Agents Toolkit MCP Server

9. **Best Practices (08-BestPractices/)**
   - Penyempurnaan dan optimasi performa
   - Merancang sistem MCP yang tahan kesalahan
   - Strategi pengujian dan ketahanan

10. **Case Studies (09-CaseStudy/)**
    - Contoh integrasi Azure API Management
    - Contoh implementasi agen perjalanan
    - Integrasi Azure DevOps dengan pembaruan YouTube
    - Contoh implementasi MCP untuk dokumentasi
    - Contoh implementasi dengan dokumentasi rinci

11. **Hands-on Workshop (10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/)**
    - Workshop praktis lengkap yang menggabungkan MCP dengan AI Toolkit
    - Membangun aplikasi cerdas yang menghubungkan model AI dengan alat dunia nyata
    - Modul praktis yang mencakup dasar-dasar, pengembangan server kustom, dan strategi deployment produksi
    - **Struktur Lab**:
      - Lab 1: Dasar-dasar Server MCP
      - Lab 2: Pengembangan Server MCP Lanjutan
      - Lab 3: Integrasi AI Toolkit
      - Lab 4: Deployment Produksi dan Scaling
    - Pendekatan pembelajaran berbasis lab dengan instruksi langkah demi langkah

## Sumber Daya Tambahan

Repositori ini juga menyertakan sumber daya pendukung:

- **Folder Images**: Berisi diagram dan ilustrasi yang digunakan sepanjang kurikulum
- **Terjemahan**: Dukungan multi-bahasa dengan terjemahan otomatis dokumentasi
- **Sumber Resmi MCP**:
  - [MCP Documentation](https://modelcontextprotocol.io/)
  - [MCP Specification](https://spec.modelcontextprotocol.io/)
  - [MCP GitHub Repository](https://github.com/modelcontextprotocol)

## Cara Menggunakan Repositori Ini

1. **Pembelajaran Berurutan**: Ikuti bab secara berurutan (00 sampai 10) untuk pengalaman belajar yang terstruktur.
2. **Fokus Bahasa Tertentu**: Jika tertarik pada bahasa pemrograman tertentu, jelajahi direktori contoh untuk implementasi dalam bahasa pilihan Anda.
3. **Implementasi Praktis**: Mulailah dengan bagian "Getting Started" untuk menyiapkan lingkungan dan membuat server serta klien MCP pertama Anda.
4. **Eksplorasi Lanjutan**: Setelah memahami dasar, dalami topik lanjutan untuk memperluas pengetahuan.
5. **Keterlibatan Komunitas**: Bergabunglah dengan komunitas MCP melalui diskusi GitHub dan saluran Discord untuk terhubung dengan para ahli dan pengembang lain.

## Klien dan Alat MCP

Kurikulum ini mencakup berbagai klien dan alat MCP:

1. **Klien Resmi**:
   - Visual Studio Code
   - MCP di Visual Studio Code
   - Claude Desktop
   - Claude di VSCode
   - Claude API

2. **Klien Komunitas**:
   - Cline (berbasis terminal)
   - Cursor (editor kode)
   - ChatMCP
   - Windsurf

3. **Alat Manajemen MCP**:
   - MCP CLI
   - MCP Manager
   - MCP Linker
   - MCP Router

## Server MCP Populer

Repositori ini memperkenalkan berbagai server MCP, termasuk:

1. **Server MCP Resmi Microsoft**:
   - Microsoft Learn Docs MCP Server
   - Azure MCP Server (15+ konektor khusus)
   - GitHub MCP Server
   - Azure DevOps MCP Server
   - MarkItDown MCP Server
   - SQL Server MCP Server
   - Playwright MCP Server
   - Dev Box MCP Server
   - Azure AI Foundry MCP Server
   - Microsoft 365 Agents Toolkit MCP Server

2. **Server Referensi Resmi**:
   - Filesystem
   - Fetch
   - Memory
   - Sequential Thinking

3. **Generasi Gambar**:
   - Azure OpenAI DALL-E 3
   - Stable Diffusion WebUI
   - Replicate

4. **Alat Pengembangan**:
   - Git MCP
   - Terminal Control
   - Code Assistant

5. **Server Khusus**:
   - Salesforce
   - Microsoft Teams
   - Jira & Confluence

## Kontribusi

Repositori ini menyambut kontribusi dari komunitas. Lihat bagian Community Contributions untuk panduan cara berkontribusi secara efektif ke ekosistem MCP.

## Changelog

| Tanggal | Perubahan |
|---------|-----------|
| 18 Juli 2025 | - Memperbarui struktur repositori untuk memasukkan Panduan Microsoft MCP Servers<br>- Menambahkan daftar lengkap 10 server MCP Microsoft siap produksi<br>- Memperkuat bagian Server MCP Populer dengan Server MCP Resmi Microsoft<br>- Memperbarui bagian Case Studies dengan contoh file nyata<br>- Menambahkan detail Struktur Lab untuk Workshop Praktis |
| 16 Juli 2025 | - Memperbarui struktur repositori sesuai isi terkini<br>- Menambahkan bagian Klien dan Alat MCP<br>- Menambahkan bagian Server MCP Populer<br>- Memperbarui Peta Kurikulum Visual dengan semua topik terkini<br>- Memperkuat bagian Topik Lanjutan dengan semua area khusus<br>- Memperbarui Case Studies dengan contoh nyata<br>- Menjelaskan asal-usul MCP yang dibuat oleh Anthropic |
| 11 Juni 2025 | - Pembuatan awal panduan belajar<br>- Menambahkan Peta Kurikulum Visual<br>- Menguraikan struktur repositori<br>- Menyertakan proyek contoh dan sumber daya tambahan |

---

*Panduan belajar ini diperbarui pada 18 Juli 2025, dan memberikan gambaran repositori hingga tanggal tersebut. Isi repositori dapat diperbarui setelah tanggal ini.*

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk mencapai akurasi, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.