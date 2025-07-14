<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-07-13T20:16:37+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "sw"
}
-->
# Kuendesha sampuli hii

Unashauriwa kufunga `uv` lakini si lazima, angalia [maelekezo](https://docs.astral.sh/uv/#highlights)

## -0- Unda mazingira ya virtual

```bash
python -m venv venv
```

## -1- Washa mazingira ya virtual

```bash
venv\Scrips\activate
```

## -2- Sakinisha utegemezi

```bash
pip install "mcp[cli]"
```

## -3- Endesha sampuli


```bash
mcp run server.py
```

## -4- Jaribu sampuli

Wakati server iko hai kwenye terminal moja, fungua terminal nyingine na endesha amri ifuatayo:

```bash
mcp dev server.py
```

Hii inapaswa kuanzisha server ya wavuti yenye kiolesura cha kuona kinachokuwezesha kujaribu sampuli.

Mara server itakapounganishwa:

- jaribu kuorodhesha zana na endesha `add`, kwa hoja 2 na 4, unapaswa kuona 6 kama matokeo.
- nenda kwenye resources na resource template na piga get_greeting, andika jina na unapaswa kuona salamu yenye jina ulilotoa.

### Kupima kwa mode ya CLI

Inspector uliyoendesha ni app ya Node.js na `mcp dev` ni kifuniko cha app hiyo.

Unaweza kuizindua moja kwa moja kwa mode ya CLI kwa kuendesha amri ifuatayo:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Hii itaorodhesha zana zote zinazopatikana kwenye server. Unapaswa kuona matokeo yafuatayo:

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

Ili kuitisha zana andika:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Unapaswa kuona matokeo yafuatayo:

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
> Kwa kawaida ni haraka zaidi kuendesha inspector kwa mode ya CLI kuliko kutumia kivinjari.
> Soma zaidi kuhusu inspector [hapa](https://github.com/modelcontextprotocol/inspector).

**Kiarifu cha Kutotegemea**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inashauriwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.