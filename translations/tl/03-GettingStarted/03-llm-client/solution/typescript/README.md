<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-17T10:57:45+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "tl"
}
-->
# Pagpapatakbo ng sample na ito

Ang sample na ito ay nangangailangan ng pagkakaroon ng LLM sa kliyente. Kailangan ng LLM na patakbuhin mo ito sa isang Codespaces o mag-set up ng personal access token sa GitHub para gumana.

## -1- I-install ang mga kinakailangan

```bash
npm install
```

## -3- Patakbuhin ang server

```bash
npm run build
```

## -4- Patakbuhin ang kliyente

```sh
npm run client
```

Dapat mong makita ang resulta na katulad ng:

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**Pagtatatuwa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Habang sinisikap naming maging tumpak, pakitandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi tumpak na impormasyon. Ang orihinal na dokumento sa kanyang sariling wika ang dapat ituring na mapagkakatiwalaang sanggunian. Para sa mahalagang impormasyon, inirerekomenda ang propesyonal na pagsasaling-wika ng tao. Hindi kami mananagot para sa anumang hindi pagkakaintindihan o maling interpretasyon na dulot ng paggamit ng pagsasaling ito.