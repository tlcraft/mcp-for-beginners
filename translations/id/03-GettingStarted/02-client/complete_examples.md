<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T09:12:39+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "id"
}
-->
# Contoh Lengkap Klien MCP

Direktori ini berisi contoh lengkap dan berfungsi dari klien MCP dalam berbagai bahasa pemrograman. Setiap klien menunjukkan fungsionalitas penuh yang dijelaskan dalam tutorial utama README.md.

## Klien yang Tersedia

### 1. Klien Java (`client_example_java.java`)
- **Transport**: SSE (Server-Sent Events) melalui HTTP
- **Server Target**: `http://localhost:8080`
- **Fitur**: 
  - Pembuatan koneksi dan ping
  - Daftar alat
  - Operasi kalkulator (tambah, kurang, kali, bagi, bantuan)
  - Penanganan kesalahan dan ekstraksi hasil

**Untuk menjalankan:**
```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. Klien C# (`client_example_csharp.cs`)
- **Transport**: Stdio (Standard Input/Output)
- **Server Target**: Server MCP .NET lokal melalui dotnet run
- **Fitur**:
  - Startup server otomatis melalui transport stdio
  - Daftar alat dan sumber daya
  - Operasi kalkulator
  - Parsing hasil JSON
  - Penanganan kesalahan yang komprehensif

**Untuk menjalankan:**
```bash
dotnet run
```

### 3. Klien TypeScript (`client_example_typescript.ts`)
- **Transport**: Stdio (Standard Input/Output)
- **Server Target**: Server MCP Node.js lokal
- **Fitur**:
  - Dukungan penuh protokol MCP
  - Operasi alat, sumber daya, dan prompt
  - Operasi kalkulator
  - Membaca sumber daya dan menjalankan prompt
  - Penanganan kesalahan yang tangguh

**Untuk menjalankan:**
```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Klien Python (`client_example_python.py`)
- **Transport**: Stdio (Standard Input/Output)  
- **Server Target**: Server MCP Python lokal
- **Fitur**:
  - Pola async/await untuk operasi
  - Penemuan alat dan sumber daya
  - Pengujian operasi kalkulator
  - Membaca konten sumber daya
  - Organisasi berbasis kelas

**Untuk menjalankan:**
```bash
python client_example_python.py
```

## Fitur Umum di Semua Klien

Setiap implementasi klien menunjukkan:

1. **Manajemen Koneksi**
   - Membuat koneksi ke server MCP
   - Menangani kesalahan koneksi
   - Pembersihan dan pengelolaan sumber daya yang tepat

2. **Penemuan Server**
   - Daftar alat yang tersedia
   - Daftar sumber daya yang tersedia (jika didukung)
   - Daftar prompt yang tersedia (jika didukung)

3. **Pemanggilan Alat**
   - Operasi kalkulator dasar (tambah, kurang, kali, bagi)
   - Perintah bantuan untuk informasi server
   - Pengiriman argumen dan penanganan hasil yang tepat

4. **Penanganan Kesalahan**
   - Kesalahan koneksi
   - Kesalahan eksekusi alat
   - Kegagalan yang tertata dan umpan balik ke pengguna

5. **Pemrosesan Hasil**
   - Mengekstrak konten teks dari respons
   - Memformat output agar mudah dibaca
   - Menangani berbagai format respons

## Prasyarat

Sebelum menjalankan klien ini, pastikan Anda:

1. **Server MCP yang sesuai sudah berjalan** (dari `../01-first-server/`)
2. **Dependensi yang dibutuhkan sudah terpasang** untuk bahasa yang Anda pilih
3. **Konektivitas jaringan yang tepat** (untuk transport berbasis HTTP)

## Perbedaan Utama Antar Implementasi

| Bahasa    | Transport | Startup Server | Model Async | Perpustakaan Utama |
|-----------|-----------|----------------|-------------|--------------------|
| Java      | SSE/HTTP  | Eksternal      | Sinkron     | WebFlux, MCP SDK   |
| C#        | Stdio     | Otomatis       | Async/Await | .NET MCP SDK       |
| TypeScript| Stdio     | Otomatis       | Async/Await | Node MCP SDK       |
| Python    | Stdio     | Otomatis       | AsyncIO     | Python MCP SDK     |

## Langkah Selanjutnya

Setelah mempelajari contoh klien ini:

1. **Modifikasi klien** untuk menambahkan fitur atau operasi baru
2. **Buat server Anda sendiri** dan uji dengan klien ini
3. **Eksperimen dengan transport yang berbeda** (SSE vs. Stdio)
4. **Bangun aplikasi yang lebih kompleks** yang mengintegrasikan fungsionalitas MCP

## Pemecahan Masalah

### Masalah Umum

1. **Koneksi ditolak**: Pastikan server MCP berjalan di port/path yang diharapkan
2. **Modul tidak ditemukan**: Pasang MCP SDK yang diperlukan untuk bahasa Anda
3. **Izin ditolak**: Periksa izin file untuk transport stdio
4. **Alat tidak ditemukan**: Pastikan server mengimplementasikan alat yang diharapkan

### Tips Debugging

1. **Aktifkan logging verbose** di MCP SDK Anda
2. **Periksa log server** untuk pesan kesalahan
3. **Verifikasi nama dan tanda tangan alat** cocok antara klien dan server
4. **Uji dengan MCP Inspector** terlebih dahulu untuk memvalidasi fungsi server

## Dokumentasi Terkait

- [Tutorial Klien Utama](./README.md)
- [Contoh Server MCP](../../../../03-GettingStarted/01-first-server)
- [MCP dengan Integrasi LLM](../../../../03-GettingStarted/03-llm-client)
- [Dokumentasi Resmi MCP](https://modelcontextprotocol.io/)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk mencapai akurasi, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.