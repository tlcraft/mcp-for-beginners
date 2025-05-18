<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:04:57+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "tl"
}
-->
# Pagpapatakbo ng halimbawang ito

Inirerekomenda na i-install ang `uv` ngunit hindi ito kinakailangan, tingnan ang [mga tagubilin](https://docs.astral.sh/uv/#highlights)

## -0- Lumikha ng virtual na kapaligiran

```bash
python -m venv venv
```

## -1- I-activate ang virtual na kapaligiran

```bash
venv\Scrips\activate
```

## -2- I-install ang mga kinakailangan

```bash
pip install "mcp[cli]"
```

## -3- Patakbuhin ang halimbawa

```bash
mcp run server.py
```

## -4- Subukan ang halimbawa

Habang tumatakbo ang server sa isang terminal, magbukas ng isa pang terminal at patakbuhin ang sumusunod na utos:

```bash
mcp dev server.py
```

Dapat magsimula ito ng isang web server na may visual na interface na magpapahintulot sa iyo na subukan ang halimbawa.

Kapag nakakonekta na ang server:

- subukan ang paglista ng mga tool at patakbuhin ang `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` ay isang wrapper para dito.

Maaari mo itong ilunsad nang direkta sa CLI mode sa pamamagitan ng pagpapatakbo ng sumusunod na utos:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

Ito ay maglilista ng lahat ng mga tool na available sa server. Dapat mong makita ang sumusunod na output:

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

Upang tawagin ang isang tool, i-type:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

Dapat mong makita ang sumusunod na output:

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
> Karaniwang mas mabilis patakbuhin ang ispector sa CLI mode kaysa sa browser.
> Magbasa pa tungkol sa inspector [dito](https://github.com/modelcontextprotocol/inspector).

**Pagtanggi**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Habang sinisikap naming maging tumpak, pakitandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o kamalian. Ang orihinal na dokumento sa kanyang katutubong wika ang dapat ituring na mapagkakatiwalaang sanggunian. Para sa mahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Kami ay hindi mananagot para sa anumang hindi pagkakaintindihan o maling interpretasyon na dulot ng paggamit ng pagsasaling ito.