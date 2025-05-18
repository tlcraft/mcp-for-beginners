<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fae57a69c2b62cb7d92ff12da65f36c3",
  "translation_date": "2025-05-17T10:12:36+00:00",
  "source_file": "03-GettingStarted/02-client/solution/typescript/README.md",
  "language_code": "sl"
}
-->
# इस नमूने को चलाना

आपको `uv` इंस्टॉल करने की सिफारिश की जाती है, लेकिन यह जरूरी नहीं है, [निर्देश देखें](https://docs.astral.sh/uv/#highlights)

## -1- निर्भरता स्थापित करें

```bash
npm install
```

## -3- सर्वर चलाएँ

```bash
npm run build
```

## -4- क्लाइंट चलाएँ

```sh
npm run client
```

आपको निम्नलिखित के समान एक परिणाम देखना चाहिए:

```text
Prompt:  {
  type: 'text',
  text: 'Please review this code:\n\nconsole.log("hello");'
}
Resource template:  file
Tool result:  { content: [ { type: 'text', text: '9' } ] }
```

**Zavrnitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve AI prevajanja [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da se zavedate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku bi moral biti obravnavan kot avtoritativni vir. Za kritične informacije je priporočljivo profesionalno človeško prevajanje. Ne odgovarjamo za kakršne koli nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.