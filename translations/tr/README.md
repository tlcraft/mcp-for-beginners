<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9a14017adf28f7440f20c2d5e7f1d0f8",
  "translation_date": "2025-06-17T15:45:00+00:00",
  "source_file": "README.md",
  "language_code": "tr"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.tr.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


Bu kaynakları kullanmaya başlamak için şu adımları izleyin:
1. **Depoyu Forklayın**: Tıklayın [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Depoyu Klonlayın**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Azure AI Foundry Discord’a katılın ve uzmanlar ile diğer geliştiricilerle tanışın**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Çok Dilli Destek

#### GitHub Action ile desteklenmektedir (Otomatik ve Her Zaman Güncel)

# 🚀 Yeni Başlayanlar için Model Context Protocol (MCP) Müfredatı

## **C#, Java, JavaScript, Python ve TypeScript ile Uygulamalı MCP Öğrenin**

## 🧠 Model Context Protocol Müfredatına Genel Bakış

**Model Context Protocol (MCP)**, yapay zeka modelleri ile istemci uygulamalar arasındaki etkileşimleri standartlaştırmak için geliştirilmiş ileri seviye bir çerçevedir. Bu açık kaynak müfredat, C#, Java, JavaScript, TypeScript ve Python gibi popüler programlama dillerinde pratik kod örnekleri ve gerçek dünya kullanım senaryolarıyla yapılandırılmış bir öğrenme yolu sunar.

İster bir yapay zeka geliştiricisi, sistem mimarı, isterse yazılım mühendisi olun, bu rehber MCP’nin temel kavramlarını ve uygulama stratejilerini ustalıkla öğrenmeniz için kapsamlı bir kaynaktır.

## 🔗 Resmi MCP Kaynakları

- 📘 [MCP Dokümantasyonu](https://modelcontextprotocol.io/) – Detaylı eğitimler ve kullanıcı rehberleri  
- 📜 [MCP Spesifikasyonu](https://spec.modelcontextprotocol.io/) – Protokol mimarisi ve teknik referanslar  
- 🧑‍💻 [MCP GitHub Deposu](https://github.com/modelcontextprotocol) – Açık kaynak SDK’lar, araçlar ve kod örnekleri  

## 🧭 MCP Müfredatının Tam Yapısı

| Bölüm | Başlık | Açıklama | Bağlantı |
|--|--|--|--|
| 00 | **MCP’ye Giriş** | Model Context Protocol’ün genel tanıtımı ve AI iş akışlarındaki önemi, MCP nedir, standartlaşmanın neden önemli olduğu, pratik kullanım örnekleri ve faydaları | [Giriş](./00-Introduction/README.md) |
| 01 | **Temel Kavramlar** | MCP’nin temel kavramlarının derinlemesine incelenmesi; istemci-sunucu mimarisi, protokolün ana bileşenleri ve mesajlaşma kalıpları | [Temel Kavramlar](./01-CoreConcepts/README.md) |
| 02 | **MCP’de Güvenlik** | MCP tabanlı sistemlerde güvenlik tehditlerinin tanımlanması, güvenli uygulamalar için teknikler ve en iyi uygulamalar | [Güvenlik](./02-Security/README.md) |
| 03 | **MCP’ye Başlarken** | Ortam kurulumu ve yapılandırma, temel MCP sunucu ve istemcilerinin oluşturulması, MCP’nin mevcut uygulamalara entegrasyonu | [Başlarken](./03-GettingStarted/README.md) |
| 3.1 | **İlk Sunucu** | MCP protokolü kullanarak temel bir sunucu kurulumu, sunucu-istemci etkileşiminin anlaşılması ve sunucunun test edilmesi | [İlk Sunucu](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **İlk İstemci**  | MCP protokolü kullanarak temel bir istemci kurulumu, istemci-sunucu etkileşiminin anlaşılması ve istemcinin test edilmesi | [İlk İstemci](./03-GettingStarted/02-client/README.md) |
| 3.3 | **LLM ile İstemci**  | MCP protokolü kullanarak Büyük Dil Modeli (LLM) destekli bir istemci kurulumu | [LLM ile İstemci](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Visual Studio Code ile Sunucu Tüketimi** | MCP protokolü kullanarak sunucuları tüketmek için Visual Studio Code’un yapılandırılması | [Visual Studio Code ile Sunucu Tüketimi](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **SSE ile Sunucu Oluşturma** | SSE, sunucuyu internete açmamıza yardımcı olur. Bu bölümde SSE kullanarak sunucu oluşturmayı öğreneceksiniz | [SSE ile Sunucu Oluşturma](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **HTTP Akışı** | İstemciler ile MCP sunucuları arasında gerçek zamanlı veri aktarımı için HTTP akışı nasıl uygulanır öğrenin | [HTTP Akışı](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **AI Araç Setini Kullanma** | AI araç seti, AI ve MCP iş akışınızı yönetmenize yardımcı olacak harika bir araçtır. | [AI Araç Setini Kullanma](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **Sunucunuzu Test Etme** | Test etmek geliştirme sürecinin önemli bir parçasıdır. Bu bölümde farklı araçlar kullanarak test yapmayı öğreneceksiniz. | [Sunucunuzu Test Etme](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **Sunucunuzu Yayına Alma** | Yerel geliştirmeden üretime nasıl geçilir? Bu bölüm sunucunuzu geliştirme ve yayına alma süreçlerini anlatır. | [Sunucunuzu Yayına Alma](./03-GettingStarted/09-deployment/README.md) |
| 04 | **Pratik Uygulama** | Farklı dillerde SDK kullanımı, hata ayıklama, test ve doğrulama, yeniden kullanılabilir prompt şablonları ve iş akışları oluşturma | [Pratik Uygulama](./04-PracticalImplementation/README.md) |
| 05 | **MCP’de İleri Konular** | Çok modlu AI iş akışları ve genişletilebilirlik, güvenli ölçeklendirme stratejileri, MCP’nin kurumsal ekosistemlerde kullanımı | [İleri Konular](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP’nin Azure ile Entegrasyonu** | Azure ile entegrasyon gösterimi | [MCP Azure entegrasyonu](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Çok Modluluk** | Görüntüler ve diğer modlar gibi farklı modalitelerle çalışma gösterimi | [Çok Modluluk](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 Demo** | MCP ile OAuth2’yi gösteren minimal Spring Boot uygulaması; hem Yetkilendirme hem de Kaynak Sunucusu olarak. Güvenli token verme, korumalı uç noktalar, Azure Container Apps dağıtımı ve API Yönetimi entegrasyonunu gösterir. | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Root context hakkında daha fazla bilgi edinin ve nasıl uygulanacağını öğrenin | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Farklı routing türlerini öğrenin | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Sampling ile nasıl çalışılır öğrenin | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Ölçeklendirme** | MCP sunucularının ölçeklendirilmesi hakkında bilgi; yatay ve dikey ölçeklendirme stratejileri, kaynak optimizasyonu ve performans ayarlamaları | [Ölçeklendirme](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Güvenlik** | MCP sunucunuzu güvenceye alın; kimlik doğrulama, yetkilendirme ve veri koruma stratejileri | [Güvenlik](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP sunucusu ve istemcisi, SerpAPI ile gerçek zamanlı web, haber, ürün araması ve Soru-Cevap entegrasyonu. Çoklu araç orkestrasyonu, dış API entegrasyonu ve sağlam hata yönetimini gösterir | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Gerçek Zamanlı Akış** | Günümüzün veri odaklı dünyasında gerçek zamanlı veri akışı kritik hale geldi; işletmeler ve uygulamalar hızlı kararlar almak için anlık bilgiye ihtiyaç duyuyor. | [Gerçek Zamanlı Akış](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Gerçek Zamanlı Web Araması** | MCP’nin AI modelleri, arama motorları ve uygulamalar arasında bağlam yönetimini standartlaştırarak gerçek zamanlı web aramasını nasıl dönüştürdüğünü öğrenin. | [Gerçek Zamanlı Web Araması](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Topluluk Katkıları** | Kod ve doküman katkısı yapma, GitHub üzerinden iş birliği, topluluk odaklı geliştirmeler ve geri bildirimler | [Topluluk Katkıları](./06-CommunityContributions/README.md) |
| 07 | **Erken Benimsemeden Elde Edilen İçgörüler** | Gerçek dünya uygulamaları ve işe yarayanlar, MCP tabanlı çözümlerin oluşturulması ve dağıtımı, trendler ve geleceğe yönelik yol haritası | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **MCP için En İyi Uygulamalar** | Performans ayarı ve optimizasyon, hata toleranslı MCP sistemleri tasarımı, test ve dayanıklılık stratejileri | [Best Practices](./08-BestPractices/README.md) |
| 09 | **MCP Vaka Çalışmaları** | MCP çözüm mimarilerine derinlemesine bakış, dağıtım şablonları ve entegrasyon ipuçları, açıklamalı diyagramlar ve proje anlatımları | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **Yapay Zeka İş Akışlarını Kolaylaştırma: AI Toolkit ile MCP Sunucusu Oluşturma** | MCP’yi Microsoft’un AI Toolkit’i ile VS Code’da birleştiren kapsamlı uygulamalı atölye. Temel bilgiler, özel sunucu geliştirme ve üretim dağıtım stratejilerini kapsayan pratik modüllerle yapay zeka modellerini gerçek dünya araçlarıyla birleştiren akıllı uygulamalar oluşturmayı öğrenin. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Örnek Projeler

### 🧮 MCP Hesaplayıcı Örnek Projeleri:
<details>
  <summary><strong>Dil Bazında Kod Uygulamalarını Keşfet</strong></summary>

  - [C# MCP Sunucu Örneği](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP Hesaplayıcı](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP Demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP Sunucusu](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP Örneği](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP İleri Düzey Hesaplayıcı Projeleri:
<details>
  <summary><strong>İleri Düzey Örnekleri Keşfet</strong></summary>

  - [İleri Düzey C# Örneği](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java Container Uygulama Örneği](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript İleri Düzey Örnek](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python Karmaşık Uygulama](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Container Örneği](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 MCP Öğrenmek için Ön Koşullar

Bu müfredattan en iyi şekilde yararlanmak için:

- Temel C#, Java veya Python bilgisi
- İstemci-sunucu modeli ve API’ler hakkında anlayış
- (İsteğe bağlı) Makine öğrenimi kavramlarına aşinalık

## 📚 Çalışma Rehberi

Bu depoyu etkili şekilde kullanmanıza yardımcı olmak için kapsamlı bir [Çalışma Rehberi](./study_guide.md) bulunmaktadır. Rehber şunları içerir:

- Kapsanan tüm konuları gösteren görsel müfredat haritası
- Her depo bölümünün detaylı açıklaması
- Örnek projelerin nasıl kullanılacağına dair rehberlik
- Farklı beceri seviyeleri için önerilen öğrenme yolları
- Öğrenme yolculuğunuzu destekleyecek ek kaynaklar

## 🛠️ Bu Müfredatı Etkili Kullanma Yöntemleri

Bu rehberdeki her ders şunları içerir:

1. MCP kavramlarının net açıklamaları  
2. Birden fazla dilde canlı kod örnekleri  
3. Gerçek MCP uygulamaları geliştirmek için alıştırmalar  
4. İleri düzey öğrenenler için ek kaynaklar  

## 📜 Lisans Bilgisi

Bu içerik **MIT Lisansı** ile lisanslanmıştır. Şartlar için [LICENSE](../../LICENSE) dosyasına bakınız.

## 🤝 Katkı Rehberi

Bu proje katkı ve önerilere açıktır. Çoğu katkı için, katkınızı kullanma haklarını size ait olduğunu ve bu hakları bize verdiğinizi beyan eden bir Contributor License Agreement (CLA) kabul etmeniz gerekir. Detaylar için <https://cla.opensource.microsoft.com> adresini ziyaret edin.

Bir pull request gönderdiğinizde, CLA botu otomatik olarak CLA’ya ihtiyacınız olup olmadığını belirler ve PR’yi uygun şekilde işaretler (örneğin, durum kontrolü, yorum). Botun verdiği talimatları takip etmeniz yeterlidir. Bu işlemi, CLA kullanan tüm depolar için sadece bir kez yapmanız yeterlidir.

Bu proje [Microsoft Açık Kaynak Davranış Kuralları](https://opensource.microsoft.com/codeofconduct/)’nu benimsemiştir. Daha fazla bilgi için [Davranış Kuralları SSS](https://opensource.microsoft.com/codeofconduct/faq/) sayfasını ziyaret edin veya ek sorularınız için [opencode@microsoft.com](mailto:opencode@microsoft.com) adresiyle iletişime geçin.

## 🎒 Diğer Kurslar  
Ekibimiz başka kurslar da sunuyor! Göz atın:

- [Yeni Başlayanlar için AI Agentleri](https://github.com/microsoft/ai-agents-for-beginners?WT.mc_id=academic-105485-koreyst)
- [.NET ile Yeni Başlayanlar için Üretken AI](https://github.com/microsoft/Generative-AI-for-beginners-dotnet?WT.mc_id=academic-105485-koreyst)
- [JavaScript ile Yeni Başlayanlar için Üretken AI](https://github.com/microsoft/generative-ai-with-javascript?WT.mc_id=academic-105485-koreyst)
- [Yeni Başlayanlar için Üretken AI](https://github.com/microsoft/generative-ai-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Yeni Başlayanlar için ML](https://aka.ms/ml-beginners?WT.mc_id=academic-105485-koreyst)
- [Yeni Başlayanlar için Veri Bilimi](https://aka.ms/datascience-beginners?WT.mc_id=academic-105485-koreyst)
- [Yeni Başlayanlar için AI](https://aka.ms/ai-beginners?WT.mc_id=academic-105485-koreyst)
- [Yeni Başlayanlar için Siber Güvenlik](https://github.com/microsoft/Security-101??WT.mc_id=academic-96948-sayoung)
- [Yeni Başlayanlar için Web Geliştirme](https://aka.ms/webdev-beginners?WT.mc_id=academic-105485-koreyst)
- [Yeni Başlayanlar için IoT](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)
- [Yeni Başlayanlar için XR Geliştirme](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Yapay Zeka Eşli Programlama için GitHub Copilot'u Ustalaştırmak](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [C#/.NET Geliştiricileri için GitHub Copilot'u Ustalaştırmak](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Kendi Copilot Maceranı Seç](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Marka Bildirimi

Bu proje, projeler, ürünler veya hizmetler için ticari markalar veya logolar içerebilir. Microsoft ticari markalarının veya logolarının yetkili kullanımı, [Microsoft'un Ticari Marka ve Marka Rehberi](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general) kurallarına tabi olup, bu kurallara uyulmalıdır. Bu projenin değiştirilmiş sürümlerinde Microsoft ticari markalarının veya logolarının kullanımı, karışıklığa yol açmamalı veya Microsoft sponsorluğunu ima etmemelidir. Üçüncü taraf ticari markalarının veya logolarının kullanımı ise ilgili üçüncü tarafların politikalarına tabidir.

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı nedeniyle ortaya çıkabilecek yanlış anlamalar veya yanlış yorumlamalar konusunda sorumluluk kabul edilmemektedir.