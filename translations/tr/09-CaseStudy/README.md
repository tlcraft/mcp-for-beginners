<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "873741da08dd6537858d5e14c3a386e1",
  "translation_date": "2025-07-04T17:14:06+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "tr"
}
-->
# MCP Uygulamada: Gerçek Dünya Vaka Çalışmaları

Model Context Protocol (MCP), yapay zeka uygulamalarının veri, araçlar ve hizmetlerle etkileşim şeklini dönüştürüyor. Bu bölüm, MCP’nin çeşitli kurumsal senaryolarda pratik uygulamalarını gösteren gerçek dünya vaka çalışmalarını sunar.

## Genel Bakış

Bu bölüm, MCP uygulamalarına dair somut örnekler sunarak, organizasyonların bu protokolü karmaşık iş problemlerini çözmek için nasıl kullandığını vurgular. Bu vaka çalışmalarını inceleyerek, MCP’nin gerçek dünya senaryolarındaki çok yönlülüğü, ölçeklenebilirliği ve pratik faydaları hakkında bilgi edineceksiniz.

## Temel Öğrenme Hedefleri

Bu vaka çalışmalarını keşfederek:

- MCP’nin belirli iş problemlerini çözmek için nasıl uygulanabileceğini anlayacaksınız
- Farklı entegrasyon desenleri ve mimari yaklaşımlar hakkında bilgi sahibi olacaksınız
- Kurumsal ortamlarda MCP uygulamak için en iyi uygulamaları tanıyacaksınız
- Gerçek dünya uygulamalarında karşılaşılan zorluklar ve çözümler hakkında fikir edineceksiniz
- Kendi projelerinizde benzer desenleri uygulama fırsatlarını belirleyeceksiniz

## Öne Çıkan Vaka Çalışmaları

### 1. [Azure AI Seyahat Acenteleri – Referans Uygulama](./travelagentsample.md)

Bu vaka çalışması, Microsoft’un MCP, Azure OpenAI ve Azure AI Search kullanarak çoklu ajanlı, yapay zeka destekli seyahat planlama uygulaması oluşturmayı gösteren kapsamlı referans çözümünü inceliyor. Proje şunları gösteriyor:

- MCP ile çoklu ajan orkestrasyonu
- Azure AI Search ile kurumsal veri entegrasyonu
- Azure servisleri kullanılarak güvenli ve ölçeklenebilir mimari
- Yeniden kullanılabilir MCP bileşenleriyle genişletilebilir araçlar
- Azure OpenAI destekli sohbet tabanlı kullanıcı deneyimi

Mimari ve uygulama detayları, MCP’yi koordinasyon katmanı olarak kullanarak karmaşık çoklu ajan sistemleri oluşturma konusunda değerli bilgiler sunuyor.

### 2. [YouTube Verilerinden Azure DevOps Öğelerinin Güncellenmesi](./UpdateADOItemsFromYT.md)

Bu vaka çalışması, MCP’nin iş akışı süreçlerini otomatikleştirmek için pratik bir uygulamasını gösteriyor. MCP araçlarının nasıl kullanılabileceğini anlatıyor:

- Çevrimiçi platformlardan (YouTube) veri çekmek
- Azure DevOps sistemlerindeki iş öğelerini güncellemek
- Tekrarlanabilir otomasyon iş akışları oluşturmak
- Farklı sistemler arasında veri entegrasyonu sağlamak

Bu örnek, nispeten basit MCP uygulamalarının bile rutin görevleri otomatikleştirerek ve sistemler arası veri tutarlılığını artırarak önemli verimlilik kazançları sağlayabileceğini gösteriyor.

### 3. [MCP ile Gerçek Zamanlı Dokümantasyon Erişimi](./docs-mcp/README.md)

Bu vaka çalışması, bir Python konsol istemcisini Model Context Protocol (MCP) sunucusuna bağlayarak gerçek zamanlı, bağlam odaklı Microsoft dokümantasyonunu nasıl alıp kaydedebileceğinizi anlatıyor. Öğrenecekleriniz:

- Resmi MCP SDK kullanarak Python istemcisi ile MCP sunucusuna bağlanmak
- Verimli ve gerçek zamanlı veri çekimi için streaming HTTP istemcileri kullanmak
- Sunucudaki dokümantasyon araçlarını çağırmak ve yanıtları doğrudan konsola kaydetmek
- Güncel Microsoft dokümantasyonunu terminalden çıkmadan iş akışınıza entegre etmek

Bölüm, uygulamalı bir görev, minimal çalışan kod örneği ve daha derin öğrenme için ek kaynak bağlantıları içeriyor. MCP’nin konsol tabanlı ortamlarda dokümantasyon erişimini ve geliştirici verimliliğini nasıl dönüştürebileceğini anlamak için tam anlatımı ve kodu ilgili bölümde inceleyin.

### 4. [MCP ile Etkileşimli Çalışma Planı Oluşturucu Web Uygulaması](./docs-mcp/README.md)

Bu vaka çalışması, Chainlit ve Model Context Protocol (MCP) kullanarak herhangi bir konu için kişiselleştirilmiş çalışma planları oluşturan etkileşimli bir web uygulaması yapmayı gösteriyor. Kullanıcılar bir konu (örneğin "AI-900 sertifikası") ve çalışma süresi (örneğin 8 hafta) belirtebiliyor, uygulama ise haftalık önerilen içerik listesini sunuyor. Chainlit, sohbet tabanlı etkileşimli bir arayüz sağlıyor ve deneyimi ilgi çekici ve uyarlanabilir kılıyor.

- Chainlit destekli sohbet tabanlı web uygulaması
- Kullanıcı tarafından belirlenen konu ve süre girdileri
- MCP kullanarak haftalık içerik önerileri
- Sohbet arayüzünde gerçek zamanlı, uyarlanabilir yanıtlar

Proje, sohbet tabanlı yapay zeka ile MCP’nin modern web ortamlarında dinamik, kullanıcı odaklı eğitim araçları yaratmak için nasıl birleştirilebileceğini gösteriyor.

### 5. [VS Code’da MCP Sunucusu ile Editör İçi Dokümantasyon](./docs-mcp/README.md)

Bu vaka çalışması, MCP sunucusunu kullanarak Microsoft Learn Dokümanlarını doğrudan VS Code ortamınıza nasıl getirebileceğinizi gösteriyor—tarayıcı sekmeleri arasında geçiş yapmaya son! Şunları göreceksiniz:

- MCP paneli veya komut paleti ile VS Code içinde anında doküman arama ve okuma
- Dokümantasyona referans verme ve README ya da kurs markdown dosyalarına doğrudan bağlantı ekleme
- GitHub Copilot ve MCP’yi birlikte kullanarak kesintisiz, yapay zeka destekli dokümantasyon ve kod iş akışları
- Gerçek zamanlı geri bildirim ve Microsoft kaynaklı doğrulukla dokümantasyonunuzu doğrulama ve geliştirme
- Sürekli dokümantasyon doğrulaması için MCP’yi GitHub iş akışlarıyla entegre etme

Uygulama şunları içerir:
- Kolay kurulum için örnek `.vscode/mcp.json` yapılandırması
- Editör içi deneyimin ekran görüntüleriyle anlatımı
- Maksimum verimlilik için Copilot ve MCP’nin birlikte kullanımına dair ipuçları

Bu senaryo, kurs yazarları, dokümantasyon yazarları ve doküman, Copilot ve doğrulama araçlarıyla çalışırken editörlerinde odaklanmak isteyen geliştiriciler için idealdir.

### 6. [APIM MCP Sunucusu Oluşturma](./apimsample.md)

Bu vaka çalışması, Azure API Management (APIM) kullanarak MCP sunucusunun nasıl oluşturulacağına dair adım adım rehber sunar. Kapsanan konular:

- Azure API Management içinde MCP sunucusu kurma
- API işlemlerini MCP araçları olarak açığa çıkarma
- Oran sınırlama ve güvenlik için politika yapılandırma
- Visual Studio Code ve GitHub Copilot kullanarak MCP sunucusunu test etme

Bu örnek, Azure’un yeteneklerini kullanarak çeşitli uygulamalarda kullanılabilecek sağlam bir MCP sunucusu oluşturmayı ve AI sistemlerinin kurumsal API’lerle entegrasyonunu nasıl geliştirebileceğinizi gösterir.

## Sonuç

Bu vaka çalışmaları, Model Context Protocol’ün gerçek dünya senaryolarındaki çok yönlülüğünü ve pratik uygulamalarını ortaya koyuyor. Karmaşık çoklu ajan sistemlerinden hedefe yönelik otomasyon iş akışlarına kadar MCP, yapay zeka sistemlerini ihtiyaç duydukları araçlar ve verilerle standart bir şekilde bağlamanın yolunu sunuyor.

Bu uygulamaları inceleyerek, kendi MCP projelerinizde kullanabileceğiniz mimari desenler, uygulama stratejileri ve en iyi uygulamalar hakkında bilgi edinebilirsiniz. Örnekler, MCP’nin sadece teorik bir çerçeve olmadığını, gerçek iş problemlerine pratik bir çözüm sunduğunu gösteriyor.

## Ek Kaynaklar

- [Azure AI Travel Agents GitHub Deposu](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Aracı](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Aracı](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Sunucusu](https://github.com/MicrosoftDocs/mcp)
- [MCP Topluluk Örnekleri](https://github.com/microsoft/mcp)

Sonraki: Uygulamalı Laboratuvar [AI İş Akışlarını Kolaylaştırma: AI Toolkit ile MCP Sunucusu Oluşturma](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu ortaya çıkabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.