<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:11:07+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "id"
}
-->
# Menjalankan contoh ini

## -1- Instal dependensi

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- Jalankan contoh

```bash
dotnet run
```

## -4- Uji contoh

Dengan server berjalan di satu terminal, buka terminal lain dan jalankan perintah berikut:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Ini akan memulai server web dengan antarmuka visual yang memungkinkan Anda menguji contoh tersebut.

Setelah server terhubung:

- coba daftar alat dan jalankan `add`, dengan argumen 2 dan 4, Anda seharusnya melihat hasil 6.
- pergi ke sumber daya dan template sumber daya dan panggil "greeting", ketikkan nama dan Anda seharusnya melihat sapaan dengan nama yang Anda berikan.

### Pengujian dalam mode CLI

Anda dapat meluncurkannya langsung dalam mode CLI dengan menjalankan perintah berikut:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Ini akan menampilkan semua alat yang tersedia di server. Anda seharusnya melihat output berikut:

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

Untuk memanggil alat, ketik:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Anda seharusnya melihat output berikut:

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> Biasanya lebih cepat menjalankan ispector dalam mode CLI daripada di browser.
> Baca lebih lanjut tentang inspector [di sini](https://github.com/modelcontextprotocol/inspector).

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan penerjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk akurasi, harap diingat bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang berwenang. Untuk informasi penting, disarankan menggunakan terjemahan manusia profesional. Kami tidak bertanggung jawab atas kesalahpahaman atau salah tafsir yang timbul dari penggunaan terjemahan ini.