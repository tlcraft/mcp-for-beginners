<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T06:06:00+00:00",
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

Kwa server ikiendesha kwenye terminal moja, fungua terminal nyingine na endesha amri ifuatayo:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Hii inapaswa kuanzisha server ya wavuti yenye kiolesura cha kuona kinachokuwezesha kujaribu sampuli.

Mara server itakapounganishwa:

- jaribu orodha ya zana na endesha `add`, kwa hoja 2 na 4, unapaswa kuona 6 kama matokeo.
- nenda kwenye resources na template ya resource na piga "greeting", andika jina na utapokea salamu yenye jina ulilotoa.

### Kupima kwa hali ya CLI

Unaweza kuanzisha moja kwa moja kwa hali ya CLI kwa kuendesha amri ifuatayo:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Hii itaorodhesha zana zote zilizopo kwenye server. Unapaswa kuona matokeo yafuatayo:

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

Ili kuitisha zana, andika:

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
> Kwa kawaida ni haraka zaidi kuendesha inspector kwa hali ya CLI kuliko kupitia kivinjari.
> Soma zaidi kuhusu inspector [hapa](https://github.com/modelcontextprotocol/inspector).

**Kifungu cha Kutolewa Hukumu**:  
Hati hii imetafsiriwa kwa kutumia huduma ya utafsiri wa AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuhakikisha usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya mama inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inashauriwa. Hatuna dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.