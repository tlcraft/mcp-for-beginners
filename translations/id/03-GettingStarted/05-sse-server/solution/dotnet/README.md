<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:57:33+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "id"
}
-->
# Menjalankan contoh ini

## -1- Instal dependensi

```bash
dotnet run
```

## -2- Jalankan contoh

```bash
dotnet run
```

## -3- Uji contoh

Mulai terminal terpisah sebelum Anda menjalankan perintah di bawah ini (pastikan server masih berjalan).

Dengan server berjalan di satu terminal, buka terminal lain dan jalankan perintah berikut:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Ini akan memulai server web dengan antarmuka visual yang memungkinkan Anda menguji contoh.

Setelah server terhubung:

- coba daftarkan alat dan jalankan `add`, dengan argumen 2 dan 4, Anda harus melihat 6 dalam hasil.
- pergi ke sumber daya dan template sumber daya dan panggil "greeting", ketikkan nama dan Anda harus melihat salam dengan nama yang Anda berikan.

### Pengujian dalam mode CLI

Anda dapat meluncurkannya langsung dalam mode CLI dengan menjalankan perintah berikut:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Ini akan menampilkan semua alat yang tersedia di server. Anda harus melihat output berikut:

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

Untuk memanggil alat ketik:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
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
> Biasanya lebih cepat menjalankan ispector dalam mode CLI daripada di browser.
> Baca lebih lanjut tentang inspector [di sini](https://github.com/modelcontextprotocol/inspector).

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan penerjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berusaha untuk akurasi, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang berwenang. Untuk informasi penting, disarankan menggunakan terjemahan manusia profesional. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang timbul dari penggunaan terjemahan ini.