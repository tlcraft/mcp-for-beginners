<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:58:11+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "sw"
}
-->
# Kuendesha sampuli hii

## -1- Sakinisha mahitaji

```bash
dotnet run
```

## -2- Endesha sampuli

```bash
dotnet run
```

## -3- Jaribu sampuli

Anzisha terminal tofauti kabla ya kuendesha yaliyo chini (hakikisha seva bado inaendelea).

Na seva ikiendelea kwenye terminal moja, fungua terminal nyingine na endesha amri ifuatayo:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Hii inapaswa kuanzisha seva ya wavuti yenye kiolesura cha kuona kinachokuruhusu kujaribu sampuli.

Mara seva inapounganishwa:

- jaribu kuorodhesha zana na endesha `add`, ukiwa na args 2 na 4, unapaswa kuona 6 katika matokeo.
- nenda kwenye rasilimali na template ya rasilimali na uite "greeting", andika jina na unapaswa kuona salamu na jina ulilotoa.

### Kujaribu katika hali ya CLI

Unaweza kuianzisha moja kwa moja katika hali ya CLI kwa kuendesha amri ifuatayo:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Hii itaorodhesha zana zote zinazopatikana kwenye seva. Unapaswa kuona matokeo yafuatayo:

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

Kuita zana andika:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
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
> Kwa kawaida ni haraka zaidi kuendesha ispector katika hali ya CLI kuliko kwenye kivinjari.
> Soma zaidi kuhusu ispector [hapa](https://github.com/modelcontextprotocol/inspector).

**Kanusho**: 
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati asili katika lugha yake ya awali inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa habari muhimu, tafsiri ya kibinadamu ya kitaalamu inapendekezwa. Hatutawajibika kwa kutoelewana au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.