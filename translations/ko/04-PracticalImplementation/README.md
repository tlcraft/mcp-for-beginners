<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-16T15:34:37+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "ko"
}
-->
# Practical Implementation

실제 구현은 Model Context Protocol(MCP)의 힘이 실질적으로 드러나는 부분입니다. MCP의 이론과 아키텍처를 이해하는 것도 중요하지만, 진짜 가치는 이러한 개념을 적용해 실제 문제를 해결하는 솔루션을 구축, 테스트, 배포할 때 나타납니다. 이 장에서는 개념적인 지식과 실무 개발 사이의 간극을 메우며, MCP 기반 애플리케이션을 실제로 구현하는 과정을 안내합니다.

지능형 어시스턴트를 개발하든, AI를 비즈니스 워크플로우에 통합하든, 데이터 처리용 맞춤 도구를 만들든, MCP는 유연한 기반을 제공합니다. 언어에 구애받지 않는 설계와 주요 프로그래밍 언어용 공식 SDK 덕분에 다양한 개발자가 쉽게 접근할 수 있습니다. 이 SDK들을 활용하면 빠르게 프로토타입을 만들고 반복하며, 다양한 플랫폼과 환경에서 솔루션을 확장할 수 있습니다.

다음 섹션에서는 C#, Java, TypeScript, JavaScript, Python에서 MCP를 구현하는 실제 예제, 샘플 코드, 배포 전략을 다룹니다. MCP 서버를 디버깅하고 테스트하는 방법, API를 관리하는 방법, Azure를 이용해 클라우드에 솔루션을 배포하는 방법도 배울 수 있습니다. 이러한 실습 자료는 학습 속도를 높이고 견고한 프로덕션 수준의 MCP 애플리케이션을 자신 있게 구축하는 데 도움을 줍니다.

## Overview

이 수업은 여러 프로그래밍 언어에서 MCP를 실무적으로 구현하는 방법에 초점을 맞춥니다. C#, Java, TypeScript, JavaScript, Python용 MCP SDK를 사용해 견고한 애플리케이션을 만들고, MCP 서버를 디버깅 및 테스트하며, 재사용 가능한 리소스, 프롬프트, 도구를 생성하는 방법을 살펴봅니다.

## Learning Objectives

이 수업이 끝나면 다음을 할 수 있습니다:
- 다양한 프로그래밍 언어용 공식 SDK를 사용해 MCP 솔루션 구현
- MCP 서버를 체계적으로 디버깅하고 테스트
- 서버 기능(리소스, 프롬프트, 도구) 생성 및 활용
- 복잡한 작업을 위한 효과적인 MCP 워크플로우 설계
- 성능과 신뢰성을 위한 MCP 구현 최적화

## Official SDK Resources

Model Context Protocol은 다음 언어별 공식 SDK를 제공합니다:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Working with MCP SDKs

이 섹션에서는 여러 프로그래밍 언어에서 MCP를 구현하는 실제 예제를 제공합니다. `samples` 디렉터리에서 언어별로 정리된 샘플 코드를 확인할 수 있습니다.

### Available Samples

저장소에는 다음 언어별 샘플 구현이 포함되어 있습니다:

- C#
- Java
- TypeScript
- JavaScript
- Python

각 샘플은 해당 언어와 생태계에 맞는 주요 MCP 개념과 구현 패턴을 보여줍니다.

## Core Server Features

MCP 서버는 다음 기능들을 조합하여 구현할 수 있습니다:

### Resources
리소스는 사용자나 AI 모델이 활용할 수 있는 컨텍스트와 데이터를 제공합니다:
- 문서 저장소
- 지식 베이스
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

공식 C# SDK 저장소에는 MCP의 다양한 측면을 보여주는 여러 샘플 구현이 포함되어 있습니다:

- **Basic MCP Client**: MCP 클라이언트를 생성하고 도구를 호출하는 간단한 예제
- **Basic MCP Server**: 기본 도구 등록이 포함된 최소 서버 구현
- **Advanced MCP Server**: 도구 등록, 인증, 오류 처리 등 완전한 기능의 서버
- **ASP.NET Integration**: ASP.NET Core와 통합하는 예제
- **Tool Implementation Patterns**: 다양한 복잡도의 도구 구현 패턴

MCP C# SDK는 현재 프리뷰 단계이며 API가 변경될 수 있습니다. SDK가 발전함에 따라 이 블로그를 지속적으로 업데이트할 예정입니다.

### Key Features 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- [첫 MCP 서버 구축하기](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

완전한 C# 구현 샘플은 [공식 C# SDK 샘플 저장소](https://github.com/modelcontextprotocol/csharp-sdk)를 방문하세요.

## Sample implementation: Java Implementation

Java SDK는 기업용 기능을 갖춘 견고한 MCP 구현 옵션을 제공합니다.

### Key Features

- Spring Framework 통합
- 강력한 타입 안정성
- 리액티브 프로그래밍 지원
- 포괄적인 오류 처리

완전한 Java 구현 샘플은 샘플 디렉터리의 [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java)를 참고하세요.

## Sample implementation: JavaScript Implementation

JavaScript SDK는 가볍고 유연한 MCP 구현 방식을 제공합니다.

### Key Features

- Node.js 및 브라우저 지원
- Promise 기반 API
- Express 등 프레임워크와 손쉬운 통합
- 스트리밍용 WebSocket 지원

완전한 JavaScript 구현 샘플은 샘플 디렉터리의 [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js)를 참고하세요.

## Sample implementation: Python Implementation

Python SDK는 뛰어난 ML 프레임워크 통합과 함께 파이썬다운 MCP 구현 방식을 제공합니다.

### Key Features

- asyncio를 이용한 async/await 지원
- Flask 및 FastAPI 통합
- 간단한 도구 등록
- 주요 ML 라이브러리와의 네이티브 통합

완전한 Python 구현 샘플은 샘플 디렉터리의 [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py)를 참고하세요.

## API management 

Azure API Management는 MCP 서버를 안전하게 보호하는 훌륭한 방법입니다. MCP 서버 앞에 Azure API Management 인스턴스를 두고 다음과 같은 기능을 처리하도록 할 수 있습니다:

- 속도 제한
- 토큰 관리
- 모니터링
- 부하 분산
- 보안

### Azure Sample

아래는 MCP 서버를 생성하고 Azure API Management로 보호하는 예제입니다: [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

아래 이미지를 통해 인증 흐름을 확인하세요:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

위 이미지에서 다음과 같은 일이 발생합니다:

- Microsoft Entra를 이용한 인증/인가가 수행됩니다.
- Azure API Management가 게이트웨이 역할을 하며 정책을 통해 트래픽을 관리합니다.
- Azure Monitor가 모든 요청을 기록해 추가 분석에 활용합니다.

#### Authorization flow

인증 흐름을 좀 더 자세히 살펴봅시다:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP authorization specification

[MCP 인증 명세](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)를 더 알아보세요.

## Deploy Remote MCP Server to Azure

앞서 언급한 샘플을 Azure에 배포해 봅시다:

1. 저장소 클론

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. `Microsoft.App` 공급자 등록 후 상태 확인

    `` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`

3. 다음 [azd](https://aka.ms/azd) 명령어로 API 관리 서비스, 함수 앱(코드 포함), 기타 필요한 Azure 리소스를 프로비저닝

    ```shell
    azd up
    ```

    이 명령어로 Azure에 모든 클라우드 리소스가 배포됩니다.

### Testing your server with MCP Inspector

1. **새 터미널 창**에서 MCP Inspector 설치 및 실행

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    다음과 유사한 인터페이스가 나타납니다:

    ![Connect to Node inspector](../../../translated_images/connect.9f4ccffc595d24b85ce22579ddf26016b5f21d941d544568c1b9752a51d0a4b1.ko.png)

2. 앱에서 표시된 URL(e.g. http://127.0.0.1:6274/#resources)을 CTRL 클릭해 MCP Inspector 웹 앱 로드
3. 전송 유형을 `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up`로 설정하고 **Connect** 클릭:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools**. 도구를 클릭하고 **Run Tool** 실행.

모든 단계가 정상적으로 완료되면 MCP 서버에 연결되어 도구를 호출할 수 있습니다.

## MCP servers for Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): 이 저장소 세트는 Python, C# .NET, Node/TypeScript를 사용해 Azure Functions로 맞춤형 원격 MCP 서버를 빠르게 구축하고 배포할 수 있는 템플릿입니다.

샘플은 개발자가 다음을 수행할 수 있도록 완전한 솔루션을 제공합니다:

- 로컬에서 빌드 및 실행: 로컬 머신에서 MCP 서버 개발 및 디버깅
- Azure에 배포: 간단한 azd up 명령으로 클라우드에 쉽게 배포
- 클라이언트 연결: VS Code의 Copilot 에이전트 모드, MCP Inspector 도구 등 다양한 클라이언트에서 MCP 서버에 연결

### Key Features:

- 보안 설계: 키와 HTTPS를 사용해 MCP 서버 보안 유지
- 인증 옵션: 내장 인증 및/또는 API Management를 통한 OAuth 지원
- 네트워크 격리: Azure Virtual Networks(VNET)를 이용한 네트워크 격리 가능
- 서버리스 아키텍처: Azure Functions를 활용한 확장 가능하고 이벤트 기반 실행
- 로컬 개발 지원: 포괄적인 로컬 개발 및 디버깅 지원
- 간단한 배포: Azure로의 간소화된 배포 프로세스

저장소에는 프로덕션 수준 MCP 서버 구현을 빠르게 시작할 수 있도록 필요한 모든 구성 파일, 소스 코드, 인프라 정의가 포함되어 있습니다.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Python용 Azure Functions를 활용한 MCP 샘플 구현

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - C# .NET용 Azure Functions를 활용한 MCP 샘플 구현

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Node/TypeScript용 Azure Functions를 활용한 MCP 샘플 구현

## Key Takeaways

- MCP SDK는 언어별로 견고한 MCP 솔루션 구현을 위한 도구를 제공합니다
- 디버깅과 테스트 과정은 신뢰할 수 있는 MCP 애플리케이션을 위한 핵심 단계입니다
- 재사용 가능한 프롬프트 템플릿으로 일관된 AI 상호작용을 지원합니다
- 잘 설계된 워크플로우는 여러 도구를 사용해 복잡한 작업을 조율할 수 있습니다
- MCP 솔루션 구현 시 보안, 성능, 오류 처리에 대한 고려가 필요합니다

## Exercise

자신의 분야에서 실제 문제를 해결하는 실용적인 MCP 워크플로우를 설계해 보세요:

1. 문제 해결에 유용할 도구 3-4개를 선정하세요
2. 이 도구들이 어떻게 상호작용하는지 워크플로우 다이어그램을 만드세요
3. 선호하는 언어로 도구 중 하나의 기본 버전을 구현하세요
4. 모델이 도구를 효과적으로 활용할 수 있도록 돕는 프롬프트 템플릿을 만드세요

## Additional Resources


---

Next: [Advanced Topics](../05-AdvancedTopics/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 노력하고 있으나, 자동 번역에는 오류나 부정확한 부분이 있을 수 있음을 유의하시기 바랍니다. 원본 문서의 원어 버전이 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인한 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.