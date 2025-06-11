<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:05:14+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "ko"
}
-->
# Practical Implementation

실제 구현은 Model Context Protocol(MCP)의 강력함을 체감할 수 있는 단계입니다. MCP의 이론과 아키텍처를 이해하는 것도 중요하지만, 진정한 가치는 이러한 개념을 활용해 실제 문제를 해결하는 솔루션을 구축, 테스트, 배포할 때 나타납니다. 이 장에서는 개념적 지식과 실무 개발 사이의 간극을 메우며, MCP 기반 애플리케이션을 구현하는 과정을 안내합니다.

지능형 어시스턴트를 개발하든, AI를 비즈니스 워크플로우에 통합하든, 데이터 처리용 맞춤형 도구를 만들든, MCP는 유연한 기반을 제공합니다. 언어에 구애받지 않는 설계와 주요 프로그래밍 언어용 공식 SDK 덕분에 다양한 개발자가 쉽게 접근할 수 있습니다. 이 SDK들을 활용하면 빠르게 프로토타입을 만들고, 반복하며, 다양한 플랫폼과 환경에서 솔루션을 확장할 수 있습니다.

다음 섹션에서는 C#, Java, TypeScript, JavaScript, Python에서 MCP를 구현하는 실용적인 예제, 샘플 코드, 배포 전략을 소개합니다. 또한 MCP 서버 디버깅과 테스트 방법, API 관리, Azure를 통한 클라우드 배포 방법도 배울 수 있습니다. 이 실습 자료들은 학습 속도를 높이고 자신 있게 견고한 프로덕션 수준의 MCP 애플리케이션을 구축할 수 있도록 설계되었습니다.

## Overview

이 수업은 여러 프로그래밍 언어에서 MCP를 실제로 구현하는 데 중점을 둡니다. C#, Java, TypeScript, JavaScript, Python용 MCP SDK를 사용해 견고한 애플리케이션을 만들고, MCP 서버를 디버깅 및 테스트하며, 재사용 가능한 리소스, 프롬프트, 도구를 만드는 방법을 살펴봅니다.

## Learning Objectives

이 수업을 마치면 다음을 할 수 있습니다:
- 다양한 프로그래밍 언어용 공식 SDK를 사용해 MCP 솔루션 구현하기
- MCP 서버를 체계적으로 디버깅하고 테스트하기
- 서버 기능(리소스, 프롬프트, 도구) 생성 및 활용하기
- 복잡한 작업을 위한 효과적인 MCP 워크플로우 설계하기
- 성능과 안정성을 고려한 MCP 구현 최적화하기

## Official SDK Resources

Model Context Protocol은 여러 언어용 공식 SDK를 제공합니다:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Working with MCP SDKs

이 섹션에서는 여러 프로그래밍 언어에서 MCP를 구현하는 실용적인 예제를 제공합니다. 샘플 코드는 `samples` 디렉토리에 언어별로 정리되어 있습니다.

### Available Samples

리포지토리에는 다음 언어별 샘플 구현이 포함되어 있습니다:

- C#
- Java
- TypeScript
- JavaScript
- Python

각 샘플은 해당 언어와 생태계에 맞는 주요 MCP 개념과 구현 패턴을 보여줍니다.

## Core Server Features

MCP 서버는 다음 기능들을 조합해 구현할 수 있습니다:

### Resources
리소스는 사용자나 AI 모델이 활용할 수 있는 컨텍스트와 데이터를 제공합니다:
- 문서 저장소
- 지식 기반
- 구조화된 데이터 소스
- 파일 시스템

### Prompts
프롬프트는 사용자용 템플릿 메시지와 워크플로우입니다:
- 미리 정의된 대화 템플릿
- 안내형 상호작용 패턴
- 특화된 대화 구조

### Tools
도구는 AI 모델이 실행할 수 있는 기능입니다:
- 데이터 처리 유틸리티
- 외부 API 통합
- 계산 기능
- 검색 기능

## Sample Implementations: C#

공식 C# SDK 리포지토리에는 MCP의 다양한 측면을 보여주는 여러 샘플 구현이 포함되어 있습니다:

- **Basic MCP Client**: MCP 클라이언트를 생성하고 도구를 호출하는 간단한 예제
- **Basic MCP Server**: 기본 도구 등록이 포함된 최소 서버 구현
- **Advanced MCP Server**: 도구 등록, 인증, 오류 처리 등 완전한 기능을 갖춘 서버
- **ASP.NET Integration**: ASP.NET Core와 통합하는 예제
- **Tool Implementation Patterns**: 다양한 복잡도 수준의 도구 구현 패턴

C# MCP SDK는 현재 프리뷰 상태이며 API가 변경될 수 있습니다. SDK 발전에 맞춰 블로그를 지속 업데이트할 예정입니다.

### Key Features 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- [첫 MCP 서버 구축하기](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)

완전한 C# 구현 샘플은 [공식 C# SDK 샘플 리포지토리](https://github.com/modelcontextprotocol/csharp-sdk)를 참고하세요.

## Sample implementation: Java Implementation

Java SDK는 엔터프라이즈급 기능을 갖춘 견고한 MCP 구현 옵션을 제공합니다.

### Key Features

- Spring Framework 통합
- 강력한 타입 안전성
- 리액티브 프로그래밍 지원
- 포괄적인 오류 처리

완전한 Java 구현 샘플은 샘플 디렉토리의 [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java)를 참고하세요.

## Sample implementation: JavaScript Implementation

JavaScript SDK는 가볍고 유연한 MCP 구현 방식을 제공합니다.

### Key Features

- Node.js 및 브라우저 지원
- 프로미스 기반 API
- Express 등 프레임워크와의 쉬운 통합
- 스트리밍을 위한 WebSocket 지원

완전한 JavaScript 구현 샘플은 샘플 디렉토리의 [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js)를 참고하세요.

## Sample implementation: Python Implementation

Python SDK는 뛰어난 ML 프레임워크 통합과 함께 파이썬다운 MCP 구현 방식을 제공합니다.

### Key Features

- asyncio 기반 async/await 지원
- Flask 및 FastAPI 통합
- 간단한 도구 등록
- 인기 있는 ML 라이브러리와의 네이티브 통합

완전한 Python 구현 샘플은 샘플 디렉토리의 [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py)를 참고하세요.

## API management 

Azure API Management는 MCP 서버 보안에 훌륭한 해답입니다. MCP 서버 앞에 Azure API Management 인스턴스를 두고, 다음과 같은 기능들을 맡길 수 있습니다:

- 요청 제한(rate limiting)
- 토큰 관리
- 모니터링
- 부하 분산(load balancing)
- 보안

### Azure Sample

다음은 MCP 서버를 만들고 Azure API Management로 보호하는 Azure 샘플입니다: [링크](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

아래 이미지는 인증 흐름을 보여줍니다:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

위 이미지에서 다음과 같은 일이 발생합니다:

- Microsoft Entra를 이용한 인증/인가가 진행됩니다.
- Azure API Management는 게이트웨이 역할을 하며 정책을 사용해 트래픽을 관리하고 조절합니다.
- Azure Monitor는 모든 요청을 기록해 추가 분석에 활용합니다.

#### Authorization flow

인증 흐름을 좀 더 자세히 살펴봅시다:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP authorization specification

[MCP 인증 명세](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)에 대해 더 알아보세요.

## Deploy Remote MCP Server to Azure

앞서 언급한 샘플을 배포해 봅시다:

1. 리포지토리 클론

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. `Microsoft.App` 공급자 등록

    `` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`

    등록 완료 여부를 확인하려면 잠시 기다리세요.

3. 다음 [azd](https://aka.ms/azd) 명령어로 API Management 서비스, 코드가 포함된 함수 앱, 기타 필요한 Azure 리소스를 프로비저닝하세요:

    ```shell
    azd up
    ```

    이 명령어는 Azure에 모든 클라우드 리소스를 배포합니다.

### Testing your server with MCP Inspector

1. **새 터미널 창**에서 MCP Inspector를 설치하고 실행하세요:

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    다음과 비슷한 인터페이스가 표시됩니다:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ko.png) 

2. 앱이 표시하는 URL(e.g. http://127.0.0.1:6274/#resources)에서 CTRL 클릭해 MCP Inspector 웹 앱을 로드하세요.
3. 전송 유형을 `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up`으로 설정하고 **Connect**를 클릭하세요:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **도구 목록 보기**. 도구를 클릭하고 **Run Tool**을 실행하세요.

모든 단계가 정상적으로 완료되면 MCP 서버에 연결되어 도구를 호출할 수 있습니다.

## MCP servers for Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): 이 리포지토리 세트는 Python, C# .NET, Node/TypeScript를 사용해 Azure Functions 기반의 맞춤형 원격 MCP 서버를 빠르게 구축하고 배포할 수 있는 템플릿입니다.

샘플은 개발자가 다음을 할 수 있게 완전한 솔루션을 제공합니다:

- 로컬에서 빌드 및 실행: 로컬 환경에서 MCP 서버 개발 및 디버깅
- Azure에 배포: 간단한 azd up 명령어로 클라우드에 배포
- 클라이언트 연결: VS Code Copilot 에이전트 모드, MCP Inspector 도구 등 다양한 클라이언트에서 MCP 서버에 연결

### Key Features:

- 설계 단계부터 보안 적용: 키와 HTTPS로 MCP 서버 보안 확보
- 인증 옵션: 내장 인증 및/또는 API Management를 통한 OAuth 지원
- 네트워크 격리: Azure Virtual Networks(VNET)를 통한 네트워크 분리 가능
- 서버리스 아키텍처: Azure Functions를 활용한 확장 가능하고 이벤트 기반 실행
- 로컬 개발 지원: 포괄적인 로컬 개발 및 디버깅 환경 제공
- 간편한 배포: Azure로의 배포 프로세스 간소화

리포지토리에는 프로덕션 수준 MCP 서버 구현을 빠르게 시작할 수 있도록 필요한 모든 구성 파일, 소스 코드, 인프라 정의가 포함되어 있습니다.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Python과 Azure Functions를 이용한 MCP 샘플 구현
- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - C# .NET과 Azure Functions를 이용한 MCP 샘플 구현
- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Node/TypeScript와 Azure Functions를 이용한 MCP 샘플 구현

## Key Takeaways

- MCP SDK는 언어별 맞춤 도구를 제공해 견고한 MCP 솔루션 구현을 지원합니다.
- 디버깅과 테스트 과정은 신뢰성 높은 MCP 애플리케이션을 위해 매우 중요합니다.
- 재사용 가능한 프롬프트 템플릿은 일관된 AI 상호작용을 가능하게 합니다.
- 잘 설계된 워크플로우는 여러 도구를 활용해 복잡한 작업을 조율할 수 있습니다.
- MCP 솔루션 구현 시 보안, 성능, 오류 처리에 대한 고려가 필요합니다.

## Exercise

실제 문제를 해결하는 실용적인 MCP 워크플로우를 설계해 보세요:

1. 이 문제 해결에 유용할 3~4개의 도구를 선정하세요.
2. 이 도구들이 어떻게 상호작용하는지 보여주는 워크플로우 다이어그램을 만드세요.
3. 선호하는 언어로 도구 중 하나의 기본 버전을 구현하세요.
4. 모델이 도구를 효과적으로 사용할 수 있도록 돕는 프롬프트 템플릿을 만드세요.

## Additional Resources


---

Next: [Advanced Topics](../05-AdvancedTopics/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확한 부분이 있을 수 있음을 유의하시기 바랍니다. 원문은 해당 언어의 원본 문서를 권위 있는 출처로 간주해야 합니다. 중요한 정보의 경우, 전문 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해서는 책임을 지지 않습니다.