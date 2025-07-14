<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-07-13T20:19:16+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "ko"
}
-->
# 이 샘플 실행하기

## -1- 의존성 설치하기

```bash
npm install
```

## -3- 샘플 실행하기

```bash
npm run build
```

## -4- 샘플 테스트하기

서버가 한 터미널에서 실행 중일 때, 다른 터미널을 열고 다음 명령어를 실행하세요:

```bash
npm run inspector
```

이 명령어는 샘플을 테스트할 수 있는 시각적 인터페이스가 포함된 웹 서버를 시작합니다.

서버가 연결되면:

- 도구 목록을 확인하고 `add`를 실행해 보세요. 인수로 2와 4를 넣으면 결과에 6이 표시되어야 합니다.
- resources와 resource template로 이동해 "greeting"을 호출하고 이름을 입력하면, 입력한 이름이 포함된 인사말이 표시됩니다.

### CLI 모드에서 테스트하기

실행한 inspector는 실제로 Node.js 앱이며, `mcp dev`는 이를 감싸는 래퍼입니다.

- `npm run build` 명령어로 서버를 시작하세요.

- 별도의 터미널에서 다음 명령어를 실행하세요:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    이 명령어는 서버에서 사용 가능한 모든 도구를 나열합니다. 다음과 같은 출력이 보여야 합니다:

    ```text
    {
    "tools": [
        {
        "name": "add",
        "description": "Add two numbers",
        "inputSchema": {
            "type": "object",
            "properties": {
            "a": {
                "title": "A",
                "type": "integer"
            },
            "b": {
                "title": "B",
                "type": "integer"
            }
            },
            "required": [
            "a",
            "b"
            ],
            "title": "addArguments"
        }
        }
    ]
    }
    ```

- 다음 명령어를 입력해 도구 유형을 호출하세요:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

다음과 같은 출력이 보여야 합니다:

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> inspector를 브라우저 대신 CLI 모드에서 실행하는 것이 보통 훨씬 빠릅니다.
> inspector에 대해 더 자세히 알고 싶다면 [여기](https://github.com/modelcontextprotocol/inspector)를 참고하세요.

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확한 부분이 있을 수 있음을 유의해 주시기 바랍니다. 원문은 해당 언어의 원본 문서가 권위 있는 자료로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.