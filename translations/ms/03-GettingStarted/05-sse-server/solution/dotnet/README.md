<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-07-13T20:11:11+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "ms"
}
-->
# Menjalankan contoh ini

## -1- Pasang kebergantungan

```bash
dotnet restore
```

## -2- Jalankan contoh

```bash
dotnet run
```

## -3- Uji contoh

Mulakan terminal berasingan sebelum anda jalankan arahan di bawah (pastikan server masih berjalan).

Dengan server berjalan di satu terminal, buka terminal lain dan jalankan arahan berikut:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Ini akan memulakan server web dengan antara muka visual yang membolehkan anda menguji contoh.

> Pastikan **SSE** dipilih sebagai jenis pengangkutan, dan URL adalah `http://localhost:3001/sse`.

Setelah server disambungkan:

- cuba senaraikan alat dan jalankan `add`, dengan argumen 2 dan 4, anda sepatutnya melihat hasil 6.
- pergi ke resources dan resource template dan panggil "greeting", taipkan nama dan anda akan melihat ucapan dengan nama yang anda berikan.

### Ujian dalam mod CLI

Anda boleh lancarkan terus dalam mod CLI dengan menjalankan arahan berikut:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Ini akan menyenaraikan semua alat yang tersedia di server. Anda sepatutnya melihat output berikut:

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

Untuk memanggil alat taip:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Anda sepatutnya melihat output berikut:

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
> Biasanya lebih pantas menjalankan inspector dalam mod CLI berbanding di pelayar.
> Baca lebih lanjut tentang inspector [di sini](https://github.com/modelcontextprotocol/inspector).

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.