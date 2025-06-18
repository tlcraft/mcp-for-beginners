<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c40c54fa74ded9c223bc0ebfc8a2de7c",
  "translation_date": "2025-06-18T05:59:10+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "tr"
}
-->
# Bu örneği çalıştır

> [!NOTE]
> Bu örnek, bir GitHub Codespaces örneği kullandığınızı varsayar. Bunu yerel olarak çalıştırmak isterseniz, GitHub üzerinde kişisel erişim belirteci (PAT) oluşturmanız gerekir.
>
> ```bash
> # zsh/bash
> export GITHUB_TOKEN="{{YOUR_GITHUB_PAT}}"
> ```
>
> ```powershell
> # PowerShell
> $env:GITHUB_TOKEN = "{{YOUR_GITHUB_PAT}}"
> ```

## Kütüphaneleri yükle

```sh
dotnet restore
```

Aşağıdaki kütüphaneleri yüklemelisiniz: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol 

## Çalıştır

```sh 
dotnet run
```

Şu şekilde bir çıktı görmelisiniz:

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

Çıktının çoğu hata ayıklama ile ilgili, ancak önemli olan MCP Sunucusundan araçları listelemeniz, bunları LLM araçlarına dönüştürmeniz ve sonunda "Sum 6" yanıtını veren bir MCP istemcisi elde etmeniz.

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu ortaya çıkabilecek yanlış anlamalar veya yanlış yorumlamalardan dolayı sorumluluk kabul edilmemektedir.