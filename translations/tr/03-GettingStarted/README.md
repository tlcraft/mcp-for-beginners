<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-12T23:45:39+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "tr"
}
-->
## Başlarken  

Bu bölüm birkaç dersten oluşmaktadır:

- **1 İlk sunucunuz**, bu ilk derste, ilk sunucunuzu nasıl oluşturacağınızı ve sunucunuzu test edip hata ayıklamak için değerli bir araç olan inspector ile nasıl inceleyeceğinizi öğreneceksiniz, [derse git](/03-GettingStarted/01-first-server/README.md)

- **2 İstemci**, bu derste, sunucunuza bağlanabilen bir istemci yazmayı öğreneceksiniz, [derse git](/03-GettingStarted/02-client/README.md)

- **3 LLM ile İstemci**, istemci yazmanın daha iyi bir yolu, ona bir LLM ekleyerek sunucunuzla ne yapılacağı konusunda "müzakere" yapabilmesini sağlamaktır, [derse git](/03-GettingStarted/03-llm-client/README.md)

- **4 Visual Studio Code’da bir sunucu GitHub Copilot Agent modunu kullanmak**. Burada, MCP Sunucumuzu Visual Studio Code içinde çalıştırmayı inceliyoruz, [derse git](/03-GettingStarted/04-vscode/README.md)

- **5 SSE (Server Sent Events) kullanarak tüketme** SSE, sunucudan istemciye gerçek zamanlı güncellemeler göndermeyi sağlayan standart bir yöntemdir, [derse git](/03-GettingStarted/05-sse-server/README.md)

- **6 MCP ile HTTP Akışı (Streamable HTTP)**. Modern HTTP akışı, ilerleme bildirimleri ve Streamable HTTP kullanarak ölçeklenebilir, gerçek zamanlı MCP sunucuları ve istemciler nasıl oluşturulur öğrenin. [derse git](/03-GettingStarted/06-http-streaming/README.md)

- **7 VSCode için AI Toolkit kullanımı** MCP İstemcilerinizi ve Sunucularınızı tüketmek ve test etmek için [derse git](/03-GettingStarted/07-aitk/README.md)

- **8 Test Etme**. Burada özellikle sunucu ve istemcimizi farklı şekillerde nasıl test edebileceğimize odaklanacağız, [derse git](/03-GettingStarted/08-testing/README.md)

- **9 Dağıtım**. Bu bölümde MCP çözümlerinizi dağıtmanın farklı yollarına bakacağız, [derse git](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP), uygulamaların LLM’lere bağlam sağlamasını standartlaştıran açık bir protokoldür. MCP’yi AI uygulamaları için bir USB-C portu gibi düşünebilirsiniz – AI modellerini farklı veri kaynakları ve araçlara bağlamak için standart bir yol sağlar.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- C#, Java, Python, TypeScript ve JavaScript için MCP geliştirme ortamları kurmak
- Özelleştirilmiş özelliklere (kaynaklar, istemler ve araçlar) sahip temel MCP sunucuları oluşturmak ve dağıtmak
- MCP sunucularına bağlanan ana uygulamalar oluşturmak
- MCP uygulamalarını test etmek ve hata ayıklamak
- Yaygın kurulum zorluklarını ve çözümlerini anlamak
- MCP uygulamalarınızı popüler LLM servislerine bağlamak

## MCP Ortamınızı Kurma

MCP ile çalışmaya başlamadan önce, geliştirme ortamınızı hazırlamak ve temel iş akışını anlamak önemlidir. Bu bölüm, MCP ile sorunsuz bir başlangıç için ilk kurulum adımlarında size rehberlik edecektir.

### Ön Koşullar

MCP geliştirmeye başlamadan önce şunlara sahip olmalısınız:

- **Geliştirme Ortamı**: Seçtiğiniz dil için (C#, Java, Python, TypeScript veya JavaScript)
- **IDE/Düzenleyici**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm veya herhangi modern bir kod düzenleyici
- **Paket Yöneticileri**: NuGet, Maven/Gradle, pip veya npm/yarn
- **API Anahtarları**: Ana uygulamalarınızda kullanmayı planladığınız AI servisleri için


### Resmi SDK’lar

Gelecek bölümlerde Python, TypeScript, Java ve .NET kullanılarak oluşturulmuş çözümleri göreceksiniz. İşte resmi olarak desteklenen tüm SDK’lar.

MCP, birden çok dil için resmi SDK’lar sağlar:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft iş birliğiyle geliştirilmektedir
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI iş birliğiyle geliştirilmektedir
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Resmi TypeScript uygulaması
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Resmi Python uygulaması
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Resmi Kotlin uygulaması
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI iş birliğiyle geliştirilmektedir
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Resmi Rust uygulaması

## Önemli Noktalar

- MCP geliştirme ortamı kurmak, dil özel SDK’larıyla kolaydır
- MCP sunucuları, açık şemalara sahip araçlar oluşturup kaydetmeyi içerir
- MCP istemcileri, genişletilmiş özelliklerden faydalanmak için sunuculara ve modellere bağlanır
- Test ve hata ayıklama, güvenilir MCP uygulamaları için şarttır
- Dağıtım seçenekleri yerel geliştirmeden bulut tabanlı çözümlere kadar çeşitlidir

## Uygulama

Bu bölümde göreceğiniz tüm bölümlerdeki alıştırmaları tamamlayan bir örnek setimiz var. Ayrıca her bölümün kendi alıştırmaları ve ödevleri de bulunmaktadır.

- [Java Hesap Makinesi](./samples/java/calculator/README.md)
- [.Net Hesap Makinesi](../../../03-GettingStarted/samples/csharp)
- [JavaScript Hesap Makinesi](./samples/javascript/README.md)
- [TypeScript Hesap Makinesi](./samples/typescript/README.md)
- [Python Hesap Makinesi](../../../03-GettingStarted/samples/python)

## Ek Kaynaklar

- [Model Context Protocol kullanarak Azure’da Ajanlar Oluşturma](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Apps ile Uzaktan MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Ajanı](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Sonraki Adım

Sonraki: [İlk MCP Sunucunuzu Oluşturma](/03-GettingStarted/01-first-server/README.md)

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı nedeniyle ortaya çıkabilecek yanlış anlamalar veya yanlış yorumlamalardan sorumlu değiliz.