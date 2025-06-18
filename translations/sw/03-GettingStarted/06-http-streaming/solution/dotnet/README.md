<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-06-18T06:18:53+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "sw"
}
-->
# Kuendesha sampuli hii

## -1- Sakinisha utegemezi

```bash
dotnet restore
```

## -2- Endesha sampuli

```bash
dotnet run
```

## -3- Jaribu sampuli

Anza terminali tofauti kabla ya kuendesha ifuatayo (hakikisha seva bado inaendelea).

Seva ikiwa inaendeshwa kwenye terminali moja, fungua terminali nyingine na endesha amri ifuatayo:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Hii inapaswa kuanzisha seva ya wavuti yenye kiolesura cha kuona kinachokuwezesha kujaribu sampuli.

> Hakikisha kwamba **Streamable HTTP** imechaguliwa kama aina ya usafirishaji, na URL ni `http://localhost:3001/mcp`.

Once the server is connected: 

- try listing tools and run `add`, ukiweka vigezo 2 na 4, unapaswa kuona 6 matokeo.
- nenda kwenye resources na resource template na ita "greeting", andika jina na utapata salamu yenye jina ulilotoa.

### Kujaribu katika hali ya CLI

Unaweza kuanzisha moja kwa moja katika hali ya CLI kwa kuendesha amri ifuatayo:

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

Ili kuitisha zana andika:

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
> Kwa kawaida ni haraka zaidi kuendesha inspector katika hali ya CLI kuliko katika kivinjari.
> Soma zaidi kuhusu inspector [hapa](https://github.com/modelcontextprotocol/inspector).

**Tangazo la Kutokujali**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuhakikisha usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upotovu. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inashauriwa. Hatubebwi jukumu kwa maelewano au tafsiri potofu zitokanazo na matumizi ya tafsiri hii.