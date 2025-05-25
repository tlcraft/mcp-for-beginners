<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-05-16T15:20:17+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "ko"
}
-->
# 샘플 실행하기

## -1- 의존성 설치하기

```bash
npm install
```

## -3- 샘플 실행하기


```bash
npm run build
```

## -4- 샘플 테스트하기

한 터미널에서 서버가 실행 중일 때, 다른 터미널을 열고 다음 명령어를 실행하세요:

```bash
npm run inspector
```

이 명령어는 샘플을 테스트할 수 있는 시각적 인터페이스가 있는 웹 서버를 시작합니다.

서버가 연결되면:

- 도구 목록을 확인하고 `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build`를 실행해 보세요.

- 별도의 터미널에서 다음 명령어를 실행하세요:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    이 명령어는 서버에서 사용 가능한 모든 도구를 나열합니다. 다음과 같은 출력이 표시될 것입니다:

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

다음과 같은 출력이 나타납니다:

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
> 인스펙터를 브라우저보다 CLI 모드에서 실행하는 것이 보통 훨씬 빠릅니다.
> 인스펙터에 대해 더 알아보려면 [여기](https://github.com/modelcontextprotocol/inspector)를 참고하세요.

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확한 부분이 있을 수 있음을 유의해 주시기 바랍니다. 원문은 해당 언어의 원본 문서를 권위 있는 출처로 간주해야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해서는 책임을 지지 않습니다.