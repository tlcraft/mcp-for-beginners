<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:08:56+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "tr"
}
-->
## Başlarken  

Bu bölüm birkaç dersten oluşmaktadır:

- **1 İlk sunucunuz**, bu ilk derste, ilk sunucunuzu nasıl oluşturacağınızı ve sunucunuzu test edip hata ayıklamak için değerli bir araç olan inspector ile nasıl inceleyeceğinizi öğreneceksiniz, [derse git](/03-GettingStarted/01-first-server/README.md)

- **2 İstemci**, bu derste, sunucunuza bağlanabilen bir istemci yazmayı öğreneceksiniz, [derse git](/03-GettingStarted/02-client/README.md)

- **3 LLM ile İstemci**, istemci yazmanın daha iyi bir yolu, sunucunuzla ne yapacağı konusunda "müzakere" edebilmesi için bir LLM eklemektir, [derse git](/03-GettingStarted/03-llm-client/README.md)

- **4 Visual Studio Code’da GitHub Copilot Agent modunda bir sunucuyu kullanma**. Burada, MCP Sunucumuzu Visual Studio Code içinden çalıştırmayı inceliyoruz, [derse git](/03-GettingStarted/04-vscode/README.md)

- **5 SSE (Server Sent Events) ile tüketme** SSE, sunucudan istemciye gerçek zamanlı güncellemeleri HTTP üzerinden ileten standart bir yöntemdir, [derse git](/03-GettingStarted/05-sse-server/README.md)

- **6 MCP İstemcilerinizi ve Sunucularınızı test etmek ve kullanmak için AI Toolkit’i kullanma** [derse git](/03-GettingStarted/06-aitk/README.md)

- **7 Test Etme**. Burada özellikle sunucumuzu ve istemcimizi farklı şekillerde nasıl test edebileceğimize odaklanacağız, [derse git](/03-GettingStarted/07-testing/README.md)

- **8 Dağıtım**. Bu bölümde MCP çözümlerinizi dağıtmanın farklı yollarına bakacağız, [derse git](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP), uygulamaların LLM’lere bağlam sağlamasını standartlaştıran açık bir protokoldür. MCP’yi AI uygulamaları için bir USB-C portu gibi düşünebilirsiniz - AI modellerini farklı veri kaynaklarına ve araçlara bağlamanın standart bir yolunu sunar.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- C#, Java, Python, TypeScript ve JavaScript için MCP geliştirme ortamlarını kurmak
- Özel özelliklere sahip temel MCP sunucuları oluşturup dağıtmak (kaynaklar, istemler ve araçlar)
- MCP sunucularına bağlanan host uygulamalar geliştirmek
- MCP uygulamalarını test etmek ve hata ayıklamak
- Yaygın kurulum sorunlarını ve çözümlerini anlamak
- MCP uygulamalarınızı popüler LLM servislerine bağlamak

## MCP Ortamınızı Kurma

MCP ile çalışmaya başlamadan önce geliştirme ortamınızı hazırlamanız ve temel iş akışını anlamanız önemlidir. Bu bölüm, MCP ile sorunsuz bir başlangıç için ilk kurulum adımlarında size rehberlik edecek.

### Gereksinimler

MCP geliştirmeye başlamadan önce şunlara sahip olduğunuzdan emin olun:

- **Geliştirme Ortamı**: Seçtiğiniz dil için (C#, Java, Python, TypeScript veya JavaScript)
- **IDE/Düzenleyici**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm veya herhangi modern bir kod editörü
- **Paket Yöneticileri**: NuGet, Maven/Gradle, pip veya npm/yarn
- **API Anahtarları**: Host uygulamalarınızda kullanmayı planladığınız AI servisleri için


### Resmi SDK’lar

Gelecek bölümlerde Python, TypeScript, Java ve .NET kullanılarak oluşturulmuş çözümleri göreceksiniz. İşte resmi olarak desteklenen tüm SDK’lar.

MCP, birden fazla dil için resmi SDK’lar sağlar:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft ile işbirliği içinde geliştirilmektedir
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI ile işbirliği içinde geliştirilmektedir
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Resmi TypeScript uygulaması
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Resmi Python uygulaması
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Resmi Kotlin uygulaması
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI ile işbirliği içinde geliştirilmektedir
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Resmi Rust uygulaması

## Önemli Noktalar

- MCP geliştirme ortamını kurmak, dil bazlı SDK’larla oldukça kolaydır
- MCP sunucuları oluşturmak, açık şemalara sahip araçlar yaratmak ve kaydetmek anlamına gelir
- MCP istemcileri, genişletilmiş özelliklerden yararlanmak için sunuculara ve modellere bağlanır
- Test ve hata ayıklama, güvenilir MCP uygulamaları için kritik öneme sahiptir
- Dağıtım seçenekleri yerel geliştirmeden bulut tabanlı çözümlere kadar uzanır

## Uygulama

Bu bölümde göreceğiniz tüm alıştırmaları tamamlayan bir dizi örnek bulunmaktadır. Ayrıca her bölümün kendi alıştırmaları ve görevleri de vardır.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Ek Kaynaklar

- [Model Context Protocol kullanarak Azure’da Ajanlar Oluşturma](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Apps ile Uzaktan MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Sonraki Adım

Sonraki: [İlk MCP Sunucunuzu Oluşturmak](/03-GettingStarted/01-first-server/README.md)

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba gösterilse de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu ortaya çıkabilecek yanlış anlamalar veya yanlış yorumlamalardan dolayı sorumluluk kabul edilmemektedir.