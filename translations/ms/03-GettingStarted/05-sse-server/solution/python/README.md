<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:04:48+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "ms"
}
-->
# Menjalankan sampel ini

Disarankan untuk memasang `uv` tetapi ia bukan satu kewajipan, lihat [arahan](https://docs.astral.sh/uv/#highlights)

## -0- Buat persekitaran maya

```bash
python -m venv venv
```

## -1- Aktifkan persekitaran maya

```bash
venv\Scrips\activate
```

## -2- Pasang kebergantungan

```bash
pip install "mcp[cli]"
```

## -3- Jalankan sampel

```bash
mcp run server.py
```

## -4- Uji sampel

Dengan pelayan berjalan di satu terminal, buka terminal lain dan jalankan arahan berikut:

```bash
mcp dev server.py
```

Ini akan memulakan pelayan web dengan antara muka visual yang membolehkan anda menguji sampel.

Sebaik sahaja pelayan disambungkan:

- cuba senaraikan alat dan jalankan `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` adalah pembungkus di sekelilingnya.

Anda boleh melancarkannya secara langsung dalam mod CLI dengan menjalankan arahan berikut:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Ini akan menyenaraikan semua alat yang tersedia di pelayan. Anda sepatutnya melihat output berikut:

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

Untuk memanggil alat taip:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> Biasanya lebih cepat untuk menjalankan ispector dalam mod CLI berbanding dalam pelayar.
> Baca lebih lanjut mengenai ispector [di sini](https://github.com/modelcontextprotocol/inspector).

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang berwibawa. Untuk maklumat kritikal, terjemahan manusia profesional adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.