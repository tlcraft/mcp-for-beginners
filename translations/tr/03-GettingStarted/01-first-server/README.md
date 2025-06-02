<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "37563349cd6894fe00489bf3b4d488ae",
  "translation_date": "2025-06-02T10:34:23+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "tr"
}
-->
### -2- Proje Oluşturma

SDK'nızı kurduğunuza göre, şimdi bir proje oluşturalım:

### -3- Proje Dosyalarını Oluşturma

### -4- Sunucu Kodunu Yazma

### -5- Bir Araç ve Kaynak Ekleme

Aşağıdaki kodu ekleyerek bir araç ve kaynak ekleyin:

### -6- Son Kod

Sunucunun başlayabilmesi için gereken son kodu ekleyelim:

### -7- Sunucuyu Test Etme

Aşağıdaki komutla sunucuyu başlatın:

### -8- Inspector ile Çalıştırma

Inspector, sunucunuzu başlatıp onunla etkileşim kurmanızı sağlayan harika bir araçtır; böylece çalıştığını test edebilirsiniz. Hadi başlatalım:

> [!NOTE]
> Komut alanında, kullandığınız çalışma zamanına göre farklı görünebilir.

Aşağıdaki kullanıcı arayüzünü görmelisiniz:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.tr.png)

1. Bağlan düğmesini seçerek sunucuya bağlanın  
   Sunucuya bağlandıktan sonra aşağıdakini görmelisiniz:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.tr.png)

2. "Tools" ve "listTools" seçeneklerini seçin, "Add" görünmelidir, "Add" seçeneğini seçip parametre değerlerini doldurun.

   Aşağıdaki yanıtı görmelisiniz, yani "add" aracından bir sonuç:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.tr.png)

Tebrikler, ilk sunucunuzu oluşturup çalıştırmayı başardınız!

### Resmi SDK'lar

MCP, birden fazla dil için resmi SDK'lar sağlar:  
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft iş birliğiyle sürdürülmektedir  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI iş birliğiyle sürdürülmektedir  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Resmi TypeScript uygulaması  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Resmi Python uygulaması  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Resmi Kotlin uygulaması  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI iş birliğiyle sürdürülmektedir  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Resmi Rust uygulaması  

## Önemli Noktalar

- MCP geliştirme ortamı, dil bazlı SDK'larla kolayca kurulur  
- MCP sunucuları, açık şemalara sahip araçlar oluşturup kaydetmeyi içerir  
- Test ve hata ayıklama, güvenilir MCP uygulamaları için şarttır  

## Örnekler

- [Java Calculator](../samples/java/calculator/README.md)  
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)  
- [JavaScript Calculator](../samples/javascript/README.md)  
- [TypeScript Calculator](../samples/typescript/README.md)  
- [Python Calculator](../../../../03-GettingStarted/samples/python)  

## Ödev

Seçtiğiniz bir araçla basit bir MCP sunucusu oluşturun:  
1. Tercih ettiğiniz dilde (.NET, Java, Python veya JavaScript) aracı uygulayın.  
2. Girdi parametreleri ve dönüş değerlerini tanımlayın.  
3. Sunucunun düzgün çalıştığını doğrulamak için inspector aracını çalıştırın.  
4. Uygulamayı çeşitli girdilerle test edin.  

## Çözüm

[Çözüm](./solution/README.md)

## Ek Kaynaklar

- [MCP GitHub Deposu](https://github.com/microsoft/mcp-for-beginners)

## Sonraki Adım

Sonraki: [MCP İstemcileri ile Başlamak](/03-GettingStarted/02-client/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba sarf etsek de, otomatik çevirilerin hata veya yanlışlık içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu ortaya çıkabilecek herhangi bir yanlış anlama veya yorum hatasından sorumlu değiliz.