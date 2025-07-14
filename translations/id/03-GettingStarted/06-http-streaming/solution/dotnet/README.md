<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-07-13T21:05:29+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "id"
}
-->
# Menjalankan contoh ini

## -1- Pasang dependensi

```bash
dotnet restore
```

## -2- Jalankan contoh

```bash
dotnet run
```

## -3- Uji contoh

Buka terminal terpisah sebelum menjalankan perintah di bawah ini (pastikan server masih berjalan).

Dengan server berjalan di satu terminal, buka terminal lain dan jalankan perintah berikut:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Ini akan memulai server web dengan antarmuka visual yang memungkinkan Anda menguji contoh.

> Pastikan **Streamable HTTP** dipilih sebagai tipe transport, dan URL-nya adalah `http://localhost:3001/mcp`.

Setelah server terhubung:

- coba daftar tools dan jalankan `add`, dengan argumen 2 dan 4, Anda harus melihat hasil 6.
- buka resources dan resource template lalu panggil "greeting", ketikkan sebuah nama dan Anda akan melihat sapaan dengan nama yang Anda masukkan.

### Pengujian dalam mode CLI

Anda bisa langsung menjalankannya dalam mode CLI dengan menjalankan perintah berikut:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Ini akan menampilkan semua tools yang tersedia di server. Anda harus melihat output berikut:

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

Untuk memanggil sebuah tool ketik:

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
> Biasanya menjalankan inspector dalam mode CLI jauh lebih cepat dibandingkan di browser.
> Baca lebih lanjut tentang inspector [di sini](https://github.com/modelcontextprotocol/inspector).

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk mencapai akurasi, harap diingat bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.