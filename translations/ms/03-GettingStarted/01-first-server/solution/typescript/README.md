<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:25:30+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "ms"
}
-->
# Menjalankan sampel ini

Anda disarankan untuk memasang `uv` tetapi bukan keperluan, lihat [arahan](https://docs.astral.sh/uv/#highlights)

## -1- Pasang kebergantungan

```bash
npm install
```

## -3- Jalankan sampel

```bash
npm run build
```

## -4- Uji sampel

Dengan pelayan berjalan dalam satu terminal, buka terminal lain dan jalankan perintah berikut:

```bash
npm run inspector
```

Ini akan memulakan pelayan web dengan antara muka visual yang membolehkan anda menguji sampel.

Setelah pelayan disambungkan:

- cuba senaraikan alat dan jalankan `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` adalah pembungkus di sekelilingnya.

Anda boleh melancarkannya secara langsung dalam mod CLI dengan menjalankan perintah berikut:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

Ini akan menyenaraikan semua alat yang tersedia dalam pelayan. Anda seharusnya melihat output berikut:

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

Untuk memanggil alat, taipkan:

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Anda seharusnya melihat output berikut:

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
> Biasanya lebih cepat untuk menjalankan pemeriksa dalam mod CLI berbanding dalam pelayar.
> Baca lebih lanjut tentang pemeriksa [di sini](https://github.com/modelcontextprotocol/inspector).

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang berwibawa. Untuk maklumat penting, terjemahan manusia profesional adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.