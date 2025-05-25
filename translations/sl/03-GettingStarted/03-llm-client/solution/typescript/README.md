<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-17T10:59:17+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "sl"
}
-->
# මෙම නිදසුන ක්‍රියාත්මක කිරීම

මෙම නිදසුනේදී, LLM එකක් පාරිභෝගිකයාට තිබිය යුතුය. LLM එක ඔබට මෙය Codespaces එකක ක්‍රියාත්මක කරන ලෙස හෝ GitHub හි පුද්ගලික ප්‍රවේශ ටෝකනයක් සකස් කිරීමට අවශ්‍ය වේ.

## -1- අවශ්‍යතා ස්ථාපනය කිරීම

```bash
npm install
```

## -3- සේවාදායකය ක්‍රියාත්මක කිරීම

```bash
npm run build
```

## -4- පාරිභෝගිකයා ක්‍රියාත්මක කිරීම

```sh
npm run client
```

ඔබට පහත දැක්වෙන ප්‍රතිඵලයක් මෙන් එකක් දැකිය හැක:

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za strojno prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko samodejni prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku je treba obravnavati kot avtoritativni vir. Za kritične informacije je priporočljiv profesionalni človeški prevod. Ne prevzemamo odgovornosti za nesporazume ali napačne razlage, ki izhajajo iz uporabe tega prevoda.