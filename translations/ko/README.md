<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9a14017adf28f7440f20c2d5e7f1d0f8",
  "translation_date": "2025-06-17T15:26:00+00:00",
  "source_file": "README.md",
  "language_code": "ko"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.ko.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


이 리소스를 사용하기 시작하려면 다음 단계를 따라주세요:
1. **저장소 포크하기**: 클릭 [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **저장소 클론하기**: `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Azure AI Foundry Discord에 참여하여 전문가 및 다른 개발자들과 만나보세요**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 다국어 지원

#### GitHub Action을 통해 지원 (자동화 및 항상 최신 상태 유지)

# 🚀 초보자를 위한 Model Context Protocol (MCP) 커리큘럼

## **C#, Java, JavaScript, Python, TypeScript로 배우는 MCP 실습 코드 예제**

## 🧠 Model Context Protocol 커리큘럼 개요

**Model Context Protocol (MCP)**은 AI 모델과 클라이언트 애플리케이션 간 상호작용을 표준화하기 위해 고안된 최신 프레임워크입니다. 이 오픈소스 커리큘럼은 C#, Java, JavaScript, TypeScript, Python 등 인기 있는 프로그래밍 언어를 아우르는 실습 예제와 실제 사례를 포함한 체계적인 학습 경로를 제공합니다.

AI 개발자, 시스템 아키텍트, 소프트웨어 엔지니어 누구나 MCP의 기본 개념과 구현 전략을 마스터할 수 있는 종합 가이드입니다.

## 🔗 공식 MCP 리소스

- 📘 [MCP 문서](https://modelcontextprotocol.io/) – 상세한 튜토리얼과 사용자 가이드  
- 📜 [MCP 명세](https://spec.modelcontextprotocol.io/) – 프로토콜 아키텍처 및 기술 참고자료  
- 🧑‍💻 [MCP GitHub 저장소](https://github.com/modelcontextprotocol) – 오픈소스 SDK, 도구, 코드 샘플  

## 🧭 MCP 커리큘럼 전체 구조

| Ch | 제목 | 설명 | 링크 |
|--|--|--|--|
| 00 | **MCP 소개** | Model Context Protocol 개요와 AI 파이프라인에서의 중요성, MCP란 무엇인지, 표준화가 왜 필요한지, 실용적인 사례와 이점 | [소개](./00-Introduction/README.md) |
| 01 | **핵심 개념 설명** | MCP의 핵심 개념 심층 탐구, 클라이언트-서버 아키텍처, 주요 프로토콜 구성요소, 메시징 패턴 | [핵심 개념](./01-CoreConcepts/README.md) |
| 02 | **MCP 보안** | MCP 기반 시스템의 보안 위협 파악, 보안 구현을 위한 기법과 모범 사례 | [보안](./02-Security/README.md) |
| 03 | **MCP 시작하기** | 환경 설정과 구성, 기본 MCP 서버 및 클라이언트 생성, 기존 애플리케이션과 MCP 통합 | [시작하기](./03-GettingStarted/README.md) |
| 3.1 | **첫 번째 서버** | MCP 프로토콜을 사용해 기본 서버 설정, 서버-클라이언트 상호작용 이해 및 서버 테스트 | [첫 번째 서버](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **첫 번째 클라이언트** | MCP 프로토콜을 사용해 기본 클라이언트 설정, 클라이언트-서버 상호작용 이해 및 클라이언트 테스트 | [첫 번째 클라이언트](./03-GettingStarted/02-client/README.md) |
| 3.3 | **LLM과 함께하는 클라이언트** | MCP 프로토콜을 사용해 대형 언어 모델(LLM)과 연동된 클라이언트 설정 | [LLM 클라이언트](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Visual Studio Code로 서버 사용하기** | MCP 프로토콜을 사용하는 서버를 Visual Studio Code에서 활용하는 방법 | [VS Code로 서버 사용하기](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **SSE를 이용한 서버 생성** | SSE를 통해 서버를 인터넷에 노출하는 방법, SSE 기반 서버 생성 가이드 | [SSE 서버 생성](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **HTTP 스트리밍** | 클라이언트와 MCP 서버 간 실시간 데이터 전송을 위한 HTTP 스트리밍 구현 방법 | [HTTP 스트리밍](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **AI 툴킷 사용하기** | AI 툴킷은 AI 및 MCP 워크플로우 관리를 돕는 훌륭한 도구입니다. | [AI 툴킷 사용](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **서버 테스트하기** | 테스트는 개발 과정에서 중요한 부분입니다. 다양한 도구를 활용한 테스트 방법 안내 | [서버 테스트](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **서버 배포하기** | 로컬 개발에서 프로덕션까지, 서버 개발과 배포 방법 | [서버 배포](./03-GettingStarted/09-deployment/README.md) |
| 04 | **실전 구현** | 다양한 언어별 SDK 활용, 디버깅, 테스트 및 검증, 재사용 가능한 프롬프트 템플릿과 워크플로우 제작 | [실전 구현](./04-PracticalImplementation/README.md) |
| 05 | **MCP 고급 주제** | 멀티모달 AI 워크플로우와 확장성, 안전한 확장 전략, 기업 생태계 내 MCP 적용 | [고급 주제](./05-AdvancedTopics/README.md) |
| 5.1 | **Azure와 MCP 통합** | Azure와의 통합 방법 소개 | [Azure 통합](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **멀티모달리티** | 이미지 등 다양한 모달리티 다루기 | [멀티모달리티](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **MCP OAuth2 데모** | Spring Boot 최소 앱으로 MCP OAuth2 구현, 권한 서버와 리소스 서버 역할, 안전한 토큰 발급, 보호된 엔드포인트, Azure Container Apps 배포, API 관리 통합 시연 | [OAuth2 데모](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **루트 컨텍스트** | 루트 컨텍스트에 대한 이해와 구현 방법 | [루트 컨텍스트](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **라우팅** | 다양한 라우팅 유형 학습 | [라우팅](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **샘플링** | 샘플링 작업 방법 배우기 | [샘플링](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **스케일링** | MCP 서버의 수평 및 수직 확장 전략, 자원 최적화, 성능 튜닝 | [스케일링](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **보안** | 인증, 권한 부여, 데이터 보호 전략을 포함한 MCP 서버 보안 강화 | [보안](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **웹 검색 MCP** | SerpAPI와 통합된 Python MCP 서버 및 클라이언트로 실시간 웹, 뉴스, 상품 검색 및 Q&A 구현. 멀티 툴 오케스트레이션, 외부 API 통합, 견고한 오류 처리 시연 | [웹 검색 MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **실시간 스트리밍** | 오늘날 데이터 중심 환경에서 즉각적인 정보 접근이 필요한 비즈니스와 애플리케이션을 위한 실시간 데이터 스트리밍 필수성 | [실시간 스트리밍](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **실시간 웹 검색** | MCP가 AI 모델, 검색 엔진, 애플리케이션 간 컨텍스트 관리를 표준화하여 실시간 웹 검색을 혁신하는 방법 | [실시간 웹 검색](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **커뮤니티 기여** | 코드 및 문서 기여 방법, GitHub 협업, 커뮤니티 주도 개선 및 피드백 | [커뮤니티 기여](./06-CommunityContributions/README.md) |
| 07 | **초기 도입에서 얻은 인사이트** | 실제 구현 사례와 성공 요인, MCP 기반 솔루션 구축 및 배포, 트렌드와 향후 로드맵 | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **MCP를 위한 모범 사례** | 성능 조정 및 최적화, 내결함성 MCP 시스템 설계, 테스트 및 복원력 전략 | [Best Practices](./08-BestPractices/README.md) |
| 09 | **MCP 사례 연구** | MCP 솔루션 아키텍처 심층 분석, 배포 청사진 및 통합 팁, 주석이 달린 다이어그램과 프로젝트 워크스루 | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **AI 워크플로우 간소화: AI Toolkit으로 MCP 서버 구축하기** | MCP와 Microsoft의 AI Toolkit for VS Code를 결합한 종합 실습 워크숍입니다. 기본 개념, 맞춤형 서버 개발, 프로덕션 배포 전략을 다루는 실습 모듈을 통해 AI 모델과 실제 도구를 연결하는 지능형 애플리케이션 구축 방법을 배울 수 있습니다. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

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
  <summary><strong>고급 샘플 탐색하기</strong></summary>

  - [고급 C# 샘플](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java 컨테이너 앱 예제](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript 고급 샘플](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python 복잡한 구현](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript 컨테이너 샘플](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 MCP 학습을 위한 전제 조건

이 커리큘럼을 최대한 활용하려면 다음이 필요합니다:

- C#, Java 또는 Python의 기본 지식
- 클라이언트-서버 모델 및 API에 대한 이해
- (선택 사항) 머신러닝 개념에 대한 친숙함

## 📚 학습 가이드

이 저장소를 효과적으로 탐색할 수 있도록 종합적인 [학습 가이드](./study_guide.md)가 제공됩니다. 가이드에는 다음이 포함됩니다:

- 다루는 모든 주제를 시각화한 커리큘럼 맵
- 각 저장소 섹션에 대한 상세 설명
- 샘플 프로젝트 활용 방법 안내
- 다양한 수준에 맞춘 추천 학습 경로
- 학습 여정을 보완할 추가 자료

## 🛠️ 이 커리큘럼을 효과적으로 활용하는 방법

각 강의에는 다음이 포함되어 있습니다:

1. MCP 개념에 대한 명확한 설명  
2. 여러 언어로 된 실시간 코드 예제  
3. 실제 MCP 애플리케이션을 구축하는 연습 문제  
4. 심화 학습자를 위한 추가 자료  

## 📜 라이선스 정보

이 콘텐츠는 **MIT 라이선스** 하에 제공됩니다. 이용 약관은 [LICENSE](../../LICENSE)를 참조하세요.

## 🤝 기여 가이드라인

이 프로젝트는 기여와 제안을 환영합니다. 대부분의 기여는 기여자가 자신의 기여에 대한 권리를 보유하고 있으며 실제로 해당 권리를 우리에게 부여한다는 내용의 Contributor License Agreement(CLA)에 동의해야 합니다. 자세한 내용은 <https://cla.opensource.microsoft.com>를 참고하세요.

풀 리퀘스트를 제출하면 CLA 봇이 자동으로 CLA 제출 필요 여부를 판단하고 PR에 적절한 표시(예: 상태 검사, 댓글)를 합니다. 봇이 안내하는 절차를 따라주시면 됩니다. CLA 제출은 해당 CLA를 사용하는 모든 저장소에서 한 번만 하면 됩니다.

이 프로젝트는 [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/)를 채택했습니다. 자세한 내용은 [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/)를 확인하거나 추가 질문 및 의견은 [opencode@microsoft.com](mailto:opencode@microsoft.com)으로 문의하세요.

## 🎒 기타 과정
우리 팀은 다른 과정도 제공합니다! 다음을 확인해 보세요:

- [AI Agents For Beginners](https://github.com/microsoft/ai-agents-for-beginners?WT.mc_id=academic-105485-koreyst)
- [.NET을 활용한 초보자를 위한 생성형 AI](https://github.com/microsoft/Generative-AI-for-beginners-dotnet?WT.mc_id=academic-105485-koreyst)
- [JavaScript를 활용한 초보자를 위한 생성형 AI](https://github.com/microsoft/generative-ai-with-javascript?WT.mc_id=academic-105485-koreyst)
- [초보자를 위한 생성형 AI](https://github.com/microsoft/generative-ai-for-beginners?WT.mc_id=academic-105485-koreyst)
- [초보자를 위한 ML](https://aka.ms/ml-beginners?WT.mc_id=academic-105485-koreyst)
- [초보자를 위한 데이터 과학](https://aka.ms/datascience-beginners?WT.mc_id=academic-105485-koreyst)
- [초보자를 위한 AI](https://aka.ms/ai-beginners?WT.mc_id=academic-105485-koreyst)
- [초보자를 위한 사이버 보안](https://github.com/microsoft/Security-101??WT.mc_id=academic-96948-sayoung)
- [초보자를 위한 웹 개발](https://aka.ms/webdev-beginners?WT.mc_id=academic-105485-koreyst)
- [초보자를 위한 IoT](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)
- [초보자를 위한 XR 개발](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)
- [AI 페어 프로그래밍을 위한 GitHub Copilot 완전 정복](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [C#/.NET 개발자를 위한 GitHub Copilot 완전 정복](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [나만의 Copilot 모험 선택하기](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ 상표 고지

이 프로젝트에는 프로젝트, 제품 또는 서비스의 상표나 로고가 포함될 수 있습니다. Microsoft 상표나 로고의 허가된 사용은
[Microsoft 상표 및 브랜드 가이드라인](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general)을 준수해야 합니다.
이 프로젝트의 수정된 버전에서 Microsoft 상표나 로고를 사용하는 경우 혼동을 일으키거나 Microsoft의 후원을 암시해서는 안 됩니다.
제3자 상표나 로고 사용은 해당 제3자의 정책을 따라야 합니다.

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 노력하고 있으나, 자동 번역에는 오류나 부정확성이 포함될 수 있음을 양지해 주시기 바랍니다. 원본 문서는 해당 언어의 원문이 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우, 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.