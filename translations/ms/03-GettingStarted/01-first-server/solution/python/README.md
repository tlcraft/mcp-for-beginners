<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-17T09:18:29+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "ms"
}
-->
# Menjalankan contoh ini

Anda disarankan untuk memasang `uv` tetapi ia bukanlah satu keperluan, lihat [arahan](https://docs.astral.sh/uv/#highlights)

## -0- Cipta persekitaran maya

```bash
python -m venv venv
```

## -1- Aktifkan persekitaran maya

```bash
venv\Scrips\activate
```

## -2- Pasang keperluan

```bash
pip install "mcp[cli]"
```

## -3- Jalankan contoh

```bash
mcp run server.py
```

## -4- Uji contoh

Dengan pelayan sedang berjalan di satu terminal, buka terminal lain dan jalankan perintah berikut:

```bash
mcp dev server.py
```

Ini sepatutnya memulakan pelayan web dengan antaramuka visual yang membolehkan anda menguji contoh tersebut.

Sebaik sahaja pelayan bersambung:

- cuba senaraikan alat dan jalankan `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` adalah pembungkus di sekelilingnya.

Anda boleh melancarkannya terus dalam mod CLI dengan menjalankan perintah berikut:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

Ini akan menyenaraikan semua alat yang tersedia dalam pelayan. Anda sepatutnya melihat keluaran berikut:

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
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Anda sepatutnya melihat keluaran berikut:

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
> Biasanya lebih cepat menjalankan pemeriksa dalam mod CLI berbanding dalam pelayar.
> Baca lebih lanjut mengenai pemeriksa [di sini](https://github.com/modelcontextprotocol/inspector).

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang berwibawa. Untuk maklumat kritikal, terjemahan manusia profesional disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.