<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "96e08a8c1049dab757deb64cce4ea1e8",
  "translation_date": "2025-05-16T15:16:01+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "ko"
}
-->
# 샘플 실행하기

여기서는 이미 작동하는 서버 코드를 가지고 있다고 가정합니다. 이전 장 중 하나에서 서버를 찾아보세요.

## mcp.json 설정하기

참고용으로 사용할 파일이 있습니다, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

서버 항목을 필요에 따라 수정하여 서버의 절대 경로와 실행에 필요한 전체 명령어를 지정하세요.

위에서 언급한 예제 파일의 서버 항목은 다음과 같습니다:

```json
"hello-mcp": {
    "command": "cmd",
    "args": [
        "/c", "node", "<absolute path>\\build\\index.js"
    ]
}
```

이것은 다음과 같은 명령어를 실행하는 것과 같습니다: `cmd /c node <절대 경로>\\build\index.js`. 

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder, 

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` "add 3 to 20"과 같은 내용을 입력해 보세요.

    채팅 입력창 위에 도구 실행을 선택할 수 있는 표시가 나타나는 것을 볼 수 있을 것입니다. 다음과 같은 화면입니다:

    ![VS Code가 도구 실행을 원함을 나타내는 모습](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.ko.png)

    도구를 선택하면 이전에 언급한 대로 프롬프트가 입력되었을 경우 "23"이라는 숫자 결과가 출력될 것입니다.

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역은 오류나 부정확성이 포함될 수 있음을 유의해 주시기 바랍니다. 원본 문서의 원어가 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역의 사용으로 인한 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.