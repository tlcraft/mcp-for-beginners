<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-17T09:18:21+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "id"
}
-->
# Menjalankan sampel ini

Disarankan untuk menginstal `uv` tapi tidak wajib, lihat [instruksi](https://docs.astral.sh/uv/#highlights)

## -0- Buat lingkungan virtual

```bash
python -m venv venv
```

## -1- Aktifkan lingkungan virtual

```bash
venv\Scrips\activate
```

## -2- Instal dependensi

```bash
pip install "mcp[cli]"
```

## -3- Jalankan sampel

```bash
mcp run server.py
```

## -4- Uji sampel

Dengan server berjalan di satu terminal, buka terminal lain dan jalankan perintah berikut:

```bash
mcp dev server.py
```

Ini akan memulai server web dengan antarmuka visual yang memungkinkan Anda untuk menguji sampel.

Setelah server terhubung:

- coba daftarkan alat dan jalankan `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` adalah pembungkus di sekitarnya.

Anda dapat meluncurkannya langsung dalam mode CLI dengan menjalankan perintah berikut:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

Ini akan menampilkan semua alat yang tersedia di server. Anda harus melihat output berikut:

```text
{
  "tools": [
    {
      "name": "add",
      "description": "Add two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "title": "A",
            "type": "integer"
          },
          "b": {
            "title": "B",
            "type": "integer"
          }
        },
        "required": [
          "a",
          "b"
        ],
        "title": "addArguments"
      }
    }
  ]
}
```

Untuk memanggil alat ketik:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Anda harus melihat output berikut:

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Biasanya lebih cepat menjalankan inspector dalam mode CLI daripada di browser.
> Baca lebih lanjut tentang inspector [di sini](https://github.com/modelcontextprotocol/inspector).

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan penerjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang otoritatif. Untuk informasi penting, disarankan menggunakan penerjemahan manusia profesional. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.