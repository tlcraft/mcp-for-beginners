<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d5b044c0924d393af3066e03d7d89c5",
  "translation_date": "2025-07-16T09:39:15+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ko"
}
-->
### -2- 프로젝트 생성

SDK를 설치했으니, 이제 프로젝트를 만들어 봅시다.

### -3- 프로젝트 파일 생성

### -4- 서버 코드 작성

### -5- 도구와 리소스 추가

다음 코드를 추가하여 도구와 리소스를 추가하세요.

### -6- 최종 코드

서버를 시작할 수 있도록 마지막 코드를 추가해 봅시다.

### -7- 서버 테스트

다음 명령어로 서버를 시작하세요.

### -8- 인스펙터 사용하기

인스펙터는 서버를 실행하고 상호작용하며 작동 여부를 테스트할 수 있는 훌륭한 도구입니다. 시작해 봅시다.
> [!NOTE]  
> "command" 필드에는 특정 런타임에서 서버를 실행하는 명령어가 포함되어 있어 다르게 보일 수 있습니다.
다음과 같은 사용자 인터페이스가 보여야 합니다:

![Connect](/03-GettingStarted/01-first-server/assets/connect.png)

1. Connect 버튼을 선택하여 서버에 연결하세요.
  서버에 연결되면 다음 화면이 보여야 합니다:

  ![Connected](/03-GettingStarted/01-first-server/assets/connected.png)

1. "Tools"에서 "listTools"를 선택하면 "Add"가 나타납니다. "Add"를 선택하고 매개변수 값을 입력하세요.

  다음과 같은 응답, 즉 "add" 도구의 결과를 볼 수 있습니다:

  ![Result of running add](/03-GettingStarted/01-first-server/assets/ran-tool.png)

축하합니다, 첫 번째 서버를 성공적으로 만들고 실행했습니다!

### Official SDKs

MCP는 여러 언어에 대한 공식 SDK를 제공합니다:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft와 협력하여 유지 관리
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI와 협력하여 유지 관리
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - 공식 TypeScript 구현체
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - 공식 Python 구현체
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - 공식 Kotlin 구현체
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI와 협력하여 유지 관리
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - 공식 Rust 구현체

## 주요 내용 정리

- MCP 개발 환경 설정은 언어별 SDK로 간단하게 할 수 있습니다
- MCP 서버 구축은 명확한 스키마를 가진 도구를 생성하고 등록하는 과정입니다
- 테스트와 디버깅은 신뢰할 수 있는 MCP 구현에 필수적입니다

## 샘플

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## 과제

원하는 도구를 사용하여 간단한 MCP 서버를 만드세요:

1. 선호하는 언어(.NET, Java, Python, 또는 JavaScript)로 도구를 구현하세요.
2. 입력 매개변수와 반환 값을 정의하세요.
3. inspector 도구를 실행하여 서버가 의도대로 작동하는지 확인하세요.
4. 다양한 입력으로 구현을 테스트하세요.

## 솔루션

[Solution](./solution/README.md)

## 추가 자료

- [Azure에서 Model Context Protocol을 사용해 에이전트 빌드하기](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Apps와 함께하는 원격 MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP 에이전트](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## 다음 단계

다음: [MCP 클라이언트 시작하기](../02-client/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확한 부분이 있을 수 있음을 유의하시기 바랍니다. 원문은 해당 언어의 원본 문서가 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.