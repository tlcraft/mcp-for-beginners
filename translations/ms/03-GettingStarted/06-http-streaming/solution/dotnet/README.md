<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-06-18T06:18:42+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
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

Ini akan memulakan pelayan web dengan antara muka visual yang membolehkan anda menguji contoh tersebut.

> Pastikan **Streamable HTTP** dipilih sebagai jenis pengangkutan, dan URL adalah `http://localhost:3001/mcp`.

Once the server is connected: 

- try listing tools and run `add`, dengan argumen 2 dan 4, anda sepatutnya melihat 6 sebagai hasilnya.
- pergi ke resources dan resource template dan panggil "greeting", taipkan nama dan anda akan melihat ucapan dengan nama yang anda berikan.

### Ujian dalam mod CLI

Anda boleh lancarkan terus dalam mod CLI dengan menjalankan arahan berikut:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Ini akan menyenaraikan semua alat yang tersedia dalam server. Anda sepatutnya melihat output berikut:

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
> Baca lebih lanjut mengenai inspector [di sini](https://github.com/modelcontextprotocol/inspector).

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab terhadap sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.