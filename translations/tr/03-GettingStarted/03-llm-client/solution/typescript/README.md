<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-17T10:55:36+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "tr"
}
-->
# Bu örneği çalıştırma

Bu örnek, istemcide bir LLM bulunmasını gerektirir. LLM, bunu ya bir Codespaces içinde çalıştırmanızı ya da GitHub'da kişisel erişim belirteci ayarlamanızı gerektirir.

## -1- Bağımlılıkları yükle

```bash
npm install
```

## -3- Sunucuyu çalıştır

```bash
npm run build
```

## -4- İstemciyi çalıştır

```sh
npm run client
```

Benzer bir sonuç görmelisiniz:

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**Feragatname**: 
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hata veya yanlışlık içerebileceğini unutmayın. Belgenin orijinal dili, yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından doğabilecek yanlış anlamalar veya yanlış yorumlamalardan sorumlu değiliz.