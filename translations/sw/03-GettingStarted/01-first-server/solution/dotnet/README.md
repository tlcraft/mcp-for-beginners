<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "07863f50601f395c3bdfce30f555f11a",
  "translation_date": "2025-07-13T17:50:16+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "sw"
}
-->
# Kuendesha sampuli hii

## -1- Sakinisha utegemezi

```bash
dotnet restore
```

## -3- Endesha sampuli

```bash
dotnet run
```

## -4- Jaribu sampuli

Wakati serveri inapoendesha kwenye terminali moja, fungua terminali nyingine na endesha amri ifuatayo:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Hii inapaswa kuanzisha serveri ya wavuti yenye kiolesura cha kuona kinachokuwezesha kujaribu sampuli.

Mara serveri itakapounganishwa:

- jaribu kuorodhesha zana na endesha `add`, ukiingiza hoja 2 na 4, unapaswa kuona 6 kama matokeo.
- nenda kwenye resources na resource template na piga "greeting", andika jina na utapokea salamu yenye jina ulilotoa.

### Kupima kwa njia ya CLI

Unaweza kuanzisha moja kwa moja kwa njia ya CLI kwa kuendesha amri ifuatayo:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Hii itaorodhesha zana zote zinazopatikana kwenye serveri. Unapaswa kuona matokeo yafuatayo:

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

Ili kuitisha zana andika:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Unapaswa kuona matokeo yafuatayo:

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
> Kwa kawaida ni haraka zaidi kuendesha inspector kwa njia ya CLI kuliko kupitia kivinjari.
> Soma zaidi kuhusu inspector [hapa](https://github.com/modelcontextprotocol/inspector).

**Kiarifu cha Kutotegemea**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.