<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:58:00+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "tl"
}
-->
# Pagpapatakbo ng sample na ito

## -1- I-install ang mga dependencies

```bash
dotnet run
```

## -2- Patakbuhin ang sample

```bash
dotnet run
```

## -3- Subukan ang sample

Magbukas ng hiwalay na terminal bago mo patakbuhin ang nasa ibaba (siguraduhing tumatakbo pa rin ang server).

Kapag tumatakbo na ang server sa isang terminal, magbukas ng isa pang terminal at patakbuhin ang sumusunod na command:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

Dapat magsimula ito ng web server na may visual na interface na nagbibigay-daan sa iyo na subukan ang sample.

Kapag nakakonekta na ang server:

- subukang ilista ang mga tools at patakbuhin ang `add`, gamit ang args 2 at 4, dapat mong makita ang 6 sa resulta.
- pumunta sa mga resources at resource template at tawagin ang "greeting", mag-type ng pangalan at dapat mong makita ang pagbati na may pangalan na ibinigay mo.

### Pagsubok sa CLI mode

Maaari mo itong ilunsad nang direkta sa CLI mode sa pamamagitan ng pagpapatakbo ng sumusunod na command:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

Ilista nito ang lahat ng tools na available sa server. Dapat mong makita ang sumusunod na output:

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

Upang magpatakbo ng tool mag-type ng:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
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
> Karaniwan mas mabilis na patakbuhin ang inspector sa CLI mode kaysa sa browser.
> Magbasa pa tungkol sa inspector [dito](https://github.com/modelcontextprotocol/inspector).

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Habang pinagsisikapan naming maging tumpak, pakitandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkakatumpak. Ang orihinal na dokumento sa kanyang katutubong wika ang dapat ituring na mapagkakatiwalaang sanggunian. Para sa mahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaintindihan o maling interpretasyon na dulot ng paggamit ng pagsasaling ito.