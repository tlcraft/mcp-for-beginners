<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:25:41+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "tl"
}
-->
# Pagtakbo ng sample na ito

Inirerekomenda na i-install ang `uv` pero hindi ito kinakailangan, tingnan ang [mga instruksyon](https://docs.astral.sh/uv/#highlights)

## -1- I-install ang mga kinakailangan

```bash
npm install
```

## -3- Patakbuhin ang sample

```bash
npm run build
```

## -4- Subukan ang sample

Habang tumatakbo ang server sa isang terminal, buksan ang isa pang terminal at patakbuhin ang sumusunod na command:

```bash
npm run inspector
```

Dapat itong magsimula ng isang web server na may visual na interface na nagpapahintulot sa iyo na subukan ang sample.

Kapag nakakonekta na ang server:

- subukan ang paglista ng mga tools at patakbuhin `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` ay isang wrapper sa paligid nito.

Maaari mo itong ilunsad direkta sa CLI mode sa pamamagitan ng pagpapatakbo ng sumusunod na command:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

Ito ay maglilista ng lahat ng mga tools na available sa server. Dapat mong makita ang sumusunod na output:

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

Para tawagin ang isang tool, i-type:

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> Mas mabilis kadalasan ang pagtakbo ng inspector sa CLI mode kaysa sa browser.
> Magbasa pa tungkol sa inspector [dito](https://github.com/modelcontextprotocol/inspector).

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Habang sinisikap namin ang katumpakan, pakitandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkaka-ayon. Ang orihinal na dokumento sa kanyang katutubong wika ang dapat ituring na mapagkakatiwalaang sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot para sa anumang hindi pagkakaintindihan o maling interpretasyon na nagmumula sa paggamit ng pagsasaling ito.