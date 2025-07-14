<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-07-13T18:06:34+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "id"
}
-->
# Menjalankan contoh ini

Disarankan untuk menginstal `uv` tapi tidak wajib, lihat [instruksi](https://docs.astral.sh/uv/#highlights)

## -1- Instal dependensi

```bash
npm install
```

## -3- Jalankan contoh


```bash
npm run build
```

## -4- Uji contoh

Dengan server berjalan di satu terminal, buka terminal lain dan jalankan perintah berikut:

```bash
npm run inspector
```

Ini akan memulai server web dengan antarmuka visual yang memungkinkan Anda menguji contoh.

Setelah server terhubung:

- coba daftar tools dan jalankan `add`, dengan argumen 2 dan 4, Anda harus melihat hasil 6.
- pergi ke resources dan resource template lalu panggil "greeting", ketikkan sebuah nama dan Anda akan melihat sapaan dengan nama yang Anda masukkan.

### Pengujian dalam mode CLI

Inspector yang Anda jalankan sebenarnya adalah aplikasi Node.js dan `mcp dev` adalah pembungkusnya.

Anda bisa menjalankannya langsung dalam mode CLI dengan menjalankan perintah berikut:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

Ini akan menampilkan semua tools yang tersedia di server. Anda harus melihat output berikut:

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

Untuk memanggil sebuah tool ketik:

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> Biasanya menjalankan inspector dalam mode CLI jauh lebih cepat daripada di browser.
> Baca lebih lanjut tentang inspector [di sini](https://github.com/modelcontextprotocol/inspector).

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk akurasi, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sah. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.