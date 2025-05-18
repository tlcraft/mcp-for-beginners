<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:11:15+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "ms"
}
-->
# Menjalankan sampel ini

## -1- Pasang keperluan

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- Jalankan sampel

```bash
dotnet run
```

## -4- Uji sampel

Dengan pelayan berjalan di satu terminal, buka terminal lain dan jalankan arahan berikut:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Ini sepatutnya memulakan pelayan web dengan antara muka visual yang membolehkan anda menguji sampel.

Setelah pelayan disambungkan:

- cuba senaraikan alat dan jalankan `add`, dengan argumen 2 dan 4, anda sepatutnya melihat 6 dalam hasilnya.
- pergi ke sumber dan templat sumber dan panggil "greeting", taip nama dan anda sepatutnya melihat ucapan dengan nama yang anda berikan.

### Ujian dalam mod CLI

Anda boleh melancarkannya terus dalam mod CLI dengan menjalankan arahan berikut:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Ini akan menyenaraikan semua alat yang tersedia dalam pelayan. Anda sepatutnya melihat output berikut:

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

Untuk memanggil alat taip:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Anda sepatutnya melihat output berikut:

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
> Biasanya lebih pantas untuk menjalankan ispektor dalam mod CLI berbanding dalam pelayar.
> Baca lebih lanjut tentang ispektor [di sini](https://github.com/modelcontextprotocol/inspector).

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang berwibawa. Untuk maklumat kritikal, terjemahan manusia profesional adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.