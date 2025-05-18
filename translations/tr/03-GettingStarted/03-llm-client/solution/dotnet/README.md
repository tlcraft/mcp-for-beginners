<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:41:15+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "tr"
}
-->
# Bu örneği çalıştırın

> [!NOTE]
> Bu örnek, GitHub Codespaces örneği kullandığınızı varsayar. Bunu yerel olarak çalıştırmak istiyorsanız, GitHub'da kişisel erişim belirteci ayarlamanız gerekir.

## Kütüphaneleri yükle

```sh
dotnet restore
```

Şu kütüphaneler yüklenmelidir: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol 

## Çalıştır

```sh 
dotnet run
```

Şuna benzer bir çıktı görmelisiniz:

```text
Setting up stdio transport
Listing tools
Connected to server with tools: Add
Tool description: Adds two numbers
Tool parameters: {"title":"Add","description":"Adds two numbers","type":"object","properties":{"a":{"type":"integer"},"b":{"type":"integer"}},"required":["a","b"]}
Tool definition: Azure.AI.Inference.ChatCompletionsToolDefinition
Properties: {"a":{"type":"integer"},"b":{"type":"integer"}}
MCP Tools def: 0: Azure.AI.Inference.ChatCompletionsToolDefinition
Tool call 0: Add with arguments {"a":2,"b":4}
Sum 6
```

Çıktının çoğu sadece hata ayıklama içindir ancak önemli olan MCP Sunucusundan araçları listelemenizdir, bunları LLM araçlarına dönüştürün ve sonuç olarak "Sum 6" MCP istemci yanıtı alırsınız.

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluğu sağlamak için çaba göstersek de, otomatik çevirilerin hata veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belgenin kendi dilindeki hali yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından kaynaklanan yanlış anlamalar veya yanlış yorumlamalardan dolayı sorumluluk kabul etmiyoruz.