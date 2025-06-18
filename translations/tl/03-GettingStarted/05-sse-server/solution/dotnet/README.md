<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T06:05:34+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "tl"
}
-->
# Pagpapatakbo ng sample na ito

## -1- I-install ang mga dependencies

```bash
dotnet restore
```

## -2- Patakbuhin ang sample

```bash
dotnet run
```

## -3- Subukan ang sample

Magbukas ng hiwalay na terminal bago patakbuhin ang nasa ibaba (siguraduhing tumatakbo pa rin ang server).

Habang tumatakbo ang server sa isang terminal, buksan ang isa pang terminal at patakbuhin ang sumusunod na utos:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Dapat nitong simulan ang isang web server na may visual interface na magpapahintulot sa iyo na subukan ang sample.

> Siguraduhing naka-set ang **SSE** bilang transport type, at ang URL ay `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add`, gamit ang mga args na 2 at 4, makikita mo ang 6 bilang resulta.
- pumunta sa resources at resource template at tawagin ang "greeting", mag-type ng pangalan at makikita mo ang pagbati gamit ang pangalang ibinigay mo.

### Pagsubok sa CLI mode

Maaari mo itong direktang patakbuhin sa CLI mode sa pamamagitan ng pagsunod na utos:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Ipapakita nito ang lahat ng tools na available sa server. Makikita mo ang sumusunod na output:

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

Para tawagin ang isang tool, i-type:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

Makikita mo ang sumusunod na output:

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
> Mas mabilis karaniwang patakbuhin ang inspector sa CLI mode kaysa sa browser.
> Basahin pa ang tungkol sa inspector [dito](https://github.com/modelcontextprotocol/inspector).

**Pagtatangi**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat aming pinagsisikapang maging tumpak ang salin, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na opisyal na sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.