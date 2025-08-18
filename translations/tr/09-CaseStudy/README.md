<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "61a160248efabe92b09d7b08293d17db",
  "translation_date": "2025-08-18T17:42:32+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "tr"
}
-->
# MCP Eylemde: Gerçek Dünya Vaka Çalışmaları

[![MCP Eylemde: Gerçek Dünya Vaka Çalışmaları](../../../translated_images/10.3262cc80b4de5071fde8ba74c5c5d6738a0a9f398dcc0423f0210f632e2238b8.tr.png)](https://youtu.be/IxshWb2Az5w)

_(Bu dersin videosunu izlemek için yukarıdaki görsele tıklayın)_

Model Context Protocol (MCP), yapay zeka uygulamalarının veri, araçlar ve hizmetlerle etkileşim şeklini dönüştürüyor. Bu bölüm, MCP'nin çeşitli kurumsal senaryolardaki pratik uygulamalarını gösteren gerçek dünya vaka çalışmalarını sunmaktadır.

## Genel Bakış

Bu bölüm, MCP uygulamalarının somut örneklerini sergileyerek, organizasyonların bu protokolü karmaşık iş zorluklarını çözmek için nasıl kullandığını vurgulamaktadır. Bu vaka çalışmalarını inceleyerek, MCP'nin gerçek dünya senaryolarındaki çok yönlülüğü, ölçeklenebilirliği ve pratik faydaları hakkında bilgi edineceksiniz.

## Temel Öğrenme Hedefleri

Bu vaka çalışmalarını inceleyerek:

- MCP'nin belirli iş problemlerini çözmek için nasıl uygulanabileceğini anlayacaksınız
- Farklı entegrasyon modelleri ve mimari yaklaşımlar hakkında bilgi edineceksiniz
- MCP'nin kurumsal ortamlarda uygulanması için en iyi uygulamaları tanıyacaksınız
- Gerçek dünya uygulamalarında karşılaşılan zorluklar ve çözümler hakkında fikir sahibi olacaksınız
- Kendi projelerinizde benzer modelleri uygulama fırsatlarını belirleyeceksiniz

## Öne Çıkan Vaka Çalışmaları

### 1. [Azure AI Seyahat Acenteleri – Referans Uygulama](./travelagentsample.md)

Bu vaka çalışması, MCP, Azure OpenAI ve Azure AI Search kullanarak çoklu ajanlı, yapay zeka destekli bir seyahat planlama uygulaması oluşturmayı gösteren Microsoft'un kapsamlı referans çözümünü incelemektedir. Proje şunları sergiler:

- MCP aracılığıyla çoklu ajan koordinasyonu
- Azure AI Search ile kurumsal veri entegrasyonu
- Azure hizmetlerini kullanarak güvenli, ölçeklenebilir mimari
- Yeniden kullanılabilir MCP bileşenleri ile genişletilebilir araçlar
- Azure OpenAI tarafından desteklenen konuşma tabanlı kullanıcı deneyimi

Mimari ve uygulama detayları, MCP'yi koordinasyon katmanı olarak kullanarak karmaşık, çoklu ajan sistemleri oluşturma konusunda değerli bilgiler sunar.

### 2. [YouTube Verilerinden Azure DevOps Öğelerini Güncelleme](./UpdateADOItemsFromYT.md)

Bu vaka çalışması, MCP'nin iş akışı süreçlerini otomatikleştirmek için pratik bir uygulamasını göstermektedir. MCP araçlarının nasıl kullanılabileceğini gösterir:

- Çevrimiçi platformlardan (YouTube) veri çıkarma
- Azure DevOps sistemlerinde iş öğelerini güncelleme
- Tekrarlanabilir otomasyon iş akışları oluşturma
- Farklı sistemler arasında veri entegrasyonu

Bu örnek, nispeten basit MCP uygulamalarının bile rutin görevleri otomatikleştirerek ve sistemler arasında veri tutarlılığını artırarak önemli verimlilik kazançları sağlayabileceğini göstermektedir.

### 3. [MCP ile Gerçek Zamanlı Dokümantasyon Erişimi](./docs-mcp/README.md)

Bu vaka çalışması, bir Python konsol istemcisini bir Model Context Protocol (MCP) sunucusuna bağlayarak gerçek zamanlı, bağlama duyarlı Microsoft dokümantasyonunu almayı ve kaydetmeyi gösterir. Şunları öğreneceksiniz:

- Resmi MCP SDK kullanarak bir MCP sunucusuna bağlanma
- Verimli, gerçek zamanlı veri alımı için akışlı HTTP istemcileri kullanma
- Sunucudaki dokümantasyon araçlarını çağırma ve yanıtları doğrudan konsola kaydetme
- Terminalden ayrılmadan iş akışınıza güncel Microsoft dokümantasyonunu entegre etme

Bölüm, uygulamalı bir ödev, minimal çalışan bir kod örneği ve daha derin öğrenme için ek kaynaklara bağlantılar içerir. MCP'nin dokümantasyon erişimini ve geliştirici verimliliğini konsol tabanlı ortamlarda nasıl dönüştürebileceğini anlamak için bağlantılı bölümü ve kodu inceleyin.

### 4. [MCP ile Etkileşimli Çalışma Planı Oluşturucu Web Uygulaması](./docs-mcp/README.md)

Bu vaka çalışması, Chainlit ve Model Context Protocol (MCP) kullanarak herhangi bir konu için kişiselleştirilmiş çalışma planları oluşturmak üzere etkileşimli bir web uygulaması oluşturmayı gösterir. Kullanıcılar bir konu (örneğin "AI-900 sertifikası") ve bir çalışma süresi (örneğin 8 hafta) belirtebilir ve uygulama haftalık önerilen içeriklerin bir dökümünü sağlar. Chainlit, konuşma tabanlı bir sohbet arayüzü sunarak deneyimi ilgi çekici ve uyarlanabilir hale getirir.

- Chainlit tarafından desteklenen konuşma tabanlı web uygulaması
- Konu ve süre için kullanıcı odaklı istemler
- MCP kullanarak haftalık içerik önerileri
- Sohbet arayüzünde gerçek zamanlı, uyarlanabilir yanıtlar

Proje, modern bir web ortamında dinamik, kullanıcı odaklı eğitim araçları oluşturmak için konuşma tabanlı yapay zeka ve MCP'nin nasıl birleştirilebileceğini göstermektedir.

### 5. [VS Code'da MCP Sunucusu ile Editör İçi Dokümantasyon](./docs-mcp/README.md)

Bu vaka çalışması, Microsoft Learn Dokümanlarını doğrudan VS Code ortamınıza MCP sunucusu kullanarak getirmenin nasıl mümkün olduğunu gösterir—artık tarayıcı sekmeleri arasında geçiş yapmanıza gerek yok! Şunları göreceksiniz:

- MCP paneli veya komut paleti kullanarak VS Code içinde anında doküman arama ve okuma
- Dokümantasyonu referans alarak README veya kurs markdown dosyalarınıza bağlantılar ekleme
- GitHub Copilot ve MCP'yi bir arada kullanarak kesintisiz, yapay zeka destekli dokümantasyon ve kod iş akışları oluşturma
- Gerçek zamanlı geri bildirim ve Microsoft kaynaklı doğruluk ile dokümantasyonunuzu doğrulama ve geliştirme
- Sürekli dokümantasyon doğrulama için MCP'yi GitHub iş akışlarıyla entegre etme

Uygulama şunları içerir:

- Kolay kurulum için örnek `.vscode/mcp.json` yapılandırması
- Editör içi deneyimin ekran görüntüsü tabanlı anlatımları
- Maksimum verimlilik için Copilot ve MCP'yi birleştirme ipuçları

Bu senaryo, dokümantasyon yazarları, kurs yazarları ve dokümanlar, Copilot ve doğrulama araçlarıyla çalışırken editörlerinde odaklanmak isteyen geliştiriciler için idealdir—hepsi MCP tarafından desteklenmektedir.

### 6. [APIM MCP Sunucusu Oluşturma](./apimsample.md)

Bu vaka çalışması, Azure API Management (APIM) kullanarak bir MCP sunucusu oluşturmanın adım adım rehberini sunar. Şunları kapsar:

- Azure API Management'ta bir MCP sunucusu kurma
- API işlemlerini MCP araçları olarak sunma
- Hız sınırlama ve güvenlik için politikalar yapılandırma
- MCP sunucusunu Visual Studio Code ve GitHub Copilot kullanarak test etme

Bu örnek, Azure'un yeteneklerini kullanarak çeşitli uygulamalarda kullanılabilecek sağlam bir MCP sunucusu oluşturmanın, yapay zeka sistemlerinin kurumsal API'lerle entegrasyonunu nasıl geliştirebileceğini göstermektedir.

## Sonuç

Bu vaka çalışmaları, Model Context Protocol'ün gerçek dünya senaryolarındaki çok yönlülüğünü ve pratik uygulamalarını vurgulamaktadır. Karmaşık çoklu ajan sistemlerinden hedeflenmiş otomasyon iş akışlarına kadar MCP, yapay zeka sistemlerini ihtiyaç duydukları araçlar ve verilerle bağlamak için standart bir yol sunar.

Bu uygulamaları inceleyerek, kendi MCP projelerinize uygulanabilecek mimari modeller, uygulama stratejileri ve en iyi uygulamalar hakkında bilgi edinebilirsiniz. Örnekler, MCP'nin sadece teorik bir çerçeve değil, gerçek iş zorluklarına pratik bir çözüm olduğunu göstermektedir.

## Ek Kaynaklar

- [Azure AI Seyahat Acenteleri GitHub Deposu](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Aracı](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Aracı](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Sunucusu](https://github.com/MicrosoftDocs/mcp)
- [MCP Topluluk Örnekleri](https://github.com/microsoft/mcp)

Sonraki: Uygulamalı Laboratuvar [Yapay Zeka İş Akışlarını Kolaylaştırma: AI Toolkit ile MCP Sunucusu Oluşturma](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Feragatname**:  
Bu belge, AI çeviri hizmeti [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluğu sağlamak için çaba göstersek de, otomatik çeviriler hata veya yanlışlıklar içerebilir. Belgenin orijinal dili, yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımından kaynaklanan yanlış anlamalar veya yanlış yorumlamalardan sorumlu değiliz.