<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "537bdb70a3ce1e8bd86c83c74bf98c77",
  "translation_date": "2025-05-16T14:23:00+00:00",
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


이 리소스를 사용해 시작하려면 다음 단계를 따라주세요:
1. **저장소 포크하기**: 클릭 [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/network)
2. **저장소 클론하기**: `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Microsoft Azure AI Foundry Discord에 참여하여 전문가 및 개발자들과 소통하기**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 다국어 지원

#### GitHub Action을 통해 지원 (자동화 및 항상 최신 상태 유지)


# 🚀 초보자를 위한 Model Context Protocol (MCP) 커리큘럼 완벽 가이드

## **C#, Java, JavaScript, Python, TypeScript로 배우는 MCP 실습 코드 예제**

## 🧠 Model Context Protocol 커리큘럼 개요

**Model Context Protocol (MCP)**은 AI 모델과 클라이언트 애플리케이션 간 상호작용을 표준화하기 위해 설계된 최첨단 프레임워크입니다. 이 오픈소스 커리큘럼은 C#, Java, JavaScript, TypeScript, Python 등 인기 있는 프로그래밍 언어별로 실습 코드와 실제 사례를 포함한 체계적인 학습 경로를 제공합니다.

AI 개발자, 시스템 아키텍트, 소프트웨어 엔지니어 등 누구든 MCP의 기본 개념과 구현 전략을 마스터할 수 있는 종합 자료입니다.

## 🔗 공식 MCP 리소스

- 📘 [MCP 문서](https://modelcontextprotocol.io/) – 상세 튜토리얼 및 사용자 가이드  
- 📜 [MCP 사양서](https://spec.modelcontextprotocol.io/) – 프로토콜 아키텍처 및 기술 참조  
- 🧑‍💻 [MCP GitHub 저장소](https://github.com/modelcontextprotocol) – 오픈소스 SDK, 도구, 코드 샘플  

## 🧭 MCP 커리큘럼 전체 구성

### 📌 [MCP 소개](./00-Introduction/README.md)

- Model Context Protocol이란 무엇인가?
- AI 파이프라인에서 표준화가 중요한 이유
- MCP의 실제 활용 사례와 장점

### 🧩 [핵심 개념 설명](./01-CoreConcepts/README.md)

- MCP의 클라이언트-서버 아키텍처 이해하기
- 주요 프로토콜 구성 요소: 요청, 응답, 스키마
- MCP 메시징과 데이터 교환 패턴

### 🔐 [MCP 보안](./02-Security/readme.md)

- MCP 기반 시스템의 보안 위협 식별
- 안전한 구현을 위한 기법과 모범 사례

### 🚀 [MCP 시작하기](./03-GettingStarted/README.md)

- 환경 설정과 구성
- 기본 MCP 서버 및 클라이언트 만들기
- 기존 애플리케이션과 MCP 통합하기

#### 🧮 MCP 계산기 샘플 프로젝트:
<details>
  <summary><strong>언어별 코드 구현 살펴보기</strong></summary>

  - [C# MCP 서버 예제](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP 계산기](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP 데모](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP 서버](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP 예제](./03-GettingStarted/samples/typescript/README.md)

</details>

### 🛠️ [실전 구현](./04-PracticalImplementation/README.md)

- 다양한 언어용 SDK 활용법
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
### 🌍 [Community Contributions](./06-CommunityContributions/README.md)

- 코드와 문서 기여 방법  
- GitHub를 통한 협업  
- 커뮤니티 주도 개선 및 피드백  

### 📈 [Insights from Early Adoption](./07-CaseStudies/README.md)

- 실제 적용 사례와 성공 요인  
- MCP 기반 솔루션 구축 및 배포  
- 트렌드와 향후 로드맵  

### 📏 [Best Practices for MCP](./08-BestPractices/README.md)

- 성능 조정 및 최적화  
- 내결함성 MCP 시스템 설계  
- 테스트 및 복원력 전략  

### 📊 [MCP Case Studies](./09-CaseStudy/Readme.md)

- MCP 솔루션 아키텍처 심층 분석  
- 배포 설계도 및 통합 팁  
- 주석이 포함된 다이어그램과 프로젝트 안내  

## 🎯 Prerequisites for Learning MCP

이 커리큘럼을 최대한 활용하려면 다음 사항을 갖추는 것이 좋습니다:

- C#, Java 또는 Python의 기본 지식  
- 클라이언트-서버 모델과 API 이해  
- (선택 사항) 머신러닝 개념에 대한 친숙함  

## 🛠️ How to Use This Curriculum Effectively

이 가이드의 각 수업에는 다음이 포함되어 있습니다:

1. MCP 개념에 대한 명확한 설명  
2. 여러 언어로 된 실시간 코드 예제  
3. 실제 MCP 애플리케이션을 만드는 연습 문제  
4. 심화 학습자를 위한 추가 자료  

## 📜 License Information

이 콘텐츠는 **MIT License** 하에 제공됩니다. 이용 약관은 [LICENSE](../../LICENSE)를 참고하세요.  

## 🤝 Contribution Guidelines

이 프로젝트는 기여와 제안을 환영합니다. 대부분의 기여는 기여자가 기여물 사용 권한을 실제로 보유하고 있음을 선언하는 Contributor License Agreement(CLA)에 동의해야 합니다. 자세한 내용은 <https://cla.opensource.microsoft.com>을 참조하세요.

풀 리퀘스트를 제출하면 CLA 봇이 자동으로 CLA 제출 필요 여부를 판단하고 PR에 적절한 표시(예: 상태 검사, 댓글)를 추가합니다. 봇이 제공하는 지침을 따라주시면 됩니다. CLA는 모든 저장소에서 한 번만 제출하면 됩니다.

이 프로젝트는 [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/)를 채택하고 있습니다. 자세한 내용은 [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/)를 참고하거나 추가 질문이나 의견이 있을 경우 [opencode@microsoft.com](mailto:opencode@microsoft.com)으로 연락해 주세요.

## ™️ Trademark Notice

이 프로젝트에는 프로젝트, 제품 또는 서비스에 대한 상표나 로고가 포함될 수 있습니다. Microsoft 상표나 로고의 권한 있는 사용은 [Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general)을 준수해야 합니다. 수정된 버전의 프로젝트에서 Microsoft 상표나 로고를 사용하는 경우 혼동을 일으키거나 Microsoft의 후원을 암시해서는 안 됩니다. 제3자 상표나 로고 사용은 해당 제3자의 정책을 따라야 합니다.

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 노력하고 있으나, 자동 번역에는 오류나 부정확성이 포함될 수 있음을 유의해 주시기 바랍니다. 원문 문서가 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우, 전문적인 인간 번역을 권장합니다. 이 번역 사용으로 인한 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.