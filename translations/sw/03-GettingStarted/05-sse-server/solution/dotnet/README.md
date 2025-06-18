<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T06:06:06+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
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

Anzisha terminali tofauti kabla ya kuendesha ifuatayo (hakikisha server bado inaendelea kuendesha).

Wakati server iko hai kwenye terminali moja, fungua terminali nyingine na endesha amri ifuatayo:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Hii inapaswa kuanzisha server ya wavuti yenye kiolesura cha kuona kinachokuwezesha kujaribu sampuli.

> Hakikisha kuwa **SSE** imechaguliwa kama aina ya usafirishaji, na URL ni `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add`, ukiweka vigezo 2 na 4, utapata 6 kama matokeo.
- nenda kwenye resources na resource template kisha itaje "greeting", andika jina na utaona salamu yenye jina ulilotoa.

### Kupima kwa njia ya CLI

Unaweza kuanzisha moja kwa moja kwa njia ya CLI kwa kuendesha amri ifuatayo:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Hii itaonyesha orodha ya zana zote zinazopatikana kwenye server. Utapata matokeo yafuatayo:

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

Ili kuitisha zana, andika:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Utapata matokeo yafuatayo:

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
> Kwa kawaida ni haraka zaidi kuendesha inspector kwa njia ya CLI kuliko kwenye kivinjari.
> Soma zaidi kuhusu inspector [hapa](https://github.com/modelcontextprotocol/inspector).

**Kiarifu cha Msamaha**:  
Nyaraka hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuwa sahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Nyaraka ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubeba dhamana kwa kutoelewana au tafsiri potofu zitokanazo na matumizi ya tafsiri hii.