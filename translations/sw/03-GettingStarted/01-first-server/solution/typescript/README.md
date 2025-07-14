<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-07-13T18:06:52+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "sw"
}
-->
# Kuendesha sampuli hii

Unashauriwa kufunga `uv` lakini si lazima, angalia [maelekezo](https://docs.astral.sh/uv/#highlights)

## -1- Sakinisha utegemezi

```bash
npm install
```

## -3- Endesha sampuli


```bash
npm run build
```

## -4- Jaribu sampuli

Wakati server ikifanya kazi kwenye terminal moja, fungua terminal nyingine na endesha amri ifuatayo:

```bash
npm run inspector
```

Hii inapaswa kuanzisha server ya wavuti yenye kiolesura cha kuona kinachokuwezesha kujaribu sampuli.

Mara server itakapounganishwa:

- jaribu kuorodhesha zana na endesha `add`, kwa hoja 2 na 4, unapaswa kuona 6 kama matokeo.
- nenda kwenye resources na resource template na piga "greeting", andika jina na unapaswa kuona salamu yenye jina ulilotoa.

### Kupima kwa mode ya CLI

Inspector uliyoendesha ni app ya Node.js na `mcp dev` ni kifuniko chake.

Unaweza kuianzisha moja kwa moja kwa mode ya CLI kwa kuendesha amri ifuatayo:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
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
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> Kwa kawaida ni haraka zaidi kuendesha inspector kwa mode ya CLI kuliko kwa kivinjari.
> Soma zaidi kuhusu inspector [hapa](https://github.com/modelcontextprotocol/inspector).

**Kiarifu cha Kutotegemea**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.