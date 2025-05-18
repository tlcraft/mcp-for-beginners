<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:11:36+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "tl"
}
-->
# Pagpapatakbo ng halimbawang ito

## -1- I-install ang mga kinakailangang sangkap

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- Patakbuhin ang halimbawa

```bash
dotnet run
```

## -4- Subukan ang halimbawa

Habang tumatakbo ang server sa isang terminal, magbukas ng isa pang terminal at patakbuhin ang sumusunod na utos:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

Dapat magsimula ito ng isang web server na may visual na interface na nagpapahintulot sa iyo na subukan ang halimbawa.

Kapag nakakonekta na ang server:

- subukan ang paglista ng mga tool at patakbuhin ang `add`, gamit ang args 2 at 4, dapat mong makita ang 6 sa resulta.
- pumunta sa mga resources at resource template at tawagin ang "greeting", mag-type ng isang pangalan at dapat mong makita ang isang pagbati na may pangalan na iyong ibinigay.

### Pagsusuri sa CLI mode

Maaari mo itong ilunsad nang direkta sa CLI mode sa pamamagitan ng pagpapatakbo ng sumusunod na utos:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

Ililista nito ang lahat ng mga tool na magagamit sa server. Dapat mong makita ang sumusunod na output:

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

Upang tawagin ang isang tool, i-type ang:

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
> Magbasa pa tungkol sa inspector [dito](https://github.com/modelcontextprotocol/inspector).

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat sinisikap naming maging tumpak, pakitandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga error o hindi pagkakatumpak. Ang orihinal na dokumento sa kanyang katutubong wika ang dapat ituring na mapagkakatiwalaang pinagmulan. Para sa kritikal na impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot para sa anumang hindi pagkakaintindihan o maling interpretasyon na dulot ng paggamit ng pagsasaling ito.