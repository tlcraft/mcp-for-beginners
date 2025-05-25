<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c37fabfbc0dcbc9a4afb6d17e7d3be9f",
  "translation_date": "2025-05-16T15:14:31+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "ko"
}
-->
다음 섹션에서는 시각적 인터페이스를 어떻게 사용하는지 더 자세히 이야기해 보겠습니다.

## 접근 방법

전체적인 접근 방식은 다음과 같습니다:

- MCP 서버를 찾을 수 있도록 파일을 구성합니다.
- 해당 서버를 시작하거나 연결하여 서버의 기능 목록을 가져옵니다.
- GitHub Copilot의 채팅 인터페이스를 통해 해당 기능들을 사용합니다.

좋습니다, 흐름을 이해했으니 이제 연습을 통해 Visual Studio Code에서 MCP 서버를 사용하는 방법을 시도해 봅시다.

## 연습: 서버 사용하기

이번 연습에서는 Visual Studio Code가 MCP 서버를 찾도록 구성하여 GitHub Copilot의 채팅 인터페이스에서 사용할 수 있도록 할 것입니다.

### -0- 사전 단계, MCP 서버 검색 활성화

MCP 서버 검색 기능을 활성화해야 할 수도 있습니다.

1. `File -> Preferences -> Settings`로 이동한 후 settings.json 파일에서 ` in Visual Studio Code.

1. Search for "MCP" and enable `chat.mcp.discovery.enabled 설정을 찾으세요.

### -1- 구성 파일 만들기

프로젝트 루트에 구성 파일을 만듭니다. .vscode 폴더 안에 MCP.json 파일을 생성해야 하며, 내용은 다음과 같아야 합니다:

```text
.vscode
|-- mcp.json
```

다음으로 서버 항목을 추가하는 방법을 살펴봅시다.

### -2- 서버 구성하기

*mcp.json* 파일에 다음 내용을 추가하세요:

```json
{
    "inputs": [],
    "servers": {
       "hello-mcp": {
           "command": "cmd",
           "args": [
               "/c", "node", "<absolute path>\\build\\index.js"
           ]
       }
    }
}
```

위 예시는 Node.js로 작성된 서버를 시작하는 간단한 예입니다. 다른 런타임의 경우 `command` and `args`를 사용하여 서버를 시작하는 적절한 명령어를 지정하세요.

### -3- 서버 시작하기

이제 항목을 추가했으니 서버를 시작해 봅시다:

1. *mcp.json*에서 항목을 찾고 "play" 아이콘을 확인하세요:

  ![Visual Studio Code에서 서버 시작하기](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.ko.png)

2. "play" 아이콘을 클릭하면 GitHub Copilot 채팅의 도구 아이콘에 사용 가능한 도구 수가 증가하는 것을 볼 수 있습니다. 도구 아이콘을 클릭하면 등록된 도구 목록이 나타납니다. 각 도구를 선택하거나 해제하여 GitHub Copilot이 해당 도구를 컨텍스트로 사용할지 결정할 수 있습니다:

  ![Visual Studio Code에서 도구 보기](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.ko.png)

3. 도구를 실행하려면, 도구 설명과 일치할 것으로 예상되는 프롬프트를 입력하세요. 예를 들어 "add 22 to 1" 같은 프롬프트를 입력하면:

  ![GitHub Copilot에서 도구 실행하기](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.ko.png)

  23이라는 응답을 받을 수 있습니다.

## 과제

*mcp.json* 파일에 서버 항목을 추가하고 서버를 시작 및 중지할 수 있는지 확인하세요. 또한 GitHub Copilot 채팅 인터페이스를 통해 서버의 도구와 통신할 수 있는지도 확인해 보세요.

## 해결책

[해결책](./solution/README.md)

## 주요 내용 정리

이번 장에서 얻을 수 있는 주요 내용은 다음과 같습니다:

- Visual Studio Code는 여러 MCP 서버와 그 도구를 사용할 수 있는 훌륭한 클라이언트입니다.
- GitHub Copilot의 채팅 인터페이스를 통해 서버와 상호작용합니다.
- 사용자가 입력한 API 키와 같은 정보를 프롬프트로 받아 *mcp.json* 파일에서 서버 항목을 구성할 때 MCP 서버로 전달할 수 있습니다.

## 샘플

- [Java 계산기](../samples/java/calculator/README.md)
- [.Net 계산기](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 계산기](../samples/javascript/README.md)
- [TypeScript 계산기](../samples/typescript/README.md)
- [Python 계산기](../../../../03-GettingStarted/samples/python)

## 추가 자료

- [Visual Studio 문서](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## 다음은

- 다음: [SSE 서버 만들기](/03-GettingStarted/05-sse-server/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 노력하고 있으나, 자동 번역에는 오류나 부정확성이 포함될 수 있음을 유의하시기 바랍니다. 원본 문서의 원어 버전이 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우, 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해서는 당사가 책임지지 않습니다.