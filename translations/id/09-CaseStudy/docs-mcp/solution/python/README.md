<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:42:26+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "id"
}
-->
# Study Plan Generator dengan Chainlit & Microsoft Learn Docs MCP

## Prasyarat

- Python 3.8 atau lebih baru  
- pip (manajer paket Python)  
- Akses internet untuk terhubung ke server Microsoft Learn Docs MCP  

## Instalasi

1. Clone repositori ini atau unduh file proyek.  
2. Instal dependensi yang dibutuhkan:  

   ```bash
   pip install -r requirements.txt
   ```

## Penggunaan

### Skenario 1: Query Sederhana ke Docs MCP  
Client command-line yang terhubung ke server Docs MCP, mengirim query, dan menampilkan hasilnya.

1. Jalankan skrip:  
   ```bash
   python scenario1.py
   ```  
2. Masukkan pertanyaan dokumentasi Anda pada prompt.

### Skenario 2: Study Plan Generator (Aplikasi Web Chainlit)  
Antarmuka berbasis web (menggunakan Chainlit) yang memungkinkan pengguna membuat rencana belajar personal, mingguan, untuk topik teknis apa pun.

1. Mulai aplikasi Chainlit:  
   ```bash
   chainlit run scenario2.py
   ```  
2. Buka URL lokal yang muncul di terminal Anda (misalnya http://localhost:8000) di browser.  
3. Di jendela chat, masukkan topik belajar dan jumlah minggu yang ingin Anda pelajari (misalnya, "sertifikasi AI-900, 8 minggu").  
4. Aplikasi akan merespons dengan rencana belajar mingguan, termasuk tautan ke dokumentasi Microsoft Learn yang relevan.

**Variabel Lingkungan yang Diperlukan:**  

Untuk menggunakan Skenario 2 (aplikasi web Chainlit dengan Azure OpenAI), Anda harus mengatur variabel lingkungan berikut di file `.env` dalam direktori `python`:  

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```

Isi nilai-nilai ini dengan detail resource Azure OpenAI Anda sebelum menjalankan aplikasi.

> **Tip:** Anda bisa dengan mudah menerapkan model Anda sendiri menggunakan [Azure AI Foundry](https://ai.azure.com/).

### Skenario 3: Docs di Editor dengan MCP Server di VS Code  

Alih-alih berpindah tab browser untuk mencari dokumentasi, Anda bisa membawa Microsoft Learn Docs langsung ke VS Code menggunakan server MCP. Ini memungkinkan Anda untuk:  
- Mencari dan membaca dokumentasi di dalam VS Code tanpa meninggalkan lingkungan coding.  
- Mengacu pada dokumentasi dan menyisipkan tautan langsung ke README atau file kursus Anda.  
- Menggunakan GitHub Copilot dan MCP secara bersamaan untuk alur kerja dokumentasi bertenaga AI yang mulus.

**Contoh Kasus Penggunaan:**  
- Menambahkan tautan referensi dengan cepat ke README saat menulis dokumentasi kursus atau proyek.  
- Menggunakan Copilot untuk menghasilkan kode dan MCP untuk langsung menemukan serta mengutip dokumentasi yang relevan.  
- Tetap fokus di editor dan tingkatkan produktivitas.

> [!IMPORTANT]  
> Pastikan Anda memiliki konfigurasi [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) yang valid di workspace Anda (lokasi di `.vscode/mcp.json`).

## Mengapa Chainlit untuk Skenario 2?

Chainlit adalah framework open-source modern untuk membangun aplikasi web percakapan. Framework ini memudahkan pembuatan antarmuka chat yang terhubung ke layanan backend seperti Microsoft Learn Docs MCP server. Proyek ini menggunakan Chainlit untuk menyediakan cara sederhana dan interaktif dalam membuat rencana belajar personal secara real-time. Dengan memanfaatkan Chainlit, Anda dapat dengan cepat membangun dan menerapkan alat berbasis chat yang meningkatkan produktivitas dan pembelajaran.

## Fungsi Aplikasi Ini

Aplikasi ini memungkinkan pengguna membuat rencana belajar personal hanya dengan memasukkan topik dan durasi. Aplikasi akan memproses input Anda, mengirim query ke Microsoft Learn Docs MCP server untuk konten yang relevan, dan mengatur hasilnya menjadi rencana mingguan yang terstruktur. Rekomendasi setiap minggu ditampilkan di chat, sehingga mudah diikuti dan dipantau kemajuannya. Integrasi ini memastikan Anda selalu mendapatkan sumber belajar terbaru dan paling relevan.

## Contoh Query

Coba beberapa query berikut di jendela chat untuk melihat bagaimana aplikasi merespons:

- `sertifikasi AI-900, 8 minggu`  
- `Belajar Azure Functions, 4 minggu`  
- `Azure DevOps, 6 minggu`  
- `Data engineering di Azure, 10 minggu`  
- `Dasar keamanan Microsoft, 5 minggu`  
- `Power Platform, 7 minggu`  
- `Layanan Azure AI, 12 minggu`  
- `Arsitektur cloud, 9 minggu`

Contoh-contoh ini menunjukkan fleksibilitas aplikasi untuk berbagai tujuan belajar dan jangka waktu.

## Referensi

- [Chainlit Documentation](https://docs.chainlit.io/)  
- [MCP Documentation](https://github.com/MicrosoftDocs/mcp)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk akurasi, harap diingat bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.