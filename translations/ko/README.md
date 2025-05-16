<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ceacbad0013938974fc0bf493e93f05b",
  "translation_date": "2025-05-16T17:10:24+00:00",
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
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/network)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


이 리소스를 사용하기 위해 다음 단계를 따라주세요:
1. **레포지토리 포크하기**: 클릭 [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/network)
2. **레포지토리 클론하기**: `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Microsoft Azure AI Foundry Discord에 가입하여 전문가와 다른 개발자들과 교류하기**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 다국어 지원

### GitHub Action을 통한 지원 (자동화 및 항상 최신 상태 유지)

[French](../fr/README.md) | [Spanish](../es/README.md) | [German](../de/README.md) | [Chinese (Simplified)](../zh/README.md)  [Japanese](../ja/README.md) | [Korean](./README.md) | [Polish](../pl/README.md)


# 🚀 초보자를 위한 Model Context Protocol (MCP) 커리큘럼 완전 가이드

## **C#, Java, JavaScript, Python, TypeScript 실습 코드 예제로 배우는 MCP**

## 🧠 Model Context Protocol 커리큘럼 개요

**Model Context Protocol (MCP)**은 AI 모델과 클라이언트 애플리케이션 간 상호작용을 표준화하기 위해 설계된 최첨단 프레임워크입니다. 이 오픈 소스 커리큘럼은 C#, Java, JavaScript, TypeScript, Python 등 인기 프로그래밍 언어를 아우르며 실용적인 코드 예제와 실제 사례를 포함한 체계적인 학습 경로를 제공합니다.

AI 개발자, 시스템 아키텍트, 소프트웨어 엔지니어 누구에게나 MCP 기본 개념과 구현 전략을 완벽하게 익힐 수 있는 종합 자료입니다.

## 🔗 공식 MCP 리소스

- 📘 [MCP Documentation](https://modelcontextprotocol.io/) – 자세한 튜토리얼과 사용자 가이드  
- 📜 [MCP Specification](https://spec.modelcontextprotocol.io/) – 프로토콜 아키텍처 및 기술 참고 자료  
- 🧑‍💻 [MCP GitHub Repository](https://github.com/modelcontextprotocol) – 오픈 소스 SDK, 도구 및 코드 샘플  

## 🧭 MCP 커리큘럼 전체 구조

### 📌 [MCP 소개](./00-Introduction/README.md)

- Model Context Protocol이란 무엇인가?
- AI 파이프라인에서 표준화가 중요한 이유
- MCP의 실제 활용 사례와 장점

### 🧩 [핵심 개념 설명](./01-CoreConcepts/README.md)

- MCP의 클라이언트-서버 아키텍처 이해하기
- 주요 프로토콜 구성 요소: 요청, 응답, 스키마
- MCP 메시징 및 데이터 교환 패턴

### 🔐 [MCP 보안](./02-Security/readme.md)

- MCP 기반 시스템에서 보안 위협 식별하기
- 구현 보안을 위한 기법과 모범 사례

### 🚀 [MCP 시작하기](./03-GettingStarted/README.md)

- 환경 설정 및 구성 방법
- 기본 MCP 서버 및 클라이언트 생성하기
- 기존 애플리케이션에 MCP 통합하기

#### 🧮 MCP 계산기 샘플 프로젝트:
<details>
  <summary><strong>언어별 코드 구현 살펴보기</strong></summary>

  - [C# MCP 서버 예제](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP 계산기](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP 데모](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP 서버](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP 예제](./03-GettingStarted/samples/typescript/README.md)

</details>
### 🛠️ [실무 구현](./04-PracticalImplementation/README.md)

- 다양한 언어에서 SDK 사용하기  
- 디버깅, 테스트, 검증  
- 재사용 가능한 프롬프트 템플릿과 워크플로우 제작  

#### 💡 MCP 고급 계산기 프로젝트:
<details>
  <summary><strong>고급 샘플 살펴보기</strong></summary>

  - [고급 C# 샘플](./04-PracticalImplementation/samples/csharp/README.md)  
  - [Java 컨테이너 앱 예제](./04-PracticalImplementation/samples/java/containerapp/README.md)  
  - [JavaScript 고급 샘플](./04-PracticalImplementation/samples/javascript/README.md)  
  - [Python 복잡한 구현](../../04-PracticalImplementation/samples/python/mcp_sample.py)  
  - [TypeScript 컨테이너 샘플](./04-PracticalImplementation/samples/typescript/README.md)  

</details>

### 🎓 [MCP 고급 주제](./05-AdvancedTopics/README.md)

- 멀티모달 AI 워크플로우와 확장성  
- 안전한 확장 전략  
- 엔터프라이즈 생태계에서의 MCP  

### 🌍 [커뮤니티 기여](./06-CommunityContributions/README.md)

- 코드와 문서 기여 방법  
- GitHub를 통한 협업  
- 커뮤니티 주도 개선과 피드백  

### 📈 [초기 도입 사례 인사이트](./07-CaseStudies/README.md)

- 실제 적용 사례와 성공 요인  
- MCP 기반 솔루션 구축 및 배포  
- 트렌드와 향후 로드맵  

### 📏 [MCP 모범 사례](./08-BestPractices/README.md)

- 성능 튜닝과 최적화  
- 장애 허용 MCP 시스템 설계  
- 테스트 및 복원력 전략  

### 📊 [MCP 사례 연구](./09-CaseStudy/Readme.md)

- MCP 솔루션 아키텍처 심층 분석  
- 배포 설계도와 통합 팁  
- 주석이 달린 다이어그램과 프로젝트 진행 과정  

## 🎯 MCP 학습을 위한 사전 조건

이 커리큘럼을 최대한 활용하려면 다음이 필요합니다:

- C#, Java, 또는 Python 기본 지식  
- 클라이언트-서버 모델과 API 이해  
- (선택 사항) 머신러닝 개념에 대한 친숙함  

## 🛠️ 이 커리큘럼을 효과적으로 사용하는 방법

이 가이드의 각 수업에는 다음이 포함되어 있습니다:

1. MCP 개념에 대한 명확한 설명  
2. 여러 언어로 된 실시간 코드 예제  
3. 실제 MCP 애플리케이션을 만드는 연습 문제  
4. 고급 학습자를 위한 추가 자료  

## 📜 라이선스 정보

이 콘텐츠는 **MIT 라이선스**에 따라 제공됩니다. 약관은 [LICENSE](../../LICENSE)에서 확인하세요.  

## 🤝 기여 가이드라인

이 프로젝트는 기여와 제안을 환영합니다. 대부분의 기여는 Contributor License Agreement(CLA)에 동의해야 하며, 이는 기여 권한을 보유하고 실제로 권리를 부여한다는 내용을 선언하는 문서입니다. 자세한 내용은 <https://cla.opensource.microsoft.com>에서 확인하세요.

풀 리퀘스트를 제출하면 CLA 봇이 자동으로 CLA 제출 필요 여부를 판단하고 PR에 상태 확인이나 댓글 등 적절한 표시를 합니다. 봇의 안내를 따라주시면 되며, 모든 저장소에서 한 번만 진행하면 됩니다.

이 프로젝트는 [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/)를 채택했습니다. 자세한 내용은 [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/)를 참고하거나 추가 질문이 있으면 [opencode@microsoft.com](mailto:opencode@microsoft.com)으로 연락하세요.

## ™️ 상표 안내

이 프로젝트에는 프로젝트, 제품, 서비스의 상표나 로고가 포함될 수 있습니다. Microsoft 상표 또는 로고의 사용은 [Microsoft의 상표 및 브랜드 가이드라인](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general)을 준수해야 합니다. 이 프로젝트의 수정 버전에서 Microsoft 상표나 로고를 사용하는 경우 혼동을 초래하거나 Microsoft의 후원을 암시해서는 안 됩니다. 제3자 상표나 로고 사용은 해당 제3자의 정책에 따릅니다.

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확한 내용이 포함될 수 있음을 유의해 주시기 바랍니다. 원본 문서의 원어가 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우, 전문 인간 번역을 권장합니다. 본 번역 사용으로 인한 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.