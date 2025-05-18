<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-17T09:18:36+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "tl"
}
-->
# Pagpapatakbo ng sample na ito

Inirerekomenda na i-install ang `uv` pero hindi ito kinakailangan, tingnan ang [mga tagubilin](https://docs.astral.sh/uv/#highlights)

## -0- Gumawa ng virtual na kapaligiran

```bash
python -m venv venv
```

## -1- I-activate ang virtual na kapaligiran

```bash
venv\Scrips\activate
```

## -2- I-install ang mga dependencies

```bash
pip install "mcp[cli]"
```

## -3- Patakbuhin ang sample

```bash
mcp run server.py
```

## -4- Subukan ang sample

Kapag tumatakbo na ang server sa isang terminal, magbukas ng isa pang terminal at patakbuhin ang sumusunod na utos:

```bash
mcp dev server.py
```

Dapat itong magsimula ng isang web server na may visual na interface na nagbibigay-daan sa iyo na subukan ang sample.

Kapag nakakonekta na ang server:

- subukang ilista ang mga tool at patakbuhin ang `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` ay isang wrapper sa paligid nito.

Maaari mo itong patakbuhin nang direkta sa CLI mode sa pamamagitan ng pagpapatakbo ng sumusunod na utos:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

Ililista nito ang lahat ng tool na magagamit sa server. Dapat mong makita ang sumusunod na output:

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

Upang magpatakbo ng isang tool, i-type:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> Karaniwang mas mabilis ang pagpapatakbo ng inspector sa CLI mode kaysa sa browser.
> Magbasa pa tungkol sa inspector [dito](https://github.com/modelcontextprotocol/inspector).

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI na serbisyo ng pagsasalin [Co-op Translator](https://github.com/Azure/co-op-translator). Habang sinisikap naming maging tumpak, mangyaring tandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi eksaktong impormasyon. Ang orihinal na dokumento sa kanyang katutubong wika ay dapat ituring na mapagkakatiwalaang sanggunian. Para sa mahalagang impormasyon, inirerekomenda ang propesyonal na pagsasaling tao. Hindi kami mananagot para sa anumang hindi pagkakaintindihan o maling interpretasyon na dulot ng paggamit ng pagsasaling ito.