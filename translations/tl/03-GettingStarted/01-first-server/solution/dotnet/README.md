<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T06:05:28+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "tl"
}
-->
# Pagpapatakbo ng sample na ito

## -1- I-install ang mga dependencies

```bash
dotnet restore
```

## -3- Patakbuhin ang sample


```bash
dotnet run
```

## -4- Subukan ang sample

Habang tumatakbo ang server sa isang terminal, buksan ang isa pang terminal at patakbuhin ang sumusunod na utos:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Dapat itong magsimula ng web server na may visual na interface na magpapahintulot sa iyo na subukan ang sample.

Kapag nakakonekta na ang server:

- subukang ilista ang mga tools at patakbuhin ang `add`, gamit ang mga argumento na 2 at 4, dapat lumabas ang 6 bilang resulta.
- pumunta sa resources at resource template at tawagin ang "greeting", mag-type ng pangalan at makikita mo ang pagbati gamit ang pangalang iyong inilagay.

### Pagsubok sa CLI mode

Maaari mo itong patakbuhin direkta sa CLI mode sa pamamagitan ng pagpapatakbo ng sumusunod na utos:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Ililista nito ang lahat ng mga tools na available sa server. Dapat mong makita ang sumusunod na output:

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

Upang tawagin ang isang tool, i-type:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

Dapat mong makita ang sumusunod na output:

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
> Karaniwang mas mabilis patakbuhin ang inspector sa CLI mode kaysa sa browser.
> Basahin pa tungkol sa inspector [dito](https://github.com/modelcontextprotocol/inspector).

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat aming pinagsisikapang maging tumpak ang pagsasalin, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa kanyang sariling wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.