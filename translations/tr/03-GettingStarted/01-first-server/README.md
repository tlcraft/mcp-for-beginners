<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "262e6e510f0c3fe1e36180eadcd67c33",
  "translation_date": "2025-06-02T17:32:59+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "tr"
}
-->
### -2- Proje oluştur

SDK'nızı yüklediğinize göre, şimdi bir proje oluşturalım:

### -3- Proje dosyalarını oluştur

### -4- Sunucu kodunu oluştur

### -5- Bir araç ve kaynak ekleme

Aşağıdaki kodu ekleyerek bir araç ve kaynak ekleyin:

### -6 Son kod

Sunucunun başlayabilmesi için gereken son kodu ekleyelim:

### -7- Sunucuyu test et

Aşağıdaki komutla sunucuyu başlatın:

### -8- Inspector kullanarak çalıştırma

Inspector, sunucunuzu başlatıp onunla etkileşim kurmanızı sağlayan harika bir araçtır; böylece çalıştığını test edebilirsiniz. Hadi başlatalım:

> [!NOTE]
> "command" alanında, sunucuyu belirli runtime'ınızla çalıştırmak için gereken komut olduğu için farklı görünebilir

Aşağıdaki kullanıcı arayüzünü görmelisiniz:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.tr.png)

1. Bağlan butonunu seçerek sunucuya bağlanın  
   Sunucuya bağlandıktan sonra aşağıdakini görmelisiniz:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.tr.png)

2. "Tools" ve "listTools" seçeneklerini seçin, "Add" görünecektir, "Add" seçeneğini seçin ve parametre değerlerini doldurun.

   Aşağıdaki yanıtı görmelisiniz, yani "add" aracından bir sonuç:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.tr.png)

Tebrikler, ilk sunucunuzu oluşturup çalıştırmayı başardınız!

### Resmi SDK'lar

MCP, birçok dil için resmi SDK'lar sağlar:  
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft iş birliği ile sürdürülmektedir  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI iş birliği ile sürdürülmektedir  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Resmi TypeScript uygulaması  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Resmi Python uygulaması  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Resmi Kotlin uygulaması  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI iş birliği ile sürdürülmektedir  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Resmi Rust uygulaması  

## Önemli Noktalar

- MCP geliştirme ortamı, dil bazlı SDK'lar sayesinde kurulumu kolaydır  
- MCP sunucuları, açık şemalarla araçlar oluşturup kaydetmeyi içerir  
- Test ve hata ayıklama, güvenilir MCP uygulamaları için gereklidir  

## Örnekler

- [Java Hesap Makinesi](../samples/java/calculator/README.md)  
- [.Net Hesap Makinesi](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Hesap Makinesi](../samples/javascript/README.md)  
- [TypeScript Hesap Makinesi](../samples/typescript/README.md)  
- [Python Hesap Makinesi](../../../../03-GettingStarted/samples/python)  

## Ödev

Seçtiğiniz bir araçla basit bir MCP sunucusu oluşturun:  
1. Aracı tercih ettiğiniz dilde (.NET, Java, Python veya JavaScript) uygulayın.  
2. Girdi parametrelerini ve dönüş değerlerini tanımlayın.  
3. Inspector aracını çalıştırarak sunucunun beklendiği gibi çalıştığını doğrulayın.  
4. Farklı girdilerle uygulamayı test edin.  

## Çözüm

[Çözüm](./solution/README.md)

## Ek Kaynaklar

- [Azure'da Model Context Protocol kullanarak Ajanlar Oluşturma](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [Azure Container Apps ile Uzaktan MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP Ajanı](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## Sonraki Adım

Sonraki: [MCP İstemcileri ile Başlamak](/03-GettingStarted/02-client/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba gösterilse de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu ortaya çıkabilecek yanlış anlamalar veya yanlış yorumlamalardan sorumlu değiliz.