<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:42:37+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "ms"
}
-->
# Penjana Pelan Kajian dengan Chainlit & Microsoft Learn Docs MCP

## Prasyarat

- Python 3.8 atau lebih tinggi  
- pip (pengurus pakej Python)  
- Akses internet untuk menyambung ke pelayan Microsoft Learn Docs MCP  

## Pemasangan

1. Klon repositori ini atau muat turun fail projek.  
2. Pasang kebergantungan yang diperlukan:  

   ```bash
   pip install -r requirements.txt
   ```  

## Penggunaan

### Senario 1: Pertanyaan Mudah ke Docs MCP  
Klien baris perintah yang menyambung ke pelayan Docs MCP, menghantar pertanyaan, dan memaparkan hasilnya.  

1. Jalankan skrip:  
   ```bash
   python scenario1.py
   ```  
2. Masukkan soalan dokumentasi anda pada prompt.  

### Senario 2: Penjana Pelan Kajian (Aplikasi Web Chainlit)  
Antara muka berasaskan web (menggunakan Chainlit) yang membolehkan pengguna menjana pelan kajian peribadi, minggu demi minggu, untuk mana-mana topik teknikal.  

1. Mulakan aplikasi Chainlit:  
   ```bash
   chainlit run scenario2.py
   ```  
2. Buka URL tempatan yang diberikan dalam terminal anda (contoh: http://localhost:8000) di pelayar anda.  
3. Dalam tetingkap sembang, masukkan topik kajian dan bilangan minggu yang anda ingin belajar (contoh: "pensijilan AI-900, 8 minggu").  
4. Aplikasi akan membalas dengan pelan kajian minggu demi minggu, termasuk pautan ke dokumentasi Microsoft Learn yang berkaitan.  

**Pembolehubah Persekitaran Diperlukan:**  

Untuk menggunakan Senario 2 (aplikasi web Chainlit dengan Azure OpenAI), anda mesti tetapkan pembolehubah persekitaran berikut dalam fail `.env` di direktori `python`:  

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```  

Isikan nilai ini dengan butiran sumber Azure OpenAI anda sebelum menjalankan aplikasi.  

> **Tip:** Anda boleh dengan mudah melancarkan model anda sendiri menggunakan [Azure AI Foundry](https://ai.azure.com/).  

### Senario 3: Dokumentasi Dalam Editor dengan Pelayan MCP dalam VS Code  

Daripada menukar tab pelayar untuk mencari dokumentasi, anda boleh membawa Microsoft Learn Docs terus ke dalam VS Code menggunakan pelayan MCP. Ini membolehkan anda:  
- Mencari dan membaca dokumen dalam VS Code tanpa meninggalkan persekitaran pengkodan anda.  
- Merujuk dokumentasi dan memasukkan pautan terus ke dalam fail README atau kursus anda.  
- Menggunakan GitHub Copilot dan MCP bersama-sama untuk aliran kerja dokumentasi berkuasa AI yang lancar.  

**Contoh Kes Penggunaan:**  
- Tambah pautan rujukan dengan cepat ke README semasa menulis dokumentasi kursus atau projek.  
- Gunakan Copilot untuk menjana kod dan MCP untuk mencari serta memetik dokumen yang berkaitan dengan segera.  
- Kekal fokus dalam editor anda dan tingkatkan produktiviti.  

> [!IMPORTANT]  
> Pastikan anda mempunyai konfigurasi [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) yang sah dalam ruang kerja anda (lokasi adalah `.vscode/mcp.json`).  

## Kenapa Chainlit untuk Senario 2?  

Chainlit adalah rangka kerja sumber terbuka moden untuk membina aplikasi web perbualan. Ia memudahkan penciptaan antara muka pengguna berasaskan sembang yang bersambung ke perkhidmatan backend seperti pelayan Microsoft Learn Docs MCP. Projek ini menggunakan Chainlit untuk menyediakan cara yang mudah dan interaktif bagi menjana pelan kajian peribadi secara masa nyata. Dengan memanfaatkan Chainlit, anda boleh membina dan melancarkan alat berasaskan sembang dengan cepat yang meningkatkan produktiviti dan pembelajaran.  

## Apa Yang Dilakukan  

Aplikasi ini membolehkan pengguna mencipta pelan kajian peribadi dengan hanya memasukkan topik dan tempoh. Aplikasi akan memproses input anda, membuat pertanyaan ke pelayan Microsoft Learn Docs MCP untuk kandungan yang berkaitan, dan menyusun hasilnya ke dalam pelan terstruktur minggu demi minggu. Cadangan setiap minggu dipaparkan dalam sembang, memudahkan anda mengikuti dan menjejak kemajuan. Integrasi ini memastikan anda sentiasa mendapat sumber pembelajaran terkini dan paling relevan.  

## Contoh Pertanyaan  

Cuba pertanyaan ini dalam tetingkap sembang untuk melihat bagaimana aplikasi bertindak balas:  

- `pensijilan AI-900, 8 minggu`  
- `Belajar Azure Functions, 4 minggu`  
- `Azure DevOps, 6 minggu`  
- `Kejuruteraan data di Azure, 10 minggu`  
- `Asas keselamatan Microsoft, 5 minggu`  
- `Power Platform, 7 minggu`  
- `Perkhidmatan Azure AI, 12 minggu`  
- `Seni bina awan, 9 minggu`  

Contoh ini menunjukkan fleksibiliti aplikasi untuk pelbagai matlamat pembelajaran dan jangka masa.  

## Rujukan  

- [Dokumentasi Chainlit](https://docs.chainlit.io/)  
- [Dokumentasi MCP](https://github.com/MicrosoftDocs/mcp)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.