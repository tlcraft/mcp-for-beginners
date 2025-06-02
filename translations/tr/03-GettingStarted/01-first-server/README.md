<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e650db55873b456296a9c620069e2f71",
  "translation_date": "2025-06-02T11:09:19+00:00",
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

Sunucuyu aşağıdaki komutla başlatın:

### -8- Inspector kullanarak çalıştırma

Inspector, sunucunuzu başlatıp onunla etkileşime girmenizi sağlayan harika bir araçtır, böylece çalıştığını test edebilirsiniz. Haydi başlatalım:

> [!NOTE]
> "command" alanı, sunucunuzu belirli çalışma zamanınızla çalıştırmak için kullanılan komutu içerdiğinden farklı görünebilir.

Aşağıdaki kullanıcı arayüzünü görmelisiniz:

![Bağlan](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.tr.png)

1. Bağlan düğmesini seçerek sunucuya bağlanın  
   Sunucuya bağlandıktan sonra aşağıdakini görmelisiniz:

   ![Bağlandı](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.tr.png)

2. "Tools" ve "listTools" seçeneklerini seçin, "Add" seçeneği görünecektir, "Add"i seçin ve parametre değerlerini doldurun.

   Aşağıdaki yanıtı göreceksiniz, yani "add" aracından bir sonuç:

   ![Add aracının çalıştırılma sonucu](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.tr.png)

Tebrikler, ilk sunucunuzu oluşturup çalıştırmayı başardınız!

### Resmi SDK'lar

MCP, birden fazla dil için resmi SDK'lar sunar:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft ile işbirliği içinde bakımda
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI ile işbirliği içinde bakımda
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Resmi TypeScript uygulaması
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Resmi Python uygulaması
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Resmi Kotlin uygulaması
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI ile işbirliği içinde bakımda
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Resmi Rust uygulaması

## Önemli Noktalar

- MCP geliştirme ortamı, dil bazlı SDK’lar sayesinde kurulumu kolaydır
- MCP sunucuları, net şemalarla araçlar oluşturup kaydetmeyi içerir
- Test ve hata ayıklama, güvenilir MCP uygulamaları için gereklidir

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
3. Inspector aracını çalıştırarak sunucunun doğru çalıştığından emin olun.  
4. Farklı girdilerle uygulamayı test edin.

## Çözüm

[Çözüm](./solution/README.md)

## Ek Kaynaklar

- [MCP GitHub Deposu](https://github.com/microsoft/mcp-for-beginners)

## Sonraki Adım

Sonraki: [MCP İstemcileri ile Başlarken](/03-GettingStarted/02-client/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba gösterilse de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi ana dilindeki haliyle yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu ortaya çıkabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.