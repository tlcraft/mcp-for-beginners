<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-16T14:54:54+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ko"
}
-->
## 시작하기  

이 섹션은 여러 개의 강의로 구성되어 있습니다:

- **-1- 당신의 첫 번째 서버**, 첫 번째 강의에서는 첫 번째 서버를 만드는 방법과 검사 도구(inspector tool)를 사용해 서버를 테스트하고 디버깅하는 방법을 배웁니다, [강의로 이동](/03-GettingStarted/01-first-server/README.md)

- **-2- 클라이언트**, 이 강의에서는 서버에 연결할 수 있는 클라이언트를 작성하는 방법을 배웁니다, [강의로 이동](/03-GettingStarted/02-client/README.md)

- **-3- LLM을 활용한 클라이언트**, 클라이언트에 LLM을 추가해 서버와 "협상"하며 동작을 결정하는 더 나은 방법을 배웁니다, [강의로 이동](/03-GettingStarted/03-llm-client/README.md)

- **-4- Visual Studio Code에서 GitHub Copilot Agent 모드의 서버 사용하기**, 여기서는 Visual Studio Code 내에서 MCP Server를 실행하는 방법을 살펴봅니다, [강의로 이동](/03-GettingStarted/04-vscode/README.md)

- **-5- SSE(Server Sent Events)를 이용한 데이터 수신**, SSE는 서버가 클라이언트에 HTTP를 통해 실시간 업데이트를 푸시할 수 있게 하는 표준입니다, [강의로 이동](/03-GettingStarted/05-sse-server/README.md)

- **-6- VSCode용 AI Toolkit 활용하기**, MCP 클라이언트와 서버를 사용하고 테스트하는 방법을 배웁니다, [강의로 이동](/03-GettingStarted/06-aitk/README.md)

- **-7- 테스트**, 이 장에서는 서버와 클라이언트를 다양한 방식으로 테스트하는 방법에 집중합니다, [강의로 이동](/03-GettingStarted/07-testing/README.md)

- **-8- 배포**, MCP 솔루션을 배포하는 여러 가지 방법을 살펴봅니다, [강의로 이동](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol(MCP)은 애플리케이션이 LLM에 컨텍스트를 제공하는 방식을 표준화한 오픈 프로토콜입니다. MCP는 AI 애플리케이션을 위한 USB-C 포트처럼, AI 모델을 다양한 데이터 소스와 도구에 연결하는 표준화된 방법을 제공합니다.

## 학습 목표

이 강의를 마치면 다음을 할 수 있습니다:

- C#, Java, Python, TypeScript, JavaScript에서 MCP 개발 환경을 설정하기
- 커스텀 기능(리소스, 프롬프트, 도구)을 갖춘 기본 MCP 서버를 구축하고 배포하기
- MCP 서버에 연결하는 호스트 애플리케이션 만들기
- MCP 구현을 테스트하고 디버깅하기
- 일반적인 설정 문제와 해결책 이해하기
- 인기 있는 LLM 서비스와 MCP 구현 연결하기

## MCP 환경 설정하기

MCP 작업을 시작하기 전에 개발 환경을 준비하고 기본 워크플로우를 이해하는 것이 중요합니다. 이 섹션에서는 MCP를 원활하게 시작할 수 있도록 초기 설정 단계를 안내합니다.

### 사전 준비 사항

MCP 개발에 들어가기 전에 다음을 준비하세요:

- **개발 환경**: 선택한 언어(C#, Java, Python, TypeScript, JavaScript)에 맞는 환경
- **IDE/에디터**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm 또는 최신 코드 에디터
- **패키지 관리자**: NuGet, Maven/Gradle, pip, npm/yarn 중 하나
- **API 키**: 호스트 애플리케이션에서 사용할 AI 서비스용 API 키

### 공식 SDK

다음 장에서는 Python, TypeScript, Java, .NET을 사용한 솔루션을 보게 됩니다. 다음은 공식 지원되는 모든 SDK입니다.

MCP는 여러 언어에 대해 공식 SDK를 제공합니다:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft와 협력하여 관리
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI와 협력하여 관리
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 공식 TypeScript 구현체
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 공식 Python 구현체
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 공식 Kotlin 구현체
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI와 협력하여 관리
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 공식 Rust 구현체

## 주요 내용 요약

- 언어별 SDK를 통해 MCP 개발 환경 설정이 간단함
- MCP 서버 구축 시 명확한 스키마를 가진 도구를 생성하고 등록함
- MCP 클라이언트는 서버와 모델에 연결하여 확장된 기능 활용
- 테스트와 디버깅은 신뢰할 수 있는 MCP 구현에 필수적임
- 배포 옵션은 로컬 개발부터 클라우드 기반 솔루션까지 다양함

## 실습

이 섹션의 모든 장에서 볼 수 있는 연습 문제를 보완하는 샘플 세트가 준비되어 있습니다. 각 장마다 자체 연습 문제와 과제도 포함되어 있습니다.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## 추가 자료

- [MCP GitHub 저장소](https://github.com/microsoft/mcp-for-beginners)

## 다음 단계

다음: [첫 번째 MCP 서버 만들기](/03-GettingStarted/01-first-server/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확성이 포함될 수 있음을 유의하시기 바랍니다. 원문은 해당 언어의 원본 문서가 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인한 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.