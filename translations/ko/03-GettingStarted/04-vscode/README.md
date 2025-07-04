<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "54e9ffc5dba01afcb8880a9949fd1881",
  "translation_date": "2025-07-04T16:20:10+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "ko"
}
-->
다음 섹션에서는 시각적 인터페이스를 어떻게 사용하는지 더 자세히 이야기해 보겠습니다.

## 접근 방법

전체적인 접근 방법은 다음과 같습니다:

- MCP 서버를 찾기 위한 설정 파일을 구성합니다.
- 해당 서버를 시작하거나 연결하여 서버가 제공하는 기능 목록을 가져옵니다.
- GitHub Copilot 채팅 인터페이스를 통해 해당 기능들을 사용합니다.

좋습니다, 흐름을 이해했으니 이제 연습을 통해 Visual Studio Code에서 MCP 서버를 사용하는 방법을 시도해 봅시다.

## 연습: 서버 사용하기

이번 연습에서는 Visual Studio Code가 MCP 서버를 찾을 수 있도록 설정하여 GitHub Copilot 채팅 인터페이스에서 사용할 수 있게 할 것입니다.

### -0- 사전 단계, MCP 서버 검색 활성화

MCP 서버 검색 기능을 활성화해야 할 수도 있습니다.

1. Visual Studio Code에서 `파일 -> 기본 설정 -> 설정`으로 이동합니다.

2. "MCP"를 검색한 후 settings.json 파일에서 `chat.mcp.discovery.enabled`를 활성화합니다.

### -1- 설정 파일 생성

프로젝트 루트에 설정 파일을 만듭니다. MCP.json이라는 파일을 .vscode 폴더 안에 위치시켜야 합니다. 파일 내용은 다음과 같아야 합니다:

```text
.vscode
|-- mcp.json
```

다음으로 서버 항목을 추가하는 방법을 살펴봅시다.

### -2- 서버 구성

*mcp.json* 파일에 다음 내용을 추가하세요:

```json
{
    "inputs": [],
    "servers": {
       "hello-mcp": {
           "command": "node",
           "args": [
               "build/index.js"
           ]
       }
    }
}
```

위 예시는 Node.js로 작성된 서버를 시작하는 간단한 예입니다. 다른 런타임을 사용할 경우 `command`와 `args`를 사용해 서버 시작에 적합한 명령어를 지정하세요.

### -3- 서버 시작

이제 항목을 추가했으니 서버를 시작해 봅시다:

1. *mcp.json*에서 추가한 항목을 찾고 "재생" 아이콘이 있는지 확인하세요:

  ![Visual Studio Code에서 서버 시작](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.ko.png)  

2. "재생" 아이콘을 클릭하면 GitHub Copilot 채팅의 도구 아이콘에 사용 가능한 도구 수가 증가하는 것을 볼 수 있습니다. 도구 아이콘을 클릭하면 등록된 도구 목록이 나타납니다. 각 도구를 체크하거나 해제하여 GitHub Copilot이 해당 도구를 컨텍스트로 사용할지 선택할 수 있습니다:

  ![Visual Studio Code에서 도구 보기](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.ko.png)

3. 도구를 실행하려면, 도구 설명과 일치하는 프롬프트를 입력하세요. 예를 들어 "add 22 to 1" 같은 프롬프트를 입력합니다:

  ![GitHub Copilot에서 도구 실행](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.ko.png)

  그러면 23이라는 응답을 볼 수 있을 것입니다.

## 과제

*mcp.json* 파일에 서버 항목을 추가하고 서버를 시작/중지할 수 있는지 확인하세요. 또한 GitHub Copilot 채팅 인터페이스를 통해 서버의 도구와 통신할 수 있는지 확인하세요.

## 해결책

[해결책](./solution/README.md)

## 주요 내용 정리

이 장에서 얻을 수 있는 주요 내용은 다음과 같습니다:

- Visual Studio Code는 여러 MCP 서버와 그 도구들을 사용할 수 있는 훌륭한 클라이언트입니다.
- GitHub Copilot 채팅 인터페이스를 통해 서버와 상호작용합니다.
- *mcp.json* 파일에서 서버 항목을 구성할 때 API 키와 같은 사용자 입력을 프롬프트로 받아 MCP 서버에 전달할 수 있습니다.

## 샘플

- [Java 계산기](../samples/java/calculator/README.md)
- [.Net 계산기](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 계산기](../samples/javascript/README.md)
- [TypeScript 계산기](../samples/typescript/README.md)
- [Python 계산기](../../../../03-GettingStarted/samples/python)

## 추가 자료

- [Visual Studio 문서](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## 다음 단계

- 다음: [SSE 서버 만들기](../05-sse-server/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확한 부분이 있을 수 있음을 유의하시기 바랍니다. 원문은 해당 언어의 원본 문서가 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.