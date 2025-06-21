<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "671162f2687253f22af11187919ed02d",
  "translation_date": "2025-06-21T13:51:09+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "tr"
}
-->
# MCP Uygulamada: Gerçek Dünya Vaka Çalışmaları

Model Context Protocol (MCP), yapay zeka uygulamalarının veri, araçlar ve servislerle etkileşim şeklini dönüştürüyor. Bu bölüm, MCP'nin çeşitli kurumsal senaryolardaki pratik uygulamalarını gösteren gerçek dünya vaka çalışmalarını sunmaktadır.

## Genel Bakış

Bu bölüm, MCP uygulamalarına dair somut örnekler sunarak, organizasyonların bu protokolü karmaşık iş sorunlarını çözmek için nasıl kullandığını vurgular. Bu vaka çalışmalarını inceleyerek, MCP'nin gerçek dünya senaryolarındaki çok yönlülüğü, ölçeklenebilirliği ve pratik faydaları hakkında bilgi edineceksiniz.

## Temel Öğrenme Hedefleri

Bu vaka çalışmalarını inceleyerek:

- MCP'nin belirli iş problemlerini çözmek için nasıl uygulanabileceğini anlayacaksınız
- Farklı entegrasyon desenleri ve mimari yaklaşımlar hakkında bilgi sahibi olacaksınız
- Kurumsal ortamlarda MCP uygulamak için en iyi uygulamaları tanıyacaksınız
- Gerçek dünya uygulamalarında karşılaşılan zorluklar ve çözümler hakkında fikir edineceksiniz
- Kendi projelerinizde benzer desenleri uygulama fırsatlarını belirleyeceksiniz

## Öne Çıkan Vaka Çalışmaları

### 1. [Azure AI Seyahat Acenteleri – Referans Uygulama](./travelagentsample.md)

Bu vaka çalışması, Microsoft’un MCP, Azure OpenAI ve Azure AI Search kullanarak çok ajanlı, yapay zeka destekli seyahat planlama uygulaması geliştirmeyi gösteren kapsamlı referans çözümünü inceliyor. Proje şu konuları gösteriyor:

- MCP üzerinden çok ajanlı orkestrasyon
- Azure AI Search ile kurumsal veri entegrasyonu
- Azure servisleri kullanılarak güvenli ve ölçeklenebilir mimari
- Yeniden kullanılabilir MCP bileşenleriyle genişletilebilir araçlar
- Azure OpenAI destekli sohbet tabanlı kullanıcı deneyimi

Mimari ve uygulama detayları, MCP’yi koordinasyon katmanı olarak kullanan karmaşık çok ajanlı sistemlerin nasıl kurulacağına dair değerli bilgiler sunuyor.

### 2. [YouTube Verilerinden Azure DevOps Öğelerini Güncelleme](./UpdateADOItemsFromYT.md)

Bu vaka çalışması, MCP’nin iş akışı süreçlerini otomatikleştirmede pratik bir uygulamasını gösteriyor. MCP araçlarının nasıl kullanılabileceğini anlatıyor:

- Çevrimiçi platformlardan (YouTube) veri çekmek
- Azure DevOps sistemlerindeki iş öğelerini güncellemek
- Tekrarlanabilir otomasyon iş akışları oluşturmak
- Farklı sistemler arasında veri entegrasyonu sağlamak

Bu örnek, nispeten basit MCP uygulamalarının bile rutin işleri otomatikleştirerek ve sistemler arası veri tutarlılığını artırarak önemli verimlilik kazançları sağlayabileceğini gösteriyor.

### 3. [MCP ile Gerçek Zamanlı Dokümantasyon Erişimi](./docs-mcp/README.md)

Bu vaka çalışması, Python konsol istemcisini bir Model Context Protocol (MCP) sunucusuna bağlayarak gerçek zamanlı, bağlam odaklı Microsoft dokümantasyonunu nasıl alıp kaydedebileceğinizi adım adım gösteriyor. Öğrenecekleriniz:

- Python istemcisi ve resmi MCP SDK kullanarak MCP sunucusuna bağlanmak
- Verimli, gerçek zamanlı veri çekmek için streaming HTTP istemcileri kullanmak
- Sunucudaki dokümantasyon araçlarını çağırmak ve yanıtları doğrudan konsola kaydetmek
- Güncel Microsoft dokümantasyonunu terminalden çıkmadan iş akışınıza entegre etmek

Bölümde uygulamalı bir görev, minimal çalışan kod örneği ve daha derin öğrenme için ek kaynak bağlantıları yer alıyor. MCP’nin dokümantasyon erişimini ve geliştirici verimliliğini konsol tabanlı ortamlarda nasıl dönüştürebileceğini anlamak için tam rehbere ve koda göz atın.

### 4. [MCP ile Etkileşimli Çalışma Planı Oluşturucu Web Uygulaması](./docs-mcp/README.md)

Bu vaka çalışması, Chainlit ve Model Context Protocol (MCP) kullanarak herhangi bir konu için kişiselleştirilmiş çalışma planları oluşturan etkileşimli bir web uygulaması yapmayı gösteriyor. Kullanıcılar bir konu (örneğin "AI-900 sertifikası") ve çalışma süresi (örneğin 8 hafta) belirtebiliyor, uygulama haftalık önerilen içerik listesini sunuyor. Chainlit, sohbet tabanlı etkileşim arayüzü sağlayarak deneyimi ilgi çekici ve uyarlanabilir kılıyor.

- Chainlit destekli sohbet tabanlı web uygulaması
- Konu ve süre için kullanıcı odaklı yönlendirmeler
- MCP kullanarak haftalık içerik önerileri
- Sohbet arayüzünde gerçek zamanlı, uyarlanabilir yanıtlar

Proje, sohbet tabanlı yapay zeka ve MCP’nin modern web ortamında dinamik, kullanıcı odaklı eğitim araçları oluşturmak için nasıl bir araya getirilebileceğini gösteriyor.

### 5. [VS Code’da MCP Sunucusu ile Editör İçi Dokümantasyon](./docs-mcp/README.md)

Bu vaka çalışması, Microsoft Learn Dokümanlarını doğrudan VS Code ortamınıza MCP sunucusu aracılığıyla nasıl getirebileceğinizi gösteriyor—tarayıcı sekmeleri arasında geçiş yapmaya son! Şunları göreceksiniz:

- MCP paneli veya komut paleti ile VS Code içinde anında doküman arama ve okuma
- Dokümantasyon referansları ve bağlantılarını README veya kurs markdown dosyalarına doğrudan ekleme
- GitHub Copilot ve MCP’yi birlikte kullanarak kesintisiz, yapay zeka destekli dokümantasyon ve kod iş akışları oluşturma
- Gerçek zamanlı geri bildirim ve Microsoft kaynaklı doğruluk ile dokümantasyonunuzu doğrulama ve geliştirme
- Sürekli dokümantasyon doğrulaması için MCP’yi GitHub iş akışlarına entegre etme

Uygulama şunları içeriyor:
- Kolay kurulum için örnek `.vscode/mcp.json` yapılandırması
- Editör içi deneyimin ekran görüntüleriyle adım adım anlatımı
- Maksimum verimlilik için Copilot ve MCP’yi bir arada kullanma ipuçları

Bu senaryo, dokümanlar, Copilot ve doğrulama araçlarıyla çalışırken editöründe odaklanmak isteyen kurs yazarları, dokümantasyon yazarları ve geliştiriciler için idealdir.

## Sonuç

Bu vaka çalışmaları, Model Context Protocol’ün gerçek dünya senaryolarındaki çok yönlülüğünü ve pratik uygulamalarını vurgulamaktadır. Karmaşık çok ajanlı sistemlerden hedefe yönelik otomasyon iş akışlarına kadar, MCP, yapay zeka sistemlerini ihtiyaç duydukları araçlar ve verilerle bağlamak için standart bir yol sunar.

Bu uygulamaları inceleyerek, kendi MCP projelerinizde kullanabileceğiniz mimari desenler, uygulama stratejileri ve en iyi uygulamalar hakkında bilgi edinebilirsiniz. Örnekler, MCP’nin sadece teorik bir çerçeve olmadığını, gerçek iş sorunlarına pratik bir çözüm sunduğunu göstermektedir.

## Ek Kaynaklar

- [Azure AI Seyahat Acenteleri GitHub Deposu](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Aracı](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Aracı](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Sunucusu](https://github.com/MicrosoftDocs/mcp)
- [MCP Topluluk Örnekleri](https://github.com/microsoft/mcp)

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı nedeniyle oluşabilecek yanlış anlamalar veya yorum farklılıklarından sorumlu değiliz.