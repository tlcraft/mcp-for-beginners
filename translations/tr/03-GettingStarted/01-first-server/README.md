<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d5b044c0924d393af3066e03d7d89c5",
  "translation_date": "2025-07-16T09:43:51+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "tr"
}
-->
### -2- Proje oluşturma

SDK'nızı kurduğunuza göre, şimdi bir proje oluşturalım:

### -3- Proje dosyalarını oluşturma

### -4- Sunucu kodunu oluşturma

### -5- Bir araç ve kaynak ekleme

Aşağıdaki kodu ekleyerek bir araç ve kaynak ekleyin:

### -6- Son kod

Sunucunun başlatılabilmesi için gereken son kodu ekleyelim:

### -7- Sunucuyu test etme

Sunucuyu aşağıdaki komutla başlatın:

### -8- Inspector kullanarak çalıştırma

Inspector, sunucunuzu başlatan ve onunla etkileşim kurmanızı sağlayan harika bir araçtır, böylece çalışıp çalışmadığını test edebilirsiniz. Hadi başlatalım:
> [!NOTE]
> "command" alanında farklı görünebilir çünkü burada kendi çalışma zamanınızla bir sunucu çalıştırmak için komut yer alır/
Aşağıdaki kullanıcı arayüzünü görmelisiniz:

![Connect](/03-GettingStarted/01-first-server/assets/connect.png)

1. Connect butonunu seçerek sunucuya bağlanın  
  Sunucuya bağlandıktan sonra aşağıdakini görmelisiniz:

  ![Connected](/03-GettingStarted/01-first-server/assets/connected.png)

1. "Tools" ve ardından "listTools" seçeneğini seçin, "Add" görünmelidir, "Add" seçeneğini seçin ve parametre değerlerini doldurun.

  Aşağıdaki yanıtı görmelisiniz, yani "add" aracından bir sonuç:

  ![Result of running add](/03-GettingStarted/01-first-server/assets/ran-tool.png)

Tebrikler, ilk sunucunuzu oluşturup çalıştırmayı başardınız!

### Resmi SDK'lar

MCP, birden fazla dil için resmi SDK'lar sağlar:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft ile iş birliği içinde sürdürülmektedir
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI ile iş birliği içinde sürdürülmektedir
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Resmi TypeScript uygulaması
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Resmi Python uygulaması
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Resmi Kotlin uygulaması
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI ile iş birliği içinde sürdürülmektedir
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Resmi Rust uygulaması

## Önemli Noktalar

- MCP geliştirme ortamı, dil bazlı SDK'lar ile kurulumu kolaydır
- MCP sunucuları, net şemalara sahip araçlar oluşturup kaydetmeyi içerir
- Test ve hata ayıklama, güvenilir MCP uygulamaları için gereklidir

## Örnekler

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Ödev

Seçtiğiniz bir araçla basit bir MCP sunucusu oluşturun:

1. Aracı tercih ettiğiniz dilde (.NET, Java, Python veya JavaScript) uygulayın.
2. Girdi parametrelerini ve dönüş değerlerini tanımlayın.
3. Sunucunun doğru çalıştığından emin olmak için inspector aracını çalıştırın.
4. Farklı girdilerle uygulamayı test edin.

## Çözüm

[Solution](./solution/README.md)

## Ek Kaynaklar

- [Azure üzerinde Model Context Protocol kullanarak Ajanlar oluşturma](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Apps ile Uzaktan MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Sonraki Adım

Sonraki: [MCP İstemcileri ile Başlarken](../02-client/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu ortaya çıkabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.