<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c7fbf0cdaa44b3245daff0c8bb4f439e",
  "translation_date": "2025-06-11T16:16:42+00:00",
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


Segui questi passaggi per iniziare a utilizzare queste risorse:
1. **Forka il repository**: clicca su [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Clona il repository**: `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Unisciti al Discord di Azure AI Foundry e incontra esperti e altri sviluppatori**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Supporto multilingue

#### Supportato tramite GitHub Action (automatizzato e sempre aggiornato)

# 🚀 Model Context Protocol (MCP) Müfredatı Yeni Başlayanlar İçin

## **C#, Java, JavaScript, Python ve TypeScript ile Uygulamalı MCP Öğrenin**

## 🧠 Model Context Protocol Müfredatına Genel Bakış

**Model Context Protocol (MCP)**, yapay zeka modelleri ile istemci uygulamaları arasındaki etkileşimleri standartlaştırmak için tasarlanmış son teknoloji bir çerçevedir. Bu açık kaynak müfredat, popüler programlama dilleri arasında C#, Java, JavaScript, TypeScript ve Python dahil olmak üzere, pratik kod örnekleri ve gerçek dünya kullanım senaryolarıyla yapılandırılmış bir öğrenme yolu sunar.

İster bir yapay zeka geliştiricisi, sistem mimarı, ister yazılım mühendisi olun, bu rehber MCP temellerini ve uygulama stratejilerini ustalıkla öğrenmeniz için kapsamlı bir kaynaktır.

## 🔗 Resmi MCP Kaynakları

- 📘 [MCP Documentation](https://modelcontextprotocol.io/) – Detaylı eğitimler ve kullanıcı kılavuzları  
- 📜 [MCP Specification](https://spec.modelcontextprotocol.io/) – Protokol mimarisi ve teknik referanslar  
- 🧑‍💻 [MCP GitHub Repository](https://github.com/modelcontextprotocol) – Açık kaynak SDK'lar, araçlar ve kod örnekleri  

## 🧭 Tam MCP Müfredat Yapısı

| Ch | Başlık | Açıklama | Link |
|--|--|--|--|
| 00 | **MCP'ye Giriş** | Model Context Protocol'un genel bakışı ve AI iş akışlarındaki önemi, MCP'nin ne olduğu, neden standartlaşmanın önemli olduğu ve pratik kullanım örnekleri ile faydaları | [Introduction](./00-Introduction/README.md) |
| 01 | **Temel Kavramlar Açıklaması** | MCP'nin temel kavramlarının derinlemesine incelenmesi, istemci-sunucu mimarisi, protokolün ana bileşenleri ve mesajlaşma kalıpları | [Core Concepts](./01-CoreConcepts/README.md) |
| 02 | **MCP'de Güvenlik** | MCP tabanlı sistemlerde güvenlik tehditlerinin tanımlanması, güvenli uygulamalar için teknikler ve en iyi uygulamalar | [Security](/02-Security/README.md) |
| 03 | **MCP ile Başlarken** | Ortam kurulumu ve yapılandırması, temel MCP sunucu ve istemcilerinin oluşturulması, MCP'nin mevcut uygulamalarla entegrasyonu | [Getting Started](./03-GettingStarted/README.md) |
| 3.1 | **İlk sunucu** | MCP protokolü kullanarak temel bir sunucu kurulumu, sunucu-istemci etkileşiminin anlaşılması ve sunucunun test edilmesi | [First Server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **İlk istemci** | MCP protokolü kullanarak temel bir istemci kurulumu, istemci-sunucu etkileşiminin anlaşılması ve istemcinin test edilmesi | [First Client](./03-GettingStarted/02-client/README.md) |
| 3.3 | **LLM ile istemci** | MCP protokolü ile Büyük Dil Modeli (LLM) kullanan bir istemci kurulumu | [Client with LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Visual Studio Code ile sunucu kullanımı** | MCP protokolü kullanarak Visual Studio Code’un sunucuları tüketmek için ayarlanması | [Consuming a server with Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **SSE kullanarak sunucu oluşturma** | SSE, sunucuyu internete açmamıza yardımcı olur. Bu bölüm SSE kullanarak sunucu oluşturmanıza yardımcı olacak | [Creating a server using SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **AI Toolkit kullanımı** | AI Toolkit, AI ve MCP iş akışınızı yönetmenize yardımcı olacak harika bir araçtır. | [Use AI Toolkit](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Sunucunuzu test etmek** | Test etmek geliştirme sürecinin önemli bir parçasıdır. Bu bölüm çeşitli araçları kullanarak test yapmanıza yardımcı olacak. | [Testing your server](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Sunucunuzu dağıtmak** | Yerel geliştirmeden üretime nasıl geçilir? Bu bölüm sunucunuzu geliştirip dağıtmanıza yardımcı olacak. | [Deploy your server](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Pratik Uygulama** | Farklı dillerde SDK kullanımı, hata ayıklama, test ve doğrulama, yeniden kullanılabilir prompt şablonları ve iş akışları oluşturma | [Practical Implementation](./04-PracticalImplementation/README.md) |
| 05 | **MCP'de İleri Konular** | Çok modlu AI iş akışları ve genişletilebilirlik, güvenli ölçeklendirme stratejileri, MCP'nin kurumsal ekosistemlerde kullanımı | [Advanced Topics](./05-AdvancedTopics/README.md) |
| 5.1 | **Azure ile MCP Entegrasyonu** | Azure ile entegrasyon gösterimi | [MCP Azure integration](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Çoklu modalite** | Görüntüler ve diğer modlar gibi farklı modalitelerle çalışma gösterimi | [Multi modality](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 Demo** | MCP ile OAuth2 gösteren minimal Spring Boot uygulaması, hem Yetkilendirme hem de Kaynak Sunucusu olarak. Güvenli token verme, korumalı uç noktalar, Azure Container Apps dağıtımı ve API Yönetimi entegrasyonunu gösterir. | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Kök Bağlamlar** | Kök bağlamlar hakkında daha fazla bilgi ve nasıl uygulanacağı | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Yönlendirme** | Farklı yönlendirme türlerini öğrenin | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Örnekleme** | Örnekleme ile nasıl çalışılacağını öğrenin | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Ölçeklendirme** | MCP sunucularını yatay ve dikey ölçeklendirme stratejileri, kaynak optimizasyonu ve performans ayarlamaları dahil olmak üzere ölçeklendirme hakkında bilgi edinin | [Scaling](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Güvenlik** | MCP sunucunuzu kimlik doğrulama, yetkilendirme ve veri koruma stratejileri ile güvence altına alın | [Security](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP sunucu ve istemcisi, SerpAPI ile gerçek zamanlı web, haber, ürün araması ve SSS entegrasyonu. Çoklu araç orkestrasyonu, dış API entegrasyonu ve sağlam hata yönetimini gösterir | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Gerçek Zamanlı Akış** | Günümüzün veri odaklı dünyasında gerçek zamanlı veri akışı çok önemli hale geldi; işletmeler ve uygulamalar zamanında kararlar almak için anlık bilgiye ihtiyaç duyar. | [Realtime Streaming](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 06 | **Topluluk Katkıları** | Kod ve doküman katkısı nasıl yapılır, GitHub üzerinden iş birliği, topluluk odaklı geliştirmeler ve geri bildirim | [Community Contributions](./06-CommunityContributions/README.md) |
| 07 | **Erken Benimsemeden Alınan Dersler** | Gerçek dünya uygulamaları ve işe yarayanlar, MCP tabanlı çözümler geliştirme ve dağıtma, trendler ve geleceğe dair yol haritası | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **MCP için En İyi Uygulamalar** | Performans ayarı ve optimizasyon, hata toleranslı MCP sistemleri tasarımı, test ve dayanıklılık stratejileri | [Best Practices](./08-BestPractices/README.md) |
| 09 | **MCP 사례 연구** | MCP 솔루션 아키텍처, 배포 청사진 및 통합 팁에 대한 심층 분석, 주석이 달린 다이어그램과 프로젝트 워크스루 | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **AI 워크플로 간소화: AI Toolkit과 함께 MCP 서버 구축하기** | MCP와 Microsoft의 AI Toolkit for VS Code를 결합한 종합 실습 워크숍. 기본 개념, 맞춤형 서버 개발, 프로덕션 배포 전략을 다루는 실용 모듈을 통해 AI 모델과 실제 도구를 연결하는 지능형 애플리케이션 구축 방법을 배웁니다. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## 샘플 프로젝트

### 🧮 MCP 계산기 샘플 프로젝트:
<details>
  <summary><strong>언어별 코드 구현 살펴보기</strong></summary>

  - [C# MCP 서버 예제](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP 계산기](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP 데모](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP 서버](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP 예제](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP 고급 계산기 프로젝트:
<details>
  <summary><strong>고급 샘플 살펴보기</strong></summary>

  - [고급 C# 샘플](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java 컨테이너 앱 예제](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript 고급 샘플](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python 복잡한 구현](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript 컨테이너 샘플](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 MCP 학습을 위한 필수 조건

이 커리큘럼을 최대한 활용하려면 다음을 갖추어야 합니다:

- C#, Java 또는 Python의 기본 지식
- 클라이언트-서버 모델과 API에 대한 이해
- (선택 사항) 머신러닝 개념에 대한 친숙함

## 📚 학습 가이드

이 저장소를 효과적으로 탐색할 수 있도록 포괄적인 [학습 가이드](./study_guide.md)가 제공됩니다. 가이드에는 다음이 포함됩니다:

- 모든 주제를 보여주는 시각적 커리큘럼 맵
- 각 저장소 섹션에 대한 상세 분류
- 샘플 프로젝트 활용 방법 안내
- 다양한 수준에 맞춘 추천 학습 경로
- 학습을 보완할 추가 자료

## 🛠️ 이 커리큘럼을 효과적으로 활용하는 방법

이 가이드의 각 수업에는 다음이 포함됩니다:

1. MCP 개념에 대한 명확한 설명  
2. 여러 언어로 된 실시간 코드 예제  
3. 실제 MCP 애플리케이션 구축을 위한 연습 문제  
4. 고급 학습자를 위한 추가 자료  

## 📜 라이선스 정보

이 콘텐츠는 **MIT 라이선스** 하에 제공됩니다. 이용 약관은 [LICENSE](../../LICENSE)에서 확인하세요.

## 🤝 기여 가이드라인

이 프로젝트는 기여와 제안을 환영합니다. 대부분의 기여는 기여자가 기여물 사용 권한을 보유하고 있음을 선언하는
Contributor License Agreement(CLA)에 동의해야 합니다. 자세한 내용은 <https://cla.opensource.microsoft.com>을 참조하세요.

풀 리퀘스트를 제출하면 CLA 봇이 자동으로 CLA 제출 필요 여부를 판단하고 PR에 적절한 표시(예: 상태 검사, 댓글)를 추가합니다. 봇이 제공하는 지침을 따르면 됩니다. 모든 저장소에서 한 번만 진행하면 됩니다.

이 프로젝트는 [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/)를 채택했습니다.
자세한 내용은 [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/)를 확인하거나
추가 질문이나 의견은 [opencode@microsoft.com](mailto:opencode@microsoft.com)으로 문의하세요.

## 🎒 기타 과정
우리 팀은 다른 과정도 제공합니다! 확인해 보세요:

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


## ™️ 공지된 상표

이 프로젝트에는 프로젝트, 제품 또는 서비스의 상표나 로고가 포함될 수 있습니다. Microsoft 상표나 로고의 승인된 사용은
[Microsoft의 상표 및 브랜드 가이드라인](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general)을 준수해야 합니다.
이 프로젝트의 수정된 버전에서 Microsoft 상표나 로고를 사용할 경우 혼동을 초래하거나 Microsoft의 후원을 암시해서는 안 됩니다.
제3자 상표나 로고의 사용은 해당 제3자의 정책을 따라야 합니다.

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Originální dokument v jeho původním jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo chybné výklady vzniklé použitím tohoto překladu.