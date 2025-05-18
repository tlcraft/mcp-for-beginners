<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:09:31+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "tr"
}
-->
## Başlarken

Bu bölüm birkaç dersten oluşmaktadır:

- **-1- İlk sunucunuz**, bu ilk derste, ilk sunucunuzu nasıl oluşturacağınızı ve sunucunuzu test etmek ve hata ayıklamak için değerli bir yol olan denetleyici aracı ile nasıl inceleyeceğinizi öğreneceksiniz, [derse git](/03-GettingStarted/01-first-server/README.md)

- **-2- İstemci**, bu derste, sunucunuza bağlanabilen bir istemci yazmayı öğreneceksiniz, [derse git](/03-GettingStarted/02-client/README.md)

- **-3- LLM ile İstemci**, bir istemci yazmanın daha iyi bir yolu, ona bir LLM ekleyerek sunucunuzla ne yapılacağı konusunda "müzakere" etmesini sağlamaktır, [derse git](/03-GettingStarted/03-llm-client/README.md)

- **-4- Visual Studio Code'da GitHub Copilot Agent modunda bir sunucu kullanma**. Burada, MCP Sunucumuzu Visual Studio Code içinde çalıştırmayı inceliyoruz, [derse git](/03-GettingStarted/04-vscode/README.md)

- **-5- SSE (Sunucu Tarafından Gönderilen Olaylar) ile Tüketim** SSE, sunucuların HTTP üzerinden istemcilere gerçek zamanlı güncellemeler göndermesine olanak tanıyan sunucudan istemciye akış için bir standarttır [derse git](/03-GettingStarted/05-sse-server/README.md)

- **-6- VSCode için AI Araç Setini Kullanma** MCP İstemcilerinizi ve Sunucularınızı tüketmek ve test etmek için [derse git](/03-GettingStarted/06-aitk/README.md)

- **-7 Test Etme**. Burada, sunucumuzu ve istemcimizi farklı şekillerde nasıl test edebileceğimize özellikle odaklanacağız, [derse git](/03-GettingStarted/07-testing/README.md)

- **-8- Dağıtım**. Bu bölüm, MCP çözümlerinizi dağıtmanın farklı yollarını inceleyecektir, [derse git](/03-GettingStarted/08-deployment/README.md)

Model Bağlam Protokolü (MCP), uygulamaların LLM'lere nasıl bağlam sağladığını standartlaştıran açık bir protokoldür. MCP'yi AI uygulamaları için bir USB-C portu gibi düşünün - AI modellerini farklı veri kaynaklarına ve araçlara bağlamak için standart bir yol sağlar.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- MCP için C#, Java, Python, TypeScript ve JavaScript'te geliştirme ortamları kurmak
- Özel özelliklere sahip (kaynaklar, istemler ve araçlar) temel MCP sunucuları oluşturmak ve dağıtmak
- MCP sunucularına bağlanan ana bilgisayar uygulamaları oluşturmak
- MCP uygulamalarını test etmek ve hata ayıklamak
- Yaygın kurulum zorluklarını ve çözümlerini anlamak
- MCP uygulamalarınızı popüler LLM hizmetlerine bağlamak

## MCP Ortamınızı Ayarlama

MCP ile çalışmaya başlamadan önce, geliştirme ortamınızı hazırlamanız ve temel iş akışını anlamanız önemlidir. Bu bölüm, MCP ile sorunsuz bir başlangıç için ilk kurulum adımlarında size rehberlik edecektir.

### Gereksinimler

MCP geliştirmesine dalmadan önce, şunlara sahip olduğunuzdan emin olun:

- **Geliştirme Ortamı**: Seçtiğiniz dil için (C#, Java, Python, TypeScript veya JavaScript)
- **IDE/Düzenleyici**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm veya herhangi bir modern kod düzenleyici
- **Paket Yöneticileri**: NuGet, Maven/Gradle, pip veya npm/yarn
- **API Anahtarları**: Ana bilgisayar uygulamalarınızda kullanmayı planladığınız AI hizmetleri için

### Resmi SDK'lar

Gelecek bölümlerde Python, TypeScript, Java ve .NET kullanılarak oluşturulmuş çözümler göreceksiniz. İşte resmi olarak desteklenen tüm SDK'lar.

MCP, birden fazla dil için resmi SDK'lar sağlar:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft ile işbirliği içinde sürdürülmektedir
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI ile işbirliği içinde sürdürülmektedir
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Resmi TypeScript uygulaması
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Resmi Python uygulaması
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Resmi Kotlin uygulaması
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI ile işbirliği içinde sürdürülmektedir
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Resmi Rust uygulaması

## Temel Çıkarımlar

- MCP geliştirme ortamı kurmak, dile özgü SDK'larla kolaydır
- MCP sunucuları oluşturmak, net şemalarla araçlar oluşturmayı ve kaydetmeyi içerir
- MCP istemcileri, genişletilmiş yeteneklerden yararlanmak için sunuculara ve modellere bağlanır
- Güvenilir MCP uygulamaları için test ve hata ayıklama esastır
- Dağıtım seçenekleri yerel geliştirmeden bulut tabanlı çözümlere kadar uzanır

## Uygulama

Bu bölümdeki tüm bölümlerde göreceğiniz alıştırmaları tamamlayan bir dizi örneğimiz var. Ek olarak, her bölümün kendi alıştırmaları ve ödevleri de bulunmaktadır.

- [Java Hesap Makinesi](./samples/java/calculator/README.md)
- [.Net Hesap Makinesi](../../../03-GettingStarted/samples/csharp)
- [JavaScript Hesap Makinesi](./samples/javascript/README.md)
- [TypeScript Hesap Makinesi](./samples/typescript/README.md)
- [Python Hesap Makinesi](../../../03-GettingStarted/samples/python)

## Ek Kaynaklar

- [MCP GitHub Deposu](https://github.com/microsoft/mcp-for-beginners)

## Sıradaki Ne?

Sonraki: [İlk MCP Sunucunuzu Oluşturma](/03-GettingStarted/01-first-server/README.md)

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluğu sağlamak için çaba göstersek de, otomatik çevirilerin hata veya yanlışlık içerebileceğini lütfen unutmayın. Belgenin orijinal dili, yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından doğabilecek yanlış anlama veya yanlış yorumlamalardan sorumlu değiliz.