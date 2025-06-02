<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "677cecb63a0bf6c0f49e40ffc15f6189",
  "translation_date": "2025-06-02T12:47:56+00:00",
  "source_file": "README.md",
  "language_code": "cs"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.cs.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


Siga estes passos para começar a usar esses recursos:
1. **Fork o Repositório**: Clique em [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Clone o Repositório**: `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Participe do Discord Azure AI Foundry e conheça especialistas e outros desenvolvedores**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Suporte Multilíngue

#### Suportado via GitHub Action (Automatizado e Sempre Atualizado)

# 🚀 Model Context Protocol (MCP) Müfredatı Yeni Başlayanlar İçin

## **C#, Java, JavaScript, Python ve TypeScript ile MCP'yi Uygulamalı Kod Örnekleriyle Öğrenin**

## 🧠 Model Context Protocol Müfredatı Genel Bakış

**Model Context Protocol (MCP)**, yapay zeka modelleri ile istemci uygulamalar arasındaki etkileşimleri standartlaştırmak için tasarlanmış ileri teknoloji bir çerçevedir. Bu açık kaynak müfredat, C#, Java, JavaScript, TypeScript ve Python gibi popüler programlama dillerinde pratik kod örnekleri ve gerçek dünya kullanım senaryolarıyla yapılandırılmış bir öğrenme yolu sunar.

İster bir yapay zeka geliştiricisi, sistem mimarı, ister yazılım mühendisi olun, bu rehber MCP temel bilgilerini ve uygulama stratejilerini öğrenmeniz için kapsamlı bir kaynaktır.

## 🔗 Resmi MCP Kaynakları

- 📘 [MCP Dokümantasyonu](https://modelcontextprotocol.io/) – Ayrıntılı öğreticiler ve kullanıcı kılavuzları  
- 📜 [MCP Spesifikasyonu](https://spec.modelcontextprotocol.io/) – Protokol mimarisi ve teknik referanslar  
- 🧑‍💻 [MCP GitHub Deposu](https://github.com/modelcontextprotocol) – Açık kaynak SDK’lar, araçlar ve kod örnekleri  

## 🧭 Tam MCP Müfredat Yapısı

| Bölüm | Başlık | Açıklama | Bağlantı |
|--|--|--|--|
| 00 | **MCP'ye Giriş** | Model Context Protocol’ün genel tanıtımı ve AI süreçlerindeki önemi, Model Context Protocol nedir, neden standartlaştırma önemlidir ve pratik kullanım örnekleri ile faydalar | [Giriş](./00-Introduction/README.md) |
| 01 | **Temel Kavramlar Açıklaması** | MCP’nin temel kavramlarının derinlemesine incelenmesi, istemci-sunucu mimarisi, ana protokol bileşenleri ve mesajlaşma kalıpları | [Temel Kavramlar](./01-CoreConcepts/README.md) |
| 02 | **MCP’de Güvenlik** | MCP tabanlı sistemlerde güvenlik tehditlerinin belirlenmesi, güvenli uygulama teknikleri ve en iyi uygulamalar | [Güvenlik](./02-Security/README.md) |
| 03 | **MCP ile Başlarken** | Ortam kurulumu ve yapılandırması, temel MCP sunucu ve istemcilerinin oluşturulması, MCP’nin mevcut uygulamalarla entegrasyonu | [Başlarken](./03-GettingStarted/README.md) |
| 3.1 | **İlk sunucu** | MCP protokolü kullanarak temel bir sunucu kurulumu, sunucu-istemci etkileşiminin anlaşılması ve sunucunun test edilmesi | [İlk Sunucu](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **İlk istemci**  | MCP protokolü kullanarak temel bir istemci kurulumu, istemci-sunucu etkileşiminin anlaşılması ve istemcinin test edilmesi | [İlk İstemci](./03-GettingStarted/02-client/README.md) |
| 3.3 | **LLM ile İstemci**  | MCP protokolü ile Büyük Dil Modeli (LLM) kullanan bir istemci kurulumu | [LLM ile İstemci](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Visual Studio Code ile Sunucu Tüketimi** | Visual Studio Code ortamında MCP protokolü kullanan sunucuların tüketilmesi için yapılandırma | [Visual Studio Code ile Sunucu Tüketimi](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **SSE ile Sunucu Oluşturma** | SSE, sunucuyu internete açmamıza yardımcı olur. Bu bölüm SSE kullanarak sunucu oluşturmayı anlatır | [SSE ile Sunucu Oluşturma](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **AI Toolkit Kullanımı** | AI toolkit, AI ve MCP iş akışınızı yönetmenize yardımcı olacak harika bir araçtır | [AI Toolkit Kullanımı](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Sunucunuzu Test Etme** | Test, geliştirme sürecinin önemli bir parçasıdır. Bu bölüm çeşitli araçlarla test yapmanıza yardımcı olur | [Sunucunuzu Test Etme](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Sunucunuzu Yayınlama** | Yerel geliştirmeden üretime geçiş nasıl yapılır? Bu bölüm sunucunuzu geliştirme ve dağıtma süreçlerini anlatır | [Sunucunuzu Yayınlama](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Pratik Uygulama** | Farklı dillerde SDK kullanımı, hata ayıklama, test ve doğrulama, yeniden kullanılabilir prompt şablonları ve iş akışları oluşturma | [Pratik Uygulama](./04-PracticalImplementation/README.md) |
| 05 | **MCP’de İleri Konular** | Çok modlu AI iş akışları ve genişletilebilirlik, güvenli ölçeklendirme stratejileri, MCP’nin kurumsal ekosistemlerde kullanımı | [İleri Konular](./05-AdvancedTopics/README.md) |
| 5.1 | **MCP OAuth2 Demo** | MCP sunucularında OAuth2 kimlik doğrulaması uygulaması, erişim belirteci doğrulama, kapsam tabanlı yetkilendirme ve güvenli API uç noktası koruması | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.2 | **MCP ile Web Arama** | Model Context Protocol kullanarak web arama yeteneklerinin uygulanması, arama sorgusu işleme, sonuç yönetimi ve arama API’leri entegrasyonu | [Web Arama MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 06 | **Topluluk Katkıları** | Kod ve doküman katkısı yapma, GitHub üzerinden iş birliği, topluluk kaynaklı iyileştirmeler ve geri bildirim | [Topluluk Katkıları](./06-CommunityContributions/README.md) |
| 07 | **Erken Benimsemeden Öğrenilenler** | Gerçek dünya uygulamaları ve işe yarayan yöntemler, MCP tabanlı çözümlerin inşası ve dağıtımı, trendler ve gelecek yol haritası | [Öğrenilenler](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **MCP İçin En İyi Uygulamalar** | Performans ayarı ve optimizasyon, hata toleranslı MCP sistemleri tasarımı, test ve dayanıklılık stratejileri | [En İyi Uygulamalar](./08-BestPractices/README.md) |
| 09 | **MCP Vaka Çalışmaları** | MCP çözüm mimarilerine derinlemesine bakış, dağıtım planları ve entegrasyon ipuçları, açıklamalı diyagramlar ve proje incelemeleri | [Vaka Çalışmaları](./09-CaseStudy/README.md) |

## Örnek Projeler

### 🧮 MCP Hesap Makinesi Örnek Projeleri:
<details>
  <summary><strong>Dil Bazında Kod Uygulamalarını Keşfedin</strong></summary>

  - [C# MCP Sunucu Örneği](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP Hesap Makinesi](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP Demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP Sunucu](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP Örneği](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP İleri Düzey Hesap Makinesi Projeleri:
<details>
  <summary><strong>İleri Düzey Örnekleri Keşfedin</strong></summary>

  - [İleri Düzey C# Örneği](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java Container Uygulama Örneği](./04-PracticalImplementation/samples/java/containerapp/README.md)
- [JavaScript Advanced Sample](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python Complex Implementation](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Container Sample](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 MCP 학습을 위한 사전 조건

이 커리큘럼을 최대한 활용하려면 다음이 필요합니다:

- C#, Java, 또는 Python의 기본 지식
- 클라이언트-서버 모델과 API에 대한 이해
- (선택 사항) 머신러닝 개념에 대한 친숙함

## 🛠️ 이 커리큘럼을 효과적으로 활용하는 방법

이 가이드의 각 수업에는 다음이 포함됩니다:

1. MCP 개념에 대한 명확한 설명  
2. 여러 언어로 된 실시간 코드 예제  
3. 실제 MCP 애플리케이션을 만드는 연습 문제  
4. 심화 학습자를 위한 추가 자료  

## 📜 라이선스 정보

이 콘텐츠는 **MIT 라이선스** 하에 제공됩니다. 조건과 조항은 [LICENSE](../../LICENSE)에서 확인하세요.

## 🤝 기여 가이드라인

이 프로젝트는 기여와 제안을 환영합니다. 대부분의 기여는 기여권 계약서(CLA)에 동의해야 하며, 이는 여러분이 기여에 대한 권리를 가지고 있고 실제로 해당 권리를 우리에게 부여한다는 것을 선언하는 문서입니다. 자세한 내용은 <https://cla.opensource.microsoft.com>을 참조하세요.

풀 리퀘스트를 제출하면 CLA 봇이 자동으로 CLA 제출 필요 여부를 판단하고 PR에 적절한 표시(예: 상태 검사, 코멘트)를 합니다. 봇의 안내에 따라 진행하면 됩니다. 모든 저장소에서 한 번만 수행하면 됩니다.

이 프로젝트는 [Microsoft 오픈 소스 행동 강령](https://opensource.microsoft.com/codeofconduct/)을 채택했습니다. 자세한 내용은 [행동 강령 FAQ](https://opensource.microsoft.com/codeofconduct/faq/)를 참고하거나 추가 질문이 있으면 [opencode@microsoft.com](mailto:opencode@microsoft.com)으로 문의하세요.

## 🎒 기타 강의
저희 팀은 다른 강의도 제작합니다! 확인해보세요:

- [AI Agents For Beginners](https://github.com/microsoft/ai-agents-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners using .NET](https://github.com/microsoft/Generative-AI-for-beginners-dotnet?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners using JavaScript](https://github.com/microsoft/generative-ai-with-javascript?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners](https://github.com/microsoft/generative-ai-for-beginners?WT.mc_id=academic-105485-koreyst)
- [ML for Beginners](https://aka.ms/ml-beginners?WT.mc_id=academic-105485-koreyst)
- [Data Science for Beginners](https://aka.ms/datascience-beginners?WT.mc_id=academic-105485-koreyst)
- [AI for Beginners](https://aka.ms/ai-beginners?WT.mc_id=academic-105485-koreyst)
- [Cybersecurity for Beginners](https://github.com/microsoft/Security-101??WT.mc_id=academic-96948-sayoung)
- [Web Dev for Beginners](https://aka.ms/webdev-beginners?WT.mc_id=academic-105485-koreyst)
- [IoT for Beginners](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)
- [XR Development for Beginners](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Mastering GitHub Copilot for AI Paired Programming](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [Mastering GitHub Copilot for C#/.NET Developers](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Choose Your Own Copilot Adventure](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ 상표 고지

이 프로젝트에는 프로젝트, 제품 또는 서비스의 상표나 로고가 포함될 수 있습니다. Microsoft 상표나 로고의 사용은 [Microsoft의 상표 및 브랜드 가이드라인](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general)을 준수해야 하며, 승인된 경우에만 가능합니다. 수정된 버전에서 Microsoft 상표나 로고를 사용하는 경우 혼동을 초래하거나 Microsoft의 후원을 암시해서는 안 됩니다. 타사 상표나 로고의 사용은 해당 타사의 정책을 따라야 합니다.

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Originální dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.