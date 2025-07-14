<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:21:26+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "ms"
}
-->
# Menjalankan contoh ini

Berikut adalah cara untuk menjalankan server dan klien streaming HTTP klasik, serta server dan klien streaming MCP menggunakan Python.

### Gambaran Keseluruhan

- Anda akan menyediakan server MCP yang menstrim notifikasi kemajuan kepada klien semasa ia memproses item.
- Klien akan memaparkan setiap notifikasi secara masa nyata.
- Panduan ini merangkumi keperluan, persediaan, cara menjalankan, dan penyelesaian masalah.

### Keperluan

- Python 3.9 atau lebih baru
- Pakej Python `mcp` (pasang dengan `pip install mcp`)

### Pemasangan & Persediaan

1. Klon repositori atau muat turun fail penyelesaian.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Buat dan aktifkan persekitaran maya (disyorkan):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Pasang kebergantungan yang diperlukan:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### Fail

- **Server:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Klien:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Menjalankan Server Streaming HTTP Klasik

1. Pergi ke direktori penyelesaian:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Mulakan server streaming HTTP klasik:

   ```pwsh
   python server.py
   ```

3. Server akan bermula dan memaparkan:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Menjalankan Klien Streaming HTTP Klasik

1. Buka terminal baru (aktifkan persekitaran maya dan direktori yang sama):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Anda akan melihat mesej yang distrim dicetak secara berurutan:

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

1. Pergi ke direktori penyelesaian:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Mulakan server MCP dengan pengangkutan streamable-http:
   ```pwsh
   python server.py mcp
   ```
3. Server akan bermula dan memaparkan:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Menjalankan Klien Streaming MCP

1. Buka terminal baru (aktifkan persekitaran maya dan direktori yang sama):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. Anda akan melihat notifikasi dicetak secara masa nyata semasa server memproses setiap item:
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

### Langkah Utama Pelaksanaan

1. **Buat server MCP menggunakan FastMCP.**
2. **Tentukan alat yang memproses senarai dan menghantar notifikasi menggunakan `ctx.info()` atau `ctx.log()`.**
3. **Jalankan server dengan `transport="streamable-http"`.**
4. **Laksanakan klien dengan pengendali mesej untuk memaparkan notifikasi sebaik tiba.**

### Penjelasan Kod
- Server menggunakan fungsi async dan konteks MCP untuk menghantar kemas kini kemajuan.
- Klien melaksanakan pengendali mesej async untuk mencetak notifikasi dan hasil akhir.

### Petua & Penyelesaian Masalah

- Gunakan `async/await` untuk operasi tanpa sekatan.
- Sentiasa tangani pengecualian di kedua-dua server dan klien untuk ketahanan.
- Uji dengan pelbagai klien untuk melihat kemas kini masa nyata.
- Jika menghadapi ralat, semak versi Python anda dan pastikan semua kebergantungan dipasang.

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.