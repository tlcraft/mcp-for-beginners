<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8ea28e5e566edd5969337fd0b191ba3f",
  "translation_date": "2025-07-16T21:50:07+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "ko"
}
-->
# GitHub Copilot Agent 모드에서 서버 사용하기

Visual Studio Code와 GitHub Copilot은 클라이언트 역할을 하여 MCP 서버를 사용할 수 있습니다. 왜 이렇게 하냐고요? MCP 서버가 제공하는 모든 기능을 IDE 내에서 바로 사용할 수 있다는 뜻입니다. 예를 들어 GitHub의 MCP 서버를 추가하면, 터미널에 특정 명령어를 입력하는 대신 자연어 프롬프트로 GitHub을 제어할 수 있습니다. 개발자 경험을 자연어로 제어할 수 있다면 얼마나 편리할지 상상해 보세요. 이제 이점이 보이시죠?

## 개요

이 강의에서는 Visual Studio Code와 GitHub Copilot의 Agent 모드를 사용해 MCP 서버의 클라이언트로 활용하는 방법을 다룹니다.

## 학습 목표

이 강의를 마치면 다음을 할 수 있습니다:

- Visual Studio Code를 통해 MCP 서버를 사용하기.
- GitHub Copilot을 통해 도구 같은 기능 실행하기.
- Visual Studio Code를 설정해 MCP 서버를 찾고 관리하기.

## 사용법

MCP 서버는 두 가지 방법으로 제어할 수 있습니다:

- 사용자 인터페이스: 이 장 후반부에서 자세히 다룹니다.
- 터미널: `code` 실행 파일을 사용해 터미널에서 제어할 수 있습니다.

  사용자 프로필에 MCP 서버를 추가하려면 --add-mcp 명령줄 옵션을 사용하고, JSON 서버 구성을 {\"name\":\"server-name\",\"command\":...} 형태로 제공하세요.

  ```
  code --add-mcp "{\"name\":\"my-server\",\"command\": \"uvx\",\"args\": [\"mcp-server-fetch\"]}"
  ```

### 스크린샷

![Visual Studio Code에서 안내되는 MCP 서버 구성](../../../../translated_images/chat-mode-agent.729a22473f822216dd1e723aaee1f7d4a2ede571ee0948037a2d9357a63b9d0b.ko.png)  
![에이전트 세션별 도구 선택](../../../../translated_images/agent-mode-select-tools.522c7ba5df0848f8f0d1e439c2e96159431bc620cb39ccf3f5dc611412fd0006.ko.png)  
![MCP 개발 중 오류를 쉽게 디버깅](../../../../translated_images/mcp-list-servers.fce89eefe3f30032bed8952e110ab9d82fadf043fcfa071f7d40cf93fb1ea9e9.ko.png)

다음 섹션에서 시각적 인터페이스 사용법을 더 자세히 살펴보겠습니다.

## 접근 방법

전체적인 흐름은 다음과 같습니다:

- MCP 서버를 찾기 위한 설정 파일 구성.
- 서버를 시작하거나 연결해 기능 목록을 가져오기.
- GitHub Copilot Chat 인터페이스를 통해 해당 기능 사용하기.

이제 흐름을 이해했으니, Visual Studio Code를 통해 MCP 서버를 사용하는 연습을 해봅시다.

## 연습: 서버 사용하기

이번 연습에서는 Visual Studio Code를 설정해 MCP 서버를 찾아 GitHub Copilot Chat 인터페이스에서 사용할 수 있도록 합니다.

### -0- 사전 단계, MCP 서버 검색 활성화

MCP 서버 검색 기능을 활성화해야 할 수도 있습니다.

1. Visual Studio Code에서 `File -> Preferences -> Settings`로 이동하세요.

1. "MCP"를 검색한 후 settings.json 파일에서 `chat.mcp.discovery.enabled`를 활성화하세요.

### -1- 설정 파일 만들기

프로젝트 루트에 설정 파일을 만드세요. MCP.json 파일을 .vscode 폴더 안에 위치시켜야 합니다. 내용은 다음과 같아야 합니다:

```text
.vscode
|-- mcp.json
```

다음으로 서버 항목을 추가하는 방법을 살펴봅니다.

### -2- 서버 구성하기

*mcp.json*에 다음 내용을 추가하세요:

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

위 예시는 Node.js로 작성된 서버를 시작하는 간단한 예입니다. 다른 런타임을 사용할 경우 `command`와 `args`에 적절한 서버 시작 명령을 지정하세요.

### -3- 서버 시작하기

항목을 추가했으면 서버를 시작해봅시다:

1. *mcp.json*에서 항목을 찾고 "재생" 아이콘이 있는지 확인하세요:

  ![Visual Studio Code에서 서버 시작](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.ko.png)  

1. "재생" 아이콘을 클릭하면 GitHub Copilot Chat의 도구 아이콘에 사용 가능한 도구 수가 늘어나는 것을 볼 수 있습니다. 도구 아이콘을 클릭하면 등록된 도구 목록이 나타납니다. 각 도구를 체크하거나 해제해 GitHub Copilot이 컨텍스트로 사용할지 선택할 수 있습니다:

  ![Visual Studio Code에서 도구 선택](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.ko.png)

1. 도구를 실행하려면, 도구 설명과 일치하는 프롬프트를 입력하세요. 예를 들어 "add 22 to 1" 같은 프롬프트를 입력하면:

  ![GitHub Copilot에서 도구 실행](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.ko.png)

  결과로 23이라는 응답을 받을 수 있습니다.

## 과제

*mcp.json* 파일에 서버 항목을 추가하고 서버를 시작/중지할 수 있는지 확인하세요. 또한 GitHub Copilot Chat 인터페이스를 통해 서버의 도구와 통신할 수 있는지 테스트해 보세요.

## 해답

[해답](./solution/README.md)

## 주요 내용 정리

이번 장에서 얻은 주요 내용은 다음과 같습니다:

- Visual Studio Code는 여러 MCP 서버와 도구를 사용할 수 있는 훌륭한 클라이언트입니다.
- GitHub Copilot Chat 인터페이스를 통해 서버와 상호작용합니다.
- *mcp.json* 파일에서 서버 항목을 구성할 때 API 키 같은 사용자 입력을 받아 MCP 서버에 전달할 수 있습니다.

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
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확한 부분이 있을 수 있음을 유의해 주시기 바랍니다. 원문은 해당 언어의 원본 문서가 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.