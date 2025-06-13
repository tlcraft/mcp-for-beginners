<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3b97186cd9162b9fe9b90261e63e32d",
  "translation_date": "2025-06-13T14:33:31+00:00",
  "source_file": "README.md",
  "language_code": "sl"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.sl.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


Sledite tem korakom, da začnete uporabljati te vire:
1. **Razvezi repozitorij**: Kliknite [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Kloniraj repozitorij**: `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Pridruži se Azure AI Foundry Discordu in spoznaj strokovnjake ter druge razvijalce**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Podpora za več jezikov

#### Podprto preko GitHub Action (avtomatizirano in vedno posodobljeno)

# 🚀 Model Context Protocol (MCP) Curriculum for Beginners

## **Nauči MCP z praktičnimi primeri kode v C#, Java, JavaScript, Python in TypeScript**

## 🧠 Pregled učnega načrta Model Context Protocol

**Model Context Protocol (MCP)** je napreden okvir, zasnovan za standardizacijo interakcij med AI modeli in odjemalskimi aplikacijami. Ta odprtokodni učni načrt ponuja strukturirano pot učenja s praktičnimi primeri kode in resničnimi primeri uporabe v priljubljenih programskih jezikih, kot so C#, Java, JavaScript, TypeScript in Python.

Ne glede na to, ali ste AI razvijalec, sistemski arhitekt ali programski inženir, je ta vodič vaš celovit vir za obvladovanje osnov MCP in strategij njegove implementacije.

## 🔗 Uradni MCP viri

- 📘 [MCP Documentation](https://modelcontextprotocol.io/) – Podrobni vodiči in uporabniški priročniki  
- 📜 [MCP Specification](https://spec.modelcontextprotocol.io/) – Arhitektura protokola in tehnične reference  
- 🧑‍💻 [MCP GitHub Repository](https://github.com/modelcontextprotocol) – Odprtokodni SDK-ji, orodja in vzorci kode  

## 🧭 Celotna struktura učnega načrta MCP

| Ch | Naslov | Opis | Povezava |
|--|--|--|--|
| 00 | **Uvod v MCP** | Pregled Model Context Protocol in njegovega pomena v AI potekih dela, vključno s tem, kaj je Model Context Protocol, zakaj je standardizacija pomembna ter praktični primeri uporabe in koristi | [Introduction](./00-Introduction/README.md) |
| 01 | **Razlaga osnovnih pojmov** | Podrobna razlaga osnovnih konceptov MCP, vključno z arhitekturo klient-strežnik, ključnimi komponentami protokola in vzorci sporočanja | [Core Concepts](./01-CoreConcepts/README.md) |
| 02 | **Varnost v MCP** | Prepoznavanje varnostnih groženj v sistemih, ki temeljijo na MCP, tehnike in najboljše prakse za varno implementacijo | [Security](/02-Security/README.md) |
| 03 | **Začetek z MCP** | Nastavitev okolja in konfiguracija, ustvarjanje osnovnih MCP strežnikov in odjemalcev, integracija MCP z obstoječimi aplikacijami | [Getting Started](./03-GettingStarted/README.md) |
| 3.1 | **Prvi strežnik** | Nastavitev osnovnega strežnika z uporabo MCP protokola, razumevanje interakcije med strežnikom in odjemalcem ter testiranje strežnika | [First Server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Prvi odjemalec** | Nastavitev osnovnega odjemalca z uporabo MCP protokola, razumevanje interakcije med odjemalcem in strežnikom ter testiranje odjemalca | [First Client](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Odjemalec z LLM** | Nastavitev odjemalca, ki uporablja MCP protokol z velikim jezikovnim modelom (LLM) | [Client with LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Uporaba strežnika z Visual Studio Code** | Nastavitev Visual Studio Code za uporabo strežnikov preko MCP protokola | [Consuming a server with Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Ustvarjanje strežnika z uporabo SSE** | SSE nam pomaga izpostaviti strežnik na internetu. Ta del vam bo pomagal ustvariti strežnik z uporabo SSE | [Creating a server using SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **HTTP pretakanje** | Naučite se, kako implementirati HTTP pretakanje za prenos podatkov v realnem času med odjemalci in MCP strežniki | [HTTP Streaming](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **Uporaba AI orodij** | AI orodja so odlična pomoč pri upravljanju vašega AI in MCP poteka dela. | [Use AI Toolkit](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **Testiranje strežnika** | Testiranje je pomemben del razvojnega procesa. Ta del vam bo pomagal preizkusiti strežnik z več različnimi orodji. | [Testing your server](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **Implementacija strežnika** | Kako preiti iz lokalnega razvoja v produkcijo? Ta del vam bo pomagal razviti in implementirati vaš strežnik. | [Deploy your server](./03-GettingStarted/09-deployment/README.md) |
| 04 | **Praktična implementacija** | Uporaba SDK-jev v različnih jezikih, odpravljanje napak, testiranje in validacija, izdelava ponovno uporabnih predlog in potekov dela | [Practical Implementation](./04-PracticalImplementation/README.md) |
| 05 | **Napredne teme v MCP** | Večmodalni AI poteki dela in razširljivost, varne strategije skaliranja, MCP v poslovnih ekosistemih | [Advanced Topics](./05-AdvancedTopics/README.md) |
| 5.1 | **Integracija MCP z Azure** | Prikazuje integracijo z Azure | [MCP Azure integration](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Večmodalnost** | Prikaz dela z različnimi modalitetami, kot so slike in druge | [Multi modality](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 demo** | Minimalna Spring Boot aplikacija, ki prikazuje OAuth2 z MCP, tako kot pooblastitveni kot tudi strežnik virov. Prikazuje varno izdajo žetonov, zaščitene končne točke, implementacijo v Azure Container Apps in integracijo API upravljanja. | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Spoznajte več o root context in kako jih implementirati | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Usmerjanje** | Spoznajte različne vrste usmerjanja | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Vzorcevanje** | Naučite se, kako delati z vzorčenjem | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Skaliranje** | Spoznajte, kako skalirati MCP strežnike, vključno s horizontalnim in vertikalnim skaliranjem, optimizacijo virov in nastavitvami zmogljivosti | [Scaling](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Varnost** | Zavarujte svoj MCP strežnik, vključno z avtentikacijo, avtorizacijo in strategijami zaščite podatkov | [Security](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Python MCP strežnik in odjemalec, ki integrirata SerpAPI za iskanje v spletu, novicah, produktih in Q&A v realnem času. Prikazuje orkestracijo več orodij, integracijo zunanjih API-jev in robustno upravljanje napak | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Pretakanje v realnem času** | Pretakanje podatkov v realnem času je danes ključno, saj podjetja in aplikacije potrebujejo takojšen dostop do informacij za pravočasno odločanje. | [Realtime Streaming](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Iskanje v realnem času na spletu** | Kako MCP spreminja iskanje v realnem času na spletu z zagotavljanjem standardiziranega pristopa k upravljanju konteksta med AI modeli, iskalniki in aplikacijami. | [Realtime Web Search](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Prispevki skupnosti** | Kako prispevati k kodi in dokumentaciji, sodelovanje preko GitHub, izboljšave in povratne informacije, ki jih vodi skupnost | [Community Contributions](./06-CommunityContributions/README.md) |
| 07 | **초기 도입에서 얻은 통찰** | 실제 구현 사례와 성공 요인, MCP 기반 솔루션 구축 및 배포, 트렌드와 향후 로드맵 | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **MCP를 위한 모범 사례** | 성능 튜닝과 최적화, 내결함성 MCP 시스템 설계, 테스트 및 복원력 전략 | [Best Practices](./08-BestPractices/README.md) |
| 09 | **MCP 사례 연구** | MCP 솔루션 아키텍처 심층 분석, 배포 설계도 및 통합 팁, 주석이 달린 다이어그램과 프로젝트 진행 과정 | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **AI 워크플로 간소화: AI Toolkit과 함께하는 MCP 서버 구축** | MCP와 Microsoft AI Toolkit for VS Code를 결합한 종합 실습 워크숍. 기본 개념부터 맞춤 서버 개발, 실제 배포 전략까지 실용적인 모듈로 AI 모델과 현실 도구를 연결하는 지능형 애플리케이션 구축법을 배웁니다. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## 샘플 프로젝트

### 🧮 MCP 계산기 샘플 프로젝트:
<details>
  <summary><strong>언어별 코드 구현 탐색</strong></summary>

  - [C# MCP 서버 예제](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP 계산기](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP 데모](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP 서버](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP 예제](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 MCP 고급 계산기 프로젝트:
<details>
  <summary><strong>고급 샘플 탐색</strong></summary>

  - [고급 C# 샘플](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java 컨테이너 앱 예제](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript 고급 샘플](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python 복잡한 구현](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript 컨테이너 샘플](./04-PracticalImplementation/samples/typescript/README.md)

</details>

## 🎯 MCP 학습을 위한 필수 조건

이 커리큘럼을 최대한 활용하려면 다음을 갖추어야 합니다:

- C#, Java, 또는 Python 기본 지식
- 클라이언트-서버 모델과 API 이해
- (선택 사항) 머신러닝 개념에 대한 친숙함

## 📚 학습 가이드

효과적으로 저장소를 탐색할 수 있도록 포괄적인 [학습 가이드](./study_guide.md)가 제공됩니다. 가이드에는 다음이 포함됩니다:

- 전체 주제를 보여주는 시각적 커리큘럼 맵
- 각 저장소 섹션에 대한 상세 설명
- 샘플 프로젝트 활용 방법 안내
- 다양한 수준별 추천 학습 경로
- 학습을 보완할 추가 자료

## 🛠️ 이 커리큘럼을 효과적으로 활용하는 방법

각 수업에는 다음이 포함됩니다:

1. MCP 개념에 대한 명확한 설명  
2. 여러 언어로 된 실시간 코드 예제  
3. 실제 MCP 애플리케이션 구축을 위한 연습 문제  
4. 고급 학습자를 위한 추가 자료  

## 📜 라이선스 정보

이 콘텐츠는 **MIT 라이선스** 하에 제공됩니다. 약관은 [LICENSE](../../LICENSE)에서 확인하세요.

## 🤝 기여 가이드라인

이 프로젝트는 기여와 제안을 환영합니다. 대부분의 기여는 기여 권한을 보유하고 실제로 권한을 부여한다는 내용을 명시하는
Contributor License Agreement(CLA)에 동의해야 합니다. 자세한 내용은 <https://cla.opensource.microsoft.com>을 참조하세요.

풀 리퀘스트를 제출하면 CLA 봇이 자동으로 CLA 제출 여부를 확인하고 PR에 적절한 표시(예: 상태 검사, 댓글)를 추가합니다. 봇의 안내를 따라주세요. 모든 저장소에서 CLA 제출은 한 번만 하면 됩니다.

이 프로젝트는 [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/)를 채택했습니다.
자세한 내용은 [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/)를 확인하거나
추가 문의는 [opencode@microsoft.com](mailto:opencode@microsoft.com)으로 연락하세요.

## 🎒 기타 강의
우리 팀은 다른 강의도 제공합니다! 확인해 보세요:

- [AI Agents For Beginners](https://github.com/microsoft/ai-agents-for-beginners?WT.mc_id=academic-105485-koreyst)
- [.NET을 이용한 생성 AI 입문](https://github.com/microsoft/Generative-AI-for-beginners-dotnet?WT.mc_id=academic-105485-koreyst)
- [JavaScript를 이용한 생성 AI 입문](https://github.com/microsoft/generative-ai-with-javascript?WT.mc_id=academic-105485-koreyst)
- [생성 AI 입문](https://github.com/microsoft/generative-ai-for-beginners?WT.mc_id=academic-105485-koreyst)
- [초보자를 위한 ML](https://aka.ms/ml-beginners?WT.mc_id=academic-105485-koreyst)
- [초보자를 위한 데이터 과학](https://aka.ms/datascience-beginners?WT.mc_id=academic-105485-koreyst)
- [초보자를 위한 AI](https://aka.ms/ai-beginners?WT.mc_id=academic-105485-koreyst)
- [초보자를 위한 사이버보안](https://github.com/microsoft/Security-101??WT.mc_id=academic-96948-sayoung)
- [초보자를 위한 웹 개발](https://aka.ms/webdev-beginners?WT.mc_id=academic-105485-koreyst)
- [초보자를 위한 IoT](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)
- [초보자를 위한 XR 개발](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Mastering GitHub Copilot for AI Paired Programming](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [Mastering GitHub Copilot for C#/.NET Developers](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Choose Your Own Copilot Adventure](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Trademark Notice

Ehi projekṭṭēkku projects, products, allenkil servicesinu vendi trademarks allenkil logos undākām. Microsoft trademarks allenkil logos ude adhikārika upayōgam [Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general) anuṣṭhānamāyi kaṇṭiṭṭuṁ anusarikkān vēṇṭi varunnu. Microsoft trademarks allenkil logos ude upayōgam modified versionsil Microsoft ude sponsorshipinu confusion allenkil āśayappeṭṭuṁ varātte. Mūṟṟa party trademarks allenkil logos ude upayōgam ā mūṟṟa party ude niyamāṅṅaḷ anusaraṇamāṇ.

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za prevajanje z umetno inteligenco [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, upoštevajte, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvorno jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Za morebitne nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.