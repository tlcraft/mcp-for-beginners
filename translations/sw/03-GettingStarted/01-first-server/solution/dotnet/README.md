<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:11:45+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "sw"
}
-->
# Kuendesha sampuli hii

## -1- Sakinisha mahitaji

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- Endesha sampuli

```bash
dotnet run
```

## -4- Jaribu sampuli

Kwa server ikiwa inafanya kazi kwenye terminal moja, fungua terminal nyingine na endesha amri ifuatayo:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Hii inapaswa kuanzisha server ya wavuti yenye kiolesura cha kuona inayokuruhusu kujaribu sampuli.

Mara tu server inapounganishwa:

- jaribu kuorodhesha zana na endesha `add`, na hoja 2 na 4, unapaswa kuona 6 kwenye matokeo.
- nenda kwenye rasilimali na templeti ya rasilimali na ita "greeting", andika jina na unapaswa kuona salamu na jina ulilotoa.

### Kujaribu katika hali ya CLI

Unaweza kuiendesha moja kwa moja katika hali ya CLI kwa kuendesha amri ifuatayo:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Hii itaorodhesha zana zote zinazopatikana kwenye server. Unapaswa kuona matokeo yafuatayo:

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

Kuanzisha zana andika:

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
> Kwa kawaida ni haraka zaidi kuendesha ispector katika hali ya CLI kuliko kwenye kivinjari.
> Soma zaidi kuhusu ispector [hapa](https://github.com/modelcontextprotocol/inspector).

**Kataa:**
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati asili katika lugha yake ya asili inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatutawajibika kwa kutoelewana au kutafsiri vibaya kunakotokana na matumizi ya tafsiri hii.