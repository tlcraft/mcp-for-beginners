<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-07-13T20:21:38+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "tl"
}
-->
# Pagpapatakbo ng sample na ito

## -1- I-install ang mga dependencies

```bash
npm install
```

## -3- Patakbuhin ang sample


```bash
npm run build
```

## -4- Subukan ang sample

Habang tumatakbo ang server sa isang terminal, buksan ang isa pang terminal at patakbuhin ang sumusunod na utos:

```bash
npm run inspector
```

Dapat nitong simulan ang isang web server na may visual na interface na nagpapahintulot sa iyo na subukan ang sample.

Kapag nakakonekta na ang server:

- subukang ilista ang mga tools at patakbuhin ang `add`, gamit ang mga argumento na 2 at 4, dapat mong makita ang 6 bilang resulta.
- pumunta sa resources at resource template at tawagin ang "greeting", mag-type ng pangalan at makikita mo ang pagbati gamit ang pangalang ibinigay mo.

### Pagsubok sa CLI mode

Ang inspector na pinatakbo mo ay isang Node.js app at ang `mcp dev` ay isang wrapper nito.

- Simulan ang server gamit ang utos na `npm run build`.

- Sa hiwalay na terminal, patakbuhin ang sumusunod na utos:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    Ililista nito ang lahat ng mga tools na available sa server. Dapat mong makita ang sumusunod na output:

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

- Tawagin ang isang tool type sa pamamagitan ng pag-type ng sumusunod na utos:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

Dapat mong makita ang sumusunod na output:

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> Mas mabilis karaniwang patakbuhin ang inspector sa CLI mode kaysa sa browser.
> Basahin pa tungkol sa inspector [dito](https://github.com/modelcontextprotocol/inspector).

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa kanyang sariling wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.