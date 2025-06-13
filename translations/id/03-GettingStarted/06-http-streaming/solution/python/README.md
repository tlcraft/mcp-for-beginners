<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-13T02:03:12+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "id"
}
-->
# Menjalankan contoh ini

Berikut cara menjalankan server dan klien streaming HTTP klasik, serta server dan klien streaming MCP menggunakan Python.

### Ikhtisar

- Anda akan mengatur server MCP yang mengalirkan notifikasi progres ke klien saat memproses item.
- Klien akan menampilkan setiap notifikasi secara real time.
- Panduan ini mencakup prasyarat, pengaturan, menjalankan, dan pemecahan masalah.

### Prasyarat

- Python 3.9 atau versi lebih baru
- Paket Python `mcp` (pasang dengan `pip install mcp`)

### Instalasi & Pengaturan

1. Clone repositori atau unduh file solusi.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Buat dan aktifkan virtual environment (disarankan):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Pasang dependensi yang dibutuhkan:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### File

- **Server:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Klien:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Menjalankan Server Streaming HTTP Klasik

1. Masuk ke direktori solusi:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Mulai server streaming HTTP klasik:

   ```pwsh
   python server.py
   ```

3. Server akan mulai dan menampilkan:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Menjalankan Klien Streaming HTTP Klasik

1. Buka terminal baru (aktifkan virtual environment dan direktori yang sama):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Anda akan melihat pesan streaming yang dicetak secara berurutan:

   ```text
   Running classic HTTP streaming client...
   Connecting to http://localhost:8000/stream with message: hello
   --- Streaming Progress ---
   Processing file 1/3...
   Processing file 2/3...
   Processing file 3/3...
   Here's the file content: hello
   --- Stream Ended ---
   ```

### Menjalankan Server Streaming MCP

1. Masuk ke direktori solusi:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Mulai server MCP dengan transport streamable-http:
   ```pwsh
   python server.py mcp
   ```
3. Server akan mulai dan menampilkan:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Menjalankan Klien Streaming MCP

1. Buka terminal baru (aktifkan virtual environment dan direktori yang sama):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. Anda akan melihat notifikasi yang dicetak secara real time saat server memproses setiap item:
   ```
   Running MCP client...
   Starting client...
   Session ID before init: None
   Session ID after init: a30ab7fca9c84f5fa8f5c54fe56c9612
   Session initialized, ready to call tools.
   Received message: root=LoggingMessageNotification(...)
   NOTIFICATION: root=LoggingMessageNotification(...)
   ...
   Tool result: meta=None content=[TextContent(type='text', text='Processed files: file_1.txt, file_2.txt, file_3.txt | Message: hello from client')]
   ```

### Langkah-Langkah Implementasi Utama

1. **Buat server MCP menggunakan FastMCP.**
2. **Definisikan alat yang memproses daftar dan mengirim notifikasi menggunakan `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` untuk operasi non-blocking.**
- Selalu tangani pengecualian di server dan klien untuk keandalan.
- Uji dengan beberapa klien untuk melihat pembaruan secara real time.
- Jika menemui kesalahan, periksa versi Python Anda dan pastikan semua dependensi sudah terpasang.

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang otoritatif. Untuk informasi penting, disarankan menggunakan terjemahan manusia profesional. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.