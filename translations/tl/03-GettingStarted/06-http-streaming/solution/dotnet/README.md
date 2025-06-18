<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-06-18T06:18:47+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
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

Dapat itong magsimula ng web server na may visual na interface na nagpapahintulot sa iyo na subukan ang sample.

> Siguraduhing ang **Streamable HTTP** ang napiling uri ng transport, at ang URL ay `http://localhost:3001/mcp`.

Once the server is connected: 

- try listing tools and run `add`, na may mga args na 2 at 4, makikita mo ang 6 bilang resulta.
- pumunta sa resources at resource template at tawagin ang "greeting", mag-type ng pangalan at makikita mo ang pagbati gamit ang pangalang ibinigay mo.

### Pagsusuri sa CLI mode

Maaari mo itong patakbuhin direkta sa CLI mode sa pamamagitan ng pagpapatakbo ng sumusunod na utos:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Ipapakita nito ang lahat ng mga tools na available sa server. Dapat mong makita ang sumusunod na output:

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
> Karaniwan, mas mabilis patakbuhin ang inspector sa CLI mode kaysa sa browser.
> Basahin pa ang tungkol sa inspector [dito](https://github.com/modelcontextprotocol/inspector).

**Pagtatangi**:  
Ang dokumentong ito ay isinalin gamit ang serbisyong AI na pagsasalin na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagama’t nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o kamalian. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasaling-tao. Hindi kami mananagot sa anumang hindi pagkakaintindihan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.