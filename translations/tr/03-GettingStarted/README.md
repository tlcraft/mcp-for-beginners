<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:32:24+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "tr"
}
-->
## Başlarken  

Bu bölüm birkaç dersten oluşmaktadır:

- **-1- İlk sunucunuz**, bu ilk derste, ilk sunucunuzu nasıl oluşturacağınızı ve sunucunuzu test edip hata ayıklamak için değerli bir araç olan inspector aracıyla nasıl inceleyeceğinizi öğreneceksiniz, [derse git](/03-GettingStarted/01-first-server/README.md)

- **-2- İstemci**, bu derste, sunucunuza bağlanabilen bir istemciyi nasıl yazacağınızı öğreneceksiniz, [derse git](/03-GettingStarted/02-client/README.md)

- **-3- LLM ile İstemci**, istemci yazmanın daha iyi bir yolu, sunucunuzla ne yapılacağı konusunda "müzakere" yapabilmesi için ona bir LLM eklemektir, [derse git](/03-GettingStarted/03-llm-client/README.md)

- **-4- Visual Studio Code’da bir sunucu GitHub Copilot Agent modunu kullanmak**. Burada, MCP Sunucumuzu Visual Studio Code içinden çalıştırmayı inceliyoruz, [derse git](/03-GettingStarted/04-vscode/README.md)

- **-5- SSE (Server Sent Events) ile tüketim**. SSE, sunucudan istemciye gerçek zamanlı güncellemelerin HTTP üzerinden iletilmesini sağlayan standart bir yayın akışı yöntemidir, [derse git](/03-GettingStarted/05-sse-server/README.md)

- **-6- VSCode için AI Toolkit kullanımı** MCP İstemcilerinizi ve Sunucularınızı test etmek ve kullanmak için, [derse git](/03-GettingStarted/06-aitk/README.md)

- **-7 Test**. Burada özellikle sunucu ve istemcinizi farklı şekillerde nasıl test edebileceğimize odaklanacağız, [derse git](/03-GettingStarted/07-testing/README.md)

- **-8- Dağıtım**. Bu bölüm, MCP çözümlerinizi dağıtmanın farklı yollarını ele alacak, [derse git](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP), uygulamaların LLM’lere bağlam sağlamasını standartlaştıran açık bir protokoldür. MCP’yi, AI uygulamaları için bir USB-C portu gibi düşünebilirsiniz - AI modellerini farklı veri kaynakları ve araçlara bağlamak için standart bir yol sağlar.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- C#, Java, Python, TypeScript ve JavaScript için MCP geliştirme ortamlarını kurmak
- Özel özelliklerle (kaynaklar, istemler ve araçlar) temel MCP sunucuları oluşturmak ve dağıtmak
- MCP sunucularına bağlanan ev sahibi uygulamalar oluşturmak
- MCP uygulamalarını test etmek ve hata ayıklamak
- Yaygın kurulum zorluklarını ve çözümlerini anlamak
- MCP uygulamalarınızı popüler LLM servislerine bağlamak

## MCP Ortamınızı Kurma

MCP ile çalışmaya başlamadan önce geliştirme ortamınızı hazırlamak ve temel iş akışını anlamak önemlidir. Bu bölüm, MCP ile sorunsuz bir başlangıç yapmanız için ilk kurulum adımlarında size rehberlik edecektir.

### Ön Koşullar

MCP geliştirmeye başlamadan önce şunlara sahip olmalısınız:

- **Geliştirme Ortamı**: Seçtiğiniz dil için (C#, Java, Python, TypeScript veya JavaScript)
- **IDE/Düzenleyici**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm veya herhangi modern bir kod editörü
- **Paket Yöneticileri**: NuGet, Maven/Gradle, pip veya npm/yarn
- **API Anahtarları**: Ev sahibi uygulamalarınızda kullanmayı planladığınız AI servisleri için


### Resmi SDK’lar

Gelecek bölümlerde Python, TypeScript, Java ve .NET kullanılarak oluşturulmuş çözümler göreceksiniz. İşte resmi olarak desteklenen tüm SDK’lar.

MCP, birden fazla dil için resmi SDK’lar sunar:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft iş birliğiyle sürdürülmektedir
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI iş birliğiyle sürdürülmektedir
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Resmi TypeScript uygulaması
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Resmi Python uygulaması
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Resmi Kotlin uygulaması
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI iş birliğiyle sürdürülmektedir
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Resmi Rust uygulaması

## Önemli Noktalar

- MCP geliştirme ortamı kurmak, dil bazlı SDK’lar sayesinde oldukça kolaydır
- MCP sunucuları oluşturmak, açık şemalara sahip araçlar yaratmayı ve kaydetmeyi içerir
- MCP istemcileri, genişletilmiş yeteneklerden faydalanmak için sunuculara ve modellere bağlanır
- Test ve hata ayıklama, güvenilir MCP uygulamaları için gereklidir
- Dağıtım seçenekleri yerel geliştirmeden bulut tabanlı çözümlere kadar çeşitlilik gösterir

## Uygulama

Bu bölümde göreceğiniz tüm alıştırmaları tamamlayacak örneklerimiz var. Ayrıca her bölümün kendi alıştırmaları ve ödevleri bulunmaktadır.

- [Java Hesap Makinesi](./samples/java/calculator/README.md)
- [.Net Hesap Makinesi](../../../03-GettingStarted/samples/csharp)
- [JavaScript Hesap Makinesi](./samples/javascript/README.md)
- [TypeScript Hesap Makinesi](./samples/typescript/README.md)
- [Python Hesap Makinesi](../../../03-GettingStarted/samples/python)

## Ek Kaynaklar

- [Model Context Protocol kullanarak Azure’da Ajanlar Oluşturma](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Apps ile Uzaktan MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Sonraki Adım

Sonraki: [İlk MCP Sunucunuzu Oluşturma](/03-GettingStarted/01-first-server/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba gösterilse de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucunda oluşabilecek yanlış anlamalar veya yanlış yorumlamalardan dolayı sorumluluk kabul edilmemektedir.