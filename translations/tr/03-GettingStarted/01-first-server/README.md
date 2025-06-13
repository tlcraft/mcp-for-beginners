<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bf05718d019040cf0c7d4ccc6d6a1a88",
  "translation_date": "2025-06-13T05:59:47+00:00",
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

Sunucunun başlayabilmesi için gereken son kodu ekleyelim:

### -7- Sunucuyu test etme

Aşağıdaki komutla sunucuyu başlatın:

### -8- Inspector ile çalıştırma

Inspector, sunucunuzu başlatmanızı sağlayan ve onunla etkileşim kurarak çalıştığını test etmenize olanak veren harika bir araçtır. Haydi başlatalım:

> [!NOTE]
> "command" alanında, sunucuyu belirli çalışma zamanınızla çalıştırmak için gereken komutu içerdiğinden farklı görünebilir.

Aşağıdaki kullanıcı arayüzünü görmelisiniz:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.tr.png)

1. Connect butonunu seçerek sunucuya bağlanın  
   Sunucuya bağlandıktan sonra aşağıdaki ekranı görmelisiniz:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.tr.png)

2. "Tools" ve ardından "listTools" seçin, "Add" seçeneği görünecektir, "Add"ı seçin ve parametre değerlerini doldurun.

   Aşağıdaki yanıtı görmelisiniz, yani "add" aracından bir sonuç:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.tr.png)

Tebrikler, ilk sunucunuzu oluşturup çalıştırmayı başardınız!

### Resmi SDK'lar

MCP, birçok dil için resmi SDK'lar sağlar:  
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft ile iş birliği içinde geliştirilmektedir  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI ile iş birliği içinde geliştirilmektedir  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Resmi TypeScript uygulaması  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Resmi Python uygulaması  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Resmi Kotlin uygulaması  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI ile iş birliği içinde geliştirilmektedir  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Resmi Rust uygulaması  

## Önemli Noktalar

- MCP geliştirme ortamı, dil bazlı SDK'lar sayesinde kolayca kurulabilir  
- MCP sunucuları, açık şemalara sahip araçlar oluşturup kaydetmekten oluşur  
- Test ve hata ayıklama, güvenilir MCP uygulamaları için çok önemlidir  

## Örnekler

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## Ödev

Seçtiğiniz bir araçla basit bir MCP sunucusu oluşturun:  
1. Tercih ettiğiniz dilde (.NET, Java, Python veya JavaScript) aracı uygulayın.  
2. Girdi parametrelerini ve dönüş değerlerini tanımlayın.  
3. Sunucunun beklendiği gibi çalıştığını doğrulamak için inspector aracını çalıştırın.  
4. Farklı girdilerle uygulamayı test edin.  

## Çözüm

[Çözüm](./solution/README.md)

## Ek Kaynaklar

- [Azure'da Model Context Protocol kullanarak Ajanlar oluşturma](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [Azure Container Apps ile Uzak MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## Sonraki Adım

Sonraki: [MCP İstemcileri ile Başlarken](/03-GettingStarted/02-client/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yanlış yorumlamalardan sorumlu değiliz.