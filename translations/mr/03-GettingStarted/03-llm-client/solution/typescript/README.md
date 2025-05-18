<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-17T10:54:16+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "mr"
}
-->
# हे नमुना चालवणे

हा नमुना ग्राहकावर LLM असण्याशी संबंधित आहे. LLM ला तुम्हाला हे Codespaces मध्ये चालवावे लागेल किंवा GitHub मध्ये वैयक्तिक प्रवेश टोकन सेट करावे लागेल.

## -1- अवलंबित्वे स्थापित करा

```bash
npm install
```

## -3- सर्व्हर चालवा

```bash
npm run build
```

## -4- ग्राहक चालवा

```sh
npm run client
```

तुम्हाला यासारखा एक परिणाम दिसायला हवा:

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**अस्वीकरण**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून भाषांतरित केला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, कृपया लक्षात घ्या की स्वयंचलित भाषांतरे त्रुटी किंवा अचूकतेच्या कमतरतेसह असू शकतात. मूळ भाषेतील मूळ दस्तऐवज अधिकृत स्रोत म्हणून विचारात घेतला पाहिजे. गंभीर माहितीसाठी, व्यावसायिक मानवी भाषांतराची शिफारस केली जाते. या भाषांतराच्या वापरातून उद्भवणाऱ्या कोणत्याही गैरसमज किंवा चुकीच्या अर्थासाठी आम्ही जबाबदार नाही.