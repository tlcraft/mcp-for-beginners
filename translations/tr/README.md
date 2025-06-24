<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc76969a3bb20c032d1d5e95a304a2e3",
  "translation_date": "2025-06-24T16:33:46+00:00",
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
3. [**Azure AI Foundry Discord’a Katılın ve uzmanlar ile diğer geliştiricilerle tanışın**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Çok Dilli Destek

#### GitHub Action ile desteklenmektedir (Otomatik ve Her Zaman Güncel)

# 🚀 Başlangıç Seviyesi için Model Context Protocol (MCP) Müfredatı

## **C#, Java, JavaScript, Python ve TypeScript ile Pratik Kod Örnekleriyle MCP Öğrenin**

## 🧠 Model Context Protocol Müfredatı Hakkında Genel Bakış

**Model Context Protocol (MCP)**, yapay zeka modelleri ile istemci uygulamaları arasındaki etkileşimleri standartlaştırmak için tasarlanmış yenilikçi bir çerçevedir. Bu açık kaynaklı müfredat, C#, Java, JavaScript, TypeScript ve Python gibi popüler programlama dillerinde pratik kod örnekleri ve gerçek dünya kullanım senaryolarıyla desteklenen yapılandırılmış bir öğrenme yolu sunar.

İster bir yapay zeka geliştiricisi, sistem mimarı ya da yazılım mühendisi olun, bu rehber MCP temel kavramlarını ve uygulama stratejilerini ustalıkla öğrenmeniz için kapsamlı bir kaynaktır.

## 🔗 Resmi MCP Kaynakları

- 📘 [MCP Dokümantasyonu](https://modelcontextprotocol.io/) – Detaylı öğreticiler ve kullanıcı kılavuzları  
- 📜 [MCP Spesifikasyonu](https://spec.modelcontextprotocol.io/) – Protokol mimarisi ve teknik referanslar  
- 🧑‍💻 [MCP GitHub Deposu](https://github.com/modelcontextprotocol) – Açık kaynak SDK’lar, araçlar ve kod örnekleri  

## 🧭 MCP Müfredatı Genel Bakış

<details>
  <summary><strong>00-03: Temeller</strong></summary>

- **00. MCP’ye Giriş**  
  Model Context Protocol’ün genel tanıtımı ve AI süreçlerindeki önemi. [Devamını oku](./00-Introduction/README.md)
- **01. Temel Kavramların Açıklaması**  
  MCP’nin temel kavramlarının derinlemesine incelenmesi. [Devamını oku](./01-CoreConcepts/README.md)
- **02. MCP’de Güvenlik**  
  Güvenlik tehditleri ve en iyi uygulamalar. [Devamını oku](./02-Security/README.md)
- **03. MCP ile Başlarken**  
  Ortam kurulumu, temel sunucu/istemci yapıları, entegrasyon. [Devamını oku](./03-GettingStarted/README.md)
</details>

<details>
  <summary><strong>03.x: Uygulamalı Laboratuvarlar</strong></summary>

- **3.1. İlk sunucu** – [Kılavuz](./03-GettingStarted/01-first-server/README.md)
- **3.2. İlk istemci** – [Kılavuz](./03-GettingStarted/02-client/README.md)
- **3.3. LLM ile istemci** – [Kılavuz](./03-GettingStarted/03-llm-client/README.md)
- **3.4. Visual Studio Code ile sunucu kullanımı** – [Kılavuz](./03-GettingStarted/04-vscode/README.md)
- **3.5. SSE kullanarak sunucu oluşturma** – [Kılavuz](./03-GettingStarted/05-sse-server/README.md)
- **3.6. HTTP Akışı** – [Kılavuz](./03-GettingStarted/06-http-streaming/README.md)
- **3.7. AI Toolkit kullanımı** – [Kılavuz](./03-GettingStarted/07-aitk/README.md)
- **3.8. Sunucunuzu test etme** – [Kılavuz](./03-GettingStarted/08-testing/README.md)
- **3.9. Sunucunuzu dağıtma** – [Kılavuz](./03-GettingStarted/09-deployment/README.md)
</details>

<details>
  <summary><strong>04-05: Pratik & İleri Düzey</strong></summary>

- **04. Pratik Uygulama**  
  SDK’lar, hata ayıklama, test etme, tekrar kullanılabilir prompt şablonları. [Devamını oku](./04-PracticalImplementation/README.md)
- **05. MCP’de İleri Konular**  
  Çok modlu yapay zeka, ölçeklendirme, kurumsal kullanım. [Devamını oku](./05-AdvancedTopics/README.md)
- **5.1. MCP’nin Azure ile Entegrasyonu** – [Kılavuz](./05-AdvancedTopics/mcp-integration/README.md)
- **5.2. Çoklu Modallik** – [Kılavuz](./05-AdvancedTopics/mcp-multi-modality/README.md)
- **5.3. MCP OAuth2 Demo** – [Kılavuz](./05-AdvancedTopics/mcp-oauth2-demo/README.md)
- **5.4. Root Contexts** – [Kılavuz](./05-AdvancedTopics/mcp-root-contexts/README.md)
- **5.5. Yönlendirme** – [Kılavuz](./05-AdvancedTopics/mcp-routing/README.md)
- **5.6. Örnekleme** – [Kılavuz](./05-AdvancedTopics/mcp-sampling/README.md)
- **5.7. Ölçeklendirme** – [Kılavuz](./05-AdvancedTopics/mcp-scaling/README.md)
- **5.8. Güvenlik** – [Kılavuz](./05-AdvancedTopics/mcp-security/README.md)
- **5.9. Web Arama MCP** – [Kılavuz](./05-AdvancedTopics/web-search-mcp/README.md)
- **5.10. Gerçek Zamanlı Akış** – [Kılavuz](./05-AdvancedTopics/mcp-realtimestreaming/README.md)
- **5.11. Gerçek Zamanlı Web Arama** – [Kılavuz](./05-AdvancedTopics/mcp-realtimesearch/README.md)
</details>

<details>
  <summary><strong>06-10: Topluluk, En İyi Uygulamalar & Laboratuvarlar</strong></summary>

- **06. Topluluk Katkıları** – [Kılavuz](./06-CommunityContributions/README.md)
- **07. Erken Benimsemeden Alınan Dersler** – [Kılavuz](./07-LessonsFromEarlyAdoption/README.md)
- **08. MCP için En İyi Uygulamalar** – [Kılavuz](./08-BestPractices/README.md)
- **09. MCP Vaka Çalışmaları** – [Kılavuz](./09-CaseStudy/README.md)
- **10. AI İş Akışlarını Kolaylaştırmak: AI Toolkit ile MCP Sunucusu Oluşturma** – [Uygulamalı Laboratuvar](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)
</details>

## Örnek Projeler

### 🧮 MCP Hesaplayıcı Örnek Projeleri:
<details>
  <summary><strong>Dil Bazında Kod Uygulamalarını Keşfet</strong></summary>

  - [C# MCP Sunucu Örneği](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP Hesaplayıcı](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP Demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP Sunucu](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP Örneği](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP İleri Düzey Hesaplayıcı Projeleri:
<details>
  <summary><strong>İleri Düzey Örnekleri Keşfet</strong></summary>

  - [İleri Düzey C# Örneği](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java Konteyner Uygulama Örneği](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript İleri Düzey Örnek](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python Karmaşık Uygulama](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Konteyner Örneği](./04-PracticalImplementation/samples/typescript/README.md)

</details>

## 🎯 MCP Öğrenimi İçin Ön Koşullar

Bu müfredattan en iyi şekilde faydalanmak için:

- C#, Java veya Python hakkında temel bilgi sahibi olmalısınız  
- İstemci-sunucu modeli ve API’ler hakkında anlayışınız olmalı  
- (İsteğe bağlı) Makine öğrenimi kavramlarına aşinalık

## 📚 Çalışma Rehberi

Bu depoda etkin bir şekilde gezinmenize yardımcı olacak kapsamlı bir [Çalışma Rehberi](./study_guide.md) mevcuttur. Rehber şunları içerir:

- Kapsanan tüm konuları gösteren görsel müfredat haritası  
- Her depo bölümünün detaylı dökümü  
- Örnek projelerin nasıl kullanılacağına dair rehberlik  
- Farklı beceri seviyeleri için önerilen öğrenme yolları  
- Öğrenme yolculuğunuzu destekleyecek ek kaynaklar

## 🛠️ Bu Müfredatı Etkili Kullanma Yöntemleri

Bu kılavuzdaki her ders şunları içerir:

1. MCP kavramlarının net açıklamaları  
2. Birden çok dilde canlı kod örnekleri  
3. Gerçek MCP uygulamaları geliştirmek için alıştırmalar  
4. İleri düzey öğrenenler için ek kaynaklar

## 🌟 Topluluk Teşekkürü

Önemli kod örnekleriyle katkıda bulunan Microsoft Değerli Profesyoneli [Shivam Goyal](https://www.linkedin.com/in/shivam2003/)’a teşekkür ederiz.

## 📜 Lisans Bilgileri

Bu içerik **MIT Lisansı** altında lisanslanmıştır. Şartlar ve koşullar için [LICENSE](../../LICENSE) dosyasına bakınız.

## 🤝 Katkı Kuralları

Bu proje katkı ve önerilere açıktır. Çoğu katkı, katkınızın kullanım haklarını bize verdiğinizi ve gerçekten verdiğinizi belirten bir Contributor License Agreement (CLA) kabul etmenizi gerektirir. Detaylar için <https://cla.opensource.microsoft.com> adresini ziyaret edin.

Bir pull request gönderdiğinizde, bir CLA botu otomatik olarak CLA sağlamanız gerekip gerekmediğini belirler ve PR'ı uygun şekilde işaretler (örneğin, durum kontrolü, yorum). Botun sağladığı talimatları takip etmeniz yeterlidir. Bu işlemi, CLA kullanan tüm depolarda sadece bir kez yapmanız yeterlidir.

Bu proje [Microsoft Açık Kaynak Davranış Kuralları](https://opensource.microsoft.com/codeofconduct/)’nu benimsemiştir. Daha fazla bilgi için [Davranış Kuralları SSS](https://opensource.microsoft.com/codeofconduct/faq/) sayfasına bakabilir veya ek sorularınız için [opencode@microsoft.com](mailto:opencode@microsoft.com) adresine ulaşabilirsiniz.

## 🎒 Diğer Kurslar  
Ekibimiz başka kurslar da sunuyor! Göz atın:

- [Yeni Başlayanlar için AI Ajanları](https://github.com/microsoft/ai-agents-for-beginners?WT.mc_id=academic-105485-koreyst)  
- [.NET ile Yeni Başlayanlar için Üretken AI](https://github.com/microsoft/Generative-AI-for-beginners-dotnet?WT.mc_id=academic-105485-koreyst)  
- [JavaScript ile Yeni Başlayanlar için Üretken AI](https://github.com/microsoft/generative-ai-with-javascript?WT.mc_id=academic-105485-koreyst)  
- [Yeni Başlayanlar için Üretken AI](https://github.com/microsoft/generative-ai-for-beginners?WT.mc_id=academic-105485-koreyst)  
- [Yeni Başlayanlar için Makine Öğrenimi](https://aka.ms/ml-beginners?WT.mc_id=academic-105485-koreyst)  
- [Yeni Başlayanlar için Veri Bilimi](https://aka.ms/datascience-beginners?WT.mc_id=academic-105485-koreyst)  
- [Yeni Başlayanlar için Yapay Zeka](https://aka.ms/ai-beginners?WT.mc_id=academic-105485-koreyst)  
- [Yeni Başlayanlar için Siber Güvenlik](https://github.com/microsoft/Security-101??WT.mc_id=academic-96948-sayoung)  
- [Yeni Başlayanlar için Web Geliştirme](https://aka.ms/webdev-beginners?WT.mc_id=academic-105485-koreyst)  
- [Yeni Başlayanlar için Nesnelerin İnterneti (IoT)](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)
- [Yeni Başlayanlar için XR Geliştirme](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Yapay Zeka Eşli Programlama için GitHub Copilot'u Ustalaştırma](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [C#/.NET Geliştiricileri için GitHub Copilot'u Ustalaştırma](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Kendi Copilot Maceranı Seç](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Marka Bildirimi

Bu proje, projeler, ürünler veya hizmetler için ticari markalar veya logolar içerebilir. Microsoft ticari markalarının veya logolarının yetkili kullanımı, [Microsoft'un Marka ve Marka Rehberleri](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general) kurallarına tabidir ve bu kurallara uyulmalıdır. Bu projenin değiştirilmiş sürümlerinde Microsoft ticari markalarının veya logolarının kullanımı karışıklığa yol açmamalı veya Microsoft sponsorluğunu ima etmemelidir. Üçüncü taraf ticari markalarının veya logolarının kullanımı ise ilgili üçüncü tarafların politikalarına tabidir.

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayın. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek herhangi bir yanlış anlama veya yanlış yorumdan sorumlu değiliz.